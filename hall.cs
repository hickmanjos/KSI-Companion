using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using Android.Text;

namespace KSI_App
{
    [Activity(Label = "Hall of Fame")]
    public class Hall : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.hall);

            TextView text1 = FindViewById<TextView>(Resource.Id.textView1);
            text1.MovementMethod = new Android.Text.Method.ScrollingMovementMethod(); //Allows for scrolling on textView

            Button back_button = FindViewById<Button>(Resource.Id.back_button);

            const string filePath = "hall.txt";
            StreamReader streamReader = new StreamReader(Assets.Open(filePath));  //Taking .txt file into string
            string text = streamReader.ReadToEnd();

            back_button.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };

            text1.TextFormatted = Html.FromHtml(text);  //Formats string to output as html code


        }
    }
}

