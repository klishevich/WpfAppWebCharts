using SciChart.Charting.Visuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SciChart.Charting3D;
using SciChart.Charting3D.Axis;
using SciChart.Charting3D.Modifiers;

namespace WpfAppWebCharts
{
    /// <summary>
    /// Interaction logic for Window3D.xaml
    /// </summary>
    public partial class Window3D : Window
    {
        public Window3D()
        {
            InitializeComponent();

            var sciChart3DSurface = new SciChart3DSurface()
            {
                IsAxisCubeVisible = true,
                IsFpsCounterVisible = true,
                IsXyzGizmoVisible = true
            };
            // Create the X,Y,Z Axis
            sciChart3DSurface.XAxis = new NumericAxis3D();
            sciChart3DSurface.YAxis = new NumericAxis3D();
            sciChart3DSurface.ZAxis = new NumericAxis3D();
            // Specify Interactivity Modifiers
            sciChart3DSurface.ChartModifier = new ModifierGroup3D(
                     new OrbitModifier3D(),
                     new ZoomExtentsModifier3D());
        }
    }
}
