﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.2500
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// このソース コードは Microsoft.VSDesigner、バージョン 1.1.4322.2500 によって自動生成されました。
// 
namespace IS2Client.is2init {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="Service1Soap", Namespace="http://Walkthrough/XmlWebServices/")]
    public class Service1 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public Service1() {
            string urlSetting = System.Configuration.ConfigurationSettings.AppSettings["IS2Client.is2init.Service1"];
            if ((urlSetting != null)) {
                this.Url = string.Concat(urlSetting, "");
            }
            else {
                this.Url = "http://wwwis2.fukutsu.co.jp/is2/is2init/Service1.asmx";
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Set_tanmatsu", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Set_tanmatsu(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("Set_tanmatsu", new object[] {
                        sUser,
                        sKey});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginSet_tanmatsu(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Set_tanmatsu", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndSet_tanmatsu(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Upd_tanmatsu", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Upd_tanmatsu(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("Upd_tanmatsu", new object[] {
                        sUser,
                        sKey});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUpd_tanmatsu(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Upd_tanmatsu", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndUpd_tanmatsu(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Upd_riyou", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Upd_riyou(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("Upd_riyou", new object[] {
                        sUser,
                        sKey});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUpd_riyou(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Upd_riyou", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndUpd_riyou(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_tanmatsu2", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Get_tanmatsu2(string[] sUser, string sKey1) {
            object[] results = this.Invoke("Get_tanmatsu2", new object[] {
                        sUser,
                        sKey1});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_tanmatsu2(string[] sUser, string sKey1, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_tanmatsu2", new object[] {
                        sUser,
                        sKey1}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGet_tanmatsu2(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_tanmatsu3", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Get_tanmatsu3(string[] sUser, string[] sKey1) {
            object[] results = this.Invoke("Get_tanmatsu3", new object[] {
                        sUser,
                        sKey1});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_tanmatsu3(string[] sUser, string[] sKey1, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_tanmatsu3", new object[] {
                        sUser,
                        sKey1}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGet_tanmatsu3(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_riyou", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Get_riyou(string[] sUser, string sKey1, string sKey2) {
            object[] results = this.Invoke("Get_riyou", new object[] {
                        sUser,
                        sKey1,
                        sKey2});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_riyou(string[] sUser, string sKey1, string sKey2, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_riyou", new object[] {
                        sUser,
                        sKey1,
                        sKey2}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGet_riyou(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_seikyu", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Get_seikyu(string[] sUser, string sKey1, string sKey2) {
            object[] results = this.Invoke("Get_seikyu", new object[] {
                        sUser,
                        sKey1,
                        sKey2});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_seikyu(string[] sUser, string sKey1, string sKey2, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_seikyu", new object[] {
                        sUser,
                        sKey1,
                        sKey2}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGet_seikyu(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/login", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] login(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("login", new object[] {
                        sUser,
                        sKey});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult Beginlogin(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("login", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] Endlogin(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_jyotai", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Get_jyotai(string[] sUser) {
            object[] results = this.Invoke("Get_jyotai", new object[] {
                        sUser});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_jyotai(string[] sUser, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_jyotai", new object[] {
                        sUser}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGet_jyotai(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_syukabi", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Get_syukabi(string[] sUser, string sKey1, string sKey2) {
            object[] results = this.Invoke("Get_syukabi", new object[] {
                        sUser,
                        sKey1,
                        sKey2});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_syukabi(string[] sUser, string sKey1, string sKey2, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_syukabi", new object[] {
                        sUser,
                        sKey1,
                        sKey2}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGet_syukabi(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_bumon", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Get_bumon(string[] sUser, string sKey1) {
            object[] results = this.Invoke("Get_bumon", new object[] {
                        sUser,
                        sKey1});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_bumon(string[] sUser, string sKey1, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_bumon", new object[] {
                        sUser,
                        sKey1}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGet_bumon(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_message", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Get_message(string[] sUser, string sKey1, string sKey2) {
            object[] results = this.Invoke("Get_message", new object[] {
                        sUser,
                        sKey1,
                        sKey2});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_message(string[] sUser, string sKey1, string sKey2, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_message", new object[] {
                        sUser,
                        sKey1,
                        sKey2}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGet_message(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_seigyo", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Get_seigyo(string[] sUser, string sKey1, string sKey2) {
            object[] results = this.Invoke("Get_seigyo", new object[] {
                        sUser,
                        sKey1,
                        sKey2});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_seigyo(string[] sUser, string sKey1, string sKey2, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_seigyo", new object[] {
                        sUser,
                        sKey1,
                        sKey2}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGet_seigyo(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_seigyo2", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Get_seigyo2(string[] sUser, string sKey1, string sKey2, int iLength) {
            object[] results = this.Invoke("Get_seigyo2", new object[] {
                        sUser,
                        sKey1,
                        sKey2,
                        iLength});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_seigyo2(string[] sUser, string sKey1, string sKey2, int iLength, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_seigyo2", new object[] {
                        sUser,
                        sKey1,
                        sKey2,
                        iLength}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGet_seigyo2(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_seigyo3", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Get_seigyo3(string[] sUser, string sKey1, string sKey2) {
            object[] results = this.Invoke("Get_seigyo3", new object[] {
                        sUser,
                        sKey1,
                        sKey2});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_seigyo3(string[] sUser, string sKey1, string sKey2, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_seigyo3", new object[] {
                        sUser,
                        sKey1,
                        sKey2}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGet_seigyo3(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Ins_seigyo", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Ins_seigyo(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("Ins_seigyo", new object[] {
                        sUser,
                        sKey});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginIns_seigyo(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Ins_seigyo", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndIns_seigyo(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Upd_seigyo", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Upd_seigyo(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("Upd_seigyo", new object[] {
                        sUser,
                        sKey});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUpd_seigyo(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Upd_seigyo", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndUpd_seigyo(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/login2", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] login2(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("login2", new object[] {
                        sUser,
                        sKey});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult Beginlogin2(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("login2", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] Endlogin2(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Upd_tanmatu", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Upd_tanmatu(string[] sUser, string sKey) {
            object[] results = this.Invoke("Upd_tanmatu", new object[] {
                        sUser,
                        sKey});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUpd_tanmatu(string[] sUser, string sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Upd_tanmatu", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndUpd_tanmatu(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/login3", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] login3(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("login3", new object[] {
                        sUser,
                        sKey});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult Beginlogin3(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("login3", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] Endlogin3(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_hatuten3", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Get_hatuten3(string[] sUser, string sKcode, string sBcode) {
            object[] results = this.Invoke("Get_hatuten3", new object[] {
                        sUser,
                        sKcode,
                        sBcode});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_hatuten3(string[] sUser, string sKcode, string sBcode, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_hatuten3", new object[] {
                        sUser,
                        sKcode,
                        sBcode}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGet_hatuten3(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_Kadobi", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Get_Kadobi(string[] sUser, string sDateStart, string sDateEnd) {
            object[] results = this.Invoke("Get_Kadobi", new object[] {
                        sUser,
                        sDateStart,
                        sDateEnd});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_Kadobi(string[] sUser, string sDateStart, string sDateEnd, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_Kadobi", new object[] {
                        sUser,
                        sDateStart,
                        sDateEnd}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGet_Kadobi(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_bumon2", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Get_bumon2(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("Get_bumon2", new object[] {
                        sUser,
                        sKey});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_bumon2(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_bumon2", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGet_bumon2(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/wakeupDB", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string wakeupDB() {
            object[] results = this.Invoke("wakeupDB", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginwakeupDB(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("wakeupDB", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string EndwakeupDB(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/wakeupDB2", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string wakeupDB2(int iConCnt) {
            object[] results = this.Invoke("wakeupDB2", new object[] {
                        iConCnt});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginwakeupDB2(int iConCnt, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("wakeupDB2", new object[] {
                        iConCnt}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndwakeupDB2(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
    }
}
