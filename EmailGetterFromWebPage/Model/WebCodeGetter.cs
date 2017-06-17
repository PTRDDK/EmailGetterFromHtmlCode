using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmailGetterFromWebPage.Model
{
    class WebCodeGetter : IWebCodeGetter
    {
        private string htmlCode;
        private StreamReader readStream;

        public string getHTMLCode(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if(response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                
                if(response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
               }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }
            }


            string data = readStream.ReadToEnd();

            readStream.Close();
            response.Close();

            return data;
        }
    }
}
