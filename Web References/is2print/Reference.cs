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
namespace IS2Client.is2print {
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(object[]))]
    public class Service1 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public Service1() {
            string urlSetting = System.Configuration.ConfigurationSettings.AppSettings["IS2Client.is2print.Service1"];
            if ((urlSetting != null)) {
                this.Url = string.Concat(urlSetting, "");
            }
            else {
                this.Url = "http://wwwis2.fukutsu.co.jp/is2/is2print/Service1.asmx";
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_InvoicePrintData", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Get_InvoicePrintData(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("Get_InvoicePrintData", new object[] {
                        sUser,
                        sKey});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_InvoicePrintData(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_InvoicePrintData", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGet_InvoicePrintData(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_InvoiceNo", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Get_InvoiceNo(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("Get_InvoiceNo", new object[] {
                        sUser,
                        sKey});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_InvoiceNo(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_InvoiceNo", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGet_InvoiceNo(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Set_InvoiceNo", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Set_InvoiceNo(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("Set_InvoiceNo", new object[] {
                        sUser,
                        sKey});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginSet_InvoiceNo(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Set_InvoiceNo", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndSet_InvoiceNo(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_ConsignorPrintData", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public object[] Get_ConsignorPrintData(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("Get_ConsignorPrintData", new object[] {
                        sUser,
                        sKey});
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_ConsignorPrintData(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_ConsignorPrintData", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public object[] EndGet_ConsignorPrintData(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_ConsigneePrintData", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public object[] Get_ConsigneePrintData(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("Get_ConsigneePrintData", new object[] {
                        sUser,
                        sKey});
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_ConsigneePrintData(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_ConsigneePrintData", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public object[] EndGet_ConsigneePrintData(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_NotePrintData", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public object[] Get_NotePrintData(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("Get_NotePrintData", new object[] {
                        sUser,
                        sKey});
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_NotePrintData(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_NotePrintData", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public object[] EndGet_NotePrintData(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_Unpublished", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public object[] Get_Unpublished(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("Get_Unpublished", new object[] {
                        sUser,
                        sKey});
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_Unpublished(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_Unpublished", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public object[] EndGet_Unpublished(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_ShippedUnpublished", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public object[] Get_ShippedUnpublished(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("Get_ShippedUnpublished", new object[] {
                        sUser,
                        sKey});
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_ShippedUnpublished(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_ShippedUnpublished", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public object[] EndGet_ShippedUnpublished(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_PublishedPrintData", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public object[] Get_PublishedPrintData(string[] sUser, string sKCode, string sBCode, int iSyuka, string sSday, string sEday) {
            object[] results = this.Invoke("Get_PublishedPrintData", new object[] {
                        sUser,
                        sKCode,
                        sBCode,
                        iSyuka,
                        sSday,
                        sEday});
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_PublishedPrintData(string[] sUser, string sKCode, string sBCode, int iSyuka, string sSday, string sEday, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_PublishedPrintData", new object[] {
                        sUser,
                        sKCode,
                        sBCode,
                        iSyuka,
                        sSday,
                        sEday}, callback, asyncState);
        }
        
        /// <remarks/>
        public object[] EndGet_PublishedPrintData(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_ConsigneePrintData2", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public object[] Get_ConsigneePrintData2(string[] sUser, string[] sKey, string sKana, string sTCode, string sTelNo, string sTelNo2, string sTelNo3, string sName, int iSortLabel1, int iSortPat1, int iSortLabel2, int iSortPat2) {
            object[] results = this.Invoke("Get_ConsigneePrintData2", new object[] {
                        sUser,
                        sKey,
                        sKana,
                        sTCode,
                        sTelNo,
                        sTelNo2,
                        sTelNo3,
                        sName,
                        iSortLabel1,
                        iSortPat1,
                        iSortLabel2,
                        iSortPat2});
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_ConsigneePrintData2(string[] sUser, string[] sKey, string sKana, string sTCode, string sTelNo, string sTelNo2, string sTelNo3, string sName, int iSortLabel1, int iSortPat1, int iSortLabel2, int iSortPat2, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_ConsigneePrintData2", new object[] {
                        sUser,
                        sKey,
                        sKana,
                        sTCode,
                        sTelNo,
                        sTelNo2,
                        sTelNo3,
                        sName,
                        iSortLabel1,
                        iSortPat1,
                        iSortLabel2,
                        iSortPat2}, callback, asyncState);
        }
        
        /// <remarks/>
        public object[] EndGet_ConsigneePrintData2(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_ConsigneePrintData3", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public object[] Get_ConsigneePrintData3(string[] sUser, string[] sKey, string sKana, string sTCode, string sTelNo, string sTelNo2, string sTelNo3, string sName, int iSortLabel1, int iSortPat1, int iSortLabel2, int iSortPat2, string sUpdateDay) {
            object[] results = this.Invoke("Get_ConsigneePrintData3", new object[] {
                        sUser,
                        sKey,
                        sKana,
                        sTCode,
                        sTelNo,
                        sTelNo2,
                        sTelNo3,
                        sName,
                        iSortLabel1,
                        iSortPat1,
                        iSortLabel2,
                        iSortPat2,
                        sUpdateDay});
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_ConsigneePrintData3(string[] sUser, string[] sKey, string sKana, string sTCode, string sTelNo, string sTelNo2, string sTelNo3, string sName, int iSortLabel1, int iSortPat1, int iSortLabel2, int iSortPat2, string sUpdateDay, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_ConsigneePrintData3", new object[] {
                        sUser,
                        sKey,
                        sKana,
                        sTCode,
                        sTelNo,
                        sTelNo2,
                        sTelNo3,
                        sName,
                        iSortLabel1,
                        iSortPat1,
                        iSortLabel2,
                        iSortPat2,
                        sUpdateDay}, callback, asyncState);
        }
        
        /// <remarks/>
        public object[] EndGet_ConsigneePrintData3(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_PublishedPrintData2", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public object[] Get_PublishedPrintData2(string[] sUser, string sKCode, string sBCode, int iSyuka, string sSday, string sEday, string sIraiCd) {
            object[] results = this.Invoke("Get_PublishedPrintData2", new object[] {
                        sUser,
                        sKCode,
                        sBCode,
                        iSyuka,
                        sSday,
                        sEday,
                        sIraiCd});
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_PublishedPrintData2(string[] sUser, string sKCode, string sBCode, int iSyuka, string sSday, string sEday, string sIraiCd, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_PublishedPrintData2", new object[] {
                        sUser,
                        sKCode,
                        sBCode,
                        iSyuka,
                        sSday,
                        sEday,
                        sIraiCd}, callback, asyncState);
        }
        
        /// <remarks/>
        public object[] EndGet_PublishedPrintData2(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_PublishedPrintData3", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public object[] Get_PublishedPrintData3(string[] sUser, string sKCode, string sBCode, int iSyuka, string sSday, string sEday, string sIraiCd, string sJyoutai) {
            object[] results = this.Invoke("Get_PublishedPrintData3", new object[] {
                        sUser,
                        sKCode,
                        sBCode,
                        iSyuka,
                        sSday,
                        sEday,
                        sIraiCd,
                        sJyoutai});
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_PublishedPrintData3(string[] sUser, string sKCode, string sBCode, int iSyuka, string sSday, string sEday, string sIraiCd, string sJyoutai, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_PublishedPrintData3", new object[] {
                        sUser,
                        sKCode,
                        sBCode,
                        iSyuka,
                        sSday,
                        sEday,
                        sIraiCd,
                        sJyoutai}, callback, asyncState);
        }
        
        /// <remarks/>
        public object[] EndGet_PublishedPrintData3(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_PublishedPrintData4", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public object[] Get_PublishedPrintData4(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("Get_PublishedPrintData4", new object[] {
                        sUser,
                        sKey});
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_PublishedPrintData4(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_PublishedPrintData4", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public object[] EndGet_PublishedPrintData4(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_DeliShop", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Get_DeliShop(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("Get_DeliShop", new object[] {
                        sUser,
                        sKey});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_DeliShop(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_DeliShop", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGet_DeliShop(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_ShopZip", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Get_ShopZip(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("Get_ShopZip", new object[] {
                        sUser,
                        sKey});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_ShopZip(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_ShopZip", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGet_ShopZip(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_ShopType", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Get_ShopType(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("Get_ShopType", new object[] {
                        sUser,
                        sKey});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_ShopType(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_ShopType", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGet_ShopType(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Walkthrough/XmlWebServices/Get_PrefDeliShop", RequestNamespace="http://Walkthrough/XmlWebServices/", ResponseNamespace="http://Walkthrough/XmlWebServices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] Get_PrefDeliShop(string[] sUser, string[] sKey) {
            object[] results = this.Invoke("Get_PrefDeliShop", new object[] {
                        sUser,
                        sKey});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGet_PrefDeliShop(string[] sUser, string[] sKey, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Get_PrefDeliShop", new object[] {
                        sUser,
                        sKey}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGet_PrefDeliShop(System.IAsyncResult asyncResult) {
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
