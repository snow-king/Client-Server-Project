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
            /*RespBuilder rb = new RespBuilder();*/

            HttpListenerRequest request = context.Request;
            switch (request.HttpMethod)
            {
                case "GET":

                    var gcontroller = new GetController(context, con);
                    break;

                case "POST":
                    var pcontroller = new PostController(context, con);
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
