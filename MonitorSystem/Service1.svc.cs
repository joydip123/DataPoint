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

namespace MonitorSystem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    ///////////////////////////////////////////////////////////////
    //                       INSERT FUNCTION
    //////////////////////////////////////////////////////////////
    public class Service1 : IService1
    {

        public string InsertBasicDetails(BasicDetails BasicInfo,string rd,int cnt)
        {
            string Message;
           
           

            //////////////////////////////////
            string [] words=rd.Split(',');
           
            string[] terms = { };
            List<String> tmp = new List<string>();
            int i=1;
            foreach (string rd1 in words)
            {
                tmp.Add(rd1);
            }
            terms = tmp.ToArray();
           
            MongoCollection<BsonDocument> Info = BaseClass.db.GetCollection<BsonDocument>("Basic");

            BsonDocument Basicdoc = new BsonDocument {
            
                        { "basicid", BasicInfo.BasicId },
                        { "name", BasicInfo.Name },
                        { "description",BasicInfo.Description },
                        { "expire_t",BasicInfo.Expire_t },
                        { "expire_s",BasicInfo.Expire_s },
                        { "read", new BsonArray() {terms[cnt] } },
                        { "write", new BsonArray() { rd } }
            
            };
            //----------------------------------------------------------------------------------------
           
            //----------------------------------------------------------------------------------------

            var result = Info.Insert(Basicdoc);
            if (result != null)
            {

                Message = BasicInfo.Name + " Details inserted successfully";

            }
            else
            {

                Message = BasicInfo.Name + " Details not inserted successfully";

            }
            return Message;

        }
        ///////////////////////////////////////////////////////////////
        //                       EDIT FUNCTION
        //////////////////////////////////////////////////////////////
        public string GetUpdatedBasic(BasicDetails BasicInfoEdit)
        {
            MongoCollection<BasicDetails> EditInfo = BaseClass.db.GetCollection<BasicDetails>("Basic");
            string Message;
            var query = Query.EQ("basicid", BasicInfoEdit.BasicId);
            var sortBy = SortBy.Descending("basicid");
            var update = Update.Set("name", BasicInfoEdit.Name)
                                .Set("description", BasicInfoEdit.Description)
                                .Set("expire_t", BasicInfoEdit.Expire_t)
                                .Set("expire_s", BasicInfoEdit.Expire_s);
            //.Set("read", BasicInfoEdit.Read)
            //.Set("write", BasicInfoEdit.Write);

            var result = EditInfo.FindAndModify(query, sortBy, update, true);
            if (result != null)
            {

                Message = BasicInfoEdit.Name + " Edited successfully";

            }
            else
            {

                Message = BasicInfoEdit.Name + " Edit was not successful";

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

            BasicDetails objStudent = new BasicDetails();
            var dtls = GetBasic.FindOne(Query.EQ("basicid", Id));

            //objStudent.Id = dtls.Id.ToString();
            objStudent.Name = dtls.Name;
            objStudent.Description = dtls.Description;


            return objStudent.ToString();
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

