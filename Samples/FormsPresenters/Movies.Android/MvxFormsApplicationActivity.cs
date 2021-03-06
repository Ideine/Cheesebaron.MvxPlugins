﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Cheesebaron.MvxPlugins.FormsPresenters.Core;
using Cheesebaron.MvxPlugins.FormsPresenters.Droid;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace CoolBeans.Droid
{
    [Activity(Label = "View for anyViewModel", ScreenOrientation=ScreenOrientation.Portrait)]
    public class MvxFormsApplicationActivity
        : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            var mvxFormsApp = new MvxFormsApp();
            LoadApplication(mvxFormsApp);

            var presenter = Mvx.Resolve<IMvxViewPresenter>() as MvxFormsDroidPagePresenter;
            presenter.MvxFormsApp = mvxFormsApp;

            Mvx.Resolve<IMvxAppStart>().Start();
        }
    }
}