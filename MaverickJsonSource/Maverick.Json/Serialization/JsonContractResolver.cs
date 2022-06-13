using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Maverick.Json.Serialization
{
    public class JsonContractResolver
    {
        internal JsonContract CreateContract( Type objectType, JsonSettings settings )
        {
            if ( objectType == typeof( Object ) )
                return JsonObjectContract.Instance;

            var ignoreConverter = false;

            if ( objectType is JsonIgnoreConverter ignoreConverterType )
            {
                ignoreConverter = true;
                objectType = ignoreConverterType.UnderlyingType;
            }

            var contract = (JsonContract)s_createObjectContractMethod
                .MakeGenericMethod( objectType )
                .Invoke( this, new Object[] { settings, ignoreConverter } );

            contract.Freeze();

            return contract;
        }


        private JsonContract CreateContractCore<T>( JsonSettings settings, Boolean ignoreConverter )
        {
            var objectType = typeof( T );

            // Always resolve primitive contracts first. They are not allowed to have converters.
            if ( JsonPrimitiveContract.TryCreate( objectType, out var primitiveContract ) )
                return primitiveContract;

            if ( !ignoreConverter )
            {
                // Anything but a primitive type can have a converter.
                var converter = ResolveConverter( objectType, settings );

                if ( converter != null )
                {
                    return new JsonConverterContract<T>( converter, CreateContract() );
                }
            }

            return CreateContract();

            JsonContract CreateContract()
            {
                if ( JsonArrayContract.TryCreate( objectType, out var arrayContract ) )
                    return arrayContract;

                if ( JsonDynamicContract.TryCreate( objectType, out var dynamicContract ) )
                    return dynamicContract;

                if ( JsonDictionaryContract.TryCreate( objectType, out var dictionaryContract ) )
                    return dictionaryContract;

                if ( JsonCollectionContract<T>.TryCreate( out var collectionContract ) )
                    return collectionContract;

                return CreateObjectContract<T>( settings );
            }
        }


        protected virtual List<MemberInfo> GetSerializableMembers( Type objectType )
        {
            var explicitMembers = ReflectionHelpers.GetAttribute<JsonExplicitMembersAttribute>( objectType ) != null;
            var allMembers = ReflectionHelpers.GetFieldsAndProperties( objectType, includePrivate: true );
            var defaultMembers = ReflectionHelpers.GetFieldsAndProperties( objectType, includePrivate: false );
            var serializableMembers = new List<MemberInfo>();

            foreach ( var member in allMembers )
            {
                if ( ReflectionHelpers.GetAttribute<JsonIgnoreAttribute>( member ) != null )
                    continue;

                // Some types aren't serializable
                var memberType = ReflectionHelpers.GetFieldOrPropertyType( member );

                if ( typeof( Delegate ).IsAssignableFrom( memberType ) )
                    continue;

                if ( memberType.IsValueType &&
                     memberType.GetCustomAttributes().Any( x => x.GetType().FullName == "System.Runtime.CompilerServices.IsByRefLikeAttribute" ) )
                    continue;

                if ( ReflectionHelpers.GetAttribute<JsonPropertyAttribute>( member ) != null )
                {
                    serializableMembers.Add( member );
                }
                else if ( !explicitMembers && defaultMembers.Contains( member ) )
                {
                    // If explicit members is not required then the property must be contained in the default members
                    serializableMembers.Add( member );
                }
            }

            return serializableMembers;
        }


        ref struct Test { }

        protected internal virtual JsonObjectContract<TOwner> CreateObjectContract<TOwner>( JsonSettings settings )
        {
            var contract = new JsonObjectContract<TOwner>( settings );
            contract.Properties.AddRange( CreateProperties( contract ) );

            return contract;
        }


        protected virtual JsonPropertyCollection<TOwner> CreateProperties<TOwner>( JsonObjectContract<TOwner> contract )
        {
            var properties = new JsonPropertyCollection<TOwner>( contract.Settings.NamingStrategy );
            var method = typeof( JsonContractResolver ).GetMethod( nameof( CreateProperty ), BindingFlags.Instance | BindingFlags.NonPublic );

            foreach ( var member in GetSerializableMembers( typeof( TOwner ) ) ?? Enumerable.Empty<MemberInfo>() )
            {
                var propertyType = ReflectionHelpers.GetFieldOrPropertyType( member );
                var property = (JsonProperty<TOwner>)method.MakeGenericMethod( typeof( TOwner ), propertyType )
                                                           .Invoke( this, new Object[] { contract, member } );

                if ( property != null )
                {
                    properties.Add( property );
                }
            }

            return properties;
        }


        protected virtual JsonProperty<TOwner, TProperty> CreateProperty<TOwner, TProperty>( JsonObjectContract<TOwner> contract, MemberInfo member )
        {
            var property = new JsonProperty<TOwner, TProperty>( contract, member );

            if ( property.Converter == null )
            {
                // Check if converter has been specified in the settings
                property.Converter = ResolveConverter( typeof( TProperty ), contract.Settings );
            }

            return property;
        }


        protected virtual JsonConverter ResolveConverter( Type objectType, JsonSettings settings )
        {
            var converters = settings.Converters;

            for ( var i = 0; i < converters.Count; ++i )
            {
                if ( converters[ i ].CanConvert( objectType ) )
                {
                    return converters[ i ];
                }
            }

            return ReflectionHelpers.GetAttribute<JsonConverterAttribute>( objectType )?.CreateInstance( objectType );
        }


        private static readonly MethodInfo s_createObjectContractMethod = typeof( JsonContractResolver ).GetMethod( nameof( CreateContractCore ), BindingFlags.Instance | BindingFlags.NonPublic );
    }
}
