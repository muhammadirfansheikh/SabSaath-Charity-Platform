using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabSath.Core.Models
{
    public class PaymentContext
    {
        public class PaymentList
        {
            public int OperationId { get; set; }
            public string CreatedDateFrom { get; set; }
            public string CreatedDateTo { get; set; }
            public int PaymentListStatusId { get; set; }
            public int PaymentListMasterId { get; set; }
            public string Remarks { get; set; }
            public int UserId { get; set; }
            public string UserIP { get; set; }
            public List<PaymentList_UD> ArrayPaymentList { get; set; }
            public string ApplicantCaseCode { get; set; }
            public string ApplicantCNIC { get; set; }
            public int PrimaryFundCategoryId { get; set; }
            public int PaymentType { get; set; }
            public string ReceiverName { get; set; }
            public string ReceiverCNIC { get; set; }
            public string ReceiverContactNumber { get; set; }
            public string UploadReceipt { get; set; }
            public int PaymentStatusId { get; set; }
            public int PaymentListDetailId { get; set; }
            public string ApplicantCode { get; set; }
            public string ApplicantName { get; set; }
            public int? FundSubCategoryId { get; set; }


        }

        public class PaymentList_UD
        {
            public int ApplicantCaseId { get; set; }
            public string PaymentSchedule_Date { get; set; }
            public decimal PayableAmount { get; set; }
            public string Remarks { get; set; }

            public int? FundCategoryId { get; set; }

            public int?  FundSubCategoryId { get; set; }

            public int? PaymentTypeid { get; set; }

            public int? PaymentScheduleId { get; set; }

            public decimal? BalanceAmount { get; set; }

        }

        public class PaymentHistory
        {
            public int ApplicantCase_InvestigationId { get; set; }

        }
    }
}
