using Java.Util.Concurrent;
using System;

namespace IO.Reactivex.Internal.Operators.Observable
{
    public sealed partial class ObservableInternalHelper
    {
        public sealed partial class ReplayCallable
        {
            Java.Lang.Object ICallable.Call()
            {
                throw new NotImplementedException();
            }
        }
    }
}