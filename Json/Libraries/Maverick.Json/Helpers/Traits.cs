using System;

namespace Maverick.Json
{
    internal static class Traits<T>
    {
        private static Type Type => typeof( T );

        public static readonly Type NonNullableType = Nullable.GetUnderlyingType( Type ) ?? Type;
        public static readonly Boolean IsValueType = Type.IsValueType;
        public static readonly Boolean IsReferenceType = Type.IsClass || Type.IsInterface;
        public static readonly Boolean IsReferenceTypeOrNullable = IsReferenceType || ( Type.IsGenericType && Type.GetGenericTypeDefinition() == typeof( Nullable<> ) );
        public static readonly Boolean IsPopulatable = IsReferenceType && Type != typeof( String );
    }
}
