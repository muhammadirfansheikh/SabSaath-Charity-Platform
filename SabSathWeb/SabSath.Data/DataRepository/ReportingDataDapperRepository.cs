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
    public interface IReportingDataDapperRepository
    {


        DataSet Get_Report_Job_List(ReportingContext.Report_Job_List ObjReportJobList);
        DataSet Get_Report_Applicant_Case_List(ReportingContext.Report_Applicant_Case_List objApplicantCaseList);
        DataSet Get_Report_Payment_List(ReportingContext.Report_Payment_List ObjPaymentList);
        DataSet Get_Report_Donation_List(ReportingContext.Report_Donation_List ObjPaymentList);
        DataSet Report_Case_Donation_Details(ReportingContext.Report_Case_Donation_Details ObjPaymentList);
        DataSet Get_Report_Donor_List(ReportingContext.Report_Donord_List ObjDonorList);
        DataSet Get_Report_Referral_List(ReportingContext.Report_Referral_List ObjReferralList);
        DataSet Get_Report_Company_List(ReportingContext.Report_Company_List ObjCompanyList);
        DataSet Get_Report_Institute_Wise_List(ReportingContext.Report_Institute_Wise_List ObjCompanyList);
        DataSet Get_Report_Patient_List(ReportingContext.Report_Patient_List OnjPatientList);
        DataSet Report_Payment_Reverse_Disburs(ReportingContext.Report_Payment_Reverse_Disburs OnjPatientList);
        DataSet Report_DonationHistory(ReportingContext.Report_DonationHistory OnjPatientList);
        DataSet Report_SubscriptionDetail(ReportingContext.Report_Subscription OnjPatientList);
        DataSet Report_Task_Sechduler(ReportingContext.Report_Task_Sechduler OnjPatientList);
        DataSet Report_Subscription_List_Detail(ReportingContext.Report_Subscription_List_Detail OnjPatientList);
        DataSet Report_Subscription_List(ReportingContext.Report_Subscription_List OnjPatientList);
        DataSet Report_SubscriptionCancel(ReportingContext.Report_SubscriptionCancel OnjPatientList);
    }
    public class ReportingDataDapperRepository : IReportingDataDapperRepository
    {
        dynamic objdynamic = null;
        private string connectionString = "";
        private readonly DapperManager dapperManager;
        public ReportingDataDapperRepository()
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
        public DataSet Get_Report_Job_List(ReportingContext.Report_Job_List ObjReportJobList)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@Name", SqlDbType.NVarChar) {Value =ObjReportJobList.Name},
                new SqlParameter("@QualificationId", SqlDbType.Int) {Value =ObjReportJobList.Qualification},
                new SqlParameter("@ContactNo", SqlDbType.NVarChar) {Value =ObjReportJobList.Contact_No},
                new SqlParameter("@Address", SqlDbType.NVarChar) {Value =ObjReportJobList.Address},
                new SqlParameter("@Employed", SqlDbType.Int) {Value =ObjReportJobList.Employed},
                new SqlParameter("@CanRead", SqlDbType.Int) {Value =ObjReportJobList.CanRead},
                new SqlParameter("@CanWrite", SqlDbType.Int) {Value =ObjReportJobList.CanWrite},
                new SqlParameter("@MartialStatus", SqlDbType.Int) {Value =ObjReportJobList.MartialStatus}



            };


            var spName = "SP_Report_Sab_Saath_Job_List";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet Get_Report_Applicant_Case_List(ReportingContext.Report_Applicant_Case_List ObjApplicantCaseList)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", SqlDbType.Date) {Value =ObjApplicantCaseList.FromDate},
                new SqlParameter("@ToDate", SqlDbType.Date) {Value =ObjApplicantCaseList.ToDate},
                new SqlParameter("@ApplicantCaseCode", SqlDbType.NVarChar) {Value =ObjApplicantCaseList.ApplicantCaseCode},
                new SqlParameter("@ApplicantName", SqlDbType.NVarChar) {Value =ObjApplicantCaseList.ApplicantName},
                new SqlParameter("@CNIC", SqlDbType.NVarChar) {Value =ObjApplicantCaseList.CNIC},
                new SqlParameter("@GenderId", SqlDbType.Int) {Value =ObjApplicantCaseList.GenderId},
                new SqlParameter("@CityId", SqlDbType.Int) {Value =ObjApplicantCaseList.CityId},
                new SqlParameter("@CaseNatureId", SqlDbType.Int) {Value =ObjApplicantCaseList.CaseNatureId},
                new SqlParameter("@CategoryId", SqlDbType.Int) {Value =ObjApplicantCaseList.CategoryId},
                new SqlParameter("@FundCategoryId", SqlDbType.Int) {Value =ObjApplicantCaseList.FundCategoryId},
                new SqlParameter("@ReferralTypeId", SqlDbType.Int) {Value =ObjApplicantCaseList.ReferralTypeId},
                new SqlParameter("@ReferralName", SqlDbType.NVarChar) {Value =ObjApplicantCaseList.ReferralName},
                new SqlParameter("@CaseStatusId", SqlDbType.Int) {Value =ObjApplicantCaseList.CaseStatusId},
                new SqlParameter("@IsViewBlackList", SqlDbType.Int) {Value =ObjApplicantCaseList.IsViewBlackList},
                new SqlParameter("@MartialStatus", SqlDbType.Int) {Value =ObjApplicantCaseList.MartialStatusId}


            };


            var spName = "SP_Report_Sab_Saath_Applicant_Case_List";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet Get_Report_Payment_List(ReportingContext.Report_Payment_List ObjPaymentList)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", SqlDbType.Date) {Value =ObjPaymentList.FromDate},
                new SqlParameter("@ToDate", SqlDbType.Date) {Value =ObjPaymentList.ToDate},
                new SqlParameter("@ApplicantCaseCode", SqlDbType.NVarChar) {Value =ObjPaymentList.ApplicantCaseCode},
                new SqlParameter("@ApplicantName", SqlDbType.NVarChar) {Value =ObjPaymentList.ApplicantName},
                new SqlParameter("@Cnic", SqlDbType.NVarChar) {Value =ObjPaymentList.CNIC},
                new SqlParameter("@SupportType", SqlDbType.Int) {Value =ObjPaymentList.SupportType},
                new SqlParameter("@CategoryId", SqlDbType.Int) {Value =ObjPaymentList.FundCategoryId},
                new SqlParameter("@FundSubCategoryId", SqlDbType.Int) {Value =ObjPaymentList.FundSubCategoryId},
            };
            var spName = "SP_Report_Sab_Saath_Payment_List";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet Get_Report_Donation_List(ReportingContext.Report_Donation_List ObjPaymentList)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@OperationID", SqlDbType.Int) {Value =ObjPaymentList.OperationID},
                new SqlParameter("@DonationFromDate", SqlDbType.Date) {Value =ObjPaymentList.DonationFromDate},
                new SqlParameter("@DonationToDate", SqlDbType.Date) {Value =ObjPaymentList.DonationToDate},
                new SqlParameter("@DonorName", SqlDbType.VarChar) {Value =ObjPaymentList.DonorName},
                new SqlParameter("@DonorEmail", SqlDbType.VarChar) {Value =ObjPaymentList.DonorEmail},
                new SqlParameter("@TransactionID", SqlDbType.Int) {Value =ObjPaymentList.TransactionID},
                new SqlParameter("@PaymentSource", SqlDbType.Int) {Value =ObjPaymentList.PaymentSource},
                new SqlParameter("@Currency", SqlDbType.Int) {Value =ObjPaymentList.Currency},
                new SqlParameter("@Category", SqlDbType.Int) {Value =ObjPaymentList.Category},
                new SqlParameter("@SubCategory", SqlDbType.Int) {Value =ObjPaymentList.SubCategory},
                new SqlParameter("@Cause", SqlDbType.VarChar) {Value =ObjPaymentList.Cause},
                new SqlParameter("@Note", SqlDbType.VarChar) {Value =ObjPaymentList.Note},
                new SqlParameter("@NGO", SqlDbType.VarChar) {Value =ObjPaymentList.NGO},
                new SqlParameter("@IsRecievedUpdates", SqlDbType.Bit) {Value =ObjPaymentList.IsRecievedUpdates},
            };
            var spName = "sp_Report_Donation_List";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }

        public DataSet Report_Case_Donation_Details(ReportingContext.Report_Case_Donation_Details ObjPaymentList)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@OperationID", SqlDbType.Int) {Value =ObjPaymentList.OperationID},
                new SqlParameter("@ApplicantCaseId", SqlDbType.Int) {Value =ObjPaymentList.ApplicantCaseId},
                new SqlParameter("@Cause", SqlDbType.NVarChar) {Value =ObjPaymentList.Cause},
                new SqlParameter("@CaseStatus", SqlDbType.VarChar) {Value =ObjPaymentList.CaseStatus},
                new SqlParameter("@Category", SqlDbType.Int) {Value =ObjPaymentList.Category},
            };
            var spName = "sp_CaseDonationReportDetails";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet Get_Report_Donor_List(ReportingContext.Report_Donord_List ObjDonorList)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@ApplicantCaseCode", SqlDbType.NVarChar) {Value =ObjDonorList.ApplicantCaseCode},
                new SqlParameter("@CaseTitle", SqlDbType.NVarChar) {Value =ObjDonorList.CaseTitle},
                new SqlParameter("@FirstName", SqlDbType.NVarChar) {Value =ObjDonorList.FirstName},
                new SqlParameter("@LastName", SqlDbType.NVarChar) {Value =ObjDonorList.LastName},
                new SqlParameter("@TypeOfDonationId", SqlDbType.Int) {Value =ObjDonorList.TypeOfDonationId},
                new SqlParameter("@PaymentTypeId", SqlDbType.Int) {Value =ObjDonorList.PaymentTypeId},



            };


            var spName = "SP_Report_Sab_Saath_DonorList";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet Get_Report_Referral_List(ReportingContext.Report_Referral_List ObjReferralList)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {

                new SqlParameter("@ReferralTypeId", SqlDbType.Int) {Value =ObjReferralList.ReferralTypeId == 0 ? null :ObjReferralList.ReferralTypeId },
                new SqlParameter("@ReferralApplicantOrCompanyId", SqlDbType.Int) {Value =ObjReferralList.ReferralApplicantOrCompanyId == 0 ? null :ObjReferralList.ReferralApplicantOrCompanyId },
                new SqlParameter("@ReferralName", SqlDbType.NVarChar) {Value =ObjReferralList.ReferralName},




            };


            var spName = "SP_Report_Sab_Saath_Referral_List";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet Get_Report_Company_List(ReportingContext.Report_Company_List ObjCompanyList)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {

                new SqlParameter("@CompanyName", SqlDbType.NVarChar) {Value =ObjCompanyList.CompanyName},
                new SqlParameter("@CompanyPhoneNo", SqlDbType.NVarChar) {Value =ObjCompanyList.CompanyPhoneNo}
            };


            var spName = "SP_Report_Sab_Saath_Company";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet Get_Report_Institute_Wise_List(ReportingContext.Report_Institute_Wise_List objInstitute)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {

                new SqlParameter("@ApplicantCaseCode", SqlDbType.NVarChar) {Value =objInstitute.ApplicantCaseCode},
                new SqlParameter("@ApplicantName", SqlDbType.NVarChar) {Value =objInstitute.ApplicantName},
                new SqlParameter("@CNIC", SqlDbType.NVarChar) {Value =objInstitute.CNIC},
                new SqlParameter("@NameOfStudent", SqlDbType.NVarChar) {Value =objInstitute.NameOfStudent},
                new SqlParameter("@NameOfInstitute", SqlDbType.NVarChar) {Value =objInstitute.NameOfInstitute},
                new SqlParameter("@ClassYearSemesterID", SqlDbType.Int) {Value =objInstitute.ClassSemesterId},
                new SqlParameter("@DegreeId", SqlDbType.Int) {Value =objInstitute.DegreeId},
                new SqlParameter("@ProgrammeName", SqlDbType.NVarChar) {Value =objInstitute.ProgrammeName},

            };


            var spName = "SP_Report_Sab_Saath_InstituteWise";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet Get_Report_Patient_List(ReportingContext.Report_Patient_List ObjPatientList)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {

                new SqlParameter("@ApplicantCaseCode", SqlDbType.NVarChar) {Value =ObjPatientList.ApplicantCaseCode},
                new SqlParameter("@ApplicantName", SqlDbType.NVarChar) {Value =ObjPatientList.ApplicantName},
                new SqlParameter("@CNIC", SqlDbType.NVarChar) {Value =ObjPatientList.CNIC},
                new SqlParameter("@PatientName", SqlDbType.NVarChar) {Value =ObjPatientList.PatientName},
                new SqlParameter("@PatientContactNumber", SqlDbType.NVarChar) {Value =ObjPatientList.PatientContactNumber},
                new SqlParameter("@DisabilityId", SqlDbType.Int) {Value =ObjPatientList.DisabilityId},
                new SqlParameter("@DiseaseId", SqlDbType.Int) {Value =ObjPatientList.DiseaseId},
                new SqlParameter("@HospitalName", SqlDbType.NVarChar) {Value =ObjPatientList.HospitalName},
                new SqlParameter("@DoctorName", SqlDbType.NVarChar) {Value =ObjPatientList.DoctorName},


            };


            var spName = "SP_Report_Sab_Saath_Patient_List";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet Report_Payment_Reverse_Disburs(ReportingContext.Report_Payment_Reverse_Disburs ObjPaymentList)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", SqlDbType.Date) {Value =ObjPaymentList.FromDate},
                new SqlParameter("@ToDate", SqlDbType.Date) {Value =ObjPaymentList.ToDate},
                new SqlParameter("@ApplicantCaseCode", SqlDbType.NVarChar) {Value =ObjPaymentList.ApplicantCaseCode},
                new SqlParameter("@ApplicantName", SqlDbType.NVarChar) {Value =ObjPaymentList.ApplicantName},
                new SqlParameter("@Cnic", SqlDbType.NVarChar) {Value =ObjPaymentList.CNIC},
                new SqlParameter("@SupportType", SqlDbType.Int) {Value =ObjPaymentList.SupportType},
                new SqlParameter("@CategoryId", SqlDbType.Int) {Value = ObjPaymentList.FundCategoryId == null ? 0 : ObjPaymentList.FundCategoryId},
                new SqlParameter("@FundSubCategoryId", SqlDbType.Int) {Value =ObjPaymentList.FundSubCategoryId == null ? 0 : ObjPaymentList.FundSubCategoryId},
                new SqlParameter("@status", SqlDbType.Int) {Value =ObjPaymentList.PaymentStatus == null ? 0 : ObjPaymentList.PaymentStatus},
            };
            var spName = "SP_Report_Payment_Reverse_Disburs";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet Report_DonationHistory(ReportingContext.Report_DonationHistory ObjPaymentList)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@OperationID", SqlDbType.Int) {Value = ObjPaymentList.OperationID},
                new SqlParameter("@UserId", SqlDbType.Int) {Value = ObjPaymentList.UserId},
            };
            var spName = "SP_DonationHistory";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet Report_Task_Sechduler(ReportingContext.Report_Task_Sechduler ObjPaymentList)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@operationid", SqlDbType.Int) {Value =ObjPaymentList.operationid},
                new SqlParameter("@id", SqlDbType.Int) { Value = ObjPaymentList.ID},
                new SqlParameter("@Status", SqlDbType.VarChar) {Value = ObjPaymentList.Status},
                new SqlParameter("@count", SqlDbType.Int) {Value =ObjPaymentList.count},
                new SqlParameter("@Reason", SqlDbType.NVarChar) {Value =ObjPaymentList.count},
                new SqlParameter("@fromdate", SqlDbType.DateTime) {Value =ObjPaymentList.Fromdate},
                new SqlParameter("@todate", SqlDbType.DateTime) {Value =ObjPaymentList.Todate},
                new SqlParameter("@schdulerdate", SqlDbType.DateTime) {Value =ObjPaymentList.Schedulerdate },
            };
            var spName = "SP_taskschedulerlog";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet Report_SubscriptionDetail(ReportingContext.Report_Subscription ObjPaymentList)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@OperationID", SqlDbType.Int) { Value = ObjPaymentList.OperationID},
                new SqlParameter("@UserId", SqlDbType.Int) {Value = ObjPaymentList.UserId},
                new SqlParameter("@CategoryWise", SqlDbType.Int) {Value =ObjPaymentList.CategoryWise},
                //new SqlParameter("@SubscriptionDate", SqlDbType.VarChar) {Value =ObjPaymentList.SubscriptionDate},
                new SqlParameter("@PostingFreq", SqlDbType.VarChar) {Value = ObjPaymentList.PostingFreq},
                new SqlParameter("@DonationType", SqlDbType.Int) {Value =ObjPaymentList.DonationType},
            };
            var spName = "SP_SubscriptionDetail";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet Report_Subscription_List_Detail(ReportingContext.Report_Subscription_List_Detail ObjPaymentList)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@OperationID", SqlDbType.Int) { Value = ObjPaymentList.OperationID},
                new SqlParameter("@SubscriptionId", SqlDbType.Int) {Value = ObjPaymentList.SubscriptionId},
            };
            var spName = "SP_SubscriptionDetail";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet Report_Subscription_List(ReportingContext.Report_Subscription_List ObjPaymentList)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@OperationID", SqlDbType.Int) {Value =ObjPaymentList.OperationID},
                new SqlParameter("@SubscriptionFromDate", SqlDbType.Date) {Value =ObjPaymentList.SubscriptionFromDate},
                new SqlParameter("@SubscriptionToDate", SqlDbType.Date) {Value =ObjPaymentList.SubscriptionToDate},
                new SqlParameter("@DonorName", SqlDbType.VarChar) {Value =ObjPaymentList.DonorName},
                new SqlParameter("@DonorContact", SqlDbType.VarChar) {Value =ObjPaymentList.DonorContact},
                new SqlParameter("@SubscriptionID", SqlDbType.Int) {Value =ObjPaymentList.SubscriptionID}, 
                new SqlParameter("@Currency", SqlDbType.Int) {Value =ObjPaymentList.Currency},
                new SqlParameter("@Category", SqlDbType.Int) {Value =ObjPaymentList.Category},
                new SqlParameter("@SubCategory", SqlDbType.Int) {Value =ObjPaymentList.SubCategory},
                new SqlParameter("@Cause", SqlDbType.VarChar) {Value =ObjPaymentList.Cause},
            };
            var spName = "sp_Report_Subscription_List";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
        public DataSet Report_SubscriptionCancel(ReportingContext.Report_SubscriptionCancel ObjPaymentList)
        {
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@OperationID", SqlDbType.Int) { Value = ObjPaymentList.OperationID},
                new SqlParameter("@SubscriptionDetailId", SqlDbType.Int) {Value = ObjPaymentList.SubscriptionDetailId},
                new SqlParameter("@UserId", SqlDbType.Int) {Value = ObjPaymentList.UserId},
            };
            var spName = "SP_SubscriptionDetail";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
    }
}
