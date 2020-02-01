using GoogleAuth.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleAuth.GoogleIntegration.Helpers
{
    public class RedirectUrlHelper
    {
        private readonly GoogleAuthConfiguration _config;
        private readonly IHttpWrapper _http;

        public RedirectUrlHelper(GoogleAuthConfiguration config, IHttpWrapper http)
        {
            _config = config;
            _http = http;
        }

        public string GetRedirectUrl(string state)
        {
            var values = new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("response_type", "code"),
                new KeyValuePair<string, string>("client_id", _config.GoogleClientID),
                new KeyValuePair<string, string>("redirect_uri", _config.Redirect_Url),
                new KeyValuePair<string, string>("scope", "openid email"),
                new KeyValuePair<string, string>("state", state),
            };

            string url = GoogleConstants.authorizeUrl
                + "?"
                + string.Join("&", values.Select(v => v.Key + "=" + v.Value));

            return url;
        }
    }
}
