using Dapper;
using SabSath.Core.Models;
using SabSath.Core.Utilities;
using SabSath.Data.Manager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabSath.Data.DataRepository
{

    public interface IWebSiteDataDapperRepository
    {

        DataSet usp_DonationCategories_web(int? ApplicantCaseid);
        DataSet usp_Active_ResolvedCases_web();

        DataSet Get_Payment_Receipt_Data(string TransactionId);
        DataSet SP_ContactUs(ContactUS obj, DataTable dtContactUS_Comments);
        Task<IEnumerable<dynamic>> usp_DonationCheckOut_web(DonationCheckOut obj);
        DataSet usp_Food_GetReliefDetails();
        DataSet usp_GetRamzanCampaignDetails();
        DataSet usp_GetFeaturedNGOsDetails(FeaturedNGOsDetails obj);
        DataSet usp_GetSuccessStories();
        DataSet usp_GetCaseoftheDay();
        DataSet usp_GetBlogs();
        DataSet SP_Crud_Blogs(Blogs obj);
        DataSet sp_Crud_BlogsView(int OperationID, string BlogTitle, string BlogDesc);
        DataSet SP_Testimonials(Testimonials test);
        DataSet Sp_Content_Upload(ContentsUploads contents, DataTable dt);
        DataSet Sp_Advertisement(Advertisement add);
        DataSet sp_Crud_Blogs_Delete(int OperationID, Int32 BlogsId);
        DataSet SP_GetCompmay_BankDetails();
        DataSet GetPayment_Configuration(int OperationId, Int32 caseid, string GuidId, string PayproTranscationId, string PayProRequestMessage, string PayproResponse, string PayproStatus, int ConfigId, string Toten, string Data, string PayproBankStatus);
        DataSet DonationSubmit_CRM(Donar_CheckOut_CRM objData, DataTable DtDonordetail);
        Task<IEnumerable<dynamic>> Payment_Status_Mark(DonationCheckOut obj);
        DataSet SueessStories_AfterApproved(SuccessStory obj);
        DataSet GetDataset_SuccessStories(SuccessStory obj);
        DataSet SubScribe_Email(string Email);
        DataSet sp_Get_CountryCode(string Operationid);

        #region CheckOut
        DataSet Execute_Donation_Donor_Register(PaymentGateWay ObjPaymentGateWay);
        DataSet Execute_Donation_Transaction(PaymentGateWayDonationDetail ObjPaymentGateWayDetail);

        DataSet Execute_Donation_Transaction_Log(string Response_Request_Text, bool IsResponse, string ApiMethod, int DonationId, int UserId);
        string GetApiTransactionId(int paymentId);

        DataTable GetDonorData(PaymentGateWay objPaymentGteway);

        DataSet Save_Update_Subscruption(PaymentGateWay ObjPaymentGateWay, string status, int paymentId);
        #endregion

        DataSet Donor_WebSite_Register(DonorWebSite_Register objData);
        DataSet Save_Common_Document_Attachment(string _docAttachmentPath, string _userIp, string _transactionId, string _fileName);
        DataSet Get_Profile_Data(UserProfile_Update objData);
        DataSet Managed_EmailNotifications(ManagedEmail_Notification objData);
    }

    public class WebSiteDataDapperRepository : IWebSiteDataDapperRepository
    {
        dynamic objdynamic = null;
        private string connectionString = "";
        private readonly DapperManager dapperManager;
        public WebSiteDataDapperRepository()
        {
            connectionString = GenericConstants.ConnectionString;
            dapperManager = new DapperManager(connectionString);
        }
        public IDbConnection _Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public DataSet SP_ContactUs(ContactUS obj, DataTable dtContactUS_Comments)
        { 
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@OperationID", SqlDbType.Int) {Value =obj.OperationID},
                new SqlParameter("@CustomerQueriesID", SqlDbType.Int) {Value =obj.CustomerQueriesID},
                new SqlParameter("@FirstName", SqlDbType.NVarChar) {Value =obj.FirstName},
                new SqlParameter("@LastName", SqlDbType.NVarChar) {Value =obj.LastName},
                new SqlParameter("@PhoneNo", SqlDbType.NVarChar) {Value =obj.Phoneno},
                new SqlParameter("@EmailAddress", SqlDbType.NVarChar) {Value =obj.Emailaddress},
                new SqlParameter("@QueryMessage", SqlDbType.NVarChar) {Value =obj.QueryMessage},
                new SqlParameter("@TransactionLink", SqlDbType.NVarChar) {Value =obj.TransactionLink},
                new SqlParameter("@QueryStatus", SqlDbType.Int) {Value =obj.QueryStatus},
                new SqlParameter("@QuerySource", SqlDbType.Int) {Value =obj.QuerySource},
                new SqlParameter("@IsEmail", SqlDbType.Int) {Value =obj.IsEmail},
                new SqlParameter("@TicketArea", SqlDbType.Int) {Value =obj.TicketArea},
                new SqlParameter("@TicketTypeID", SqlDbType.Int) {Value =obj.TicketTypeID},
                new SqlParameter("@UserId", SqlDbType.Int) {Value =obj.UserId},
                new SqlParameter("@CityID", SqlDbType.Int) {Value =obj.CityID},
                new SqlParameter("@CustomerQueries_Comments", SqlDbType.Structured) {Value =dtContactUS_Comments},
            };
            var spName = "SP_ContactUs";
            DataSet ds = dapperManager.GetDataSet(spName, parm.ToArray());
            return ds;
        }

        public DataSet usp_DonationCategories_web(int? ApplicantCaseid)
        {
            if (ApplicantCaseid == 0)
                ApplicantCaseid = null;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@ApplicantCaseid", SqlDbType.Int) {Value =ApplicantCaseid},

            };
            var spName = "SP_DonationCategories_web_shehroz";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }

        public DataSet usp_Active_ResolvedCases_web()
        {
            List<SqlParameter> parm = new List<SqlParameter>();
            var spName = "usp_Get_ResolvedUnresolvedCases";
            DataSet ds = dapperManager.GetDataSet(spName, parm.ToArray());
            return ds;
        }

        public DataSet Get_Payment_Receipt_Data(string TransactionId)
        {

            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@TransactionId", SqlDbType = SqlDbType.NVarChar, Value = TransactionId });

            var spName = "SP_SS_Get_Receipt_Data";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }

        public DataSet Save_Common_Document_Attachment(string _docAttachmentPath, string _userIp, string _transactionId, string _fileName)
        {

            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@DocAttachmentPath", SqlDbType = SqlDbType.VarChar, Value = _docAttachmentPath });
            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.VarChar, Value = _userIp });
            parm.Add(new SqlParameter() { ParameterName = "@TranscationId", SqlDbType = SqlDbType.Int, Value = Convert.ToInt32(_transactionId) });
            parm.Add(new SqlParameter() { ParameterName = "@FileName", SqlDbType = SqlDbType.NVarChar, Value = _fileName });

            var spName = "SP_Tbl_CommonAttachment";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }

        public async Task<IEnumerable<dynamic>> usp_DonationCheckOut_web(DonationCheckOut obj)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@OperationID", obj.OperationID);
            queryParameters.Add("@FirstName", obj.FirstName);
            queryParameters.Add("@LastName", obj.LastName);
            queryParameters.Add("@Address", obj.Address);
            queryParameters.Add("@EmailAddress", obj.EmailAddress);
            queryParameters.Add("@ContactNumber", obj.ContactNo);
            queryParameters.Add("@Countryid", obj.Countryid == "" ? null : obj.Countryid);
            queryParameters.Add("@ApplicantCaseId", obj.ApplicantCaseID == "0" ? null : obj.ApplicantCaseID);
            queryParameters.Add("@Amount", obj.Amount);
            queryParameters.Add("@CurrencyId", obj.Currencyid);
            queryParameters.Add("@DonationTypeId", obj.DonationTypeid);
            queryParameters.Add("@PaymentTypeId", obj.PaymentTypeID == "0" ? null : obj.PaymentTypeID);
            queryParameters.Add("@CategoryID", obj.CategoryID);
            queryParameters.Add("@SubCategoryId", obj.SubCategoryID);
            queryParameters.Add("@BankId", obj.Bankid == "0" ? null : obj.Bankid);
            queryParameters.Add("@CreatedBy", obj.CreatedByid == "0" ? null : obj.CreatedByid);
            queryParameters.Add("@UserIP", obj.userip);
            queryParameters.Add("@DocTypeId", obj.Document_Type);
            queryParameters.Add("@DocAttachmentPath", obj.fileSavePath);
            queryParameters.Add("@RelationId", obj.relationID);
            queryParameters.Add("@FileName", obj.FileName);
            queryParameters.Add("@FileGeneratedName", obj.fileGeneratedName);
            queryParameters.Add("@Qty", obj.qty);
            queryParameters.Add("@ExchangeRate", obj.CurrencyExchangeRate == "" ? "0" : obj.CurrencyExchangeRate);
            queryParameters.Add("@PayProTranscationID", obj.PayProTranscationID);
            queryParameters.Add("@chequeNo", obj.ChequeNo);

            var spName = "SP_Donor_CheckoutWeb";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }

        public DataSet usp_Food_GetReliefDetails()
        {
            List<SqlParameter> parm = new List<SqlParameter>();
            var spName = "SP_GetReliefDetails";
            DataSet ds = dapperManager.GetDataSet(spName, parm.ToArray());
            return ds;
        }
        public DataSet usp_GetRamzanCampaignDetails()
        {
            List<SqlParameter> parm = new List<SqlParameter>();
            var spName = "SP_GetRamzanCampaignDetails";
            DataSet ds = dapperManager.GetDataSet(spName, parm.ToArray());
            return ds;
        }
        public DataSet usp_GetFeaturedNGOsDetails(FeaturedNGOsDetails obj)
        {
            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCaseid", SqlDbType = SqlDbType.Int, Value = obj.ApplicantCaseid });
            parm.Add(new SqlParameter() { ParameterName = "@OperationID", SqlDbType = SqlDbType.Int, Value = obj.OperationID });
            parm.Add(new SqlParameter() { ParameterName = "@Heading", SqlDbType = SqlDbType.NVarChar, Value = obj.Heading });
            parm.Add(new SqlParameter() { ParameterName = "@SetupMasterId", SqlDbType = SqlDbType.Int, Value = obj.SetupMasterId });
            parm.Add(new SqlParameter() { ParameterName = "@Description", SqlDbType = SqlDbType.NVarChar, Value = obj.Description });
            parm.Add(new SqlParameter() { ParameterName = "@BankName", SqlDbType = SqlDbType.NVarChar, Value = obj.BankName });
            parm.Add(new SqlParameter() { ParameterName = "@AccountNo", SqlDbType = SqlDbType.NVarChar, Value = obj.AccountNo });
            parm.Add(new SqlParameter() { ParameterName = "@NGOFeatureID", SqlDbType = SqlDbType.Int, Value = obj.NGOFeatureID });
            parm.Add(new SqlParameter() { ParameterName = "@UserID", SqlDbType = SqlDbType.Int, Value = obj.UserID });
            var spName = "SP_GetFeaturedNGOsDetails";
            DataSet ds = dapperManager.GetDataSet(spName, parm.ToArray());
            return ds;
        }
        public DataSet usp_GetSuccessStories()
        {
            List<SqlParameter> parm = new List<SqlParameter>();
            var spName = "SP_SuccessStory_web";
            DataSet ds = dapperManager.GetDataSet(spName, parm.ToArray());
            return ds;
        }

        public DataSet usp_GetCaseoftheDay()
        {
            List<SqlParameter> parm = new List<SqlParameter>();
            var spName = "SP_GetCaseOfTheDay";
            DataSet ds = dapperManager.GetDataSet(spName, parm.ToArray());
            return ds;
        }

        public DataSet usp_GetBlogs()
        {
            List<SqlParameter> parm = new List<SqlParameter>();
            var spName = "SP_GetBlogs_Web";
            DataSet ds = dapperManager.GetDataSet(spName, parm.ToArray());
            return ds;
        }
        public DataSet SP_Crud_Blogs(Blogs obj)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@OperationID", SqlDbType.Int) {Value =obj.OperationID},
                new SqlParameter("@Blogsid", SqlDbType.VarChar) {Value =obj.BlogsID},
                new SqlParameter("@BlogsTitle", SqlDbType.VarChar) {Value =obj.BlogsTitle},
                new SqlParameter("@BlogsDesc", SqlDbType.VarChar) {Value =obj.BlogsDesc},
                new SqlParameter("@BlogsStartDate", SqlDbType.VarChar) {Value =obj.BlogsStartDate},
                new SqlParameter("@BlogExpiryDate", SqlDbType.VarChar) {Value =obj.BlogExpiryDate},
                new SqlParameter("@ImageUrl", SqlDbType.VarChar) {Value =obj.ImageUrl},
                new SqlParameter("@UserIP", SqlDbType.VarChar) {Value =obj.UserIP},
                new SqlParameter("@IsActive", SqlDbType.VarChar) {Value =obj.IsActive},
                new SqlParameter("@CreatedBy", SqlDbType.VarChar) {Value =obj.CreatedBy},
                new SqlParameter("@FileName", SqlDbType.VarChar) {Value =obj.FileName},
                new SqlParameter("@OrignalFileName", SqlDbType.VarChar) {Value =obj.orignalFileName},
           };
            var spName = "SP_Crud_Blogs";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }

        public DataSet sp_Crud_BlogsView(int OperationID, string BlogTitle, string BlogDesc)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@OperationID", SqlDbType.Int) {Value =OperationID},
                new SqlParameter("@BlogsTitle", SqlDbType.VarChar) {Value =BlogTitle},
                new SqlParameter("@BlogsDesc", SqlDbType.VarChar) {Value =BlogDesc},
            };
            var spName = "SP_Crud_Blogs";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }

        public DataSet SP_Testimonials(Testimonials obj)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@OperationID", SqlDbType.Int) {Value = obj.OperationID},
                new SqlParameter("@TestimonialsID", SqlDbType.Int) {Value = obj.TestimonialsID},
                new SqlParameter("@TestimonialsDesc", SqlDbType.NVarChar) {Value = obj.TestimonialsDesc},
                new SqlParameter("@Name", SqlDbType.NVarChar) {Value = obj.Name},
                new SqlParameter("@Caption", SqlDbType.NVarChar) {Value = obj.Caption},
                new SqlParameter("@UserID", SqlDbType.Int) {Value = obj.UserID},
                new SqlParameter("@UserIP", SqlDbType.NVarChar) {Value = obj.UserIP},
                new SqlParameter("@VideoURL", SqlDbType.NVarChar) {Value = obj.VideoURL},
                new SqlParameter("@TestimonialType", SqlDbType.Bit) {Value = obj.TestimonialType},
                new SqlParameter("@IsPromoted", SqlDbType.Bit) {Value = obj.IsPromoted},
            };
            var spName = "SP_Testimonials";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }

        public DataSet Sp_Advertisement(Advertisement add)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@OperationID", SqlDbType.Int) {Value = add.OperationID},
                new SqlParameter("@AD_ID", SqlDbType.Int) {Value = add.AD_ID},
                new SqlParameter("@Adcontent", SqlDbType.NVarChar) {Value = add.Adcontent},
                new SqlParameter("@Thumbnail", SqlDbType.NVarChar) {Value = add.Thumbnail},
                new SqlParameter("@Adtype", SqlDbType.Int) {Value = add.Adtype},
                new SqlParameter("@Title", SqlDbType.NVarChar) {Value = add.Title},
                new SqlParameter("@Description", SqlDbType.NVarChar) {Value = add.Description},
                new SqlParameter("@Position", SqlDbType.Int) {Value = add.Position},
                new SqlParameter("@UserID", SqlDbType.Int) {Value = add.UserID},
                new SqlParameter("@UserIP", SqlDbType.NVarChar) {Value = add.UserIP},
            };
            var spName = "Sp_Advertisement";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }

        public DataSet Sp_Content_Upload(ContentsUploads obj, DataTable dt)
        {
            List<SqlParameter> parm = new List<SqlParameter>();
            //    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = "2" });
            parm.Add(new SqlParameter() { ParameterName = "@OperationID", SqlDbType = SqlDbType.Int, Value = obj.OperationID });
            parm.Add(new SqlParameter() { ParameterName = "@Content_ID", SqlDbType = SqlDbType.Int, Value = obj.Content_ID });
            parm.Add(new SqlParameter() { ParameterName = "@Content_Type", SqlDbType = SqlDbType.Int, Value = obj.Content_Type });
            parm.Add(new SqlParameter() { ParameterName = "@Content_Title", SqlDbType = SqlDbType.NVarChar, Value = obj.Content_Title });
            parm.Add(new SqlParameter() { ParameterName = "@Content_Description", SqlDbType = SqlDbType.NVarChar, Value = obj.Content_Description });
            parm.Add(new SqlParameter() { ParameterName = "@Content_Position", SqlDbType = SqlDbType.Int, Value = obj.Content_Position });
            parm.Add(new SqlParameter() { ParameterName = "@Content_IsPromoted", SqlDbType = SqlDbType.Bit, Value = obj.Content_IsPromoted });
            parm.Add(new SqlParameter() { ParameterName = "@Content_Display", SqlDbType = SqlDbType.Bit, Value = obj.Content_Display });
            parm.Add(new SqlParameter() { ParameterName = "@Content_MediaType", SqlDbType = SqlDbType.Bit, Value = obj.Content_MediaType });
            parm.Add(new SqlParameter() { ParameterName = "@UserID", SqlDbType = SqlDbType.Int, Value = obj.UserID });
            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
            parm.Add(new SqlParameter() { ParameterName = "@Tbl_Type_DocAttachment", SqlDbType = SqlDbType.Structured, Value = dt });
            var spName = "Sp_Content_Upload";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet sp_Crud_Blogs_Delete(int OperationID, Int32 Blogsid)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@OperationID", SqlDbType.Int) {Value =OperationID},
                new SqlParameter("@Blogsid", SqlDbType.Int) {Value =Blogsid},
            };
            var spName = "SP_Crud_Blogs";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }

        public DataSet SP_GetCompmay_BankDetails()
        {
            List<SqlParameter> parm = new List<SqlParameter>();
            var spName = "SP_GetCompmay_BankDetails";
            DataSet ds = dapperManager.GetDataSet(spName, parm.ToArray());
            return ds;
        }


        public DataSet GetPayment_Configuration(int OperationId, Int32 caseid, string GuidId, string PayproTranscationId, string PayProRequestMessage, string PayproResponse, string PayproStatus, int ConfigId, string Token, string Data, string PayproBankStatus)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
               new SqlParameter("@OperationID", SqlDbType.Int) {Value =OperationId},
               new SqlParameter("@Caseid", SqlDbType.Int) {Value =caseid},
               new SqlParameter("@GuidId", SqlDbType.NVarChar) {Value =GuidId},
               new SqlParameter("@PayproTranscationId", SqlDbType.VarChar) {Value =PayproTranscationId},
               new SqlParameter("@PayProRequestMessage", SqlDbType.NVarChar) {Value =PayProRequestMessage},
               new SqlParameter("@PayproResponse", SqlDbType.NVarChar) {Value =PayproResponse},
               new SqlParameter("@PayproStatus", SqlDbType.NVarChar) {Value =PayproStatus},
               new SqlParameter("@ConfigId", SqlDbType.Int) {Value =ConfigId},
               new SqlParameter("@Token", SqlDbType.NVarChar) {Value =Token},
               new SqlParameter("@Data", SqlDbType.NVarChar) {Value =Data},
               new SqlParameter("@PayProBankStatus", SqlDbType.NVarChar) {Value =PayproBankStatus},

            };
            var spName = "Sp_GetPayemntAPI_Config";
            DataSet ds = dapperManager.GetDataSet(spName, parm.ToArray());
            return ds;
        }


        public DataSet DonationSubmit_CRM(Donar_CheckOut_CRM objData, DataTable DtDonordetail)
        {
            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationID", SqlDbType = SqlDbType.Int, Value = objData.OperationID });
            parm.Add(new SqlParameter() { ParameterName = "@FirstName", SqlDbType = SqlDbType.NVarChar, Value = objData.FirstName });
            parm.Add(new SqlParameter() { ParameterName = "@LastName", SqlDbType = SqlDbType.NVarChar, Value = objData.LastName });
            parm.Add(new SqlParameter() { ParameterName = "@Address", SqlDbType = SqlDbType.NVarChar, Value = objData.Address });
            parm.Add(new SqlParameter() { ParameterName = "@EmailAddress", SqlDbType = SqlDbType.NVarChar, Value = objData.EmailAddress });
            parm.Add(new SqlParameter() { ParameterName = "@ContactNumber", SqlDbType = SqlDbType.NVarChar, Value = objData.ContactNo });
            parm.Add(new SqlParameter() { ParameterName = "@Countryid", SqlDbType = SqlDbType.Int, Value = objData.Countryid });
            // parm.Add(new SqlParameter() { ParameterName = "@CurrencyId", SqlDbType = SqlDbType.Int, Value = objData.Currencyid });
            // parm.Add(new SqlParameter() { ParameterName = "@BankId", SqlDbType = SqlDbType.Int, Value = objData.Bankid == "0" ? null : objData.Bankid });//check
            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = objData.userip });
            parm.Add(new SqlParameter() { ParameterName = "@CreatedBy", SqlDbType = SqlDbType.Int, Value = objData.CreatedByid });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCaseID", SqlDbType = SqlDbType.NVarChar, Value = objData.ApplicantCaseID });
            parm.Add(new SqlParameter() { ParameterName = "@Amount", SqlDbType = SqlDbType.Int, Value = objData.Amount });
            parm.Add(new SqlParameter() { ParameterName = "@CurrencyId", SqlDbType = SqlDbType.Int, Value = objData.Currencyid });
            parm.Add(new SqlParameter() { ParameterName = "@DonationTypeId", SqlDbType = SqlDbType.Int, Value = objData.DonationTypeid });
            parm.Add(new SqlParameter() { ParameterName = "@PaymentTypeId", SqlDbType = SqlDbType.Int, Value = objData.PaymentTypeId });
            parm.Add(new SqlParameter() { ParameterName = "@BankId", SqlDbType = SqlDbType.Int, Value = objData.Bankid });
            parm.Add(new SqlParameter() { ParameterName = "@ChequePayOrderNumber", SqlDbType = SqlDbType.NVarChar, Value = objData.ChequePayOrderNumber == "" ? "0" : objData.ChequePayOrderNumber });
            parm.Add(new SqlParameter() { ParameterName = "@Donationfrom", SqlDbType = SqlDbType.VarChar, Value = objData.DonationFrom == "" ? null : objData.DonationFrom });
            parm.Add(new SqlParameter() { ParameterName = "@Donationto", SqlDbType = SqlDbType.VarChar, Value = objData.DonationTo == "" ? null : objData.DonationTo });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCaseCode", SqlDbType = SqlDbType.VarChar, Value = objData.ApplicantCaseCode });
            parm.Add(new SqlParameter() { ParameterName = "@CashBReceiptDate", SqlDbType = SqlDbType.VarChar, Value = objData.CashBReceiptDate });
            parm.Add(new SqlParameter() { ParameterName = "@Register", SqlDbType = SqlDbType.Int, Value = objData.Register == true ? 1 : 0 });
            parm.Add(new SqlParameter() { ParameterName = "@Category", SqlDbType = SqlDbType.Int, Value = objData.CategoryID == "0" ? null : objData.CategoryID });
            parm.Add(new SqlParameter() { ParameterName = "@SubCategory", SqlDbType = SqlDbType.Int, Value = objData.SubCategoryID == "0" ? null : objData.SubCategoryID });
            parm.Add(new SqlParameter() { ParameterName = "@CnicNo", SqlDbType = SqlDbType.VarChar, Value = objData.CnicNo });
            parm.Add(new SqlParameter() { ParameterName = "@DonationForId", SqlDbType = SqlDbType.Int, Value = objData.DonationForId });
            parm.Add(new SqlParameter() { ParameterName = "@Donoridget", SqlDbType = SqlDbType.Int, Value = objData.Donorid });
            parm.Add(new SqlParameter() { ParameterName = "@Tbl_Type_DocAttachment1", SqlDbType = SqlDbType.Structured, Value = DtDonordetail });
            var spName = "SP_Donor_Detail_CRM";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }

        public async Task<IEnumerable<dynamic>> Payment_Status_Mark(DonationCheckOut obj)
        {
            string CountryVal;
            if (obj.Countryid == "0" || obj.Countryid == "")
                CountryVal = null;
            else
                CountryVal = obj.Countryid;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@OperationID", obj.OperationID);
            queryParameters.Add("@FirstName", obj.FirstName);
            queryParameters.Add("@LastName", obj.LastName);
            queryParameters.Add("@Address", obj.Address);
            queryParameters.Add("@EmailAddress", obj.EmailAddress);
            queryParameters.Add("@ContactNumber", obj.ContactNo);
            queryParameters.Add("@Countryid", CountryVal);
            queryParameters.Add("@ApplicantCaseId", obj.ApplicantCaseID == "0" ? null : obj.ApplicantCaseID);
            queryParameters.Add("@Amount", obj.Amount);
            queryParameters.Add("@CurrencyId", obj.Currencyid);
            queryParameters.Add("@DonationTypeId", obj.DonationTypeid);
            queryParameters.Add("@PaymentTypeId", obj.PaymentTypeID == "0" ? null : obj.PaymentTypeID);
            queryParameters.Add("@CategoryID", obj.CategoryID == "0" ? null : obj.CategoryID);
            queryParameters.Add("@SubCategoryId", obj.SubCategoryID == "0" ? null : obj.SubCategoryID);
            queryParameters.Add("@BankId", obj.Bankid == "0" ? null : obj.Bankid);
            queryParameters.Add("@CreatedBy", obj.CreatedByid == "0" ? null : obj.CreatedByid);
            queryParameters.Add("@UserIP", obj.userip);
            queryParameters.Add("@DocTypeId", obj.Document_Type);
            queryParameters.Add("@DocAttachmentPath", obj.fileSavePath);
            queryParameters.Add("@RelationId", obj.relationID);
            queryParameters.Add("@FileName", obj.FileName);
            queryParameters.Add("@FileGeneratedName", obj.fileGeneratedName);
            queryParameters.Add("@Qty", obj.qty);
            queryParameters.Add("@ExchangeRate", obj.CurrencyExchangeRate);
            queryParameters.Add("@PayProTranscationID", obj.PayProTranscationID);
            queryParameters.Add("@Remarks", obj.Remarks);

            var spName = "SP_Donor_CheckoutWeb";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }

        public DataSet SueessStories_AfterApproved(SuccessStory objData)
        {
            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationID", SqlDbType = SqlDbType.Int, Value = objData.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = objData.caseid });
            parm.Add(new SqlParameter() { ParameterName = "@casetittle", SqlDbType = SqlDbType.NVarChar, Value = objData.Title });
            parm.Add(new SqlParameter() { ParameterName = "@caseDesc", SqlDbType = SqlDbType.NVarChar, Value = objData.Desc });
            parm.Add(new SqlParameter() { ParameterName = "@Userip", SqlDbType = SqlDbType.NVarChar, Value = objData.Userip });
            parm.Add(new SqlParameter() { ParameterName = "@CreatedBy", SqlDbType = SqlDbType.NVarChar, Value = objData.CreatedBy });
            parm.Add(new SqlParameter() { ParameterName = "@ShortDesc", SqlDbType = SqlDbType.NVarChar, Value = objData.ShortDesc });
            parm.Add(new SqlParameter() { ParameterName = "@FileName", SqlDbType = SqlDbType.NVarChar, Value = objData.FileName == "" ? null : objData.FileName });
            parm.Add(new SqlParameter() { ParameterName = "@FileGeneratedName", SqlDbType = SqlDbType.NVarChar, Value = objData.FileGeneratedName });
            parm.Add(new SqlParameter() { ParameterName = "@DocPath", SqlDbType = SqlDbType.NVarChar, Value = objData.ImageUrl });
            parm.Add(new SqlParameter() { ParameterName = "@DocType", SqlDbType = SqlDbType.NVarChar, Value = objData.DocTypecasenum });
            parm.Add(new SqlParameter() { ParameterName = "@IsCheckShow", SqlDbType = SqlDbType.NVarChar, Value = objData.CheckCaseShow });
            var spName = "SP_SuccessStory_Update";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }


        public DataSet GetDataset_SuccessStories(SuccessStory objData)
        {
            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationID", SqlDbType = SqlDbType.Int, Value = objData.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = objData.caseid });
            parm.Add(new SqlParameter() { ParameterName = "@casetittle", SqlDbType = SqlDbType.NVarChar, Value = objData.Title });
            parm.Add(new SqlParameter() { ParameterName = "@caseDesc", SqlDbType = SqlDbType.NVarChar, Value = objData.Desc });
            parm.Add(new SqlParameter() { ParameterName = "@Userip", SqlDbType = SqlDbType.NVarChar, Value = objData.Userip });
            parm.Add(new SqlParameter() { ParameterName = "@CreatedBy", SqlDbType = SqlDbType.NVarChar, Value = objData.CreatedBy });
            parm.Add(new SqlParameter() { ParameterName = "@ShortDesc", SqlDbType = SqlDbType.NVarChar, Value = objData.ShortDesc });
            parm.Add(new SqlParameter() { ParameterName = "@FileName", SqlDbType = SqlDbType.NVarChar, Value = objData.FileName == "" ? null : objData.FileName });
            parm.Add(new SqlParameter() { ParameterName = "@FileGeneratedName", SqlDbType = SqlDbType.NVarChar, Value = objData.FileGeneratedName });
            parm.Add(new SqlParameter() { ParameterName = "@DocPath", SqlDbType = SqlDbType.NVarChar, Value = objData.ImageUrl });
            parm.Add(new SqlParameter() { ParameterName = "@DocType", SqlDbType = SqlDbType.NVarChar, Value = objData.DocTypecasenum });
            parm.Add(new SqlParameter() { ParameterName = "@IsCheckShow", SqlDbType = SqlDbType.NVarChar, Value = objData.CheckCaseShow });

            var spName = "SP_SuccessStory_Update";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }

        public DataSet SubScribe_Email(string Email)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
               new SqlParameter("@Subscriber", SqlDbType.VarChar) {Value =Email},

            };
            var spName = "SP_Subscriber_Web";
            DataSet ds = dapperManager.GetDataSet(spName, parm.ToArray());
            return ds;
        }


        public DataSet sp_Get_CountryCode(string Operationid)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
               new SqlParameter("@OperationID", SqlDbType.VarChar) {Value = Operationid},

            };
            var spName = "Sp_GetCountryCode";
            DataSet ds = dapperManager.GetDataSet(spName, parm.ToArray());
            return ds;
        }

        #region CheckOut

        public DataSet Execute_Donation_Donor_Register(PaymentGateWay ObjPaymentGateWay)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
               new SqlParameter("@FirstName", SqlDbType.VarChar) {Value =ObjPaymentGateWay.FirstName},
               new SqlParameter("@OperationId", SqlDbType.Int) {Value =ObjPaymentGateWay.OperationId},
               new SqlParameter("@LastName", SqlDbType.VarChar) {Value =ObjPaymentGateWay.LastName},
               new SqlParameter("@DonorMasterId", SqlDbType.Int) {Value =ObjPaymentGateWay.DonorId},
               new SqlParameter("@ApiExistingCustomerId", SqlDbType.NVarChar) {Value =ObjPaymentGateWay.ApiExistingCustomerId},

               new SqlParameter("@CountryId", SqlDbType.Int) {Value =ObjPaymentGateWay.CountryId},
               new SqlParameter("@EmailAddress", SqlDbType.NVarChar) {Value =ObjPaymentGateWay.EmailAddress},
               new SqlParameter("@ContactNumber", SqlDbType.NVarChar) {Value =ObjPaymentGateWay.ContactNumber},
               new SqlParameter("@Address", SqlDbType.NVarChar) {Value =ObjPaymentGateWay.Address},
               new SqlParameter("@IsRegister", SqlDbType.Bit) {Value =ObjPaymentGateWay.IsRegister},
               new SqlParameter("@IsNotify", SqlDbType.Bit) {Value =ObjPaymentGateWay.IsNotifyEmail},
               new SqlParameter("@UserId", SqlDbType.Int) {Value =ObjPaymentGateWay.UserId},
               new SqlParameter("@Url", SqlDbType.NVarChar) {Value =ObjPaymentGateWay.Url}


            };
            var spName = "SP_Sab_Saath_Register_Donor_Via_Donation";
            DataSet ds = dapperManager.GetDataSet(spName, parm.ToArray());
            return ds;
        }


        public DataSet Execute_Donation_Transaction(PaymentGateWayDonationDetail ObjPaymentGateWayDetail)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
               new SqlParameter("@OperationId", SqlDbType.Int) {Value =ObjPaymentGateWayDetail.OperationId},
               new SqlParameter("@DonationId", SqlDbType.Int) {Value =ObjPaymentGateWayDetail.DonationId},
               new SqlParameter("@DonorMasterId", SqlDbType.Int) {Value =ObjPaymentGateWayDetail.DonorMasterId},
               new SqlParameter("@ApplicantCaseId", SqlDbType.Int) {Value = ObjPaymentGateWayDetail.ApplicantCaseId == 0 || ObjPaymentGateWayDetail.ApplicantCaseId == null ? null: ObjPaymentGateWayDetail.ApplicantCaseId},
               new SqlParameter("@Amount", SqlDbType.Float) {Value =Convert.ToDecimal(ObjPaymentGateWayDetail.Amount)},
               new SqlParameter("@ExchangeRate", SqlDbType.Float) {Value =ObjPaymentGateWayDetail.ExchangeRate},
               new SqlParameter("@CurrencyId", SqlDbType.Int) {Value =ObjPaymentGateWayDetail.CurrencyId},
               new SqlParameter("@DonationTypeId", SqlDbType.Int) {Value =ObjPaymentGateWayDetail.DonationTypeId},
               new SqlParameter("@CategoryId", SqlDbType.Int) {Value =ObjPaymentGateWayDetail.CategoryId == 0 ? null :ObjPaymentGateWayDetail.CategoryId },
               new SqlParameter("@SubCategoryId", SqlDbType.Int) {Value = ObjPaymentGateWayDetail.SubCategoryId == 0 ? null : ObjPaymentGateWayDetail.SubCategoryId},
               new SqlParameter("@ApiTransactionId", SqlDbType.NVarChar) {Value =ObjPaymentGateWayDetail.Api_RefrenceId},
               new SqlParameter("@ApiSubscriptionSourceId", SqlDbType.NVarChar) {Value =ObjPaymentGateWayDetail.Api_Subcription_Source_Id},
               new SqlParameter("@DonationForId", SqlDbType.Int) {Value =ObjPaymentGateWayDetail.DonationForId},
               new SqlParameter("@Trx_Status", SqlDbType.NVarChar) {Value =ObjPaymentGateWayDetail.Trx_Status},
               new SqlParameter("@Reponse_Code", SqlDbType.NVarChar) {Value =ObjPaymentGateWayDetail.ResponseCode},
               new SqlParameter("@PaymentType", SqlDbType.NVarChar) {Value =ObjPaymentGateWayDetail.Payment_Type},
               new SqlParameter("@UserMessage", SqlDbType.NVarChar) {Value =ObjPaymentGateWayDetail.UserMessage},
               new SqlParameter("@IsTransactionCompleted", SqlDbType.Bit) {Value =ObjPaymentGateWayDetail.IsTransactionCompleted},
               new SqlParameter("@IsAdobt", SqlDbType.Bit) {Value =ObjPaymentGateWayDetail.IsAdobt},
               new SqlParameter("@UserId", SqlDbType.Int) {Value =ObjPaymentGateWayDetail.UserId},
               new SqlParameter("@UserIp", SqlDbType.NVarChar) {Value =ObjPaymentGateWayDetail.UserIp},
               new SqlParameter("@Quantity", SqlDbType.Int) {Value =ObjPaymentGateWayDetail.Quantity  == 0 ? null :ObjPaymentGateWayDetail.Quantity },  // add line manzoor
               new SqlParameter("@PopUpStatus", SqlDbType.VarChar) {Value =ObjPaymentGateWayDetail.PopUpStatus },
               new SqlParameter("@PopUpStatusMessage", SqlDbType.VarChar) {Value =ObjPaymentGateWayDetail.PopUpStatusMessage },
               new SqlParameter("@EmailStatus", SqlDbType.VarChar) {Value =ObjPaymentGateWayDetail.EmailStatus },
               new SqlParameter("@EmailStatusMessage", SqlDbType.VarChar) {Value =ObjPaymentGateWayDetail.EmailStatusMessage } ,
               new SqlParameter("@DonationComments", SqlDbType.VarChar) {Value =ObjPaymentGateWayDetail.donationcomments },
               new SqlParameter("@IsRecievedUpdates", SqlDbType.Bit) {Value =ObjPaymentGateWayDetail.IsRecievedUpdates },
               new SqlParameter("@NGOId", SqlDbType.Int) {Value =ObjPaymentGateWayDetail.NGOId },
               new SqlParameter("@Remarks", SqlDbType.VarChar) {Value =ObjPaymentGateWayDetail.Remarks }
            };
            var spName = "SP_Sab_Saath_Mark_Donation_And_Update_Status";
            DataSet ds = dapperManager.GetDataSet(spName, parm.ToArray());
            return ds;
        }


        public DataSet Execute_Donation_Transaction_Log(string Response_Request_Text, bool IsResponse, string ApiMethod, int DonationId, int UserId)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
               new SqlParameter("@Request_Response_Text", SqlDbType.NVarChar) {Value =Response_Request_Text},
               new SqlParameter("@IsResponse", SqlDbType.Bit) {Value =IsResponse},
               new SqlParameter("@ApiMethodName", SqlDbType.NVarChar) {Value =ApiMethod},
               new SqlParameter("@DonationId", SqlDbType.Int) {Value =DonationId},
               new SqlParameter("@UserId", SqlDbType.Int) {Value =UserId},



            };
            var spName = "SP_Sab_Saath_Mark_Payment_GateWay_Log";
            DataSet ds = dapperManager.GetDataSet(spName, parm.ToArray());
            return ds;
        }

        //public string GetApiTransactionId(int paymentId)
        //{
        //    //Query if Record Exist in RoleMenuItemFeatureMapping Table then Mark Checked Else Checked = false
        //    string tableNameFeature = "Tbl_Donor_Payament_Detail";
        //    string qryFeature = $"DonorDetailId = @DonorDetailId";
        //    object paramFeature = new { DonorDetailId = paymentId};
        //    //object paramSubModule = new { RoleId = roleId, MenuItemId = type.MenuId };
        //    dynamic modelFeatureChecked = dapperManager.FindByID<dynamic>(qryFeature, paramFeature, tableNameFeature).FirstOrDefault();
        //    return modelFeatureChecked.APITranscationId.ToString();
        //}

        public string GetApiTransactionId(int paymentId)
        {
            //Query if Record Exist in RoleMenuItemFeatureMapping Table then Mark Checked Else Checked = false
            string tableNameFeature = "SELECT APITranscationId FROM Tbl_Donor_Payament_Detail ";
            string qryFeature = "WHERE DonorDetailId = " + paymentId + "";

            //object paramSubModule = new { RoleId = roleId, MenuItemId = type.MenuId };

            DataTable modelFeatureChecked = dapperManager.GetQueryResult(tableNameFeature, qryFeature);

            if (modelFeatureChecked.Rows.Count > 0)
            {
                return modelFeatureChecked.Rows[0]["APITranscationId"].ToString();
            }
            else
            {
                return "";
            }

        }

        public DataSet Save_Update_Subscruption(PaymentGateWay objPaymentGteway, string status, int paymentId)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@OperationId", SqlDbType.Int) {Value =objPaymentGteway.OperationId},
                new SqlParameter("@DonorId", SqlDbType.VarChar) {Value =objPaymentGteway.DonorId},
                new SqlParameter("@ApplicantCaseId", SqlDbType.VarChar) {Value =objPaymentGteway.DonationDetail.ApplicantCaseId},
                new SqlParameter("@CategoryId", SqlDbType.VarChar) {Value =objPaymentGteway.DonationDetail.CategoryId},
                new SqlParameter("@SubCategoryId", SqlDbType.VarChar) {Value =objPaymentGteway.DonationDetail.SubCategoryId},
                new SqlParameter("@TotalAmount", SqlDbType.VarChar) {Value =objPaymentGteway.DonationDetail.TotalAmount},
                new SqlParameter("@TotalCount", SqlDbType.VarChar) {Value =objPaymentGteway.DonationDetail.TotalCount},
                new SqlParameter("@SubscriptionStatus", SqlDbType.VarChar) {Value = status},
                new SqlParameter("@SubcriptionDetailId", SqlDbType.Int) {Value = objPaymentGteway.DonationDetail.SubscriptionDetailId},
                new SqlParameter("@DonationTypeId", SqlDbType.Int) {Value = objPaymentGteway.DonationDetail.DonationTypeId},
                new SqlParameter("@Message", SqlDbType.VarChar) {Value =""},
                new SqlParameter("@Status", SqlDbType.VarChar) {Value =status},
                new SqlParameter("@PaymentId", SqlDbType.VarChar) {Value =paymentId},
                new SqlParameter("@UserId", SqlDbType.VarChar) {Value =objPaymentGteway.UserId},
                new SqlParameter("@CurrencyId", SqlDbType.Int) {Value = objPaymentGteway.DonationDetail.CurrencyId},
                new SqlParameter("@frequeny", SqlDbType.Int) {Value = objPaymentGteway.DonationDetail.frequeny},
                new SqlParameter("@Remainder", SqlDbType.Int) {Value = objPaymentGteway.DonationDetail.Remainder},
                new SqlParameter("@Amount", SqlDbType.Int) {Value = objPaymentGteway.DonationDetail.Amount},
           };
            var spName = "SP_Sab_Saath_Save_Update_Donation_Subscription";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }

        public DataTable GetDonorData(PaymentGateWay objPaymentGteway)
        {
            //Query if Record Exist in RoleMenuItemFeatureMapping Table then Mark Checked Else Checked = false
            string tableNameFeature = "SELECT * FROM Tbl_DonorMaster ";
            string qryFeature = "WHERE (lower(EmailAddress) =lower('" + objPaymentGteway.EmailAddress + "') AND EmailAddress IS NOT NULL AND EmailAddress != '' ) OR (ContactNumber = '" + objPaymentGteway.ContactNumber + "' AND ContactNumber IS NOT NULL AND ContactNumber != '' AND IsActive=1) ";

            //object paramSubModule = new { RoleId = roleId, MenuItemId = type.MenuId };

            DataTable modelFeatureChecked = dapperManager.GetQueryResult(tableNameFeature, qryFeature);
            return modelFeatureChecked;
        }
        #endregion

        public DataSet Donor_WebSite_Register(DonorWebSite_Register obj)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@OperationID", SqlDbType.Int) {Value =obj.OperationID.Trim()},
                new SqlParameter("@FirstName", SqlDbType.VarChar) {Value =obj.FirstName.Trim()},
                new SqlParameter("@LastName", SqlDbType.VarChar) {Value =obj.LastName.Trim()},
                new SqlParameter("@Address", SqlDbType.VarChar) {Value =obj.Address.Trim()},
                new SqlParameter("@EmailAddress", SqlDbType.VarChar) {Value =obj.EmailAddress.Trim()},
                new SqlParameter("@ContactNumber", SqlDbType.VarChar) {Value =obj.PhoneNo.Trim()},
                new SqlParameter("@Countryid", SqlDbType.VarChar) {Value =obj.CountryId},
                new SqlParameter("@Cityid", SqlDbType.VarChar) {Value =obj.CityId},
                new SqlParameter("@UserIP", SqlDbType.VarChar) {Value =obj.UserIP == null ? "124.29.235.20" : obj.UserIP.Trim()},
                new SqlParameter("@URL", SqlDbType.VarChar) {Value =obj.URL.Trim()},
                 new SqlParameter("@DonorIDGet", SqlDbType.VarChar) {Value =obj.DonorId.Trim()},
                 new SqlParameter("@NewPassword", SqlDbType.VarChar) {Value =obj.NewPassword.Trim()},
           };
            var spName = "SP_Donor_WebSite_Register";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet Get_Profile_Data(UserProfile_Update obj)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@OperationID", SqlDbType.Int) {Value =obj.OperationID.Trim()},
                new SqlParameter("@FirstName", SqlDbType.VarChar) {Value =obj.FirstName.Trim()},
                new SqlParameter("@LastName", SqlDbType.VarChar) {Value =obj.LastName.Trim()},
                new SqlParameter("@Address", SqlDbType.VarChar) {Value =obj.Address.Trim()},
                new SqlParameter("@Countryid", SqlDbType.VarChar) {Value =obj.CountryId},
                new SqlParameter("@UserIP", SqlDbType.VarChar) {Value =obj.UserIP.Trim()},
                new SqlParameter("@UserId", SqlDbType.Int) {Value =obj.UserId},
                new SqlParameter("@PhoneNo", SqlDbType.VarChar) {Value =obj.PhoneNo.Trim()},
                new SqlParameter("@EmailAddress", SqlDbType.VarChar) {Value =obj.EmailAddress},
                new SqlParameter("@URL", SqlDbType.VarChar) {Value =obj.URL},
            };
            var spName = "SP_Donor_Profile_Update";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }

        public DataSet Managed_EmailNotifications(ManagedEmail_Notification obj)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@OperationId", SqlDbType.Int) {Value =obj.OperationID.Trim()},
                new SqlParameter("@EmailReceive", SqlDbType.Int) {Value =obj.EmailRecive},
                new SqlParameter("@UserId", SqlDbType.Int) {Value =obj.Userid},
                new SqlParameter("@UserIP", SqlDbType.VarChar) {Value =obj.UserIP},
            };
            var spName = "SP_ManagedEmailNotifications";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
    }
}
