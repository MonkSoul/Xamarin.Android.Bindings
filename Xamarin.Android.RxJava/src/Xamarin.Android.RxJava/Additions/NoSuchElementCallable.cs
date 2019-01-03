using Java.Util.Concurrent;
using System;

namespace IO.Reactivex.Internal.Operators.Single
{
    public sealed partial class SingleInternalHelper
    {
        public sealed partial class NoSuchElementCallable
        {
            Java.Lang.Object ICallable.Call()
            {
                throw new NotImplementedException();
            }
        }
    }
}