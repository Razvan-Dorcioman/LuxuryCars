using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;

namespace LuxuryCars.Controllers
{
    public class TelemetryController : Controller
    {
        private static TelemetryClient _telemetry;

        // Use constructor injection to get a TelemetryClient instance.
        public TelemetryController(TelemetryClient telemetry)
        {
            _telemetry = telemetry;
        }

        public static void SendEvent(string eventName, IDictionary<string, string> props)
        {
            _telemetry.TrackEvent(eventName, props);
        }
    }
}