using Sitecore.Analytics;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.HttpRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace Sitecore.Pipelines.HttpRequestBegin
{
    public class SessionForWebApi : HttpRequestProcessor
    {
        private string _apiUrl;
        private SessionStateBehavior _sessionStateBehavior;
        public SessionForWebApi(string apiUrl, string sessionStateMode)
        {
            _apiUrl = apiUrl;
            _sessionStateBehavior = GetBehavior(sessionStateMode.ToLower());
        }

        /// <summary>
        /// Runs the processor.
        /// 
        /// </summary>
        /// <param name="args">The arguments.</param>
        public override void Process(HttpRequestArgs args)
        {
            Assert.ArgumentNotNull((object)args, "args");
            if (args.Context.Request.Url.OriginalString.ToLower().Contains(_apiUrl))
            {
                if (_sessionStateBehavior == SessionStateBehavior.Disabled)
                {
                    DisableTracker();
                }
                HttpContext.Current.SetSessionStateBehavior(_sessionStateBehavior);
            }
        }

        private SessionStateBehavior GetBehavior(string mode)
        {
            if (string.IsNullOrEmpty(mode))
            {
                return SessionStateBehavior.Default;
            }

            switch (mode)
            {
                case "disabled":
                    return SessionStateBehavior.Disabled;
                case "readonly":
                    return SessionStateBehavior.ReadOnly;
                case "required":
                    return SessionStateBehavior.Required;
                default:
                    return SessionStateBehavior.Default;
            }
        }

        private void DisableTracker()
        {
            Tracker.Enabled = false;
        }
    }
}
