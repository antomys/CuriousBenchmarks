using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Maverick.Json
{
    [DebuggerNonUserCode]
    internal static class ThrowHelper
    {
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void ThrowObjectDisposed( String objectName ) => throw new ObjectDisposedException( objectName );
    }
}
