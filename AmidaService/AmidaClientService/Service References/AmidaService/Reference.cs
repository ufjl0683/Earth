﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.269
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AmidaClientService.AmidaService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RegisterDeviceInfo", Namespace="http://schemas.datacontract.org/2004/07/AmidaServerService")]
    [System.SerializableAttribute()]
    public partial class RegisterDeviceInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ConnectedTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CurrentWaferIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DeviceTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PcNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProbeCardIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double ProgressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime StatusBeginTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double TimeRemainField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime WarningBeginTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WarningMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int WarningTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string eq_areaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string eq_commentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string eq_proberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string eq_typeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string lot_idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int tested_num_chipField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int tested_num_waferField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int total_num_chipField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int total_num_waferField;
        
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
        public System.DateTime ConnectedTime {
            get {
                return this.ConnectedTimeField;
            }
            set {
                if ((this.ConnectedTimeField.Equals(value) != true)) {
                    this.ConnectedTimeField = value;
                    this.RaisePropertyChanged("ConnectedTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CurrentWaferId {
            get {
                return this.CurrentWaferIdField;
            }
            set {
                if ((object.ReferenceEquals(this.CurrentWaferIdField, value) != true)) {
                    this.CurrentWaferIdField = value;
                    this.RaisePropertyChanged("CurrentWaferId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DeviceType {
            get {
                return this.DeviceTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.DeviceTypeField, value) != true)) {
                    this.DeviceTypeField = value;
                    this.RaisePropertyChanged("DeviceType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PcName {
            get {
                return this.PcNameField;
            }
            set {
                if ((object.ReferenceEquals(this.PcNameField, value) != true)) {
                    this.PcNameField = value;
                    this.RaisePropertyChanged("PcName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProbeCardId {
            get {
                return this.ProbeCardIdField;
            }
            set {
                if ((object.ReferenceEquals(this.ProbeCardIdField, value) != true)) {
                    this.ProbeCardIdField = value;
                    this.RaisePropertyChanged("ProbeCardId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Progress {
            get {
                return this.ProgressField;
            }
            set {
                if ((this.ProgressField.Equals(value) != true)) {
                    this.ProgressField = value;
                    this.RaisePropertyChanged("Progress");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Status {
            get {
                return this.StatusField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusField, value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime StatusBeginTime {
            get {
                return this.StatusBeginTimeField;
            }
            set {
                if ((this.StatusBeginTimeField.Equals(value) != true)) {
                    this.StatusBeginTimeField = value;
                    this.RaisePropertyChanged("StatusBeginTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double TimeRemain {
            get {
                return this.TimeRemainField;
            }
            set {
                if ((this.TimeRemainField.Equals(value) != true)) {
                    this.TimeRemainField = value;
                    this.RaisePropertyChanged("TimeRemain");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime WarningBeginTime {
            get {
                return this.WarningBeginTimeField;
            }
            set {
                if ((this.WarningBeginTimeField.Equals(value) != true)) {
                    this.WarningBeginTimeField = value;
                    this.RaisePropertyChanged("WarningBeginTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string WarningMessage {
            get {
                return this.WarningMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.WarningMessageField, value) != true)) {
                    this.WarningMessageField = value;
                    this.RaisePropertyChanged("WarningMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int WarningType {
            get {
                return this.WarningTypeField;
            }
            set {
                if ((this.WarningTypeField.Equals(value) != true)) {
                    this.WarningTypeField = value;
                    this.RaisePropertyChanged("WarningType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string eq_area {
            get {
                return this.eq_areaField;
            }
            set {
                if ((object.ReferenceEquals(this.eq_areaField, value) != true)) {
                    this.eq_areaField = value;
                    this.RaisePropertyChanged("eq_area");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string eq_comment {
            get {
                return this.eq_commentField;
            }
            set {
                if ((object.ReferenceEquals(this.eq_commentField, value) != true)) {
                    this.eq_commentField = value;
                    this.RaisePropertyChanged("eq_comment");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string eq_prober {
            get {
                return this.eq_proberField;
            }
            set {
                if ((object.ReferenceEquals(this.eq_proberField, value) != true)) {
                    this.eq_proberField = value;
                    this.RaisePropertyChanged("eq_prober");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string eq_type {
            get {
                return this.eq_typeField;
            }
            set {
                if ((object.ReferenceEquals(this.eq_typeField, value) != true)) {
                    this.eq_typeField = value;
                    this.RaisePropertyChanged("eq_type");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string lot_id {
            get {
                return this.lot_idField;
            }
            set {
                if ((object.ReferenceEquals(this.lot_idField, value) != true)) {
                    this.lot_idField = value;
                    this.RaisePropertyChanged("lot_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int tested_num_chip {
            get {
                return this.tested_num_chipField;
            }
            set {
                if ((this.tested_num_chipField.Equals(value) != true)) {
                    this.tested_num_chipField = value;
                    this.RaisePropertyChanged("tested_num_chip");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int tested_num_wafer {
            get {
                return this.tested_num_waferField;
            }
            set {
                if ((this.tested_num_waferField.Equals(value) != true)) {
                    this.tested_num_waferField = value;
                    this.RaisePropertyChanged("tested_num_wafer");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int total_num_chip {
            get {
                return this.total_num_chipField;
            }
            set {
                if ((this.total_num_chipField.Equals(value) != true)) {
                    this.total_num_chipField = value;
                    this.RaisePropertyChanged("total_num_chip");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int total_num_wafer {
            get {
                return this.total_num_waferField;
            }
            set {
                if ((this.total_num_waferField.Equals(value) != true)) {
                    this.total_num_waferField = value;
                    this.RaisePropertyChanged("total_num_wafer");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="InportCmdType", Namespace="http://schemas.datacontract.org/2004/07/AmidaServerService")]
    public enum InportCmdType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        InportFile = 0,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AmidaService.IAmidaService", CallbackContract=typeof(AmidaClientService.AmidaService.IAmidaServiceCallback))]
    public interface IAmidaService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAmidaService/GetData", ReplyAction="http://tempuri.org/IAmidaService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAmidaService/Register", ReplyAction="http://tempuri.org/IAmidaService/RegisterResponse")]
        void Register(string key, string DeviceType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAmidaService/SayServerHello", ReplyAction="http://tempuri.org/IAmidaService/SayServerHelloResponse")]
        void SayServerHello();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAmidaService/GetAllConnectionInfo", ReplyAction="http://tempuri.org/IAmidaService/GetAllConnectionInfoResponse")]
        AmidaClientService.AmidaService.RegisterDeviceInfo[] GetAllConnectionInfo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAmidaService/ExportCommand", ReplyAction="http://tempuri.org/IAmidaService/ExportCommandResponse")]
        void ExportCommand(string PCName, string CmdType, string xml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAmidaService/Down", ReplyAction="http://tempuri.org/IAmidaService/DownResponse")]
        void Down(string PCName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAmidaService/Release", ReplyAction="http://tempuri.org/IAmidaService/ReleaseResponse")]
        void Release(string PCName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAmidaServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAmidaService/ReceivedCommand")]
        void ReceivedCommand(string xmlCmd, AmidaClientService.AmidaService.InportCmdType cmdType, string LeadingFileName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAmidaService/SayHello")]
        void SayHello(string hello);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAmidaService/NotifyConnectionChanged")]
        void NotifyConnectionChanged();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAmidaService/NotifyStatusChanged")]
        void NotifyStatusChanged(string pcname, AmidaClientService.AmidaService.RegisterDeviceInfo info);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAmidaService/NotifyClientExported")]
        void NotifyClientExported(string PCName, string CmdType);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAmidaServiceChannel : AmidaClientService.AmidaService.IAmidaService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AmidaServiceClient : System.ServiceModel.DuplexClientBase<AmidaClientService.AmidaService.IAmidaService>, AmidaClientService.AmidaService.IAmidaService {
        
        public AmidaServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public AmidaServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public AmidaServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public AmidaServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public AmidaServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public void Register(string key, string DeviceType) {
            base.Channel.Register(key, DeviceType);
        }
        
        public void SayServerHello() {
            base.Channel.SayServerHello();
        }
        
        public AmidaClientService.AmidaService.RegisterDeviceInfo[] GetAllConnectionInfo() {
            return base.Channel.GetAllConnectionInfo();
        }
        
        public void ExportCommand(string PCName, string CmdType, string xml) {
            base.Channel.ExportCommand(PCName, CmdType, xml);
        }
        
        public void Down(string PCName) {
            base.Channel.Down(PCName);
        }
        
        public void Release(string PCName) {
            base.Channel.Release(PCName);
        }
    }
}
