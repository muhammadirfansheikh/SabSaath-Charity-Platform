using Dapper;
using Newtonsoft.Json;
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
using SabSath.Core.Models;
using SabSath.Core.Model;
using System.Reflection;
using System.Globalization;

namespace SabSath.Data.DataRepository
{
    public interface IApplicantDataDapperRepository
    {
        //Task<IEnumerable<dynamic>> usp_PrimaryInfo_Operation(ApplicantInformation objApplicantInformation, ApplicantCaseDetail objApplicantCaseDetail);
        Task<IEnumerable<dynamic>> usp_Combo_Operation(ComboOperation obj);
        Task<IEnumerable<dynamic>> usp_Get_Applicant_Cases(dynamic data);
        Task<IEnumerable<dynamic>> usp_Assign_Investigator_Applicant_Case(dynamic data);
        Task<IEnumerable<dynamic>> usp_Get_Applicant_Basic_By_Id(int data);
        DataSet usp_Get_ApplicantApplicationData(int CaseId, int Tab_INDEX);
        Task<IEnumerable<dynamic>> usp_GetReferrerDataAccordingToReferrerType(int referrerType);
        DataSet usp_RegisteredApplicantCase(ApplicantContext.ApplicantCaseRegistration objApplicantCaseRegistation);
        DataSet usp_RegisteredApplicantCase(ApplicantContext.ApplicantCaseRegistration objApplicantCaseRegistation, DataTable DtDocumnetData);
        DataSet usp_Crud_Personal_Info_Contact_Detail(ApplicantContext.ApplicantPersonalInfoContactDetail objData);
        DataSet usp_Crud_Guardian_Detail(ApplicantContext.ApplicantGuardianDetail objData);
        DataSet usp_Crud_Monthly_Expense_Detail(ApplicantContext.ApplicantMonthlyExpenseDetail objData);
        DataSet usp_Crud_Pet_Detail(ApplicantContext.ApplicantPetDetail objData);
        DataSet usp_Crud_Asset_Detail(ApplicantContext.ApplicantAssetDetail objData);
        DataSet usp_Crud_Family_Detail(ApplicantContext.ApplicantFamilyDetail objData, DataTable dt);
        DataSet usp_Crud_Family_Job_Experience_Detail(ApplicantContext.ApplicantFamilyJobExperienceDetail objData);
        DataSet usp_Crud_Family_Education_Detail(ApplicantContext.ApplicantFamilyEducationDetail objData);
        DataSet usp_Crud_EducationalCounselling(ApplicantContext.EducationalCounselling objData);
        DataSet usp_Crud_Medical_Card_Detail(ApplicantContext.ApplicantFamilyMedicalCardDetail objData);
        DataSet usp_Crud_Medical_Disability_Detail(ApplicantContext.ApplicantFamilyMedicalDisabilityDetail objData);
        DataSet usp_Crud_Medical_Disease_Detail(ApplicantContext.ApplicantFamilyMedicalDiseaseDetail objData);
        DataSet usp_Applicant_Case_Re_Investigate(ApplicantContext.ApplicantCaseReInvestigate objData);
        DataSet usp_Crud_Applicant_Loan_Detail(ApplicantContext.ApplicantLoanDetail objData);
        DataSet usp_Crud_Applicant_SourceOfDrinking_Sanatation_And_Washroom(ApplicantContext.ApplicantCaseSourceOfDrinkingSanatationAndWashroom objData);
        DataSet usp_Get_Applicant_List(ApplicantContext.ApplicantList objData);
        DataSet Get_Physical_Audit_List(ApplicantContext.PhysicalAuditList objData);
        DataSet usp_Crud_Applicant_Support_Detail(ApplicantContext.ApplicantSupport objData, DataTable DtSupportData);
        DataSet usp_Crud_Applicant_Asset_Detail_Home_Allaince(ApplicantContext.ApplicantAssetDetailHomeApplainces objData, DataTable DtHomeApplainceData);
        DataSet usp_Crud_Applicant_Personal_Information_Detail(ApplicantContext.ApplicantPersonalInformation objData, DataTable DtPersonalInfoData);
        DataSet Applicant_MarketingCase(MarketingCase obj, DataTable dt);
        DataSet GetData_MarketingCase(MarketingCase obj);
        Task<IEnumerable<dynamic>> usp_GetFamilyDetail(int CaseId);
        //Task<IEnumerable<dynamic>> usp_crud_GuardianDetail(DataTable dt, int Operationid, int ID, string Date, int UserId, string UserIP);
        //Task<IEnumerable<dynamic>> usp_crud_ExpenseDetail(DataTable dt, int Operationid, int ID, string Date, int UserId, string UserIP);
        Task<IEnumerable<dynamic>> usp_crud_ApplicantFamilyInformationDetail(DataTable dt, int Operationid, int ID, string Date, int UserId, string UserIP);
        //Task<IEnumerable<dynamic>> usp_crud_FamilyDetail(dynamic data);
        Task<IEnumerable<dynamic>> usp_crud_ApplicantPetDetail(List<PetDetail> data, DataTable dt);
        //Task<IEnumerable<dynamic>> usp_crud_AssetDetal(DataTable dt);
        Task<IEnumerable<dynamic>> SourceofDrinkingWater(SourceOFDrinkingWater obj);
        Task<IEnumerable<dynamic>> CrudCaseSupport(int CaseDetailDetailId, int OperationId, DataTable dt, DateTime date, string UserIP, int UserId, int CaseId);
        Task<IEnumerable<dynamic>> usp_Get_FamilyEduDetail(int CaseId);
        Task<IEnumerable<dynamic>> usp_Get_FamilyMedDetail(int CaseId);
        Task<IEnumerable<dynamic>> usp_Get_ApplicantExpenseDet(int CaseId);
        Task<IEnumerable<dynamic>> usp_Get_GuardianDet(int CaseId);
        Task<IEnumerable<dynamic>> usp_GetCaseDetails(int CaseId);
        Task<IEnumerable<dynamic>> usp_GetApplicantPetDetails(int CaseId);
        Task<IEnumerable<dynamic>> usp_GetApplicantExpenseDetails(int CaseId);
        Task<IEnumerable<dynamic>> usp_GetApplicantAssetDetails(int CaseId);
        Task<IEnumerable<dynamic>> usp_ApplicantPrimaryInfo(DataTable dt, DataTable dt2, DataTable dt3, int operationid, int Userid, string UserIP, DateTime createdate, int ContactID);
        Task<IEnumerable<dynamic>> ForgetPassword(string username);
        Task<IEnumerable<dynamic>> usp_UserLogin_Operation(int OperationId, int? UserId, string Name, string EmailAddress, string Password, int RoleId, int? CreatedBy, string UserIP, bool IsActive, bool isfamilymember, bool isparentFamily, bool Is_Displayed_In_Menu);
        Task<IEnumerable<dynamic>> usp_crud_ApplicantMedicalDetail(DataTable dt, int OperationId, int ApplicantMedicalDetailId, int UserId, DateTime CreatedDate, string UserIP);
        DataSet usp_SupportingDocCrud(string DocAttach, int CaseId, int DocTypeId, int Userid, string UserIP, DateTime date);
        Task<IEnumerable<dynamic>> GetCaseSupportData(int Id);
        DataSet Crud_Followup(ApplicantContext.Followup obj);
        DataSet Crud_Followup_Edit(ApplicantContext.Followup obj);
        DataSet UploadSupportingDoc(int OperationId, Int32 DocId, int CaseId, int UserId, string UserIP, DataTable dt);
        DataSet ApplicantCase_StatusHistory(ApplicantContext.ApplicantCase_StatusHistory obj, DataTable DtSupportHistoryData);
        DataSet Assign_Investigator(ApplicantContext.Assign_Investigator obj);
        DataSet JobList(ApplicantContext.JobList objData);
        DataSet UpdatePaymentMethod(ApplicantContext.PaymentMethod obj);
        DataSet GetApplicantCaseHistory(ApplicantContext.GetApplicantCaseHistory obj);
        DataSet UpdateSupportDetail(ApplicantContext.SupportDetail obj);
        DataSet GetDashboardData(int? UserId);
        DataSet Get_PrimarySupportDetailShow(int? ID);
        DataSet Update_Refrel(ApplicantContext.ApplicantCaseRegistration objapplist);
    }
    public class ApplicantDataDapperRepository : IApplicantDataDapperRepository
    {
        dynamic objdynamic = null;
        private string connectionString = "";
        private readonly DapperManager dapperManager;
        public ApplicantDataDapperRepository()
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
        public DataSet usp_Get_ApplicantApplicationData(int CaseId, int Tab_INDEX)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@CaseId", SqlDbType.Int) {Value =CaseId},
                new SqlParameter("@Tab_INDEX", SqlDbType.Int) {Value =Tab_INDEX},

            };


            var spName = "usp_Get_ApplicantApplicationData";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public async Task<IEnumerable<dynamic>> usp_Get_Applicant_Basic_By_Id(int obj)
        {
            dynamic results = JsonConvert.DeserializeObject<dynamic>(Convert.ToString(obj));

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@ApplicantCaseId", Convert.ToInt32(obj));

            var spName = "usp_Get_Applicant_Basic_Information";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public async Task<IEnumerable<dynamic>> usp_Combo_Operation(ComboOperation obj)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@OperationId", obj.OperationId);
            queryParameters.Add("@Id", obj.id);
            queryParameters.Add("@ConstantId", obj.id);

            var spName = "usp_FillDropdown";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public async Task<IEnumerable<dynamic>> usp_Get_Applicant_Cases(dynamic data)
        {


            dynamic results = JsonConvert.DeserializeObject<dynamic>(Convert.ToString(data));


            var queryParameters = new DynamicParameters();
            queryParameters.Add("@ApplicantCode", results["ApplicantCode"].ToString());
            queryParameters.Add("@ApplicantCaseCode", results["ApplicantCaseCode"].ToString());
            queryParameters.Add("@CategoryId", results["CategoryId"] == null ? 0 : Convert.ToInt32(results["CategoryId"]));
            queryParameters.Add("@Cnic", results["Cnic"].ToString());
            queryParameters.Add("@GenderID", results["GenderID"] == null ? 0 : Convert.ToInt32(results["GenderID"]));
            queryParameters.Add("@FullName", results["FullName"].ToString());
            queryParameters.Add("@ProvinceId", results["ProvinceId"] == null ? 0 : Convert.ToInt32(results["ProvinceId"]));
            queryParameters.Add("@Village_CityId", results["Village_CityId"] == null ? 0 : Convert.ToInt32(results["Village_CityId"]));
            queryParameters.Add("@IsBlocked", results["IsBlocked"] == null ? 0 : Convert.ToInt32(results["IsBlocked"]));
            queryParameters.Add("@countryid", results["countryid"] == null ? 0 : Convert.ToInt32(results["countryid"]));
            queryParameters.Add("@referbyid", results["referbyid"] == null ? 0 : Convert.ToInt32(results["referbyid"]));
            queryParameters.Add("@referbyname", results["referbyname"].ToString());
            queryParameters.Add("@muhallahid", results["muhallahid"] == null ? 0 : Convert.ToInt32(results["muhallahid"]));
            queryParameters.Add("@unionid", results["unionid"] == null ? 0 : Convert.ToInt32(results["unionid"]));
            queryParameters.Add("@districtid", results["districtid"] == null ? 0 : Convert.ToInt32(results["districtid"]));
            queryParameters.Add("@refertypeconstant", results["refertypeconstant"].ToString());
            queryParameters.Add("@Isjoinfamily", results["Isjoinfamily"] == null ? 0 : Convert.ToInt32(results["Isjoinfamily"]));
            queryParameters.Add("@referrealationshipid", results["referrealationshipid"] == null ? 0 : Convert.ToInt32(results["referrealationshipid"]));
            queryParameters.Add("@IsShowcase", results["IsShowcase"] == null ? 0 : Convert.ToInt32(results["IsShowcase"]));
            queryParameters.Add("@ISCaseofaday", results["ISCaseofaday"] == null ? 0 : Convert.ToInt32(results["ISCaseofaday"]));
            queryParameters.Add("@isclosed", results["isclosed"] == null ? 0 : Convert.ToInt32(results["isclosed"]));
            queryParameters.Add("@isfreeze", results["isfreeze"] == null ? 0 : Convert.ToInt32(results["isfreeze"]));
            queryParameters.Add("@investigatorid", results["investigatorid"] == null ? 0 : Convert.ToInt32(results["investigatorid"]));
            queryParameters.Add("@tab", Convert.ToInt32(results["tab"]));
            queryParameters.Add("@isterminate", results["isterminate"] == null ? 0 : Convert.ToInt32(results["isterminate"]));



            var spName = "usp_GetApplicantList";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public async Task<IEnumerable<dynamic>> usp_Assign_Investigator_Applicant_Case(dynamic data)
        {

            dynamic results = JsonConvert.DeserializeObject<dynamic>(Convert.ToString(data));




            var queryParameters = new DynamicParameters();
            queryParameters.Add("@investigatorid", Convert.ToInt32(results["InvestigatorId"]));
            queryParameters.Add("@operationid", Convert.ToInt32(results["OperationId"]));
            queryParameters.Add("@ApplicantCaseId", Convert.ToInt32(results["ApplicantCaseId"]));
            queryParameters.Add("@ApplicantId", Convert.ToInt32(results["ApplicantId"]));
            queryParameters.Add("@IsChecked", Convert.ToBoolean(results["IsChecked"]));

            var spName = "usp_Update_Case_Applicant_bits_Invest_Assign";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public DataSet usp_RegisteredApplicantCase(ApplicantContext.ApplicantCaseRegistration objApplicant)
        {

            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = objApplicant.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@CnicNo", SqlDbType = SqlDbType.NVarChar, Value = objApplicant.CnicNo });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantId", SqlDbType = SqlDbType.Int, Value = objApplicant.ApplicantId });
            parm.Add(new SqlParameter() { ParameterName = "@FirstName", SqlDbType = SqlDbType.NVarChar, Value = objApplicant.FirstName });
            parm.Add(new SqlParameter() { ParameterName = "@LastName", SqlDbType = SqlDbType.NVarChar, Value = objApplicant.LastName });
            parm.Add(new SqlParameter() { ParameterName = "@DateOfBirth", SqlDbType = SqlDbType.DateTime, Value = objApplicant.DateOfBirth });
            parm.Add(new SqlParameter() { ParameterName = "@GenderId", SqlDbType = SqlDbType.Int, Value = objApplicant.GenderId });
            parm.Add(new SqlParameter() { ParameterName = "@FatherName", SqlDbType = SqlDbType.NVarChar, Value = objApplicant.FatherName });
            parm.Add(new SqlParameter() { ParameterName = "@PrimaryFundCategoryId", SqlDbType = SqlDbType.Int, Value = objApplicant.PrimaryFundCategoryId });
            parm.Add(new SqlParameter() { ParameterName = "@FundAmount_Required", SqlDbType = SqlDbType.Decimal, Value = objApplicant.FundAmount_Required });
            parm.Add(new SqlParameter() { ParameterName = "@CityId", SqlDbType = SqlDbType.Int, Value = objApplicant.CityId });
            parm.Add(new SqlParameter() { ParameterName = "@PermanentAddress", SqlDbType = SqlDbType.NVarChar, Value = objApplicant.PermanentAddress });
            parm.Add(new SqlParameter() { ParameterName = "@CaseNatureId", SqlDbType = SqlDbType.Int, Value = objApplicant.CaseNatureId });
            parm.Add(new SqlParameter() { ParameterName = "@NoOf_HouseHold_Member", SqlDbType = SqlDbType.Int, Value = objApplicant.NoOf_HouseHold_Member });
            parm.Add(new SqlParameter() { ParameterName = "@FamilyNo", SqlDbType = SqlDbType.NVarChar, Value = objApplicant.FamilyNo });
            parm.Add(new SqlParameter() { ParameterName = "@Referral_TypeId", SqlDbType = SqlDbType.Int, Value = objApplicant.Referral_TypeId });
            parm.Add(new SqlParameter() { ParameterName = "@Referral_CompanyId", SqlDbType = SqlDbType.Int, Value = objApplicant.Referral_CompanyId });
            parm.Add(new SqlParameter() { ParameterName = "@ReferralName", SqlDbType = SqlDbType.NVarChar, Value = objApplicant.ReferralName });
            parm.Add(new SqlParameter() { ParameterName = "@Referral_RelationId", SqlDbType = SqlDbType.Int, Value = objApplicant.Referral_RelationId });
            parm.Add(new SqlParameter() { ParameterName = "@CaseExpiry", SqlDbType = SqlDbType.DateTime, Value = objApplicant.CaseExpiry });
            parm.Add(new SqlParameter() { ParameterName = "@IsJoinFamily", SqlDbType = SqlDbType.Bit, Value = objApplicant.IsJoinFamily });
            parm.Add(new SqlParameter() { ParameterName = "@IsHOD_HR_Signature", SqlDbType = SqlDbType.Bit, Value = objApplicant.IsHOD_HR_Signature });
            parm.Add(new SqlParameter() { ParameterName = "@InvestigatorId", SqlDbType = SqlDbType.Int, Value = objApplicant.InvestigatorId });
            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = objApplicant.UserId });

            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = objApplicant.UserIP });
            parm.Add(new SqlParameter() { ParameterName = "@AreaId", SqlDbType = SqlDbType.NVarChar, Value = objApplicant.AreaId });

            parm.Add(new SqlParameter() { ParameterName = "@Remarks", SqlDbType = SqlDbType.NVarChar, Value = objApplicant.Remarks });

            var spName = "SP_CaseRegistration";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet usp_RegisteredApplicantCase(ApplicantContext.ApplicantCaseRegistration objApplicant, DataTable DtDocumentData)
        {

            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = objApplicant.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@CnicNo", SqlDbType = SqlDbType.NVarChar, Value = objApplicant.CnicNo });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantId", SqlDbType = SqlDbType.Int, Value = objApplicant.ApplicantId });
            parm.Add(new SqlParameter() { ParameterName = "@FirstName", SqlDbType = SqlDbType.NVarChar, Value = objApplicant.FirstName });
            parm.Add(new SqlParameter() { ParameterName = "@LastName", SqlDbType = SqlDbType.NVarChar, Value = objApplicant.LastName });
            parm.Add(new SqlParameter() { ParameterName = "@DateOfBirth", SqlDbType = SqlDbType.DateTime, Value = objApplicant.DateOfBirth });
            parm.Add(new SqlParameter() { ParameterName = "@GenderId", SqlDbType = SqlDbType.Int, Value = objApplicant.GenderId });
            parm.Add(new SqlParameter() { ParameterName = "@FatherName", SqlDbType = SqlDbType.NVarChar, Value = objApplicant.FatherName });
            parm.Add(new SqlParameter() { ParameterName = "@PrimaryContactNumber", SqlDbType = SqlDbType.NVarChar, Value = objApplicant.PrimaryContactNumber });
            parm.Add(new SqlParameter() { ParameterName = "@AlternateContactNumber", SqlDbType = SqlDbType.NVarChar, Value = objApplicant.AlternateContactNumber });
            parm.Add(new SqlParameter() { ParameterName = "@PrimaryFundCategoryId", SqlDbType = SqlDbType.Int, Value = objApplicant.PrimaryFundCategoryId });
            parm.Add(new SqlParameter() { ParameterName = "@FundAmount_Required", SqlDbType = SqlDbType.Decimal, Value = objApplicant.FundAmount_Required });
            parm.Add(new SqlParameter() { ParameterName = "@CityId", SqlDbType = SqlDbType.Int, Value = objApplicant.CityId });
            parm.Add(new SqlParameter() { ParameterName = "@PermanentAddress", SqlDbType = SqlDbType.NVarChar, Value = objApplicant.PermanentAddress });
            parm.Add(new SqlParameter() { ParameterName = "@CaseNatureId", SqlDbType = SqlDbType.Int, Value = objApplicant.CaseNatureId });
            parm.Add(new SqlParameter() { ParameterName = "@NoOf_HouseHold_Member", SqlDbType = SqlDbType.Int, Value = objApplicant.NoOf_HouseHold_Member });
            parm.Add(new SqlParameter() { ParameterName = "@FamilyNo", SqlDbType = SqlDbType.NVarChar, Value = objApplicant.FamilyNo });
            parm.Add(new SqlParameter() { ParameterName = "@Referral_TypeId", SqlDbType = SqlDbType.Int, Value = objApplicant.Referral_TypeId });
            parm.Add(new SqlParameter() { ParameterName = "@Referral_CompanyId", SqlDbType = SqlDbType.Int, Value = objApplicant.Referral_CompanyId });
            parm.Add(new SqlParameter() { ParameterName = "@ReferralName", SqlDbType = SqlDbType.NVarChar, Value = objApplicant.ReferralName });
            parm.Add(new SqlParameter() { ParameterName = "@ReferralContactNumber", SqlDbType = SqlDbType.NVarChar, Value = objApplicant.ReferralContactNumber });
            parm.Add(new SqlParameter() { ParameterName = "@Referral_RelationId", SqlDbType = SqlDbType.Int, Value = objApplicant.Referral_RelationId });
            parm.Add(new SqlParameter() { ParameterName = "@CaseExpiry", SqlDbType = SqlDbType.DateTime, Value = objApplicant.CaseExpiry });
            parm.Add(new SqlParameter() { ParameterName = "@IsJoinFamily", SqlDbType = SqlDbType.Bit, Value = objApplicant.IsJoinFamily });
            parm.Add(new SqlParameter() { ParameterName = "@IsHOD_HR_Signature", SqlDbType = SqlDbType.Bit, Value = objApplicant.IsHOD_HR_Signature });
            parm.Add(new SqlParameter() { ParameterName = "@InvestigatorId", SqlDbType = SqlDbType.Int, Value = objApplicant.InvestigatorId });
            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = objApplicant.UserId });

            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = objApplicant.UserIP });
            parm.Add(new SqlParameter() { ParameterName = "@Tbl_Type_ApplicantCase_SupportDocument", SqlDbType = SqlDbType.Structured, Value = DtDocumentData });

            parm.Add(new SqlParameter() { ParameterName = "@AreaId", SqlDbType = SqlDbType.NVarChar, Value = objApplicant.AreaId });

            parm.Add(new SqlParameter() { ParameterName = "@Remarks", SqlDbType = SqlDbType.NVarChar, Value = objApplicant.Remarks });

            var spName = "SP_CaseRegistration";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet usp_Crud_Personal_Info_Contact_Detail(ApplicantContext.ApplicantPersonalInfoContactDetail objData)
        {

            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = objData.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantCase_InvestigationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantContactDetailId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantContactDetailId });
            parm.Add(new SqlParameter() { ParameterName = "@PhoneTypeId", SqlDbType = SqlDbType.Int, Value = objData.PhoneTypeId });
            parm.Add(new SqlParameter() { ParameterName = "@PhoneNo", SqlDbType = SqlDbType.NVarChar, Value = objData.PhoneNo });

            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = objData.UserId });

            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = objData.UserIP });

            var spName = "SP_Tbl_ApplicantContactDetail";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet usp_Crud_Guardian_Detail(ApplicantContext.ApplicantGuardianDetail objData)
        {

            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = objData.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantCase_InvestigationId });


            parm.Add(new SqlParameter() { ParameterName = "@ApplicantGuardianDetailId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantGuardianDetailId });
            parm.Add(new SqlParameter() { ParameterName = "@GuardianName", SqlDbType = SqlDbType.NVarChar, Value = objData.GuardianName });
            parm.Add(new SqlParameter() { ParameterName = "@GuardianCnic", SqlDbType = SqlDbType.NVarChar, Value = objData.GuardianCnic });
            parm.Add(new SqlParameter() { ParameterName = "@GuardianContactNo", SqlDbType = SqlDbType.NVarChar, Value = objData.GuardianContactNo });
            parm.Add(new SqlParameter() { ParameterName = "@Occupation", SqlDbType = SqlDbType.NVarChar, Value = objData.Occupation });
            parm.Add(new SqlParameter() { ParameterName = "@Relation", SqlDbType = SqlDbType.NVarChar, Value = objData.Relation });
            parm.Add(new SqlParameter() { ParameterName = "@CompanyName", SqlDbType = SqlDbType.NVarChar, Value = objData.CompanyName });

            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = objData.UserId });

            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = objData.UserIP });

            var spName = "SP_Tbl_ApplicantGuardianDetail";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet usp_Crud_Monthly_Expense_Detail(ApplicantContext.ApplicantMonthlyExpenseDetail objData)
        {

            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = objData.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantCase_InvestigationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantMonthlyExpenseDetailId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantMonthlyExpenseDetailId });
            parm.Add(new SqlParameter() { ParameterName = "@ExpenseId", SqlDbType = SqlDbType.Int, Value = objData.ExpenseId });
            parm.Add(new SqlParameter() { ParameterName = "@Amount", SqlDbType = SqlDbType.Decimal, Value = objData.Amount });
            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = objData.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = objData.UserIP });

            var spName = "SP_Tbl_ApplicantMonthlyExpenseDetail";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet usp_Crud_Pet_Detail(ApplicantContext.ApplicantPetDetail objData)
        {

            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = objData.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantCase_InvestigationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantPetDetailId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantPetDetailId });
            parm.Add(new SqlParameter() { ParameterName = "@PetId", SqlDbType = SqlDbType.Int, Value = objData.PetId });
            parm.Add(new SqlParameter() { ParameterName = "@Quantity", SqlDbType = SqlDbType.Decimal, Value = objData.Quantity });
            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = objData.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = objData.UserIP });

            var spName = "SP_Tbl_ApplicantPetDetail";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet usp_Crud_Asset_Detail(ApplicantContext.ApplicantAssetDetail objData)
        {

            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = objData.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantCase_InvestigationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantAssetDetailId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantAssetDetailId });
            parm.Add(new SqlParameter() { ParameterName = "@AssetTypeId", SqlDbType = SqlDbType.Int, Value = objData.AssetTypeId });
            parm.Add(new SqlParameter() { ParameterName = "@MortgageLandLordName", SqlDbType = SqlDbType.NVarChar, Value = objData.MortgageLandLordName });
            parm.Add(new SqlParameter() { ParameterName = "@MortgageLandLordContactNo", SqlDbType = SqlDbType.NVarChar, Value = objData.MortgageLandLordContactNo });
            parm.Add(new SqlParameter() { ParameterName = "@MortgageLandLordAddress", SqlDbType = SqlDbType.NVarChar, Value = objData.MortgageLandLordAddress });
            parm.Add(new SqlParameter() { ParameterName = "@Remarks", SqlDbType = SqlDbType.NVarChar, Value = objData.Remarks });
            parm.Add(new SqlParameter() { ParameterName = "@AssetSubTypeId", SqlDbType = SqlDbType.Int, Value = objData.AssetSubTypeId });
            parm.Add(new SqlParameter() { ParameterName = "@AssetStatusId", SqlDbType = SqlDbType.Int, Value = objData.AssetStatusId });
            parm.Add(new SqlParameter() { ParameterName = "@Quantity", SqlDbType = SqlDbType.Int, Value = objData.Quantity });
            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = objData.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = objData.UserIP });

            var spName = "SP_Tbl_ApplicantAssetDetail";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet usp_Crud_Family_Detail(ApplicantContext.ApplicantFamilyDetail objData, DataTable dt)
        {
            //string dateofbirth = DateTimeConverter(objData.DateOfBirth);
            //string dateofDeath = DateTimeConverter(objData.DateOfDeath);

            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = objData.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantCase_InvestigationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantFamilyDetailId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantFamilyDetailId });
            parm.Add(new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = objData.Name });
            parm.Add(new SqlParameter() { ParameterName = "@Cnic", SqlDbType = SqlDbType.NVarChar, Value = objData.Cnic });
            parm.Add(new SqlParameter() { ParameterName = "@Mother_Father_HusbandName", SqlDbType = SqlDbType.NVarChar, Value = objData.Mother_Father_HusbandName });


            parm.Add(new SqlParameter() { ParameterName = "@DateOfBirth", SqlDbType = SqlDbType.Date, Value = objData.DateOfBirth });
            parm.Add(new SqlParameter() { ParameterName = "@DateOfDeath", SqlDbType = SqlDbType.Date, Value = objData.DateOfDeath });

            //try
            //{
            //    parm.Add(new SqlParameter() { ParameterName = "@DateOfBirth", SqlDbType = SqlDbType.Date, Value = Convert.ToDateTime(objData.DateOfBirth).ToString("yyyy-MM-dd") });
            //}
            //catch (Exception)
            //{
            //    parm.Add(new SqlParameter() { ParameterName = "@DateOfBirth", SqlDbType = SqlDbType.Date, Value = objData.DateOfBirth == "" || objData.DateOfBirth == "null" ? null : objData.DateOfBirth });
            //}
            //parm.Add(new SqlParameter() { ParameterName = "@IsDeceased", SqlDbType = SqlDbType.Bit, Value = objData.IsDeceased });
            //try
            //{
            //    parm.Add(new SqlParameter() { ParameterName = "@DateOfDeath", SqlDbType = SqlDbType.Date, Value = Convert.ToDateTime(objData.DateOfDeath).ToString("yyyy-MM-dd") });
            //}
            //catch (Exception)
            //{
            //    parm.Add(new SqlParameter() { ParameterName = "@DateOfDeath", SqlDbType = SqlDbType.Date, Value = (objData.DateOfDeath == "" || objData.DateOfDeath == "null" ? null : objData.DateOfDeath) });
            //}

            parm.Add(new SqlParameter() { ParameterName = "@RelationId", SqlDbType = SqlDbType.Int, Value = objData.RelationId });
            parm.Add(new SqlParameter() { ParameterName = "@ReligionId", SqlDbType = SqlDbType.Int, Value = objData.ReligionId });
            parm.Add(new SqlParameter() { ParameterName = "@GenderId", SqlDbType = SqlDbType.Int, Value = objData.GenderId });
            parm.Add(new SqlParameter() { ParameterName = "@ContactTypeId", SqlDbType = SqlDbType.Int, Value = objData.ContactTypeId });
            parm.Add(new SqlParameter() { ParameterName = "@MaritalStatusId", SqlDbType = SqlDbType.Int, Value = objData.MaritalStatusId });
            parm.Add(new SqlParameter() { ParameterName = "@IsPartOfBannedOrg", SqlDbType = SqlDbType.Bit, Value = objData.IsPartOfBannedOrg });
            parm.Add(new SqlParameter() { ParameterName = "@IsInvolveInCriminalActivity", SqlDbType = SqlDbType.Bit, Value = objData.IsInvolveInCriminalActivity });
            parm.Add(new SqlParameter() { ParameterName = "@HasMedicalHistory", SqlDbType = SqlDbType.Bit, Value = objData.HasMedicalHistory });
            parm.Add(new SqlParameter() { ParameterName = "@Remarks", SqlDbType = SqlDbType.NVarChar, Value = objData.Remarks });
            parm.Add(new SqlParameter() { ParameterName = "@ContactNumber", SqlDbType = SqlDbType.NVarChar, Value = objData.ContactNumber });
            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = objData.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = objData.UserIP });
            parm.Add(new SqlParameter() { ParameterName = "@CanRead", SqlDbType = SqlDbType.Bit, Value = objData.CanRead });
            parm.Add(new SqlParameter() { ParameterName = "@CanWrite", SqlDbType = SqlDbType.Bit, Value = objData.CanWrite });
            parm.Add(new SqlParameter() { ParameterName = "@IsEmployeed", SqlDbType = SqlDbType.Bit, Value = objData.IsEmployeed });
            parm.Add(new SqlParameter() { ParameterName = "@IsJobList", SqlDbType = SqlDbType.Bit, Value = objData.IsJobList });
            parm.Add(new SqlParameter() { ParameterName = "@JobRemarks", SqlDbType = SqlDbType.NVarChar, Value = objData.JobRemarks });
            parm.Add(new SqlParameter() { ParameterName = "@LastWorkExperience", SqlDbType = SqlDbType.NVarChar, Value = objData.LastWorkExperience });
            parm.Add(new SqlParameter() { ParameterName = "@Orphan", SqlDbType = SqlDbType.Bit, Value = objData.Orphan });
            parm.Add(new SqlParameter() { ParameterName = "@Tbl_Type_DocAttachment", SqlDbType = SqlDbType.Structured, Value = dt });

            var spName = "SP_Tbl_ApplicantFamilyDetail";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet usp_Crud_Family_Job_Experience_Detail(ApplicantContext.ApplicantFamilyJobExperienceDetail objData)
        {

            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = objData.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantCase_InvestigationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantFamily_JobExperienceDetailId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantFamily_JobExperienceDetailId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantFamilyDetailId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantFamilyDetailId });
            parm.Add(new SqlParameter() { ParameterName = "@JobStatusId", SqlDbType = SqlDbType.Int, Value = objData.JobStatusId });
            parm.Add(new SqlParameter() { ParameterName = "@EarningAmount", SqlDbType = SqlDbType.Decimal, Value = objData.EarningAmount });
            parm.Add(new SqlParameter() { ParameterName = "@LastCompanyName", SqlDbType = SqlDbType.NVarChar, Value = objData.LastCompanyName });

            parm.Add(new SqlParameter() { ParameterName = "@Remarks", SqlDbType = SqlDbType.NVarChar, Value = objData.Remarks });
            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = objData.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = objData.UserIP });

            var spName = "SP_Tbl_ApplicantFamily_JobExperienceDetail";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet usp_Crud_Family_Education_Detail(ApplicantContext.ApplicantFamilyEducationDetail objData)
        {

            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = objData.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantCase_InvestigationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantFamily_EducationDetailId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantFamily_EducationDetailId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantFamilyDetailId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantFamilyDetailId });
            parm.Add(new SqlParameter() { ParameterName = "@AcademicId", SqlDbType = SqlDbType.Int, Value = objData.AcademicId });
            parm.Add(new SqlParameter() { ParameterName = "@DegreeId", SqlDbType = SqlDbType.Int, Value = objData.DegreeId });
            parm.Add(new SqlParameter() { ParameterName = "@YearOfCompletion", SqlDbType = SqlDbType.Int, Value = objData.YearOfCompletion });
            parm.Add(new SqlParameter() { ParameterName = "@Class_SemesterId", SqlDbType = SqlDbType.Int, Value = objData.Class_SemesterId });
            parm.Add(new SqlParameter() { ParameterName = "@NameOfInstitute", SqlDbType = SqlDbType.VarChar, Value = objData.NameOfInstitute });
            parm.Add(new SqlParameter() { ParameterName = "@ProgramName", SqlDbType = SqlDbType.NVarChar, Value = objData.ProgramName });
            parm.Add(new SqlParameter() { ParameterName = "@Location", SqlDbType = SqlDbType.NVarChar, Value = objData.Location });
            parm.Add(new SqlParameter() { ParameterName = "@Educational_ContactNo", SqlDbType = SqlDbType.NVarChar, Value = objData.Educational_ContactNo });
            parm.Add(new SqlParameter() { ParameterName = "@Grade_Percentage_CGPA_Marks", SqlDbType = SqlDbType.NVarChar, Value = objData.Grade_Percentage_CGPA_Marks });
            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = objData.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = objData.UserIP });
            parm.Add(new SqlParameter() { ParameterName = "@Counselling", SqlDbType = SqlDbType.Bit, Value = objData.Counselling });

            var spName = "SP_Tbl_ApplicantFamily_EducationDetail";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet usp_Crud_EducationalCounselling(ApplicantContext.EducationalCounselling objData)
        {

            DataTable dtcounsellingform = new DataTable();
            dtcounsellingform.Columns.Add("Educational_Counselling_ID");
            dtcounsellingform.Columns.Add("ApplicantFamily_EducationDetailId");
            dtcounsellingform.Columns.Add("LastCounsellingSessionDate");
            dtcounsellingform.Columns.Add("NextCounsellingSessionDate");
            dtcounsellingform.Columns.Add("ApplicantCaseId");
            dtcounsellingform.Columns.Add("CreatedDate");
            dtcounsellingform.Columns.Add("Createdby");
            dtcounsellingform.Columns.Add("Remarks");
            dtcounsellingform.Columns.Add("SchoolStatus");
            dtcounsellingform.Columns.Add("SchoolStatusRemarks");
            dtcounsellingform.Columns.Add("CounsellingDate");
            dtcounsellingform.Columns.Add("CounsellorName");
            dtcounsellingform.Columns.Add("CounsellorContactNumber");
            dtcounsellingform.Columns.Add("OtherCounsellorsPresent");
            dtcounsellingform.Columns.Add("AttendantWithStudent");
            dtcounsellingform.Columns.Add("ExtraCurricularActivities");
            dtcounsellingform.Columns.Add("Job");
            dtcounsellingform.Columns.Add("JobRemarks");
            dtcounsellingform.Columns.Add("FamilyCounselling");
            dtcounsellingform.Columns.Add("StatedCareerGoals");
            dtcounsellingform.Columns.Add("OtherRemarks");
            dtcounsellingform.Columns.Add("AdditionalAssistance");
            dtcounsellingform.Columns.Add("AdditionalAssistanceRemarksbyCounsellor");
            dtcounsellingform.Columns.Add("AssignedMentor");
            dtcounsellingform.Columns.Add("MentorName");
            dtcounsellingform.Columns.Add("MentorContactNumber");
            dtcounsellingform.Columns.Add("MentorSpecialization");
            dtcounsellingform.Columns.Add("StudentFeedback");
            dtcounsellingform.Columns.Add("CaseHistory");
            dtcounsellingform.Columns.Add("FamilyHistory");
            dtcounsellingform.Columns.Add("FamilyCounseling");
            dtcounsellingform.Columns.Add("Declaration");
            dtcounsellingform.Columns.Add("CounsellorRemarks");
            dtcounsellingform.Columns.Add("PlansForImplementationOfSaidGoals");
            dtcounsellingform.Columns.Add("DoesTheStudentHaveACV");
            dtcounsellingform.Columns.Add("StudentRatingOfZamanFoundationServices");
            dtcounsellingform.Columns.Add("IsCompleted");

            dtcounsellingform.Rows.Add(
                  objData.Educational_Counselling_ID
                , objData.ApplicantFamily_EducationDetailId
                , objData.LastCounsellingSessionDate
                , objData.NextCounsellingSessionDate
                , objData.ApplicantCaseId
                , objData.CreatedDate
                , objData.Createdby
                , objData.Remarks
                , objData.SchoolStatus
                , objData.SchoolStatusRemarks
                , objData.CounsellingDate
                , objData.CounsellorName
                , objData.CounsellorContactNumber
                , objData.OtherCounsellorsPresent
                , objData.AttendantWithStudent
                , objData.ExtraCurricularActivities
                , objData.Job
                , objData.JobRemarks
                , objData.FamilyCounselling
                , objData.StatedCareerGoals
                , objData.OtherRemarks
                , objData.AdditionalAssistance
                , objData.AdditionalAssistanceRemarksbyCounsellor
                , objData.AssignedMentor
                , objData.MentorName
                , objData.MentorContactNumber
                , objData.MentorSpecialization
                , objData.StudentFeedback
                , objData.CaseHistory
                , objData.FamilyHistory
                , objData.FamilyCounseling
                , objData.Declaration
                , objData.CounsellorRemarks
                , objData.PlansForImplementationOfSaidGoals
                , objData.DoesTheStudentHaveACV
                , objData.StudentRatingOfZamanFoundationServices
                , objData.IsCompleted
                );

            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationID", SqlDbType = SqlDbType.Int, Value = objData.OperationID });
            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = objData.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = objData.UserIP });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantName", SqlDbType = SqlDbType.VarChar, Value = objData.ApplicantName });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCNIC", SqlDbType = SqlDbType.VarChar, Value = objData.ApplicantCNIC });
            parm.Add(new SqlParameter() { ParameterName = "@LastCounsellingSession", SqlDbType = SqlDbType.Date, Value = objData.LastCounsellingSession });
            parm.Add(new SqlParameter() { ParameterName = "@NextCounsellingSession", SqlDbType = SqlDbType.Date, Value = objData.NextCounsellingSession });
            parm.Add(new SqlParameter() { ParameterName = "@NextSessionDateAfter", SqlDbType = SqlDbType.Date, Value = objData.NextSessionDateAfter });
            parm.Add(new SqlParameter() { ParameterName = "@StudentName", SqlDbType = SqlDbType.VarChar, Value = objData.StudentName });
            parm.Add(new SqlParameter() { ParameterName = "@Tbl_type_Educational_Counselling", SqlDbType = SqlDbType.Structured, Value = dtcounsellingform });
            var spName = "SP_Educational_Counselling";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet usp_Crud_Medical_Card_Detail(ApplicantContext.ApplicantFamilyMedicalCardDetail objData)
        {

            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = objData.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantCase_InvestigationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantFamily_MedicalCardDetailId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantFamily_MedicalCardDetailId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantFamilyDetailId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantFamilyDetailId });
            parm.Add(new SqlParameter() { ParameterName = "@MedicalCardAmount", SqlDbType = SqlDbType.Decimal, Value = objData.MedicalCardAmount });
            parm.Add(new SqlParameter() { ParameterName = "@EligibleCardId", SqlDbType = SqlDbType.Int, Value = objData.EligibleCardId });

            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = objData.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = objData.UserIP });

            var spName = "SP_Tbl_ApplicantFamily_MedicalCardDetail";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet usp_Crud_Medical_Disability_Detail(ApplicantContext.ApplicantFamilyMedicalDisabilityDetail objData)
        {

            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = objData.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantCase_InvestigationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantFamily_MedicalDisablityDetailId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantFamily_MedicalDisablityDetailId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantFamilyDetailId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantFamilyDetailId });
            parm.Add(new SqlParameter() { ParameterName = "@DisabilityId", SqlDbType = SqlDbType.Int, Value = objData.DisabilityId });
            parm.Add(new SqlParameter() { ParameterName = "@HospitalName", SqlDbType = SqlDbType.NVarChar, Value = objData.HospitalName });
            parm.Add(new SqlParameter() { ParameterName = "@HospitalContactNo", SqlDbType = SqlDbType.NVarChar, Value = objData.HospitalContactNo });
            parm.Add(new SqlParameter() { ParameterName = "@HospitalAddress", SqlDbType = SqlDbType.NVarChar, Value = objData.HospitalAddress });
            parm.Add(new SqlParameter() { ParameterName = "@DoctorName", SqlDbType = SqlDbType.NVarChar, Value = objData.DoctorName });
            parm.Add(new SqlParameter() { ParameterName = "@DoctorContactNo", SqlDbType = SqlDbType.NVarChar, Value = objData.DoctorContactNo });

            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = objData.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = objData.UserIP });

            var spName = "SP_Tbl_ApplicantFamily_MedicalDisablityDetail";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet usp_Crud_Medical_Disease_Detail(ApplicantContext.ApplicantFamilyMedicalDiseaseDetail objData)
        {

            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = objData.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantCase_InvestigationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantFamily_MedicalDiseaseDetailId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantFamily_MedicalDiseaseDetailId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantFamilyDetailId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantFamilyDetailId });
            parm.Add(new SqlParameter() { ParameterName = "@DiseaseId", SqlDbType = SqlDbType.Int, Value = objData.DiseaseId });
            parm.Add(new SqlParameter() { ParameterName = "@HospitalName", SqlDbType = SqlDbType.NVarChar, Value = objData.HospitalName });
            parm.Add(new SqlParameter() { ParameterName = "@HospitalContactNo", SqlDbType = SqlDbType.NVarChar, Value = objData.HospitalContactNo });
            parm.Add(new SqlParameter() { ParameterName = "@HospitalAddress", SqlDbType = SqlDbType.NVarChar, Value = objData.HospitalAddress });
            parm.Add(new SqlParameter() { ParameterName = "@DoctorName", SqlDbType = SqlDbType.NVarChar, Value = objData.DoctorName });
            parm.Add(new SqlParameter() { ParameterName = "@DoctorContactNo", SqlDbType = SqlDbType.NVarChar, Value = objData.DoctorContactNo });

            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = objData.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = objData.UserIP });

            var spName = "SP_Tbl_ApplicantFamily_MedicalDiseaseDetail";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet usp_Crud_Applicant_SourceOfDrinking_Sanatation_And_Washroom(ApplicantContext.ApplicantCaseSourceOfDrinkingSanatationAndWashroom objData)
        {

            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = objData.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantCase_InvestigationId });
            parm.Add(new SqlParameter() { ParameterName = "@SourceOfDrinking_Ids", SqlDbType = SqlDbType.NVarChar, Value = objData.SourceOfDrinking_Ids });
            parm.Add(new SqlParameter() { ParameterName = "@SanitationAndWashroom_Ids", SqlDbType = SqlDbType.NVarChar, Value = objData.SanitationAndWashroom_Ids });
            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = objData.UserId });

            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = objData.UserIP });

            var spName = "SP_Tbl_ApplicantCase_SourceOfDrinking_SanitationAndWashroom";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet usp_Crud_Applicant_Loan_Detail(ApplicantContext.ApplicantLoanDetail objData)
        {

            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = objData.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantCase_InvestigationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantLoanDetailId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantLoanDetailId });
            parm.Add(new SqlParameter() { ParameterName = "@LoanTypeId", SqlDbType = SqlDbType.Int, Value = objData.LoanTypeId });
            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = objData.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@LoanAmount", SqlDbType = SqlDbType.Decimal, Value = objData.LoanAmount });
            parm.Add(new SqlParameter() { ParameterName = "@MonthlyAmount", SqlDbType = SqlDbType.Decimal, Value = objData.MonthlyAmount });
            parm.Add(new SqlParameter() { ParameterName = "@BalanceAmount", SqlDbType = SqlDbType.Decimal, Value = objData.BalanceAmount });
            parm.Add(new SqlParameter() { ParameterName = "@Remarks", SqlDbType = SqlDbType.NVarChar, Value = objData.Remarks });
            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = objData.UserIP });

            var spName = "SP_Tbl_ApplicantLoanDetail";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet usp_Applicant_Case_Re_Investigate(ApplicantContext.ApplicantCaseReInvestigate objData)
        {

            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantCase_InvestigationId });
            parm.Add(new SqlParameter() { ParameterName = "@InvestigatorId", SqlDbType = SqlDbType.Int, Value = objData.InvestigatorId });
            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = objData.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@ReinvestigationDate", SqlDbType = SqlDbType.NVarChar, Value = objData.ReinvestigationDate });
            parm.Add(new SqlParameter() { ParameterName = "@Remarks", SqlDbType = SqlDbType.NVarChar, Value = objData.Remarks });
            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = objData.UserIP });

            var spName = "SP_Re_Investigation";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet usp_Get_Applicant_List(ApplicantContext.ApplicantList objData)
        {

            List<SqlParameter> parm = new List<SqlParameter>();

            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = objData.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCode", SqlDbType = SqlDbType.NVarChar, Value = objData.ApplicantCode });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCaseCode", SqlDbType = SqlDbType.NVarChar, Value = objData.ApplicantCaseCode });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantName", SqlDbType = SqlDbType.NVarChar, Value = objData.ApplicantName });
            parm.Add(new SqlParameter() { ParameterName = "@Cnic", SqlDbType = SqlDbType.NVarChar, Value = objData.Cnic });
            parm.Add(new SqlParameter() { ParameterName = "@ReferralName", SqlDbType = SqlDbType.NVarChar, Value = objData.ReferralName });
            parm.Add(new SqlParameter() { ParameterName = "@GenderID", SqlDbType = SqlDbType.Int, Value = objData.GenderID });
            parm.Add(new SqlParameter() { ParameterName = "@CountryId", SqlDbType = SqlDbType.Int, Value = objData.CountryId });
            parm.Add(new SqlParameter() { ParameterName = "@ProvinceId", SqlDbType = SqlDbType.Int, Value = objData.ProvinceId });
            parm.Add(new SqlParameter() { ParameterName = "@CityId", SqlDbType = SqlDbType.Int, Value = objData.CityId });
            parm.Add(new SqlParameter() { ParameterName = "@FundCategoryId", SqlDbType = SqlDbType.Int, Value = objData.FundCategoryId });
            parm.Add(new SqlParameter() { ParameterName = "@CaseNatureId", SqlDbType = SqlDbType.Int, Value = objData.CaseNatureId });
            parm.Add(new SqlParameter() { ParameterName = "@CaseStatusId", SqlDbType = SqlDbType.Int, Value = objData.CaseStatusId });
            parm.Add(new SqlParameter() { ParameterName = "@Referral_TypeId", SqlDbType = SqlDbType.Int, Value = objData.Referral_TypeId });
            parm.Add(new SqlParameter() { ParameterName = "@Investigatorid", SqlDbType = SqlDbType.Int, Value = objData.Investigatorid });
            parm.Add(new SqlParameter() { ParameterName = "@TabName", SqlDbType = SqlDbType.NVarChar, Value = objData.TabName });
            parm.Add(new SqlParameter() { ParameterName = "@FromDate", SqlDbType = SqlDbType.Date, Value = objData.FromDate });
            parm.Add(new SqlParameter() { ParameterName = "@ToDate", SqlDbType = SqlDbType.Date, Value = objData.ToDate });


            if (objData.IsCaseStory == 2)
                parm.Add(new SqlParameter() { ParameterName = "@IsCaseStory", SqlDbType = SqlDbType.Int, Value = null });
            else
                parm.Add(new SqlParameter() { ParameterName = "@IsCaseStory", SqlDbType = SqlDbType.Int, Value = objData.IsCaseStory });
            if (objData.ViewFilterId == 2)
                parm.Add(new SqlParameter() { ParameterName = "@ViewFilterId", SqlDbType = SqlDbType.Int, Value = null });
            else
                parm.Add(new SqlParameter() { ParameterName = "@ViewFilterId", SqlDbType = SqlDbType.Int, Value = objData.ViewFilterId });


            var spName = "SP_GetAppicantList";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet Get_Physical_Audit_List(ApplicantContext.PhysicalAuditList objData)
        {

            List<SqlParameter> parm = new List<SqlParameter>();

            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = objData.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantCase_InvestigationId });
            parm.Add(new SqlParameter() { ParameterName = "@AuditStatus", SqlDbType = SqlDbType.Int, Value = objData.AuditStatus });
            parm.Add(new SqlParameter() { ParameterName = "@PhysicalAuditId", SqlDbType = SqlDbType.Int, Value = objData.PhysicalAuditId });
            parm.Add(new SqlParameter() { ParameterName = "@Auditor", SqlDbType = SqlDbType.NVarChar, Value = objData.Auditor });
            parm.Add(new SqlParameter() { ParameterName = "@AssignDate", SqlDbType = SqlDbType.Date, Value = objData.AssignDate });
            parm.Add(new SqlParameter() { ParameterName = "@StartDate", SqlDbType = SqlDbType.Date, Value = objData.StartDate });
            parm.Add(new SqlParameter() { ParameterName = "@CloseDate", SqlDbType = SqlDbType.Date, Value = objData.CloseDate });
            parm.Add(new SqlParameter() { ParameterName = "@CaseCode", SqlDbType = SqlDbType.NVarChar, Value = objData.CaseCode });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCnic", SqlDbType = SqlDbType.NVarChar, Value = objData.ApplicantCnic });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantName", SqlDbType = SqlDbType.NVarChar, Value = objData.ApplicantName });
            parm.Add(new SqlParameter() { ParameterName = "@AuditorRemarks", SqlDbType = SqlDbType.NVarChar, Value = objData.AuditorRemarks });
            parm.Add(new SqlParameter() { ParameterName = "@TrusteeRemarks", SqlDbType = SqlDbType.NVarChar, Value = objData.TrusteeRemarks });
            parm.Add(new SqlParameter() { ParameterName = "@RoleId", SqlDbType = SqlDbType.Int, Value = objData.RoleId });
            parm.Add(new SqlParameter() { ParameterName = "@UserID", SqlDbType = SqlDbType.Int, Value = objData.UserID });
            parm.Add(new SqlParameter() { ParameterName = "@AuditStatusEdit", SqlDbType = SqlDbType.Int, Value = objData.AuditStatusEdit });


            var spName = "SP_GetPhysicalAudit";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet usp_Crud_Applicant_Personal_Information_Detail(ApplicantContext.ApplicantPersonalInformation objData, DataTable DtPersonalInfoData)
        {
            string dateofbirth = DateTimeConverter(objData.DateOfBirth);


            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = objData.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantCase_InvestigationId });
            parm.Add(new SqlParameter() { ParameterName = "@CnicNo", SqlDbType = SqlDbType.NVarChar, Value = objData.CnicNo });
            parm.Add(new SqlParameter() { ParameterName = "@FirstName", SqlDbType = SqlDbType.NVarChar, Value = objData.FirstName });
            parm.Add(new SqlParameter() { ParameterName = "@LastName", SqlDbType = SqlDbType.NVarChar, Value = objData.LastName });
            parm.Add(new SqlParameter() { ParameterName = "@GenderId", SqlDbType = SqlDbType.Int, Value = objData.GenderId });
            parm.Add(new SqlParameter() { ParameterName = "@FatherName", SqlDbType = SqlDbType.NVarChar, Value = objData.FatherName });
            parm.Add(new SqlParameter() { ParameterName = "@DateOfBirth", SqlDbType = SqlDbType.NVarChar, Value = dateofbirth });
            parm.Add(new SqlParameter() { ParameterName = "@FamilyNumber", SqlDbType = SqlDbType.NVarChar, Value = objData.FamilyNumber });
            parm.Add(new SqlParameter() { ParameterName = "@ReligionId", SqlDbType = SqlDbType.Int, Value = objData.ReligionId });
            parm.Add(new SqlParameter() { ParameterName = "@NoOf_HouseHold_Member", SqlDbType = SqlDbType.Int, Value = objData.NoOf_HouseHold_Member });
            parm.Add(new SqlParameter() { ParameterName = "@NoOf_Family_Members_Accompanying", SqlDbType = SqlDbType.NVarChar, Value = objData.NoOf_Family_Members_Accompanying });
            parm.Add(new SqlParameter() { ParameterName = "@IsJoinFamily", SqlDbType = SqlDbType.Bit, Value = objData.IsJoinFamily });
            parm.Add(new SqlParameter() { ParameterName = "@CityId", SqlDbType = SqlDbType.Int, Value = objData.CityId });
            parm.Add(new SqlParameter() { ParameterName = "@TemperoryAddresss", SqlDbType = SqlDbType.NVarChar, Value = objData.TemperoryAddresss });
            parm.Add(new SqlParameter() { ParameterName = "@PermanentAddress", SqlDbType = SqlDbType.NVarChar, Value = objData.PermanentAddress });
            parm.Add(new SqlParameter() { ParameterName = "@AcceptanceOfCharity_Ids", SqlDbType = SqlDbType.NVarChar, Value = objData.AcceptanceOfCharity_Ids });
            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = objData.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = objData.UserIP });
            parm.Add(new SqlParameter() { ParameterName = "@Tbl_ApplicantPersonal_AdditionalOtherDetails", SqlDbType = SqlDbType.Structured, Value = DtPersonalInfoData });

            parm.Add(new SqlParameter() { ParameterName = "@AreaId", SqlDbType = SqlDbType.Int, Value = objData.AreaId });

            parm.Add(new SqlParameter() { ParameterName = "@MartialStatus", SqlDbType = SqlDbType.Int, Value = objData.MartialStatusId });





            var spName = "SP_Tbl_ApplicantCase_PerosnalInformation";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet usp_Crud_Applicant_Asset_Detail_Home_Allaince(ApplicantContext.ApplicantAssetDetailHomeApplainces objData, DataTable DtHomeApplainceData)
        {

            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@operationid", SqlDbType = SqlDbType.Int, Value = objData.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantCase_InvestigationId });
            parm.Add(new SqlParameter() { ParameterName = "@userip", SqlDbType = SqlDbType.NVarChar, Value = objData.UserIP });
            parm.Add(new SqlParameter() { ParameterName = "@userid", SqlDbType = SqlDbType.Int, Value = objData.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@Tbl_ApplicantAssetDetail_HomeAppliances", SqlDbType = SqlDbType.Structured, Value = DtHomeApplainceData });



            var spName = "SP_Tbl_ApplicantAssetDetail_HomeAppliances";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet usp_Crud_Applicant_Support_Detail(ApplicantContext.ApplicantSupport objData, DataTable DtSupportDetail)
        {

            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@operationid", SqlDbType = SqlDbType.NVarChar, Value = objData.operationid });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.NVarChar, Value = objData.ApplicantCase_InvestigationId });
            parm.Add(new SqlParameter() { ParameterName = "@userip", SqlDbType = SqlDbType.NVarChar, Value = objData.userip });
            parm.Add(new SqlParameter() { ParameterName = "@userid", SqlDbType = SqlDbType.Int, Value = objData.userid });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCaseSupport", SqlDbType = SqlDbType.Structured, Value = DtSupportDetail });
            var spName = "SP_Tbl_ApplicantCaseSupport";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public async Task<IEnumerable<dynamic>> usp_GetReferrerDataAccordingToReferrerType(int referrerType)
        {



            var queryParameters = new DynamicParameters();
            queryParameters.Add("@ReferrerType", referrerType);


            var spName = "usp_GetReferrerDataAccordingToReferrerType";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public DataSet Applicant_MarketingCase(MarketingCase obj, DataTable dt)
        {
            List<SqlParameter> parm = new List<SqlParameter>();
            //    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = "2" });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = obj.caseid });
            parm.Add(new SqlParameter() { ParameterName = "@casetittle", SqlDbType = SqlDbType.NVarChar, Value = obj.CaseTitle });
            parm.Add(new SqlParameter() { ParameterName = "@caseDesc", SqlDbType = SqlDbType.NVarChar, Value = obj.caseDesc });
            parm.Add(new SqlParameter() { ParameterName = "@caseoftheday", SqlDbType = SqlDbType.NVarChar, Value = obj.caseoftheday });
            parm.Add(new SqlParameter() { ParameterName = "@caseisshow", SqlDbType = SqlDbType.NVarChar, Value = obj.Caseshow });
            parm.Add(new SqlParameter() { ParameterName = "@Userip", SqlDbType = SqlDbType.NVarChar, Value = obj.Userip });
            parm.Add(new SqlParameter() { ParameterName = "@CreatedBy", SqlDbType = SqlDbType.NVarChar, Value = obj.CreatedBy });
            parm.Add(new SqlParameter() { ParameterName = "@ShortDesc", SqlDbType = SqlDbType.NVarChar, Value = obj.ShortDesc });
            parm.Add(new SqlParameter() { ParameterName = "@Adopt", SqlDbType = SqlDbType.Bit, Value = obj.Adopt });
            parm.Add(new SqlParameter() { ParameterName = "@Source", SqlDbType = SqlDbType.Int, Value = obj.Source });
            parm.Add(new SqlParameter() { ParameterName = "@CauseLabel", SqlDbType = SqlDbType.NVarChar, Value = obj.CauseLabel });
            parm.Add(new SqlParameter() { ParameterName = "@Tbl_Type_DocAttachment", SqlDbType = SqlDbType.Structured, Value = dt });
            var spName = "SP_MarketingCase_Update";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet GetData_MarketingCase(MarketingCase obj)
        {
            List<SqlParameter> queryParameters = new List<SqlParameter>();
            queryParameters.Add(new SqlParameter() { ParameterName = "@caseid", SqlDbType = SqlDbType.Int, Value = obj.caseid });
            var spName = "SP_GetCaseForMarketing";
            return dapperManager.GetDataSet(spName, queryParameters.ToArray());
        }
        public async Task<IEnumerable<dynamic>> usp_GetFamilyDetail(int CaseId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CaseId", CaseId);

            var spName = "usp_GetFamilyDetail";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public async Task<IEnumerable<dynamic>> CrudCaseSupport(int CaseDetailDetailId, int OperationId, DataTable dt, DateTime date, string UserIP, int UserId, int CaseId)
        {
            try
            {
                dt.TableName = "casedetaill";

                var queryParameters = new DynamicParameters();
                queryParameters.Add("@CaseDetailDetailId", CaseDetailDetailId);
                queryParameters.Add("@OperationId", OperationId);
                queryParameters.Add("@casedetail", dt.AsTableValuedParameter("[CaseDetaill]"));
                queryParameters.Add("@createddate", date);
                queryParameters.Add("@userip", UserIP);
                queryParameters.Add("@userid", UserId);
                queryParameters.Add("@CaseId", CaseId);

                var spName = "usp_crud_casesupport";
                return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
            }
            catch (Exception ex)
            {
                return (dynamic)ex.Message;
            }
        }
        //public async Task<IEnumerable<dynamic>> usp_crud_FamilyDetail(dynamic data)
        //{
        //    var queryParameters = new DynamicParameters();
        //    queryParameters.Add("@CaseId", data);
        //    var spName = "usp_GetFamilyDetail";
        //    return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        //}
        public async Task<IEnumerable<dynamic>> usp_crud_ApplicantPetDetail(List<PetDetail> obj, DataTable dt)
        {

            //DataTable dt = new DataTable();
            //  DataTable dt = SabSath.Application.Helper.CommonMethodHelper.ToDataTable(obj);
            //dt = ToDataTable(obj);

            var queryParameters = new DynamicParameters();
            dt.Columns.Remove("operationid");
            queryParameters.Add("@ApplicantPetDetail", dt.AsTableValuedParameter("[ApplicantPetDetaill]"));
            queryParameters.Add("@Operationid", obj[0].OperationID);
            queryParameters.Add("@ID", obj[0].ID);
            var spName = "usp_crud_ApplicantPetDetail";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        //public async Task<IEnumerable<dynamic>> usp_crud_AssetDetal(DataTable dt)
        //{
        //    dt.Columns.Remove("operationid");
        //    dt.Columns.Remove("Data2");
        //    var queryParameters = new DynamicParameters();
        //    queryParameters.Add("@Operationid", dt.Rows[0][0].ToString());
        //    queryParameters.Add("@ID", dt.Rows[0][0].ToString());
        //    queryParameters.Add("@ASSETDETAILS", dt.AsTableValuedParameter("[ASSETDETAILS]"));
        //    queryParameters.Add("@HomeAppliances", dt.AsTableValuedParameter("[HomeAppliances]"));
        //    var spName = "usp_Crud_AssetDetails";
        //    return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);

        //}
        public async Task<IEnumerable<dynamic>> SourceofDrinkingWater(SourceOFDrinkingWater obj)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@SourceOfDrinkingWater", obj.SourceOfDrinkingWater);
            queryParameters.Add("@HasWashroom", obj.HasWashroom);
            queryParameters.Add("@userip", obj.userip);
            queryParameters.Add("@createdate", obj.createdate);
            queryParameters.Add("@userid", obj.userid);
            queryParameters.Add("@applicantid", obj.applicantid);
            var spName = "usp_SanitaryDetail";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        //public async Task<IEnumerable<dynamic>> usp_crud_GuardianDetail(DataTable dt, int Operationid, int ID, string Date, int UserId, string UserIP)
        //{
        //    var queryParameters = new DynamicParameters();
        //    queryParameters.Add("@FamilyDetail", dt.AsTableValuedParameter("[ApplicantGuardianDetail]"));
        //    queryParameters.Add("@Operationid", Operationid);
        //    queryParameters.Add("@ID", ID);
        //    queryParameters.Add("@Date", Convert.ToDateTime(Date));
        //    queryParameters.Add("@UserId", UserId);
        //    queryParameters.Add("@UserIP", UserIP);
        //    var spName = "usp_crud_GuardianDetail";
        //    return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        //}

        //public async Task<IEnumerable<dynamic>> usp_crud_ExpenseDetail(DataTable dt, int Operationid, int ID, string Date, int UserId, string UserIP)
        //{
        //    var queryParameters = new DynamicParameters();
        //    queryParameters.Add("@ExpenseDetail", dt.AsTableValuedParameter("[ApplicantExpenseDetail]"));
        //    queryParameters.Add("@Operationid", Operationid);
        //    queryParameters.Add("@ID", ID);
        //    queryParameters.Add("@Date", Convert.ToDateTime(Date));
        //    queryParameters.Add("@UserId", UserId);
        //    queryParameters.Add("@UserIP", UserIP);
        //    var spName = "usp_crud_ExpenseDetail";
        //    return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        //}
        public async Task<IEnumerable<dynamic>> usp_crud_ApplicantFamilyInformationDetail(DataTable dt, int Operationid, int ID, string Date, int UserId, string UserIP)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@ApplicantFamilyInformationDetail", dt.AsTableValuedParameter("[ApplicantFamilyInformationDetail]"));
            queryParameters.Add("@Operationid", Operationid);
            queryParameters.Add("@ID", ID);
            queryParameters.Add("@Date", Convert.ToDateTime(Date));
            queryParameters.Add("@UserId", UserId);
            queryParameters.Add("@UserIP", UserIP);
            var spName = "usp_crud_ApplicantFamilyInformationDetail";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public async Task<IEnumerable<dynamic>> usp_Get_FamilyEduDetail(int CaseId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CaseId", CaseId);
            var spName = "usp_Get_FamilyEduDetail";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public async Task<IEnumerable<dynamic>> usp_Get_FamilyMedDetail(int CaseId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CaseId", CaseId);
            var spName = "usp_Get_FamilyMedDetail";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public async Task<IEnumerable<dynamic>> usp_Get_ApplicantExpenseDet(int CaseId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CaseId", CaseId);
            var spName = "usp_Get_ApplicantExpenseDet";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public async Task<IEnumerable<dynamic>> usp_Get_GuardianDet(int CaseId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CaseId", CaseId);
            var spName = "usp_Get_GuardianDet";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public async Task<IEnumerable<dynamic>> usp_GetCaseDetails(int CaseId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CaseId", CaseId);
            var spName = "usp_GetCaseDetails";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public async Task<IEnumerable<dynamic>> usp_GetApplicantPetDetails(int CaseId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CaseId", CaseId);
            var spName = "usp_GetApplicantPetDetails";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public async Task<IEnumerable<dynamic>> usp_GetApplicantExpenseDetails(int CaseId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CaseId", CaseId);
            var spName = "usp_GetApplicantExpenseDetails";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public async Task<IEnumerable<dynamic>> usp_GetApplicantAssetDetails(int CaseId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CaseId", CaseId);
            var spName = "usp_GetApplicantAssetDetails";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public async Task<IEnumerable<dynamic>> usp_ApplicantPrimaryInfo(DataTable dt, DataTable dt2, DataTable dt3, int operationid, int Userid, string UserIP, DateTime createdate, int ContactID)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@ApplicantPrimaryInformation", dt.AsTableValuedParameter("[ApplicantPrimaryInformation]"));
            queryParameters.Add("@ApplicantContactDetaill", dt2.AsTableValuedParameter("[ApplicantContactDetaill]"));
            queryParameters.Add("@ApplicantFundDetaill", dt3.AsTableValuedParameter("[ApplicantFundDetaill]"));
            queryParameters.Add("@operationid", operationid);
            queryParameters.Add("@Userid", Userid);
            queryParameters.Add("@userip", UserIP);
            queryParameters.Add("@createdate", createdate);
            queryParameters.Add("@ContactID", ContactID);
            var spName = "usp_ApplicantPrimaryInfo";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public async Task<IEnumerable<dynamic>> ForgetPassword(string username)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@username", username);
            var spName = "ForgetPassword";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public async Task<IEnumerable<dynamic>> usp_UserLogin_Operation(int OperationId, int? UserId, string Name, string EmailAddress, string Password, int RoleId, int? CreatedBy, string UserIP, bool IsActive, bool isfamilymember, bool isparentFamily, bool Is_Displayed_In_Menu)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@OperationId", OperationId);
            queryParameters.Add("@UserId", UserId);
            queryParameters.Add("@Name", Name);
            queryParameters.Add("@EmailAddress", EmailAddress);
            queryParameters.Add("@Password", Password);
            queryParameters.Add("@RoleId", RoleId);
            queryParameters.Add("@CreatedBy", CreatedBy);
            queryParameters.Add("@UserIP", UserIP);
            queryParameters.Add("@IsActive", IsActive);
            queryParameters.Add("@isfamilymember", isfamilymember);
            queryParameters.Add("@isparentFamily", isparentFamily);
            queryParameters.Add("@Is_Displayed_In_Menu", Is_Displayed_In_Menu);
            var spName = "usp_UserLogin_Operation";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public DataSet usp_SupportingDocCrud(string DocAttach, int CaseId, int DocTypeId, int Userid, string UserIP, DateTime date)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@DocAttachment", SqlDbType.NVarChar) {Value =DocAttach},
                new SqlParameter("@CaseId", SqlDbType.Int) {Value =CaseId},
                new SqlParameter("@DocTypeID", SqlDbType.Int) {Value =DocTypeId},
                new SqlParameter("@UserId", SqlDbType.Int) {Value =Userid},
                new SqlParameter("@UserIP", SqlDbType.NVarChar) {Value =UserIP},
                new SqlParameter("@Date", SqlDbType.DateTime) {Value =date},
            };

            var spName = "usp_SupportingDocCrud";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public async Task<IEnumerable<dynamic>> usp_crud_ApplicantMedicalDetail(DataTable dt, int OperationId, int ApplicantMedicalDetailId, int UserId, DateTime CreatedDate, string UserIP)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@ApplicantMedicalDetail", dt.AsTableValuedParameter("[ApplicantMedicalDetail]"));
            queryParameters.Add("@operationid", OperationId);
            queryParameters.Add("@ApplicantMedicalDetailId", ApplicantMedicalDetailId);
            queryParameters.Add("@UserId", UserId);
            queryParameters.Add("@CreatedDate", CreatedDate);
            queryParameters.Add("@UserIP", UserIP);
            var spName = "usp_crud_ApplicantMedicalDetail";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public async Task<IEnumerable<dynamic>> GetCaseSupportData(int Id)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@ID", Id);
            var spName = "SP_GetCaseSupportApproval";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public DataSet Crud_Followup(ApplicantContext.Followup obj)
        {
            //string FollowUpDate = DateTimeConverter(obj.FollowUpDate.ToString());
            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = obj.ApplicantCase_InvestigationId });
            parm.Add(new SqlParameter() { ParameterName = "@FollowUpId", SqlDbType = SqlDbType.Int, Value = obj.FollowUpId });
            parm.Add(new SqlParameter() { ParameterName = "@FollowupDate", SqlDbType = SqlDbType.Date, Value = obj.FollowUpDate });
            parm.Add(new SqlParameter() { ParameterName = "@InvestigatorId", SqlDbType = SqlDbType.Int, Value = obj.InvestigatorId });
            parm.Add(new SqlParameter() { ParameterName = "@Remarks", SqlDbType = SqlDbType.NVarChar, Value = obj.Remarks });
            parm.Add(new SqlParameter() { ParameterName = "@FollowupSubmittionRemarks", SqlDbType = SqlDbType.NVarChar, Value = obj.FollowupSubmittionRemarks });
            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
            var spName = "SP_Tbl_FollowUp";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet UploadSupportingDoc(int OperationId, Int32 DocId, int CaseId, int UserId, string UserIP, DataTable dt)
        {
            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = CaseId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_SupportDocId", SqlDbType = SqlDbType.Int, Value = DocId });
            parm.Add(new SqlParameter() { ParameterName = "@userid", SqlDbType = SqlDbType.Int, Value = UserId });
            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = UserIP });
            parm.Add(new SqlParameter() { ParameterName = "@Tbl_Type_ApplicantCase_SupportDocument", SqlDbType = SqlDbType.Structured, Value = dt });
            var spName = "SP_Tbl_ApplicantCase_SupportDocument";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet ApplicantCase_StatusHistory(ApplicantContext.ApplicantCase_StatusHistory objData, DataTable DtSupportHistoryData)
        {
            DateTime? DateNull = null;
            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = objData.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantCase_InvestigationId });
            parm.Add(new SqlParameter() { ParameterName = "@CaseStatusId", SqlDbType = SqlDbType.Int, Value = objData.CaseStatusId });
            parm.Add(new SqlParameter() { ParameterName = "@Remarks", SqlDbType = SqlDbType.NVarChar, Value = objData.Remarks });
            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = objData.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = objData.UserIP });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCaseSupportHistory", SqlDbType = SqlDbType.Structured, Value = DtSupportHistoryData });
            parm.Add(new SqlParameter() { ParameterName = "@IsBlackList", SqlDbType = SqlDbType.Bit, Value = objData.IsBlackList });
            parm.Add(new SqlParameter() { ParameterName = "@CaseStartDate", SqlDbType = SqlDbType.Date, Value = objData.CaseStartDate == "" ? DateNull : Convert.ToDateTime(objData.CaseStartDate) });
            parm.Add(new SqlParameter() { ParameterName = "@IsProbation", SqlDbType = SqlDbType.Bit, Value = objData.IsProbation });
            parm.Add(new SqlParameter() { ParameterName = "@IsPhyscialAudit", SqlDbType = SqlDbType.Bit, Value = objData.PhysicalAudit });
            parm.Add(new SqlParameter() { ParameterName = "@Physical_Audit_Assign", SqlDbType = SqlDbType.Int, Value = objData.Physical_Audit_Assign });
            var spName = "SP_Tbl_ApplicantCase_StatusHistory";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet Assign_Investigator(ApplicantContext.Assign_Investigator obj)
        {
            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = obj.ApplicantCase_InvestigationId });
            parm.Add(new SqlParameter() { ParameterName = "@InvestigatorId", SqlDbType = SqlDbType.Int, Value = obj.InvestigatorId });
            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
            var spName = "SP_Assign_Investigator";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet JobList(ApplicantContext.JobList objData)
        {
            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = objData.Name });
            parm.Add(new SqlParameter() { ParameterName = "@Qualification", SqlDbType = SqlDbType.Int, Value = objData.Qualification });
            parm.Add(new SqlParameter() { ParameterName = "@FieldofWork", SqlDbType = SqlDbType.NVarChar, Value = objData.LastExperience });
            parm.Add(new SqlParameter() { ParameterName = "@ContactNumber", SqlDbType = SqlDbType.NVarChar, Value = objData.ContactNumber });
            var spName = "SP_GetJobListDetails";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet UpdatePaymentMethod(ApplicantContext.PaymentMethod obj)
        {
            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = obj.ApplicantCase_InvestigationId });
            parm.Add(new SqlParameter() { ParameterName = "@PaymentTypeId", SqlDbType = SqlDbType.Int, Value = obj.PaymentTypeId });
            parm.Add(new SqlParameter() { ParameterName = "@BankName", SqlDbType = SqlDbType.NVarChar, Value = obj.BankName });
            parm.Add(new SqlParameter() { ParameterName = "@AccountTitle", SqlDbType = SqlDbType.NVarChar, Value = obj.AccountTitle });
            parm.Add(new SqlParameter() { ParameterName = "@AccountNo", SqlDbType = SqlDbType.NVarChar, Value = obj.AccountNo });
            parm.Add(new SqlParameter() { ParameterName = "@PaymentCNICNo", SqlDbType = SqlDbType.NVarChar, Value = obj.PaymentCnicNo });
            parm.Add(new SqlParameter() { ParameterName = "@PaymentGatewayId", SqlDbType = SqlDbType.Int, Value = obj.PaymentGatewayId });
            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });

            var spName = "SP_UpdatePaymentMethod";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet GetApplicantCaseHistory(ApplicantContext.GetApplicantCaseHistory obj)
        {
            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = obj.ApplicantCase_InvestigationId });
            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });

            var spName = "SP_GetApplicantCaseHistory";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet UpdateSupportDetail(ApplicantContext.SupportDetail obj)
        {
            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = obj.ApplicantCase_InvestigationId });
            parm.Add(new SqlParameter() { ParameterName = "@SupportId", SqlDbType = SqlDbType.Int, Value = obj.SupportId });
            parm.Add(new SqlParameter() { ParameterName = "@FundAmount_Required", SqlDbType = SqlDbType.Decimal, Value = obj.FundRequired });

            var spName = "SP_UpdatePrimarySupport";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet GetDashboardData(int? UserId)
        {
            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = UserId });

            var spName = "GetDashboardData";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet Get_PrimarySupportDetailShow(int? ID)
        {
            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@ID", SqlDbType = SqlDbType.Int, Value = ID });
            var spName = "sp_GetPrimarySupportDetailShow";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public string DateTimeConverter(string objDate)
        {
            CultureInfo culture = new CultureInfo("es-ES");
            string dateofbirth;
            if (objDate != null && objDate != "")
            {
                String myDate = objDate;
                DateTime dateofbirthDT = DateTime.Parse(myDate, culture);
                dateofbirth = dateofbirthDT.ToString();
            }
            else
            {
                dateofbirth = objDate;
            }
            return dateofbirth;
        }
        public DataSet Update_Refrel(ApplicantContext.ApplicantCaseRegistration objapplist)
        {



            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@refrelTypeid", SqlDbType = SqlDbType.Int, Value = objapplist.Referral_TypeId == 0 ? null : objapplist.Referral_TypeId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCompid", SqlDbType = SqlDbType.Int, Value = objapplist.Referral_CompanyId == 0 ? null : objapplist.Referral_CompanyId });
            parm.Add(new SqlParameter() { ParameterName = "@RefrelName", SqlDbType = SqlDbType.VarChar, Value = objapplist.ReferralName });
            parm.Add(new SqlParameter() { ParameterName = "@Relationid", SqlDbType = SqlDbType.Int, Value = objapplist.Referral_RelationId == 0 ? null : objapplist.Referral_RelationId });
            parm.Add(new SqlParameter() { ParameterName = "@ContactNo", SqlDbType = SqlDbType.VarChar, Value = objapplist.ReferralContactNumber });
            parm.Add(new SqlParameter() { ParameterName = "@Hodsig", SqlDbType = SqlDbType.Bit, Value = objapplist.IsHOD_HR_Signature });
            parm.Add(new SqlParameter() { ParameterName = "@CaseInvestigationid", SqlDbType = SqlDbType.Int, Value = objapplist.InvestigatorId });
            parm.Add(new SqlParameter() { ParameterName = "@Userid", SqlDbType = SqlDbType.Int, Value = objapplist.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@Userip", SqlDbType = SqlDbType.VarChar, Value = objapplist.UserIP });

            parm.Add(new SqlParameter() { ParameterName = "@Remarks", SqlDbType = SqlDbType.VarChar, Value = objapplist.Remarks });


            var spName = "sp_update_Referel";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet Crud_Followup_Edit(ApplicantContext.Followup obj)
        {
            //string FollowUpDate = DateTimeConverter(obj.FollowUpDate.ToString());
            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@FollowUpId", SqlDbType = SqlDbType.Int, Value = obj.FollowUpId });
            parm.Add(new SqlParameter() { ParameterName = "@SubmitRemarks", SqlDbType = SqlDbType.VarChar, Value = obj.FollowupSubmittionRemarks });
            parm.Add(new SqlParameter() { ParameterName = "@usserid", SqlDbType = SqlDbType.Int, Value = obj.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@UserIp", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
            var spName = "sp_FollowUp_Edit";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
    }
}
