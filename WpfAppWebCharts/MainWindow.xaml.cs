using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
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
using SciChart.Data.Model;

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
            xAxesNumericAxis.Scrollbar = new SciChartScrollbar() { Height = 16 };
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            // Create XyDataSeries to host data for our charts
            var scatterData = new XyDataSeries<double, double>();
            var lineData = new XyDataSeries<double, double>();

            // Ensure that DataSeries are named for the legend
            scatterData.SeriesName = "Cos(x)";
            lineData.SeriesName = "Sin(x)";

            for (int i = 0; i < 1000; i++)
            {
                lineData.Append(i, Math.Sin(i * 0.1));
                scatterData.Append(i, Math.Cos(i * 0.1));
            }

            // Assign dataseries to RenderSeries
            LineSeries.DataSeries = lineData;
            ScatterSeries.DataSeries = scatterData;

            // Start a timer to update our data

            // UPDATE
            //double phase = 0.0;
            //var timer = new DispatcherTimer(DispatcherPriority.Render);
            //timer.Interval = TimeSpan.FromMilliseconds(10);
            //timer.Tick += (s, e) =>
            //{
            //    // SuspendUpdates() ensures the chart is frozen
            //    // while you do updates. This ensures best performance
            //    using (lineData.SuspendUpdates())
            //    using (scatterData.SuspendUpdates())
            //    {
            //        for (int i = 0; i < 1000; i++)
            //        {
            //            lineData.Update(i, Math.Sin(i * 0.1 + phase));
            //            scatterData.Update(i, Math.Cos(i * 0.1 + phase));
            //        }
            //    }
            //    phase += 0.01;
            //};
            //timer.Start();

            // APPEND
            var timer = new DispatcherTimer(DispatcherPriority.Render);
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += (s, e) =>
            {
                using (lineData.SuspendUpdates())
                using (scatterData.SuspendUpdates())
                {
                    int i = lineData.Count;
                    // Console.WriteLine("count i: " + i);
                    // Append new data point
                    lineData.Append(i, Math.Sin(i * 0.1));
                    scatterData.Append(i, Math.Cos(i * 0.1));
                    sciChartSurface.ZoomExtents();
                }
            };
            timer.Start();
        }

        private void OnLoadedFifo(object sender, RoutedEventArgs routedEventArgs)
        {
            // Create XyDataSeries to host data for our charts
            var scatterData = new XyDataSeries<double, double>() { SeriesName = "Cos(x)", FifoCapacity = 1000 };
            var lineData = new XyDataSeries<double, double>() { SeriesName = "Sin(x)", FifoCapacity = 1000 };

            // Assign dataseries to RenderSeries
            LineSeries.DataSeries = lineData;
            ScatterSeries.DataSeries = scatterData;
            int i = 0;

            // Start a timer to update our data
            // APPEND
            var timer = new DispatcherTimer(DispatcherPriority.Render);
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += (s, e) =>
            {
                using (lineData.SuspendUpdates())
                using (scatterData.SuspendUpdates())
                {
                    // Append new data point
                    lineData.Append(i, Math.Sin(i * 0.1));
                    scatterData.Append(i, Math.Cos(i * 0.1));
                    sciChartSurface.ZoomExtents();
                    // Set VisibleRange to last 1,000 points
                    xAxesNumericAxis.VisibleRange = new DoubleRange(i - 1000, i);
                    i++;
                }
            };
            timer.Start();
        }

        private void OnLoadedPreserveOldAndAllowZoom(object sender, RoutedEventArgs routedEventArgs)
        {
            // Instantiate the ViewportManager here
            double windowSize = ActualWidth;
            sciChartSurface.ViewportManager = new ScrollingViewportManager(windowSize);

            // Create XyDataSeries to host data for our charts
            var scatterData = new XyDataSeries<double, double>() { SeriesName = "Cos(x)" };
            var lineData = new XyDataSeries<double, double>() { SeriesName = "Sin(x)" };

            // Assign dataseries to RenderSeries
            LineSeries.DataSeries = lineData;
            ScatterSeries.DataSeries = scatterData;
            int i = 0;

            // Start a timer to update our data
            // APPEND
            var timer = new DispatcherTimer(DispatcherPriority.Render);
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += (s, e) =>
            {
                using (lineData.SuspendUpdates())
                using (scatterData.SuspendUpdates())
                {
                    // Append new data point
                    lineData.Append(i, Math.Sin(i * 0.1));
                    scatterData.Append(i, Math.Cos(i * 0.1));
                    // Every 100th datapoint, add an annotation
                    if (i % 100 == 0)
                    {
                        var isSecond = i % 200 == 0;
                        sciChartSurface.Annotations.Add(new InfoAnnotation() {
                            X1 = i,
                            Y1 = isSecond ? Math.Cos(i * 0.1) : Math.Sin(i * 0.1),
                            YAxisId = isSecond ? "Axis2" : AxisBase.DefaultAxisId
                        });
                        // It does not work, I don't know why?
                        // Optional: Don't forget to remove annotations which are out of range!
                        // sciChartSurface.Annotations.RemoveWhere(x => x.X1.ToDouble() < i - 1000);
                    }
                    i++;
                }
            };
            timer.Start();
        }
    }
}
