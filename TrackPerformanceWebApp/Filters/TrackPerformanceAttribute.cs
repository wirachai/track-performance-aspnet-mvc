using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Metrics;

namespace TrackPerformanceWebApp.Filters
{
    public class TrackPerformanceAttribute : ActionFilterAttribute
    {
        private readonly Timer _timer = Metric.Timer("Requests", Unit.Requests);
        private readonly Counter _counter = Metric.Counter("Concurrent Requests", Unit.Requests);

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (DoNotTrackPerformance(context))
            {
                return;
            }

            _counter.Increment();
            _timer.StartRecording();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _timer.EndRecording();
            _counter.Decrement();
        }

        private bool DoNotTrackPerformance(ActionExecutingContext context)
        {
            ActionDescriptor actionDescriptor = context.ActionDescriptor;
            return actionDescriptor.GetCustomAttributes(typeof(DoNotTrackPerformanceAttribute), true).Length > 0
                   || actionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(DoNotTrackPerformanceAttribute), true).Length > 0;
        }
    }
}