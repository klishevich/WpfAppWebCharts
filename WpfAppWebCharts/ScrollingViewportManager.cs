﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SciChart.Charting.ViewportManagers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Data.Model;

namespace WpfAppWebCharts
{
    public class ScrollingViewportManager: DefaultViewportManager
    {
        private readonly double _windowSize;
        public ScrollingViewportManager(double windowSize)
        {
            _windowSize = windowSize;
        }
        public override void AttachSciChartSurface(ISciChartSurface scs)
        {
            base.AttachSciChartSurface(scs);
            this.ParentSurface = scs;
        }
        public ISciChartSurface ParentSurface { get; private set; }
        protected override IRange OnCalculateNewXRange(IAxis xAxis)
        {
            // The Current XAxis VisibleRange
            var currentVisibleRange = xAxis.VisibleRange.AsDoubleRange();
            if (ParentSurface.ZoomState == ZoomStates.UserZooming)
                return currentVisibleRange;     // Don't scroll if user is zooming
            // The MaxXRange is the VisibleRange on the XAxis if we were to zoom to fit all data
            var maxXRange = xAxis.GetMaximumRange().AsDoubleRange();
            double xMax = Math.Max(maxXRange.Max, currentVisibleRange.Max);
            // Scroll showing latest window size
            return new DoubleRange(xMax - _windowSize, xMax);
        }
    }
}
