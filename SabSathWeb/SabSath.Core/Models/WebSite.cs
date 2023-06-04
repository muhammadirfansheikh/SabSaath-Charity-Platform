using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabSath.Core.Models
{
    public class DonationCategories
    {
        public Int32 ApplicantCaseId { get; set; }
        public string CaseDescription { get; set; }
        public string CaseTitle { get; set; }
        public string RequiredAmount { get; set; }
        public string RaisedAmount { get; set; }

    }
    public class ActiveResolvedCasses
    {
        public string ActiveCases { get; set; }
        public string ResolvedCases { get; set; }
    }
    public class HEMD
    {
        public string Health { get; set; }
        public string Education { get; set; }
        public string Meals { get; set; }
        public string Donors { get; set; }
    }
    public class AllCounts
    {
        List<ActiveResolvedCasses> ListActiveResolvedCasses { get; set; }
        List<HEMD> ListHEMD { get; set; }
    }
    public class QickDonation
    {
        public int DonationType { get; set; }
        public int Currency { get; set; }
        public string OtherAmount { get; set; }
    }
    public class DonateNow
    {
        public Int32 ApplicantCaseId { get; set; }
        public string ApplicantCase { get; set; }
        public int DonationType { get; set; }
        public int Currencyid { get; set; }
        public Int32 Amount { get; set; }
        public int qty { get; set; }
    }
    public class ContactUS
    {
        public int OperationID { get; set; }
        public int? CustomerQueriesID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phoneno { get; set; }
        public string Emailaddress { get; set; }
        public string QueryMessage { get; set; }
        public int? QueryStatus { get; set; }
        public int? QuerySource { get; set; }
        public int IsEmail { get; set; }
        public int? TicketArea { get; set; }
        public int? TicketTypeID { get; set; }
        public int UserId { get; set; }
        public int? CityID { get; set; }
        public string TransactionLink { get; set; }
        public List<ContactUS_Comments> ContactUS_Comments { get; set; }
    }
    public class ContactUS_Comments
    {
        public int? CustomerQueriesID { get; set; }
        public int? ID { get; set; }
        public string Comments { get; set; }
        public string CommentDate { get; set; }
    }
    public class DonationCheckOut
    {
        public string OperationID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Countryid { get; set; }
        public string Amount { get; set; }
        public string DonationTypeid { get; set; }
        public string ApplicantCaseID { get; set; }
        public string Currencyid { get; set; }
        public string SubCategoryID { get; set; }
        public string qty { get; set; }
        public string CategoryID { get; set; }
        public string PaymentTypeID { get; set; }
        public string Bankid { get; set; }
        public string CreatedByid { get; set; }
        public string userip { get; set; }
        public string Document_Type { get; set; }
        public string fileSavePath { get; set; }
        public string relationID { get; set; }
        public string FileName { get; set; }
        public string fileGeneratedName { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyExchangeRate { get; set; }
        public string PayProTranscationID { get; set; }
        public string ChequeNo { get; set; }
        public string Remarks { get; set; }
        public string UniqueOrderId { get; set; }
    }
    public class MailSettings
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
    public class FeaturedNGOsDetails
    {
        public int? ApplicantCaseid { get; set; }
        public int OperationID { get; set; }
        public string Heading { get; set; }
        public int? SetupMasterId { get; set; }
        public string Description { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public int? NGOFeatureID { get; set; }
        public int? UserID { get; set; }
    }
    public class Blogs
    {
        public string OperationID { get; set; }
        public string BlogsID { get; set; }
        public string BlogsTitle { get; set; }
        public string BlogsDesc { get; set; }
        public string BlogsStartDate { get; set; }
        public string BlogExpiryDate { get; set; }
        public string ImageUrl { get; set; }
        public string UserIP { get; set; }
        public string IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string FileName { get; set; }
        public string orignalFileName { get; set; }
    }
    public class Advertisement
    {
        public int OperationID { get; set; }
        public int? AD_ID { get; set; }
        public string Adcontent { get; set; }
        public string Thumbnail { get; set; }
        public int? Adtype { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public int? UserID { get; set; }
        public string UserIP { get; set; }
    }
    public class Testimonials
    {
        public int OperationID { get; set; }
        public int? TestimonialsID { get; set; }
        public string TestimonialsDesc { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public string UserIP { get; set; }
        public int? UserID { get; set; }
        public string VideoURL { get; set; }
        public bool? TestimonialType { get; set; }
        public bool? IsPromoted { get; set; }
    }
    public class PayPro_ResponseViewModel
    {
        public string Status { get; set; }
        public string Description { get; set; }
        public string Order { get; set; }
        public string OrderNumber { get; set; }

        //  public string IPGList { get; set; }
        public string IPGName { get; set; }
        public string isTransactionFeeApplied { get; set; }
        public string Click2Pay_Link_Allowed { get; set; }
        public string isAllowed { get; set; }
        public string OrderAmount { get; set; }
        public string BAFCharge { get; set; }
        public string LinkCharge { get; set; }
        public string Created_on { get; set; }
        public string Order_Expire_After_Seconds { get; set; }
        public string Click2Pay { get; set; }
        public string ConnectPayId { get; set; }
        public string FetchOrderType { get; set; }
        public string ConnectPayFee { get; set; }
        public string BillUrl { get; set; }
        public string ParityAmount { get; set; }
        public string IsParity { get; set; }
        public string PayProId { get; set; }
        public string IsFeeApplied { get; set; }
        public string PayProFee { get; set; }
        public string ConvertionRate { get; set; }
    }
    public class PayProAPI_Request
    {
        public string OrderNumber { get; set; }
        public string OrderAmount { get; set; }
        public string OrderDueDate { get; set; }
        public string OrderType { get; set; }
        public string IssueDate { get; set; }
        public string OrderExpireAfterSeconds { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public string IsConverted { get; set; }
        public string CurrencyAmount { get; set; }
        public string Currency { get; set; }
    }
    public class SendResponse
    {
        public string Status { get; set; }
        public string Description { get; set; }
        public string Click2PayURL { get; set; }
    }
    public class Donar_CheckOut_CRM
    {
        public int OperationID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Countryid { get; set; }
        public string Amount { get; set; }
        public int DonationTypeid { get; set; }
        public string ApplicantCaseID { get; set; }
        public int Currencyid { get; set; }
        public string SubCategoryID { get; set; }
        public string qty { get; set; }
        public string CategoryID { get; set; }
        public string Bankid { get; set; }
        public string CreatedByid { get; set; }
        public string userip { get; set; }
        public string ChequePayOrderNumber { get; set; }
        public int PaymentTypeId { get; set; }
        public string DonationTo { get; set; }
        public string DonationFrom { get; set; }
        public string ApplicantCaseCode { get; set; }
        public string CnicNo { get; set; }
        public string CashBReceiptDate { get; set; }
        public bool Register { get; set; }
        public int DonationForId { get; set; }
        public int Donorid { get; set; }
        public List<Donar_CheckOutDetail_CRM> Donar_CheckOutDetail_CRM { get; set; }
    }
    public class Donar_CheckOutDetail_CRM
    {
        public int? ID { get; set; }
        public int? DocTypeId { get; set; }
        public string DocAttachmentPath { get; set; }
        public int RelationId { get; set; }
        public string FileName { get; set; }
        public string FileGeneratedName { get; set; }
    }
    public class PaymentMarsStatus
    {
        public string URLStatus { get; set; }
        public string TransactionId { get; set; }
    }
    public class SuccessStory
    {
        public int OperationId { get; set; }
        public int caseid { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ShortDesc { get; set; }
        public string FileName { get; set; }
        public string FileGeneratedName { get; set; }
        public string ImageUrl { get; set; }
        public string CreatedBy { get; set; }
        public string Userip { get; set; }
        public string DocTypecasenum { get; set; }
        public string CheckCaseShow { get; set; }
    }
    public class ExchangeRate
    {
        public string Currency { get; set; }
    }
    public class PaymentGateWay
    {
        public int? OperationId { get; set; }
        public int? DonorId { get; set; }
        public string FirstName { get; set; }
        public string ApiExistingCustomerId { get; set; }
        public string LastName { get; set; }
        public string CNIC { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string SuccessUrl { get; set; }
        public string FailureUrl { get; set; }
        public string Url { get; set; }
        public string CountryCode { get; set; }
        public int UserId { get; set; }
        public bool IsRegister { get; set; }
        public bool IsNotifyEmail { get; set; }
        public string UserIP { get; set; }
        public string ApiToken { get; set; }
        public string DonationTypeId { get; set; }
        public PaymentGateWayDonationDetail DonationDetail { get; set; }

    }
    public class PaymentGateWayDonationDetail
    {
        public int? OperationId { get; set; }
        public int? DonorMasterId { get; set; }
        public int? DonationId { get; set; }
        public int? ApplicantCaseId { get; set; }
        public int UserId { get; set; }
        public decimal? Remainder { get; set; }
        public decimal Amount { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal TotalAmount { get; set; }
        public int? CurrencyId { get; set; }
        public int? DonationTypeId { get; set; }
        public int? SubscriptionDetailId { get; set; }
        public bool IsSubscriptionProcess { get; set; }
        public int TotalCount { get; set; }
        public int? frequeny { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public string Remarks { get; set; }
        public string Api_RefrenceId { get; set; }
        public int? DonationForId { get; set; }
        public string Trx_Status { get; set; }
        public string Payment_Type { get; set; }
        public string ResponseCode { get; set; }
        public string UserIp { get; set; }
        public string Api_Subcription_Source_Id { get; set; }
        public string PreviousPaymentId { get; set; }
        public string UserMessage { get; set; }
        public bool IsTransactionCompleted { get; set; }
        public bool IsAdobt { get; set; }
        public bool Is3Ds { get; set; }
        public bool IsAttemptAn3D { get; set; }
        public int? Quantity { get; set; }
        public string donationcomments { get; set; }
        public string PopUpStatus { get; set; }
        public string PopUpStatusMessage { get; set; }
        public string EmailStatus { get; set; }
        public string EmailStatusMessage { get; set; }
        public bool IsRecievedUpdates { get; set; }
        public int? NGOId { get; set; }
    }

    public class DonorWebSite_Register
    {
        public string OperationID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string UserIP { get; set; }
        public string URL { get; set; }
        public string NewPassword { get; set; }
        public string DonorId { get; set; }
    }
    public class DonorCreate_Password
    {
        public string OperationID { get; set; }
        public string NewPassword { get; set; }
        public string DonorId { get; set; }
    }
    public class UserProfile_Update
    {
        public string OperationID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public string UserIP { get; set; }
        public int UserId { get; set; }
        public string URL { get; set; }
        public string PhoneNo { get; set; }
        public string EmailAddress { get; set; }
    }
    public class ManagedEmail_Notification
    {
        public string OperationID { get; set; }
        public int EmailRecive { get; set; }
        public int Userid { get; set; }
        public string UserIP { get; set; }
    }
    public class _API
    {
        public string apiOperation { get; set; }
        //public api_operation apiOperation { get;set;}
        public in_teraction interaction { get; set; }

        public O_rder order { get; set; }
    }
    public class api_operation
    {
        public string apiOperation { get; set; }
    }
    public class in_teraction
    {
        public string operation { get; set; }

    }
    public class O_rder
    {
        public string id { get; set; }
        public string currency { get; set; }
    }

    public class ContentsUploads
    {
        public int OperationID { get; set; }
        public int? Content_ID { get; set; }
        public int? Content_Type { get; set; }
        public string Content_Title { get; set; }
        public string Content_Description { get; set; }
        public int Content_Position { get; set; }
        public bool? Content_IsPromoted { get; set; }
        public bool? Content_Display { get; set; }
        public bool? Content_MediaType { get; set; }
        public int? UserID { get; set; }
        public string UserIP { get; set; }
        public int? CommonAttachmentId { get; set; }
        public string FileName { get; set; }
        public string FileGeneratedName { get; set; }
        public string VideoURL { get; set; }
    }
}






