using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabSath.Core.Models
{
    public class MasterDetail
    {
        public int OperationId { get; set; }
        public int SetupMasterId { get; set; }
        public int? ParentId { get; set; }
        public string SetupDetailName { get; set; }
        public string Flex1 { get; set; }
        public string Flex2 { get; set; }
        public string Flex3 { get; set; }
        public int SetupDetailId { get; set; }
        public int CreatedBy { get; set; }
        public string UserIP { get; set; }
    }
    public class Category
    {
        public int OperationId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CreatedBy { get; set; }
        public string UserIP { get; set; }
    }
    public class FundCategory
    {
        public int OperationId { get; set; }
        public int FundCategoryId { get; set; }
        public int CategoryId { get; set; }
        public string FundCategoryName { get; set; }
        public int CreatedBy { get; set; }
        public string UserIP { get; set; }
    }
    public class Beneficiary
    {
        public int OperationId { get; set; }
        public int BeneficiaryId { get; set; }
        public string BeneficiaryName { get; set; }
        public int CreatedBy { get; set; }
        public string UserIP { get; set; }
    }
    public class CompanyFamily
    {
        public int OperationId { get; set; }
        public int CompanyFamilyId { get; set; }
        public int CompanyId { get; set; }
        public string FamilyName { get; set; }
        public int CreatedBy { get; set; }
        public string UserIP { get; set; }
    }
    public class CompanyLocation
    {
        public int OperationId { get; set; }
        public int CompanyLocationId { get; set; }
        public int CompanyId { get; set; }
        public string LocationName { get; set; }
        public int CreatedBy { get; set; }
        public string UserIP { get; set; }
    }
    public class Frequency
    {
        public int OperationId { get; set; }
        public int FrequencyId { get; set; }
        public string FrequencyName { get; set; }
        public int CreatedBy { get; set; }
        public string UserIP { get; set; }
    }
    public class PaymentType
    {
        public int OperationId { get; set; }
        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
        public int CreatedBy { get; set; }
        public string UserIP { get; set; }
    }
    public class ComboOperation
    {
        public int OperationId { get; set; }
        public int id { get; set; }
        public int value { get; set; }
    }
    public class MarketingCase
    {
        public int OperationId { get; set; }
        public int caseid { get; set; }
        public string CaseTitle { get; set; }
        public string caseDesc { get; set; }
        public string caseoftheday { get; set; }
        public string Caseshow { get; set; }
        public string DocTypeId { get; set; }
        public string DocAttachmentPath { get; set; }
        public string Userip { get; set; }
        public string CreatedBy { get; set; }
        public string FileName { get; set; }
        public string FileGeneratedName { get; set; }
        public string VideoURL { get; set; }
        public string VideoOrImage { get; set; }
        public string ShortDesc { get; set; }
        public string AttachmentDocID { get; set; }
        public bool Adopt { get; set; }
        public int Source { get; set; }
        public string CauseLabel { get; set; }
    }
    public class PetDetail
    {
        public int OperationID { get; set; }
        public int ID { get; set; }
        public int PetID { get; set; }
        public bool ISActive { get; set; }
        public string UserIP { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public int ApplicantID { get; set; }
        public int petQuantity { get; set; }
    }
    public class AssetDetail
    {
        public int OperationID { get; set; }
        public int ID { get; set; }
        public int AssetTypeID { get; set; }
        public int AssetSubTypeID { get; set; }
        public int AssetStatusID { get; set; }
        public int Quantity { get; set; }
        public int FamilyDetailID { get; set; }
        public string LandLoredName { get; set; }
        public string LandLoredAddress { get; set; }
        public string LandLoredContact { get; set; }
        public string createdDate { get; set; }
        public int createdBy { get; set; }
        public bool ISActive { get; set; }
        public string ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public string Remarks { get; set; }
        public string USERIP { get; set; }
        public List<AssetsDetail1> data2 { get; set; }
    }
    public class AssetDetailsLists
    {
        public List<AssetDetail> data1 { get; set; }
        public List<AssetsDetail1> data2 { get; set; }
    }
    public class AssetsDetail1
    {
        public int AssetTypeID { get; set; }
        public int AssetSubTypeID { get; set; }
        public int AssetStatusID { get; set; }
        public int Quantity { get; set; }
        public int FamilyDetailID { get; set; }
        public string LandLoredName { get; set; }
        public string LandLoredAddress { get; set; }
        public string LandLoredContact { get; set; }
        public string createdDate { get; set; }
        public int createdBy { get; set; }
        public bool ISActive { get; set; }
        public string ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public string Remarks { get; set; }
        public string USERIP { get; set; }
    }
    public class AssetsDetail_2
    {
        public int AssetTypeID { get; set; }
        public int AssetSubTypeID { get; set; }
        public int AssetStatusID { get; set; }
        public int Quantity { get; set; }
        public int FamilyDetailID { get; set; }
        public string LandLoredName { get; set; }
        public string LandLoredAddress { get; set; }
        public string LandLoredContact { get; set; }
        public string createdDate { get; set; }
        public int createdBy { get; set; }
        public bool ISActive { get; set; }
        public string ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public string Remarks { get; set; }
        public string USERIP { get; set; }
    }
    public class SourceOFDrinkingWater
    {
        public int SourceOfDrinkingWater { get; set; }
        public bool HasWashroom { get; set; }
        public string userip { get; set; }
        public string createdate { get; set; }
        public int userid { get; set; }
        public int applicantid { get; set; }
    }
}
