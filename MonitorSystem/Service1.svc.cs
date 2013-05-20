using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Newtonsoft.Json;
using MongoDB.Bson.Serialization;
using System.Text;

namespace MonitorSystem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    ///////////////////////////////////////////////////////////////
    //                       INSERT FUNCTION
    //////////////////////////////////////////////////////////////
    public class Service1 : IService1
    {
       
        //public void InsertData(BasicDetails BasicInfo,string readval)
        //{
        //    MongoCollection<BsonDocument> Info = BaseClass.db.GetCollection<BsonDocument>("Basic");
        //    //Create some data
        //    var movie1 = new Movie { Title = "Indiana Jones and the Raiders of the Lost Ark", Year = "1981" };
        //    movie1.AddActor("Harrison Ford");
        //    movie1.AddActor("Karen Allen");
        //    movie1.AddActor("Paul Freeman");

            
        //    Info.Insert(movie1);
           
        //}
        public string InsertBasicDetails(BasicDetails BasicInfo,string rd,string wrt)
        {
            string Message;
           
            //////////////////////////////////
            string [] wordRd=rd.Split(',');
            string [] wordRw = wrt.Split(',');
            //string[] terms = { };
            //List<String> tmp = new List<string>();
            
            //foreach (string rd1 in words)
            //{
            //    tmp.Add(rd1);
            //}
            //terms = tmp.ToArray();
          
            MongoCollection<BsonDocument> Info = BaseClass.db.GetCollection<BsonDocument>("Basic");
            //////////////////////////////////////////////////////////////////////////////////////////////////////
            //var basicdetails = new BasicDetails { basicid = BasicInfo.basicid, name = BasicInfo.Name, description=BasicInfo.Description, expire_t=BasicInfo.Expire_t, expire_s=BasicInfo.Expire_s };
            var basicdetails = new BasicDetails { basicid = BasicInfo.basicid, name = BasicInfo.name, description = BasicInfo.description, expire_t = BasicInfo.expire_t, expire_s = BasicInfo.expire_s };
            
            foreach (string rd1 in wordRd){ basicdetails.AddRead(rd1);}foreach (string rd2 in wordRw){basicdetails.AddWrite(rd2);}
           
            /////////////////////////////////////////////////////////////////////////////////////////////////////
            //BsonDocument Basicdoc = new BsonDocument {
            
            //            { "basicid", BasicInfo.BasicId },
            //            { "name", BasicInfo.Name },
            //            { "description",BasicInfo.Description },
            //            { "expire_t",BasicInfo.Expire_t },
            //            { "expire_s",BasicInfo.Expire_s },
            //            { "read", new BsonArray().Add(BsonValue.Create(rst } },
                       
            //            { "write", new BsonArray() {terms[cnt] } },
            
            //};
            //----------------------------------------------------------------------------------------
           
            //----------------------------------------------------------------------------------------
            
            var result = Info.Insert(basicdetails);
            if (result == null )
            { Message = BasicInfo.name + " Details inserted successfully";}
            else{Message = BasicInfo.name + " Details not inserted successfully";}
            return Message;
        }
        ///////////////////////////////////////////////////////////////
        //                       EDIT FUNCTION
        //////////////////////////////////////////////////////////////
        public string GetUpdatedBasic(BasicDetails BasicInfoEdit, string Editrd, string Editwrt)
        {

            MongoCollection<BsonDocument> Info = BaseClass.db.GetCollection<BsonDocument>("Basic");
            string Message;
            var query = Query.EQ("basicid", BasicInfoEdit.basicid);
            var sortBy = SortBy.Descending("basicid");
            var basicdetails = Update.Set("basicid", BasicInfoEdit.basicid)
                                     .Set("name", BasicInfoEdit.name)
                                     .Set("description", BasicInfoEdit.description)
                                     .Set("expire_t", BasicInfoEdit.expire_t)
                                     .Set("expire_s", BasicInfoEdit.expire_s)
                                     .Set("read", BsonArray.Create(Editrd.Split(',').Select(o => o.Trim())))
                                     .Set("write", BsonArray.Create(Editwrt.Split(',').Select(p => p.Trim())));

            //foreach (string rd1 in wordRd) { Update.Set("read", BsonArray.Create(rd.Split(',').Select(o => o.Trim()))); }
            //foreach (string rd2 in wordRw) { Update.Set("write" + i.ToString(), rd2); i++; };

            // var result = Update.PushAll("Basic",Info.ToBsonDocument());
            var result = Info.FindAndModify(query, sortBy, basicdetails, true);
            if (result != null)
            {


                Message = BasicInfoEdit.name + " Edited successfully";

            }
            else
            {

                Message = BasicInfoEdit.name + " Edit was not successful";

            }
            return Message;
        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public string DeleteBasicInfo(string BasicId)
        {
            string Message;
            MongoCollection<BasicDetails> employees = BaseClass.db.GetCollection<BasicDetails>("Basic");
            var result = employees.FindAndRemove(Query.EQ("basicid", BasicId),
                SortBy.Ascending("_id"));
            if (result != null)
            {

                Message = " Deleted successfully";

            }
            else
            {

                Message = " Deletion Unsuccessful";

            }
            return Message;
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////
        //                Retrieve Data

        //////////////////////////////////////////////////////////////////////////////////////////////////

        public string getBasicInfoById(string Id)
        {
            MongoCollection<BasicDetails> GetBasic = BaseClass.db.GetCollection<BasicDetails>("Basic");
            BasicDetails obj = new BasicDetails();
            var dtls = GetBasic.FindOne(Query.EQ("basicid", Id));

            //obj.read = dtls.read;
            //obj.write = dtls.write;
            //string objRd = "";
            //string objRw="";
            //for (int i = 0; i < obj.read.Count; i++)
            //{
            //    objRd = objRd + obj.read[i]+",";
            //}
            //objRd = objRd.TrimEnd(',',' ');
            //for (int i = 0; i < obj.read.Count; i++)
            //{
            //    objRw = objRw + obj.write[i] + ",";
            //}
            //objRw = objRw.TrimEnd(',', ' ');              
                return obj.ToString();
          
        }
        public IEnumerable<BasicDetails> getAll()
        {
            List<BasicDetails> lst = new List<BasicDetails>();
            //return lst;
            //BsonSerializer.Deserialize<MyType>(doc);

            MongoCollection<BasicDetails> alldt = BaseClass.db.GetCollection<BasicDetails>("Basic");


            foreach (BasicDetails allobj in alldt.FindAll())
            {
                lst.Add(allobj);

            }
            return lst;

        }

    }
}

