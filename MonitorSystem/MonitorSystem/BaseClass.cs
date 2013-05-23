using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MongoDB.Bson;
//using MongoDB.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace MonitorSystem
{
    public class BaseClass
    {
        public static MongoServer server = MongoServer.Create();
        public static MongoDatabase db = server.GetDatabase("MachineMonitorDB");
        public BaseClass()
        {
            server.Connect();
        }
    }
}