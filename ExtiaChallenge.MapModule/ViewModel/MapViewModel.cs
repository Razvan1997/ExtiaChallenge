using ExtiaChallenge.Common;
using ExtiaChallenge.Data.Contracts;
using ExtiaChallenge.MapModule.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ExtiaChallenge.MapModule.ViewModel
{
    public class MapViewModel : BindableBase
    {
        public ObservableCollection<SoldierModel> Soldiers { get; set; } = new ObservableCollection<SoldierModel>();

        private DispatcherTimer _timer;
        private double _canvasWidth = 800; 
        private double _canvasHeight = 600;
        public Canvas MainCanvas { get; set; }
        public DelegateCommand<SoldierModel> OnEllipseClickCommand { get; private set; }
        // Constructor
        public MapViewModel()
        {
            InitializeTimer();
            RandomizeCirclesAndTextWithAnimation();
            OnEllipseClickCommand = new DelegateCommand<SoldierModel>(OnEllipseClick);
        }
        private void OnEllipseClick(SoldierModel soldier)
        {
            var _eventAggregator = ContainerLocator.Container.Resolve<IEventAggregator>();
            _eventAggregator.GetEvent<ContentEvents>().Publish(("SoldierDetails", false, soldier.SoldierName));
        }

        private void InitializeTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(5);
            _timer.Tick += (sender, e) => MoveSoldiers();
            _timer.Start();
        }

        private void RandomizeCirclesAndTextWithAnimation()
        {
            Random random = new Random();

            var soldierService = ContainerLocator.Container.Resolve<ISoldierService>();
            var soldiers = soldierService.GetAllSoldiersAsync();

            for (int i = 0; i < soldiers.Count; i++)
            {
                double randomLeft = random.Next(0, (int)_canvasWidth - 20);
                double randomTop = random.Next(0, (int)_canvasHeight - 20);

                var soldierViewModel = new SoldierModel
                {
                    SoldierName = soldiers[i].SoldierName,
                    Left = randomLeft,
                    Top = randomTop,
                };

                Soldiers.Add(soldierViewModel);
            }
        }

        private void MoveSoldiers()
        {
            Random random = new Random();

            foreach (var soldier in Soldiers)
            {
                double oldLeft = soldier.Left;
                double oldTop = soldier.Top;

                double newLeft = soldier.Left;
                double newTop = soldier.Top;

                int direction = random.Next(0, 4); // 0 - left, 1 - right, 2 - up, 3 - down
                switch (direction)
                {
                    case 0: newLeft -= 10; break;
                    case 1: newLeft += 10; break;
                    case 2: newTop -= 10; break;
                    case 3: newTop += 10; break;
                }

                newLeft = Math.Max(0, Math.Min(_canvasWidth - soldier.EllipseSize, newLeft));
                newTop = Math.Max(0, Math.Min(_canvasHeight - soldier.EllipseSize, newTop));

                DrawLine(oldLeft, oldTop, newLeft, newTop);

                soldier.Left = newLeft;
                soldier.Top = newTop;
            }
        }

        private void DrawLine(double x1, double y1, double x2, double y2)
        {
            Line line = new Line
            {
                X1 = x1 + 10, 
                Y1 = y1 + 10,
                X2 = x2 + 10,
                Y2 = y2 + 10,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };

            MainCanvas.Children.Add(line);
        }
    }
}
