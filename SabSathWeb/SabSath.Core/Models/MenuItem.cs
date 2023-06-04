using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabSath.Core.Models
{
    public class MenuItem
    {
        public int OperationId { get; set; }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuURL { get; set; }
        public int ParentId { get; set; }
        public bool IsDisplayed { get; set; }
        public int SortOrder { get; set; }
        public string FeatureIds { get; set; }
        public string DeletedFeatureIds { get; set; }
        public string Parenticon { get; set; }
        public int CreatedBy { get; set; }
        public string UserIP { get; set; }
    }

    public class MenuItem_Feature
    {
        public int FeatureId { get; set; }
        public string Feature { get; set; }
        public int MenuId { get; set; }
    }

    public class MenuItem_CheckAccess
    {
        public int RoleId { get; set; }
        public string Menu_URL { get; set; }
    }
    public class MenuItem_FeatureMapping_Get
    {
        public int MenuId { get; set; }
        public int RoleId { get; set; }
        public int FeatureId { get; set; }
        public int MenuItemFeatureId { get; set; }
    }

    public class MenuItem_RoleAccess
    {
        public int RoleId { get; set; }
        public int MenuId { get; set; }
        public bool IsInsert { get; set; }
        public string MenuItemFeatureIds { get; set; }
        public int CreatedBy { get; set; }
        public string UserIP { get; set; }
    }

    public class MenuFeatureMapping
    {
        public int MenuId { get; set; }

        public string Value { get; set; }

        public int FeatureId { get; set; }

        public string Feature { get; set; }
        public string MenuName { get; set; }

        public string Menu_Name { get; set; }

        public string text { get; set; }

        public string id { get; set; }

        public int MenuItemId { get; set; }

        public string parent { get; set; }

        public Boolean Checked { get; set; }

        public int ParentId { get; set; }

        public int CreatedBy { get; set; }

        public int ModifiedBy { get; set; }

        public int MenuItemFeatureId { get; set; }
        public int ApplicationId { get; set; }

        public string Label { get; set; }

        public string MenuURL { get; set; }



        public string SubNode { get; set; }

        public List<MenuFeatureMapping> children { get; set; } = new List<MenuFeatureMapping>();

        public List<MenuFeatureMapping> grandchildren { get; set; } = new List<MenuFeatureMapping>();


    }


    public class MenuItemFeature
    {
        public int FeatureId { get; set; }

        public string Feature { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }


        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }


        public string Id { get; set; }

        public string parent { get; set; }

        public string text { get; set; }

        public Boolean Checked { get; set; }

    }

}
