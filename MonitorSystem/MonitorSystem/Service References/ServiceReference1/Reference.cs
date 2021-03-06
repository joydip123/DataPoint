﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MonitorSystem.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BasicDetails", Namespace="http://schemas.datacontract.org/2004/07/MonitorSystem")]
    [System.SerializableAttribute()]
    public partial class BasicDetails : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BasicIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Expire_sField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Expire_tField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ReadField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WriteField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BasicId {
            get {
                return this.BasicIdField;
            }
            set {
                if ((object.ReferenceEquals(this.BasicIdField, value) != true)) {
                    this.BasicIdField = value;
                    this.RaisePropertyChanged("BasicId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Expire_s {
            get {
                return this.Expire_sField;
            }
            set {
                if ((object.ReferenceEquals(this.Expire_sField, value) != true)) {
                    this.Expire_sField = value;
                    this.RaisePropertyChanged("Expire_s");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Expire_t {
            get {
                return this.Expire_tField;
            }
            set {
                if ((object.ReferenceEquals(this.Expire_tField, value) != true)) {
                    this.Expire_tField = value;
                    this.RaisePropertyChanged("Expire_t");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Read {
            get {
                return this.ReadField;
            }
            set {
                if ((object.ReferenceEquals(this.ReadField, value) != true)) {
                    this.ReadField = value;
                    this.RaisePropertyChanged("Read");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Write {
            get {
                return this.WriteField;
            }
            set {
                if ((object.ReferenceEquals(this.WriteField, value) != true)) {
                    this.WriteField = value;
                    this.RaisePropertyChanged("Write");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/InsertBasicDetails", ReplyAction="http://tempuri.org/IService1/InsertBasicDetailsResponse")]
        string InsertBasicDetails(MonitorSystem.ServiceReference1.BasicDetails BasicInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUpdatedBasic", ReplyAction="http://tempuri.org/IService1/GetUpdatedBasicResponse")]
        string GetUpdatedBasic(MonitorSystem.ServiceReference1.BasicDetails BasicInfoEdit);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteBasicInfo", ReplyAction="http://tempuri.org/IService1/DeleteBasicInfoResponse")]
        string DeleteBasicInfo(string BasicId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getBasicInfoById", ReplyAction="http://tempuri.org/IService1/getBasicInfoByIdResponse")]
        string getBasicInfoById(string Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getAll", ReplyAction="http://tempuri.org/IService1/getAllResponse")]
        MonitorSystem.ServiceReference1.BasicDetails[] getAll();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : MonitorSystem.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<MonitorSystem.ServiceReference1.IService1>, MonitorSystem.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string InsertBasicDetails(MonitorSystem.ServiceReference1.BasicDetails BasicInfo) {
            return base.Channel.InsertBasicDetails(BasicInfo);
        }
        
        public string GetUpdatedBasic(MonitorSystem.ServiceReference1.BasicDetails BasicInfoEdit) {
            return base.Channel.GetUpdatedBasic(BasicInfoEdit);
        }
        
        public string DeleteBasicInfo(string BasicId) {
            return base.Channel.DeleteBasicInfo(BasicId);
        }
        
        public string getBasicInfoById(string Id) {
            return base.Channel.getBasicInfoById(Id);
        }
        
        public MonitorSystem.ServiceReference1.BasicDetails[] getAll() {
            return base.Channel.getAll();
        }
    }
}
