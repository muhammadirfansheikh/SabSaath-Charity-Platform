using SabSath.Application.Helper;
using SabSath.Core.Models;
using SabSath.Core.Utilities;
using SabSath.Data.DataRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace SabSath.Application.Repositiories
{
    public interface IApplicantService
    {
        //dynamic usp_Primary_Operation(ApplicantInformation objApplicantInformation, ApplicantCaseDetail objApplicantCaseDetail);
        dynamic usp_Combo_Operation(ComboOperation obj);
        dynamic usp_GetReferrerDataAccordingToReferrerType(int referrerType);
        dynamic usp_RegisteredApplicantCase(ApplicantContext.ApplicantCaseRegistration objPrimaryInformation);
        dynamic usp_RegisteredApplicantCase(ApplicantContext.ApplicantCaseRegistration objPrimaryInformation, List<IFormFile> FilesData, IHostingEnvironment hostingEnvironment);
        dynamic usp_Crud_Personal_Info_Contact_Detail(ApplicantContext.ApplicantPersonalInfoContactDetail objData);
        dynamic usp_Crud_Guardian_Detail(ApplicantContext.ApplicantGuardianDetail objData);
        dynamic usp_Crud_Monthly_Expense_Detail(ApplicantContext.ApplicantMonthlyExpenseDetail objData);
        dynamic usp_Crud_Pet_Detail(ApplicantContext.ApplicantPetDetail objData);
        dynamic usp_Crud_Asset_Detail(ApplicantContext.ApplicantAssetDetail objData);
        dynamic usp_Crud_Family_Detail(ApplicantContext.ApplicantFamilyDetail objData, DataTable dt);
        dynamic usp_Crud_Family_Job_Experience_Detail(ApplicantContext.ApplicantFamilyJobExperienceDetail objData);
        dynamic usp_Crud_Family_Education_Detail(ApplicantContext.ApplicantFamilyEducationDetail objData);
        dynamic usp_Crud_Medical_Card_Detail(ApplicantContext.ApplicantFamilyMedicalCardDetail objData);
        dynamic usp_Crud_Medical_Disability_Detail(ApplicantContext.ApplicantFamilyMedicalDisabilityDetail objData);
        dynamic usp_Crud_EducationalCounselling(ApplicantContext.EducationalCounselling objData);
        dynamic usp_Crud_Medical_Disease_Detail(ApplicantContext.ApplicantFamilyMedicalDiseaseDetail objData);
        dynamic usp_Applicant_Case_Re_Investigate(ApplicantContext.ApplicantCaseReInvestigate objData);
        dynamic usp_Applicant_Crud_Loan_Detail(ApplicantContext.ApplicantLoanDetail objData);
        dynamic usp_Crud_Applicant_Source_Of_Drinking_Water_Sanatation_And_Washroom(ApplicantContext.ApplicantCaseSourceOfDrinkingSanatationAndWashroom objData);
        dynamic usp_Get_Applicant_List(ApplicantContext.ApplicantList objData);
        dynamic Get_Physical_Audit_List(ApplicantContext.PhysicalAuditList objData);
        dynamic usp_Crud_Applicant_Support_Detail(ApplicantContext.ApplicantSupport objData);
        dynamic usp_Crud_Applicant_Asset_Detail_Home_Applainces(ApplicantContext.ApplicantAssetDetailHomeApplainces objData);
        dynamic usp_Crud_Applicant_Personal_Information_Detail(ApplicantContext.ApplicantPersonalInformation objData);
        dynamic usp_Get_Applicant_Cases(dynamic data);
        dynamic usp_Get_Applicant_Basic_By_Id(int data);
        dynamic usp_Get_ApplicantApplicationData(int CaseId, int Tab_INDEX);
        dynamic usp_Assign_Investigator_Applicant_Case(dynamic data);
        dynamic Applicant_MarketingCase(MarketingCase obj, DataTable dt);
        dynamic GetData_MarketingCase(MarketingCase obj);
        //dynamic usp_Primary_Operation(ApplicantInformation objApplicantInformation, ApplicantCaseDetail objApplicantCaseDetail);
        dynamic usp_GetFamilyDetail(int CaseId);
        //dynamic usp_crud_GuardianDetail(List<ApplicantGuardianDetail> obj, int Operationid, int ID, string Date, int UserId, string UserIP);
        //dynamic usp_crud_ExpenseDetail(List<ApplicantExpenseDetail> obj, int Operationid, int ID, string Date, int UserId, string UserIP);
        dynamic usp_crud_ApplicantFamilyInformationDetail(List<ApplicantFamilyInformationDetail> obj, int Operationid, int ID, string Date, int UserId, string UserIP);
        //dynamic usp_crud_FamilyDetail(dynamic data);
        dynamic usp_crud_ApplicantPetDetail(List<PetDetail> obj, DataTable dt);
        //dynamic usp_crud_AssetDetail(DataTable dt);
        dynamic SourceofDrinkingWater(SourceOFDrinkingWater obj);
        dynamic CrudCaseSupport(int CaseDetailDetailId, int OperationId, DataTable dt, DateTime date, string UserIP, int UserId, int CaseId);
        dynamic usp_Get_FamilyEduDetail(int CaseId);
        dynamic usp_Get_FamilyMedDetail(int CaseId);
        dynamic usp_Get_ApplicantExpenseDet(int CaseId);
        dynamic usp_Get_GuardianDet(int CaseId);
        dynamic usp_GetCaseDetails(int CaseId);
        dynamic usp_GetApplicantPetDetails(int CaseId);
        dynamic usp_GetApplicantExpenseDetails(int CaseId);
        dynamic usp_GetApplicantAssetDetails(int CaseId);
        dynamic usp_ApplicantPrimaryInfo(DataTable dt, DataTable dt2, DataTable dt3, int operationid, int Userid, string UserIP, DateTime createdate, int ContactID);
        dynamic UploadSupportingDoc(int OperationId, Int32 DocId, int CaseId, int UserId, string UserIP, DataTable dt);
        dynamic ForgetPassword(string username);
        dynamic usp_UserLogin_Operation(int OperationId, int? UserId, string Name, string EmailAddress, string Password, int RoleId, int? CreatedBy, string UserIP, bool IsActive, bool isfamilymember, bool isparentFamily, bool Is_Displayed_In_Menu);
        dynamic usp_crud_ApplicantMedicalDetail(List<ApplicantMedicalDetail> obj, int OperationId, int ApplicantMedicalDetailId, int UserId, DateTime CreatedDate, string UserIP);
        dynamic Crud_Followup(ApplicantContext.Followup obj);
        dynamic Crud_Followup_Edid(ApplicantContext.Followup obj);
        dynamic GetCaseSupportData(int Id);
        dynamic ApplicantCase_StatusHistory(ApplicantContext.ApplicantCase_StatusHistory obj);
        dynamic Assign_Investigator(ApplicantContext.Assign_Investigator obj);
        dynamic JobList(ApplicantContext.JobList objData);
        dynamic UpdatePaymentMethod(ApplicantContext.PaymentMethod objData);
        dynamic GetApplicantCaseHistory(ApplicantContext.GetApplicantCaseHistory objData);
        dynamic UpdateSupportDetail(ApplicantContext.SupportDetail objData);
        dynamic GetDashboardData(int? UserId);
        dynamic Get_PrimarySupportDetailShow(int? ID);
        dynamic Update_Refrel(ApplicantContext.ApplicantCaseRegistration objapplist);
    }
    public class ApplicantService : IApplicantService
    {
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();

        private readonly IApplicantDataDapperRepository _IApplicantDataDapperRepository;
        public ApplicantService(IApplicantDataDapperRepository ApplicantDataDapperRepository)
        {
            _IApplicantDataDapperRepository = ApplicantDataDapperRepository;
        }
        //public dynamic usp_Primary_Operation(ApplicantInformation objApplicantInformation, ApplicantCaseDetail objApplicantCaseDetail)
        //{
        //    try
        //    {
        //        dynamic obj_response = _IApplicantDataDapperRepository.usp_PrimaryInfo_Operation(objApplicantInformation,objApplicantCaseDetail);
        //        if (obj_response != null)
        //        {
        //            responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
        //        }
        //        else
        //        {
        //            responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
        //        }
        //        return responseDetail;
        //    }
        //    catch
        //    {
        //        return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
        //    }
        //}

        public dynamic usp_Combo_Operation(ComboOperation obj)
        {
            try
            {
                dynamic obj_response = _IApplicantDataDapperRepository.usp_Combo_Operation(obj);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic usp_Get_Applicant_Cases(dynamic data)
        {
            try
            {

                dynamic obj_response = _IApplicantDataDapperRepository.usp_Get_Applicant_Cases(data);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception e)
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic usp_Assign_Investigator_Applicant_Case(dynamic data)
        {
            try
            {

                dynamic obj_response = _IApplicantDataDapperRepository.usp_Assign_Investigator_Applicant_Case(data);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception e)
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic usp_Get_ApplicantApplicationData(int CaseId, int Tab_INDEX)
        {
            try
            {

                DataSet obj_response = _IApplicantDataDapperRepository.usp_Get_ApplicantApplicationData(CaseId, Tab_INDEX);
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
        public dynamic usp_Get_Applicant_Basic_By_Id(int data)
        {
            try
            {

                dynamic obj_response = _IApplicantDataDapperRepository.usp_Get_Applicant_Basic_By_Id(data);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception e)
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic usp_RegisteredApplicantCase(ApplicantContext.ApplicantCaseRegistration objApplicantRegistartion)
        {
            try
            {

                DataSet obj_response = _IApplicantDataDapperRepository.usp_RegisteredApplicantCase(objApplicantRegistartion);
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
        public dynamic usp_RegisteredApplicantCase(ApplicantContext.ApplicantCaseRegistration objApplicantRegistartion, List<IFormFile> FilesData, IHostingEnvironment hostingEnvironment)
        {
            try
            {
                List<DocumentAttachmentContext.CommonTableDocumentAttachment> objDocData = new List<DocumentAttachmentContext.CommonTableDocumentAttachment>();

                DataTable DocumentData;

                dynamic DocumentListData;


                if (FilesData.Count > 0 && FilesData != null)
                {

                    objDocData = CommonMethodHelper.UploadDocument(FilesData, hostingEnvironment, "/wwwroot/UploadImages/Applicant_Case_Registration/");

                    if (objDocData.Count > 0)
                        objDocData[0].DocTypeId = (Int32)EnumHelper.Document_Type.NIC_Front;
                    if (objDocData.Count > 1)
                        objDocData[1].DocTypeId = (Int32)EnumHelper.Document_Type.NIC_Back;
                    if (objDocData.Count > 2)
                        objDocData[2].DocTypeId = (Int32)EnumHelper.Document_Type.Application;
                    if (objDocData.Count > 3)
                        objDocData[3].DocTypeId = (Int32)EnumHelper.Document_Type.Applicant_Photo;
                    if (objDocData.Count > 4)
                        objDocData[4].DocTypeId = (Int32)EnumHelper.Document_Type.Thumb_Print;

                    objDocData = objDocData.Where(x => x.FileName != "NoFile.txt").ToList();

                    DocumentListData = objDocData;



                }
                else
                    DocumentListData = objDocData.AsEnumerable().ToList();



                DocumentData = CommonMethodHelper.ToDataTable(DocumentListData);

                DataSet obj_response = _IApplicantDataDapperRepository.usp_RegisteredApplicantCase(objApplicantRegistartion, DocumentData);
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
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, e.Message);
            }
        }
        public dynamic usp_Crud_Personal_Info_Contact_Detail(ApplicantContext.ApplicantPersonalInfoContactDetail ObjData)
        {
            try
            {

                DataSet obj_response = _IApplicantDataDapperRepository.usp_Crud_Personal_Info_Contact_Detail(ObjData);
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
        public dynamic usp_Crud_Guardian_Detail(ApplicantContext.ApplicantGuardianDetail ObjData)
        {
            try
            {

                DataSet obj_response = _IApplicantDataDapperRepository.usp_Crud_Guardian_Detail(ObjData);
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
        public dynamic usp_Crud_Monthly_Expense_Detail(ApplicantContext.ApplicantMonthlyExpenseDetail ObjData)
        {
            try
            {

                DataSet obj_response = _IApplicantDataDapperRepository.usp_Crud_Monthly_Expense_Detail(ObjData);
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
        public dynamic usp_Crud_Pet_Detail(ApplicantContext.ApplicantPetDetail ObjData)
        {
            try
            {

                DataSet obj_response = _IApplicantDataDapperRepository.usp_Crud_Pet_Detail(ObjData);
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
        public dynamic usp_Crud_Asset_Detail(ApplicantContext.ApplicantAssetDetail ObjData)
        {
            try
            {

                DataSet obj_response = _IApplicantDataDapperRepository.usp_Crud_Asset_Detail(ObjData);
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
        public dynamic usp_Crud_Family_Detail(ApplicantContext.ApplicantFamilyDetail ObjData, DataTable dt)
        {
            try
            {

                DataSet obj_response = _IApplicantDataDapperRepository.usp_Crud_Family_Detail(ObjData, dt);
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
        public dynamic usp_Crud_Family_Job_Experience_Detail(ApplicantContext.ApplicantFamilyJobExperienceDetail ObjData)
        {
            try
            {

                DataSet obj_response = _IApplicantDataDapperRepository.usp_Crud_Family_Job_Experience_Detail(ObjData);
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
        public dynamic usp_Crud_Family_Education_Detail(ApplicantContext.ApplicantFamilyEducationDetail ObjData)
        {
            try
            {

                DataSet obj_response = _IApplicantDataDapperRepository.usp_Crud_Family_Education_Detail(ObjData);
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
        public dynamic usp_Crud_EducationalCounselling(ApplicantContext.EducationalCounselling ObjData)
        {
            try
            {
                DataSet obj_response = _IApplicantDataDapperRepository.usp_Crud_EducationalCounselling(ObjData);
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
        public dynamic usp_Crud_Medical_Card_Detail(ApplicantContext.ApplicantFamilyMedicalCardDetail ObjData)
        {
            try
            {

                DataSet obj_response = _IApplicantDataDapperRepository.usp_Crud_Medical_Card_Detail(ObjData);
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
        public dynamic usp_Crud_Medical_Disability_Detail(ApplicantContext.ApplicantFamilyMedicalDisabilityDetail ObjData)
        {
            try
            {

                DataSet obj_response = _IApplicantDataDapperRepository.usp_Crud_Medical_Disability_Detail(ObjData);
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
        public dynamic usp_Crud_Medical_Disease_Detail(ApplicantContext.ApplicantFamilyMedicalDiseaseDetail ObjData)
        {
            try
            {

                DataSet obj_response = _IApplicantDataDapperRepository.usp_Crud_Medical_Disease_Detail(ObjData);
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
        public dynamic usp_Crud_Applicant_Source_Of_Drinking_Water_Sanatation_And_Washroom(ApplicantContext.ApplicantCaseSourceOfDrinkingSanatationAndWashroom ObjData)
        {
            try
            {

                DataSet obj_response = _IApplicantDataDapperRepository.usp_Crud_Applicant_SourceOfDrinking_Sanatation_And_Washroom(ObjData);
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
        public dynamic usp_Applicant_Crud_Loan_Detail(ApplicantContext.ApplicantLoanDetail ObjData)
        {
            try
            {

                DataSet obj_response = _IApplicantDataDapperRepository.usp_Crud_Applicant_Loan_Detail(ObjData);
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
        public dynamic usp_Applicant_Case_Re_Investigate(ApplicantContext.ApplicantCaseReInvestigate ObjData)
        {
            try
            {

                DataSet obj_response = _IApplicantDataDapperRepository.usp_Applicant_Case_Re_Investigate(ObjData);
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
        public dynamic usp_Get_Applicant_List(ApplicantContext.ApplicantList ObjData)
        {
            try
            {

                DataSet obj_response = _IApplicantDataDapperRepository.usp_Get_Applicant_List(ObjData);
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
        public dynamic Get_Physical_Audit_List(ApplicantContext.PhysicalAuditList ObjData)
        {
            try
            {

                DataSet obj_response = _IApplicantDataDapperRepository.Get_Physical_Audit_List(ObjData);
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
        public dynamic usp_Crud_Applicant_Support_Detail(ApplicantContext.ApplicantSupport obj)
        {
            try
            {
                List<ApplicantContext.ApplicantCaseSupport_UD> objApplicantSupportData = new List<ApplicantContext.ApplicantCaseSupport_UD>();

                DataTable SupportData;

                dynamic SupportListData;


                if (obj.ApplicantSupportArray != null)
                    SupportListData = obj.ApplicantSupportArray.AsEnumerable().ToList();
                else
                    SupportListData = objApplicantSupportData.AsEnumerable().ToList();

                SupportData = CommonMethodHelper.ToDataTable(SupportListData);


                DataSet obj_response = _IApplicantDataDapperRepository.usp_Crud_Applicant_Support_Detail(obj, SupportData);

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
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, e.Message.ToString());
            }
        }
        public dynamic usp_Crud_Applicant_Personal_Information_Detail(ApplicantContext.ApplicantPersonalInformation obj)
        {
            try
            {
                List<ApplicantContext.ApplicantPersonalInformation_UD> objApplicantSupportData = new List<ApplicantContext.ApplicantPersonalInformation_UD>();
                DataTable PersonalInformationData;
                dynamic PersonalInformationListData;

                if (obj.ArrayApplicantPersonalInformation != null)
                    PersonalInformationListData = obj.ArrayApplicantPersonalInformation.AsEnumerable().ToList();
                else
                    PersonalInformationListData = objApplicantSupportData.AsEnumerable().ToList();


                PersonalInformationData = CommonMethodHelper.ToDataTable(PersonalInformationListData);


                DataSet obj_response = _IApplicantDataDapperRepository.usp_Crud_Applicant_Personal_Information_Detail(obj, PersonalInformationData);

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
        public dynamic usp_Crud_Applicant_Asset_Detail_Home_Applainces(ApplicantContext.ApplicantAssetDetailHomeApplainces obj)
        {
            try
            {
                List<ApplicantContext.ApplicantAssetDetailHomeApplainces_UD> objApplicantSupportData = new List<ApplicantContext.ApplicantAssetDetailHomeApplainces_UD>();
                DataTable HomeApplainceData;
                dynamic HomeApplainceListData;

                if (obj.AssetHomeApplainceArray != null)
                    HomeApplainceListData = obj.AssetHomeApplainceArray.AsEnumerable().ToList();
                else
                    HomeApplainceListData = objApplicantSupportData.AsEnumerable().ToList();
                HomeApplainceData = CommonMethodHelper.ToDataTable(HomeApplainceListData);


                DataSet obj_response = _IApplicantDataDapperRepository.usp_Crud_Applicant_Asset_Detail_Home_Allaince(obj, HomeApplainceData);

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
        public dynamic usp_GetReferrerDataAccordingToReferrerType(int referrerType)
        {
            try
            {
                dynamic obj_response = _IApplicantDataDapperRepository.usp_GetReferrerDataAccordingToReferrerType(referrerType);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic Applicant_MarketingCase(MarketingCase obj, DataTable dt)
        {
            try
            {
                try
                {
                    DataSet obj_response = _IApplicantDataDapperRepository.Applicant_MarketingCase(obj, dt);
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
        public dynamic GetData_MarketingCase(MarketingCase obj)
        {
            try
            {
                DataSet obj_response = _IApplicantDataDapperRepository.GetData_MarketingCase(obj); 
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
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic usp_GetFamilyDetail(int CaseId)
        {
            try
            {
                dynamic obj_response = _IApplicantDataDapperRepository.usp_GetFamilyDetail(CaseId);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        //public dynamic usp_crud_GuardianDetail(List<ApplicantGuardianDetail> obj, int Operationid, int ID, string Date, int UserId, string UserIP)
        //{
        //    try
        //    {
        //        DataTable dt = CommonMethodHelper.ToDataTable(obj);
        //        dynamic obj_response = _IApplicantDataDapperRepository.usp_crud_GuardianDetail(dt, Operationid, ID, Date, UserId, UserIP);
        //        if (obj_response != null)
        //        {
        //            responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
        //        }
        //        else
        //        {
        //            responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
        //        }
        //        return responseDetail;
        //    }
        //    catch
        //    {
        //        return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
        //    }
        //}

        //public dynamic usp_crud_ExpenseDetail(List<ApplicantExpenseDetail> obj, int Operationid, int ID, string Date, int UserId, string UserIP)
        //{
        //    try
        //    {
        //        DataTable dt = CommonMethodHelper.ToDataTable(obj);
        //        dynamic obj_response = _IApplicantDataDapperRepository.usp_crud_ExpenseDetail(dt, Operationid, ID, Date, UserId, UserIP);
        //        if (obj_response != null)
        //        {
        //            responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
        //        }
        //        else
        //        {
        //            responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
        //        }
        //        return responseDetail;
        //    }
        //    catch
        //    {
        //        return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
        //    }
        //}
        //public dynamic usp_crud_FamilyDetail(dynamic data)
        //{
        //    try
        //    {
        //        dynamic obj_response = _IApplicantDataDapperRepository.usp_crud_FamilyDetail(data);
        //        if (obj_response != null)
        //        {
        //            responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
        //        }
        //        else
        //        {
        //            responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
        //        }
        //        return responseDetail;
        //    }
        //    catch
        //    {
        //        return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
        //    }
        //}
        public dynamic usp_crud_ApplicantPetDetail(List<PetDetail> obj, DataTable dt)
        {
            try
            {

                dynamic obj_response = _IApplicantDataDapperRepository.usp_crud_ApplicantPetDetail(obj, dt);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        //public dynamic usp_crud_AssetDetail(DataTable dt)
        //{
        //    try
        //    {

        //        dynamic obj_response = _IApplicantDataDapperRepository.usp_crud_AssetDetal(dt);
        //        if (obj_response != null)
        //        {
        //            responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
        //        }
        //        else
        //        {
        //            responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
        //        }
        //        return responseDetail;
        //    }
        //    catch
        //    {
        //        return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
        //    }
        //}
        public dynamic SourceofDrinkingWater(SourceOFDrinkingWater obj)
        {
            try
            {
                dynamic obj_response = _IApplicantDataDapperRepository.SourceofDrinkingWater(obj);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic usp_crud_ApplicantFamilyInformationDetail(List<ApplicantFamilyInformationDetail> obj, int Operationid, int ID, string Date, int UserId, string UserIP)
        {
            try
            {
                DataTable dt = CommonMethodHelper.ToDataTable(obj);
                dynamic obj_response = _IApplicantDataDapperRepository.usp_crud_ApplicantFamilyInformationDetail(dt, Operationid, ID, Date, UserId, UserIP);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic usp_Get_FamilyEduDetail(int CaseId)
        {
            try
            {
                dynamic obj_response = _IApplicantDataDapperRepository.usp_Get_FamilyEduDetail(CaseId);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic usp_Get_FamilyMedDetail(int CaseId)
        {
            try
            {
                dynamic obj_response = _IApplicantDataDapperRepository.usp_Get_FamilyMedDetail(CaseId);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic usp_Get_ApplicantExpenseDet(int CaseId)
        {
            try
            {
                dynamic obj_response = _IApplicantDataDapperRepository.usp_Get_ApplicantExpenseDet(CaseId);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic usp_Get_GuardianDet(int CaseId)
        {
            try
            {
                dynamic obj_response = _IApplicantDataDapperRepository.usp_Get_GuardianDet(CaseId);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic usp_GetCaseDetails(int CaseId)
        {
            try
            {
                dynamic obj_response = _IApplicantDataDapperRepository.usp_GetCaseDetails(CaseId);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic usp_GetApplicantPetDetails(int CaseId)
        {
            try
            {
                dynamic obj_response = _IApplicantDataDapperRepository.usp_GetApplicantPetDetails(CaseId);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic usp_GetApplicantExpenseDetails(int CaseId)
        {
            try
            {
                dynamic obj_response = _IApplicantDataDapperRepository.usp_GetApplicantExpenseDetails(CaseId);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic usp_GetApplicantAssetDetails(int CaseId)
        {
            try
            {
                dynamic obj_response = _IApplicantDataDapperRepository.usp_GetApplicantAssetDetails(CaseId);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic CrudCaseSupport(int CaseDetailDetailId, int OperationId, DataTable dt, DateTime date, string UserIP, int UserId, int CaseId)
        {
            try
            {
                dynamic obj_response = _IApplicantDataDapperRepository.CrudCaseSupport(CaseDetailDetailId, OperationId, dt, date, UserIP, UserId, CaseId);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic usp_ApplicantPrimaryInfo(DataTable dt, DataTable dt2, DataTable dt3, int operationid, int Userid, string UserIP, DateTime createdate, int ContactID)
        {
            try
            {
                dynamic obj_response = _IApplicantDataDapperRepository.usp_ApplicantPrimaryInfo(dt, dt2, dt3, operationid, Userid, UserIP, createdate, ContactID);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;

            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic ForgetPassword(string username)
        {
            try
            {
                dynamic obj_response = _IApplicantDataDapperRepository.ForgetPassword(username);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic usp_UserLogin_Operation(int OperationId, int? UserId, string Name, string EmailAddress, string Password, int RoleId, int? CreatedBy, string UserIP, bool IsActive, bool isfamilymember, bool isparentFamily, bool Is_Displayed_In_Menu)
        {
            try
            {
                dynamic obj_response = _IApplicantDataDapperRepository.usp_UserLogin_Operation(OperationId, UserId, Name, EmailAddress, Password, RoleId, CreatedBy, UserIP, IsActive, isfamilymember, isparentFamily, Is_Displayed_In_Menu);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic UploadSupportingDoc(int OperationId, Int32 DocId, int CaseId, int UserId, string UserIP, DataTable dt)
        {
            try
            {
                DataSet obj_response = _IApplicantDataDapperRepository.UploadSupportingDoc(OperationId, DocId, CaseId, UserId, UserIP, dt);
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
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }


        }
        public dynamic usp_crud_ApplicantMedicalDetail(List<ApplicantMedicalDetail> obj, int OperationId, int ApplicantMedicalDetailId, int UserId, DateTime CreatedDate, string UserIP)
        {
            try
            {
                DataTable dt = CommonMethodHelper.ToDataTable(obj);
                dynamic obj_response = _IApplicantDataDapperRepository.usp_crud_ApplicantMedicalDetail(dt, OperationId, ApplicantMedicalDetailId, UserId, CreatedDate, UserIP);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic Crud_Followup(ApplicantContext.Followup obj)
        {
            try
            {

                DataSet obj_response = _IApplicantDataDapperRepository.Crud_Followup(obj);
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
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic Crud_Followup_Edid(ApplicantContext.Followup obj)
        {
            try
            {

                DataSet obj_response = _IApplicantDataDapperRepository.Crud_Followup_Edit(obj);
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
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic GetCaseSupportData(int Id)
        {
            try
            {
                dynamic obj_response = _IApplicantDataDapperRepository.GetCaseSupportData(Id);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic ApplicantCase_StatusHistory(ApplicantContext.ApplicantCase_StatusHistory obj)
        {
            try
            {
                List<ApplicantContext.ApplicantCase_SupportHistory> objApplicantSupportDataHistory = new List<ApplicantContext.ApplicantCase_SupportHistory>();
                DataTable SupportHistoryData;
                dynamic SupportHistoryListData;

                if (obj.ArrayApplicantCaseSupportHistory != null)
                {
                    SupportHistoryListData = obj.ArrayApplicantCaseSupportHistory.AsEnumerable().ToList();
                }
                else
                {
                    SupportHistoryListData = objApplicantSupportDataHistory.AsEnumerable().ToList();
                }


                SupportHistoryData = CommonMethodHelper.ToDataTable(SupportHistoryListData);


                DataSet obj_response = _IApplicantDataDapperRepository.ApplicantCase_StatusHistory(obj, SupportHistoryData);

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
        public dynamic Assign_Investigator(ApplicantContext.Assign_Investigator obj)
        {
            try
            {

                DataSet obj_response = _IApplicantDataDapperRepository.Assign_Investigator(obj);
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
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic JobList(ApplicantContext.JobList objData)
        {
            try
            {

                DataSet obj_response = _IApplicantDataDapperRepository.JobList(objData);
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
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic UpdatePaymentMethod(ApplicantContext.PaymentMethod objData)
        {
            try
            {

                DataSet obj_response = _IApplicantDataDapperRepository.UpdatePaymentMethod(objData);
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
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic GetApplicantCaseHistory(ApplicantContext.GetApplicantCaseHistory objData)
        {
            try
            {

                DataSet obj_response = _IApplicantDataDapperRepository.GetApplicantCaseHistory(objData);
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
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic UpdateSupportDetail(ApplicantContext.SupportDetail objData)
        {
            try
            {
                DataSet obj_response = _IApplicantDataDapperRepository.UpdateSupportDetail(objData);
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
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic GetDashboardData(int? UserId)
        {
            try
            {
                DataSet obj_response = _IApplicantDataDapperRepository.GetDashboardData(UserId);
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
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic Get_PrimarySupportDetailShow(int? ID)
        {
            try
            {
                DataSet obj_response = _IApplicantDataDapperRepository.Get_PrimarySupportDetailShow(ID);
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
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic Update_Refrel(ApplicantContext.ApplicantCaseRegistration objapplist)
        {
            try
            {
                DataSet obj_response = _IApplicantDataDapperRepository.Update_Refrel(objapplist);
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
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
    }
}
