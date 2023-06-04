using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabSath.Core.Models
{
   public class Companies
    {
        public int? OperationId { get; set; }
        public int CompanyID { get; set; }
        public int? BankId { get; set; }
        public int? ParentId { get; set; }
        public int? FamilyId { get; set; }
        
        public string Company { get; set; }
        public string Block_UnblockReason { get; set; }
        public string Address { get; set; }
        
        public string PhoneNo { get; set; }
        public string Ext { get; set; }
        
        public bool IsSuperCompanyBool { get; set; }
        
        public bool IsTrustedBool { get; set; }
        
        public bool IsBlockBool { get; set; }
        
        public bool IsActiveBool { get; set; }
       

        public int CreatedBy { get; set; }
       
        public int ModifiedBy { get; set; }
        public string UserIP { get; set; }

        

        public List<CompanyBankInformation> CompanyBankInfoList { get; set; }
      
    }

    public class CompanyBankInformation
    {
        public string GuidId { get; set; }
        public int ID { get; set; }
        public int? CompanyID { get; set; }
        public int? BankID { get; set; }
        public string IBAN { get; set; }
        public string BankName { get; set; }
        public string SwiftCode { get; set; }
        public string BankBranchName { get; set; }
        public string UserIP { get; set; }
        public string AccountNo { get; set; }
        public string AccountTitle { get; set; }
        public string BranchAddress { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }
}
