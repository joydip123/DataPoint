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

        [OperationContract]
        [System.ServiceModel.Web.WebInvoke(Method = "POST", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json, BodyStyle = System.ServiceModel.Web.WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        string GetUpdatedBasic(BasicDetails BasicInfoEdit, string Editrd, string Editwrt);

        [OperationContract]
        [System.ServiceModel.Web.WebInvoke(Method = "POST", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json, BodyStyle = System.ServiceModel.Web.WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        string DeleteBasicInfo(string BasicId);


        [OperationContract]
        [System.ServiceModel.Web.WebInvoke(Method = "Get", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json, BodyStyle = System.ServiceModel.Web.WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        string getBasicInfoNameById(string Id);

        [OperationContract]
        [System.ServiceModel.Web.WebInvoke(Method = "Get", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json, BodyStyle = System.ServiceModel.Web.WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        string getBasicInfoDescriptionById(string Id);

        [OperationContract]
        [System.ServiceModel.Web.WebInvoke(Method = "Get", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json, BodyStyle = System.ServiceModel.Web.WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        string getBasicInfoExpTById(string Id);

        [OperationContract]
        [System.ServiceModel.Web.WebInvoke(Method = "Get", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json, BodyStyle = System.ServiceModel.Web.WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        string getBasicInfoExpSById(string Id);

        [OperationContract]
        [System.ServiceModel.Web.WebInvoke(Method = "Get", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json, BodyStyle = System.ServiceModel.Web.WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        string getBasicInfoReadId(string Id);

        [OperationContract]
        [System.ServiceModel.Web.WebInvoke(Method = "Get", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json, BodyStyle = System.ServiceModel.Web.WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        string getBasicInfoWriteId(string Id);

        [OperationContract]
        [System.ServiceModel.Web.WebInvoke(Method = "Get", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json, BodyStyle = System.ServiceModel.Web.WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        string getAll();
        // TODO: Add your service operations here
    }


    
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
 
    }
}
