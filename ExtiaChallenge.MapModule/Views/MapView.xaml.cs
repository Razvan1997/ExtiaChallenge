using ExtiaChallenge.MapModule.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace ExtiaChallenge.MapModule.Views
{
    /// <summary>
    /// Interaction logic for MapView.xaml
    /// </summary>
    public partial class MapView : UserControl
    {
        private const double MinZoom = 0.5;
        private const double MaxZoom = 3.0;
        private Point lastMousePosition;
        private bool isDragging = false;
        public MapView()
        {
            InitializeComponent();
            imgWorld.MouseWheel += ImgWorld_MouseWheel;
            imgWorld.MouseDown += ImgWorld_MouseDown;
            imgWorld.MouseMove += ImgWorld_MouseMove;
            imgWorld.MouseUp += ImgWorld_MouseUp;
            var viewModel = (MapViewModel)DataContext;
            viewModel.MainCanvas = mainCanvas;
        }

        private void ImgWorld_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            const double zoomFactor = 0.1;

            if (e.Delta > 0)
            {
                gridScaleTransform.ScaleX = Math.Min(MaxZoom, gridScaleTransform.ScaleX + zoomFactor);
                gridScaleTransform.ScaleY = Math.Min(MaxZoom, gridScaleTransform.ScaleY + zoomFactor);
            }
            else
            {
                gridScaleTransform.ScaleX = Math.Max(MinZoom, gridScaleTransform.ScaleX - zoomFactor);
                gridScaleTransform.ScaleY = Math.Max(MinZoom, gridScaleTransform.ScaleY - zoomFactor);
            }
        }

        private void ImgWorld_MouseDown(object sender, MouseButtonEventArgs e)
        {
            imgWorld.CaptureMouse();
            isDragging = true;
            lastMousePosition = e.GetPosition(this);
        }

        private void ImgWorld_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentMousePosition = e.GetPosition(this);
                Vector delta = currentMousePosition - lastMousePosition;

                imageTranslateTransform.X += delta.X;
                imageTranslateTransform.Y += delta.Y;

                lastMousePosition = currentMousePosition;
            }
        }

        private void ImgWorld_MouseUp(object sender, MouseButtonEventArgs e)
        {
            imgWorld.ReleaseMouseCapture();
            isDragging = false;
        }

    }
}
