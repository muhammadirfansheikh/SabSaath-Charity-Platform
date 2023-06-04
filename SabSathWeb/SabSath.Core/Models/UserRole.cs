using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabSath.Core.Models
{
    public class UserRole
    {
        public int OperationId { get; set; }
        public int RoleId { get; set; }
        public int CompanyId { get; set; }
        public string Company { get; set; }
        public string RoleName { get; set; }
        public int CreatedBy { get; set; }
        public string UserIP { get; set; }
        public int LoginRoleId { get; set; }
        public int IsDisplayInSideMenu { get; set; }

        public string [] checkedNodes { get; set; }

        public bool ISActive { get; set; }
    }

    public class SelectedNodes
        {
        public string  checkedNodes { get; set; }
        public int OperationId { get; set; }
    }
}
