namespace cSharpBasic
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;

    internal class http_request
    {
        public static string backdata(string bm, string DsmpUrl, string sXmlMessage, string ua, string isJson)
        {
            try
            {
                if (bm == "")
                {
                    return "请选择编码!";
                }
                Encoding encoding = Encoding.GetEncoding(bm);
                byte[] bytes = encoding.GetBytes(sXmlMessage);
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(DsmpUrl);
                request.Method = "POST";
                if (Convert.ToBoolean(System.Int32.Parse(isJson)))
                {
                    request.ContentType = "application/json";
                }
                else
                {
                    request.ContentType = "application/x-www-form-urlencoded";
                }
                
                request.ContentLength = bytes.Length;
                request.UserAgent = ua;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), encoding);
                char[] buffer = new char[0x100];
                int length = reader.Read(buffer, 0, 0x100);
                string str = null;
                while (length > 0)
                {
                    str = str + new string(buffer, 0, length);
                    length = reader.Read(buffer, 0, 0x100);
                }
                reader.Close();
                response.Close();
                return str;
            }
            catch (WebException exception)
            {
                WebResponse response2 = exception.Response;
                Encoding encoding2 = Encoding.GetEncoding(bm);
                StreamReader reader2 = new StreamReader(response2.GetResponseStream(), encoding2);
                string str2 = reader2.ReadToEnd();
                response2.Close();
                reader2.Close();
                return str2;
            }
        }
    }
}

