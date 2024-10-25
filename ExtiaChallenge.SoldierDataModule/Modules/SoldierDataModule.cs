using ExtiaChallenge.SoldierDataModule.ViewModels;
using ExtiaChallenge.SoldierDataModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ExtiaChallenge.SoldierDataModule.Modules
{
    public class SoldierDataModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = ContainerLocator.Container.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("DetailsRegion", typeof(DetailsView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<DetailsView, DetailsViewModel>();
        }
    }
}
