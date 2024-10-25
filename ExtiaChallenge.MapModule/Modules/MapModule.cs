using ExtiaChallenge.MapModule.ViewModel;
using ExtiaChallenge.MapModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ExtiaChallenge.MapModule.Modules
{
    public class MapModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = ContainerLocator.Container.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(MapView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MapView, MapViewModel>();
        }
    }
}
