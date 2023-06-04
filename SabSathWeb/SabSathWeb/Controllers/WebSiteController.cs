using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SabSath.Application.Repositiories;
using SabSath.Core.Models;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System;
using Microsoft.AspNetCore.Http;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Text;
using SabSath.Core.Utilities;
using Checkout;
using Checkout.Previous;
using Checkout.Common;
using Checkout.Payments;
using Checkout.Payments.Previous.Request;
using Checkout.Payments.Previous.Request.Source;
using Checkout.Payments.Previous.Response;


namespace SabSathWeb.Controllers
{
    [EnableCors("Security")]
    [Route("api/[controller]")]
    [ApiController]
    public class WebSiteController : ControllerBase
    {
        private readonly IWebSiteService _IWebSiteService;
        public IHostingEnvironment hostingEnvironment;

        //  protected readonly SabSath.Core.Models.GatewayApiRequest gatewayApiClient;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objIWebSiteService"></param>
        /// <param name="hostingenv"></param>
        public WebSiteController(IWebSiteService objIWebSiteService, IHostingEnvironment hostingenv)
        {
            _IWebSiteService = objIWebSiteService;
            hostingEnvironment = hostingenv;
        }
        //
        //OK
        [HttpPost("usp_DonationCategories_web")]
        public string usp_DonationCategories_web(int? ApplicantCaseid)
        {
            var response = _IWebSiteService.usp_DonationCategories_web(ApplicantCaseid);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("usp_Active_ResolvedCases_web")]
        public string usp_Active_ResolvedCases_web()
        {
            var response = _IWebSiteService.usp_Active_ResolvedCases_web();
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("SP_ContactUs")]
        public string SP_ContactUs(ContactUS obj)
        {
            //List<object> listobj = new List<object>();
            //listobj.Add(obj);
            //DataTable dt = SabSath.Application.Helper.CommonMethodHelper.DynamicListToDataTable(listobj.ToList());


            List<ContactUS_Comments> objContactUS_Comments = new List<ContactUS_Comments>();
            DataTable dtContactUS_Comments = null;
            dynamic SupportListData = null;
            if (obj.ContactUS_Comments != null)
                SupportListData = obj.ContactUS_Comments.AsEnumerable().ToList();
            else
                SupportListData = objContactUS_Comments.AsEnumerable().ToList();
            dtContactUS_Comments = SabSath.Application.Helper.CommonMethodHelper.ToDataTable(SupportListData);


            var response = _IWebSiteService.SP_ContactUs(obj, dtContactUS_Comments); 
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("usp_DonationCheckOut_web")]
        public JsonResult usp_DonationCheckOut_web()
        {
            int PaymentListenum = (int)SabSath.Application.Helper.EnumHelper.Document_Type.PaymentSlip;
            try
            {
                DonationCheckOut objDon = new DonationCheckOut();

                var files = HttpContext.Request.Form.Files;
                string CaseDeschtml = "";
                var data = HttpContext.Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                foreach (var item in data)
                {
                    if (item.Key.Contains("body"))
                    {
                        CaseDeschtml = item.Value;
                    }
                }

                string fileStorePath = "";
                objDon.OperationID = CaseDeschtml.Split(',')[0].ToString();
                objDon.FirstName = CaseDeschtml.Split(',')[1].ToString();
                objDon.LastName = CaseDeschtml.Split(',')[2].ToString();
                objDon.EmailAddress = CaseDeschtml.Split(',')[3].ToString();
                objDon.ContactNo = CaseDeschtml.Split(',')[4].ToString();
                objDon.Address = CaseDeschtml.Split(',')[5].ToString();
                objDon.Countryid = CaseDeschtml.Split(',')[6].ToString();
                objDon.Amount = CaseDeschtml.Split(',')[7].ToString();
                objDon.DonationTypeid = CaseDeschtml.Split(',')[8].ToString();

                if (CaseDeschtml.Split(',')[9].ToString() != "0")
                    objDon.ApplicantCaseID = CaseDeschtml.Split(',')[9].ToString();
                else
                    objDon.ApplicantCaseID = null;

                objDon.Currencyid = CaseDeschtml.Split(',')[10].ToString();
                objDon.SubCategoryID = CaseDeschtml.Split(',')[11].ToString();
                objDon.qty = CaseDeschtml.Split(',')[12].ToString();
                objDon.CategoryID = CaseDeschtml.Split(',')[13].ToString();
                objDon.PaymentTypeID = CaseDeschtml.Split(',')[14].ToString();
                objDon.Bankid = CaseDeschtml.Split(',')[15].ToString();
                //objDon.CreatedByid = CaseDeschtml.Split(',')[16].ToString();
                objDon.userip = CaseDeschtml.Split(',')[17].ToString();
                foreach (var file in files)
                {
                    string datestring = DateTime.Now.ToString("ddMMyyyyhhmmss");
                    objDon.Document_Type = PaymentListenum.ToString();
                    objDon.fileSavePath = Path.Combine("/UploadImages");

                    objDon.FileName = file.FileName;
                    objDon.fileGeneratedName = datestring + "_" + file.FileName;
                    var FileSave = Path.Combine("", hostingEnvironment.ContentRootPath + "/wwwroot/UploadImages/" + file.FileName);
                    var renamefilepath = Path.Combine("", hostingEnvironment.ContentRootPath + "/wwwroot/UploadImages/");
                    using (var stream = new FileStream(FileSave, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    System.IO.File.Copy(FileSave, renamefilepath + objDon.fileGeneratedName);
                    System.IO.File.Delete(FileSave);

                }
                var response = _IWebSiteService.usp_DonationCheckOut_web(objDon);
                if (objDon == null)
                {
                    return null;
                }
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return new JsonResult(false);
            }
        }

        [HttpPost("usp_Food_GetReliefDetails")]
        public string usp_Food_GetReliefDetails()
        {
            var response = _IWebSiteService.usp_Food_GetReliefDetails();
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("usp_GetRamzanCampaignDetails")]
        public string usp_GetRamzanCampaignDetails()
        {
            var response = _IWebSiteService.usp_GetRamzanCampaignDetails();
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("usp_GetFeaturedNGOsDetails")]
        public string usp_GetFeaturedNGOsDetails(FeaturedNGOsDetails obj)
        {
            var response = _IWebSiteService.usp_GetFeaturedNGOsDetails(obj);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("usp_GetSuccessStories")]
        public string usp_GetSuccessStories()
        {
            var response = _IWebSiteService.usp_GetSuccessStories();
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("usp_GetCaseoftheDay")]
        public string usp_GetCaseoftheDay()
        {
            var response = _IWebSiteService.usp_GetCaseoftheDay();
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("usp_GetBlogs")]
        public string usp_GetBlogs()
        {
            var response = _IWebSiteService.usp_GetBlogs();
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("SP_Crud_Blogs")]
        public string SP_Crud_Blogs()
        {
            Blogs objDon = new Blogs();
            var files = HttpContext.Request.Form.Files;
            //  string CaseDeschtml = "2,0,Blogtitle,desc,01-01-2022,02-02-2022,1,2,192.168";
            string CaseDeschtml = "";
            var data = HttpContext.Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            foreach (var item in data)
            {
                if (item.Key.Contains("body"))
                {
                    CaseDeschtml = item.Value;
                    objDon = JsonConvert.DeserializeObject<Blogs>(CaseDeschtml);

                }
            }


            string fileStorePath = "";
            objDon.ImageUrl = "/UploadImages";

            foreach (var file in files)
            {
                string datestring = DateTime.Now.ToString("ddMMyyyyhhmmss");
                objDon.FileName = datestring + "_" + file.FileName;
                objDon.orignalFileName = file.FileName;
                var FileSave = Path.Combine("", hostingEnvironment.ContentRootPath + "/wwwroot/UploadImages/" + file.FileName);
                var renamefilepath = Path.Combine("", hostingEnvironment.ContentRootPath + "/wwwroot/UploadImages/");
                using (var stream = new FileStream(FileSave, FileMode.Create))
                {
                    file.CopyTo(stream);

                }
                System.IO.File.Copy(FileSave, renamefilepath + datestring + "_" + file.FileName);
                System.IO.File.Delete(FileSave);
            }
            var response = _IWebSiteService.SP_Crud_Blogs(objDon);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;

        }

        [HttpPost("sp_Crud_BlogsView")]
        public string sp_Crud_BlogsView(int OperationID, string BlogTitle, string BlogDesc)
        {
            var response = _IWebSiteService.sp_Crud_BlogsView(OperationID, BlogTitle, BlogDesc);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("sp_Crud_Blogs_Delete")]
        public string sp_Crud_Blogs_Delete(int OperationID, Int32 Blogsid)
        {
            var response = _IWebSiteService.sp_Crud_Blogs_Delete(OperationID, Blogsid);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("SP_Testimonials")]
        public string SP_Testimonials(Testimonials test)
        {
            var response = _IWebSiteService.SP_Testimonials(test);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("Sp_Advertisement")]
        public string Sp_Advertisement(Advertisement add)
        {
            var response = _IWebSiteService.Sp_Advertisement(add);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("SP_GetCompmay_BankDetails")]
        public string SP_GetCompmay_BankDetails()
        {
            var response = _IWebSiteService.SP_GetCompmay_BankDetails();
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        [HttpPost("Payment_GatwWay_API")]
        public string Payment_GatwWay_API()
        {

            DonationCheckOut ObjCheckout = new DonationCheckOut();
            string json;
            json = PaymentGatWay_ALFalaha_Method(ObjCheckout);
            return json;
        }
        public string Toten_Authorization(string ClientId, string clientsecret, string AuthAPIURL, string GuidId)
        {
            string Tokenstr = "";
            try
            {
                WebClient client1 = new WebClient();
                List<object> listClient = new List<object>();
                listClient.Add(new { clientid = ClientId, clientsecret = clientsecret });
                var ClientListJson = JsonConvert.SerializeObject(listClient, Formatting.Indented);
                var jssonClient = ClientListJson.Substring(1, ClientListJson.Length - 2).Trim();
                client1.Headers.Add("Content-Type", "application/json");
                var APIRespone_Token = client1.UploadString(AuthAPIURL, jssonClient);
                Tokenstr = client1.ResponseHeaders.GetValues("Token")[0]; //Get Token for authorization
                client1.Dispose();
            }
            catch (Exception ex)
            {
                _IWebSiteService.GetPayment_Configuration(4, Convert.ToInt32(0), GuidId, "0", ex.Message, "Token Generated Exception", "0", 0, "0", "0", "0");
                Tokenstr = "Token Generated Error";
            }

            return Tokenstr;
        }
        public string PaymentGatWay_Method(DonationCheckOut ObjCheckout)
        {
            string json = "";
            try
            {
                string CaseDeschtml = "";
                var data = HttpContext.Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                foreach (var item in data)
                {
                    if (item.Key.Contains("Data"))
                    {
                        CaseDeschtml = item.Value;
                        ObjCheckout = JsonConvert.DeserializeObject<DonationCheckOut>(CaseDeschtml);
                    }
                }
                // if (ObjCheckout.Amount  != "" && ObjCheckout.FirstName != "" && ObjCheckout.LastName != "" && ObjCheckout.ContactNo != "" && ObjCheckout.EmailAddress != "")
                //{
                //CURRENCY BLOCK 
                string CurrencyISO = ObjCheckout.CurrencyName.Split("-")[1].Trim();
                //decimal ConvertAmount = 0;
                //if (ObjCheckout.CurrencyName != "Pakistani Rupee - PKR")
                //{
                //string CurrencyISO = ObjCheckout.CurrencyName.Split("-")[1].Trim();
                //string CurrSymbol = CurrencyISO + "_PKR&compact=ultra&apiKey=35e1f8c7d558ce73b005";
                //String apiConverter = "https://free.currconv.com/api/v7/convert?q=" + CurrSymbol;
                //using (var webClient = new WebClient())
                //{
                //    string Rate = "";
                //    var Currency_Json = webClient.DownloadString(apiConverter);
                //    if (Currency_Json != "{}")
                //    {
                //        List<object> listObj1 = new List<object>();
                //        listObj1.Add(Currency_Json);
                //        Rate = Currency_Json.Split(':')[1];

                //        decimal ExchangeRate = Convert.ToDecimal(Rate.Remove(Rate.Length - 2));
                //        ObjCheckout.CurrencyExchangeRate = ExchangeRate.ToString();
                //        ConvertAmount = ExchangeRate * Convert.ToDecimal(ObjCheckout.Amount);
                //        //ObjCheckout.CurrencyExchangeRate = ConvertRate.;
                //    }
                //    else
                //    {
                //        json = "Currency Api Error";
                //        return json;
                //    }
                //}
                //}
                //else
                //{
                //  ObjCheckout.CurrencyExchangeRate = "1";
                //  ConvertAmount = Convert.ToDecimal(ObjCheckout.Amount);
                //  }
                Guid objGudid = Guid.NewGuid();
                PayProAPI_Request obj = new PayProAPI_Request();
                obj.OrderNumber = objGudid.ToString();
                //obj.OrderAmount = ConvertAmount.ToString();
                obj.OrderDueDate = DateTime.Now.ToString("dd/MM/yyyy");
                obj.OrderType = "Service";
                obj.IssueDate = DateTime.Now.ToString("dd/MM/yyyy");
                obj.OrderExpireAfterSeconds = "0";
                obj.CustomerName = ObjCheckout.FirstName + " " + ObjCheckout.LastName;
                obj.CustomerMobile = "";
                obj.CustomerEmail = ObjCheckout.EmailAddress;
                obj.CustomerAddress = "";
                obj.IsConverted = "true";
                obj.Currency = CurrencyISO;
                obj.CurrencyAmount = ObjCheckout.Amount;

                //Get Data for Api Configuration USER NAME URL E.g
                DataSet ds = _IWebSiteService.GetPayment_Configuration(1, Convert.ToInt32(ObjCheckout.ApplicantCaseID), objGudid.ToString(), "0", "", "", "", 0, "", "", "");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                    string ClientId = ds.Tables[0].Rows[0]["ClientId"].ToString();
                    string clientsecret = ds.Tables[0].Rows[0]["ClientSecret"].ToString();
                    string APIURL = ds.Tables[0].Rows[0]["APIURL"].ToString();
                    string AuthAPIURL = ds.Tables[0].Rows[0]["APIAuthorizationURL"].ToString();
                    //string Token = ds.Tables[0].Rows[0]["Token"].ToString();
                    int ConfigId = Convert.ToInt32(ds.Tables[0].Rows[0]["PaymentApIConfigId"].ToString());
                    var marchentid = new { MerchantId = UserName };  //API UserName

                    List<object> listObj = new List<object>();
                    listObj.Add(marchentid);
                    listObj.Add(obj);

                    var jsonPaymentSave = JsonConvert.SerializeObject(ObjCheckout);
                    var jsonOrder = JsonConvert.SerializeObject(listObj);

                    //Get Token for PayPro
                    string GetToen = Toten_Authorization(ClientId, clientsecret, AuthAPIURL, objGudid.ToString());
                    if (GetToen != "Token Generated Error")
                    {
                        ds = _IWebSiteService.GetPayment_Configuration(2, Convert.ToInt32(ObjCheckout.ApplicantCaseID), objGudid.ToString(), "0", jsonOrder, "", "Toekn Generated", 0, "", "", "");
                        var APIresponse = "";
                        try
                        {
                            //string baseUrl = APIURL; //"https://demoapi.paypro.com.pk/v2/";
                            WebClient client = new WebClient();
                            client.Headers.Add("Token", GetToen);
                            APIresponse = client.UploadString(APIURL, jsonOrder);
                        }
                        catch (Exception ex)
                        {
                            ds = _IWebSiteService.GetPayment_Configuration(4, Convert.ToInt32(ObjCheckout.ApplicantCaseID), objGudid.ToString(), "0", "", ex.Message.ToString(), "Exception", ConfigId, "", "", "");
                            json = ex.Message;
                            return json;
                        }
                        var model = JsonConvert.DeserializeObject<List<PayPro_ResponseViewModel>>(APIresponse);
                        SendResponse objsRes = new SendResponse();
                        if (model != null)
                        {
                            if (model[0].Status == "00") //API Response  Success
                            {
                                ObjCheckout.CurrencyExchangeRate = model[1].ConvertionRate;
                                ds = _IWebSiteService.GetPayment_Configuration(4, Convert.ToInt32(ObjCheckout.ApplicantCaseID), objGudid.ToString(), model[1].PayProId, "", APIresponse, model[0].Status, 0, "", jsonPaymentSave, "");
                                objsRes.Status = model[0].Status;
                                objsRes.Description = model[1].Description;
                                objsRes.Click2PayURL = model[1].Click2Pay;
                                json = JsonConvert.SerializeObject(objsRes, Formatting.Indented);
                            }
                            else
                            {
                                ds = _IWebSiteService.GetPayment_Configuration(4, Convert.ToInt32(ObjCheckout.ApplicantCaseID), objGudid.ToString(), "0", "", APIresponse, model[0].Status, 0, "", "", "");
                                objsRes.Status = model[0].Status;
                                objsRes.Description = model[1].Description;
                                objsRes.Click2PayURL = model[1].Click2Pay;
                                json = JsonConvert.SerializeObject(objsRes, Formatting.Indented);
                            }
                        }
                        else //AP Failure
                        {
                            ds = _IWebSiteService.GetPayment_Configuration(4, Convert.ToInt32(ObjCheckout.ApplicantCaseID), objGudid.ToString(), "0", "", "no response for model Empty", model[0].Status, 0, "", "", "");
                            json = "Mo Response for model Empty";
                        }
                    }
                    else
                    {
                        ds = _IWebSiteService.GetPayment_Configuration(4, Convert.ToInt32(ObjCheckout.ApplicantCaseID), objGudid.ToString(), "0", "", "Token Generated Error", "", 0, "", "", "");
                        json = "Token Generated Error";
                    }
                }
                //}
                //else
                //{
                //    json = "Please fill all fields";
                //}
            }
            catch (Exception ex)
            {
                _IWebSiteService.GetPayment_Configuration(4, Convert.ToInt32(ObjCheckout.ApplicantCaseID), "0", "0", ex.Message.ToString(), "", "LastCastch Exception", 0, "", "", "");
                json = ex.Message;
            }
            return json;
        }

        [HttpPost("DonationSubmit_WEB")] //ok
        public JsonResult usp_DonationCheckOut()
        {
            int PaymentListenum = (int)SabSath.Application.Helper.EnumHelper.Document_Type.PaymentSlip;
            try
            {
                DonationCheckOut objDon = new DonationCheckOut();

                var files = HttpContext.Request.Form.Files;
                string CaseDeschtml = "";
                var data = HttpContext.Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                foreach (var item in data)
                {
                    if (item.Key.Contains("Data"))
                    {
                        CaseDeschtml = item.Value;
                        objDon = JsonConvert.DeserializeObject<DonationCheckOut>(CaseDeschtml);

                    }
                }

                string fileStorePath = "";
                foreach (var file in files)
                {
                    string datestring = DateTime.Now.ToString("ddMMyyyyhhmmss");
                    objDon.Document_Type = PaymentListenum.ToString();
                    objDon.fileSavePath = Path.Combine("/UploadImages");

                    objDon.FileName = file.FileName;
                    objDon.fileGeneratedName = datestring + "_" + file.FileName;
                    var FileSave = Path.Combine("", hostingEnvironment.ContentRootPath + "/wwwroot/UploadImages/" + file.FileName);
                    var renamefilepath = Path.Combine("", hostingEnvironment.ContentRootPath + "/wwwroot/UploadImages/");
                    using (var stream = new FileStream(FileSave, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    System.IO.File.Copy(FileSave, renamefilepath + objDon.fileGeneratedName);
                    System.IO.File.Delete(FileSave);

                }
                objDon.CurrencyExchangeRate = "1";
                var response = _IWebSiteService.usp_DonationCheckOut_web(objDon);
                if (objDon == null)
                {
                    return null;
                }
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return new JsonResult(false);
            }
        }

        [HttpPost("Payment_Status_Mark")]
        public JsonResult Payment_Status_Mark(PaymentMarsStatus objStatus)
        {
            DonationCheckOut obj = new DonationCheckOut();
            string[] statusArray = new string[10];
            statusArray = objStatus.URLStatus.Split("%");
            string StatusMsg = statusArray[0].Split("=")[1].Split("&")[0].ToString();

            string Orderid = "";
            //var response = "";
            if (StatusMsg == "Success")
            {
                Orderid = statusArray[4].Split("=")[1].ToString();
                DataSet ds = _IWebSiteService.GetPayment_Configuration(5, Convert.ToInt32(0), "", Orderid, "", "", "", 0, "", "", "");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string paymentSavedata = ds.Tables[0].Rows[0]["PaymentData"].ToString();
                    obj = JsonConvert.DeserializeObject<DonationCheckOut>(paymentSavedata);
                    obj.PayProTranscationID = Orderid;
                    var response = _IWebSiteService.Payment_Status_Mark(obj); //
                    _IWebSiteService.GetPayment_Configuration(6, Convert.ToInt32(0), "", Orderid, "", "", "", 0, "", "", StatusMsg);
                }
            }
            else //Failure
            {
                Orderid = statusArray[8].Split("=")[1].ToString();
                _IWebSiteService.GetPayment_Configuration(6, Convert.ToInt32(0), "", Orderid, "", "", "", 0, "", "", StatusMsg);
            }
            string returnMsg = StatusMsg + '-' + Orderid;
            return new JsonResult(returnMsg);
        }

        [HttpPost("Payment_Status_Mark_Alfalaha")]
        public JsonResult Payment_Status_Mark_Alfalaha(PaymentMarsStatus objStatus)
        {
            //test
            string Orderid = "";
            string returnMsg = "";
            string StatusMsg = "";
            try
            {
                Save_Data_NotePadFile("-------------------------Start:-- Payment_Status_Mark_Alfalaha Method-----------------" + System.DateTime.Now.ToString());

                DonationCheckOut obj = new DonationCheckOut();
                string[] statusArray = new string[10];
                StatusMsg = objStatus.URLStatus.Split("=")[0].ToString();
                Save_Data_NotePadFile("StatusMsg:-- " + StatusMsg);
                //var response = "";
                if (StatusMsg == "completeCallback")
                {
                    Save_Data_NotePadFile("completeCallback:-- ");
                    Orderid = objStatus.URLStatus.Split("=")[1].ToString();
                    Save_Data_NotePadFile("completeCallback:-- " + Orderid);
                    DataSet ds = _IWebSiteService.GetPayment_Configuration(5, Convert.ToInt32(0), "", Orderid, "", "", "", 0, "", "", "");
                    Save_Data_NotePadFile("First ds:-- " + ds.Tables[0].Rows.Count);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        string paymentSavedata = ds.Tables[0].Rows[0]["PaymentData"].ToString();
                        Save_Data_NotePadFile("paymentSavedata:-- " + paymentSavedata);
                        obj = JsonConvert.DeserializeObject<DonationCheckOut>(paymentSavedata);
                        Save_Data_NotePadFile("Json Dserilized:--");
                        obj.PayProTranscationID = Orderid;
                        var response = _IWebSiteService.Payment_Status_Mark(obj);
                        Save_Data_NotePadFile("response:--");
                        _IWebSiteService.GetPayment_Configuration(6, Convert.ToInt32(0), "", Orderid, "", "", "", 0, "", "", StatusMsg);
                        Save_Data_NotePadFile("Successfully Status Mark:--" + StatusMsg);
                    }
                    else
                    {
                        StatusMsg = "Invalid Order id" + '-' + Orderid;
                        Save_Data_NotePadFile("Invalid Order id:--" + StatusMsg);
                    }
                }
                else //Failure
                {
                    Orderid = objStatus.URLStatus.Split("=")[1].ToString();
                    Save_Data_NotePadFile("Failure:--" + Orderid);
                    _IWebSiteService.GetPayment_Configuration(6, Convert.ToInt32(0), "", Orderid, "", "", "", 0, "", "", StatusMsg);
                    Save_Data_NotePadFile("Failure succssfully status mark:--" + Orderid + " " + StatusMsg);
                }

            }
            catch (Exception ex)
            {

                StatusMsg = ex.ToString() + '-' + Orderid;
                Save_Data_NotePadFile("Exception:--" + StatusMsg);
            }
            returnMsg = StatusMsg + '-' + Orderid;
            Save_Data_NotePadFile("Reurn Msg:--" + returnMsg);
            return new JsonResult(returnMsg);
        }

        [HttpPost("Get_Payment_Receipt_Data")]
        public string Get_Payment_Receipt_Data(PaymentMarsStatus TransactionId, string UserIp = "")
        {
            var response = _IWebSiteService.USP_Get_Receipt_Data(TransactionId.TransactionId, UserIp);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        public void Save_Data_NotePadFile(string val)
        {
            string applicationPath = Path.GetFullPath(System.AppDomain.CurrentDomain.BaseDirectory); // the directory that your program is installed in
            string saveFilePath = Path.Combine(applicationPath, "log.txt");
            StreamWriter w = new StreamWriter(saveFilePath, true);
            w.WriteLine(val);
            w.Close();

            //string text = val;
            //        System.IO.File.WriteAllText("D:\\Desktop 18_Aug_2022\\log.txt",  text);

        }

        //public JsonResult Payment_Status_Mark_Alfalaha_test(PaymentMarsStatus objStatus)
        //{
        //    DonationCheckOut obj = new DonationCheckOut();
        //    string[] statusArray = new string[10];
        //    // statusArray = objStatus.URLStatus.Split("=")[0].ToString();
        //    string StatusMsg = objStatus.URLStatus.Split("=")[0].ToString();
        //    //string orderid = objStatus.URLStatus.Split("=")[].ToString();

        //    string Orderid = "";
        //    //var response = "";
        //    if (StatusMsg == "completeCallback")
        //    {
        //        Orderid = objStatus.URLStatus.Split("=")[1].ToString();
        //        //DataSet ds = _IWebSiteService.GetPayment_Configuration(5, Convert.ToInt32(0), "", Orderid, "", "", "", 0, "", "", "");
        //        //if (ds.Tables[0].Rows.Count > 0)
        //        //{
        //            //string paymentSavedata = ds.Tables[0].Rows[0]["PaymentData"].ToString();
        //            //obj = JsonConvert.DeserializeObject<DonationCheckOut>(paymentSavedata);
        //            obj.PayProTranscationID = Orderid;
        //           // var response = _IWebSiteService.Payment_Status_Mark(obj); //
        //            _IWebSiteService.GetPayment_Configuration(6, Convert.ToInt32(0), "", Orderid, "", "", "", 0, "", "", StatusMsg); //Donor Master Update Status
        //        //}
        //        //else
        //        //{
        //        //    StatusMsg = "Invalid Order id";
        //        //}
        //    }
        //    else //Failure
        //    {
        //        Orderid = objStatus.URLStatus.Split("=")[1].ToString();
        //        _IWebSiteService.GetPayment_Configuration(6, Convert.ToInt32(0), "", Orderid, "", "", "", 0, "", "", StatusMsg);
        //    }
        //    string returnMsg = StatusMsg + '-' + Orderid;
        //    return new JsonResult(returnMsg);
        //}

        [HttpPost("Payment_Status_Mark_Test")]
        public JsonResult Payment_Status_Mark_Test(PaymentMarsStatus objStatus)
        {
            DonationCheckOut obj = new DonationCheckOut();
            string[] statusArray = new string[10];
            //    statusArray = objStatus.URLStatus.Split("%");
            //   string StatusMsg = statusArray[0].Split("=")[1].Split("&")[0].ToString();
            string StatusMsg = "Success";
            string Orderid = "";
            //var response = "";
            if (StatusMsg == "Success")
            {
                Orderid = "09522214700002";//statusArray[4].Split("=")[1].ToString();
                DataSet ds = _IWebSiteService.GetPayment_Configuration(5, Convert.ToInt32(0), "", Orderid, "", "", "", 0, "", "", "");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string paymentSavedata = ds.Tables[0].Rows[0]["PaymentData"].ToString();
                    obj = JsonConvert.DeserializeObject<DonationCheckOut>(paymentSavedata);
                    obj.PayProTranscationID = Orderid;
                    var response = _IWebSiteService.Payment_Status_Mark(obj); //
                    _IWebSiteService.GetPayment_Configuration(6, Convert.ToInt32(0), "", Orderid, "", "", "", 0, "", "", "Success");
                }
            }
            else //Failure
            {
                Orderid = statusArray[8].Split("=")[1].ToString();
                _IWebSiteService.GetPayment_Configuration(6, Convert.ToInt32(0), "", Orderid, "", "", "", 0, "", "", StatusMsg);
            }
            string returnMsg = StatusMsg + '-' + Orderid;
            return new JsonResult(returnMsg);
        }

        [HttpPost("SueessStories_AfterApproved")]
        public string SueessStories_AfterApproved()
        {
            SuccessStory objDon = new SuccessStory();
            var files = HttpContext.Request.Form.Files;
            var data = HttpContext.Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            string CaseDeschtml = "";

            foreach (var item in data)
            {

                if (item.Key.Contains("OperationID"))
                {
                    objDon.OperationId = Convert.ToInt32(item.Value);
                }
                else if (item.Key.Contains("CaseofApplicant"))
                {
                    objDon.caseid = Convert.ToInt32(item.Value);
                }

                else if (item.Key.Contains("CaseTitle"))
                {
                    objDon.Title = item.Value;
                }
                else if (item.Key.Contains("caseDesc"))
                {
                    objDon.Desc = item.Value;
                }

                else if (item.Key.Contains("UserId"))
                {
                    objDon.CreatedBy = item.Value;
                }

                else if (item.Key.Contains("UserIP"))
                {
                    objDon.Userip = item.Value;
                }
                else if (item.Key.Contains("ShortDesc"))
                {
                    objDon.ShortDesc = item.Value;
                }

                else if (item.Key.Contains("CheckCaseShow"))
                {
                    objDon.CheckCaseShow = item.Value;
                }
            }

            string fileStorePath = "";
            objDon.ImageUrl = "/UploadImages";
            int marketingcasenum = (int)SabSath.Application.Helper.EnumHelper.Document_Type.SuccessStory;
            objDon.DocTypecasenum = marketingcasenum.ToString();
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    string datestring = DateTime.Now.ToString("ddMMyyyyhhmmss");
                    objDon.FileName = file.FileName;
                    objDon.FileGeneratedName = datestring + "_" + file.FileName;

                    var FileSave = Path.Combine("", hostingEnvironment.ContentRootPath + "/wwwroot/UploadImages/" + file.FileName);
                    var renamefilepath = Path.Combine("", hostingEnvironment.ContentRootPath + "/wwwroot/UploadImages/");
                    using (var stream = new FileStream(FileSave, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    System.IO.File.Copy(FileSave, renamefilepath + datestring + "_" + file.FileName);
                    System.IO.File.Delete(FileSave);
                }
            }
            var response = _IWebSiteService.SueessStories_AfterApproved(objDon);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("GetDataset_SuccessStories")]
        public string GetDataset_SuccessStories(SuccessStory obj)
        {
            if (obj == null)
            {
                return null;
            }
            obj.DocTypecasenum = Convert.ToString((int)SabSath.Application.Helper.EnumHelper.Document_Type.SuccessStory);
            var response = _IWebSiteService.GetDataset_SuccessStories(obj);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("GetCurrency_Value")]
        public string GetCurrency_Value(ExchangeRate obj1)
        {
            string Json = "";
            try
            {

                string CurrencyISO = obj1.Currency.Split("-")[1].Trim();

                if (obj1.Currency != "null")
                {
                    if (obj1.Currency != "Pakistani Rupee - PKR")
                    {
                        string fromCurr = CurrencyISO;
                        string tocurr = "+to+pkr";
                        using (var webClient = new WebClient())
                        {
                            string url = "https://www.google.com/search?q=" + fromCurr + tocurr;
                            var Currency_Json = webClient.DownloadString(url);

                            string jsonOrder = JsonConvert.SerializeObject(Currency_Json);
                            string[] strsplit = jsonOrder.Split("BNeawe iBp4i AP7Wnd");
                            string ExchangeRate = strsplit[2].Split("Pakistani Rupee")[0].Remove(0, 3).Trim();
                            var response = _IWebSiteService.CurrResponse("00", ExchangeRate);
                            Json = JsonConvert.SerializeObject(response, Formatting.Indented);
                            DataSet ds = _IWebSiteService.GetPayment_Configuration(7, Convert.ToInt32(0), "0", "0", fromCurr, ExchangeRate, ExchangeRate, 0, "", "", "");

                            //return Json;
                            //string CurrencyValue = val.Split("=")[1].Split("Pakistani Rupee")[0].Trim();
                        }
                    }
                    else
                    {
                        var response = _IWebSiteService.CurrResponse("00", "1");
                        Json = JsonConvert.SerializeObject(response, Formatting.Indented);
                        DataSet ds = _IWebSiteService.GetPayment_Configuration(7, Convert.ToInt32(0), "0", "PKR", response.Data, "", "", 0, "", "", "");
                    }
                }
                else
                {
                    var response = _IWebSiteService.CurrResponse("00", "0.0");
                    Json = JsonConvert.SerializeObject(response, Formatting.Indented);

                }

            }
            catch (Exception ex)
            {
                var response = _IWebSiteService.CurrResponse("01", ex.Message);
                Json = JsonConvert.SerializeObject(response, Formatting.Indented);

                //return Json;
            }
            return Json;
        }
        public string GetCurrency_Value_old(ExchangeRate obj1)
        {
            string CurrencyISO = obj1.Currency.Split("-")[1].Trim();
            decimal ExchangeRate = 0;
            string json = "";
            if (obj1.Currency != "null")
            {
                if (obj1.Currency != "Pakistani Rupee - PKR")
                {
                    Guid objGudid = Guid.NewGuid();
                    PayProAPI_Request obj = new PayProAPI_Request();
                    obj.OrderNumber = objGudid.ToString();
                    //obj.OrderAmount = ConvertAmount.ToString();
                    obj.OrderDueDate = DateTime.Now.ToString("dd/MM/yyyy");
                    obj.OrderType = "Service";
                    obj.IssueDate = DateTime.Now.ToString("dd/MM/yyyy");
                    obj.OrderExpireAfterSeconds = "0";
                    obj.CustomerName = "Null" + " " + "Null";
                    obj.CustomerMobile = "";
                    obj.CustomerEmail = "email@gmail.com";
                    obj.CustomerAddress = "10";
                    obj.IsConverted = "true";
                    obj.CurrencyAmount = "100";
                    obj.Currency = CurrencyISO;


                    //Get Data for Api Configuration USER NAME URL E.g
                    DataSet ds = _IWebSiteService.GetPayment_Configuration(1, Convert.ToInt32(0), objGudid.ToString(), "0", "", "", "", 0, "", "", "");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                        string ClientId = ds.Tables[0].Rows[0]["ClientId"].ToString();
                        string clientsecret = ds.Tables[0].Rows[0]["ClientSecret"].ToString();
                        string APIURL = ds.Tables[0].Rows[0]["APIURL"].ToString();
                        string AuthAPIURL = ds.Tables[0].Rows[0]["APIAuthorizationURL"].ToString();
                        //string Token = ds.Tables[0].Rows[0]["Token"].ToString();
                        int ConfigId = Convert.ToInt32(ds.Tables[0].Rows[0]["PaymentApIConfigId"].ToString());
                        var marchentid = new { MerchantId = UserName };  //API UserName

                        List<object> listObj = new List<object>();
                        listObj.Add(marchentid);
                        listObj.Add(obj);

                        //var jsonPaymentSave = JsonConvert.SerializeObject(ObjCheckout);
                        var jsonOrder = JsonConvert.SerializeObject(listObj);

                        //Get Token for PayPro
                        string GetToen = Toten_Authorization(ClientId, clientsecret, AuthAPIURL, objGudid.ToString());
                        if (GetToen != "Token Generated Error")
                        {
                            var APIresponse = "";
                            try
                            {
                                WebClient client = new WebClient();
                                client.Headers.Add("Token", GetToen);
                                APIresponse = client.UploadString(APIURL, jsonOrder);

                            }
                            catch (Exception ex)
                            {
                                json = ex.Message;
                                return json;
                            }
                            var model = JsonConvert.DeserializeObject<List<PayPro_ResponseViewModel>>(APIresponse);
                            SendResponse objsRes = new SendResponse();
                            if (model != null)
                            {
                                if (model[0].Status == "00") //API Response  Success
                                {
                                    string ExRate = model[1].ConvertionRate;
                                    var response = _IWebSiteService.CurrResponse("00", ExRate);
                                    json = JsonConvert.SerializeObject(response, Formatting.Indented);
                                    return json;
                                }
                                else
                                {

                                    string[] strsplit = APIresponse.Split(",");
                                    string[] Msg = strsplit[1].Split(":");
                                    string desc = Msg[1].ToString().Remove(0, 1);
                                    string ErrMsg = desc.Remove(desc.Length - 3);
                                    var response = _IWebSiteService.CurrResponse("01", ErrMsg);
                                    json = JsonConvert.SerializeObject(response, Formatting.Indented);
                                    return json;
                                }
                            }
                            else //AP Failure
                            {
                                string ErrMsg = "Mo Response for model Empty";
                                var response = _IWebSiteService.CurrResponse("01", ErrMsg);
                                json = JsonConvert.SerializeObject(response, Formatting.Indented);
                                return json;
                            }
                        }
                        else
                        {
                            string ErrMsg = "Token Generated Error";
                            var response = _IWebSiteService.CurrResponse("01", ErrMsg);
                            json = JsonConvert.SerializeObject(response, Formatting.Indented);
                            return json;
                        }
                    }
                }
                else
                {
                    var response = _IWebSiteService.CurrResponse("00", "1");
                    json = JsonConvert.SerializeObject(response, Formatting.Indented);
                    return json;
                }
            }
            return json;
        }

        [HttpPost("SubScribe_Email")]
        public string SubScribe_Email(string Email)
        {
            var response = _IWebSiteService.SubScribe_Email(Email);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("sp_Get_CountryCode")]
        public string sp_Get_CountryCode(string OperationId)
        {
            var response = _IWebSiteService.sp_Get_CountryCode(OperationId);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        public void EmailSend()
        {

        }
        private string GetJArrayValue(JObject yourJArray, string key)
        {
            foreach (KeyValuePair<string, JToken> keyValuePair in yourJArray)
            {
                if (key == keyValuePair.Key)
                {
                    return keyValuePair.Value.ToString();
                }
            }
            return "";
        }
        public string Get_Session_Authorization(string p_SessionURL, string p_UserName, string p_Password, string p_Orderid, string p_Currency)
        {
            string sessionid = "";
            string body = String.Empty;
            //live URL
            //HttpWebRequest request = WebRequest.Create("https://bankalfalah.gateway.mastercard.com/api/rest/version/53/merchant/ZAMANFOUNDAT/session") as HttpWebRequest;

            HttpWebRequest request = WebRequest.Create(p_SessionURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Host = "bankalfalah.gateway.mastercard.com";
            //request.Referer = "http://www.waqasurrehman.me/waqas/index.php";
            request.Accept = "application/json";
            //live 
            //string credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("merchant.ZAMANFOUNDAT:abcfdeeaaa1c3eb80c89d569a585482f"));
            string credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(p_UserName + ":" + p_Password));
            request.Headers.Add("Authorization", "Basic " + credentials);
            {
                _API objAPI = new _API();
                objAPI.apiOperation = "CREATE_CHECKOUT_SESSION";
                objAPI.interaction = new in_teraction();
                objAPI.interaction.operation = "PURCHASE";

                objAPI.order = new O_rder();
                objAPI.order.id = p_Orderid;//"1013333";
                objAPI.order.currency = "PKR";//p_Currency;//"PKR";
                string json = JsonConvert.SerializeObject(objAPI);

                // Create a byte array of the data we want to send
                byte[] utf8bytes = Encoding.UTF8.GetBytes(json);
                byte[] iso8859bytes = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("iso-8859-1"), utf8bytes);
                // Set the content length in the request headers
                request.ContentLength = iso8859bytes.Length;
                // Write request data
                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(iso8859bytes, 0, iso8859bytes.Length);
                }
            }
            // Get response
            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Get the response stream
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("iso-8859-1"));
                    body = reader.ReadToEnd();

                    var jsonData = JObject.Parse(body);
                    var sessionObj = GetJArrayValue(jsonData, "session");
                    sessionid = GetJArrayValue(JObject.Parse(sessionObj), "id");
                }
            }
            catch (WebException wex)
            {
                StreamReader reader = new StreamReader(wex.Response.GetResponseStream(), Encoding.GetEncoding("iso-8859-1"));
                body = reader.ReadToEnd();
                var jsonData = JObject.Parse(body);
                sessionid = GetJArrayValue(jsonData, "result");
                //sessionid = GetJArrayValue(JObject.Parse(sessionid), "result");
                var error = GetJArrayValue(jsonData, "error");
                sessionid = sessionid + "*" + GetJArrayValue(JObject.Parse(error), "cause");
            }
            return sessionid;
        }
        public string Payment_GatwWay_API_AlFalaha()
        {
            DonationCheckOut ObjCheckout = new DonationCheckOut();
            string json;
            json = PaymentGatWay_ALFalaha_Method(ObjCheckout);
            return json;
        }
        public string PaymentGatWay_ALFalaha_Method(DonationCheckOut ObjCheckout)
        {
            string json = "";
            try
            {
                string CaseDeschtml = "";
                var data = HttpContext.Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                foreach (var item in data)
                {
                    if (item.Key.Contains("Data"))
                    {
                        CaseDeschtml = item.Value;
                        ObjCheckout = JsonConvert.DeserializeObject<DonationCheckOut>(CaseDeschtml);
                    }
                }
                //CURRENCY BLOCK 
                string CurrencyISO = ObjCheckout.CurrencyName.Split("-")[1].Trim();
                DataSet ds = _IWebSiteService.GetPayment_Configuration(1, Convert.ToInt32(ObjCheckout.ApplicantCaseID), "0", "0", "", "", "", 0, "", "", "");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string Merchantid = ds.Tables[0].Rows[0]["Merchantid"].ToString();
                    string ApiKeyPassword = ds.Tables[0].Rows[0]["ApiPassword"].ToString();
                    string APISessionURL = ds.Tables[0].Rows[0]["APISession_URL"].ToString();
                    string APIRederictURL = ds.Tables[0].Rows[0]["APIRedirectURL"].ToString();
                    int ConfigId = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());


                    //Guid GuidOrderID = Guid.NewGuid();
                    string GuidOrderID = ObjCheckout.UniqueOrderId;
                    ObjCheckout.PayProTranscationID = GuidOrderID;

                    var jsonPaymentSave = JsonConvert.SerializeObject(ObjCheckout);

                    //get session id
                    string GetSessionID = Get_Session_Authorization(APISessionURL, Merchantid, ApiKeyPassword, ObjCheckout.UniqueOrderId, CurrencyISO);

                    if (GetSessionID.Split("*")[0] != "ERROR")
                    {
                        ds = _IWebSiteService.GetPayment_Configuration(2, Convert.ToInt32(ObjCheckout.ApplicantCaseID), GuidOrderID.ToString(), ObjCheckout.UniqueOrderId, "", "", "SessionID Generated", 0, "", jsonPaymentSave, "");
                        try
                        {
                            //APIRederictURL
                            json = "00 - " + GetSessionID + " - " + APIRederictURL;
                            //json = Gate_Way_API(GetSessionID, GuidOrderID.ToString(), GuidOrderID.ToString(), "10.00", "PKR", Merchantid, ApiKeyPassword , APIPAYURL , "5454545");
                        }
                        catch (Exception ex)
                        {
                            ds = _IWebSiteService.GetPayment_Configuration(4, Convert.ToInt32(ObjCheckout.ApplicantCaseID), GuidOrderID.ToString(), "0", "", ex.Message.ToString(), "Exception", ConfigId, "", "", "");
                            json = json = "01 - " + ex.Message + " - " + ex.Message;  //ex.Message;
                            return json;
                        }
                    }
                    else
                    {
                        ds = _IWebSiteService.GetPayment_Configuration(2, Convert.ToInt32(ObjCheckout.ApplicantCaseID), GuidOrderID.ToString(), "0", "", "", GetSessionID + "-Session", 0, "", "", "");
                        //json = "Session Generate Error";
                        json = json = "03 - " + GetSessionID.Split("*")[1] + " - " + "Session Generate Error";  //ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                _IWebSiteService.GetPayment_Configuration(4, Convert.ToInt32(ObjCheckout.ApplicantCaseID), "0", "0", ex.Message.ToString(), "", "LastCastch Exception", 0, "", "", "");
                json = json = "04 - " + ex.Message + " - " + ex.Message;  //ex.Message;
                // json = ex.Message;
            }

            return json;

        }
        public string Get_Payment_Receipt_Subscription(PaymentMarsStatus TransactionId, string UserIp = "")
        {
            var response = _IWebSiteService.USP_Get_Receipt_Data(TransactionId.TransactionId, UserIp);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }



        [HttpPost("DonationSubmit_CRM_Save")]
        public string DonationSubmit_CRM_Save()
        {
            string json = "";
            try
            {
                var files = HttpContext.Request.Form.Files;
                string CaseDeschtml = "";
                Donar_CheckOut_CRM obj = new Donar_CheckOut_CRM();
                var data = HttpContext.Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                foreach (var item in data)
                {
                    if (item.Key.Contains("body"))
                    {
                        CaseDeschtml = item.Value;
                        obj = JsonConvert.DeserializeObject<Donar_CheckOut_CRM>(CaseDeschtml);
                    }
                }


                obj.Donar_CheckOutDetail_CRM = new List<Donar_CheckOutDetail_CRM>();

                // obj.fileSavePath = "/UploadImages";
                List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG", ".JPEG", ".TIFF" };
                if (files != null && files.Count > 0)
                {

                    foreach (var file in files)
                    {
                        if (ImageExtensions.Contains(Path.GetExtension(file.FileName).ToUpperInvariant()))
                        {
                            string datestring = DateTime.Now.ToString("ddMMyyyyhhmmss");
                            var FileSave = Path.Combine("", hostingEnvironment.ContentRootPath + "/wwwroot/UploadImages/" + file.FileName);
                            var renamefilepath = Path.Combine("", hostingEnvironment.ContentRootPath + "/wwwroot/UploadImages/");
                            using (var stream = new FileStream(FileSave, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }
                            System.IO.File.Copy(FileSave, renamefilepath + datestring + "_" + file.FileName);
                            System.IO.File.Delete(FileSave);


                            Donar_CheckOutDetail_CRM objdet1 = new Donar_CheckOutDetail_CRM();
                            if (file.Name == "CashBookRecpt")
                            {
                                objdet1.DocTypeId = (int)SabSath.Application.Helper.EnumHelper.Document_Type.CashBook_Receipt;
                            }
                            else
                            {
                                objdet1.DocTypeId = (int)SabSath.Application.Helper.EnumHelper.Document_Type.BankDeposit_Receipt;
                            }
                            objdet1.FileName = file.FileName;
                            objdet1.DocAttachmentPath = "/UploadImages";
                            objdet1.FileGeneratedName = datestring + "_" + file.FileName;
                            objdet1.RelationId = 0;
                            objdet1.ID = 0;

                            obj.Donar_CheckOutDetail_CRM.Add(objdet1);

                        }
                        else
                        {
                            json = "Invalid image File";
                            return json;
                        }

                    }
                }
                var response = _IWebSiteService.DonationSubmit_CRM(obj);
                json = JsonConvert.SerializeObject(response, Formatting.Indented);
                return json;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("DonationSubmit_CRM")]
        public string DonationSubmit_CRM(Donar_CheckOut_CRM ObjDCo)
        {
            try
            {
                var response = _IWebSiteService.DonationSubmit_CRM(ObjDCo);
                string json = JsonConvert.SerializeObject(response, Formatting.Indented);
                return json;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #region Fast_Forex_API
        [HttpPost("Fast_Forex_Only_One")]
        public string Fast_Forex_Only_One(List<string> lstData)
        {
            var response = _IWebSiteService.Fast_Forex_Fetch_Only_One(lstData[0], lstData[1]);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;


        }

        #endregion

        #region CheckOut

        [HttpPost("GetDonor")]
        public string GetDonor(PaymentGateWay ObjPayment)
        {
            var response = _IWebSiteService.GetDonorData(ObjPayment);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("PayDonation")]
        public async Task<string> PayDonation(PaymentGateWay ObjPaymentGateWay)
        {
            MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
            int? _DonorMasterId = null;
            int? _DonationId = null;
            string _ExistingApiCustomerId = null;
            bool _FlagForPayment = false;
            string _ResponseCode = "";
            string Trx_Status = "";
            bool statuscode = false;
            string UserMessage = "";
            PaymentMarsStatus paymentMarsStatus = new PaymentMarsStatus();

            // Please refer to https://github.com/checkout/checkout-sdk-net on how to setup the SDK with OAuth
            try
            {
                #region Step1
                /****** This Step Use For Insert Data In Donor Master Both Cases Is Register Or Not *******/
                ObjPaymentGateWay.OperationId = 1; /////Its Means SP Run For Only Registartion
                responseDetail = _IWebSiteService.SP_Sab_Saath_Donation_Donor_Registration(ObjPaymentGateWay); /////Run SP And Get Response
                _FlagForPayment = true;///Set Flag True
                #endregion

                #region Step2
                /*******This Step For After Donor Register and Checking Donor Already Exist Then Will Go For Mark Donation Transaction********/

                ////This Condition Check Donor Checking And Register Successful Then Execute This Clause
                if (responseDetail.ResponseCodes == "00" /*&& ObjPaymentGateWay.IsRegister*/ && _FlagForPayment)
                {


                    _DonorMasterId = Convert.ToInt32(responseDetail.DataSet.Tables[0].Rows[0]["ResponseData"]); ///Get Registered And Already Exist Donor ID 
                    _ExistingApiCustomerId = responseDetail.DataSet.Tables[0].Rows[0]["ApiCustomerExistingId"].ToString(); //Get Already Registered Donor API Customer Ref ID IF NOT Registered Then Value Is Empmty. 


                    /*******Create Object For Mark Donor Donation Transaction *******/
                    ObjPaymentGateWay.DonationDetail.DonorMasterId = _DonorMasterId;
                    ObjPaymentGateWay.DonationDetail.OperationId = 1;
                    ObjPaymentGateWay.DonationDetail.Trx_Status = "Incomplete";
                    ObjPaymentGateWay.DonationDetail.Api_RefrenceId = "";
                    /********* End *********/


                    ///Then Call SP FOR Mark Donation
                    responseDetail = _IWebSiteService.SP_Sab_Saath_Mark_Donation_Transaction(ObjPaymentGateWay.DonationDetail);


                    ///After Mark Donation Then SP Return Inserted ID And Set Into Variable And Set Flag To True For Move Further Steps.
                    _DonationId = Convert.ToInt32(responseDetail.DataSet.Tables[0].Rows[0]["ResponseData"]);
                    _FlagForPayment = true;

                }

                else   /////////If Donor Registration Or Checking Failed
                {
                    _FlagForPayment = false;
                }
                #endregion

                #region Step3
                /**************This Step Create Data Objec t For Call API Checkout**************/
                if (_FlagForPayment)
                {
                    #region Step3_A
                    string _FullName = ObjPaymentGateWay.FirstName + " " + ObjPaymentGateWay.LastName;
                    string _CountryCode = ObjPaymentGateWay.CountryCode.Replace("+", string.Empty);

                    PaymentRequest PaymentRequestData = new PaymentRequest
                    {
                        /***********This Ternary Operator Check PaymentType IF Subscription Will Move For Call Payment API bhalf of Source Id Otherwise User Token Authentication. Source ID Saved In Detail Table Of Donation **************/
                        Source = ObjPaymentGateWay.DonationDetail.IsSubscriptionProcess
                        ?
                        new RequestIdSource
                        {
                            Type = Checkout.Common.PaymentSourceType.Id,
                            Id = ObjPaymentGateWay.DonationDetail.Api_Subcription_Source_Id
                        }
                        : new RequestTokenSource { Token = ObjPaymentGateWay.ApiToken },
                        /*************************/
                        Amount = (Convert.ToInt64(Math.Round(ObjPaymentGateWay.DonationDetail.Amount)) * Convert.ToInt64(Math.Round(ObjPaymentGateWay.DonationDetail.ExchangeRate))) * 100,
                        Currency = Checkout.Common.Currency.PKR, //////////API also PKR donation received.

                        PaymentType = ObjPaymentGateWay.DonationDetail.Is3Ds
                        ? Checkout.Payments.PaymentType.Regular : Checkout.Payments.PaymentType.Recurring,

                        PreviousPaymentId = ObjPaymentGateWay.DonationDetail.Is3Ds
                        ? null : ObjPaymentGateWay.DonationDetail.PreviousPaymentId,

                        MerchantInitiated = ObjPaymentGateWay.DonationDetail.Is3Ds
                        ? false : true,

                        Reference = _DonationId.ToString(),
                        Description = "Set of 3 masks",
                        Capture = true,
                        //CaptureOn = new DateTime(),
                        Customer = ObjPaymentGateWay.IsRegister ? ////////This Ternary operator Check Customer Is Registered then send data to API call otherwise not send.
                        new CustomerRequest
                        {
                            Id = _ExistingApiCustomerId == "" ? null : _ExistingApiCustomerId,
                            Email = ObjPaymentGateWay.EmailAddress,
                            Name = _FullName
                            //,Phone = new Phone { CountryCode = _CountryCode, Number = ObjPaymentGateWay.ContactNumber }
                        } : null,
                        // Customer =  null,
                        Shipping = new ShippingDetails
                        {
                            Address = new Address
                            {
                                AddressLine1 = ObjPaymentGateWay.Address
                            },
                            Phone = new Phone
                            {
                                CountryCode = _CountryCode,
                                Number = ObjPaymentGateWay.ContactNumber
                            }
                        },
                        ThreeDs = ObjPaymentGateWay.DonationDetail.IsSubscriptionProcess ? null : ////////This Ternary condition check if subscription call then move to 2D otherwise Follow 3D Authorization
                       new Checkout.Payments.ThreeDsRequest
                       {
                           Enabled = ObjPaymentGateWay.DonationDetail.Is3Ds,
                           AttemptN3D = ObjPaymentGateWay.DonationDetail.IsAttemptAn3D
                       },


                        SuccessUrl = !String.IsNullOrEmpty(ObjPaymentGateWay.SuccessUrl) ? ObjPaymentGateWay.SuccessUrl + "?Id=" + _DonationId : GenericConstants.Url + "?Id=" + _DonationId,
                        FailureUrl = !String.IsNullOrEmpty(ObjPaymentGateWay.FailureUrl) ? ObjPaymentGateWay.FailureUrl + "?Id=" + _DonationId : GenericConstants.Url + "?Id=" + _DonationId,


                        //SuccessUrl = !String.IsNullOrEmpty(ObjPaymentGateWay.SuccessUrl) ? ObjPaymentGateWay.SuccessUrl + "?Id=" + _DonationId : "",  ///Set Success Url After 3d Payment Successfull auto redirect.
                        //FailureUrl = !String.IsNullOrEmpty(ObjPaymentGateWay.FailureUrl) ? ObjPaymentGateWay.FailureUrl + "?Id=" + _DonationId : "", ///Set Failure Url After 3d Payment Successfull auto redirect.

                    };

                    #endregion

                    #region Step3_B
                    /**********This Step For Call API And Mark Log Of Request Parameter Also*************/

                    /////Convert Request Param To JSON Result.
                    string _PaymentRequstString = JsonConvert.SerializeObject(PaymentRequestData, Formatting.Indented);

                    ///////Call API Log SP and Saved Request Data
                    responseDetail = _IWebSiteService.SP_Sab_Saath_Donation_Transaction_Log(_PaymentRequstString, false, "PaymentsClient", Convert.ToInt32(_DonationId), ObjPaymentGateWay.UserId);


                    Checkout.Previous.ICheckoutApi api = CheckoutSdk.Builder().Previous().StaticKeys()
                    .SecretKey(GenericConstants._CheckOutSecretApiKey)
                    .Environment(Checkout.Environment.Sandbox)
                    .HttpClientFactory(new DefaultHttpClientFactory())
                    .Build();

                    ///////Call API For Mark Payment
                    var _Paymentresponse = await api.PaymentsClient().RequestPayment(PaymentRequestData);

                    ///////Then Also Mark Log Of Payment Response
                    responseDetail = _IWebSiteService.SP_Sab_Saath_Donation_Transaction_Log(JsonConvert.SerializeObject(_Paymentresponse, Formatting.Indented), true, "PaymentsClient", Convert.ToInt32(_DonationId), ObjPaymentGateWay.UserId);

                    #endregion

                    var body = _Paymentresponse.Body;
                    paymentMarsStatus.TransactionId = _DonationId.ToString();

                    #region Step3_C

                    /***************This Step Follow To Mark Donor Donation Transaction Statuses****************/

                    if (ObjPaymentGateWay.DonationDetail.IsSubscriptionProcess == true)
                    {
                        if (_Paymentresponse.Approved == true && _Paymentresponse.Id != null)
                        {
                            Trx_Status = _IWebSiteService.GetRequestPaymentStatusCode(Convert.ToInt32(_Paymentresponse.Status));
                            statuscode = true;
                            UserMessage = "";
                        }
                        else
                        {
                            Trx_Status = _IWebSiteService.GetRequestPaymentStatusCode(Convert.ToInt32(_Paymentresponse.Status));
                            statuscode = false;
                            UserMessage = "Incomplete - Your Payment (Transaction ID: " + Convert.ToInt32(_Paymentresponse.Reference) + ") is declined by bank due to : ";
                        }
                        List<string> result = body.Split(',').ToList();
                        for (int i = 0; i < result.Count; i++)
                        {
                            var o = result[i].Replace('"', ' ').Trim().Split(':');
                            if (o[0].Trim() == "response_code")
                            {
                                _ResponseCode = o[1].Trim();
                            }
                            if (o[0].Trim() == "response_summary")
                            {
                                UserMessage += o[1].Trim();
                                break;
                            }
                        }

                        ObjPaymentGateWay.DonationDetail.OperationId = 2;
                        ObjPaymentGateWay.DonationDetail.DonationId = _DonationId;
                        ObjPaymentGateWay.DonationDetail.ResponseCode = _ResponseCode;
                        ObjPaymentGateWay.DonationDetail.Api_RefrenceId = _Paymentresponse.Id;
                        ObjPaymentGateWay.DonationDetail.IsTransactionCompleted = statuscode;
                        ObjPaymentGateWay.DonationDetail.Trx_Status = Trx_Status;
                        ObjPaymentGateWay.DonationDetail.UserMessage = UserMessage;
                    }
                    else
                    {
                        ObjPaymentGateWay.DonationDetail.OperationId = 2;
                        ObjPaymentGateWay.DonationDetail.DonationId = _DonationId;
                        ObjPaymentGateWay.DonationDetail.ResponseCode = _Paymentresponse.HttpStatusCode.ToString();
                        ObjPaymentGateWay.DonationDetail.Api_RefrenceId = _Paymentresponse.Id;
                        ObjPaymentGateWay.DonationDetail.IsTransactionCompleted = _Paymentresponse.HttpStatusCode == 201 ? true : false;
                        ObjPaymentGateWay.DonationDetail.Trx_Status = _Paymentresponse.HttpStatusCode == 201 ? "Success" : "Incomplete";
                        ObjPaymentGateWay.DonationDetail.UserMessage = _IWebSiteService.GetRequestPaymentResponse(Convert.ToInt32(_Paymentresponse.HttpStatusCode));
                    }
                    ////Create Data Object For Save Donation Statuses////////

                    #endregion

                    #region Step3_D

                    /******This Step Follow 3D Or 2D Cases Sources******/
                    if (_Paymentresponse.Source != null) //////////@d Case Source also Fill But 3d return null
                    {
                        Checkout.Payments.Previous.Response.Source.ResponseCardSource _ObjCardResponse = new Checkout.Payments.Previous.Response.Source.ResponseCardSource();
                        _ObjCardResponse = (Checkout.Payments.Previous.Response.Source.ResponseCardSource)_Paymentresponse.Source;
                        ObjPaymentGateWay.DonationDetail.Api_Subcription_Source_Id = _ObjCardResponse.Id;
                    }
                    else ///////Also Null Source If 3D process
                        ObjPaymentGateWay.DonationDetail.Api_Subcription_Source_Id = null;

                    //////Then Save Donor Donation Transaction
                    responseDetail = _IWebSiteService.SP_Sab_Saath_Mark_Donation_Transaction(ObjPaymentGateWay.DonationDetail);

                    //////After Saved Get Donation Id
                    _DonationId = Convert.ToInt32(responseDetail.DataSet.Tables[0].Rows[0]["ResponseData"]);

                    #endregion

                    ///End Donation transaction

                    #region Step3_E
                    /********This Step Follow Update API Customer Refrence Id After Return Check Out Payment API Call*********/
                    if (ObjPaymentGateWay.IsRegister)
                    {
                        ObjPaymentGateWay.OperationId = 2;
                        ObjPaymentGateWay.ApiExistingCustomerId = _Paymentresponse.Customer != null ? _Paymentresponse.Customer.Id : "";
                        ObjPaymentGateWay.DonorId = _DonorMasterId;

                        responseDetail = _IWebSiteService.SP_Sab_Saath_Donation_Donor_Registration(ObjPaymentGateWay);
                        _FlagForPayment = true;
                    }
                    #endregion

                    #region Step3_F

                    /*********This Step Follow Mark Subscription **********/

                    /////This Condition Only Run If FrontEnd Send No Of Month Greater Then 1 AND Its Only First Time Mark Subscription.
                    if (ObjPaymentGateWay.DonationDetail.TotalCount > 1 && ObjPaymentGateWay.DonationDetail.SubscriptionDetailId == null)
                    {
                        PaymentGateWay _ObjSubscription = new PaymentGateWay
                        {

                            OperationId = 1,
                            DonorId = _DonorMasterId,
                            DonationDetail = new PaymentGateWayDonationDetail
                            {
                                ApplicantCaseId = ObjPaymentGateWay.DonationDetail.ApplicantCaseId,
                                CategoryId = ObjPaymentGateWay.DonationDetail.CategoryId,
                                SubCategoryId = ObjPaymentGateWay.DonationDetail.SubCategoryId,
                                Remainder = ObjPaymentGateWay.DonationDetail.Remainder,
                                Amount = ObjPaymentGateWay.DonationDetail.Amount,
                                TotalAmount = ObjPaymentGateWay.DonationDetail.TotalAmount,
                                TotalCount = ObjPaymentGateWay.DonationDetail.TotalCount,
                                DonationTypeId = ObjPaymentGateWay.DonationDetail.DonationTypeId,
                                CurrencyId = ObjPaymentGateWay.DonationDetail.CurrencyId,
                                frequeny = ObjPaymentGateWay.DonationDetail.frequeny

                                //ApplicantCaseId = ObjPaymentGateWay.DonationDetail.ApplicantCaseId,
                                //CategoryId = ObjPaymentGateWay.DonationDetail.CategoryId,
                                //SubCategoryId = ObjPaymentGateWay.DonationDetail.SubCategoryId,
                                //TotalAmount = ObjPaymentGateWay.DonationDetail.Amount * ObjPaymentGateWay.DonationDetail.TotalCount,
                                //TotalCount = ObjPaymentGateWay.DonationDetail.TotalCount,
                                //DonationTypeId = ObjPaymentGateWay.DonationDetail.DonationTypeId,
                                //CurrencyId = ObjPaymentGateWay.DonationDetail.CurrencyId,
                                //frequeny = ObjPaymentGateWay.DonationDetail.frequeny
                            },
                            UserId = ObjPaymentGateWay.UserId
                        };

                        responseDetail = _IWebSiteService.SP_Sab_Saath_Subscription(_ObjSubscription, "Incomplete", Convert.ToInt32(_Paymentresponse.Reference));
                    }
                    //////// This Condition Run Only Subscriptionn Console run Time 
                    else if (ObjPaymentGateWay.DonationDetail.TotalCount == 1 && ObjPaymentGateWay.DonationDetail.SubscriptionDetailId != null)
                    {
                        PaymentGateWay _ObjSubscription = new PaymentGateWay
                        {
                            OperationId = 2,
                            DonationDetail = new PaymentGateWayDonationDetail
                            {
                                SubscriptionDetailId = ObjPaymentGateWay.DonationDetail.SubscriptionDetailId,
                                TotalAmount = 0,
                                TotalCount = 0,
                            },
                            UserId = ObjPaymentGateWay.UserId
                        };
                        responseDetail = _IWebSiteService.SP_Sab_Saath_Subscription(_ObjSubscription, UserMessage, Convert.ToInt32(_DonationId));
                        if (statuscode == true)
                        {
                            Get_Payment_Receipt_Subscription(paymentMarsStatus);
                        }
                        else
                        {
                            Get_Payment_Receipt_Subscription(paymentMarsStatus, "");
                        }
                    }
                    #endregion

                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, _IWebSiteService.GetRequestPaymentResponse(Convert.ToInt32(_Paymentresponse.HttpStatusCode)), _Paymentresponse);
                }
                #endregion

            }

            #region catch 

            catch (CheckoutApiException e)
            {
                // API error
                dynamic _Data = new { requestId = e.RequestId, statusCode = e.HttpStatusCode, errordt = e.ErrorDetails };
                string _ErrorDetail = JsonConvert.SerializeObject(_Data, Formatting.Indented);

                ////Update Donation Transaction
                ObjPaymentGateWay.DonationDetail.OperationId = 2;
                ObjPaymentGateWay.DonationDetail.DonationId = _DonationId;
                ObjPaymentGateWay.DonationDetail.ResponseCode = ((int)e.HttpStatusCode).ToString();
                ObjPaymentGateWay.DonationDetail.IsTransactionCompleted = false;
                ObjPaymentGateWay.DonationDetail.Trx_Status = "Incomplete";
                ObjPaymentGateWay.DonationDetail.UserMessage = _IWebSiteService.GetRequestPaymentResponse((int)e.HttpStatusCode);

                responseDetail = _IWebSiteService.SP_Sab_Saath_Mark_Donation_Transaction(ObjPaymentGateWay.DonationDetail);

                PaymentGateWay _ObjSubscription = new PaymentGateWay
                {
                    OperationId = 2,
                    DonationDetail = new PaymentGateWayDonationDetail
                    {
                        SubscriptionDetailId = ObjPaymentGateWay.DonationDetail.SubscriptionDetailId,
                        TotalAmount = 0,
                        TotalCount = 0,
                    },
                    UserId = 1
                };
                responseDetail = _IWebSiteService.SP_Sab_Saath_Subscription(_ObjSubscription, "Incomplete", Convert.ToInt32(_DonationId));
                paymentMarsStatus.TransactionId = _DonationId.ToString();
                if (statuscode == false)
                {
                    Get_Payment_Receipt_Subscription(paymentMarsStatus, "Incomplete - Your Payment (Transaction ID: " + Convert.ToInt32(_DonationId) + " Error Code: " + ((int)e.HttpStatusCode).ToString() + ") could not be Processed by Checkout. Please call Sab Saath helpline.");
                }

                ///End Donation transaction
                ///

                _IWebSiteService.SP_Sab_Saath_Donation_Transaction_Log(_ErrorDetail, true, "PaymentsClient", Convert.ToInt32(_DonationId), ObjPaymentGateWay.UserId);

                //responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Failure, _IWebSiteService.GetRequestPaymentResponse((int)e.HttpStatusCode), _Data);
                responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Failure, "Incomplete - Your Payment (Transaction ID: " + Convert.ToInt32(_DonationId) + " Error Code: " + ((int)e.HttpStatusCode).ToString() + ") could not be Processed by Checkout. Please call Sab Saath helpline.", null);
            }
            catch (CheckoutArgumentException e)
            {
                ////Update Donation Transaction
                ObjPaymentGateWay.DonationDetail.OperationId = 2;
                ObjPaymentGateWay.DonationDetail.DonationId = _DonationId;
                ObjPaymentGateWay.DonationDetail.ResponseCode = e.Message.ToString();
                ObjPaymentGateWay.DonationDetail.IsTransactionCompleted = false;
                ObjPaymentGateWay.DonationDetail.Trx_Status = "Incomplete";
                ObjPaymentGateWay.DonationDetail.UserMessage = e.Message;

                responseDetail = _IWebSiteService.SP_Sab_Saath_Mark_Donation_Transaction(ObjPaymentGateWay.DonationDetail);

                PaymentGateWay _ObjSubscription = new PaymentGateWay
                {
                    OperationId = 2,
                    DonationDetail = new PaymentGateWayDonationDetail
                    {
                        SubscriptionDetailId = ObjPaymentGateWay.DonationDetail.SubscriptionDetailId,
                        TotalAmount = 0,
                        TotalCount = 0,
                    },
                    UserId = 1
                };
                responseDetail = _IWebSiteService.SP_Sab_Saath_Subscription(_ObjSubscription, "Incomplete", Convert.ToInt32(_DonationId));
                paymentMarsStatus.TransactionId = _DonationId.ToString();
                if (statuscode == false)
                {
                    Get_Payment_Receipt_Subscription(paymentMarsStatus, "Incomplete - Your Payment (Transaction ID: " + Convert.ToInt32(_DonationId) + " Error Code: " + e.Message.ToString() + ") could not be Processed by Checkout. Please call Sab Saath helpline.");
                }

                ///End Donation transaction
                ///

                _IWebSiteService.SP_Sab_Saath_Donation_Transaction_Log(e.Message, true, e.Message, Convert.ToInt32(_DonationId), ObjPaymentGateWay.UserId);

                responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Failure, "Incomplete - Your Payment (Transaction ID: " + Convert.ToInt32(_DonationId) + " Error Code: " + e.Message.ToString() + ") could not be Processed by Checkout. Please call Sab Saath helpline.", null);
                // Bad arguments
            }
            catch (CheckoutAuthorizationException e)
            {
                ////Update Donation Transaction
                ObjPaymentGateWay.DonationDetail.OperationId = 2;
                ObjPaymentGateWay.DonationDetail.DonationId = _DonationId;
                ObjPaymentGateWay.DonationDetail.ResponseCode = e.Message.ToString();
                ObjPaymentGateWay.DonationDetail.IsTransactionCompleted = false;
                ObjPaymentGateWay.DonationDetail.Trx_Status = "Incomplete";
                ObjPaymentGateWay.DonationDetail.UserMessage = e.Message;

                responseDetail = _IWebSiteService.SP_Sab_Saath_Mark_Donation_Transaction(ObjPaymentGateWay.DonationDetail);
                _IWebSiteService.SP_Sab_Saath_Donation_Transaction_Log(e.Message, true, e.Message, Convert.ToInt32(_DonationId), ObjPaymentGateWay.UserId);

                PaymentGateWay _ObjSubscription = new PaymentGateWay
                {
                    OperationId = 2,
                    DonationDetail = new PaymentGateWayDonationDetail
                    {
                        SubscriptionDetailId = ObjPaymentGateWay.DonationDetail.SubscriptionDetailId,
                        TotalAmount = 0,
                        TotalCount = 0,
                    },
                    UserId = 1
                };
                responseDetail = _IWebSiteService.SP_Sab_Saath_Subscription(_ObjSubscription, "Incomplete", Convert.ToInt32(_DonationId));
                paymentMarsStatus.TransactionId = _DonationId.ToString();
                if (statuscode == false)
                {
                    Get_Payment_Receipt_Subscription(paymentMarsStatus, "Incomplete - Your Payment (Transaction ID: " + Convert.ToInt32(_DonationId) + " Error Code: " + e.Message.ToString() + ") could not be Processed by Checkout. Please call Sab Saath helpline.");
                }

                responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Failure, "Incomplete - Your Payment (Transaction ID: " + Convert.ToInt32(_DonationId) + " Error Code: " + e.Message.ToString() + ") could not be Processed by Checkout. Please call Sab Saath helpline.", null);
                // Invalid authorization
            }
            catch (Exception ex)
            {
                ObjPaymentGateWay.DonationDetail.OperationId = 2;
                ObjPaymentGateWay.DonationDetail.DonationId = _DonationId;
                ObjPaymentGateWay.DonationDetail.ResponseCode = ex.Message.ToString();
                ObjPaymentGateWay.DonationDetail.IsTransactionCompleted = false;
                ObjPaymentGateWay.DonationDetail.Trx_Status = "Incomplete";
                ObjPaymentGateWay.DonationDetail.UserMessage = ex.Message;

                responseDetail = _IWebSiteService.SP_Sab_Saath_Mark_Donation_Transaction(ObjPaymentGateWay.DonationDetail);
                _IWebSiteService.SP_Sab_Saath_Donation_Transaction_Log(ex.Message, true, ex.Message, Convert.ToInt32(_DonationId), ObjPaymentGateWay.UserId);

                PaymentGateWay _ObjSubscription = new PaymentGateWay
                {
                    OperationId = 2,
                    DonationDetail = new PaymentGateWayDonationDetail
                    {
                        SubscriptionDetailId = ObjPaymentGateWay.DonationDetail.SubscriptionDetailId,
                        TotalAmount = 0,
                        TotalCount = 0,
                    },
                    UserId = 1
                };
                responseDetail = _IWebSiteService.SP_Sab_Saath_Subscription(_ObjSubscription, "Incomplete", Convert.ToInt32(_DonationId));
                paymentMarsStatus.TransactionId = _DonationId.ToString();
                if (statuscode == false)
                {
                    Get_Payment_Receipt_Subscription(paymentMarsStatus, "Incomplete - Your Payment (Transaction ID: " + Convert.ToInt32(_DonationId) + ") could not be Processed.Please call Sab Saath helpline.");
                }

                responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Failure, "Incomplete - Your Payment (Transaction ID: " + Convert.ToInt32(_DonationId) + ") could not be Processed.Please call Sab Saath helpline.", null);
            }
            #endregion

            string json = JsonConvert.SerializeObject(responseDetail, Formatting.Indented);
            return json;
        }

        [HttpPost("GetPaymentDetails")]
        public async Task<string> GetCheckOutPaymentDetails(List<string> data)
        {
            MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
            int _DonationId = Convert.ToInt32(data[0]);
            PaymentGateWayDonationDetail ObjPaymentGateWayDetail;
            string _ResponseCode = "";
            string Trx_Status = "";
            bool statuscode;
            string UserMessage = "";
            try
            {
                responseDetail = _IWebSiteService.SP_Sab_Saath_Donation_Transaction_Log(data[1], false, "GetPaymentDetails", _DonationId, -1);
                string _PaymentDetailData = _IWebSiteService.GetAPITransactionId(_DonationId).Data;

                Checkout.Previous.ICheckoutApi api = CheckoutSdk.Builder().Previous().StaticKeys()
                     .SecretKey(GenericConstants._CheckOutSecretApiKey)
                     .Environment(Checkout.Environment.Sandbox)
                     .HttpClientFactory(new DefaultHttpClientFactory())
                     .Build();

                var _Paymentresponse = await api.PaymentsClient().GetPaymentDetails(_PaymentDetailData);
                responseDetail = _IWebSiteService.SP_Sab_Saath_Donation_Transaction_Log(JsonConvert.SerializeObject(_Paymentresponse, Formatting.Indented), true, "GetPaymentDetails", Convert.ToInt32(_DonationId), -1);
                ////Update Donation Transaction 

                if (_Paymentresponse.Approved == true && _Paymentresponse.Id != null)
                {
                    Trx_Status = _IWebSiteService.GetRequestPaymentStatusCode(Convert.ToInt32(_Paymentresponse.Status));
                    statuscode = true;
                    UserMessage = "";
                }
                else
                {
                    Trx_Status = _IWebSiteService.GetRequestPaymentStatusCode(Convert.ToInt32(_Paymentresponse.Status));
                    //ResponseCode = 401;
                    statuscode = false;
                    UserMessage = "Incomplete - Your Payment (Transaction ID: " + Convert.ToInt32(_Paymentresponse.Reference) + ") is declined by bank due to : ";
                }

                var _Paymentresponse1 = await api.PaymentsClient().GetPaymentActions(_PaymentDetailData);
                var body = _Paymentresponse1.Body;
                var body1 = _Paymentresponse.Body;
                if (body == "[]")
                {
                    List<string> result = body1.Split(',').ToList();
                    for (int i = 0; i < result.Count; i++)
                    {
                        var o = result[i].Replace('"', ' ').Trim().Split(':');
                        if (o[0].Trim() == "response_code")
                        {
                            _ResponseCode = "20005";// o[1].Trim();
                        }
                        if (o[0].Trim() == "status")
                        {
                            // UserMessage += o[1].Trim();
                            UserMessage = "Your Payment (Transaction ID: " + Convert.ToInt32(_Paymentresponse.Reference) + ") is " + o[1].Trim() + ".";
                            break;
                        }
                    }
                }
                else
                {
                    List<string> result = body.Split(',').ToList();
                    for (int i = 0; i < result.Count; i++)
                    {
                        var o = result[i].Replace('"', ' ').Trim().Split(':');
                        if (o[0].Trim() == "response_code")
                        {
                            _ResponseCode = o[1].Trim();
                        }
                        if (o[0].Trim() == "response_summary")
                        {
                            UserMessage += o[1].Trim();
                            break;
                        }
                    }
                }

                ObjPaymentGateWayDetail = new PaymentGateWayDonationDetail
                {
                    OperationId = 2,
                    DonationId = Convert.ToInt32(_Paymentresponse.Reference),
                    ResponseCode = _ResponseCode, //_Paymentresponse.HttpStatusCode.ToString(),
                    Api_RefrenceId = _Paymentresponse.Id,
                    IsTransactionCompleted = statuscode,//_Paymentresponse.HttpStatusCode == 200 ? true : false,
                    Trx_Status = Trx_Status,// "Success",
                    UserMessage = UserMessage //_IWebSiteService.GetRequestPaymentResponse(Convert.ToInt32(_Paymentresponse.HttpStatusCode))
                };
                if (_Paymentresponse.Source != null) //////////@d Case Source also Fill But 3d return null
                {
                    //Checkout.Payments.Response.Source.CardResponseSource _ObjCardResponse = new Checkout.Payments.Response.Source.CardResponseSource();
                    //_ObjCardResponse = (Checkout.Payments.Response.Source.CardResponseSource)_Paymentresponse.Source;
                    //ObjPaymentGateWayDetail.Api_Subcription_Source_Id = _ObjCardResponse.Id;
                    Checkout.Payments.Previous.Response.Source.ResponseCardSource _ObjCardResponse = new Checkout.Payments.Previous.Response.Source.ResponseCardSource();
                    _ObjCardResponse = (Checkout.Payments.Previous.Response.Source.ResponseCardSource)_Paymentresponse.Source;
                    ObjPaymentGateWayDetail.Api_Subcription_Source_Id = _ObjCardResponse.Id;
                }
                else
                {
                    ObjPaymentGateWayDetail.Api_Subcription_Source_Id = null;
                }
                responseDetail = _IWebSiteService.SP_Sab_Saath_Mark_Donation_Transaction(ObjPaymentGateWayDetail);
                ///End Donation transaction
                _DonationId = Convert.ToInt32(_Paymentresponse.Reference);

                PaymentGateWay _ObjSubscription = new PaymentGateWay
                {
                    OperationId = 2,
                    DonationDetail = new PaymentGateWayDonationDetail
                    {
                        SubscriptionDetailId = null,
                        TotalAmount = 0,
                        TotalCount = 0,
                    },
                    UserId = 1
                };
                responseDetail = _IWebSiteService.SP_Sab_Saath_Subscription(_ObjSubscription, UserMessage, Convert.ToInt32(_DonationId));
                if (responseDetail.Data.Tables != null)
                {
                    try
                    {
                        if (((System.Data.DataSet)responseDetail.Data).Tables.Count > 0 && ((System.Data.DataSet)responseDetail.Data).Tables[0].Rows[0][1].ToString() == "10")
                        {
                            UserMessage += " " + ((System.Data.DataSet)responseDetail.Data).Tables[0].Rows[0][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        if (((System.Data.DataSet)responseDetail.Data).Tables.Count > 0 && ((System.Data.DataSet)responseDetail.Data).Tables[1].Rows[0][1].ToString() == "10")
                        {
                            UserMessage += " " + ((System.Data.DataSet)responseDetail.Data).Tables[1].Rows[0][0].ToString();
                        }
                    }
                    finally
                    {

                    }
                }

                responseDetail = CommonObjects.GetRepsonses(true, UserMessage == "Approved" ? ResponseCodes.Success : ResponseCodes.Failure, UserMessage);

            }
            catch (CheckoutApiException e)
            {
                // API error
                dynamic _Data = new { requestId = e.RequestId, statusCode = e.HttpStatusCode, errordt = e.ErrorDetails };
                string _ErrorDetail = JsonConvert.SerializeObject(_Data, Formatting.Indented);
                ////Update Donation Transaction 
                ObjPaymentGateWayDetail = new PaymentGateWayDonationDetail
                {
                    OperationId = 2,
                    DonationId = _DonationId,
                    ResponseCode = ((int)e.HttpStatusCode).ToString(),
                    IsTransactionCompleted = false,
                    Trx_Status = "Error",
                    UserMessage = _IWebSiteService.GetRequestPaymentResponse((int)e.HttpStatusCode)
                };
                responseDetail = _IWebSiteService.SP_Sab_Saath_Mark_Donation_Transaction(ObjPaymentGateWayDetail);

                PaymentGateWay _ObjSubscription = new PaymentGateWay
                {
                    OperationId = 2,
                    DonationDetail = new PaymentGateWayDonationDetail
                    {
                        SubscriptionDetailId = null,
                        TotalAmount = 0,
                        TotalCount = 0,
                    },
                    UserId = 1
                };
                responseDetail = _IWebSiteService.SP_Sab_Saath_Subscription(_ObjSubscription, UserMessage, Convert.ToInt32(_DonationId));

                ///End Donation transaction
                _IWebSiteService.SP_Sab_Saath_Donation_Transaction_Log(_ErrorDetail, true, "GetPaymentDetails", Convert.ToInt32(_DonationId), -1);
                // responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Failure, _IWebSiteService.GetRequestPaymentResponse((int)e.HttpStatusCode), _Data);
                responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Failure, "Incomplete - Your Payment (Transaction ID: " + Convert.ToInt32(_DonationId) + ") could not be Processed by Sab Saath. Please contact helpline for info.", _Data);

            }
            catch (CheckoutArgumentException e)
            {
                ////Update Donation Transaction
                ObjPaymentGateWayDetail = new PaymentGateWayDonationDetail
                {
                    OperationId = 2,
                    DonationId = _DonationId,
                    ResponseCode = e.Message.ToString(),
                    IsTransactionCompleted = false,
                    Trx_Status = "Error",
                    UserMessage = e.Message
                };
                responseDetail = _IWebSiteService.SP_Sab_Saath_Mark_Donation_Transaction(ObjPaymentGateWayDetail);

                PaymentGateWay _ObjSubscription = new PaymentGateWay
                {
                    OperationId = 2,
                    DonationDetail = new PaymentGateWayDonationDetail
                    {
                        SubscriptionDetailId = null,
                        TotalAmount = 0,
                        TotalCount = 0,
                    },
                    UserId = 1
                };
                responseDetail = _IWebSiteService.SP_Sab_Saath_Subscription(_ObjSubscription, UserMessage, Convert.ToInt32(_DonationId));

                ///End Donation transaction
                _IWebSiteService.SP_Sab_Saath_Donation_Transaction_Log(e.Message, true, e.Message, _DonationId, -1);
                //responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Failure, "Bad Request", null);
                responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Failure, "Incomplete - Your Payment (Transaction ID: " + Convert.ToInt32(_DonationId) + ") could not be Processed by Sab Saath. Please contact helpline for info.", null);
                // Bad arguments
            }
            catch (CheckoutAuthorizationException e)
            {
                ////Update Donation Transaction
                ObjPaymentGateWayDetail = new PaymentGateWayDonationDetail
                {
                    OperationId = 2,
                    DonationId = _DonationId,
                    ResponseCode = e.Message.ToString(),
                    IsTransactionCompleted = false,
                    Trx_Status = "Error",
                    UserMessage = e.Message
                };
                responseDetail = _IWebSiteService.SP_Sab_Saath_Mark_Donation_Transaction(ObjPaymentGateWayDetail);

                PaymentGateWay _ObjSubscription = new PaymentGateWay
                {
                    OperationId = 2,
                    DonationDetail = new PaymentGateWayDonationDetail
                    {
                        SubscriptionDetailId = null,
                        TotalAmount = 0,
                        TotalCount = 0,
                    },
                    UserId = 1
                };
                responseDetail = _IWebSiteService.SP_Sab_Saath_Subscription(_ObjSubscription, UserMessage, Convert.ToInt32(_DonationId));

                ///End Donation transaction
                _IWebSiteService.SP_Sab_Saath_Donation_Transaction_Log(e.Message, true, e.Message, _DonationId, -1);
                //responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Failure, "Invalid authorization", null);
                responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Failure, "Incomplete - Your Payment (Transaction ID: " + Convert.ToInt32(_DonationId) + ") could not be Processed by Sab Saath. Please contact helpline for info.", null);
                // Invalid authorization
            }

            string json = JsonConvert.SerializeObject(responseDetail, Formatting.Indented);
            return json;
        }

        #endregion

        [HttpPost("Donor_WebSite_Register")]
        public string Donor_WebSite_Register(DonorWebSite_Register ObjDCo)
        {
            try
            {
                var response = _IWebSiteService.Donor_WebSite_Register(ObjDCo);
                string json = JsonConvert.SerializeObject(response, Formatting.Indented);
                return json;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("Disaster_Relief_GetCategory")]
        public string Disaster_Relief_GetCategory(DonorWebSite_Register ObjDCo)
        {
            try
            {
                var response = _IWebSiteService.Donor_WebSite_Register(ObjDCo);
                string json = JsonConvert.SerializeObject(response, Formatting.Indented);
                return json;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("Get_Profile_Data")]
        public string Get_Profile_Data(UserProfile_Update ObjDCo)
        {
            try
            {
                var response = _IWebSiteService.Get_Profile_Data(ObjDCo);
                string json = JsonConvert.SerializeObject(response, Formatting.Indented);
                return json;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("Managed_EmailNotifications")]
        public string Managed_EmailNotifications(ManagedEmail_Notification ObjDCo)
        {
            try
            {
                var response = _IWebSiteService.Managed_EmailNotifications(ObjDCo);
                string json = JsonConvert.SerializeObject(response, Formatting.Indented);
                return json;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("ContentsUploads")]
        public string ContentsUploads()
        {
            ContentsUploads obj = new ContentsUploads();
            var files = HttpContext.Request.Form.Files;
            var data = HttpContext.Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            foreach (var item in data)
            {
                if (item.Key.Contains("OperationID"))
                {
                    obj.OperationID = Convert.ToInt32(item.Value);
                }
                else if (item.Key.Contains("Content_ID"))
                {
                    obj.Content_ID = Convert.ToInt32(item.Value);
                }
                else if (item.Key.Contains("Content_Type"))
                {
                    obj.Content_Type = Convert.ToInt32(item.Value);
                }

                else if (item.Key.Contains("Content_Title"))
                {
                    obj.Content_Title = item.Value;
                }

                else if (item.Key.Contains("Content_Description"))
                {
                    obj.Content_Description = item.Value;
                }

                else if (item.Key.Contains("Content_Position"))
                {
                    obj.Content_Position = Convert.ToInt32(item.Value);
                }

                else if (item.Key.Contains("Content_IsPromoted"))
                {
                    obj.Content_IsPromoted = Convert.ToBoolean(item.Value);
                }

                else if (item.Key.Contains("Content_Display"))
                {
                    obj.Content_Display = Convert.ToBoolean(item.Value);
                }

                else if (item.Key.Contains("Content_MediaType"))
                {
                    obj.Content_MediaType = Convert.ToBoolean(item.Value);
                }

                else if (item.Key.Contains("UserID"))
                {
                    obj.UserID = Convert.ToInt32(item.Value);
                }
                else if (item.Key.Contains("UserIP"))
                {
                    obj.UserIP = item.Value;
                }
                else if (item.Key.Contains("CommonAttachmentId"))
                {
                    obj.CommonAttachmentId = Convert.ToInt32(item.Value);
                }
                else if (item.Key.Contains("FileName"))
                {
                    obj.FileName = item.Value;
                }
                else if (item.Key.Contains("FileGeneratedName"))
                {
                    obj.FileGeneratedName = item.Value;
                }
                else if (item.Key.Contains("VideoURL"))
                {
                    obj.VideoURL = item.Value;
                }
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("CommonAttachmentId");
            dt.Columns.Add("DocTypeId");
            dt.Columns.Add("DocAttachmentPath");
            dt.Columns.Add("UserIP");
            dt.Columns.Add("CreatedBy");
            dt.Columns.Add("ModifiedBy");
            dt.Columns.Add("RelationId");
            dt.Columns.Add("FileName");
            dt.Columns.Add("FileGeneratedName");
            dt.Columns.Add("VideoOrImage");
            dt.Columns.Add("VideoURL");
            dt.Columns.Add("TableTypeId");
            List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG", ".JPEG", ".TIFF" };
            if (files != null && files.Count > 0)
            {

                //string FileGeneratedName = "";
                foreach (var file in files)
                {
                    if (ImageExtensions.Contains(Path.GetExtension(file.FileName).ToUpperInvariant()))
                    {
                        string datestring = DateTime.Now.ToString("ddMMyyyyhhmmss");
                        obj.FileName = file.FileName;
                        obj.FileGeneratedName = datestring + "_" + file.FileName;
                        var FileSave = Path.Combine("", hostingEnvironment.ContentRootPath + "/wwwroot/UploadImages/" + file.FileName);
                        var renamefilepath = Path.Combine("", hostingEnvironment.ContentRootPath + "/wwwroot/UploadImages/");
                        using (var stream = new FileStream(FileSave, FileMode.Create))
                        { file.CopyTo(stream); }
                        System.IO.File.Copy(FileSave, renamefilepath + datestring + "_" + file.FileName);
                        System.IO.File.Delete(FileSave);
                    }
                    else  //for video
                    {
                        string datestring = DateTime.Now.ToString("ddMMyyyyhhmmss");
                        //obj.FileName = file.FileName;
                        obj.VideoURL = datestring + "_" + file.FileName;
                        var FileSave = Path.Combine("", hostingEnvironment.ContentRootPath + "/wwwroot/UploadImages/" + file.FileName);
                        var renamefilepath = Path.Combine("", hostingEnvironment.ContentRootPath + "/wwwroot/UploadImages/");
                        using (var stream = new FileStream(FileSave, FileMode.Create))
                        { file.CopyTo(stream); }
                        System.IO.File.Copy(FileSave, renamefilepath + datestring + "_" + file.FileName);
                        System.IO.File.Delete(FileSave);
                    }
                }
                dt.Rows.Add(obj.CommonAttachmentId == null || obj.CommonAttachmentId == 0 ? 0 : obj.CommonAttachmentId
                               , obj.Content_Type
                               , "/UploadImages"
                               , obj.UserIP
                               , obj.UserID
                               , obj.UserID
                               , obj.Content_ID
                               , obj.FileName
                               , obj.FileGeneratedName
                               , obj.Content_MediaType
                               , obj.VideoURL
                               , null);
            }
            var response = _IWebSiteService.Sp_Content_Upload(obj, dt);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

    }
}



