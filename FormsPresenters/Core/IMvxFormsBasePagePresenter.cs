using Cirrious.MvvmCross.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cheesebaron.MvxPlugins.FormsPresenters.Core
{
    public interface IMvxFormsBasePagePresenter
        : IMvxViewPresenter
    {
        void PlatformSpecificInitialRendering(NavigationPage navigationPage);

        Task PlatformSpecificInitialNavigationAsync(ContentPage page);
    }
}
