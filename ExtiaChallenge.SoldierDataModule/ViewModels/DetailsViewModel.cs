using ExtiaChallenge.Common;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;

namespace ExtiaChallenge.SoldierDataModule.ViewModels
{
    public class DetailsViewModel : BindableBase
    {
        private string _soldierName;

        public string SoldierName
        {
            get => _soldierName;
            set => SetProperty(ref _soldierName, value);
        }

        public DetailsViewModel()
        {
            var _eventAggregator = ContainerLocator.Container.Resolve<IEventAggregator>();
            _eventAggregator.GetEvent<ContentEvents>().Subscribe(OnContentEvent);
        }

        private void OnContentEvent((string Message, bool Flag, object data) tuple)
        {
            var message = tuple.Message;
            var flag = tuple.Flag;
            var data = tuple.data;

            if (message == "SoldierDetails")
            {
                SoldierName = data.ToString();
            }
        }
    }
}
