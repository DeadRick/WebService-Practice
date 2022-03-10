/// HTTP GET

using System;
using System.IO;
using System.Net;
using System.Text;


/// <summary>
/// получение ответа от сервера (GET-запрос)
/// </summary>
/// <param name="url">адрес страницы</param>
/// <returns>строка</returns>
static string GetStringByHttpGet(string url)
{
    using (WebClient wc = new WebClient())
        return wc.DownloadString(url);
}
static string GetStringByHttpPost1(string url, string data, string contentType = "application/x-www-form-urlencoded")
{
    Byte[] dataBytes =  Encoding.UTF8.GetBytes(data);
    return GetStringByHttpPost(url, dataBytes, contentType);
}
static string GetStringByHttpPost(string url, byte[] dataBytes, string contentType = "application/x-www-form-urlencoded")
{
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
    request.ContentLength = dataBytes.Length;
    request.ContentType = contentType;
    request.Method = "POST";
    using (Stream requestBody = request.GetRequestStream())
    {
        requestBody.Write(dataBytes, 0, dataBytes.Length);
    }
    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    using (Stream stream = response.GetResponseStream())
    using (StreamReader reader = new StreamReader(stream))
    {
        return reader.ReadToEnd();
    }
}

Console.WriteLine(GetStringByHttpGet("http://localhost:14560/?name=wow"));
//Console.WriteLine(GetStringByHttpPost1("http://localhost:14560/", "name=aaa"));



