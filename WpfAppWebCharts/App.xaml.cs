using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SciChart.Charting.Visuals;

namespace WpfAppWebCharts
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // Set this code once in App.xaml.cs or application startup
            var runtimeKey = System.Environment.GetEnvironmentVariable("SCICHART_RUNTIMEKEY");
            Console.WriteLine("runtimeKey: " + runtimeKey);
            SciChartSurface.SetRuntimeLicenseKey(runtimeKey);
        }
    }
}
