using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cheesebaron.MvxPlugins.FormsPresenters.Core
{
    public class MvxFormsBasePagePresenter
        : IMvxFormsBasePagePresenter
    {
        private readonly Xamarin.Forms.Application _xamarinFormsApp;

        public MvxFormsBasePagePresenter(Xamarin.Forms.Application xamarinFormsApp = null)
        {
            _xamarinFormsApp = xamarinFormsApp;
        }

        public async void Show(MvxViewModelRequest request)
        {
            if (await TryShowPageAsync(request))
                return;

            Mvx.Error("Skipping request for {0}", request.ViewModelType.Name);
        }

        public async void ChangePresentation(MvxPresentationHint hint)
        {
            if (_xamarinFormsApp == null)
                return;

            if (hint is MvxClosePresentationHint)
            {
                var mainPage = _xamarinFormsApp.MainPage as NavigationPage;

                if (mainPage == null)
                {
                    Mvx.TaggedTrace("MvxFormsPresenter:ChangePresentation()", "Shit, son! Don't know what to do");
                }
                else
                {
                    // TODO - perhaps we should do more here... also async void is a boo boo
                    await mainPage.PopAsync();
                }
            }
        }

        public virtual void PlatformSpecificInitialRendering(NavigationPage navigationPage)
        { }

        public virtual async Task PlatformSpecificInitialNavigationAsync(ContentPage page)
        {
            var navigationPage = _xamarinFormsApp.MainPage as NavigationPage;

            // 1st navigation
            if (navigationPage == null)
            {
                navigationPage = new NavigationPage(page);
                _xamarinFormsApp.MainPage = navigationPage;
                PlatformSpecificInitialRendering(navigationPage);
            }
            else
            {
                await navigationPage.PushAsync(page);
            }
        }

        public virtual async Task<bool> TryShowPageAsync(MvxViewModelRequest request)
        {
            var page = MvxPresenterHelpers.CreatePage(request);

            if (page == null)
                return false;

            var viewModel = MvxPresenterHelpers.LoadViewModel(request);
            
            // CRASHES ON ANDROID
            await PlatformSpecificInitialNavigationAsync(page);

            page.BindingContext = viewModel;

            return true;
        }
    }
}
