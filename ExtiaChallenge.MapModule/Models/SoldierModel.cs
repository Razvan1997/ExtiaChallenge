using Prism.Mvvm;

namespace ExtiaChallenge.MapModule.Models
{
    public class SoldierModel : BindableBase
    {
        private double _left;
        private double _top;
        private double _ellipseSize = 20;
        private string _soldierName;

        public string SoldierName
        {
            get => _soldierName;
            set => SetProperty(ref _soldierName, value);
        }

        public double Left
        {
            get => _left;
            set => SetProperty(ref _left, value);
        }

        public double Top
        {
            get => _top;
            set => SetProperty(ref _top, value);
        }

        public double EllipseSize
        {
            get => _ellipseSize;
            set => SetProperty(ref _ellipseSize, value);
        }
    }
}
