﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.269
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 4.0.60310.0
// 
namespace slAmidaConsole.WebService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WebService.WebServiceSoap")]
    public interface WebServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/RegisterSession", ReplyAction="*")]
        System.IAsyncResult BeginRegisterSession(slAmidaConsole.WebService.RegisterSessionRequest request, System.AsyncCallback callback, object asyncState);
        
        slAmidaConsole.WebService.RegisterSessionResponse EndRegisterSession(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IsUserLogin", ReplyAction="*")]
        System.IAsyncResult BeginIsUserLogin(slAmidaConsole.WebService.IsUserLoginRequest request, System.AsyncCallback callback, object asyncState);
        
        slAmidaConsole.WebService.IsUserLoginResponse EndIsUserLogin(System.IAsyncResult result);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class RegisterSessionRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="RegisterSession", Namespace="http://tempuri.org/", Order=0)]
        public slAmidaConsole.WebService.RegisterSessionRequestBody Body;
        
        public RegisterSessionRequest() {
        }
        
        public RegisterSessionRequest(slAmidaConsole.WebService.RegisterSessionRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class RegisterSessionRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string userid;
        
        public RegisterSessionRequestBody() {
        }
        
        public RegisterSessionRequestBody(string userid) {
            this.userid = userid;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class RegisterSessionResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="RegisterSessionResponse", Namespace="http://tempuri.org/", Order=0)]
        public slAmidaConsole.WebService.RegisterSessionResponseBody Body;
        
        public RegisterSessionResponse() {
        }
        
        public RegisterSessionResponse(slAmidaConsole.WebService.RegisterSessionResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class RegisterSessionResponseBody {
        
        public RegisterSessionResponseBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class IsUserLoginRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="IsUserLogin", Namespace="http://tempuri.org/", Order=0)]
        public slAmidaConsole.WebService.IsUserLoginRequestBody Body;
        
        public IsUserLoginRequest() {
        }
        
        public IsUserLoginRequest(slAmidaConsole.WebService.IsUserLoginRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class IsUserLoginRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string userid;
        
        public IsUserLoginRequestBody() {
        }
        
        public IsUserLoginRequestBody(string userid) {
            this.userid = userid;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class IsUserLoginResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="IsUserLoginResponse", Namespace="http://tempuri.org/", Order=0)]
        public slAmidaConsole.WebService.IsUserLoginResponseBody Body;
        
        public IsUserLoginResponse() {
        }
        
        public IsUserLoginResponse(slAmidaConsole.WebService.IsUserLoginResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class IsUserLoginResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool IsUserLoginResult;
        
        public IsUserLoginResponseBody() {
        }
        
        public IsUserLoginResponseBody(bool IsUserLoginResult) {
            this.IsUserLoginResult = IsUserLoginResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebServiceSoapChannel : slAmidaConsole.WebService.WebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IsUserLoginCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public IsUserLoginCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebServiceSoapClient : System.ServiceModel.ClientBase<slAmidaConsole.WebService.WebServiceSoap>, slAmidaConsole.WebService.WebServiceSoap {
        
        private BeginOperationDelegate onBeginRegisterSessionDelegate;
        
        private EndOperationDelegate onEndRegisterSessionDelegate;
        
        private System.Threading.SendOrPostCallback onRegisterSessionCompletedDelegate;
        
        private BeginOperationDelegate onBeginIsUserLoginDelegate;
        
        private EndOperationDelegate onEndIsUserLoginDelegate;
        
        private System.Threading.SendOrPostCallback onIsUserLoginCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public WebServiceSoapClient() {
        }
        
        public WebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("無法設定 CookieContainer。請確定繫結包含 HttpCookieContainerBindingElement。");
                }
            }
        }
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> RegisterSessionCompleted;
        
        public event System.EventHandler<IsUserLoginCompletedEventArgs> IsUserLoginCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult slAmidaConsole.WebService.WebServiceSoap.BeginRegisterSession(slAmidaConsole.WebService.RegisterSessionRequest request, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginRegisterSession(request, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private System.IAsyncResult BeginRegisterSession(string userid, System.AsyncCallback callback, object asyncState) {
            slAmidaConsole.WebService.RegisterSessionRequest inValue = new slAmidaConsole.WebService.RegisterSessionRequest();
            inValue.Body = new slAmidaConsole.WebService.RegisterSessionRequestBody();
            inValue.Body.userid = userid;
            return ((slAmidaConsole.WebService.WebServiceSoap)(this)).BeginRegisterSession(inValue, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        slAmidaConsole.WebService.RegisterSessionResponse slAmidaConsole.WebService.WebServiceSoap.EndRegisterSession(System.IAsyncResult result) {
            return base.Channel.EndRegisterSession(result);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private void EndRegisterSession(System.IAsyncResult result) {
            slAmidaConsole.WebService.RegisterSessionResponse retVal = ((slAmidaConsole.WebService.WebServiceSoap)(this)).EndRegisterSession(result);
        }
        
        private System.IAsyncResult OnBeginRegisterSession(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string userid = ((string)(inValues[0]));
            return this.BeginRegisterSession(userid, callback, asyncState);
        }
        
        private object[] OnEndRegisterSession(System.IAsyncResult result) {
            this.EndRegisterSession(result);
            return null;
        }
        
        private void OnRegisterSessionCompleted(object state) {
            if ((this.RegisterSessionCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.RegisterSessionCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void RegisterSessionAsync(string userid) {
            this.RegisterSessionAsync(userid, null);
        }
        
        public void RegisterSessionAsync(string userid, object userState) {
            if ((this.onBeginRegisterSessionDelegate == null)) {
                this.onBeginRegisterSessionDelegate = new BeginOperationDelegate(this.OnBeginRegisterSession);
            }
            if ((this.onEndRegisterSessionDelegate == null)) {
                this.onEndRegisterSessionDelegate = new EndOperationDelegate(this.OnEndRegisterSession);
            }
            if ((this.onRegisterSessionCompletedDelegate == null)) {
                this.onRegisterSessionCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnRegisterSessionCompleted);
            }
            base.InvokeAsync(this.onBeginRegisterSessionDelegate, new object[] {
                        userid}, this.onEndRegisterSessionDelegate, this.onRegisterSessionCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult slAmidaConsole.WebService.WebServiceSoap.BeginIsUserLogin(slAmidaConsole.WebService.IsUserLoginRequest request, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginIsUserLogin(request, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private System.IAsyncResult BeginIsUserLogin(string userid, System.AsyncCallback callback, object asyncState) {
            slAmidaConsole.WebService.IsUserLoginRequest inValue = new slAmidaConsole.WebService.IsUserLoginRequest();
            inValue.Body = new slAmidaConsole.WebService.IsUserLoginRequestBody();
            inValue.Body.userid = userid;
            return ((slAmidaConsole.WebService.WebServiceSoap)(this)).BeginIsUserLogin(inValue, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        slAmidaConsole.WebService.IsUserLoginResponse slAmidaConsole.WebService.WebServiceSoap.EndIsUserLogin(System.IAsyncResult result) {
            return base.Channel.EndIsUserLogin(result);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private bool EndIsUserLogin(System.IAsyncResult result) {
            slAmidaConsole.WebService.IsUserLoginResponse retVal = ((slAmidaConsole.WebService.WebServiceSoap)(this)).EndIsUserLogin(result);
            return retVal.Body.IsUserLoginResult;
        }
        
        private System.IAsyncResult OnBeginIsUserLogin(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string userid = ((string)(inValues[0]));
            return this.BeginIsUserLogin(userid, callback, asyncState);
        }
        
        private object[] OnEndIsUserLogin(System.IAsyncResult result) {
            bool retVal = this.EndIsUserLogin(result);
            return new object[] {
                    retVal};
        }
        
        private void OnIsUserLoginCompleted(object state) {
            if ((this.IsUserLoginCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.IsUserLoginCompleted(this, new IsUserLoginCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void IsUserLoginAsync(string userid) {
            this.IsUserLoginAsync(userid, null);
        }
        
        public void IsUserLoginAsync(string userid, object userState) {
            if ((this.onBeginIsUserLoginDelegate == null)) {
                this.onBeginIsUserLoginDelegate = new BeginOperationDelegate(this.OnBeginIsUserLogin);
            }
            if ((this.onEndIsUserLoginDelegate == null)) {
                this.onEndIsUserLoginDelegate = new EndOperationDelegate(this.OnEndIsUserLogin);
            }
            if ((this.onIsUserLoginCompletedDelegate == null)) {
                this.onIsUserLoginCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnIsUserLoginCompleted);
            }
            base.InvokeAsync(this.onBeginIsUserLoginDelegate, new object[] {
                        userid}, this.onEndIsUserLoginDelegate, this.onIsUserLoginCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override slAmidaConsole.WebService.WebServiceSoap CreateChannel() {
            return new WebServiceSoapClientChannel(this);
        }
        
        private class WebServiceSoapClientChannel : ChannelBase<slAmidaConsole.WebService.WebServiceSoap>, slAmidaConsole.WebService.WebServiceSoap {
            
            public WebServiceSoapClientChannel(System.ServiceModel.ClientBase<slAmidaConsole.WebService.WebServiceSoap> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginRegisterSession(slAmidaConsole.WebService.RegisterSessionRequest request, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = request;
                System.IAsyncResult _result = base.BeginInvoke("RegisterSession", _args, callback, asyncState);
                return _result;
            }
            
            public slAmidaConsole.WebService.RegisterSessionResponse EndRegisterSession(System.IAsyncResult result) {
                object[] _args = new object[0];
                slAmidaConsole.WebService.RegisterSessionResponse _result = ((slAmidaConsole.WebService.RegisterSessionResponse)(base.EndInvoke("RegisterSession", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginIsUserLogin(slAmidaConsole.WebService.IsUserLoginRequest request, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = request;
                System.IAsyncResult _result = base.BeginInvoke("IsUserLogin", _args, callback, asyncState);
                return _result;
            }
            
            public slAmidaConsole.WebService.IsUserLoginResponse EndIsUserLogin(System.IAsyncResult result) {
                object[] _args = new object[0];
                slAmidaConsole.WebService.IsUserLoginResponse _result = ((slAmidaConsole.WebService.IsUserLoginResponse)(base.EndInvoke("IsUserLogin", _args, result)));
                return _result;
            }
        }
    }
}