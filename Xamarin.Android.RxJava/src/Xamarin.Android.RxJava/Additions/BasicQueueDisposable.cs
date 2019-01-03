using System;

namespace IO.Reactivex.Internal.Observers
{
    public abstract partial class BasicQueueDisposable
    {
        public virtual Java.Lang.Object Poll()
        {
            throw new NotImplementedException();
        }
    }
}