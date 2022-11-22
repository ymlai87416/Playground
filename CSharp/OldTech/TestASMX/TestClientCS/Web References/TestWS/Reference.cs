﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace TestClientCS.TestWS {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WebService1Soap", Namespace="http://tempuri.org/")]
    public partial class WebService1 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private WSHeader wSHeaderValueField;
        
        private System.Threading.SendOrPostCallback HelloWorldOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddOperationCompleted;
        
        private System.Threading.SendOrPostCallback Add2OperationCompleted;
        
        private System.Threading.SendOrPostCallback GetRecordOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetRecord2OperationCompleted;
        
        private System.Threading.SendOrPostCallback SearchDocumentFromAllCMOperationCompleted;
        
        private System.Threading.SendOrPostCallback DownloadDocumentOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WebService1() {
            this.Url = global::TestClientCS.Properties.Settings.Default.TestClientCS_TestWS_WebService1;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public WSHeader WSHeaderValue {
            get {
                return this.wSHeaderValueField;
            }
            set {
                this.wSHeaderValueField = value;
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
        public event HelloWorldCompletedEventHandler HelloWorldCompleted;
        
        /// <remarks/>
        public event AddCompletedEventHandler AddCompleted;
        
        /// <remarks/>
        public event Add2CompletedEventHandler Add2Completed;
        
        /// <remarks/>
        public event GetRecordCompletedEventHandler GetRecordCompleted;
        
        /// <remarks/>
        public event GetRecord2CompletedEventHandler GetRecord2Completed;
        
        /// <remarks/>
        public event SearchDocumentFromAllCMCompletedEventHandler SearchDocumentFromAllCMCompleted;
        
        /// <remarks/>
        public event DownloadDocumentCompletedEventHandler DownloadDocumentCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("WSHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/HelloWorld", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld() {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void HelloWorldAsync() {
            this.HelloWorldAsync(null);
        }
        
        /// <remarks/>
        public void HelloWorldAsync(object userState) {
            if ((this.HelloWorldOperationCompleted == null)) {
                this.HelloWorldOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHelloWorldOperationCompleted);
            }
            this.InvokeAsync("HelloWorld", new object[0], this.HelloWorldOperationCompleted, userState);
        }
        
        private void OnHelloWorldOperationCompleted(object arg) {
            if ((this.HelloWorldCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HelloWorldCompleted(this, new HelloWorldCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Add", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int Add(int a, int b) {
            object[] results = this.Invoke("Add", new object[] {
                        a,
                        b});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void AddAsync(int a, int b) {
            this.AddAsync(a, b, null);
        }
        
        /// <remarks/>
        public void AddAsync(int a, int b, object userState) {
            if ((this.AddOperationCompleted == null)) {
                this.AddOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddOperationCompleted);
            }
            this.InvokeAsync("Add", new object[] {
                        a,
                        b}, this.AddOperationCompleted, userState);
        }
        
        private void OnAddOperationCompleted(object arg) {
            if ((this.AddCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddCompleted(this, new AddCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Add2", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool Add2(int a, int b, ref int result) {
            object[] results = this.Invoke("Add2", new object[] {
                        a,
                        b,
                        result});
            result = ((int)(results[1]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void Add2Async(int a, int b, int result) {
            this.Add2Async(a, b, result, null);
        }
        
        /// <remarks/>
        public void Add2Async(int a, int b, int result, object userState) {
            if ((this.Add2OperationCompleted == null)) {
                this.Add2OperationCompleted = new System.Threading.SendOrPostCallback(this.OnAdd2OperationCompleted);
            }
            this.InvokeAsync("Add2", new object[] {
                        a,
                        b,
                        result}, this.Add2OperationCompleted, userState);
        }
        
        private void OnAdd2OperationCompleted(object arg) {
            if ((this.Add2Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Add2Completed(this, new Add2CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetRecord", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool GetRecord(string input, ref System.Data.DataTable output) {
            object[] results = this.Invoke("GetRecord", new object[] {
                        input,
                        output});
            output = ((System.Data.DataTable)(results[1]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void GetRecordAsync(string input, System.Data.DataTable output) {
            this.GetRecordAsync(input, output, null);
        }
        
        /// <remarks/>
        public void GetRecordAsync(string input, System.Data.DataTable output, object userState) {
            if ((this.GetRecordOperationCompleted == null)) {
                this.GetRecordOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetRecordOperationCompleted);
            }
            this.InvokeAsync("GetRecord", new object[] {
                        input,
                        output}, this.GetRecordOperationCompleted, userState);
        }
        
        private void OnGetRecordOperationCompleted(object arg) {
            if ((this.GetRecordCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetRecordCompleted(this, new GetRecordCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetRecord2", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable GetRecord2(string input) {
            object[] results = this.Invoke("GetRecord2", new object[] {
                        input});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void GetRecord2Async(string input) {
            this.GetRecord2Async(input, null);
        }
        
        /// <remarks/>
        public void GetRecord2Async(string input, object userState) {
            if ((this.GetRecord2OperationCompleted == null)) {
                this.GetRecord2OperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetRecord2OperationCompleted);
            }
            this.InvokeAsync("GetRecord2", new object[] {
                        input}, this.GetRecord2OperationCompleted, userState);
        }
        
        private void OnGetRecord2OperationCompleted(object arg) {
            if ((this.GetRecord2Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetRecord2Completed(this, new GetRecord2CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("WSHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SearchDocumentFromAllCM", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool SearchDocumentFromAllCM(string[] fields, string[] values, ref System.Data.DataSet docs, ref string err) {
            object[] results = this.Invoke("SearchDocumentFromAllCM", new object[] {
                        fields,
                        values,
                        docs,
                        err});
            docs = ((System.Data.DataSet)(results[1]));
            err = ((string)(results[2]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void SearchDocumentFromAllCMAsync(string[] fields, string[] values, System.Data.DataSet docs, string err) {
            this.SearchDocumentFromAllCMAsync(fields, values, docs, err, null);
        }
        
        /// <remarks/>
        public void SearchDocumentFromAllCMAsync(string[] fields, string[] values, System.Data.DataSet docs, string err, object userState) {
            if ((this.SearchDocumentFromAllCMOperationCompleted == null)) {
                this.SearchDocumentFromAllCMOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSearchDocumentFromAllCMOperationCompleted);
            }
            this.InvokeAsync("SearchDocumentFromAllCM", new object[] {
                        fields,
                        values,
                        docs,
                        err}, this.SearchDocumentFromAllCMOperationCompleted, userState);
        }
        
        private void OnSearchDocumentFromAllCMOperationCompleted(object arg) {
            if ((this.SearchDocumentFromAllCMCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SearchDocumentFromAllCMCompleted(this, new SearchDocumentFromAllCMCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("WSHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/DownloadDocument", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool DownloadDocument(string index, ref string err, [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")] ref byte[] imgData) {
            object[] results = this.Invoke("DownloadDocument", new object[] {
                        index,
                        err,
                        imgData});
            err = ((string)(results[1]));
            imgData = ((byte[])(results[2]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void DownloadDocumentAsync(string index, string err, byte[] imgData) {
            this.DownloadDocumentAsync(index, err, imgData, null);
        }
        
        /// <remarks/>
        public void DownloadDocumentAsync(string index, string err, byte[] imgData, object userState) {
            if ((this.DownloadDocumentOperationCompleted == null)) {
                this.DownloadDocumentOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDownloadDocumentOperationCompleted);
            }
            this.InvokeAsync("DownloadDocument", new object[] {
                        index,
                        err,
                        imgData}, this.DownloadDocumentOperationCompleted, userState);
        }
        
        private void OnDownloadDocumentOperationCompleted(object arg) {
            if ((this.DownloadDocumentCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DownloadDocumentCompleted(this, new DownloadDocumentCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/", IsNullable=false)]
    public partial class WSHeader : System.Web.Services.Protocols.SoapHeader {
        
        private string userIdField;
        
        private string userPasswordField;
        
        private string serverField;
        
        private int timeoutField;
        
        private string companyInUseField;
        
        private string environmentInUseField;
        
        private string projectField;
        
        private string userTypeField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        public string UserId {
            get {
                return this.userIdField;
            }
            set {
                this.userIdField = value;
            }
        }
        
        /// <remarks/>
        public string UserPassword {
            get {
                return this.userPasswordField;
            }
            set {
                this.userPasswordField = value;
            }
        }
        
        /// <remarks/>
        public string Server {
            get {
                return this.serverField;
            }
            set {
                this.serverField = value;
            }
        }
        
        /// <remarks/>
        public int Timeout {
            get {
                return this.timeoutField;
            }
            set {
                this.timeoutField = value;
            }
        }
        
        /// <remarks/>
        public string CompanyInUse {
            get {
                return this.companyInUseField;
            }
            set {
                this.companyInUseField = value;
            }
        }
        
        /// <remarks/>
        public string EnvironmentInUse {
            get {
                return this.environmentInUseField;
            }
            set {
                this.environmentInUseField = value;
            }
        }
        
        /// <remarks/>
        public string Project {
            get {
                return this.projectField;
            }
            set {
                this.projectField = value;
            }
        }
        
        /// <remarks/>
        public string UserType {
            get {
                return this.userTypeField;
            }
            set {
                this.userTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr {
            get {
                return this.anyAttrField;
            }
            set {
                this.anyAttrField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void HelloWorldCompletedEventHandler(object sender, HelloWorldCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HelloWorldCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HelloWorldCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void AddCompletedEventHandler(object sender, AddCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AddCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AddCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void Add2CompletedEventHandler(object sender, Add2CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Add2CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Add2CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
        
        /// <remarks/>
        public int result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void GetRecordCompletedEventHandler(object sender, GetRecordCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetRecordCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetRecordCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
        
        /// <remarks/>
        public System.Data.DataTable output {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void GetRecord2CompletedEventHandler(object sender, GetRecord2CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetRecord2CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetRecord2CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void SearchDocumentFromAllCMCompletedEventHandler(object sender, SearchDocumentFromAllCMCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SearchDocumentFromAllCMCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SearchDocumentFromAllCMCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
        
        /// <remarks/>
        public System.Data.DataSet docs {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[1]));
            }
        }
        
        /// <remarks/>
        public string err {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[2]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void DownloadDocumentCompletedEventHandler(object sender, DownloadDocumentCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DownloadDocumentCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DownloadDocumentCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
        
        /// <remarks/>
        public string err {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
        
        /// <remarks/>
        public byte[] imgData {
            get {
                this.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[2]));
            }
        }
    }
}

#pragma warning restore 1591