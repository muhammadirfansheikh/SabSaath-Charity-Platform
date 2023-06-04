using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SabSath.Application.Repositiories;
using SabSath.Core.Models;
using System.Data;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace SabSathWeb.Controllers
{
    [EnableCors("Security")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _IApplicantService;
        public IHostingEnvironment hostingEnvironment;
        public ApplicantController(IApplicantService objIApplicantService, IHostingEnvironment hostingenv)
        {
            _IApplicantService = objIApplicantService;
            hostingEnvironment = hostingenv;
        }
        //[HttpPost("Applicant_Operation")]
        //public JsonResult Applicant_Operation(ConsolidateApplicant objConsolidateApplicant)
        //{

        //     var response = _IApplicantService.usp_Primary_Operation(objConsolidateApplicant.ApplicantInformation, objConsolidateApplicant.ApplicantCaseDetail);
        //    return new JsonResult(response);

        //}

        [HttpPost("Get_Data_According_To_ReferrerType")]
        public JsonResult Get_Data_According_To_ReferrerType(List<int> ReferralTypeId)
        {

            var response = _IApplicantService.usp_GetReferrerDataAccordingToReferrerType(ReferralTypeId[0]);
            return new JsonResult(response);

        }

        [HttpPost("Get_Applicant_Cases")]
        public JsonResult Get_Applicant_Cases(dynamic data)
        {

            var response = _IApplicantService.usp_Get_Applicant_Cases(data);
            return new JsonResult(response);

        }

        [HttpPost("Get_Applicant_Basic_By_Id")]
        public JsonResult Get_Applicant_Basic_By_Id(List<int> ApplicantCaseId)
        {

            var response = _IApplicantService.usp_Get_Applicant_Basic_By_Id(ApplicantCaseId[0]);

            return new JsonResult(response);

        }

        [HttpPost("Get_Application_Applicant_Data")]
        public string Get_Application_Applicant_Data(int CaseId, int Tab_INDEX)
        {

            var response = _IApplicantService.usp_Get_ApplicantApplicationData(CaseId, Tab_INDEX);

            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("Assign_All_Check_Applicant_Case")]
        public JsonResult Assign_All_Check_Applicant_Case(dynamic data)
        {

            var response = _IApplicantService.usp_Assign_Investigator_Applicant_Case(data);
            return new JsonResult(response);

        }
        [HttpPost("Applicant_MarketingCase")]
        public string Applicant_MarketingCase()
        {
            MarketingCase obj = new MarketingCase();
            var files = HttpContext.Request.Form.Files;
            var data = HttpContext.Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            foreach (var item in data)
            {
                if (item.Key.Contains("caseDesc"))
                {
                    obj.caseDesc = item.Value;
                }
                else if (item.Key.Contains("CaseofApplicant"))
                {
                    obj.caseid = Convert.ToInt32(item.Value);
                }
                else if (item.Key.Contains("CaseTitle"))
                {
                    obj.CaseTitle = item.Value;
                }

                else if (item.Key.Contains("CaseoftheDay"))
                {
                    obj.caseoftheday = item.Value;
                }

                else if (item.Key.Contains("CasesShow"))
                {
                    obj.Caseshow = item.Value;
                }

                else if (item.Key.Contains("UserId"))
                {
                    obj.CreatedBy = item.Value;
                }

                else if (item.Key.Contains("UserIP"))
                {
                    obj.Userip = item.Value;
                }

                else if (item.Key.Contains("VideoURL"))
                {
                    obj.VideoURL = item.Value;
                }

                else if (item.Key.Contains("ShortDesc"))
                {
                    obj.ShortDesc = item.Value;
                }

                else if (item.Key.Contains("DocAttachmentID"))
                {
                    obj.AttachmentDocID = item.Value;
                }
                else if (item.Key.Contains("Adopt"))
                {
                    obj.Adopt = Convert.ToBoolean(item.Value);
                }
                else if (item.Key.Contains("Source"))
                {
                    obj.Source = Convert.ToInt32(item.Value);
                }
                else if (item.Key.Contains("CauseLabel"))
                {
                    obj.CauseLabel = item.Value;
                }
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("DocTypeId");
            dt.Columns.Add("DocAttachmentPath");
            dt.Columns.Add("RelationId");
            dt.Columns.Add("FileName");
            dt.Columns.Add("FileGeneratedName");
            //dt.Columns.Add("VideoOrImage");
            //dt.Columns.Add("VideoURL");

            int marketingcasenum = (int)SabSath.Application.Helper.EnumHelper.Document_Type.MarketingCase;
            int marketingVideoURL = (int)SabSath.Application.Helper.EnumHelper.Document_Type.VideoandURL;
            List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG", ".JPEG", ".TIFF" };

            if (files != null && files.Count > 0)
            {
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
                        {
                            file.CopyTo(stream);
                        }
                        System.IO.File.Copy(FileSave, renamefilepath + datestring + "_" + file.FileName);
                        System.IO.File.Delete(FileSave);
                        dt.Rows.Add(obj.AttachmentDocID == "undefined" ? 0 : obj.AttachmentDocID, marketingcasenum, "/UploadImages", obj.caseid, file.FileName, obj.FileGeneratedName);
                    }
                    else
                    {
                        string datestring = DateTime.Now.ToString("ddMMyyyyhhmmss");
                        obj.FileName = file.FileName;
                        obj.FileGeneratedName = datestring + "_" + file.FileName;

                        var FileSave = Path.Combine("", hostingEnvironment.ContentRootPath + "/wwwroot/UploadImages/" + file.FileName);
                        var renamefilepath = Path.Combine("", hostingEnvironment.ContentRootPath + "/wwwroot/UploadImages/");
                        using (var stream = new FileStream(FileSave, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        System.IO.File.Copy(FileSave, renamefilepath + datestring + "_" + file.FileName);
                        System.IO.File.Delete(FileSave);
                        dt.Rows.Add(obj.AttachmentDocID == "undefined" ? 0 : obj.AttachmentDocID, marketingVideoURL, "/UploadImages", obj.caseid, file.FileName, obj.FileGeneratedName);
                    }
                }
            }
            if (obj.VideoURL != "null")
            {
                dt.Rows.Add(obj.AttachmentDocID, marketingVideoURL, obj.VideoURL, obj.caseid, null, null);
            }

            var response = _IApplicantService.Applicant_MarketingCase(obj, dt);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("GetData_MarketingCase")]
        public string GetData_MarketingCase(MarketingCase objData)
        {
            var response = _IApplicantService.GetData_MarketingCase(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("Combo_Operation")]
        public JsonResult Combo_Operation(ComboOperation obj)
        {
            if (obj == null)
            {
                return null;
            }
            var response = _IApplicantService.usp_Combo_Operation(obj);
            return new JsonResult(response);
        }

        [HttpGet("GetFamilyDetail")]
        public JsonResult GetFamilyDetail(int id)
        {
            var response = _IApplicantService.usp_GetFamilyDetail(id);
            return new JsonResult(response);
        }

        //[HttpPost("CrudCaseSupport")]
        //public IActionResult CrudCaseSupport([FromBody] List<ApplicantCaseSupport> obj, DateTime date, int UserId, string UserIP,int CaseId)
        //{
        //    DataTable dt = SabSath.Application.Helper.CommonMethodHelper.ToDataTable(obj);
        //    var response = IApplicantService.CrudCaseSupport(obj[0].CaseDetailDetailid, 2, dt, date,UserIP,UserId, CaseId);

        //    return Ok(response);
        //}

        //[HttpPost("usp_crud_GuardianDetail")]
        //public JsonResult usp_crud_GuardianDetail(List<ApplicantGuardianDetail> obj, int Operationid, int ID, string Date, int UserId, string UserIP)
        //{
        //    var response = _IApplicantService.usp_crud_GuardianDetail(obj, Operationid, ID, Date, UserId, UserIP);
        //    return new JsonResult(response);
        //}

        //[HttpPost("usp_crud_ExpenseDetail")]
        //public JsonResult usp_crud_ExpenseDetail(List<ApplicantExpenseDetail> obj, int Operationid, int ID, string Date, int UserId, string UserIP)
        //{
        //    var response = _IApplicantService.usp_crud_ExpenseDetail(obj, Operationid, ID, Date, UserId, UserIP);
        //    return new JsonResult(response);
        //}

        [HttpPost("usp_crud_ApplicantFamilyInformationDetail")]
        public JsonResult usp_crud_ApplicantFamilyInformationDetail(List<ApplicantFamilyInformationDetail> obj, int Operationid, int ID, string Date, int UserId, string UserIP)
        {
            DateTime dt = Convert.ToDateTime(Date);
            var response = _IApplicantService.usp_crud_ApplicantFamilyInformationDetail(obj, Operationid, ID, Date, UserId, UserIP);
            return new JsonResult(response);
        }

        //[HttpGet("usp_crud_FamilyDetail")]
        //public JsonResult usp_crud_FamilyDetail(dynamic data)
        //{
        //    var response = _IApplicantService.usp_crud_FamilyDetail(data);
        //    return new JsonResult(response);
        //}

        [HttpPost("usp_crud_ApplicantPetDetail")]
        public JsonResult usp_crud_ApplicantPetDetail(List<PetDetail> obj)
        {
            DataTable dt = SabSath.Application.Helper.CommonMethodHelper.ToDataTable(obj);
            var response = _IApplicantService.usp_crud_ApplicantPetDetail(obj, dt);
            return new JsonResult(response);
        }

        //[HttpPost("usp_crud_AssetDetail")]
        //public JsonResult usp_crud_AssetDetail(List<AssetDetailsLists> obj)
        //{

        //    DataTable dt = SabSath.Application.Helper.CommonMethodHelper.ToDataTable(obj[0].data1);
        //    DataTable dt2 = SabSath.Application.Helper.CommonMethodHelper.ToDataTable(obj[0].data2);

        //    DataTable dt3 = new DataTable();

        //    dt3.Merge(dt);
        //    dt3.AcceptChanges();

        //    dt3.Merge(dt2);
        //    dt3.AcceptChanges();

        //    var response = _IApplicantService.usp_crud_AssetDetail(dt3);
        //    return new JsonResult(response);
        //}

        [HttpPost("SourceofDrinkingWater")]
        public JsonResult SourceofDrinkingWater(SourceOFDrinkingWater obj)
        {
            if (obj == null)
            {
                return null;
            }
            var response = _IApplicantService.SourceofDrinkingWater(obj);
            return new JsonResult(response);

        }

        //[HttpGet("usp_crud_ExpenseDetail")]
        //public JsonResult usp_crud_ExpenseDetail(dynamic data)
        //{
        //    var response = _IApplicantService.usp_crud_ExpenseDetail(data);
        //    return new JsonResult(response);
        //}

        [HttpGet("usp_Get_FamilyEduDetail")]
        public JsonResult usp_Get_FamilyEduDetail(int Caseid)
        {
            var response = _IApplicantService.usp_Get_FamilyEduDetail(Caseid);
            return new JsonResult(response);
        }

        [HttpGet("usp_Get_FamilyMedDetail")]
        public JsonResult usp_Get_FamilyMedDetail(int Caseid)
        {
            var response = _IApplicantService.usp_Get_FamilyMedDetail(Caseid);
            return new JsonResult(response);
        }

        [HttpGet("usp_Get_ApplicantExpenseDet")]
        public JsonResult usp_Get_ApplicantExpenseDet(int Caseid)
        {
            var response = _IApplicantService.usp_Get_ApplicantExpenseDet(Caseid);
            return new JsonResult(response);
        }

        [HttpGet("usp_Get_GuardianDet")]
        public JsonResult usp_Get_GuardianDet(int Caseid)
        {
            var response = _IApplicantService.usp_Get_GuardianDet(Caseid);
            return new JsonResult(response);
        }

        [HttpGet("usp_GetCaseDetails")]
        public JsonResult usp_GetCaseDetails(int Caseid)
        {
            var response = _IApplicantService.usp_GetCaseDetails(Caseid);
            return new JsonResult(response);
        }

        [HttpGet("usp_GetApplicantPetDetails")]
        public JsonResult usp_GetApplicantPetDetails(int Caseid)
        {
            var response = _IApplicantService.usp_GetApplicantPetDetails(Caseid);
            return new JsonResult(response);
        }

        [HttpGet("usp_GetApplicantExpenseDetails")]
        public JsonResult usp_GetApplicantExpenseDetails(int Caseid)
        {
            var response = _IApplicantService.usp_GetApplicantExpenseDetails(Caseid);
            return new JsonResult(response);
        }

        [HttpGet("usp_GetApplicantAssetDetails")]
        public JsonResult usp_GetApplicantAssetDetails(int Caseid)
        {
            var response = _IApplicantService.usp_GetApplicantAssetDetails(Caseid);
            return new JsonResult(response);
        }

        [HttpPost("usp_ApplicantPrimaryInfo")]
        public JsonResult usp_ApplicantPrimaryInfo(List<ApplicantPrimaryInfo> obj, int operationid, int UserId, string UserIP, DateTime Date, int ContactID)
        {
            DataTable dt = SabSath.Application.Helper.CommonMethodHelper.ToDataTable(obj[0].data1);
            DataTable dt2 = SabSath.Application.Helper.CommonMethodHelper.ToDataTable(obj[0].data2);
            DataTable dt3 = SabSath.Application.Helper.CommonMethodHelper.ToDataTable(obj[0].data3);
            var response = _IApplicantService.usp_ApplicantPrimaryInfo(dt, dt2, dt3, operationid, UserId, UserIP, Date, ContactID);
            return new JsonResult(response);
        }

        [HttpPost("ForgetPassword")]
        public JsonResult ForgetPassword(string username)
        {
            var response = _IApplicantService.ForgetPassword(username);
            return new JsonResult(response);
        }

        [HttpPost("usp_UserLogin_Operation")]
        public JsonResult usp_UserLogin_Operation(int OperationId, int? UserId, string Name, string EmailAddress, string Password, int RoleId, int? CreatedBy, string UserIP, bool IsActive, bool isfamilymember, bool isparentFamily, bool Is_Displayed_In_Menu)
        {
            var response = _IApplicantService.usp_UserLogin_Operation(OperationId, UserId, Name, EmailAddress, Password, RoleId, CreatedBy, UserIP, IsActive, isfamilymember, isparentFamily, Is_Displayed_In_Menu);
            return new JsonResult(response);
        }

        [HttpPost("UploadSupportingDoc")]
        public string UploadSupportingDoc(int Docid, int DocTypeId, int CaseId, int UserId, int OperationId, string UserIP, string FileName)
        {
            try
            {
                string path = "";
                DataSet ds = new DataSet();
                var files = HttpContext.Request.Form.Files;

                DataTable dt = new DataTable();
                dt.Columns.Add("DocTypeId");
                dt.Columns.Add("DocAttachmentPath");
                dt.Columns.Add("FileName");
                dt.Columns.Add("OrignalFileName");
                dt.Columns.Add("FileGeneratedName");

                string datestring = DateTime.Now.ToString("ddMMyyyyhhmmss");
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        var FileSave = Path.Combine("", hostingEnvironment.ContentRootPath + "/wwwroot/UploadImages/" + file.FileName);
                        var renamefilepath = Path.Combine("", hostingEnvironment.ContentRootPath + "/wwwroot/UploadImages/");
                        using (var stream = new FileStream(FileSave, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        System.IO.File.Copy(FileSave, renamefilepath + datestring + "_" + file.FileName);
                        System.IO.File.Delete(FileSave);
                        dt.Rows.Add(DocTypeId, "/UploadImages", FileName, file.FileName, datestring + "_" + file.FileName);
                    }
                }
                var response = _IApplicantService.UploadSupportingDoc(OperationId, Docid, CaseId, UserId, UserIP, dt);
                string json = JsonConvert.SerializeObject(response, Formatting.Indented);
                return json;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost("usp_crud_ApplicantMedicalDetail")]
        public JsonResult usp_crud_ApplicantMedicalDetail(List<ApplicantMedicalDetail> obj, int OperationId, int ApplicantMedicalDetailId, int UserId, DateTime CreatedDate, string UserIP)
        {
            var response = _IApplicantService.usp_crud_ApplicantMedicalDetail(obj, OperationId, ApplicantMedicalDetailId, UserId, CreatedDate, UserIP);
            return new JsonResult(response);
        }

        #region Working

        [HttpPost("Register_Applicant_Case")]
        public string Register_Applicant_Case(ApplicantContext.ApplicantCaseRegistration objCaseRegistration)
        {

            var response = _IApplicantService.usp_RegisteredApplicantCase(objCaseRegistration);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;


        }

        [HttpPost("Register_Applicant_Case_With_Document")]
        public IActionResult Register_Applicant_Case_With_Document([FromForm] DocumentAttachmentContext.FormDataWithDocument obj)
        {

            ApplicantContext.ApplicantCaseRegistration objCaseRegistration = Newtonsoft.Json.JsonConvert.DeserializeObject<ApplicantContext.ApplicantCaseRegistration>(obj.Data);
            var response = _IApplicantService.usp_RegisteredApplicantCase(objCaseRegistration, obj.AttachedFiles, hostingEnvironment);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);


            return Ok(json);


        }

        [HttpPost("Crud_Personal_Information_Contact_Detail")]
        public string Crud_Personal_Information_Contact_Detail(ApplicantContext.ApplicantPersonalInfoContactDetail objData)
        {

            var response = _IApplicantService.usp_Crud_Personal_Info_Contact_Detail(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;


        }

        [HttpPost("Crud_Guardian_Detail")]
        public string Crud_Guardian_Detail(ApplicantContext.ApplicantGuardianDetail objData)
        {
            var response = _IApplicantService.usp_Crud_Guardian_Detail(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;


        }

        [HttpPost("Crud_Monthly_Expense_Detail")]
        public string Crud_Monthly_Expense_Detail(ApplicantContext.ApplicantMonthlyExpenseDetail objData)
        {
            var response = _IApplicantService.usp_Crud_Monthly_Expense_Detail(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;


        }

        [HttpPost("Crud_Pet_Detail")]
        public string Crud_Pet_Detail(ApplicantContext.ApplicantPetDetail objData)
        {
            var response = _IApplicantService.usp_Crud_Pet_Detail(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;


        }

        [HttpPost("Crud_Asset_Detail")]
        public string Crud_Asset_Detail(ApplicantContext.ApplicantAssetDetail objData)
        {
            var response = _IApplicantService.usp_Crud_Asset_Detail(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;


        }

        [HttpPost("Crud_Family_Detail")]
        public string Crud_Family_Detail(ApplicantContext.ApplicantFamilyDetail objData)
        {
            try
            {
                var response = _IApplicantService.usp_Crud_Family_Detail(objData, null);
                string json = JsonConvert.SerializeObject(response, Formatting.Indented);
                return json;
            }
            catch (Exception e)
            {
                string json = JsonConvert.SerializeObject(e.Message, Formatting.Indented);
                return json;
            }
        }

        [HttpPost("Crud_Family_Detail_Image")]
        public string Crud_Family_Detail_Image()
        {
            ApplicantContext.ApplicantFamilyDetail objData = new ApplicantContext.ApplicantFamilyDetail();
            try
            {
                var files = HttpContext.Request.Form.Files;
                var data = HttpContext.Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                foreach (var item in data)
                {
                    switch (item.Key)
                    {
                        case "OperationId":
                            objData.OperationId = Convert.ToInt32(item.Value);
                            break;
                        case "ApplicantCase_InvestigationId":
                            objData.ApplicantCase_InvestigationId = Convert.ToInt32(item.Value);
                            break;
                        case "ApplicantFamilyDetailId":
                            objData.ApplicantFamilyDetailId = Convert.ToInt32(item.Value);
                            break;
                        case "Name":
                            objData.Name = item.Value;
                            break;
                        case "Cnic":
                            objData.Cnic = item.Value;
                            break;
                        case "Mother_Father_HusbandName":
                            objData.Mother_Father_HusbandName = item.Value;
                            break;
                        case "DateOfBirth":
                            objData.DateOfBirth = (item.Value == "null" ? null : Convert.ToDateTime(item.Value));
                            break;
                        case "IsDeceased":
                            objData.IsDeceased = Convert.ToBoolean(item.Value);
                            break;
                        case "DateOfDeath":
                            objData.DateOfDeath = (item.Value == "null" ? null : Convert.ToDateTime(item.Value));
                            break;
                        case "RelationId":
                            objData.RelationId = Convert.ToInt32(item.Value);
                            break;
                        case "ReligionId":
                            objData.ReligionId = Convert.ToInt32(item.Value);
                            break;
                        case "GenderId":
                            objData.GenderId = Convert.ToInt32(item.Value);
                            break;
                        case "ContactTypeId":
                            objData.ContactTypeId = Convert.ToInt32(item.Value);
                            break;
                        case "MaritalStatusId":
                            objData.MaritalStatusId = Convert.ToInt32(item.Value);
                            break;
                        case "IsPartOfBannedOrg":
                            objData.IsPartOfBannedOrg = Convert.ToBoolean(item.Value);
                            break;
                        case "IsInvolveInCriminalActivity":
                            objData.IsInvolveInCriminalActivity = Convert.ToBoolean(item.Value);
                            break;
                        case "HasMedicalHistory":
                            objData.HasMedicalHistory = Convert.ToBoolean(item.Value);
                            break;
                        case "Remarks":
                            objData.Remarks = item.Value;
                            break;
                        case "ContactNumber":
                            objData.ContactNumber = item.Value;
                            break;
                        case "UserId":
                            objData.UserId = Convert.ToInt32(item.Value);
                            break;
                        case "UserIP":
                            objData.UserIP = item.Value;
                            break;
                        case "CanRead":
                            objData.CanRead = Convert.ToBoolean(item.Value);
                            break;
                        case "CanWrite":
                            objData.CanWrite = Convert.ToBoolean(item.Value);
                            break;
                        case "IsEmployeed":
                            objData.IsEmployeed = Convert.ToBoolean(item.Value);
                            break;
                        case "IsJobList":
                            objData.IsJobList = Convert.ToBoolean(item.Value);
                            break;
                        case "JobRemarks":
                            objData.JobRemarks = item.Value;
                            break;
                        case "LastWorkExperience":
                            objData.LastWorkExperience = item.Value;
                            break;
                        case "Orphan":
                            objData.Orphan = Convert.ToBoolean(item.Value);
                            break;
                        case "FamilyMemberPicture":
                            objData.FamilyMemberPicture = item.Value;
                            break;
                    }
                }
                DataTable dt = new DataTable();
                dt.Columns.Add("DocTypeId");
                dt.Columns.Add("DocAttachmentPath");
                dt.Columns.Add("RelationId");
                dt.Columns.Add("FileName");
                dt.Columns.Add("FileGeneratedName");

                int familymemberpictureID = (int)SabSath.Application.Helper.EnumHelper.Document_Type.FamilyMemberPicture;
                List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG", ".JPEG", ".TIFF" };

                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        string datestring = DateTime.Now.ToString("ddMMyyyyhhmmss");
                        //objData.FileName = file.FileName;
                        string FileGeneratedName = datestring + "_" + file.FileName;

                        var FileSave = Path.Combine("", hostingEnvironment.ContentRootPath + "/wwwroot/UploadImages/" + file.FileName);
                        var renamefilepath = Path.Combine("", hostingEnvironment.ContentRootPath + "/wwwroot/UploadImages/");
                        using (var stream = new FileStream(FileSave, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        System.IO.File.Copy(FileSave, renamefilepath + datestring + "_" + file.FileName);
                        System.IO.File.Delete(FileSave);
                        dt.Rows.Add(familymemberpictureID, "/UploadImages", objData.ApplicantFamilyDetailId, file.FileName, FileGeneratedName);
                    }
                }
                var response = _IApplicantService.usp_Crud_Family_Detail(objData, dt);
                string json = JsonConvert.SerializeObject(response, Formatting.Indented);
                return json;

            }
            catch (Exception e)
            {
                //string json = JsonConvert.SerializeObject(e.Message, Formatting.Indented);
                //var response = _IApplicantService.usp_Crud_Family_Detail(objData, null);
                //string json = JsonConvert.SerializeObject(response, Formatting.Indented);
                //return json;
                string json = e.Message;
                return json;
            }
        }

        [HttpPost("Crud_Family_Job_Experience_Detail")]
        public string Crud_Family_Job_Experience_Detail(ApplicantContext.ApplicantFamilyJobExperienceDetail objData)
        {
            var response = _IApplicantService.usp_Crud_Family_Job_Experience_Detail(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;


        }

        [HttpPost("Crud_Family_Education_Detail")]
        public string Crud_Family_Education_Detail(ApplicantContext.ApplicantFamilyEducationDetail objData)
        {
            var response = _IApplicantService.usp_Crud_Family_Education_Detail(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;


        }

        [HttpPost("EducationalCounselling_List_Table")]
        public string EducationalCounselling_List_Table(ApplicantContext.EducationalCounselling objData)
        {
            var response = _IApplicantService.usp_Crud_EducationalCounselling(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("Crud_Family_Medical_Card_Detail")]
        public string Crud_Family_Medical_Card_Detail(ApplicantContext.ApplicantFamilyMedicalCardDetail objData)
        {
            var response = _IApplicantService.usp_Crud_Medical_Card_Detail(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;


        }
        [HttpPost("GetCaseSupportData")]
        public string GetCaseSupportData(int Id)
        {
            var response = _IApplicantService.GetCaseSupportData(Id);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;


        }

        [HttpPost("Crud_Family_Medical_Disability_Detail")]
        public string Crud_Family_Medical_Disability_Detail(ApplicantContext.ApplicantFamilyMedicalDisabilityDetail objData)
        {
            var response = _IApplicantService.usp_Crud_Medical_Disability_Detail(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;


        }

        [HttpPost("Crud_Family_Medical_Disease_Detail")]
        public string Crud_Family_Medical_Disease_Detail(ApplicantContext.ApplicantFamilyMedicalDiseaseDetail objData)
        {
            var response = _IApplicantService.usp_Crud_Medical_Disease_Detail(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;


        }

        [HttpPost("Get_Applicant_List")]
        public string Get_Applicant_List(ApplicantContext.ApplicantList objData)

        {
            var response = _IApplicantService.usp_Get_Applicant_List(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;


        }

        [HttpPost("Get_Physical_Audit_List")]
        public string Get_Physical_Audit_List(ApplicantContext.PhysicalAuditList objData)

        {
            var response = _IApplicantService.Get_Physical_Audit_List(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;


        }

        [HttpPost("Crud_Applicant_Support_Detail")]
        public string Crud_Applicant_Support_Detail(ApplicantContext.ApplicantSupport objData)
        {
            var response = _IApplicantService.usp_Crud_Applicant_Support_Detail(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;


        }

        [HttpPost("Crud_Applicant_Asset_Detail_Home_Applaince")]
        public string Crud_Applicant_Asset_Detail_Home_Applaince(ApplicantContext.ApplicantAssetDetailHomeApplainces objData)
        {
            var response = _IApplicantService.usp_Crud_Applicant_Asset_Detail_Home_Applainces(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;


        }

        [HttpPost("Crud_Applicant_Personal_Information_Detail")]
        public string Crud_Applicant_Personal_Information_Detail(ApplicantContext.ApplicantPersonalInformation objData)
        {
            var response = _IApplicantService.usp_Crud_Applicant_Personal_Information_Detail(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;


        }

        [HttpPost("Crud_Followup")]
        public string Crud_Followup(ApplicantContext.Followup obj)
        {
            var response = _IApplicantService.Crud_Followup(obj);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("Crud_Followup_Edit")]
        public string Crud_Followup_Edit(ApplicantContext.Followup obj)
        {
            var response = _IApplicantService.Crud_Followup_Edid(obj);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("Applicant_Case_Re_Investigate")]
        public string Applicant_Case_Re_Investigate(ApplicantContext.ApplicantCaseReInvestigate objData)
        {
            var response = _IApplicantService.usp_Applicant_Case_Re_Investigate(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;


        }

        [HttpPost("Applicant_Crud_Loan_Detail")]
        public string Applicant_Crud_Loan_Detail(ApplicantContext.ApplicantLoanDetail objData)
        {
            var response = _IApplicantService.usp_Applicant_Crud_Loan_Detail(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;


        }

        [HttpPost("Applicant_Crud_Source_Of_Drinking_SanatationAndWashroom")]
        public string Applicant_Crud_Source_Of_Drinking_SanatationAndWashroom(ApplicantContext.ApplicantCaseSourceOfDrinkingSanatationAndWashroom objData)
        {
            var response = _IApplicantService.usp_Crud_Applicant_Source_Of_Drinking_Water_Sanatation_And_Washroom(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("ApplicantCase_StatusHistory")]
        public string ApplicantCase_StatusHistory(ApplicantContext.ApplicantCase_StatusHistory objData)
        {
            var response = _IApplicantService.ApplicantCase_StatusHistory(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;


        }

        [HttpPost("Assign_Investigator")]
        public string SP_Assign_Investigator(ApplicantContext.Assign_Investigator objData)
        {
            var response = _IApplicantService.Assign_Investigator(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("JobList")]
        public string JobList(ApplicantContext.JobList objData)
        {
            var response = _IApplicantService.JobList(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("UpdatePaymentMethod")]
        public string UpdatePaymentMethod(ApplicantContext.PaymentMethod objData)
        {
            var response = _IApplicantService.UpdatePaymentMethod(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("GetApplicantCaseHistory")]
        public string GetApplicantCaseHistory(ApplicantContext.GetApplicantCaseHistory objData)
        {
            var response = _IApplicantService.GetApplicantCaseHistory(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("UpdateSupportDetail")]
        public string UpdateSupportDetail(ApplicantContext.SupportDetail objData)
        {
            var response = _IApplicantService.UpdateSupportDetail(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("GetDashboardData")]
        public string GetDashboardData(int? UserId)
        {
            var response = _IApplicantService.GetDashboardData(UserId);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        //Working Manzoor
        [HttpPost("Get_PrimarySupportDetailShow")]
        public string Get_PrimarySupportDetailShow(int? ID)
        {
            var response = _IApplicantService.Get_PrimarySupportDetailShow(ID);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("Update_Refrel")]
        public string Update_Refrel(ApplicantContext.ApplicantCaseRegistration objapplist)
        {
            var response = _IApplicantService.Update_Refrel(objapplist);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;


        }
        #endregion
    }
}
