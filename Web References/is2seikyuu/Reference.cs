﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.2407
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// このソース コードは Microsoft.VSDesigner、バージョン 1.1.4322.2407 によって自動生成されました。
// 
namespace IS2Client.is2seikyuu {
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
            string urlSetting = System.Configuration.ConfigurationSettings.AppSettings["IS2Client.is2seikyuu.Service1"];
            if ((urlSetting != null)) {
                this.Url = string.Concat(urlSetting, "");
            }
            else {
                this.Url = "http://wwwis2.fukutsu.co.jp/is2/is2seikyuu/Service1.asmx";
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_Claim", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Get_Claim(string[] sUser, string sKcode, string sBcode) {
            object[] results = this.Invoke("Get_Claim", new object[] {
                        sUser,
                        sKcode,
                        sBcode});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_Claim(string[] sUser, string sKcode, string sBcode, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_Claim", new object[] {
                        sUser,
                        sKcode,
                        sBcode}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGet_Claim(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Sel_Claim", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Sel_Claim(string[] sUser, string sKcode, string sBcode, string sTcode, string sTBcode) {
            object[] results = this.Invoke("Sel_Claim", new object[] {
                        sUser,
                        sKcode,
                        sBcode,
                        sTcode,
                        sTBcode});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginSel_Claim(string[] sUser, string sKcode, string sBcode, string sTcode, string sTBcode, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Sel_Claim", new object[] {
                        sUser,
                        sKcode,
                        sBcode,
                        sTcode,
                        sTBcode}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndSel_Claim(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_seikyuucnt", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Get_seikyuucnt(string[] sUser, string sYubin, string sTcode, string sTbcode) {
            object[] results = this.Invoke("Get_seikyuucnt", new object[] {
                        sUser,
                        sYubin,
                        sTcode,
                        sTbcode});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_seikyuucnt(string[] sUser, string sYubin, string sTcode, string sTbcode, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_seikyuucnt", new object[] {
                        sUser,
                        sYubin,
                        sTcode,
                        sTbcode}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGet_seikyuucnt(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Ins_Claim", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Ins_Claim(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("Ins_Claim", new object[] {
                        sUser,
                        sKey});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginIns_Claim(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Ins_Claim", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndIns_Claim(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Upd_Claim", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Upd_Claim(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("Upd_Claim", new object[] {
                        sUser,
                        sKey});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUpd_Claim(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Upd_Claim", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndUpd_Claim(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Del_Claim", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Del_Claim(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("Del_Claim", new object[] {
                        sUser,
                        sKey});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginDel_Claim(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Del_Claim", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndDel_Claim(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Sel_IrainusiSeikyuu", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Sel_IrainusiSeikyuu(string[] sUser, string[] sData) {
            object[] results = this.Invoke("Sel_IrainusiSeikyuu", new object[] {
                        sUser,
                        sData});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginSel_IrainusiSeikyuu(string[] sUser, string[] sData, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Sel_IrainusiSeikyuu", new object[] {
                        sUser,
                        sData}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndSel_IrainusiSeikyuu(System.IAsyncResult asyncResult) {
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
    }
}