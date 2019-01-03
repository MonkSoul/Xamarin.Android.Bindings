using Java.Lang;
using System;

namespace IO.Reactivex.Internal.Operators.Observable
{
    public sealed partial class ObservableDelay
    {
        public sealed partial class DelayObserver
        {
            void IObserver.OnComplete()
            {
                throw new NotImplementedException();
            }

            void IObserver.OnError(Throwable p0)
            {
                throw new NotImplementedException();
            }
        }
    }
}