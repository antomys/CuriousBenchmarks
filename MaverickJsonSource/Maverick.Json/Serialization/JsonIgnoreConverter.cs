using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Maverick.Json.Serialization
{
    /// <summary>
    /// A special type that instructs the contract resolver to return contract without
    /// any user defined converters.
    /// </summary>
    internal sealed class JsonIgnoreConverter : Type
    {
        public static JsonIgnoreConverter FromType( Type type ) => s_types.GetOrAdd( type, s_factory );


        private JsonIgnoreConverter( Type type )
        {
            UnderlyingType = type ?? throw new ArgumentNullException( nameof( Type ) );
        }


        public Type UnderlyingType { get; }
        public override Assembly Assembly => UnderlyingType.Assembly;
        public override String AssemblyQualifiedName => UnderlyingType.AssemblyQualifiedName;
        public override Type BaseType => UnderlyingType.BaseType;
        public override String FullName => UnderlyingType.FullName;
        public override Guid GUID => UnderlyingType.GUID;
        public override Module Module => UnderlyingType.Module;
        public override String Namespace => UnderlyingType.Namespace;
        public override Type UnderlyingSystemType => UnderlyingType.UnderlyingSystemType;
        public override String Name => UnderlyingType.Name;
        public override ConstructorInfo[] GetConstructors( BindingFlags bindingAttr ) => UnderlyingType.GetConstructors( bindingAttr );
        public override Object[] GetCustomAttributes( Boolean inherit ) => UnderlyingType.GetCustomAttributes( inherit );
        public override Object[] GetCustomAttributes( Type attributeType, Boolean inherit ) => UnderlyingType.GetCustomAttributes( attributeType, inherit );
        public override Type GetElementType() => UnderlyingType.GetElementType();
        public override EventInfo GetEvent( String name, BindingFlags bindingAttr ) => UnderlyingType.GetEvent( name, bindingAttr );
        public override EventInfo[] GetEvents( BindingFlags bindingAttr ) => UnderlyingType.GetEvents( bindingAttr );
        public override FieldInfo GetField( String name, BindingFlags bindingAttr ) => UnderlyingType.GetField( name, bindingAttr );
        public override FieldInfo[] GetFields( BindingFlags bindingAttr ) => UnderlyingType.GetFields( bindingAttr );
        public override Type GetInterface( String name, Boolean ignoreCase ) => UnderlyingType.GetInterface( name, ignoreCase );
        public override Type[] GetInterfaces() => UnderlyingType.GetInterfaces();
        public override MemberInfo[] GetMembers( BindingFlags bindingAttr ) => UnderlyingType.GetMembers( bindingAttr );
        public override MethodInfo[] GetMethods( BindingFlags bindingAttr ) => UnderlyingType.GetMethods( bindingAttr );
        public override Type GetNestedType( String name, BindingFlags bindingAttr ) => UnderlyingType.GetNestedType( name, bindingAttr );
        public override Type[] GetNestedTypes( BindingFlags bindingAttr ) => UnderlyingType.GetNestedTypes( bindingAttr );
        public override PropertyInfo[] GetProperties( BindingFlags bindingAttr ) => UnderlyingType.GetProperties( bindingAttr );
        public override Object InvokeMember( String name, BindingFlags invokeAttr, Binder binder, Object target, Object[] args, ParameterModifier[] modifiers, CultureInfo culture, String[] namedParameters ) => UnderlyingType.InvokeMember( name, invokeAttr, binder, target, args, modifiers, culture, namedParameters );
        public override Boolean IsDefined( Type attributeType, Boolean inherit ) => UnderlyingType.IsDefined( attributeType, inherit );
        protected override TypeAttributes GetAttributeFlagsImpl() => UnderlyingType.Attributes;
        protected override ConstructorInfo GetConstructorImpl( BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers ) => UnderlyingType.GetConstructor( bindingAttr, binder, callConvention, types, modifiers );
        protected override MethodInfo GetMethodImpl( String name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers ) => UnderlyingType.GetMethod( name, bindingAttr, binder, callConvention, types, modifiers );
        protected override PropertyInfo GetPropertyImpl( String name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers ) => UnderlyingType.GetProperty( name, bindingAttr, binder, returnType, types, modifiers );
        protected override Boolean HasElementTypeImpl() => UnderlyingType.HasElementType;
        protected override Boolean IsArrayImpl() => UnderlyingType.IsArray;
        protected override Boolean IsByRefImpl() => UnderlyingType.IsByRef;
        protected override Boolean IsCOMObjectImpl() => UnderlyingType.IsCOMObject;
        protected override Boolean IsPointerImpl() => UnderlyingType.IsPointer;
        protected override Boolean IsPrimitiveImpl() => UnderlyingType.IsPrimitive;


        public override Boolean Equals( Type o ) => ReferenceEquals( this, o );


        public override Int32 GetHashCode() => RuntimeHelpers.GetHashCode( this );


        private static readonly ConcurrentDictionary<Type, JsonIgnoreConverter> s_types = new ConcurrentDictionary<Type, JsonIgnoreConverter>();
        private static readonly Func<Type, JsonIgnoreConverter> s_factory = x => new JsonIgnoreConverter( x );
    }
}
