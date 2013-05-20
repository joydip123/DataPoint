using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using Newtonsoft.Json;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Text;

namespace MonitorSystem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [System.ServiceModel.Web.WebInvoke(Method = "POST", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json, BodyStyle = System.ServiceModel.Web.WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        string InsertBasicDetails(BasicDetails BasicInfo, string rd,string wrt);

        //[OperationContract]
        //void InsertData(BasicDetails BasicInfo, string readval);

        [OperationContract]
        [System.ServiceModel.Web.WebInvoke(Method = "POST", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json, BodyStyle = System.ServiceModel.Web.WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        string GetUpdatedBasic(BasicDetails BasicInfoEdit, string Editrd, string Editwrt);

        [OperationContract]
        [System.ServiceModel.Web.WebInvoke(Method = "POST", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json, BodyStyle = System.ServiceModel.Web.WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        string DeleteBasicInfo(string BasicId);


        [OperationContract]
        [System.ServiceModel.Web.WebInvoke(Method = "Get", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json, BodyStyle = System.ServiceModel.Web.WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        string getBasicInfoById(string Id);

        [OperationContract]
        [System.ServiceModel.Web.WebInvoke(Method = "Get", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json, BodyStyle = System.ServiceModel.Web.WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        IEnumerable<BasicDetails> getAll();
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class Movie
    //{
    //    public BsonObjectId Id { get; set; }
    //    public string Title { get; set; }
    //    public string Year { get; set; }
    //    public List<string> Actors { get; set; }

    //    public void AddActor(string actor)
    //    {
    //        if (Actors == null)
    //        {
    //            Actors = new List<string>();
    //        }
    //        Actors.Add(actor);
    //    }
    //}
    [DataContract]
    public class BasicDetails
    {
        public ObjectId _id { get; set; }

        [DataMember]
        public string basicid { get ; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string expire_t { get; set; }
        [DataMember]
        public string expire_s { get; set; }
       
        public List<string> read = new List<string>();
        public void AddRead(string rd)
        {
            if (read == null)
            {
                read = new List<string>();
            }
            read.Add(rd);
        }
        public List<string> write = new List<string>();
        public void AddWrite(string wrt)
        {
            if (write == null)
            {
                write = new List<string>();
            }
            write.Add(wrt);
        }
        
      
        
        //[DataMember]

        //public string BasicId
        //{

        //    get { return basicid; }

        //    set { basicid = value; }

        //}

        //[DataMember]

        //public string Name

        //{

        //    get { return name; }

        //    set { name = value; }

        //}

        //[DataMember]

        //public string Description
        //{

        //    get { return description; }

        //    set { description = value; }

        //}

        //[DataMember]

        //public string Expire_t
        //{

        //    get { return expire_t; }

        //    set { expire_t = value; }

        //}

        //[DataMember]

        //public string Expire_s
        //{

        //    get { return expire_s; }

        //    set { expire_s = value; }

        //}

        
    }
}
