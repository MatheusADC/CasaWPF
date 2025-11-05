using System;
using System.Windows;
using System.Windows.Media.Animation; 
using System.Windows.Media.Media3D;   

namespace casaPIC2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            InicializarAnimacaoCamera();
            InicializarAnimacaoLuzes();
        }

        private void InicializarAnimacaoCamera()
        {
            var rotacaoVertical = new AxisAngleRotation3D(new Vector3D(1, 0, 0), 0);
            var transformacaoCamera = new RotateTransform3D(rotacaoVertical, new Point3D(2, 3, -2));

            camera.Transform = transformacaoCamera;

            var animacaoCamera = new DoubleAnimation
            {
                From = -0,
                To = -180,
                Duration = new Duration(TimeSpan.FromSeconds(5)),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };

            rotacaoVertical.BeginAnimation(AxisAngleRotation3D.AngleProperty, animacaoCamera);
        }

        private void InicializarAnimacaoLuzes()
        {
            var rotacaoLuzUm = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0);
            var transformacaoLuzUm = new RotateTransform3D(rotacaoLuzUm);
            luzUm.Transform = transformacaoLuzUm;

            var animacaoLuzUm = new DoubleAnimation
            {
                From = 0,
                To = 360,
                Duration = new Duration(TimeSpan.FromSeconds(10)),
                RepeatBehavior = RepeatBehavior.Forever
            };

            rotacaoLuzUm.BeginAnimation(AxisAngleRotation3D.AngleProperty, animacaoLuzUm);

            var rotacaoLuzDois = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0);
            var transformacaoLuzDois = new RotateTransform3D(rotacaoLuzDois);
            luzDois.Transform = transformacaoLuzDois;

            var animacaoLuzDois = new DoubleAnimation
            {
                From = 0,
                To = -360,
                Duration = new Duration(TimeSpan.FromSeconds(10)),
                RepeatBehavior = RepeatBehavior.Forever
            };

            rotacaoLuzDois.BeginAnimation(AxisAngleRotation3D.AngleProperty, animacaoLuzDois);
        }
    }
}