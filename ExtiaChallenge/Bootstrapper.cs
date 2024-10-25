using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace ExtiaChallenge
{
    public class Bootstrapper : PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ExtiaChallenge.Data.Startup.Startup.RegisterServices(containerRegistry);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<MapModule.Modules.MapModule>();
            moduleCatalog.AddModule<SoldierDataModule.Modules.SoldierDataModule>();
        }
    }
}
