using ExtiaChallenge.Common;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;

namespace ExtiaChallenge.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private Visibility _isDetailsVisible;
        public Visibility IsDetailsVisible
        {
            get { return _isDetailsVisible; }
            set { SetProperty(ref _isDetailsVisible, value); }
        }

        private readonly IEventAggregator _eventAggregator;
        private readonly IRegionManager _regionManager;
        public MainViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;
            IsDetailsVisible = Visibility.Collapsed;
            _eventAggregator.GetEvent<ContentEvents>().Subscribe(OnContentEvent);
        }

        private void OnContentEvent((string Message, bool Flag, object data) tuple)
        {
            var message = tuple.Message;
            var flag = tuple.Flag;
            var data = tuple.data;

            if (message == "SoldierDetails")
            {
                IsDetailsVisible = Visibility.Visible;
            }
        }
    }
}
