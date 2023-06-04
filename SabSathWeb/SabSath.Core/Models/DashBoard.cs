using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabSath.Core.Models
{
  public  class DashBoard
    {

        public class CardList
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
        }
    }
}
