using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabSath.Application.Helper
{
    public class EnumHelper
    {
        public enum Document_Type
        {
            Applicant = 1,
            Marketing = 2,
            BankSlip = 3,

            NIC_Front = 710,
            NIC_Back = 711,
            Thumb_Print = 712,
            Applicant_Photo = 713,
            Application = 714,

            //Add on Master id 3 DocumentSubTypes
            //Master Detail 
            MarketingCase = 674,//1,
            PaymentSlip = 677,//3,
            SuccessStory = 675,//4,
            BankLogo = 676,//5,
            VideoandURL = 678,
            CashBook_Receipt = 715,
            BankDeposit_Receipt = 716,
            DonationReceipt = 1510,
            FamilyMemberPicture = 717,
        }
    }
}
