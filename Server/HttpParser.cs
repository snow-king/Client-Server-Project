using System;
using System.IO;
using Server.Controllers;
using System.Net;
using Server.Models;
using YamlDotNet.Serialization;

namespace Server
{

    class HttpParser
    {
        public class RespBuilder
        {
            public int StatusCode { get; set; }
            public string StatusDescription { get; set; }
            public string ResponseString { get; set; }
        }

        //string req;
        public HttpParser(HttpListenerContext context, SQLConnector con)
        {
            RespBuilder rb = new RespBuilder();

            HttpListenerRequest request = context.Request;
            switch (request.HttpMethod)
            {
                case "GET":

                    GetController controller = new GetController(context, con);


                    break;

                case "POST":
                    DBDataModifyFuncs mod = new DBDataModifyFuncs(con.Connection);
                    //mod.timetableIns(10, 3, 7, 13, 1, 8, 7, 3);

                    if (!request.HasEntityBody)
                    {
                        Console.WriteLine("No client data was sent with the request.");
                        //req = "ДУРАК БЛЯТЬ СУКА";
                        break;
                    }

                    Stream body = request.InputStream;
                    System.Text.Encoding encoding = request.ContentEncoding;
                    StreamReader reader = new StreamReader(body, encoding);

                    if (request.ContentType != null)
                    {
                        Console.WriteLine("Client data content type {0}", request.ContentType);
                    }
                    Console.WriteLine("Client data content length {0}", request.ContentLength64);

                    Console.WriteLine("Start if client data: ");
                    string s = reader.ReadToEnd();
                    Console.WriteLine(s);
                    Console.WriteLine("End of client data:");

                    var deserializer = new DeserializerBuilder()
                        //.WithNamingConvention(CamelCaseNamingConvention.Instance)
                        .Build();
                    var allTimetable = deserializer.Deserialize<Timetable>(s);
                    mod.timetableIns(allTimetable);

                    body.Close();
                    reader.Close();

                    //req = "ОК БЛЯ, СУКА!!!";

                    break;

                default:
                    break;
            }

            /*HttpListenerResponse resp = context.Response;
            ResponsCreate(resp, rb);*/

        }
/*        private void ResponsCreate(HttpListenerResponse resp, RespBuilder respsv)
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(respsv.ResponseString);
            resp.ContentLength64 = buffer.Length;
            resp.StatusCode = respsv.StatusCode;
            resp.StatusDescription = respsv.StatusDescription;
            Stream output = resp.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }        */
    }
}
