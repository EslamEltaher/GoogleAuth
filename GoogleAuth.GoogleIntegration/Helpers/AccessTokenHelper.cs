using GoogleAuth.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleAuth.GoogleIntegration.Helpers
{
    public class AccessTokenHelper
    {
        private readonly GoogleAuthConfiguration _config;
        private readonly IHttpWrapper _http;

        public AccessTokenHelper(GoogleAuthConfiguration config, IHttpWrapper http)
        {
            _config = config;
            _http = http;
        }
    }
}
