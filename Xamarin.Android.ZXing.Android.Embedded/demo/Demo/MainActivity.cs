using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using Com.Google.Zxing.Integration.Android;

namespace Demo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TextView textView1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += Button1_Click;

            textView1 = FindViewById<TextView>(Resource.Id.textView1);
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            InitScan();
        }

        private void InitScan()
        {
            var integrator = new IntentIntegrator(this);
            integrator.SetPrompt("请扫描");
            integrator.SetOrientationLocked(true);
            integrator.SetCameraId(0);
            integrator.SetBeepEnabled(false);
            integrator.SetCaptureActivity(new ScanActivity().Class);
            integrator.InitiateScan();
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            IntentResult result = IntentIntegrator.ParseActivityResult(requestCode, (int)resultCode, data);
            if (result != null)
            {
                if (result.Contents == null)
                {
                    textView1.Text = "No Result.";
                    Toast.MakeText(this, "Cancelled", ToastLength.Long).Show();
                }
                else
                {
                    textView1.Text = result.Contents;
                    Toast.MakeText(this, "Scanned: " + result.Contents, ToastLength.Long).Show();
                }
            }
        }
    }
}