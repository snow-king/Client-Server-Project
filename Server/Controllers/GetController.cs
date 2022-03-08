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

 

            string[] loc = context.Request.RawUrl.Split('?', 2);
            Console.WriteLine(loc[0]);

            switch (loc[0])
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
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(sel.getLessonsByProffesorNSR(request.QueryString["name"], request.QueryString["surname"], request.QueryString["patronymic"]));
                        response.ContentLength64 = buffer.Length;
                        response.StatusCode = (int)HttpStatusCode.OK;
                        Stream output = response.OutputStream;
                        output.Write(buffer, 0, buffer.Length);
                        output.Close();
                    }
                    break;

                case "/professorsDate":
                    {
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(sel.getLessonsByProffesorNSRDate(request.QueryString["name"], request.QueryString["surname"], request.QueryString["patronymic"], request.QueryString["weekDay"], request.QueryString["parity"]));
                        response.ContentLength64 = buffer.Length;
                        response.StatusCode = (int)HttpStatusCode.OK;
                        Stream output = response.OutputStream;
                        output.Write(buffer, 0, buffer.Length);
                        output.Close();
                    }
                    break;
                
                case "/group":
                    {
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(sel.getLessonsByGroup(request.QueryString["name"]));
                        response.ContentLength64 = buffer.Length;
                        response.StatusCode = (int)HttpStatusCode.OK;
                        Stream output = response.OutputStream;
                        output.Write(buffer, 0, buffer.Length);
                        output.Close();
                    }
                    break;

                case "/groupDate":
                    {
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(sel.getLessonsByGroupDate(request.QueryString["name"], request.QueryString["weekDay"], request.QueryString["parity"]));
                        response.ContentLength64 = buffer.Length;
                        response.StatusCode = (int)HttpStatusCode.OK;
                        Stream output = response.OutputStream;
                        output.Write(buffer, 0, buffer.Length);
                        output.Close();
                    }
                    break;

                case "/classroom":
                    {
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(sel.getLessonsByClassrom(request.QueryString["classroom"], request.QueryString["frame"]));
                        response.ContentLength64 = buffer.Length;
                        response.StatusCode = (int)HttpStatusCode.OK;
                        Stream output = response.OutputStream;
                        output.Write(buffer, 0, buffer.Length);
                        output.Close();
                    }
                    break;

                case "/classroomDate":
                    {
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(sel.getLessonsByClassromDate(request.QueryString["classroom"], request.QueryString["frame"], request.QueryString["weedDay"], request.QueryString["parity"]));
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
