using Java.Util.Concurrent;
using System;

namespace IO.Reactivex.Schedulers
{
    public sealed partial class Schedulers
    {
        public sealed partial class ComputationTask
        {
            Java.Lang.Object ICallable.Call()
            {
                throw new NotImplementedException();
            }
        }
    }
}