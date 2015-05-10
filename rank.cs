using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using Android.Text;
using Android.Animation;

namespace KSI_App
{
    [Activity(Label = "Rank Structure")]
    public class Rank : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Rank);
            Button back_button = FindViewById<Button>(Resource.Id.back_button);

            back_button.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };

        #region Button Declarations

            //~~~~All descriptions declared below~~~//
            TextView sn_dir_text = FindViewById<TextView>(Resource.Id.sn_dir_text);
            TextView div_text = FindViewById<TextView>(Resource.Id.div_text);
            TextView co_div_text = FindViewById<TextView>(Resource.Id.co_div_text);
            TextView founder_text = FindViewById<TextView>(Resource.Id.founder_text);
            TextView co_fo_text = FindViewById<TextView>(Resource.Id.co_fo_text);
            TextView gen_text = FindViewById<TextView>(Resource.Id.gen_text);
            TextView cap_text = FindViewById<TextView>(Resource.Id.cap_text);
            TextView lt_text = FindViewById<TextView>(Resource.Id.lt_text);
            TextView st_sgt_text = FindViewById<TextView>(Resource.Id.st_sgt_text);
            TextView sgt_text = FindViewById<TextView>(Resource.Id.sgt_text);
            TextView cpl_text = FindViewById<TextView>(Resource.Id.cpl_text);
            TextView pvt_text = FindViewById<TextView>(Resource.Id.pvt_text);
            TextView rct_text = FindViewById<TextView>(Resource.Id.rct_text);


            //~~~~All titles declared below~~~//
            TextView sn_dir_title = FindViewById<TextView>(Resource.Id.sn_dir_title);
            TextView div_title = FindViewById<TextView>(Resource.Id.div_title);
            TextView co_div_title = FindViewById<TextView>(Resource.Id.co_div_title);
            TextView founder_title = FindViewById<TextView>(Resource.Id.founder_title);
            TextView co_fo_title = FindViewById<TextView>(Resource.Id.co_fo_title);
            TextView gen_title = FindViewById<TextView>(Resource.Id.gen_title);
            TextView cap_title = FindViewById<TextView>(Resource.Id.cap_title);
            TextView lt_title = FindViewById<TextView>(Resource.Id.lt_title);
            TextView st_sgt_title = FindViewById<TextView>(Resource.Id.st_sgt_title);
            TextView sgt_title = FindViewById<TextView>(Resource.Id.sgt_title);
            TextView cpl_title = FindViewById<TextView>(Resource.Id.cpl_title);
            TextView pvt_title = FindViewById<TextView>(Resource.Id.pvt_title);
            TextView rct_title = FindViewById<TextView>(Resource.Id.rct_title);

            setup_html(sn_dir_text, "Sn_Dir.txt");
            setup_html(div_text, "Div.txt");
            setup_html(co_div_text, "Co_Div.txt");
            setup_html(founder_text, "Founder.txt");
            setup_html(co_fo_text, "Co_Fo.txt");
            setup_html(gen_text, "Gen.txt");
            setup_html(cap_text, "Cap.txt");
            setup_html(lt_text, "Lt.txt");
            setup_html(st_sgt_text, "St_Sgt.txt");
            setup_html(sgt_text, "Sgt.txt");
            setup_html(cpl_text, "Cpl.txt");
            setup_html(pvt_text, "Pvt.txt");
            setup_html(rct_text, "Rct.txt");

            //Allows for scrolling on textViews
            sn_dir_text.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            div_text.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            co_div_text.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            founder_text.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            co_fo_text.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            gen_text.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            cap_text.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            lt_text.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            st_sgt_text.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            sgt_text.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            cpl_text.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            pvt_text.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            rct_text.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            //sn_dir_text.Visibility = ViewStates.Gone;   //hides textview

            //All title buttons being clicked expands/collapse their respective view
            sn_dir_title.Click += (sender, e) => { rank_click(sn_dir_title, sn_dir_text); };
            div_title.Click += (sender, e) => { rank_click(div_title, div_text); };
            co_div_title.Click += (sender, e) => { rank_click(co_div_title, co_div_text); };
            founder_title.Click += (sender, e) => { rank_click(founder_title, founder_text); };
            co_fo_title.Click += (sender, e) => { rank_click(co_fo_title, co_fo_text); };
            gen_title.Click += (sender, e) => { rank_click(gen_title, gen_text); };
            cap_title.Click += (sender, e) => { rank_click(cap_title, cap_text); };
            lt_title.Click += (sender, e) => { rank_click(lt_title, lt_text); };
            st_sgt_title.Click += (sender, e) => { rank_click(st_sgt_title, st_sgt_text); };
            sgt_title.Click += (sender, e) => { rank_click(sgt_title, sgt_text); };
            cpl_title.Click += (sender, e) => { rank_click(cpl_title, cpl_text); };
            pvt_title.Click += (sender, e) => { rank_click(pvt_title, pvt_text); };
            rct_title.Click += (sender, e) => { rank_click(rct_title, rct_text); };

#endregion
        }

        private void setup_html(TextView text, string path)
        {
            StreamReader streamReader = new StreamReader(Assets.Open(path));  //Taking .txt file into string
            string rank_text = streamReader.ReadToEnd();
            text.TextFormatted = Html.FromHtml(rank_text);  //Formats string to output as html code
        }

        private void rank_click(TextView title, TextView text)
        {
                if (text.Visibility.Equals(ViewStates.Gone))
                {
                    //Expand View
                    text.Visibility = ViewStates.Visible;
                    int widthSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
                    int heightSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
                    text.Measure(widthSpec, heightSpec);

                    ValueAnimator mAnimator = slideAnimator(0, text.MeasuredHeight, text);
                    mAnimator.Start();

                }
                else
                {
                    //Collapse View
                    int finalHeight = text.Height;

                    ValueAnimator mAnimator = slideAnimator(finalHeight, 0, text);
                    mAnimator.Start();
                    mAnimator.AnimationEnd += (object IntentSender, EventArgs arg) =>
                    {
                        text.Visibility = ViewStates.Gone;
                    };
                }
        }

        private ValueAnimator slideAnimator(int start, int end, TextView v)
        {

            ValueAnimator animator = ValueAnimator.OfInt(start, end);
            //ValueAnimator animator2 = ValueAnimator.OfInt(start, end);
            //  animator.AddUpdateListener (new ValueAnimator.IAnimatorUpdateListener{
            animator.Update +=
                (object sender, ValueAnimator.AnimatorUpdateEventArgs e) =>
                {
                    //  int newValue = (int)
                    //e.Animation.AnimatedValue; // Apply this new value to the object being animated.
                    //  myObj.SomeIntegerValue = newValue; 
                    var value = (int)animator.AnimatedValue;
                    ViewGroup.LayoutParams layoutParams = v.LayoutParameters;
                    layoutParams.Height = value;
                    v.LayoutParameters=layoutParams;
                };
            return animator;
        }
    }
}

