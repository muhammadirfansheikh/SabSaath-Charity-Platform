using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabSath.Core.Utilities
{
    public struct GenericConstants
    {
        public const string ConnectionStringKey = "ConnectionString";

        public static int Sql_CommandTimeout = 36000;
        public const string DefaultDateFormat = "MMM dd,yyyy";
        public const string DefaultDateFormatWithTime = "MMM dd,yyyy HH:mm:ss";
        public const string DateFormatDDMMYYYY = "dd-MM-yyyy";
        public const string TimeFormatLong = "HH:mm:ss";
        public const string TimeFormatAMPM = "hh:mm:ss tt";
        public const string ErrorLog = "Logs/ExceptionsLogs";
        public const string GetDefaultPage = "/Default.aspx";
        public const string EmailLog = "Logs/EmailLog";
        public const string Password = "ppcrm123$";

        #region DB_NAMES
        public const string DB_Setup = "SW_Setup";
        public const string DB_HRMS = "SW_HRMS";
        public const string DB_TMS = "SW_TMS";
        #endregion

        #region Connection String

        #region Development and UAT
        //public const string ConnectionString = @"Data Source =  192.168.61.32\MSSQLSERVER2017;Initial Catalog =DB_Sab_Saath_Dev_UAT; User ID=sa;pwd=Sybr1d123; Connection Timeout = 600000;";
        #endregion

        #region Pre Production 
        public const string ConnectionString = @"Data Source = 192.168.61.233;Initial Catalog =DB_Sab_Saath_Pre_Prod; User ID=sa;pwd=Sybr1d123;Connection Timeout = 600000;";
        #endregion

        #region Production 
        //public const string ConnectionString = @"Data Source = 192.168.61.233;Initial Catalog =DB_Sab_Sath_Live; User ID=sa;pwd=Sybr1d123;Connection Timeout = 600000;";
        #endregion

        #endregion

        #region DirectoryPath

        #region Development 
        //public const string DirectoryPath = "http://localhost:50469/UploadImages/";
        #endregion

        #region UAT Server 
        //public const string DirectoryPath = "http://124.29.235.8:9182/UploadImages/";
        #endregion

        #region Pre Production Server
        public const string DirectoryPath = "http://124.29.235.8:9183/UploadImages/";
        #endregion

        #region Production Server 
        //public const string DirectoryPath = "https://api.sabsaath.org/UploadImages/";
        #endregion

        #endregion

        #region CheckoutURL

        #region Development
        //public const string Url = "http://localhost:50469/checkout";
        #endregion

        #region UAT Server
        //public const string Url = "http://124.29.235.8:9182/checkout";
        #endregion

        #region Pre Production Server
        public const string Url = "http://124.29.235.8:9183/checkout";
        #endregion

        #region Production Server
        //public const string Url = "https://api.sabsaath.org/checkout";
        #endregion

        #endregion

        #region SabsathandZamanLogo

        #region Development 
        //public const string SabSaathLogo = "http://124.29.235.8:4001/static/media/sabsaath-logo.7f9ba71815a845cea8ae.png";
        //public const string ZamanLogo = "http://www.zamanfoundation.pk/wp-content/uploads/2020/02/logo.png";
        #endregion

        #region UAT Server 
        //public const string SabSaathLogo = "http://124.29.235.8:5001/static/media/sabsaath-logo.7f9ba71815a845cea8ae.png";
        //public const string ZamanLogo = "http://www.zamanfoundation.pk/wp-content/uploads/2020/02/logo.png";
        #endregion

        #region Pre Production Server 
        public const string SabSaathLogo = "http://124.29.235.8:4001/static/media/sabsaath-logo.7f9ba71815a845cea8ae.png";
        public const string ZamanLogo = "http://www.zamanfoundation.pk/wp-content/uploads/2020/02/logo.png";
        #endregion

        #region Production Server 
        //public const string SabSaathLogo = "https://sabsaath.org/static/media/sabsaath-logo.7f9ba71815a845cea8ae.png";
        //public const string ZamanLogo = "https://www.zamanfoundation.pk/wp-content/uploads/2020/02/logo.png";
        #endregion

        #endregion


        #region SaveReceiptPath

        #region Development 
        //public const string SaveReceiptPath = "D:/Projects/SabSath/SabSaathProjectAfterMerging/SabSaathAPI/SabSathWeb/SabSathWeb/wwwroot/UploadImages/DonationRecipet/";
        #endregion

        #region UAT Server 
        //public const string SaveReceiptPath = "D:/Applications/Sab_Sath_Api/wwwroot/UploadImages/DonationRecipet/";
        #endregion

        #region Pre Production Server 
        public const string SaveReceiptPath = "D:/Applications/Sab_Saath_API_Live_UAT/wwwroot/UploadImages/DonationRecipet/";
        #endregion

        #region Production Server 
        //public const string SaveReceiptPath = "E:/Application/SabSath/Sab_Sath_Api/wwwroot/UploadImages/DonationRecipet/";
        #endregion

        #endregion

        #region EmailCredentials

        public const string _SenderEmail = "info@sabsaath.org";
        public const string _SenderEmailPassword = "TBqqx#*JLC?-";
        public const string _SenderEmailSMTP = "192.185.167.136";
        public const string _SenderEmailPort = "587";
        public const bool _SenderEmailSsl = false;

        //public const string _SenderEmail = "info@zamanfoundation.pk";
        //public const string _SenderEmailPassword = "%J37MR4A@dlo";
        //public const string _SenderEmailSMTP = "mail.zamanfoundation.pk";
        //public const string _SenderEmailPort = "25";
        //public const bool _SenderEmailSsl = true;

        //public const string _SenderEmail = "irfan.muhammad@sybrid.com";
        //public const string _SenderEmailPassword = "odtcqtmxyrjvvsnt";
        //public const string _SenderEmailSMTP = "smtp.gmail.com";
        //public const string _SenderEmailPort = "587";
        //public const bool _SenderEmailSsl = true;

        #endregion

        #region Api Keys
        public const string _FastForexKey = "5c8a444420-40bf9f1dc8-rj5vt1";
        #endregion

        #region FastForex
        //public const string _FastForexAPIKey = "c06cbb8999-0d2aa5291d-rk3fih";
        public const string _FastForexAPIKey = "5c8a444420-40bf9f1dc8-rj5vt1";  // live key

        #endregion

        #region CheckOut

        #region Sandbox
        public const string _CheckOutPublicKey = "pk_test_e85b7a81-99ba-4b61-bf22-3e189396cf91";
        public const string _CheckOutSecretApiKey = "sk_test_22e982cf-2001-4b74-b417-2be788bb42f6";
        public const string _CheckOutPublicKeyId = "98A720F9BD8726850280D8E1457EC905";
        public const string _CheckOutSecretApiKeyId = "DB9731DEB08A28FB2C680BCBB148F582";
        public const string _CheckOutAccessKeyId = "ack_bkzu6uo5dvqunaoajbiolbbvw4";
        public const string _CheckOutAccessKeySecret = "sruBYOIBeyhM_GJaxd8EiBM9IfnZUVYr8eOTwlpia-F8sCP43_DKKb1r62hkyQJnl7tJKdNgMX8CzgzNXJzrZA";
        #endregion

        #region Production
        //public const string _CheckOutPublicKey = "pk_05eea11c-8f78-4acb-aa8e-c607cb27acb1";
        //public const string _CheckOutSecretApiKey = "sk_071974cc-a9a3-4ab3-a40b-8983728e8c36";
        //public const string _CheckOutPublicKeyId = "98A720F9BD8726850280D8E1457EC905";
        //public const string _CheckOutSecretApiKeyId = "DB9731DEB08A28FB2C680BCBB148F582";
        //public const string _CheckOutAccessKeyId = "ack_bkzu6uo5dvqunaoajbiolbbvw4";
        //public const string _CheckOutAccessKeySekcret = "sruBYOIBeyhM_GJaxd8EiBM9IfnZUVYr8eOTwlpia-F8sCP43_DKKb1r62hkyQJnl7tJKdNgMX8CzgzNXJzrZA";
        #endregion 

        #endregion
    }

    public struct Roles
    {
        public const int SuperAdmin = 1;
        public const int Admin = 2;
        public const int Incharge = 3;
        public const int Employee = 4;
    }
    public struct Setup_Master
    {
        public const int OperationTypes = 1;
    }
    public struct Setup_MasterDetail
    {
        public const int Select = 1;
        public const int Insert = 2;
        public const int Update = 3;
        public const int Delete = 4;
    }
    public struct Feature
    {
        public const int Add = 1;
        public const int Edit = 2;
        public const int Delete = 3;
        public const int View = 4;
    }
    public class ResponseKeys
    {
        public static string Data = "Data";
        public static string Response = "Response";
        public static string ResponseCode = "ResponseCode";
        public static string ErrorMessage = "ErrorMessage";
        public static string ResponseMessage = "ResponseMessage";
        public static string Token = "Token";
    }
    public class ResponseCodes
    {
        public static string Success = "00";
        public static string TokenExpired = "01";
        public static string NotGeneratedAgainstThisUser = "02";
        public static string InvalidToken = "03";
        public static string InvalidCredentials = "04";
        public static string Exception = "05";
        public static string ValidationError = "07";
        public static string Failure = "11";
    }
    public class ResponseMessages
    {
        public static string Success = "Success";
        public static string TokenExpired = "Token Expired";
        public static string NotGeneratedAgainstThisUser = "Token is not valid for this user";
        public static string InvalidToken = "Invalid Token";
        public static string InvalidCredentials = "Invalid Credentials";
        public static string InvalidErrorCode = "Invalid Error Code";
        public static string Failure = "Failure";
        public static string Exception = "An Exception has been occured";
        public static string NoData = "No Data Found";
        public static string ExceptionMessage = "An Exception has occured. Some thing went wrong";
        public static string InvalidPatientId = "Invalid Patient";
        public static string SuccessfullyRegistered = "SuccessfullyRegistered";
        public static string InvalidParameters = "Invalid Parameters";
        public static string SuccessfullyUpdated = "Successfully Updated";
        public static string SuccessfullyAdded = "Successfully Added";
        public static string SuccessfullyDeleted = "Successfully Deleted";
    }
    public class MessageDate<T>
    {
        public bool Response { get; set; }
        public string ResponseCodes { get; set; }
        public string ResponseMessage { get; set; }
        public T Data { get; set; }
        public DataSet DataSet { get; set; }

    }
    public class MessageDate_M<T>
    {
        public T Data { get; set; }
    }
    public struct OperationTypes
    {
        public const string Select = "Select";
        public const string Insert = "Insert";
        public static string Update = "Update";
        public const string Delete = "Delete";
    }
    public class Menu
    {
        public string path { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public string component { get; set; }
        public string layout { get; set; }
        public string SubNode { get; set; }
        public int MenuId { get; set; }
        public int ApplicationId { get; set; }
        public string Menu_Name { get; set; }
        public int Parent_Id { get; set; }
        public string Value { get; set; }
        public string Menu_URL { get; set; }
        public bool? Is_Displayed_In_Menu { get; set; }
        public List<SubMenu> SubMenus { get; set; }
    }
    public class SubMenu
    {
        public string path { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public string component { get; set; }
        public string layout { get; set; }
        public int MenuItemId { get; set; }
        public int ApplicationId { get; set; }
        public string Value { get; set; }
        public string parent { get; set; }
        public Boolean Checked { get; set; }
        public string Label { get; set; }
        public bool? Is_Displayed_In_Menu { get; set; }
        public List<ChildSubMenu> ChildSubMenu { get; set; }
    }
    public class ChildSubMenu
    {
        public string path { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public string component { get; set; }
        public string layout { get; set; }
        public int SubMenuItemId { get; set; }
        public int ApplicationId { get; set; }
        public string Value { get; set; }
        public string parent { get; set; }
        public Boolean Checked { get; set; }
        public string Label { get; set; }
        public bool? Is_Displayed_In_Menu { get; set; }
    }


    public class ParentMenu
    {
        public int value { get; set; }
        public string label { get; set; }
        public List<Features> ParentFeature { get; set; }
        public List<ChildMenu> children { get; set; }
    }
    public class ChildMenu
    {
        public int value { get; set; }
        public string label { get; set; }
        public List<Features> children { get; set; }
    }
    public class Features
    {
        public int value { get; set; }
        public string label { get; set; }
    }
}
