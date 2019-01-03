using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Journeyapps.Barcodescanner;

namespace Demo
{
    [Activity(Label = "ScanActivity")]
    public class ScanActivity : AppCompatActivity, DecoratedBarcodeView.ITorchListener
    {
        private CaptureManager captureManager;
        private bool isLightOn = false;
        private DecoratedBarcodeView mDBV;
        private Button swichLight;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_scan);

            swichLight = FindViewById<Button>(Resource.Id.btn_switch);
            mDBV = FindViewById<DecoratedBarcodeView>(Resource.Id.dbv_custom);
            mDBV.SetTorchListener(this);
            if (!HasFlash())
            {
                swichLight.Visibility = ViewStates.Gone;
            }
            swichLight.Click += (sender, e) =>
            {
                if (isLightOn)
                {
                    mDBV.SetTorchOff();
                }
                else
                {
                    mDBV.SetTorchOn();
                }
            };

            captureManager = new CaptureManager(this, mDBV);
            captureManager.InitializeFromIntent(Intent, savedInstanceState);
            captureManager.Decode();
        }

        private bool HasFlash()
        {
            return ApplicationContext.PackageManager.HasSystemFeature(Android.Content.PM.PackageManager.FeatureCameraFlash);
        }

        public void OnTorchOn()
        {
            Toast.MakeText(this, "torch on", ToastLength.Long).Show();
            isLightOn = true;
        }

        public void OnTorchOff()
        {
            Toast.MakeText(this, "torch off", ToastLength.Long).Show();
            isLightOn = false;
        }

        public override void OnSaveInstanceState(Bundle outState, PersistableBundle outPersistentState)
        {
            base.OnSaveInstanceState(outState, outPersistentState);
            captureManager.OnSaveInstanceState(outState);
        }

        public override bool OnKeyDown([GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            return mDBV.OnKeyDown(keyCode, e) || base.OnKeyDown(keyCode, e);
        }

        protected override void OnPause()
        {
            base.OnPause();
            captureManager.OnPause();
        }

        protected override void OnResume()
        {
            base.OnResume();
            captureManager.OnResume();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            captureManager.OnDestroy();
        }
    }
}