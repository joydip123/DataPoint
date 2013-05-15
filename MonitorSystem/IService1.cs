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
        string InsertBasicDetails(BasicDetails BasicInfo, string rd,int cnt);

        [OperationContract]
        [System.ServiceModel.Web.WebInvoke(Method = "POST", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json, BodyStyle = System.ServiceModel.Web.WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        string GetUpdatedBasic(BasicDetails BasicInfoEdit);

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
    [DataContract]
    public class BasicDetails
    {
       
        public string basicid { get; set; }
        public string name { get; set; }

        public string description { get; set; }
        public string expire_t { get; set; }
        public string expire_s { get; set; }
       
        public List<string> read = new List<string>();
        public List<string> write = new List<string>();
       
        public ObjectId _id { get; set; }
      
        [DataMember]
        public List<string> Read
        {
            get { return this.read; }
            set { this.read = value; }
        }
        [DataMember]
        public List<string> Write
        {
            get { return this.write; }
            set { this.write = value; }
        }
        [DataMember]

        public string BasicId
        {

            get { return basicid; }

            set { basicid = value; }

        }
       
        [DataMember]

        public string Name
        {

            get { return name; }

            set { name = value; }

        }

        [DataMember]

        public string Description
        {

            get { return description; }

            set { description = value; }

        }

        [DataMember]

        public string Expire_t
        {

            get { return expire_t; }

            set { expire_t = value; }

        }

        [DataMember]

        public string Expire_s
        {

            get { return expire_s; }

            set { expire_s = value; }

        }

        
    }
}
