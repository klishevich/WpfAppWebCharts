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
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Model.DataSeries.Heatmap2DArrayDataSeries;

namespace WpfAppWebCharts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine("Licensing info: " + SciChartSurface.VersionAndLicenseInfo);
            Console.WriteLine("Dump info: " + SciChartSurface.DumpInfo());
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            // Then, in code-behind, apply the data
            int cellHeight = 3;
            int cellWidth = 4;
            var data = new double[cellHeight, cellWidth];
            for (int x = 0; x < cellWidth; x++)
                for (int y = 0; y < cellHeight; y++)
                {
                    data[y, x] = (double)(x + y * cellWidth);
                }
            // TODO: Fill the data[,] array with values to represent your heat values
            // NOTE: HeatmapColorPalette.Maximum and Minimum defines the mapping of gradient colors to data values

            double startX = 0;
            double stepX = 1;
            double startY = 0;
            double stepY = 1;
            var heatmapDataSeries = new UniformHeatmapDataSeries<double, double, double>(data, startX, stepX, startY, stepY);

            // Apply the dataseries to the heatmap
            heatmapSeries.DataSeries = heatmapDataSeries;
        }
    }
}
