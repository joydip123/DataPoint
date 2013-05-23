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


        public string InsertBasicDetails(BasicDetails BasicInfo, string rd, string wrt)
        {
            string Message;

            //////////////////////////////////
            string[] wordRd = rd.Split(',');
            string[] wordRw = wrt.Split(',');


            MongoCollection<BsonDocument> Info = BaseClass.db.GetCollection<BsonDocument>("Basic");
            //////////////////////////////////////////////////////////////////////////////////////////////////////
            
            var dtls = Info.FindOne(Query.EQ("basicid", BasicInfo.basicid));
            if (dtls == null)
            {
                var basicdetails = new BasicDetails { basicid = BasicInfo.basicid, name = BasicInfo.name, description = BasicInfo.description, expire_t = BasicInfo.expire_t, expire_s = BasicInfo.expire_s };

                foreach (string rd1 in wordRd) { basicdetails.AddRead(rd1); } foreach (string rd2 in wordRw) { basicdetails.AddWrite(rd2); }



                //----------------------------------------------------------------------------------------

                var result = Info.Insert(basicdetails);
                if (result == null)
                { Message = BasicInfo.name + " Details inserted successfully"; }
                else { Message = BasicInfo.name + " Details not inserted successfully"; }
            }
            else
            {
                Message = "Id No. " + BasicInfo.basicid + "is already exist!";
            }
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
        public string getBasicInfoReadId(string Id)
        {
            string Message;
            MongoCollection<BasicDetails> GetBasic = BaseClass.db.GetCollection<BasicDetails>("Basic");
            BasicDetails obj = new BasicDetails();
            var dtls = GetBasic.FindOne(Query.EQ("basicid", Id));

            if (dtls != null)
            {
                obj.read = dtls.read;

                string objRd = "";

                for (int i = 0; i < obj.read.Count; i++)
                {
                    objRd = objRd + obj.read[i] + ",";
                }
                Message = objRd.TrimEnd(',', ' ');
            }
            else
            {
                Message = "";
            }

            return Message;
        }
        public string getBasicInfoWriteId(string Id)
        {
            string Message;
            MongoCollection<BasicDetails> GetBasic = BaseClass.db.GetCollection<BasicDetails>("Basic");
            BasicDetails obj = new BasicDetails();
            var dtls = GetBasic.FindOne(Query.EQ("basicid", Id));

            if (dtls != null)
            {
                obj.write = dtls.write;

                string objRw = "";


                for (int i = 0; i < obj.write.Count; i++)
                {
                    objRw = objRw + obj.write[i] + ",";
                }
                Message = objRw.TrimEnd(',', ' ');
            }
            else
            {
                Message = "";
            }
            return Message;
        }
        public string getBasicInfoNameById(string Id)
        {
            string Message;
            MongoCollection<BasicDetails> employees = BaseClass.db.GetCollection<BasicDetails>("Basic");
            string nm = "";
            BasicDetails bsd = employees.FindOne(Query.EQ("basicid", Id));
            if (bsd != null)
            {
                nm = bsd.name.ToString();
                Message = nm;
            }
            else
            {
                nm = "";
                Message = nm;
            }

            return nm;
        }
        public string getBasicInfoDescriptionById(string Id)
        {
            string Message;
            MongoCollection<BasicDetails> employees = BaseClass.db.GetCollection<BasicDetails>("Basic");

            BasicDetails bsd = employees.FindOne(Query.EQ("basicid", Id));


            if (bsd != null)
            {
                Message = bsd.description.ToString();

            }
            else
            {

                Message = "";
            }

            return Message;
        }
        public string getBasicInfoExpTById(string Id)
        {
            string Message;
            MongoCollection<BasicDetails> employees = BaseClass.db.GetCollection<BasicDetails>("Basic");

            BasicDetails bsd = employees.FindOne(Query.EQ("basicid", Id));

            if (bsd != null)
            {
                Message = bsd.expire_t.ToString();

            }
            else
            {

                Message = "";
            }

            return Message;
        }
        public string getBasicInfoExpSById(string Id)
        {
            string Message;
            MongoCollection<BasicDetails> employees = BaseClass.db.GetCollection<BasicDetails>("Basic");

            BasicDetails bsd = employees.FindOne(Query.EQ("basicid", Id));

            if (bsd != null)
            {
                Message = bsd.expire_s.ToString();

            }
            else
            {

                Message = "";
            }

            return Message;
        }

        public string getAll()
        {

            string lst = "";
            MongoCollection<BasicDetails> info = BaseClass.db.GetCollection<BasicDetails>("Basic");


            foreach (BasicDetails dtlsinfo in info.FindAll())
            {
                string aa = dtlsinfo.basicid;

                lst = lst + aa + ",";
            }
            lst = lst.TrimEnd(',');

            return lst.ToString();


        }


    }
}

