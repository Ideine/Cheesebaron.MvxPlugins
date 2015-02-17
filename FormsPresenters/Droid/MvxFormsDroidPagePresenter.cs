using Cheesebaron.MvxPlugins.FormsPresenters.Core;
using Cheesebaron.MvxPlugins.FormsPresenters.Droid.Interfaces;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cheesebaron.MvxPlugins.FormsPresenters.Droid
{
    public class MvxFormsDroidPagePresenter
        : MvxAndroidViewPresenter
        , IMvxFormsBasePagePresenter
        , IMvxPageNavigationHost
    {
        private readonly MvxFormsBasePagePresenter _mvxFormsBasePagePresenter;

        public IMvxPageNavigationProvider NavigationProvider { get; set; }

        public MvxFormsDroidPagePresenter()
            : base()
        {
            _mvxFormsBasePagePresenter = new MvxFormsBasePagePresenter();
        }

        public override void Show(MvxViewModelRequest request)
        {
            _mvxFormsBasePagePresenter.Show(request);
        }

        public override void ChangePresentation(MvxPresentationHint hint)
        {
            _mvxFormsBasePagePresenter.ChangePresentation(hint);
        }

        //public override void Close(IMvxViewModel viewModel)
        //{
        //    if (NavigationProvider == null)
        //        return;

        //    NavigationProvider.Pop();
        //}

        public async Task PlatformSpecificInitialNavigationAsync(ContentPage page)
        {
            await Task.Run(() => NavigationProvider.Push(page));
        }

        //protected async Task<bool> TryShowPageAsync(MvxViewModelRequest request)
        //{
        //    if (NavigationProvider == null)
        //        return false;

        //    return await _mvxFormsBasePagePresenter.TryShowPageAsync(request);
        //}

        public void PlatformSpecificInitialRendering(NavigationPage navigationPage)
        {
            // Intentionally blank
        }
    }
}