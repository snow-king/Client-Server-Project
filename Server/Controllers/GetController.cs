using System;
using System.IO;
using System.Net;
using Server.Models;
using YamlDotNet.Serialization;

namespace Server.Controllers
{
    class GetController
    {
        public GetController(HttpListenerContext context, SQLConnector con)
        {
            DBSelectsFuncs sel = new DBSelectsFuncs(con.Connection);
            HttpListenerResponse response = context.Response;
            HttpListenerRequest request = context.Request;

            switch (context.Request.RawUrl)
            {
                case "/":
                    {
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        Stream output = response.OutputStream;
                        output.Close();
                    }
                    break;
                case "/timetable":
                    {
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(sel.getAll());
                        response.ContentLength64 = buffer.Length;
                        response.StatusCode = (int)HttpStatusCode.OK;
                        Stream output = response.OutputStream;
                        output.Write(buffer, 0, buffer.Length);
                        output.Close();
                    }
                    break;
                
                case "/professors":
                    {
                        System.Collections.Specialized.NameValueCollection headers = request.Headers;
                        string value = headers["ProfessorId"];
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(sel.getLessonsByProffesor(Convert.ToInt32(value)));
                        response.ContentLength64 = buffer.Length;
                        response.StatusCode = (int)HttpStatusCode.OK;
                        Stream output = response.OutputStream;
                        output.Write(buffer, 0, buffer.Length);
                        output.Close();
                    }
                    break;

                default:
                    {
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        Stream output = response.OutputStream;
                        output.Close();
                    }
                    break;
            }
        }
    }
}
