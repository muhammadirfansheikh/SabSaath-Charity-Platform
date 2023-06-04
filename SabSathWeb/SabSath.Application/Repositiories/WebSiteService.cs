using SabSath.Application.Helper;
using SabSath.Core.Models;
using SabSath.Core.Utilities;
using SabSath.Data.DataRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Mail;

namespace SabSath.Application.Repositiories
{
    public interface IWebSiteService
    {
        dynamic SP_ContactUs(ContactUS obj, DataTable dt1);
        DataSet usp_DonationCategories_web(int? ApplicantCaseid);
        dynamic USP_Get_Receipt_Data(string TransactionId, string UserIp);
        dynamic usp_Active_ResolvedCases_web();
        dynamic usp_DonationCheckOut_web(DonationCheckOut obj);
        DataSet usp_Food_GetReliefDetails();
        DataSet usp_GetRamzanCampaignDetails();
        DataSet usp_GetFeaturedNGOsDetails(FeaturedNGOsDetails obj);
        DataSet usp_GetSuccessStories();
        DataSet usp_GetCaseoftheDay();
        DataSet usp_GetBlogs();
        dynamic SP_Crud_Blogs(Blogs obj);
        DataSet sp_Crud_BlogsView(int OperationID, string BlogTitle, string BlogDesc);
        DataSet SP_Testimonials(Testimonials test);
        dynamic Sp_Content_Upload(ContentsUploads contents, DataTable dt);
        DataSet Sp_Advertisement(Advertisement add);
        DataSet sp_Crud_Blogs_Delete(int OperationID, Int32 BlogsId);
        DataSet SP_GetCompmay_BankDetails();
        DataSet GetPayment_Configuration(int OperationId, Int32 caseid, string GuidId, string PayproTranscationId, string PayProRequestMessage, string PayproResponse, string PayproStatus, int ConfigId, string Toten, string Data, string PayproBankStatus);
        dynamic DonationSubmit_CRM(Donar_CheckOut_CRM obj);
        dynamic Payment_Status_Mark(DonationCheckOut obj);
        dynamic SueessStories_AfterApproved(SuccessStory obj);
        dynamic GetDataset_SuccessStories(SuccessStory obj);
        dynamic SubScribe_Email(string Email);
        dynamic CurrResponse(string ResCode, string Msg);
        dynamic sp_Get_CountryCode(string OperationId);

        #region FastForex
        dynamic Fast_Forex_Fetch_Only_One(string fromCurrency, string toCurrency);
        #endregion

        dynamic Donor_WebSite_Register(DonorWebSite_Register obj);
        dynamic Get_Profile_Data(UserProfile_Update obj);
        dynamic Managed_EmailNotifications(ManagedEmail_Notification obj);
        // Task SendEmailAsync(MailRequest mailRequest);

        #region CheckOut
        MessageDate<dynamic> SP_Sab_Saath_Donation_Donor_Registration(PaymentGateWay ObjPaymentGateWay);
        MessageDate<dynamic> SP_Sab_Saath_Mark_Donation_Transaction(PaymentGateWayDonationDetail ObjPaymentGateWayDetail);
        MessageDate<dynamic> SP_Sab_Saath_Donation_Transaction_Log(string Response_Request_Text, bool IsResponse, string ApiMethod, int DonationId, int UserId);
        string GetRequestPaymentResponse(int httpResponseCode);
        string GetRequestPaymentStatusCode(int StatusCode);
        MessageDate<dynamic> GetAPITransactionId(int PayamentDetailId);
        MessageDate<dynamic> GetDonorData(PaymentGateWay objPaymentGateWay);
        MessageDate<dynamic> SP_Sab_Saath_Subscription(PaymentGateWay obj, string status, int paymentId);
        #endregion

    }
    public class WebSiteService : IWebSiteService
    {
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        private readonly IWebSiteDataDapperRepository _IWebSiteDataDapperRepository;
        private IHostingEnvironment Environment;
        PaymentGateWayDonationDetail ObjPaymentGateWayDetail = new PaymentGateWayDonationDetail();

        public WebSiteService(IWebSiteDataDapperRepository WebSiteDataDapperRepository, IHostingEnvironment _environment)
        {
            _IWebSiteDataDapperRepository = WebSiteDataDapperRepository;
            Environment = _environment;

        }
        public dynamic SP_ContactUs(ContactUS obj, DataTable dt1)
        {
            try
            {
                DataSet obj_response = _IWebSiteDataDapperRepository.SP_ContactUs(obj, dt1);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception e)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public DataSet usp_DonationCategories_web(int? ApplicantCaseid)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _IWebSiteDataDapperRepository.usp_DonationCategories_web(ApplicantCaseid);
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }
        private void ReceiptBody(DataSet DS, out string _receiveHtml, out string _receiveFileName, out bool _isFileGenerated, string _transactionId = "")
        {
            TextLogWriter("Calling ReceiptBody");
            string path = GenericConstants.DirectoryPath;
            string _html = "";
            _receiveHtml = _html;
            _isFileGenerated = false;
            string _SavedReceiptName = "";
            DataSet obj_response = null;
            try
            {
                ObjPaymentGateWayDetail.OperationId = 3;
                ObjPaymentGateWayDetail.DonationId = Convert.ToInt32(_transactionId);
                ObjPaymentGateWayDetail.PopUpStatus = "Pending";
                ObjPaymentGateWayDetail.EmailStatus = "Pending";
                obj_response = _IWebSiteDataDapperRepository.Execute_Donation_Transaction(ObjPaymentGateWayDetail);

                _html = @"<div style='overflow-x : hidden;'>
    <div style='border: 2px solid; border-radius:25px; font-family:Arial,Helvetica, sans-serif; ' id='invoicePrint'>
        <table style='font-size:smaller;width:100%; margin-top:25px; margin-bottom:25px !important'>
            <tr>
                <td style='font-size:smaller; width:100%; text-align:center;'>
                    <img src='{SuccessLogo}' />
                </td>
            </tr>
        </table>
        <table style='font-size:smaller;width:100%'>
            <tr>
                <td style='text-align:center'>
                    <strong> <span style='color:#68991d;font-size:medium'>Transaction Successful</span></strong>
                </td>
            </tr>
        </table>
        </br>
        <table style='font-size:smaller;width:100%; margin-left : 5px;'>
            <tr>
                <td style='text-align:left'>
                     Hi {DonorName},
                    <br></br>
                </td>
            </tr>
        </table>
        <table style='font-size:smaller;width:100%;text-align:left; margin-left : 5px;'>
            <tr>
                <td>
                    Thankyou for your generous donation.
                </td>
            </tr>
            <tr>
                <td style='text-align:left'>
                    {EmailText}
                </td>
            </tr>
        </table>
        </br>
        <table style='font-size:smaller;width:100%; margin-left : 5px;'>
            <tr>
                <td style='font-weight:bold;text-align:left; width:32%' padding-left=10%>Recipient Account</td>
                <td style='text-align:left'> &nbsp; Zaman Foundation</td>
            </tr>
            <tr>
                <td style='font-weight:bold;text-align:left'>Date & Time</td>
                <td style='text-align:left'> &nbsp; {TransactionDate}</td>
            </tr>
            <tr>
                <td style='font-weight:bold;text-align:left'>Transaction ID</td>
                <td style='text-align:left'> &nbsp; {TransactionId}</td>
            </tr>
            <tr>
                <td style='font-weight:bold;text-align:left'>Donation Amount</td>
                <td style='text-align:left'> &nbsp; {DonationAmount} {CurrencyCode}</td>
            </tr>
            <tr>
                <td style='font-weight:bold;text-align:left'>NGO</td>
                <td style='text-align:left'> &nbsp; {NGO}</td>
            </tr>
            <tr>
                <td style='font-weight:bold;text-align:left'>Cause</td>
                <td style='text-align:left'> &nbsp; {Cause}</td>
            </tr>
            <tr>
                <td style='font-weight:bold;text-align:left;display:{display}'>Note</td>
                <td style='text-align:left;display:{display}'> &nbsp; {Comments}</td>
            </tr>
        </table>
        </br>
        <table style='font-size:smaller;width:100%'>
            <tr>
                <td style='text-align:center'>
                    <img src='{SabSaathLogo}' />
                </td>
            </tr>
        </table>
    </div>
    <div style='text-align:left; font-size:smaller; font-family:Arial,Helvetica, sans-serif;'>{EmailText1}</div>
</div>";

                _html = _html.Replace("{SuccessLogo}", path + "success_icon.png");
                _html = _html.Replace("{DonorName}", DS.Tables[0].Rows[0]["FullName"].ToString());
                _html = _html.Replace("{TransactionDate}", DS.Tables[0].Rows[0]["TransactionDate"].ToString());
                _html = _html.Replace("{TransactionDate}", DS.Tables[0].Rows[0]["TransactionDate"].ToString());
                _html = _html.Replace("{TransactionId}", DS.Tables[0].Rows[0]["TransactionId"].ToString());
                _html = _html.Replace("{DonationAmount}", DS.Tables[0].Rows[0]["Amount"].ToString());
                _html = _html.Replace("{CurrencyCode}", "  " + DS.Tables[0].Rows[0]["CurrencyCode"].ToString());
                _html = _html.Replace("{NGO}", "  " + DS.Tables[0].Rows[0]["NGO"].ToString());
                _html = _html.Replace("{Cause}", "  " + DS.Tables[0].Rows[0]["Cause"].ToString());
                //_html = _html.Replace("{SabSaathLogo}", path + "sabsaath-logo.png");
                _html = _html.Replace("{SabSaathLogo}", GenericConstants.SabSaathLogo);
                _html = _html.Replace("{Comments}", "  " + DS.Tables[0].Rows[0]["Comments"].ToString());
                //_html = _html.Replace("{EmailText}", " ");

                string _EmailBeforPara =
                 @"<div style='font-family:Arial,Helvetica, sans-serif ;  ' id='email'>";

                if (DS.Tables[0].Rows[0]["IsQurbani"].ToString() == "0")
                {
                    _EmailBeforPara +=
                    @"<table style=width:100%;text-align:left'>
                    <tr>
                    <td>
                    <strong> Thank You for helping. </strong> 
                    </td>
                    </tr>
                    <tr>
                    <td></td>
                    </tr>
                    <tr>
                    <td> Hi {FullName}, </td>
                    </tr>
                    <tr>
                    <td></td>
                    </tr>
                    <tr>
                    <td>
                    <p>Your donation is saving lives. Just because of your help, we are able to provide relief and aid to individuals and families across Pakistan. Your official receipt is attached to this email  as   well.<p>
                    </td>
                    </tr>
                    <tr>
                    <td>{EmailBody}</td>
                    </tr>
                    <tr> 
                    </tr>
                    <tr>
                    <td></td>
                    </tr>       
                    <tr>
                    <td></td>
                    </tr>
                    <tr>
                    <td>-Your friends at Sab Saath. </td>
                    </tr>
                    <tr>
                    <td></td>
                    </tr>
                    </table>";
                }
                else
                {
                    _EmailBeforPara +=
                   @"<table style=width:100%;text-align:left'>
                    <tr>
                    <td> Dear {FullName}, </td>
                    </tr>

                    <tr>
                    <td></td>
                    </tr>

                    <tr>
                    <td>
                    <p>Your order is confirmed. Thank you for trusting Sab Saath with your Qurbani. 100% of the sacrificial meat and skins will serve families in need and allow them to partake in the joyous celebrations of Eid ul Azha.<p>
                    </td>
                    </tr>

                    <tr>
                    <td></td>
                    </tr>

                    <tr>
                    <td>May God bless you and your loved ones. Ameen. ❤️ </td>
                    </tr>

                    <tr>
                    <td><br/></td>
                    </tr>
                    
                    <tr>
                    <td>Warmth and Prayers,</td>
                    </tr>  

                    <tr>
                    <td>Team Sab Saath</td>
                    </tr>

                    <tr>
                    <td>Call / WhatsApp: +92 301 844 4959</td>
                    </tr>

                    <tr>
                    <td><a href='www.sabsaath.org'>www.sabsaath.org</a></td>
                    </tr>

                    </table>";
                }

                _EmailBeforPara += @"<table style='width:70% ; border-spacing:0px; padding: 10px 13px; border:1px solid';>
        <thead>
        <tr>
        <th style='text-align:left; font-size: 20px; font-weight: 600;'  colspan='2'>Sab Saath - Donation Receipt</th>
        <th rowspan='3' style='text-align:right;'> 
        <img src = {SabSaathLogo}  style='width:100px;'>
        </th>
        </tr>
        <tr>
        <th style='text-align:left;font-size:12px;padding-top:12px;'><img src ='http:www.iconsdb.comiconspreviewgraymessageoutlinexxl.png'height='12px'width='10px'info@sabsaath.org
        </th>
        </tr>
        <th style='text-align:left; font-size:12px;padding-bottom: 8px;'><img
        src='https:www.iconsdb.comiconspreviewgraygeographyxxl.png'height='12px'width='10px'>www.sabsaath.org<th>
        </thead>
        <tbody>
        <tr>
        <td style='border-top: 2px solid ;border-bottom:2px solid'><strong>Summary</strong></td>
        <td style='border-top: 2px solid ;border-bottom : 2px solid'></td>
        <td style = 'border-top: 2px solid ;border-bottom : 2px solid'> Receipt Number: &nbsp; {InvoiceNumber}</td>
        </tr>
        <tr>
        <td colspan='3' style='padding-top: 10px ; padding-bottom:20px ;'>Received with thanks from {FullName}</td>
        </tr>
        <tr>
        <td style='width: 20%;'><strong>Donation Amount:</strong></td>
        <td><strong>{DonationAmount} {CurrencyCode}</strong></td>
        <td></td>
        </tr>
        <tr>
        <td style='width: 20%;'><strong>Donation Date:</strong></td>
        <td><strong>{TransactionDate}</strong></td>
        <td></td>
        </tr>
        <tr>
        <td style='width: 20%;'><strong>Date Issued: </strong></td>
        <td><strong>{TransactionDate}</strong></td>
        <td></td>
        </tr>
        <tr>
        <td style='width:20%;'><strong>Payment Mode:</strong></td>
        <td><strong>Online</strong></td>
        <td></td>
        </tr>
        <tr>
        <td style='width:20%;'><strong>NGO:</strong></td>
        <td><strong>{NGO}</strong></td>
        <td></td>
        </tr>
        <tr>
        <td style='width:20%;'><strong>Cause:</strong></td>
        <td><strong>{Cause}</strong></td>
        <td></td>
        </tr>
       <tr>
        <td style='width:20%;display:{display};'><strong>Note:</strong></td>
        <td style='display:{display};'><strong>{Comments}</strong></td>
        <td style='display:{display};'></td>
        </tr>
        <tr>
        <td colspan = '3'>
        <p>This is an auto-generated receipt and does not need signatures. Please print this receipt for tax purposes.</p>
        <p>Zaman Foundation (NTN-2544023-3) is a non profit organization. We are tax exempted under FBR act 2(36)(c).</p>
        </td>
        </tr>
        <tr>
        <td colspan='3'><hr/></td>
        </tr>
        <tr>
        <td  style='background-color:#76608a; color:white; padding-top:28px; padding-bottom:28px; border:2px solid #76608a; text-align:center;'colspan='2'>
        All that is with you is bound to come to an end whereas that is which is with God is everlasting</td>
        <td style='background-color:#e1d5e7; color:black ; padding-top:28px; padding-bottom:28px; border:2px solid #76608a;  text-align:center'>Surah Al-Nahl 16:96</td>
        </tr>
       
        <tr style='height:0px;'>
         <td style = 'padding-top:15px'; colspan ='2'><img src ='https://p.kindpng.com/picc/s/108-1084416_transparent-white-location-icon-png-png-download.png' height='12px' width='10px'> 21 - Waris Road, Lahore Pakistan</td>
          
            <td rowspan='3' style='text-align:right;'><img src = {ZamanLogo}  style='width:60px;'></td>
        </tr>
        <tr style = 'height:0px;'>
        <td colspan='2'><img src ='http://www.iconsdb.com/icons/preview/gray/phone-71-xxl.png' height='12px' width='10px'> 92 42 111 222 500</td>
        
        <td style='text-align:right;'></td>
        </tr>
        <tr>
        <td></td>
        <td></td>
        </tr>

        </tbody>
        </table>
                     </div>";

                // _EmailBeforPara = _EmailBeforPara.Replace("{SuccessLogo}", path + "success_icon.png");
                _EmailBeforPara = _EmailBeforPara.Replace("{FullName}", DS.Tables[0].Rows[0]["FullName"].ToString());
                _EmailBeforPara = _EmailBeforPara.Replace("{PaperClip}", path + "papericon.png");
                _EmailBeforPara = _EmailBeforPara.Replace("{DonationAmount}", DS.Tables[0].Rows[0]["Amount"].ToString());
                _EmailBeforPara = _EmailBeforPara.Replace("{TransactionDate}", DS.Tables[0].Rows[0]["TransactionDate"].ToString());
                _EmailBeforPara = _EmailBeforPara.Replace("{TransactionDate}", DS.Tables[0].Rows[0]["TransactionDate"].ToString());
                _EmailBeforPara = _EmailBeforPara.Replace("{CurrencyCode}", DS.Tables[0].Rows[0]["CurrencyCode"].ToString());
                _EmailBeforPara = _EmailBeforPara.Replace("{NGO}", "  " + DS.Tables[0].Rows[0]["NGO"].ToString());
                _EmailBeforPara = _EmailBeforPara.Replace("{Cause}", "  " + DS.Tables[0].Rows[0]["Cause"].ToString());
                _EmailBeforPara = _EmailBeforPara.Replace("{Comments}", "  " + DS.Tables[0].Rows[0]["Comments"].ToString());
                _EmailBeforPara = _EmailBeforPara.Replace("{SabSaathLogo}", GenericConstants.SabSaathLogo);
                _EmailBeforPara = _EmailBeforPara.Replace("{InvoiceNumber}", DS.Tables[0].Rows[0]["TransactionId"].ToString());
                _EmailBeforPara = _EmailBeforPara.Replace("{ZamanLogo}", GenericConstants.ZamanLogo);
                if (DS.Tables[1] != null && DS.Tables[1].Rows.Count > 0)
                {
                    if (!String.IsNullOrEmpty(DS.Tables[1].Rows[0]["NextPostingDate"].ToString()))
                    {
                        //_EmailBeforPara = _EmailBeforPara.Replace("{EmailBody}", "<p>Your next donation will be posted at " + Convert.ToDateTime(DS.Tables[1].Rows[0]["NextPostingDate"]).ToString("dd-MM-yyyy") + ". You can view and manage your subscription by logging in at <a href='www.sabsaath.org'>Sab Saath</a> or also </p> <p> to unsubscribe from notifications, please click <a href='www.sabsaath.org'>here</a></p>");

                        _EmailBeforPara = _EmailBeforPara.Replace("{EmailBody}", "<p>Your next donation will be posted on " + Convert.ToDateTime(DS.Tables[1].Rows[0]["NextPostingDate"]).ToString("dd-MM-yyyy") + ". You can view and manage your subscription and notifications by logging in at <a href='www.sabsaath.org'>Sab Saath.</a></p>");
                    }
                    else
                    {
                        _EmailBeforPara = _EmailBeforPara.Replace("{EmailBody}", "&nbsp;");
                    }
                }
                else
                {
                    _EmailBeforPara = _EmailBeforPara.Replace("{EmailBody}", "");
                }


                if (!String.IsNullOrEmpty(DS.Tables[0].Rows[0]["EmailAddress"].ToString()))
                {
                    ////Generate Image Of Receipt
                    if (!Convert.ToBoolean(DS.Tables[0].Rows[0]["IsVerified"]))
                        _html = _html.Replace("{EmailText1}", "&nbsp;Account activation email has been sent to your email");
                    else
                        _html = _html.Replace("{EmailText1}", " ");

                    if (DS.Tables[0].Rows[0]["Comments"] == null || !String.IsNullOrEmpty(DS.Tables[0].Rows[0]["Comments"].ToString()))
                    {
                        _html = _html.Replace("{display}", "revert");
                        _EmailBeforPara = _EmailBeforPara.Replace("{display}", "revert");
                    }
                    else
                    {
                        _html = _html.Replace("{display}", "none");
                        _EmailBeforPara = _EmailBeforPara.Replace("{display}", "none");
                    }
                    string _EmailHtml = _html;

                    _EmailHtml = _html.Replace("{EmailText}", " ");
                    TextLogWriter("Calling ConvertHtmlToImage");
                    _SavedReceiptName = CommonObjects.ConvertHtmlToImage(_EmailHtml, GenericConstants.SaveReceiptPath, DS.Tables[0].Rows[0]["FullName"].ToString(), _transactionId);
                    TextLogWriter("_SavedReceiptName => " + _SavedReceiptName);
                    _isFileGenerated = true;
                    TextLogWriter("_isFileGenerated = true");

                    TextLogWriter("Calling SendMail");
                    responseDetail = SendMail(DS.Tables[0].Rows[0]["EmailAddress"].ToString(), "Sab Saath Donation Receipt", _EmailBeforPara, "", "wwwroot/UploadImages/DonationRecipet/" + _SavedReceiptName, _transactionId);

                    if (responseDetail.Response)
                    {
                        _html = _html.Replace("{EmailText}", "A confirmation email has been sent to your email id <p>" + DS.Tables[0].Rows[0]["EmailAddress"].ToString() + "</p>");
                    }
                    else
                    {
                        _html = _html.Replace("{EmailText}", "A confirmation email could not be sent to your email id " + DS.Tables[0].Rows[0]["EmailAddress"].ToString() + "");
                    }

                    ObjPaymentGateWayDetail.OperationId = 3;
                    ObjPaymentGateWayDetail.DonationId = Convert.ToInt32(_transactionId);
                    ObjPaymentGateWayDetail.PopUpStatus = "Success";
                    DataSet obj_response1 = _IWebSiteDataDapperRepository.Execute_Donation_Transaction(ObjPaymentGateWayDetail);

                }
                else
                {
                    _html = _html.Replace("{EmailText}", "");
                }
            }
            catch (Exception ex)
            {
                TextLogWriter("Exception => " + ex.Message);

                ObjPaymentGateWayDetail.OperationId = 3;
                ObjPaymentGateWayDetail.DonationId = Convert.ToInt32(_transactionId);
                ObjPaymentGateWayDetail.PopUpStatus = "Exception";
                ObjPaymentGateWayDetail.PopUpStatusMessage = "Exception => " + ex.Message + " --- " + "InnerException => " + ex.InnerException;
                obj_response = _IWebSiteDataDapperRepository.Execute_Donation_Transaction(ObjPaymentGateWayDetail);
            }
            _receiveHtml = _html;
            _receiveFileName = _SavedReceiptName;
            TextLogWriter("_receiveFileName => " + _receiveFileName);
        }

        private void ReceiptBodyFailure(DataSet DS, string exceptionmessgage = "", string _transactionId = "")
        {
            TextLogWriter("Calling ReceiptBodyFailure");
            string path = GenericConstants.DirectoryPath;
            string _html = "";
            string _SavedReceiptName = "";
            DataSet obj_response = null;
            try
            {
                ObjPaymentGateWayDetail.OperationId = 3;
                ObjPaymentGateWayDetail.DonationId = Convert.ToInt32(_transactionId);
                ObjPaymentGateWayDetail.PopUpStatus = "Pending";
                ObjPaymentGateWayDetail.EmailStatus = "Pending";
                obj_response = _IWebSiteDataDapperRepository.Execute_Donation_Transaction(ObjPaymentGateWayDetail);

                _html = @"
                <div style='border: 2px solid; border-radius:25px; font-family:Arial,Helvetica, sans-serif; ' id='invoicePrint'> 
                    <table style='font-size:smaller;width:100%'>
                        <tr>
                            <td style='text-align:left'> &nbsp; Hi {DonorName}, <br></td>
                        </tr>
                    </table>
                    <table style='font-size:smaller;width:100%;text-align:left'>
                        <tr>
                            <td>&nbsp; Your subscribed donation has failed due to {UserMessage}</td>
                        </tr> 
                    </table>				
                </div>";

                string _EmailBeforPara =
                 @"<div style='font-family:Arial,Helvetica, sans-serif;' id='email'>
                  <table style=width:100%;text-align:left'>
                    <tr><td><strong> Thank You for helping. </strong> </td></tr>
                    <tr><td></td></tr>
                    <tr><td> Hi {FullName}, </td></tr> 
                    <tr>
                    <td>
                    <p>Your subscribed donation has failed due to {UserMessage}<p>
                    </td>
                    </tr>
                    <tr><td>{EmailBody}</td></tr>
                    <tr><td></td></tr>
                    <tr><td>-Your friends at Sab Saath. </td></tr>
                    <tr><td></td></tr>
                  </table>                  
                  </div>";

                _html = _html.Replace("{DonorName}", DS.Tables[2].Rows[0]["FullName"].ToString());
                _html = _html.Replace("{UserMessage}", exceptionmessgage == "" ? DS.Tables[2].Rows[0]["UserMessage"].ToString() : exceptionmessgage);
                _EmailBeforPara = _EmailBeforPara.Replace("{FullName}", DS.Tables[2].Rows[0]["FullName"].ToString());
                _EmailBeforPara = _EmailBeforPara.Replace("{UserMessage}", exceptionmessgage == "" ? DS.Tables[2].Rows[0]["UserMessage"].ToString() : exceptionmessgage);
                if (DS.Tables[1] != null && DS.Tables[1].Rows.Count > 0)
                {
                    if (!String.IsNullOrEmpty(DS.Tables[1].Rows[0]["NextPostingDate"].ToString()))
                    {
                        _EmailBeforPara = _EmailBeforPara.Replace("{EmailBody}", "<p>Your next donation will be posted on " + Convert.ToDateTime(DS.Tables[1].Rows[0]["NextPostingDate"]).ToString("dd-MM-yyyy") + ". You can view and manage your subscription and notifications by logging in at <a href='www.sabsaath.org'>Sab Saath.</a></p>");
                    }
                    else
                    {
                        _EmailBeforPara = _EmailBeforPara.Replace("{EmailBody}", "&nbsp;");
                    }
                }
                else
                {
                    _EmailBeforPara = _EmailBeforPara.Replace("{EmailBody}", "");
                }


                if (!String.IsNullOrEmpty(DS.Tables[2].Rows[0]["EmailAddress"].ToString()))
                {
                    ////Generate Image Of Receipt 

                    TextLogWriter("Calling SendMail");
                    responseDetail = SendMail(DS.Tables[2].Rows[0]["EmailAddress"].ToString(), "Sab Saath Donation Failure", _EmailBeforPara, "", "wwwroot/UploadImages/DonationRecipet/" + _SavedReceiptName, _transactionId);

                    ObjPaymentGateWayDetail.OperationId = 3;
                    ObjPaymentGateWayDetail.DonationId = Convert.ToInt32(_transactionId);
                    ObjPaymentGateWayDetail.PopUpStatus = "Success";
                    DataSet obj_response1 = _IWebSiteDataDapperRepository.Execute_Donation_Transaction(ObjPaymentGateWayDetail);
                }
            }
            catch (Exception ex)
            {
                TextLogWriter("Exception => " + ex.Message);

                ObjPaymentGateWayDetail.OperationId = 3;
                ObjPaymentGateWayDetail.DonationId = Convert.ToInt32(_transactionId);
                ObjPaymentGateWayDetail.PopUpStatus = "Exception";
                ObjPaymentGateWayDetail.PopUpStatusMessage = "Exception => " + ex.Message + " --- " + "InnerException => " + ex.InnerException;
                obj_response = _IWebSiteDataDapperRepository.Execute_Donation_Transaction(ObjPaymentGateWayDetail);
            }
        }

        public void TextLogWriter(string sText)
        {
            try
            {
                string ProcessPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                FileInfo fileInfo = new FileInfo(ProcessPath);
                string CurrentPath = fileInfo.DirectoryName + "\\Logs\\" + System.DateTime.Now.ToString("ddMMyyyy") + "\\" + System.DateTime.Now.ToString("ddMMyyyyHH") + ".log";
                string directoryLog = fileInfo.DirectoryName + "\\Logs\\" + System.DateTime.Now.ToString("ddMMyyyy");
                if (!Directory.Exists(directoryLog))
                {
                    Directory.CreateDirectory(directoryLog);
                }
                if (!File.Exists(CurrentPath))
                {
                    File.Create(CurrentPath).Close();
                }
                StreamWriter logWriter = new StreamWriter(CurrentPath, true);
                logWriter.WriteLine(System.DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + "|" + sText);
                logWriter.Close();
            }
            catch (Exception)
            {
            }
        }
        public dynamic SendMail(string to, string subject, string msg, string cc, string Attachment, string _transactionId = "")
        {
            MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
            DataSet obj_response = null;
            try
            {
                if (string.IsNullOrEmpty(to) == false)
                {
                    if (GenericConstants._SenderEmailSMTP != "" && GenericConstants._SenderEmail != "" && GenericConstants._SenderEmailPort != "")
                    {
                        MailMessage message = new MailMessage();
                        string[] addresses = to.Split(';');
                        foreach (string address in addresses)
                        {
                            if (!string.IsNullOrEmpty(address))
                            {
                                message.To.Add(new MailAddress(address));
                            }
                        }
                        if (!string.IsNullOrEmpty(cc))
                        {
                            string[] cc_address = cc.Split(';');
                            if (cc_address != null)
                            {
                                foreach (string address in cc_address)
                                {
                                    if (!string.IsNullOrEmpty(address))
                                    {
                                        message.CC.Add(new MailAddress(address));
                                    }
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(Attachment))
                        {
                            string[] Attachment_ = Attachment.Split(';');
                            if (Attachment_ != null)
                            {
                                foreach (string file in Attachment_)
                                {
                                    if (!string.IsNullOrEmpty(file))
                                    {
                                        if (File.Exists(file))
                                        {
                                            System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(file);
                                            message.Attachments.Add(attach);
                                        }
                                    }
                                }
                            }
                        }

                        message.From = new MailAddress(GenericConstants._SenderEmail, "Sab Saath");
                        message.Subject = subject;
                        message.Body = msg;
                        message.IsBodyHtml = true;
                        SmtpClient client = new SmtpClient();
                        client.Port = Convert.ToInt32(GenericConstants._SenderEmailPort);
                        client.Host = GenericConstants._SenderEmailSMTP;
                        System.Net.NetworkCredential objNetworkCredential = new System.Net.NetworkCredential(GenericConstants._SenderEmail, GenericConstants._SenderEmailPassword);
                        client.EnableSsl = Convert.ToBoolean(GenericConstants._SenderEmailSsl);
                        client.UseDefaultCredentials = false;
                        client.Credentials = objNetworkCredential;
                        client.Send(message);
                        TextLogWriter("Email Send Successfully");
                        ObjPaymentGateWayDetail.OperationId = 3;
                        ObjPaymentGateWayDetail.DonationId = Convert.ToInt32(_transactionId);
                        ObjPaymentGateWayDetail.EmailStatus = "Success";
                        obj_response = _IWebSiteDataDapperRepository.Execute_Donation_Transaction(ObjPaymentGateWayDetail);
                        return responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, "Email Send Successfully");
                    }
                    else
                    {
                        TextLogWriter("Email Could Not Send");
                        responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Success, ResponseMessages.Success, "Email Could Not Send");
                    }
                }
                else
                {
                    TextLogWriter("Failed To Email is Missing");
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Success, ResponseMessages.Success, "Failed To Email is Missing");
                }
            }
            catch (SmtpFailedRecipientException ex)
            {
                TextLogWriter("SmtpFailedRecipientException => " + ex.Message);
                TextLogWriter("InnerException => " + ex.InnerException);

                ObjPaymentGateWayDetail.OperationId = 3;
                ObjPaymentGateWayDetail.DonationId = Convert.ToInt32(_transactionId);
                ObjPaymentGateWayDetail.EmailStatus = "Exception";
                ObjPaymentGateWayDetail.EmailStatusMessage = "SmtpFailedRecipientException => " + ex.Message + " --- " + "InnerException => " + ex.InnerException;
                obj_response = _IWebSiteDataDapperRepository.Execute_Donation_Transaction(ObjPaymentGateWayDetail);

                responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Success, ResponseMessages.Success, "Email failed");
            }
            catch (SmtpException ex)
            {
                TextLogWriter("SmtpException => " + ex.Message);
                TextLogWriter("InnerException => " + ex.InnerException);

                ObjPaymentGateWayDetail.OperationId = 3;
                ObjPaymentGateWayDetail.DonationId = Convert.ToInt32(_transactionId);
                ObjPaymentGateWayDetail.EmailStatus = "Exception";
                ObjPaymentGateWayDetail.EmailStatusMessage = "SmtpException => " + ex.Message + " --- " + "InnerException => " + ex.InnerException;
                obj_response = _IWebSiteDataDapperRepository.Execute_Donation_Transaction(ObjPaymentGateWayDetail);

                responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Success, ResponseMessages.Success, "Email failed");
            }
            catch (Exception ex)
            {
                TextLogWriter("Exception => " + ex.Message);
                TextLogWriter("InnerException => " + ex.InnerException);

                ObjPaymentGateWayDetail.OperationId = 3;
                ObjPaymentGateWayDetail.DonationId = Convert.ToInt32(_transactionId);
                ObjPaymentGateWayDetail.EmailStatus = "Exception";
                ObjPaymentGateWayDetail.EmailStatusMessage = "Exception => " + ex.Message + " --- " + "InnerException => " + ex.InnerException;
                obj_response = _IWebSiteDataDapperRepository.Execute_Donation_Transaction(ObjPaymentGateWayDetail);

                responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Success, ResponseMessages.Success, "Email failed");
            }
            return responseDetail;
        }
        public dynamic USP_Get_Receipt_Data(string TransactionId, string UserIp)
        {
            try
            {
                dynamic _ResultData;
                string _Html = "";

                TextLogWriter("******************* Start *******************");
                TextLogWriter("TransactionId => " + TransactionId);
                DataSet obj_response = _IWebSiteDataDapperRepository.Get_Payment_Receipt_Data(TransactionId);
                string _ReceiveHtml = "";
                string _ReceiveFileName = "";
                bool _IsFileGenerated = false;

                if (obj_response != null && obj_response.Tables[0].Rows.Count > 0)
                {
                    TextLogWriter("obj_response != null");

                    ReceiptBody(obj_response, out _ReceiveHtml, out _ReceiveFileName, out _IsFileGenerated, TransactionId);

                    _ResultData = new
                    {
                        FullName = obj_response.Tables[0].Rows[0]["FullName"].ToString()
                        ,
                        TransactionDate = obj_response.Tables[0].Rows[0]["TransactionDate"].ToString()
                        ,
                        TransactionId = obj_response.Tables[0].Rows[0]["TransactionId"].ToString()
                        ,
                        Amount = Convert.ToDecimal(obj_response.Tables[0].Rows[0]["Amount"])
                        ,
                        ExchangeRate = Convert.ToDecimal(obj_response.Tables[0].Rows[0]["ExchangeRate"])
                        ,
                        TotalAmount = Convert.ToDecimal(obj_response.Tables[0].Rows[0]["TotalAmount"])
                        ,
                        CurrencyId = Convert.ToUInt64(obj_response.Tables[0].Rows[0]["CurrencyId"])
                        ,
                        CurrencyName = obj_response.Tables[0].Rows[0]["CurrencyName"].ToString()
                        ,
                        CurrencyCode = obj_response.Tables[0].Rows[0]["CurrencyCode"].ToString()
                        ,
                        Html = _ReceiveHtml
                        ,
                        CaseId = obj_response.Tables[0].Rows[0]["CaseId"].ToString()
                        ,
                        DownloadPathFile = GenericConstants.DirectoryPath + "DonationRecipet/" + _ReceiveFileName
                        ,
                        IsFileGenerated = _IsFileGenerated

                    };

                    DataSet _DsAttachmentSave = _IWebSiteDataDapperRepository.Save_Common_Document_Attachment(GenericConstants.SaveReceiptPath, UserIp, TransactionId, _ReceiveFileName);
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, _ResultData);
                }
                else
                {
                    if (obj_response != null && obj_response.Tables[2].Rows.Count > 0)
                    {
                        TextLogWriter("obj_response != null");

                        ReceiptBodyFailure(obj_response, UserIp, TransactionId);

                        responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                    }
                    else
                    {
                        TextLogWriter("obj_response = null");
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                    }
                }
                TextLogWriter("******************* End *******************");
                return responseDetail;
            }
            catch (Exception e)
            {
                TextLogWriter("Exception => " + e.Message);
                TextLogWriter("******************* End *******************");
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, e.Message);
            }
        }
        public dynamic usp_Active_ResolvedCases_web()
        {
            try
            {
                DataSet obj_response = _IWebSiteDataDapperRepository.usp_Active_ResolvedCases_web();
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception e)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic usp_DonationCheckOut_web(DonationCheckOut obj)
        {
            try
            {
                dynamic obj_response = _IWebSiteDataDapperRepository.usp_DonationCheckOut_web(obj);
                if (obj_response != null)
                {

                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                    var response = responseDetail.Data[0];
                    string val = ((object[])((System.Collections.Generic.IDictionary<string, object>)response).Values)[0].ToString();
                    if (val == "1")
                    {
                        responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                    }
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public DataSet usp_Food_GetReliefDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _IWebSiteDataDapperRepository.usp_Food_GetReliefDetails();
            }
            catch
            {
                //return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
            return ds;
        }
        public DataSet usp_GetRamzanCampaignDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _IWebSiteDataDapperRepository.usp_GetRamzanCampaignDetails();
            }
            catch
            {
                //return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
            return ds;
        }
        public DataSet usp_GetFeaturedNGOsDetails(FeaturedNGOsDetails obj)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _IWebSiteDataDapperRepository.usp_GetFeaturedNGOsDetails(obj);
            }
            catch
            {
                //return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
            return ds;
        }
        public DataSet usp_GetSuccessStories()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _IWebSiteDataDapperRepository.usp_GetSuccessStories();
            }
            catch
            {
                //return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
            return ds;
        }
        public DataSet usp_GetCaseoftheDay()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _IWebSiteDataDapperRepository.usp_GetCaseoftheDay();
            }
            catch
            {
                //return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
            return ds;
        }
        public DataSet usp_GetBlogs()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _IWebSiteDataDapperRepository.usp_GetBlogs();
            }
            catch
            {
                //return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
            return ds;
        }
        public dynamic SP_Crud_Blogs(Blogs obj)
        {
            try
            {
                DataSet obj_response = _IWebSiteDataDapperRepository.SP_Crud_Blogs(obj);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception e)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public DataSet sp_Crud_BlogsView(int OperationID, string BlogTitle, string BlogDesc)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _IWebSiteDataDapperRepository.sp_Crud_BlogsView(OperationID, BlogTitle, BlogDesc);
            }
            catch
            {
                //return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
            return ds;
        }
        public DataSet SP_Testimonials(Testimonials test)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _IWebSiteDataDapperRepository.SP_Testimonials(test);
            }
            catch
            {
                //return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
            return ds;
        }
        public dynamic Sp_Content_Upload(ContentsUploads obj, DataTable dt)
        {
            try
            {
                try
                {
                    DataSet obj_response = _IWebSiteDataDapperRepository.Sp_Content_Upload(obj, dt);
                    if (obj_response != null)
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                    }
                    else
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                    }

                }
                catch (Exception e)
                {
                    return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ResponseMessages.Exception);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }

        public DataSet Sp_Advertisement(Advertisement add)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _IWebSiteDataDapperRepository.Sp_Advertisement(add);
            }
            catch
            {
                //return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
            return ds;
        }
        public DataSet sp_Crud_Blogs_Delete(int OperationID, Int32 BlogsId)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _IWebSiteDataDapperRepository.sp_Crud_Blogs_Delete(OperationID, BlogsId);
            }
            catch
            {
                //return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
            return ds;
        }
        public DataSet SP_GetCompmay_BankDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _IWebSiteDataDapperRepository.SP_GetCompmay_BankDetails();
            }
            catch
            {
                //return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
            return ds;
        }
        public DataSet GetPayment_Configuration(int OperationId, Int32 caseid, string GuidId, string PayproTranscationId, string PayProRequestMessage, string PayproResponse, string PayproStatus, int ConfigId, string Toten, string Data, string PayproBankStatus)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _IWebSiteDataDapperRepository.GetPayment_Configuration(OperationId, caseid, GuidId, PayproTranscationId, PayProRequestMessage, PayproResponse, PayproStatus, ConfigId, Toten, Data, PayproBankStatus);
            }
            catch (Exception ex)
            {
                //return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
            return ds;
        }
        public dynamic DonationSubmit_CRM(Donar_CheckOut_CRM obj)
        {
            try
            {
                List<Donar_CheckOutDetail_CRM> objApplicantSupportData = new List<Donar_CheckOutDetail_CRM>();

                DataTable SupportData = null;
                dynamic SupportListData = null;

                if (obj.Donar_CheckOutDetail_CRM != null)
                    SupportListData = obj.Donar_CheckOutDetail_CRM.AsEnumerable().ToList();
                else
                    SupportListData = objApplicantSupportData.AsEnumerable().ToList();




                SupportData = CommonMethodHelper.ToDataTable(SupportListData);




                DataSet obj_response = _IWebSiteDataDapperRepository.DonationSubmit_CRM(obj, SupportData);

                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic Payment_Status_Mark(DonationCheckOut obj)
        {
            try
            {
                dynamic obj_response = _IWebSiteDataDapperRepository.Payment_Status_Mark(obj);
                if (obj_response != null)
                {

                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                    var response = responseDetail.Data[0];
                    string val = ((object[])((System.Collections.Generic.IDictionary<string, object>)response).Values)[0].ToString();
                    if (val == "1")
                    {
                        responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                    }
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic SueessStories_AfterApproved(SuccessStory obj)
        {
            try
            {
                try
                {
                    DataSet obj_response = _IWebSiteDataDapperRepository.SueessStories_AfterApproved(obj);
                    if (obj_response != null)
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                    }
                    else
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                    }

                }
                catch (Exception e)
                {
                    return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ResponseMessages.Exception);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic GetDataset_SuccessStories(SuccessStory obj)
        {
            try
            {
                try
                {
                    DataSet obj_response = _IWebSiteDataDapperRepository.GetDataset_SuccessStories(obj);
                    if (obj_response != null)
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                    }
                    else
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                    }

                }
                catch (Exception e)
                {
                    return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ResponseMessages.Exception);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic SubScribe_Email(string Email)
        {
            try
            {
                try
                {
                    DataSet obj_response = _IWebSiteDataDapperRepository.SubScribe_Email(Email);
                    if (obj_response != null)
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                    }
                    else
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                    }

                }
                catch (Exception e)
                {
                    return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ResponseMessages.Exception);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic CurrResponse(string ResCode, string Msg)
        {
            try
            {
                dynamic obj_response = "";//_IWebSiteDataDapperRepository.Payment_Status_Mark();
                if (ResCode == "00")
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, Msg);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure, Msg);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic sp_Get_CountryCode(string OperationId)
        {
            try
            {
                try
                {
                    DataSet obj_response = _IWebSiteDataDapperRepository.sp_Get_CountryCode(OperationId);
                    if (obj_response != null)
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                    }
                    else
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                    }

                }
                catch (Exception e)
                {
                    return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ResponseMessages.Exception);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }

        #region FastForex
        public dynamic Fast_Forex_Fetch_Only_One(string fromCurrency, string toCurrency)
        {
            try
            {
                dynamic _ObjResponse;
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync("https://api.fastforex.io/fetch-one?api_key=" + GenericConstants._FastForexAPIKey + "&from=" + fromCurrency + "&to=" + toCurrency + "").Result;
                if (response.IsSuccessStatusCode)
                {
                    _ObjResponse = response.Content.ReadAsStringAsync().Result.ToString();
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, _ObjResponse);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure, null);
                }


                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ex.Message);
            }
        }

        #endregion


        #region CheckOutWorking
        public MessageDate<dynamic> SP_Sab_Saath_Donation_Donor_Registration(PaymentGateWay ObjPaymentGateWay)
        {
            try
            {
                try
                {
                    DataSet obj_response = _IWebSiteDataDapperRepository.Execute_Donation_Donor_Register(ObjPaymentGateWay);
                    if (obj_response != null)
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                    }
                    else
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                    }

                }
                catch (Exception e)
                {
                    return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ResponseMessages.Exception);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public MessageDate<dynamic> SP_Sab_Saath_Mark_Donation_Transaction(PaymentGateWayDonationDetail ObjPaymentGateWayDetail)
        {
            try
            {
                try
                {
                    DataSet obj_response = _IWebSiteDataDapperRepository.Execute_Donation_Transaction(ObjPaymentGateWayDetail);
                    if (obj_response != null)
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                    }
                    else
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                    }

                }
                catch (Exception e)
                {
                    return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ResponseMessages.Exception);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public MessageDate<dynamic> SP_Sab_Saath_Donation_Transaction_Log(string Response_Request_Text, bool IsResponse, string ApiMethod, int DonationId, int UserId)
        {
            try
            {
                try
                {
                    DataSet obj_response = _IWebSiteDataDapperRepository.Execute_Donation_Transaction_Log(Response_Request_Text, IsResponse, ApiMethod, DonationId, UserId);
                    if (obj_response != null)
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                    }
                    else
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                    }

                }
                catch (Exception e)
                {
                    return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ResponseMessages.Exception);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public MessageDate<dynamic> GetAPITransactionId(int PayamentDetailId)
        {
            try
            {
                try
                {
                    string obj_response = _IWebSiteDataDapperRepository.GetApiTransactionId(PayamentDetailId);
                    if (obj_response != null)
                    {
                        responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                    }
                    else
                    {
                        responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                    }

                }
                catch (Exception e)
                {
                    return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public MessageDate<dynamic> GetDonorData(PaymentGateWay objPaymentGateWay)
        {
            try
            {
                try
                {
                    var obj_response = _IWebSiteDataDapperRepository.GetDonorData(objPaymentGateWay);
                    if (obj_response != null)
                    {
                        responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                    }
                    else
                    {
                        responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                    }

                }
                catch (Exception e)
                {
                    return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public string GetRequestPaymentResponse(int httpResponseCode)
        {

            string _Msg = "";

            switch (httpResponseCode)
            {
                case 200:
                    _Msg = "Payment retrieved successfully";
                    break;

                case 201:
                    _Msg = "Payment processed successfully";
                    break;
                case 202:
                    _Msg = "Payment asynchronous or further action required";
                    break;
                case 401:
                    _Msg = "Unauthorized";
                    break;
                case 404:
                    _Msg = "Payment not found";
                    break;
                case 422:
                    _Msg = "Invalid data was sent";
                    break;
                case 429:
                    _Msg = "Too many requests or duplicate request detected";
                    break;
                case 502:
                    _Msg = "Bad gateway";
                    break;
                default:
                    _Msg = "No Msg";
                    break;
            }
            return _Msg;
        }
        public string GetRequestPaymentStatusCode(int StatusCode)
        {
            string _Msg = "";
            switch (StatusCode)
            {
                case 0:
                    _Msg = "Active";
                    break;
                case 1:
                    _Msg = "Pending";
                    break;
                case 2:
                    _Msg = "Authorized";
                    break;
                case 3:
                    _Msg = "CardVerified";
                    break;
                case 4:
                    _Msg = "Voided";
                    break;
                case 5:
                    _Msg = "PartiallyCaptured";
                    break;
                case 6:
                    _Msg = "Captured";
                    break;
                case 7:
                    _Msg = "PartiallyRefunded";
                    break;
                case 8:
                    _Msg = "Refunded";
                    break;
                case 9:
                    _Msg = "Declined";
                    break;
                case 10:
                    _Msg = "Canceled";
                    break;
                case 11:
                    _Msg = "Expired";
                    break;
                case 12:
                    _Msg = "Requested";
                    break;
                case 13:
                    _Msg = "Paid";
                    break;
                default:
                    _Msg = "";
                    break;
            }
            return _Msg;
        }

        #endregion

        public dynamic Donor_WebSite_Register(DonorWebSite_Register obj)
        {
            try
            {
                DataSet obj_response = _IWebSiteDataDapperRepository.Donor_WebSite_Register(obj);

                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public MessageDate<dynamic> SP_Sab_Saath_Subscription(PaymentGateWay obj, string status, int paymentId)
        {
            try
            {
                try
                {
                    var obj_response = _IWebSiteDataDapperRepository.Save_Update_Subscruption(obj, status, paymentId);
                    if (obj_response != null)
                    {
                        responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                    }
                    else
                    {
                        responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                    }

                }
                catch (Exception e)
                {
                    return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic Get_Profile_Data(UserProfile_Update obj)
        {
            try
            {
                DataSet obj_response = _IWebSiteDataDapperRepository.Get_Profile_Data(obj);

                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic Managed_EmailNotifications(ManagedEmail_Notification obj)
        {
            try
            {
                DataSet obj_response = _IWebSiteDataDapperRepository.Managed_EmailNotifications(obj);

                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
    }
}
