using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabSath.Core.Model
{
    public class RoleMenuItemFeatureMapping
    {
        public int RoleMenuItemFeatureMappingId { get; set; }
        public int RoleId { get; set; }

        public int MenuItemId { get; set; }

        public string MenuItemFeatureId { get; set; }

        public Boolean IsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }

        public int MenuId { get; set; }

        public int FeatureId { get; set; }

        public string Feature { get; set; }

        public string SubNode { get; set; }

      //  public string Menu_URL { get; set; }

        public string Companyname { get; set; }

        public int CompanyId { get; set; }

        public int ApplicationId { get; set; }

        public string Menu_Name { get; set; }

        public int ParentId { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public Boolean Checked { get; set; }

        // public IList<MenuFeatureMapping> menuItemFeature { get; set; }

      


    }

    public class TreeViewNode
    {
        public string id { get; set; }
        public string parent { get; set; }
        public string text { get; set; }

        public string FeatureId { get; set; }

        public List<TreeViewNode> itemsChild { get; set; }

        public TreeViewNode()
        {
            itemsChild = new List<TreeViewNode>();
        }
    }
}
