﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.42000 版自动生成。
// 
#pragma warning disable 1591

namespace MyWeChatService.WebReference {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="Service1Soap", Namespace="http://tempuri.org/")]
    public partial class Service1 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback CheckRockeyOperationCompleted;
        
        private System.Threading.SendOrPostCallback AutoCompleteOperationCompleted;
        
        private System.Threading.SendOrPostCallback LoginCheckOperationCompleted;
        
        private System.Threading.SendOrPostCallback ZJRFCheckOperationCompleted;
        
        private System.Threading.SendOrPostCallback ZJRFCheckAccordContractNoOperationCompleted;
        
        private System.Threading.SendOrPostCallback DstringOperationCompleted;
        
        private System.Threading.SendOrPostCallback EstringOperationCompleted;
        
        private System.Threading.SendOrPostCallback QueryContractOperationCompleted;
        
        private System.Threading.SendOrPostCallback JXRFCheckOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Service1() {
            this.Url = global::MyWeChatService.Properties.Settings.Default.MyWeChatService_WebReference_Service1;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event CheckRockeyCompletedEventHandler CheckRockeyCompleted;
        
        /// <remarks/>
        public event AutoCompleteCompletedEventHandler AutoCompleteCompleted;
        
        /// <remarks/>
        public event LoginCheckCompletedEventHandler LoginCheckCompleted;
        
        /// <remarks/>
        public event ZJRFCheckCompletedEventHandler ZJRFCheckCompleted;
        
        /// <remarks/>
        public event ZJRFCheckAccordContractNoCompletedEventHandler ZJRFCheckAccordContractNoCompleted;
        
        /// <remarks/>
        public event DstringCompletedEventHandler DstringCompleted;
        
        /// <remarks/>
        public event EstringCompletedEventHandler EstringCompleted;
        
        /// <remarks/>
        public event QueryContractCompletedEventHandler QueryContractCompleted;
        
        /// <remarks/>
        public event JXRFCheckCompletedEventHandler JXRFCheckCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CheckRockey", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool CheckRockey() {
            object[] results = this.Invoke("CheckRockey", new object[0]);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void CheckRockeyAsync() {
            this.CheckRockeyAsync(null);
        }
        
        /// <remarks/>
        public void CheckRockeyAsync(object userState) {
            if ((this.CheckRockeyOperationCompleted == null)) {
                this.CheckRockeyOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCheckRockeyOperationCompleted);
            }
            this.InvokeAsync("CheckRockey", new object[0], this.CheckRockeyOperationCompleted, userState);
        }
        
        private void OnCheckRockeyOperationCompleted(object arg) {
            if ((this.CheckRockeyCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CheckRockeyCompleted(this, new CheckRockeyCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AutoComplete", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string AutoComplete() {
            object[] results = this.Invoke("AutoComplete", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void AutoCompleteAsync() {
            this.AutoCompleteAsync(null);
        }
        
        /// <remarks/>
        public void AutoCompleteAsync(object userState) {
            if ((this.AutoCompleteOperationCompleted == null)) {
                this.AutoCompleteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAutoCompleteOperationCompleted);
            }
            this.InvokeAsync("AutoComplete", new object[0], this.AutoCompleteOperationCompleted, userState);
        }
        
        private void OnAutoCompleteOperationCompleted(object arg) {
            if ((this.AutoCompleteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AutoCompleteCompleted(this, new AutoCompleteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/LoginCheck", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string LoginCheck(string username, string password) {
            object[] results = this.Invoke("LoginCheck", new object[] {
                        username,
                        password});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void LoginCheckAsync(string username, string password) {
            this.LoginCheckAsync(username, password, null);
        }
        
        /// <remarks/>
        public void LoginCheckAsync(string username, string password, object userState) {
            if ((this.LoginCheckOperationCompleted == null)) {
                this.LoginCheckOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLoginCheckOperationCompleted);
            }
            this.InvokeAsync("LoginCheck", new object[] {
                        username,
                        password}, this.LoginCheckOperationCompleted, userState);
        }
        
        private void OnLoginCheckOperationCompleted(object arg) {
            if ((this.LoginCheckCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LoginCheckCompleted(this, new LoginCheckCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ZJRFCheck", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ZJRFCheck(string equpmentCode) {
            object[] results = this.Invoke("ZJRFCheck", new object[] {
                        equpmentCode});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ZJRFCheckAsync(string equpmentCode) {
            this.ZJRFCheckAsync(equpmentCode, null);
        }
        
        /// <remarks/>
        public void ZJRFCheckAsync(string equpmentCode, object userState) {
            if ((this.ZJRFCheckOperationCompleted == null)) {
                this.ZJRFCheckOperationCompleted = new System.Threading.SendOrPostCallback(this.OnZJRFCheckOperationCompleted);
            }
            this.InvokeAsync("ZJRFCheck", new object[] {
                        equpmentCode}, this.ZJRFCheckOperationCompleted, userState);
        }
        
        private void OnZJRFCheckOperationCompleted(object arg) {
            if ((this.ZJRFCheckCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ZJRFCheckCompleted(this, new ZJRFCheckCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ZJRFCheckAccordContractNo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ZJRFCheckAccordContractNo(string contractBianHao) {
            object[] results = this.Invoke("ZJRFCheckAccordContractNo", new object[] {
                        contractBianHao});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ZJRFCheckAccordContractNoAsync(string contractBianHao) {
            this.ZJRFCheckAccordContractNoAsync(contractBianHao, null);
        }
        
        /// <remarks/>
        public void ZJRFCheckAccordContractNoAsync(string contractBianHao, object userState) {
            if ((this.ZJRFCheckAccordContractNoOperationCompleted == null)) {
                this.ZJRFCheckAccordContractNoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnZJRFCheckAccordContractNoOperationCompleted);
            }
            this.InvokeAsync("ZJRFCheckAccordContractNo", new object[] {
                        contractBianHao}, this.ZJRFCheckAccordContractNoOperationCompleted, userState);
        }
        
        private void OnZJRFCheckAccordContractNoOperationCompleted(object arg) {
            if ((this.ZJRFCheckAccordContractNoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ZJRFCheckAccordContractNoCompleted(this, new ZJRFCheckAccordContractNoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Dstring", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Dstring(string s) {
            object[] results = this.Invoke("Dstring", new object[] {
                        s});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void DstringAsync(string s) {
            this.DstringAsync(s, null);
        }
        
        /// <remarks/>
        public void DstringAsync(string s, object userState) {
            if ((this.DstringOperationCompleted == null)) {
                this.DstringOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDstringOperationCompleted);
            }
            this.InvokeAsync("Dstring", new object[] {
                        s}, this.DstringOperationCompleted, userState);
        }
        
        private void OnDstringOperationCompleted(object arg) {
            if ((this.DstringCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DstringCompleted(this, new DstringCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Estring", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Estring(string s) {
            object[] results = this.Invoke("Estring", new object[] {
                        s});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void EstringAsync(string s) {
            this.EstringAsync(s, null);
        }
        
        /// <remarks/>
        public void EstringAsync(string s, object userState) {
            if ((this.EstringOperationCompleted == null)) {
                this.EstringOperationCompleted = new System.Threading.SendOrPostCallback(this.OnEstringOperationCompleted);
            }
            this.InvokeAsync("Estring", new object[] {
                        s}, this.EstringOperationCompleted, userState);
        }
        
        private void OnEstringOperationCompleted(object arg) {
            if ((this.EstringCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.EstringCompleted(this, new EstringCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/QueryContract", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string QueryContract(string pwd, string contractNo) {
            object[] results = this.Invoke("QueryContract", new object[] {
                        pwd,
                        contractNo});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void QueryContractAsync(string pwd, string contractNo) {
            this.QueryContractAsync(pwd, contractNo, null);
        }
        
        /// <remarks/>
        public void QueryContractAsync(string pwd, string contractNo, object userState) {
            if ((this.QueryContractOperationCompleted == null)) {
                this.QueryContractOperationCompleted = new System.Threading.SendOrPostCallback(this.OnQueryContractOperationCompleted);
            }
            this.InvokeAsync("QueryContract", new object[] {
                        pwd,
                        contractNo}, this.QueryContractOperationCompleted, userState);
        }
        
        private void OnQueryContractOperationCompleted(object arg) {
            if ((this.QueryContractCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.QueryContractCompleted(this, new QueryContractCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/JXRFCheck", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string JXRFCheck(string equpmentCode) {
            object[] results = this.Invoke("JXRFCheck", new object[] {
                        equpmentCode});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void JXRFCheckAsync(string equpmentCode) {
            this.JXRFCheckAsync(equpmentCode, null);
        }
        
        /// <remarks/>
        public void JXRFCheckAsync(string equpmentCode, object userState) {
            if ((this.JXRFCheckOperationCompleted == null)) {
                this.JXRFCheckOperationCompleted = new System.Threading.SendOrPostCallback(this.OnJXRFCheckOperationCompleted);
            }
            this.InvokeAsync("JXRFCheck", new object[] {
                        equpmentCode}, this.JXRFCheckOperationCompleted, userState);
        }
        
        private void OnJXRFCheckOperationCompleted(object arg) {
            if ((this.JXRFCheckCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.JXRFCheckCompleted(this, new JXRFCheckCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void CheckRockeyCompletedEventHandler(object sender, CheckRockeyCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CheckRockeyCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CheckRockeyCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void AutoCompleteCompletedEventHandler(object sender, AutoCompleteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AutoCompleteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AutoCompleteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void LoginCheckCompletedEventHandler(object sender, LoginCheckCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LoginCheckCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LoginCheckCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void ZJRFCheckCompletedEventHandler(object sender, ZJRFCheckCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ZJRFCheckCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ZJRFCheckCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void ZJRFCheckAccordContractNoCompletedEventHandler(object sender, ZJRFCheckAccordContractNoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ZJRFCheckAccordContractNoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ZJRFCheckAccordContractNoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void DstringCompletedEventHandler(object sender, DstringCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DstringCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DstringCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void EstringCompletedEventHandler(object sender, EstringCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class EstringCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal EstringCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void QueryContractCompletedEventHandler(object sender, QueryContractCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class QueryContractCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal QueryContractCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void JXRFCheckCompletedEventHandler(object sender, JXRFCheckCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class JXRFCheckCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal JXRFCheckCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591