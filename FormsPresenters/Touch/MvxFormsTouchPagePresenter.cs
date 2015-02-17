using System.Threading.Tasks;
using Cheesebaron.MvxPlugins.FormsPresenters.Core;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Cirrious.MvvmCross.ViewModels;
using UIKit;
using Xamarin.Forms;

namespace Cheesebaron.MvxPlugins.FormsPresenters.Touch
{
    public class MvxFormsTouchPagePresenter
        : MvxFormsBasePagePresenter
        , IMvxTouchViewPresenter
    {
        private readonly UIWindow _window;

        public MvxFormsTouchPagePresenter(UIWindow window, Application xamarinFormsApp)
            : base(xamarinFormsApp)
        {
            _window = window;
        }

        public override void PlatformSpecificInitialRendering(NavigationPage navigationPage)
        {
            _window.RootViewController = navigationPage.CreateViewController();
        }

        public virtual bool PresentModalViewController(UIViewController controller, bool animated)
        {
            return false;
        }

        public virtual void NativeModalViewControllerDisappearedOnItsOwn()
        {
        }
    }
}