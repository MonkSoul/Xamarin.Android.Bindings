using Android.OS;
using Java.Lang;

namespace Com.Journeyapps.Barcodescanner.Camera
{
    public class CameraThread : Object
    {
        private const string TAG = nameof(CameraThread);

        private static CameraThread instance;

        public static CameraThread GetInstance()
        {
            if (instance == null)
            {
                instance = new CameraThread();
            }
            return instance;
        }

        private Handler handler;
        private HandlerThread thread;

        private int openCount = 0;

        private static readonly object LOCK = new object();

        private CameraThread()
        {
        }

        protected void Enqueue(IRunnable runnable)
        {
            lock (LOCK)
            {
                CheckRunning();
                this.handler.Post(runnable);
            }
        }

        protected void EnqueueDelayed(IRunnable runnable, long delayMillis)
        {
            lock (LOCK)
            {
                CheckRunning();
                this.handler.PostDelayed(runnable, delayMillis);
            }
        }

        private void CheckRunning()
        {
            lock (LOCK)
            {
                if (this.handler == null)
                {
                    if (openCount <= 0)
                    {
                        throw new IllegalStateException("CameraThread is not open");
                    }
                    this.thread = new HandlerThread("CameraThread");
                    this.thread.Start();
                    this.handler = new Handler(thread.Looper);
                }
            }
        }

        private void Quit()
        {
            lock (LOCK)
            {
                this.thread.Quit();
                this.thread = null;
                this.handler = null;
            }
        }

        protected void DecrementInstances()
        {
            lock (LOCK)
            {
                openCount -= 1;
                if (openCount == 0)
                {
                    Quit();
                }
            }
        }

        protected void IncrementAndEnqueue(Runnable runner)
        {
            lock (LOCK)
            {
                openCount += 1;
                Enqueue(runner);
            }
        }
    }
}