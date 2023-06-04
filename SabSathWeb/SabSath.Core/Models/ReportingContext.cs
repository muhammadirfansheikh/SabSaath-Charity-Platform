using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabSath.Core.Models
{
    public class ReportingContext
    {
        public class Report_Job_List
        {
            public string Name { get; set; }
            public int? Qualification { get; set; }
            public string Contact_No { get; set; }
            public string Address { get; set; }
            public int? Employed { get; set; }
            public int? CanRead { get; set; }
            public int? CanWrite { get; set; }
            public int? MartialStatus { get; set; }

        }
        public class Report_Applicant_Case_List
        {
            public DateTime FromDate { get; set; }
            public DateTime ToDate { get; set; }
            public string ApplicantCaseCode { get; set; }
            public string ApplicantName { get; set; }
            public string CNIC { get; set; }
            public int? GenderId { get; set; }
            public int? CityId { get; set; }
            public int? CaseNatureId { get; set; }
            public int? CategoryId { get; set; }
            public int? FundCategoryId { get; set; }
            public int? ReferralTypeId { get; set; }
            public string ReferralName { get; set; }
            public int? CaseStatusId { get; set; }
            public int? IsViewBlackList { get; set; }

            public int? MartialStatusId { get; set; }


        }
        public class Report_Payment_List
        {
            public DateTime FromDate { get; set; }
            public DateTime ToDate { get; set; }
            public string ApplicantCaseCode { get; set; }
            public string ApplicantName { get; set; }
            public string CNIC { get; set; }
            public int? SupportType { get; set; }
            public int? FundSubCategoryId { get; set; }
            public int? FundCategoryId { get; set; }
        }
        public class Report_Task_Sechduler
        {
            public int operationid { get; set; }
            public int? ID { get; set; }
            public string Status { get; set; }
            public int? count { get; set; }
            public string Reason { get; set; }
            public DateTime? Fromdate { get; set; }
            public DateTime? Todate { get; set; }
            public DateTime? Schedulerdate { get; set; }
        }
        public class Report_Donord_List
        {
            public string ApplicantCaseCode { get; set; }
            public string CaseTitle { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int? TypeOfDonationId { get; set; }
            public int? PaymentTypeId { get; set; }

        }
        public class Report_Referral_List
        {

            public int? ReferralTypeId { get; set; }
            public int? ReferralApplicantOrCompanyId { get; set; }
            public string ReferralName { get; set; }

        }
        public class Report_Company_List
        {
            public string CompanyName { get; set; }
            public string CompanyPhoneNo { get; set; }

        }
        public class Report_Institute_Wise_List
        {
            public string ApplicantCaseCode { get; set; }
            public string ApplicantName { get; set; }
            public string CNIC { get; set; }
            public string NameOfStudent { get; set; }
            public string NameOfInstitute { get; set; }
            public int? ClassSemesterId { get; set; }
            public int? DegreeId { get; set; }
            public string ProgrammeName { get; set; }

        }
        public class Report_Patient_List
        {
            public string ApplicantCaseCode { get; set; }
            public string ApplicantName { get; set; }
            public string CNIC { get; set; }
            public string PatientName { get; set; }
            public string PatientContactNumber { get; set; }
            public int? DisabilityId { get; set; }
            public int? DiseaseId { get; set; }
            public string HospitalName { get; set; }
            public string DoctorName { get; set; }


        }
        public class Report_Payment_Reverse_Disburs
        {
            public DateTime FromDate { get; set; }
            public DateTime ToDate { get; set; }
            public string ApplicantCaseCode { get; set; }
            public string ApplicantName { get; set; }
            public string CNIC { get; set; }
            public int? SupportType { get; set; }
            public int? FundSubCategoryId { get; set; }
            public int? FundCategoryId { get; set; }

            public int? PaymentStatus { get; set; }
        }
        public class Report_Subscription
        {

            public int? OperationID { get; set; }
            public int? UserId { get; set; }
            public int? CategoryWise { get; set; }

            public string SubscriptionDate { get; set; }
            public string PostingFreq { get; set; }

            public int DonationType { get; set; }

        }
        public class Report_Subscription_List_Detail
        {
            public int? OperationID { get; set; }
            public int? SubscriptionId { get; set; }
        }
        public class Report_SubscriptionCancel
        {
            public int? OperationID { get; set; }
            public int? SubscriptionDetailId { get; set; }
            public int? UserId { get; set; }
        }
        public class Report_DonationHistory
        {
            public int? OperationID { get; set; }
            public int? UserId { get; set; }
        }

        public class Report_Case_Donation_Details
        {
            public int OperationID { get; set; }
            public int? ApplicantCaseId { get; set; }
            public string Cause { get; set; }
            public string CaseStatus { get; set; }
            public int? Category { get; set; }
        }
        public class Report_Donation_List
        {
            public int? OperationID { get; set; }
            public DateTime? DonationFromDate { get; set; }
            public DateTime? DonationToDate { get; set; }
            public string DonorName { get; set; }
            public string DonorEmail { get; set; }
            public int? TransactionID { get; set; }
            public int? PaymentSource { get; set; }
            public int? Currency { get; set; }
            public int? Category { get; set; }
            public int? SubCategory { get; set; }
            public string Cause { get; set; }
            public string Note { get; set; }
            public string NGO { get; set; }
            public bool IsRecievedUpdates { get; set; }
        }
        public class Report_Subscription_List
        {
            public int? OperationID { get; set; }
            public DateTime? SubscriptionFromDate { get; set; }
            public DateTime? SubscriptionToDate { get; set; }
            public string DonorName { get; set; }
            public string DonorContact { get; set; }
            public int? SubscriptionID { get; set; } 
            public int? Currency { get; set; }
            public int? Category { get; set; }
            public int? SubCategory { get; set; }
            public string Cause { get; set; } 
        }
    }
}
