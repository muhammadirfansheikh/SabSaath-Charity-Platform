using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabSath.Core.Models
{
    public class CompanyContext
    {
        public class CompanyOperation
        {
            public int OperationId { get; set; }
            public int CompanyId { get; set; }
            public string CompanyName { get; set; }
            public string UserIP { get; set; }
            public int IsSuperCompany { get; set; }
            public int IsActive  { get; set; }
            public int IsTrusted { get; set; }
            public int CreatedBy { get; set; }
            public int familyid { get; set; }
            public int bankid { get; set; }
            public int userid { get; set; }
            public int POCID { get; set; }
            

        }


    }
}
