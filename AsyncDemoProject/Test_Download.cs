using System;
using System.IO;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsyncDemoProject
{
    [TestClass]
    public class Test_Download
    {
        string url = "http://www.deelay.me/5000/www.delsink.com";

        [TestMethod]
        public void TestDownload()
        {
            var httpRequestInfo = HttpWebRequest.Create(url);
            var callBack = new AsyncCallback(HttpResponseAvailable);
            var asyncResult = httpRequestInfo.BeginGetResponse(callBack, httpRequestInfo);

            asyncResult.AsyncWaitHandle.WaitOne();
        }

        private static void HttpResponseAvailable(IAsyncResult asyncResult)
        {
            var httpRequestInfo = asyncResult.AsyncState as HttpWebRequest;
            var httpResponseInfo = httpRequestInfo.EndGetResponse(asyncResult) as HttpWebResponse;

            var responseStream = httpResponseInfo.GetResponseStream();
            using (StreamReader sr = new StreamReader(responseStream))
            {
                var webPage = sr.ReadToEnd();
            }
        }
    }
}
