using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabSath.Core.Models
{
    public class ApplicantContext
    {
        public class ApplicantCaseRegistration
        {

            public int OperationId { get; set; }
            public string CnicNo { get; set; }
            public int ApplicantId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public int? GenderId { get; set; }
            public string FatherName { get; set; }
            public string PrimaryContactNumber { get; set; }
            public string AlternateContactNumber { get; set; }
            public int? PrimaryFundCategoryId { get; set; }
            public decimal FundAmount_Required { get; set; }
            public int? CityId { get; set; }
            public string PermanentAddress { get; set; }
            public int? CaseNatureId { get; set; }
            public int NoOf_HouseHold_Member { get; set; }
            public string FamilyNo { get; set; }
            //public string NoOf_Family_Members_Accompanying { get; set; }
            public int? Referral_TypeId { get; set; }
            public int? Referral_CompanyId { get; set; }
            public string ReferralName { get; set; }
            public string ReferralContactNumber { get; set; }
            public int? Referral_RelationId { get; set; }
            public DateTime? CaseExpiry { get; set; }
            public bool IsJoinFamily { get; set; }
            public bool IsHOD_HR_Signature { get; set; }
            public int? InvestigatorId { get; set; }
            public int UserId { get; set; }
            public string UserIP { get; set; }
            public string Attachment { get; set; }

            public int? AreaId { get; set; }

            public string Remarks { get; set; }



            public int? CaseStatusId { get; set; } //add line manzoor


        }
        public class ApplicantPersonalInfoContactDetail
        {
            public int OperationId { get; set; }
            public int ApplicantCase_InvestigationId { get; set; }
            public int ApplicantContactDetailId { get; set; }
            public int? PhoneTypeId { get; set; }
            public string PhoneNo { get; set; }
            public int UserId { get; set; }
            public string UserIP { get; set; }




        }
        public class ApplicantGuardianDetail
        {
            public int OperationId { get; set; }
            public int ApplicantCase_InvestigationId { get; set; }
            public int ApplicantGuardianDetailId { get; set; }

            public string GuardianName { get; set; }
            public string GuardianCnic { get; set; }
            public string GuardianContactNo { get; set; }
            public string Occupation { get; set; }
            public string Relation { get; set; }
            public string CompanyName { get; set; }

            public int UserId { get; set; }
            public string UserIP { get; set; }




        }
        public class ApplicantMonthlyExpenseDetail
        {
            public int OperationId { get; set; }
            public int ApplicantCase_InvestigationId { get; set; }
            public int ApplicantMonthlyExpenseDetailId { get; set; }
            public int? ExpenseId { get; set; }
            public decimal Amount { get; set; }
            public int UserId { get; set; }
            public string UserIP { get; set; }

        }
        public class ApplicantPetDetail
        {
            public int OperationId { get; set; }
            public int ApplicantCase_InvestigationId { get; set; }
            public int ApplicantPetDetailId { get; set; }
            public int? PetId { get; set; }
            public int Quantity { get; set; }
            public int UserId { get; set; }
            public string UserIP { get; set; }




        }
        public class ApplicantAssetDetail
        {
            public int OperationId { get; set; }
            public int ApplicantCase_InvestigationId { get; set; }
            public int ApplicantAssetDetailId { get; set; }
            public int? AssetTypeId { get; set; }
            public string MortgageLandLordName { get; set; }
            public string MortgageLandLordContactNo { get; set; }
            public string MortgageLandLordAddress { get; set; }
            public string Remarks { get; set; }

            public int? AssetSubTypeId { get; set; }
            public int? AssetStatusId { get; set; }
            public int? Quantity { get; set; }
            public int UserId { get; set; }
            public string UserIP { get; set; }




        }
        public class ApplicantFamilyDetail
        {
            public int OperationId { get; set; }
            public int ApplicantCase_InvestigationId { get; set; }
            public int ApplicantFamilyDetailId { get; set; }
            public string Name { get; set; }
            public string Cnic { get; set; }
            public string Mother_Father_HusbandName { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public bool IsDeceased { get; set; }
            public DateTime? DateOfDeath { get; set; }
            public int? RelationId { get; set; }
            public int? ReligionId { get; set; }
            public int? GenderId { get; set; }
            public int? ContactTypeId { get; set; }
            public int? MaritalStatusId { get; set; }
            public bool IsPartOfBannedOrg { get; set; }
            public bool IsInvolveInCriminalActivity { get; set; }
            public bool HasMedicalHistory { get; set; }
            public string Remarks { get; set; }
            public string ContactNumber { get; set; }
            public int UserId { get; set; }
            public string UserIP { get; set; }
            public bool CanRead { get; set; }
            public bool CanWrite { get; set; }
            public bool IsEmployeed { get; set; }
            public bool IsJobList { get; set; }
            public string JobRemarks { get; set; }
            public string LastWorkExperience { get; set; }
            public bool Orphan { get; set; }
            public string FamilyMemberPicture { get; set; }

        }
        public class ApplicantFamilyJobExperienceDetail
        {
            public int OperationId { get; set; }
            public int ApplicantCase_InvestigationId { get; set; }
            public int ApplicantFamily_JobExperienceDetailId { get; set; }

            public int? ApplicantFamilyDetailId { get; set; }
            public int? JobStatusId { get; set; }
            public decimal EarningAmount { get; set; }
            public string LastCompanyName { get; set; }

            public string Remarks { get; set; }

            public int UserId { get; set; }
            public string UserIP { get; set; }




        }
        public class ApplicantFamilyEducationDetail
        {
            public int OperationId { get; set; }
            public int ApplicantCase_InvestigationId { get; set; }
            public int ApplicantFamily_EducationDetailId { get; set; }
            public int? ApplicantFamilyDetailId { get; set; }
            public int? AcademicId { get; set; }
            public string NameOfInstitute { get; set; }
            public string ProgramName { get; set; }
            public string Grade_Percentage_CGPA_Marks { get; set; }
            public string Location { get; set; }
            public string Educational_ContactNo { get; set; }
            public int? DegreeId { get; set; }
            public int? Class_SemesterId { get; set; }
            public int? YearOfCompletion { get; set; }
            public int UserId { get; set; }
            public string UserIP { get; set; }
            public bool? Counselling { get; set; }
        }
        public class EducationalCounselling
        {
            public int OperationID { get; set; }
            public int? UserId { get; set; }
            public string UserIP { get; set; }

            // Search Filter
            public string ApplicantName { get; set; }
            public string ApplicantCNIC { get; set; }
            public DateTime? LastCounsellingSession { get; set; }
            public DateTime? NextCounsellingSession { get; set; }
            public DateTime? NextSessionDateAfter { get; set; }
            public string StudentName { get; set; }

            // End Search Filter

            public int? Educational_Counselling_ID { get; set; }
            public int? ApplicantFamily_EducationDetailId { get; set; }
            public DateTime? LastCounsellingSessionDate { get; set; }
            public DateTime? NextCounsellingSessionDate { get; set; }
            public int? ApplicantCaseId { get; set; }
            public DateTime? CreatedDate { get; set; }
            public int? Createdby { get; set; }
            public string Remarks { get; set; }
            public int? SchoolStatus { get; set; }
            public string SchoolStatusRemarks { get; set; }
            public DateTime? CounsellingDate { get; set; }
            public string CounsellorName { get; set; }
            public string CounsellorContactNumber { get; set; }
            public string OtherCounsellorsPresent { get; set; }
            public string AttendantWithStudent { get; set; }
            public string ExtraCurricularActivities { get; set; }
            public bool? Job { get; set; }
            public string JobRemarks { get; set; }
            public bool? FamilyCounselling { get; set; }
            public string StatedCareerGoals { get; set; }
            public string OtherRemarks { get; set; }
            public bool? AdditionalAssistance { get; set; }
            public string AdditionalAssistanceRemarksbyCounsellor { get; set; }
            public bool? AssignedMentor { get; set; }
            public string MentorName { get; set; }
            public string MentorContactNumber { get; set; }
            public string MentorSpecialization { get; set; }
            public string StudentFeedback { get; set; }
            public bool? CaseHistory { get; set; }
            public bool? FamilyHistory { get; set; }
            public bool? FamilyCounseling { get; set; }
            public bool? Declaration { get; set; }
            public string CounsellorRemarks { get; set; }
            public string PlansForImplementationOfSaidGoals { get; set; }
            public bool? DoesTheStudentHaveACV { get; set; }
            public int? StudentRatingOfZamanFoundationServices { get; set; }
            public int? IsCompleted { get; set; }
        }
        public class ApplicantFamilyMedicalCardDetail
        {
            public int OperationId { get; set; }
            public int ApplicantCase_InvestigationId { get; set; }
            public int ApplicantFamily_MedicalCardDetailId { get; set; }

            public int? ApplicantFamilyDetailId { get; set; }
            public int? EligibleCardId { get; set; }
            public decimal MedicalCardAmount { get; set; }

            public int UserId { get; set; }
            public string UserIP { get; set; }




        }
        public class ApplicantFamilyMedicalDisabilityDetail
        {
            public int OperationId { get; set; }
            public int ApplicantCase_InvestigationId { get; set; }
            public int ApplicantFamily_MedicalDisablityDetailId { get; set; }

            public int? ApplicantFamilyDetailId { get; set; }
            public int? DisabilityId { get; set; }
            public string HospitalName { get; set; }
            public string HospitalContactNo { get; set; }
            public string HospitalAddress { get; set; }
            public string DoctorName { get; set; }
            public string DoctorContactNo { get; set; }

            public int UserId { get; set; }
            public string UserIP { get; set; }




        }
        public class ApplicantFamilyMedicalDiseaseDetail
        {
            public int OperationId { get; set; }
            public int ApplicantCase_InvestigationId { get; set; }
            public int ApplicantFamily_MedicalDiseaseDetailId { get; set; }

            public int? ApplicantFamilyDetailId { get; set; }
            public int? DiseaseId { get; set; }
            public string HospitalName { get; set; }
            public string HospitalContactNo { get; set; }
            public string HospitalAddress { get; set; }
            public string DoctorName { get; set; }
            public string DoctorContactNo { get; set; }

            public int UserId { get; set; }
            public string UserIP { get; set; }




        }
        public class ApplicantList
        {
            public int UserId { get; set; }
            public string ApplicantCode { get; set; }
            public string ApplicantCaseCode { get; set; }
            public string ApplicantName { get; set; }
            public string Cnic { get; set; }
            public string ReferralName { get; set; }
            public int GenderID { get; set; }
            public int CountryId { get; set; }
            public int ProvinceId { get; set; }
            public int CityId { get; set; }
            public int FundCategoryId { get; set; }
            public int CaseNatureId { get; set; }
            public int CaseStatusId { get; set; }
            public int Referral_TypeId { get; set; }
            public int Investigatorid { get; set; }
            public string TabName { get; set; }
            public Int64 IsCaseStory { get; set; }
            public Int64 ViewFilterId { get; set; }
            public DateTime? FromDate { get; set; }
            public DateTime? ToDate { get; set; }

        }
        public class PhysicalAuditList
        {
            public int OperationId { get; set; }
            public int? AuditStatus { get; set; }
            public string Auditor { get; set; }
            public DateTime? AssignDate { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? CloseDate { get; set; }

            public string CaseCode { get; set; }

            public string ApplicantCnic { get; set; }

            public string ApplicantName { get; set; }
            public int? ApplicantCase_InvestigationId { get; set; }

            public int? PhysicalAuditId { get; set; }

            public string TrusteeRemarks { get; set; }

            public string AuditorRemarks { get; set; }

            public int? RoleId { get; set; }

            public int? AuditStatusEdit { get; set; }
            public int? UserID { get; set; }
        }
        public class ApplicantSupport
        {

            public int operationid { get; set; }
            public int ApplicantCase_InvestigationId { get; set; }
            public string userip { get; set; }
            public int? userid { get; set; }

            public List<ApplicantCaseSupport_UD> ApplicantSupportArray { get; set; }

        }
        public class ApplicantCaseSupport_UD
        {
            public int? ApplicantCaseId { get; set; }
            public bool? IsPrimarySupport { get; set; }
            public int? FundCategoryId { get; set; }
            public decimal? AmountRequested { get; set; }
            public decimal? AmountApproved { get; set; }
            public int SupportStatusId { get; set; }
            public int ApplicantFamilyDetailId { get; set; }
            public int FundSubCategoryId { get; set; }
            public string Remarks { get; set; }
            public int? Repitation { get; set; }
            public int? RepetaionRemaining { get; set; }
            public int? PaymentFrequencyId { get; set; }
            public bool? IsActive { get; set; }
            public bool? IsDeleted { get; set; }
            public int? CreatedBy { get; set; }
            public int? ModifiedBy { get; set; }
            public DateTime? ModifiedDate { get; set; }
            public DateTime? CreatedDate { get; set; }
            public string UserIP { get; set; }
        }
        public class ApplicantAssetDetailHomeApplainces
        {
            public int OperationId { get; set; }
            public int ApplicantCase_InvestigationId { get; set; }
            public int UserId { get; set; }
            public string UserIP { get; set; }

            public List<ApplicantAssetDetailHomeApplainces_UD> AssetHomeApplainceArray { get; set; }
        }
        public class ApplicantAssetDetailHomeApplainces_UD
        {
            public int? AssetTypeID { get; set; }
            public int Quantity { get; set; }
            public string Remarks { get; set; }
        }
        public class ApplicantPersonalInformation
        {
            public int OperationId { get; set; }
            public int ApplicantCase_InvestigationId { get; set; }
            public string CnicNo { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int? GenderId { get; set; }
            public string FatherName { get; set; }
            public string DateOfBirth { get; set; }
            public string FamilyNumber { get; set; }
            public int? ReligionId { get; set; }
            public int NoOf_HouseHold_Member { get; set; }
            public string NoOf_Family_Members_Accompanying { get; set; }
            public bool IsJoinFamily { get; set; }
            public int? CityId { get; set; }
            public string TemperoryAddresss { get; set; }
            public string PermanentAddress { get; set; }
            public string AcceptanceOfCharity_Ids { get; set; }
            public int UserId { get; set; }
            public string UserIP { get; set; }

            public int? AreaId { get; set; }

            public int? MartialStatusId { get; set; }


            public List<ApplicantPersonalInformation_UD> ArrayApplicantPersonalInformation { get; set; }

        }
        public class ApplicantPersonalInformation_UD
        {
            public int? AdditionalPersonalDetailId { get; set; }
            public bool IsChecked { get; set; }
            public string TextBox_Value { get; set; }

        }
        public class ApplicantCaseReInvestigate
        {
            public int ApplicantCase_InvestigationId { get; set; }
            public int? InvestigatorId { get; set; }
            public string ReinvestigationDate { get; set; }
            public string Remarks { get; set; }
            public int UserId { get; set; }
            public string UserIP { get; set; }
        }
        public class ApplicantLoanDetail
        {
            public int OperationId { get; set; }
            public int ApplicantCase_InvestigationId { get; set; }
            public int ApplicantLoanDetailId { get; set; }
            public int? LoanTypeId { get; set; }
            public decimal? LoanAmount { get; set; }
            public decimal? MonthlyAmount { get; set; }
            public decimal? BalanceAmount { get; set; }
            public string Remarks { get; set; }
            public int UserId { get; set; }
            public string UserIP { get; set; }
        }
        public class ApplicantCaseSourceOfDrinkingSanatationAndWashroom
        {
            public int OperationId { get; set; }
            public int ApplicantCase_InvestigationId { get; set; }
            public string SourceOfDrinking_Ids { get; set; }
            public string SanitationAndWashroom_Ids { get; set; }

            public int UserId { get; set; }
            public string UserIP { get; set; }
        }
        public class Followup
        {
            public int OperationId { get; set; }
            public int ApplicantCase_InvestigationId { get; set; }
            public int FollowUpId { get; set; }
            public DateTime? FollowUpDate { get; set; }
            public int? InvestigatorId { get; set; }
            public string Remarks { get; set; }
            public string FollowupSubmittionRemarks { get; set; }
            public int UserId { get; set; }
            public string UserIP { get; set; }
        }
        public class SupportingDoc
        {
            public int OperationId { get; set; }
            public int ApplicantCase_InvestigationId { get; set; }
            public Int32 ApplicantCase_SupportDocId { get; set; }
            public int UserId { get; set; }
            public string UserIP { get; set; }
        }
        public class ApplicantCase_StatusHistory
        {
            public int OperationId { get; set; }
            public int ApplicantCase_InvestigationId { get; set; }
            public int CaseStatusId { get; set; }
            public string Remarks { get; set; }
            public int UserId { get; set; }
            public string UserIP { get; set; }
            public List<ApplicantCase_SupportHistory> ArrayApplicantCaseSupportHistory { get; set; }
            public bool IsBlackList { get; set; }
            public string CaseStartDate { get; set; }
            public bool IsProbation { get; set; }
            public bool PhysicalAudit { get; set; }
            public int? Physical_Audit_Assign { get; set; }
        }
        public class ApplicantCase_SupportHistory
        {
            public int ApplicantCaseSupportId { get; set; }
            public decimal AmountApproved { get; set; }
            public string Remarks { get; set; }
            public int SupportStatusId { get; set; }
            public DateTime? PaymentStartDateT { get; set; }
            public int? PaymentTypeID { get; set; }

            public int? ApplicantCaseSupportDetailId { get; set; }





        }
        public class Assign_Investigator
        {
            public int ApplicantCase_InvestigationId { get; set; }
            public int InvestigatorId { get; set; }
            public int UserId { get; set; }
            public string UserIP { get; set; }
        }
        public class JobList
        {
            public string Name { get; set; }
            public int Qualification { get; set; }
            public string LastExperience { get; set; }
            public string ContactNumber { get; set; }

        }
        public class PaymentMethod
        {
            public int OperationId { get; set; }
            public int ApplicantCase_InvestigationId { get; set; }
            public int PaymentTypeId { get; set; }
            public string BankName { get; set; }
            public string AccountTitle { get; set; }
            public string AccountNo { get; set; }
            public string PaymentCnicNo { get; set; }
            public int PaymentGatewayId { get; set; }
            public int UserId { get; set; }

        }
        public class GetApplicantCaseHistory
        {
            public int OperationId { get; set; }
            public int ApplicantCase_InvestigationId { get; set; }

        }
        public class SupportDetail
        {
            public int ApplicantCase_InvestigationId { get; set; }
            public int SupportId { get; set; }
            public decimal FundRequired { get; set; }

        }
    }
}
