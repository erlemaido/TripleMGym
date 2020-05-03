using System;
using System.Net;

namespace TrainingApp.Aids.Services {

    public static class WebService {

        public static string Load(string url) {
            var num = 0;

            while (num <= 3) {
                num++;
                using var client = new WebClient();

                try { return client.DownloadString(url); }
                catch (Exception e) { Logging.Log.Exception(e); }
            }

            return string.Empty;
        }

    }

}