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
            SciChartSurface.SetRuntimeLicenseKey("yHEqMJIyOII/lSy4527EFMnmjvuy9hKmgdD+5fAwSAtt5LbFtTvO3JHEyaxMl7hiRZ+EvI+fyGhxDDFasTZOm3tsZvwt3XIaHOpT5E5jaR2W6YNNsuNdLNwqjklRtxhRq4pljfSXHeG5DhNnJCY0w/UtZHiwdMdd8gfwZ/KEgFfdLtzI6iCprnx+UuuErc1X717l+SnSAQgm5oKGefgAANzMt4/RjDxaAZZOXHbFw7A17+RabghfN/FIAP6BjEqaHHyZQ0mkREkyk63kaPlW4SiHqDayhBSLetMmo+Ncs1Lw+8/BMu1sm1e3Nm8B+rOe5q8znC4Y++3FC/+KHdx2d/pxJ7iZV01kqc2sOSXDtYR/9mc0MOLHqbNY/vrJVvlxTjDAeXqkfvX3eNoFGnOWksnn/0HLidIXBq3BNHeBwCrzK3VnGqtJN+EyFK52bMGpICsPvMTe72aB2kL2JmjQ9ScMgLEJjwhBqOE8W+HwS4t2Xyhk0y3eNv8QRNfRBBvRJD7IEA0PfrOB5kTUgnqIg7c2DPsijDd5OHJn5tbAydLUE9dxiqVbVl1J");
        }
    }
}
