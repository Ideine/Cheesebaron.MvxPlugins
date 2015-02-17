using System.Threading.Tasks;
using Cheesebaron.MvxPlugins.FormsPresenters.Core;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsPhone.Views;
using Xamarin.Forms;
using Microsoft.Phone.Controls;
using System;

namespace Cheesebaron.MvxPlugins.FormsPresenters.WindowsPhone
{
    public class MvxFormsWindowsPhonePagePresenter 
        : MvxFormsBasePagePresenter
        , IMvxPhoneViewPresenter
    {
        private PhoneApplicationFrame _rootFrame;

        public static Application XamarinFormsApp;

        public MvxFormsWindowsPhonePagePresenter(PhoneApplicationFrame rootFrame, Application xamarinFormsApp)
            : base(xamarinFormsApp)
        {
            _rootFrame = rootFrame;
            XamarinFormsApp = xamarinFormsApp;
        }

        public override void PlatformSpecificInitialRendering(NavigationPage navigationPage)
        {
            _rootFrame.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}
