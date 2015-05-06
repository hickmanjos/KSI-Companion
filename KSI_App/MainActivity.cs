using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace KSI_App
{
    [Activity(Label = "KSI Companion", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button rank_button = FindViewById<Button>(Resource.Id.MyButton);
            Button code_button = FindViewById<Button>(Resource.Id.code);
            Button hall_button = FindViewById<Button>(Resource.Id.hall);
            Button div_button = FindViewById<Button>(Resource.Id.divisions);
            Button links_button = FindViewById<Button>(Resource.Id.links);
            Button hand_button = FindViewById<Button>(Resource.Id.handbook);

            rank_button.Click += (sender, e) => 
            {
                var intent = new Intent(this, typeof(Rank));
                StartActivity(intent); 
            };

            code_button.Click += (sender, e) =>
            {
                StartActivity(typeof(CodeOfCondunct));
            };

            hall_button.Click += (sender, e) =>
            {
                StartActivity(typeof(Hall));
            };

            div_button.Click += (sender, e) =>
            {
                StartActivity(typeof(Div));
            };

            links_button.Click += (sender, e) =>
            {
                StartActivity(typeof(Links));
            };

            hand_button.Click += (sender, e) =>
            {
                StartActivity(typeof(Handbook));
            };
        }
    }
}

