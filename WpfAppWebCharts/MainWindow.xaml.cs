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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Charting.ChartModifiers;

namespace WpfAppWebCharts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FastLineRenderableSeries LineSeries;
        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine("Licensing info: " + SciChartSurface.VersionAndLicenseInfo);
            Console.WriteLine("Dump info: " + SciChartSurface.DumpInfo());


            LineSeries = new FastLineRenderableSeries()
            {
                Stroke = (Color)ColorConverter.ConvertFromString("#FF4083B7")
            };
            sciChartSurface.RenderableSeries.Add(LineSeries);

            // Create the X and Y Axis
            var xAxesNumericAxis = new NumericAxis() { AxisTitle = "Number of Samples (per Series)" };
            xAxesNumericAxis.Scrollbar = new SciChartScrollbar() { Height = 16 };
            var yAxesNumericAxis = new NumericAxis() { AxisTitle = "Value" };
            sciChartSurface.XAxes.Add(xAxesNumericAxis);
            sciChartSurface.YAxes.Add(yAxesNumericAxis);

            // interactivity modifiers
            //var rubberBandXyZoomModifier = new RubberBandXyZoomModifier()
            //{
            //    ExecuteOn = ExecuteOn.MouseLeftButton,
            //    RubberBandFill = new BrushConverter().ConvertFromString("#33FFFFFF") as SolidColorBrush
            //};
            //var zoomExtentsModifier = new ZoomExtentsModifier() { ExecuteOn = ExecuteOn.MouseDoubleClick };
            //sciChartSurface.ChartModifier = modifierGroup;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            // Create XyDataSeries to host data for our charts
            var scatterData = new XyDataSeries<double, double>();
            var lineData = new XyDataSeries<double, double>();

            // NEW CODE HERE           
            // Ensure that DataSeries are named for the legend
            scatterData.SeriesName = "Cos(x)";
            lineData.SeriesName = "Sin(x)";
            // END NEW CODE

            for (int i = 0; i < 1000; i++)
            {
                lineData.Append(i, Math.Sin(i * 0.1));
                scatterData.Append(i, Math.Cos(i * 0.1));
            }
            // Assign dataseries to RenderSeries
            LineSeries.DataSeries = lineData;
        }
    }
}
