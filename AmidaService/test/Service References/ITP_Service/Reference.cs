﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace test.ITP_Service {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://winfoundry.com/", ConfigurationName="ITP_Service.Service1Soap")]
    public interface Service1Soap {
        
        // CODEGEN: 命名空間 http://winfoundry.com/ 的元素名稱  HelloWorldResult 未標示為 nillable，正在產生訊息合約
        [System.ServiceModel.OperationContractAttribute(Action="http://winfoundry.com/HelloWorld", ReplyAction="*")]
        test.ITP_Service.HelloWorldResponse HelloWorld(test.ITP_Service.HelloWorldRequest request);
        
        // CODEGEN: 命名空間 http://winfoundry.com/ 的元素名稱  Para 未標示為 nillable，正在產生訊息合約
        [System.ServiceModel.OperationContractAttribute(Action="http://winfoundry.com/ITP_WebService", ReplyAction="*")]
        test.ITP_Service.ITP_WebServiceResponse ITP_WebService(test.ITP_Service.ITP_WebServiceRequest request);
        
        // CODEGEN: 命名空間 http://winfoundry.com/ 的元素名稱  isTakeOver 未標示為 nillable，正在產生訊息合約
        [System.ServiceModel.OperationContractAttribute(Action="http://winfoundry.com/CheckService", ReplyAction="*")]
        test.ITP_Service.CheckServiceResponse CheckService(test.ITP_Service.CheckServiceRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://winfoundry.com/", Order=0)]
        public test.ITP_Service.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(test.ITP_Service.HelloWorldRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class HelloWorldRequestBody {
        
        public HelloWorldRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorldResponse", Namespace="http://winfoundry.com/", Order=0)]
        public test.ITP_Service.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(test.ITP_Service.HelloWorldResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://winfoundry.com/")]
    public partial class HelloWorldResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HelloWorldResult;
        
        public HelloWorldResponseBody() {
        }
        
        public HelloWorldResponseBody(string HelloWorldResult) {
            this.HelloWorldResult = HelloWorldResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ITP_WebServiceRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ITP_WebService", Namespace="http://winfoundry.com/", Order=0)]
        public test.ITP_Service.ITP_WebServiceRequestBody Body;
        
        public ITP_WebServiceRequest() {
        }
        
        public ITP_WebServiceRequest(test.ITP_Service.ITP_WebServiceRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://winfoundry.com/")]
    public partial class ITP_WebServiceRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string Para;
        
        public ITP_WebServiceRequestBody() {
        }
        
        public ITP_WebServiceRequestBody(string Para) {
            this.Para = Para;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ITP_WebServiceResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ITP_WebServiceResponse", Namespace="http://winfoundry.com/", Order=0)]
        public test.ITP_Service.ITP_WebServiceResponseBody Body;
        
        public ITP_WebServiceResponse() {
        }
        
        public ITP_WebServiceResponse(test.ITP_Service.ITP_WebServiceResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://winfoundry.com/")]
    public partial class ITP_WebServiceResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string ITP_WebServiceResult;
        
        public ITP_WebServiceResponseBody() {
        }
        
        public ITP_WebServiceResponseBody(string ITP_WebServiceResult) {
            this.ITP_WebServiceResult = ITP_WebServiceResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CheckServiceRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CheckService", Namespace="http://winfoundry.com/", Order=0)]
        public test.ITP_Service.CheckServiceRequestBody Body;
        
        public CheckServiceRequest() {
        }
        
        public CheckServiceRequest(test.ITP_Service.CheckServiceRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://winfoundry.com/")]
    public partial class CheckServiceRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string isTakeOver;
        
        public CheckServiceRequestBody() {
        }
        
        public CheckServiceRequestBody(string isTakeOver) {
            this.isTakeOver = isTakeOver;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CheckServiceResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CheckServiceResponse", Namespace="http://winfoundry.com/", Order=0)]
        public test.ITP_Service.CheckServiceResponseBody Body;
        
        public CheckServiceResponse() {
        }
        
        public CheckServiceResponse(test.ITP_Service.CheckServiceResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://winfoundry.com/")]
    public partial class CheckServiceResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string CheckServiceResult;
        
        public CheckServiceResponseBody() {
        }
        
        public CheckServiceResponseBody(string CheckServiceResult) {
            this.CheckServiceResult = CheckServiceResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface Service1SoapChannel : test.ITP_Service.Service1Soap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1SoapClient : System.ServiceModel.ClientBase<test.ITP_Service.Service1Soap>, test.ITP_Service.Service1Soap {
        
        public Service1SoapClient() {
        }
        
        public Service1SoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1SoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1SoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        test.ITP_Service.HelloWorldResponse test.ITP_Service.Service1Soap.HelloWorld(test.ITP_Service.HelloWorldRequest request) {
            return base.Channel.HelloWorld(request);
        }
        
        public string HelloWorld() {
            test.ITP_Service.HelloWorldRequest inValue = new test.ITP_Service.HelloWorldRequest();
            inValue.Body = new test.ITP_Service.HelloWorldRequestBody();
            test.ITP_Service.HelloWorldResponse retVal = ((test.ITP_Service.Service1Soap)(this)).HelloWorld(inValue);
            return retVal.Body.HelloWorldResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        test.ITP_Service.ITP_WebServiceResponse test.ITP_Service.Service1Soap.ITP_WebService(test.ITP_Service.ITP_WebServiceRequest request) {
            return base.Channel.ITP_WebService(request);
        }
        
        public string ITP_WebService(string Para) {
            test.ITP_Service.ITP_WebServiceRequest inValue = new test.ITP_Service.ITP_WebServiceRequest();
            inValue.Body = new test.ITP_Service.ITP_WebServiceRequestBody();
            inValue.Body.Para = Para;
            test.ITP_Service.ITP_WebServiceResponse retVal = ((test.ITP_Service.Service1Soap)(this)).ITP_WebService(inValue);
            return retVal.Body.ITP_WebServiceResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        test.ITP_Service.CheckServiceResponse test.ITP_Service.Service1Soap.CheckService(test.ITP_Service.CheckServiceRequest request) {
            return base.Channel.CheckService(request);
        }
        
        public string CheckService(string isTakeOver) {
            test.ITP_Service.CheckServiceRequest inValue = new test.ITP_Service.CheckServiceRequest();
            inValue.Body = new test.ITP_Service.CheckServiceRequestBody();
            inValue.Body.isTakeOver = isTakeOver;
            test.ITP_Service.CheckServiceResponse retVal = ((test.ITP_Service.Service1Soap)(this)).CheckService(inValue);
            return retVal.Body.CheckServiceResult;
        }
    }
}