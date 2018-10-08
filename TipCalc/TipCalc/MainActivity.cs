using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace TipCalc
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView textView;
        TextView textView2;
        TextView summa;
        EditText arve;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            textView = FindViewById<TextView>(Resource.Id.jootrahaProtsent);
            textView2 = FindViewById<TextView>(Resource.Id.jootraha);
            arve = FindViewById<EditText>(Resource.Id.arve);
            summa = FindViewById<TextView>(Resource.Id.summa);
            var seekBar = FindViewById<SeekBar>(Resource.Id.seekBar1);

            seekBar.ProgressChanged += SeekBar_ProgressChanged;
        }

        private void SeekBar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            textView2.Text = (float.Parse(arve.Text) * float.Parse(textView.Text) / 100).ToString();
            summa.Text = (float.Parse(arve.Text) + float.Parse(textView2.Text)).ToString();
            textView.Text = e.Progress.ToString();
        }
    }
}