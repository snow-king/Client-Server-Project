using System;
using System.IO;
using System.Net;
using Server.Models;
using Server;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Server.Controllers
{
    class PostController
    {
        public PostController(HttpListenerContext context, SQLConnector con)
        {
            HttpListenerResponse response = context.Response;
            HttpListenerRequest request = context.Request;
            DBDataModifyFuncs mod = new DBDataModifyFuncs(con.Connection);

            if (!request.HasEntityBody)
            {
                Console.WriteLine("No client data was sent with the request.");
                return;
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

            switch (context.Request.RawUrl)
            {
                case "/":
                    {
                        body.Close();
                        reader.Close();
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        Stream output = response.OutputStream;
                        output.Close();
                    }
                    break;

                case "/timetable":
                    {
                        

                        var deserializer = new DeserializerBuilder()
                            //.WithNamingConvention(CamelCaseNamingConvention.Instance)
                            .Build();
                        var allTimetable = deserializer.Deserialize<Timetable>(s);
                        mod.timetableIns(allTimetable);

                        body.Close();
                        reader.Close();


                        response.StatusCode = (int)HttpStatusCode.OK;
                        Stream output = response.OutputStream;
                        output.Close();                                              
                    }   
                    break; 
                
                case "/classroom":
                    {
                        var deserializer = new DeserializerBuilder()
                            //.WithNamingConvention(CamelCaseNamingConvention.Instance)
                            .Build();
                        var classrooms = deserializer.Deserialize<Classroom>(s);
                        mod.classroomIns(classrooms.Classroom_number, classrooms.Frame);

                        body.Close();
                        reader.Close();


                        response.StatusCode = (int)HttpStatusCode.OK;
                        Stream output = response.OutputStream;
                        output.Close();                                              
                    }   
                    break;       
                
                case "/discipline":
                    {
                        var deserializer = new DeserializerBuilder()
                            //.WithNamingConvention(CamelCaseNamingConvention.Instance)
                            .Build();
                        var disciplines = deserializer.Deserialize<Discipline>(s);
                        mod.disciplineIns(disciplines.Name_discipline);

                        body.Close();
                        reader.Close();


                        response.StatusCode = (int)HttpStatusCode.OK;
                        Stream output = response.OutputStream;
                        output.Close();                                              
                    }   
                    break;
                
                case "/faculty":
                    {
                        var deserializer = new DeserializerBuilder()
                            //.WithNamingConvention(CamelCaseNamingConvention.Instance)
                            .Build();
                        var facultys = deserializer.Deserialize<Faculty>(s);
                        mod.facultyIns(facultys.Name_faculty);

                        body.Close();
                        reader.Close();


                        response.StatusCode = (int)HttpStatusCode.OK;
                        Stream output = response.OutputStream;
                        output.Close();                                              
                    }   
                    break;       
                
                case "/lesson_time":
                    {
                        var deserializer = new DeserializerBuilder()
                            //.WithNamingConvention(CamelCaseNamingConvention.Instance)
                            .Build();
                        var lesson_times = deserializer.Deserialize<LessonTime>(s);
                        mod.lesson_timeIns(lesson_times.Lesson_number, lesson_times.Lesson_start, lesson_times.Lesson_finish);

                        body.Close();
                        reader.Close();


                        response.StatusCode = (int)HttpStatusCode.OK;
                        Stream output = response.OutputStream;
                        output.Close();                                              
                    }   
                    break; 
                
                case "/lesson_type":
                    {
                        var deserializer = new DeserializerBuilder()
                            //.WithNamingConvention(CamelCaseNamingConvention.Instance)
                            .Build();
                        var lesson_types = deserializer.Deserialize<LessonType>(s);
                        mod.lesson_typeIns(lesson_types.Lesson_type);

                        body.Close();
                        reader.Close();


                        response.StatusCode = (int)HttpStatusCode.OK;
                        Stream output = response.OutputStream;
                        output.Close();                                              
                    }   
                    break; 
                
                case "/professors":
                    {
                        var deserializer = new DeserializerBuilder()
                            //.WithNamingConvention(CamelCaseNamingConvention.Instance)
                            .Build();
                        var professors = deserializer.Deserialize<Professors>(s);
                        mod.professorsIns(professors.Name, professors.Surname, professors.Patronymic);

                        body.Close();
                        reader.Close();


                        response.StatusCode = (int)HttpStatusCode.OK;
                        Stream output = response.OutputStream;
                        output.Close();                                              
                    }   
                    break;   
                
                case "/speciality":
                    {
                        var deserializer = new DeserializerBuilder()
                            //.WithNamingConvention(CamelCaseNamingConvention.Instance)
                            .Build();
                        var specialitys = deserializer.Deserialize<Speciality>(s);
                        mod.specialityIns(specialitys.Name_speciality, specialitys.Abbreviated_speciality);

                        body.Close();
                        reader.Close();


                        response.StatusCode = (int)HttpStatusCode.OK;
                        Stream output = response.OutputStream;
                        output.Close();                                              
                    }   
                    break;   
                
                case "/study_groups":
                    {
                        var deserializer = new DeserializerBuilder()
                            //.WithNamingConvention(CamelCaseNamingConvention.Instance)
                            .Build();
                        var studyGroups = deserializer.Deserialize<StudyGroups>(s);
                        mod.study_groupsIns(studyGroups.Name_group, studyGroups.Id_faculty, studyGroups.Id_speciality, studyGroups.Course, studyGroups.Form_education);

                        body.Close();
                        reader.Close();


                        response.StatusCode = (int)HttpStatusCode.OK;
                        Stream output = response.OutputStream;
                        output.Close();                                              
                    }   
                    break; 
                
                case "/week_day":
                    {
                        var deserializer = new DeserializerBuilder()
                            //.WithNamingConvention(CamelCaseNamingConvention.Instance)
                            .Build();
                        var weekDays = deserializer.Deserialize<WeekDay>(s);
                        mod.week_dayIns(weekDays.Weekday);

                        body.Close();
                        reader.Close();


                        response.StatusCode = (int)HttpStatusCode.OK;
                        Stream output = response.OutputStream;
                        output.Close();                                              
                    }   
                    break;  
                
                case "/week_parity":
                    {
                        var deserializer = new DeserializerBuilder()
                            //.WithNamingConvention(CamelCaseNamingConvention.Instance)
                            .Build();
                        var WeekParitys = deserializer.Deserialize<WeekParity>(s);
                        mod.week_parityIns(WeekParitys.Week_parity);

                        body.Close();
                        reader.Close();


                        response.StatusCode = (int)HttpStatusCode.OK;
                        Stream output = response.OutputStream;
                        output.Close();                                              
                    }   
                    break;                

                default:
                    {
                        body.Close();
                        reader.Close();
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        Stream output = response.OutputStream;
                        output.Close();
                    }
                    break;
            }
        }
    }
}
