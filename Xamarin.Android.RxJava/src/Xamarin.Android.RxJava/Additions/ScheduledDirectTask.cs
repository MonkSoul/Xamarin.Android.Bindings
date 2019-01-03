using Java.Util.Concurrent;
using System;

namespace IO.Reactivex.Internal.Schedulers
{
    public sealed partial class ScheduledDirectTask
    {
        Java.Lang.Object ICallable.Call()
        {
            throw new NotImplementedException();
        }
    }
}