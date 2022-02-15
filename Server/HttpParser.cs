using System;
using Server;
using System.Web;
using System.Net;

namespace Server
{
    class HttpParser
    {
        public string Req { get; private set; }

        public HttpParser(HttpListenerRequest query, SQLConnector con)
        {
            switch (query.HttpMethod)
            {
                case "GET":

                    Req = con.SelectTimeTable();
                    break;

                case "POST":
                    DBDataModifyFuncs mod = new DBDataModifyFuncs(con.Connection);
                    mod.timetableIns(10, 3, 7, 13, 1, 8, 7, 3);
                    break;

                default:
                    break;
            }
        }        
    }
}
