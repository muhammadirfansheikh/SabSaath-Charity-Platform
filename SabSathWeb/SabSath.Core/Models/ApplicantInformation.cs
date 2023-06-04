

//using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabSath.Core.Models
{
    public class ApplicantInformation
    {


        public int OperationId { get; set; }
        public int ApplicantId { get; set; }

        public string FullName { get; set; }
        public string FatherName { get; set; }
        public string Cnic { get; set; }
        public int CountryId { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public int CaseNatureId { get; set; }
        public int FundsRequired { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int SubSubCategoryId { get; set; }
        public int ReferalTypeId { get; set; }
        public int ReferedBy { get; set; }
        public int UserId { get; set; }
        public int UserIP { get; set; }

        //public int NatureofCaseId { get; set; }

        //public int ReferrerCatIdON { get; set; }
        //public string PermanentAddress { get; set; }
        //public int CompanyFamilyIdON { get; set; }
        //public int ReferrerId { get; set; }






        //public string FullName { get; set; }
        //public string FatherName { get; set; }

        //public string Cnic { get; set; }


        //public int CountryId { get; set; }

        //public int ProvinceId { get; set; }

        //public DateTime ApplicantDate { get; set; }
        //public Int64 Cnic { get; set; }

        //public DateTime DateOfBirth { get; set; }
        //public int GenderId { get; set; }
        //public bool IsActive { get; set; }
        //public int CreatedBy { get; set; }
        //public string UserIP { get; set; }
    }
    public class ApplicantCaseDetail
    {
        public int ApplicantCaseId { get; set; }
        public int ApplicantId { get; set; }
        public string ApplicantCaseCode { get; set; }
        public int MartialStatusId { get; set; }
        public string Father_HusbandName { get; set; }
        public string ContactNumber { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public int UnionId { get; set; }
        public int CouncilId { get; set; }
        public int Village_Muhalla_Id { get; set; }
        public string TemporaryAddress { get; set; }
        public string PermanentAddress { get; set; }
        public int InvestigatingOfficerId { get; set; }
        public string ReferrerName { get; set; }
        public int CaseNatureId { get; set; }
        public bool IsActive { get; set; }
        public bool IsCriminalActivity { get; set; }
        public bool IsPartOfBannedOrg { get; set; }
        public int CreatedBy { get; set; }
        public string UserIP { get; set; }

    }
    public class ApplicantFamilyInformation
    {
        public int OperationId { get; set; }
        public int ApplicantCaseId { get; set; }
        public int FamilyDetailId { get; set; }
        public string FamilyMemberNo { get; set; }
        public string Name { get; set; }
        public int RelationId { get; set; }
        public Int64 Cnic { get; set; }
        public DateTime DOB { get; set; }
        public int MaritalStatusId { get; set; }
        public string Remarks { get; set; }
        public bool IsEmployed { get; set; }
        public string DetailsOfEarning { get; set; }
        public int Earnings { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public string UserIP { get; set; }
    }

    public class MonthlyExpenseDetail
    {
        public int MonthlyExpenseDetailId { get; set; }
        public int ApplicantCaseId { get; set; }
        public int ExpenseId { get; set; }
        public int ExpenseValue { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public string UserIP { get; set; }
    }

    public class PrimaryInfomation
    {

        public int? ApplicantId { get; set; }
        public string Nameofpplicant { get; set; }
        public string FatherNameHusbandName { get; set; }
        public string CNIC { get; set; }
        public string ContactNo { get; set; }
        public int? CountryId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public int? UnionId { get; set; }
        public int? AreaId { get; set; }
        public int? GenderId { get; set; }
        public int? ReferedByEmployeeID { get; set; }
        public int? ReferedByCompanyId { get; set; }
        public int? ReferedByApplicantId { get; set; }
        public int? ReferedByFamilyId { get; set; }
        public int? InvestigatorId { get; set; }

        public int? ReferralTypeId { get; set; }
        public int? ApplicantOrCompanyId { get; set; }
        public int? NoOfFamilyMembersAccompanying { get; set; }
        public int? NoOfHouseholdMembers { get; set; }

        public int? RelationshipId { get; set; }

        public int? FundsCategory { get; set; }
        public int? FundsSabCategory { get; set; }
        public int? NatureOfCase { get; set; }
        public int? FundsRequired { get; set; }
        public int? ReferrerCategory { get; set; }

        public string PermenantAddress { get; set; }
        public string TemporaryAddress { get; set; }

        public string ReferedByName { get; set; }
        public string cnicattachment { get; set; }



        public bool IsJoinFamily { get; set; }
        public bool IsActive { get; set; }

        public int? CompanyFamily { get; set; }



        public int CreatedBy { get; set; }

        public string UserIP { get; set; }









    }

    public class ApplicantCaseSupport
    {
        //Id:0
        //                  ,casedetaildetailid:0
        //                  ,Caseid:0
        //                  ,CategoryId:row.categoryId
        //                  ,IsPrimarySupport:true
        //                  ,IsActive:true
        //                  ,CreatedBy:UserId
        //                  ,ModifiedBy:UserId
        //                  ,ModifiedDate:''
        //                  ,CreatedDate:''
        //                  ,UserIP:UserIp
        //                  ,AmountRequested:row.fundRequired
        //                  ,AmountApproved:0
        //                  ,SubCategoryId:row.fundCategory
        //                  ,Repitation:row.repeatition
        //                  ,PaymentFrequencyId:row.frequency
        //                  ,Remarks:''
        //                  ,familydetailid:row.familyMember

        public int Id { get; set; }
        public int CaseDetailDetailid { get; set; }
        public int Caseid { get; set; }
        public int CategoryId { get; set; }
        public int IsPrimarySupport { get; set; }
        public int IsActive { get; set; }
        public double AmountRequested { get; set; }
        public double AmountApproved { get; set; }
        public int SubCategoryId { get; set; }
        public int Repitation { get; set; }
        public int PaymentFrequencyId { get; set; }
        public string Remarks { get; set; }
        public string FamilyDetailId { get; set; }


    }

    public class ConsolidateApplicant
    {
        public ApplicantInformation ApplicantInformation { get; set; }
        public PrimaryInfomation PrimaryInfomation { get; set; }

        public ApplicantCaseDetail ApplicantCaseDetail { get; set; }
        public List<ApplicantFamilyInformation> ApplicantFamilyInformation { get; set; }
        public List<MonthlyExpenseDetail> MonthlyExpenseDetail { get; set; }
    }

    public class ApplicantGuardianDetail
    {
        public int ApplicantID { get; set; }
        public string name { get; set; }
        public string Cnic { get; set; }
        public string CNIC_Attachment { get; set; }
        public string CompnayName { get; set; }
        public string Occupation { get; set; }
        public int FamilyDetailId { get; set; }
        public int RelationID { get; set; }
        public string ContactNumber { get; set; }

    }

    public class ApplicantExpenseDetail
    {
        public int ApplicantId { get; set; }
        public decimal ExpenseAmountAvg { get; set; }
        public int ExpenseTypeId { get; set; }
        public int id { get; set; }
    }


    public class ApplicantFamilyInformationDetail
    {
        public int? FamilyDetailId { get; set; }
        public string Name { get; set; }
        public int? RelationId { get; set; }
        public string Cnic { get; set; }
        public string CNIC_Attachment { get; set; }
        public string Mother_Father_HusbandName { get; set; }
        public int? ReligionID { get; set; }
        public int? GenderID { get; set; }
        public bool? IsDeceased { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public DateTime? Dob { get; set; }
        public int? MaritalStatusId { get; set; }
        public string Remarks { get; set; }
        public bool? IsPartOfBannedOrg { get; set; }
        public bool? IsCriminalActivity { get; set; }
        public bool? HasMedicalHistory { get; set; }
        public string ContactNumber { get; set; }
        public int? ContactTypeId { get; set; }
        public int? ContactId { get; set; }
        public int? ApplicantId { get; set; }

    }





    public class ApplicantPrimaryInfo
    {
        public List<ApplicantPrimaryInformation> data1 { get; set; }
        public List<ApplicantContact> data2 { get; set; }
        public List<ApplicantFundDetaill> data3 { get; set; }
    }

    public class ApplicantPrimaryInformation
    {
        public int? id { get; set; }
        public int? FamilyDetailId { get; set; }
        public int? CaseId { get; set; }
        public string FullName { get; set; }
        public string Cnic { get; set; }
        public string CNIC_Attachment { get; set; }
        public string Mother_Father_HusbandName { get; set; }
        public int? GenderID { get; set; }
        public DateTime? DOB { get; set; }
        public int? ReligionID { get; set; }
        public int? NoOfFamilyMembersAccompanying { get; set; }
        public int? NoOfHouseholdMembers { get; set; }
        public bool? IsJointFamily { get; set; }
        public int? CountryId { get; set; }
        public int? Village_CityId { get; set; }
        public int? ProvinceId { get; set; }
        public int? Unionid { get; set; }
        public int? DistrictId { get; set; }
        public int? MuhallaId { get; set; }
        public string TemperoryAddresss { get; set; }
        public string PermanentAddress { get; set; }
        public bool? IsCriminalActivity { get; set; }
        public bool? IsPartOfBannedOrg { get; set; }
        public bool? IsGovernmentSupportHolder { get; set; }
        public bool? IsSchoolWithIN1km { get; set; }
        public int? HowFarSchool { get; set; }
        public string FamilyNumber { get; set; }
        public bool? IsActive { get; set; }
    }

    public class ApplicantContact
    {
        public int? id { get; set; }
        public string ContactNumber { get; set; }
        public int? ContactTypeid { get; set; }
        public int? FamilyDetailId { get; set; }
        public bool? IsActive { get; set; }
        //public string UserIP { get; set; }
        //public int? CreatedBy { get; set; }
        //public DateTime? CreatedDate { get; set; }

    }

    public class ApplicantFundDetaill
    {
        public int? id { get; set; }
        public int? FundTypeId { get; set; }
        public int? FamilyDetailId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsAccepted { get; set; }

    }


    public class CaseSupportingDocs
    {
        public string DocAttachment { get; set; }
        public int? CaseId { get; set; }
        public int? DocTypeId { get; set; }
        public bool? IsActive { get; set; }
        public string UserIP { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
       // public IFormFile FormFile { get; set; }
    }

    public class ApplicantMedicalDetail
    {
        public int? id { get; set; }
        public int? FamilyDetailId { get; set; }
        public bool? HasCorpHealthCard { get; set; }
        public bool? HasGovernmentCards { get; set; }
        public bool? HasPESSI { get; set; }
        public bool? HasDisability { get; set; }
        public int? DisabilityTypeID { get; set; }
        public bool? HasDisseas { get; set; }
        public int? DisseasId { get; set; }
        public string HospitalName { get; set; }
        public string HospitalContactNo { get; set; }
        public string HospitalAddress { get; set; }
        public string DoctorName { get; set; }
        public string DoctorContactNo { get; set; }
        public bool? IsActive { get; set; }
    }
}
