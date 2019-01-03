using System;

namespace IO.Reactivex.Internal.Observers
{
    public abstract partial class BasicFuseableObserver
    {
        public virtual void OnNext(Java.Lang.Object p0)
        {
            throw new NotImplementedException();
        }

        public virtual Java.Lang.Object Poll()
        {
            throw new NotImplementedException();
        }
    }
}