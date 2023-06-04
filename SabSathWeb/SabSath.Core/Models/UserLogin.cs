using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabSath.Core.Models
{
    public class UserLogin
    {
        public int? UserId { get; set; }

        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }
        public string OldPassword { get; set; }

        public string LoginId { get; set; }

        public int? RoleId { get; set; }

        public int? CreatedBy { get; set; }

        

        public int? ModifiedBy { get; set; }

        public string UserIP { get; set; }
        
        public int? IsDiplayedMenu { get; set; }

        public int? OperationTypeId { get; set; }

        public int? EmailOrPhone { get; set; }

        public int? PhoneNo { get; set; }

        public string CountryCode { get; set; }



        //        @OperationId AS int=1 ,
        //@UserId AS int =null,
        //@Name AS VARCHAR(MAX)=null,
        //@EmailAddress AS VARCHAR(MAX)=null,
        //@Password AS VARCHAR(MAX)=null,
        //@RoleId AS INT =null,
        //@CreatedBy AS INT=null,
        //@UserIP AS VARCHAR(MAX)=null,
        //@IsActive AS int=1,
        //@isfamilymember AS int=2,
        //@isparentFamily AS int=2,
        //@Is_Displayed_In_Menu AS int=0

    }
}
