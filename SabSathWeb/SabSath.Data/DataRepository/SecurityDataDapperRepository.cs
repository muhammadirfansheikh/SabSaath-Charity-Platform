using Dapper;
using SabSath.Core.Models;
using SabSath.Core.Utilities;
using SabSath.Data.Manager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabSath.Core.Model;


namespace SabSath.Data.DataRepository
{
    public interface ISecurityDataDapperRepository
    {
        Task<IEnumerable<dynamic>> usp_UserRole_Operation(UserRole obj);

        Task<IEnumerable<dynamic>> usp_MenuItem_Operation(MenuItem obj);

        Task<IEnumerable<dynamic>> usp_MenuItem_Side(UserRole obj);

        Task<IEnumerable<dynamic>> usp_MenuItem_Feature_Get(MenuItem_Feature obj);

        Task<IEnumerable<dynamic>> usp_MenuItem_CheckAccess(MenuItem_CheckAccess obj);

        Task<IEnumerable<dynamic>> usp_MenuItem_FeatureMapping_Get(MenuItem_FeatureMapping_Get obj);

        Task<IEnumerable<dynamic>> usp_MenuItem_RoleAccess(MenuItem_RoleAccess obj);

        Task<IEnumerable<dynamic>> GetMenuItemByRoleIdDataDapper(int roleId);
     

        Task<IEnumerable<dynamic>> User_Roles_Get(UserRole obj);
        Task<IEnumerable<dynamic>> Save_Update_Roles(UserRole obj);
        // Task<IEnumerable<dynamic>> CreateRoleMenuItemDataDapper(List<RoleMenuItemFeatureMapping> model);

        Task<dynamic> CreateRoleMenuItemDataDapper(List<RoleMenuItemFeatureMapping> model);
    }
    public class SecurityDataDapperRepository : ISecurityDataDapperRepository
    {
        dynamic objdynamic = null;
        private string connectionString = "";
        private readonly DapperManager dapperManager;
        public SecurityDataDapperRepository()
        {

            connectionString = GenericConstants.ConnectionString;
            dapperManager = new DapperManager(connectionString);
        }
        public IDbConnection _Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
        public async Task<IEnumerable<dynamic>> usp_UserRole_Operation(UserRole obj)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@OperationId", obj.OperationId);
            queryParameters.Add("@RoleId", obj.RoleId);
            queryParameters.Add("@CompanyId", obj.CompanyId);
            queryParameters.Add("@RoleName", obj.RoleName);
            queryParameters.Add("@CreatedBy", obj.CreatedBy);
            queryParameters.Add("@UserIP", obj.UserIP);
            queryParameters.Add("@LoginRoleId", obj.LoginRoleId);
            var spName = "usp_UserRole_Operation";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public async Task<IEnumerable<dynamic>> usp_MenuItem_Operation(MenuItem obj)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@OperationId", obj.OperationId);
            queryParameters.Add("@MenuId", obj.MenuId);
            queryParameters.Add("@MenuName", obj.MenuName);
            queryParameters.Add("@MenuURL", obj.MenuURL);
            queryParameters.Add("@ParentId", obj.ParentId);
            queryParameters.Add("@IsDisplayed", obj.IsDisplayed);
            queryParameters.Add("@SortOrder", obj.SortOrder);
            queryParameters.Add("@FeatureIds", obj.FeatureIds);
            queryParameters.Add("@DeletedFeatureIds", obj.DeletedFeatureIds);
            queryParameters.Add("@Parenticon", obj.Parenticon);
            queryParameters.Add("@CreatedBy", obj.CreatedBy);
            queryParameters.Add("@UserIP", obj.UserIP);
            var spName = "usp_MenuItem_Operation";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public async Task<IEnumerable<dynamic>> usp_MenuItem_Side(UserRole obj)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@RoleId", obj.RoleId);
            queryParameters.Add("@Is_Displayed_In_Menu", obj.IsDisplayInSideMenu);
            var spName = "usp_MenuItem_Side";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public async Task<IEnumerable<dynamic>> usp_MenuItem_Feature_Get(MenuItem_Feature obj)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@FeatureId", obj.FeatureId);
            queryParameters.Add("@Feature", obj.Feature);
            queryParameters.Add("@MenuId", obj.MenuId);
            var spName = "usp_MenuItem_Feature_Get";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public async Task<IEnumerable<dynamic>> usp_MenuItem_CheckAccess(MenuItem_CheckAccess obj)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@RoleId", obj.RoleId);
            queryParameters.Add("@Menu_URL", obj.Menu_URL);
            var spName = "usp_MenuItem_CheckAccess";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public async Task<IEnumerable<dynamic>> usp_MenuItem_FeatureMapping_Get(MenuItem_FeatureMapping_Get obj)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@MenuId", obj.MenuId);
            queryParameters.Add("@RoleId", obj.RoleId);
            queryParameters.Add("@FeatureId", obj.FeatureId);
            queryParameters.Add("@MenuItemFeatureId", obj.MenuItemFeatureId);
            var spName = "usp_MenuItem_FeatureMapping_Get";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public async Task<IEnumerable<dynamic>> usp_MenuItem_RoleAccess(MenuItem_RoleAccess obj)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@MenuId", obj.MenuId);
            queryParameters.Add("@RoleId", obj.RoleId);
            queryParameters.Add("@MenuItemFeatureIds", obj.MenuItemFeatureIds);
            queryParameters.Add("@IsInsert", obj.IsInsert);
            queryParameters.Add("@CreatedBy", obj.CreatedBy);
            queryParameters.Add("@UserIP", obj.UserIP);
            var spName = "usp_MenuItem_RoleAccess";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public string GenerateRandomNo()
        {
            return "8";
           // return _random.Next(0, 9999).ToString("D4");
        }
        public async Task<IEnumerable<dynamic>> GetMenuItemByRoleIdDataDapper(int roleId)
        {
            List<MenuFeatureMapping> nodes = new List<MenuFeatureMapping>();
            MenuFeatureMapping parent = new MenuFeatureMapping();

            RoleMenuItemFeatureMapping roleMenuItemFeatureMapping = new RoleMenuItemFeatureMapping();
            MenuItemFeature menuItemFeature = new MenuItemFeature();

            var queryParametersParent = new DynamicParameters();
            queryParametersParent.Add("@RoleId", roleId);

            var spNameParentNode = "usp_MenuItem_Get_RoleMenuItemParent ";
            IEnumerable<RoleMenuItemFeatureMapping> modelParent = await dapperManager.QueryList(roleMenuItemFeatureMapping, spNameParentNode, queryParametersParent);

            foreach (RoleMenuItemFeatureMapping type in modelParent)
            {
                //Get Checked menu Item (Parent Node)


                if (type.SubNode == "#")
                {
                    //Get Parent Name from Below Line and Check and UnCheck Node behalf on this
                    var queryParamParent = new DynamicParameters();
                    queryParamParent.Add("@RoleId", roleId);
                    queryParamParent.Add("@MenuItemId", type.MenuId);

                    var spNameParent = "usp_MenuItem_GetRoleMenuItemFeatureMappingExist";
                    RoleMenuItemFeatureMapping ParentNode = new RoleMenuItemFeatureMapping();
                    IEnumerable<RoleMenuItemFeatureMapping> modelParentChecked = await dapperManager.QueryList(ParentNode, spNameParent, queryParamParent);
                    if (modelParentChecked.Any())
                    {
                        parent = new MenuFeatureMapping() { MenuItemId = type.MenuId, Value = type.MenuId.ToString(), ApplicationId = type.ApplicationId, parent = "#", Label = type.Menu_Name, Checked = false };
                    }
                    else
                    {
                        parent = new MenuFeatureMapping() { MenuItemId = type.MenuId, Value = type.MenuId.ToString(), ApplicationId = type.ApplicationId, parent = "#", Label = type.Menu_Name, Checked = false };
                    }

                    //Get Child Node Name from Below Line
                    var queryParametersSubModule = new DynamicParameters();
                    queryParametersSubModule.Add("@ParentId", type.MenuId);

                    var spNameSubChildModule = "usp_MenuItem_Get_RoleMenuItemChildModule ";

                    IEnumerable<MenuFeatureMapping> modelSubModule = await dapperManager.QueryList(parent, spNameSubChildModule, queryParametersSubModule);
                    var i = 0;
                    foreach (MenuFeatureMapping SubModule in modelSubModule)
                    {
                        if (SubModule.MenuId == 4)
                        {

                        }
                        string randomSubModule = GenerateRandomNo();

                        var queryParameters = new DynamicParameters();
                        queryParameters.Add("@RoleId", roleId);
                        queryParameters.Add("@MenuItemId", SubModule.MenuId);

                        var spName = "usp_MenuItem_GetRoleMenuItemFeatureMappingExist";
                        RoleMenuItemFeatureMapping role = new RoleMenuItemFeatureMapping();
                        IEnumerable<RoleMenuItemFeatureMapping> modelSubModuleChecked = await dapperManager.QueryList(role, spName, queryParameters);
                        if (modelSubModuleChecked.Any())
                        {
                            parent.children.Add(new MenuFeatureMapping() { MenuItemId = SubModule.MenuId, Value = SubModule.MenuId + randomSubModule, ParentId = SubModule.ParentId, Label = SubModule.Menu_Name, Checked = true });

                            //Get Grand Child Node Name from Below Line
                            var queryParametersSubChild = new DynamicParameters();
                            queryParametersSubChild.Add("@MenuItemId", SubModule.MenuId);

                            var spNameSubChildNode = "usp_MenuItem_Get_RoleMenuItemSubChild ";
                            IEnumerable<MenuFeatureMapping> modelFeature = await dapperManager.QueryList(parent, spNameSubChildNode, queryParametersSubChild);
                            foreach (MenuFeatureMapping SubModulefeature in modelFeature)
                            {
                                //Query if Record Exist in RoleMenuItemFeatureMapping Table then Mark Checked Else Checked = false
                                string tableNameFeature = "Setup_RoleMenuItemFeatureMapping";
                                string qryFeature = $"RoleId = @RoleId  AND  MenuItemFeatureId = @MenuItemFeatureId and IsActive = 1";
                                object paramFeature = new { RoleId = roleId, MenuItemId = SubModule.MenuId, MenuItemFeatureId = SubModulefeature.MenuItemFeatureId };
                                //object paramSubModule = new { RoleId = roleId, MenuItemId = type.MenuId };
                                RoleMenuItemFeatureMapping modelFeatureChecked = dapperManager.FindByID<RoleMenuItemFeatureMapping>(qryFeature, paramFeature, tableNameFeature).FirstOrDefault();
                                if (modelFeatureChecked != null)
                                {
                                    parent.children[i].children.Add(new MenuFeatureMapping() { FeatureId = SubModulefeature.MenuItemFeatureId, MenuItemId = SubModule.MenuId, Value = randomSubModule + 1, Label = SubModulefeature.Feature, MenuItemFeatureId = SubModulefeature.MenuItemFeatureId, Checked = true,ParentId = SubModulefeature.ParentId });
                                }
                                else
                                {
                                    parent.children[i].children.Add(new MenuFeatureMapping() { FeatureId = SubModulefeature.MenuItemFeatureId, MenuItemId = SubModule.MenuId, Value = randomSubModule + 1, Label = SubModulefeature.Feature, MenuItemFeatureId = SubModulefeature.MenuItemFeatureId, Checked = false, ParentId = SubModulefeature.ParentId });
                                }

                            }
                            nodes.Add(parent);

                        }
                        else
                        {
                            parent.children.Add(new MenuFeatureMapping() { MenuItemId = SubModule.MenuId, ParentId = SubModule.ParentId, Value = SubModule.MenuId + randomSubModule, Label = SubModule.Menu_Name, Checked = false });

                            //Get Grand Child Node Name from Below Line
                            var queryParametersSubChild = new DynamicParameters();
                            queryParametersSubChild.Add("@MenuItemId", SubModule.MenuId);

                            var spNameSubChildNode = "usp_MenuItem_Get_RoleMenuItemSubChild ";
                            IEnumerable<MenuFeatureMapping> modelFeature = await dapperManager.QueryList(parent, spNameSubChildNode, queryParametersSubChild);
                            foreach (MenuFeatureMapping SubModulefeature in modelFeature)
                            {
                                parent.children[i].children.Add(new MenuFeatureMapping() {ParentId= SubModulefeature.ParentId, FeatureId = SubModulefeature.MenuItemFeatureId, MenuItemId = SubModule.MenuId, Value = randomSubModule + 1, Label = SubModulefeature.Feature, MenuItemFeatureId = SubModulefeature.MenuItemFeatureId, Checked = false });
                                // parent.children[i].children.Add(new MenuFeatureMapping() { FeatureId = SubModulefeature.FeatureId, MenuItemId = type.MenuId, Value = randomSubModule + 1, Label = SubModulefeature.Feature, Checked = true });
                            }

                            nodes.Add(parent);
                        }
                        i++;
                    }

                }
                else
                {
                    if (type.SubNode != "###" && type.SubNode != "#")
                    {
                        if (type.MenuId == 2)
                        {

                        }
                        var queryParameters = new DynamicParameters();
                        queryParameters.Add("@RoleId", roleId);
                        queryParameters.Add("@MenuItemId", type.MenuId);

                        var spName = "usp_MenuItem_GetRoleMenuItemFeatureMappingExist";
                        RoleMenuItemFeatureMapping role = new RoleMenuItemFeatureMapping();
                        IEnumerable<RoleMenuItemFeatureMapping> modelParentNodeChecked = await dapperManager.QueryList(role, spName, queryParameters);
                        if (modelParentNodeChecked.Any())
                        {
                            parent = new MenuFeatureMapping() { MenuItemId = type.MenuId, ApplicationId = type.ApplicationId, Value = type.MenuId.ToString(), parent = "#", Label = type.Menu_Name, Checked = true };
                            nodes.Add(parent);
                        }
                        else
                        {
                            parent = new MenuFeatureMapping() { MenuItemId = type.MenuId, ApplicationId = type.ApplicationId, Value = type.MenuId.ToString(), parent = "#", Label = type.Menu_Name, Checked = false };
                            nodes.Add(parent);

                        }


                    }

                }
                // }
                if (type.SubNode != "#" && type.SubNode != "###")

                {
                    //Get Child Node Feature Mapping
                    var queryParametersSubChild = new DynamicParameters();
                    queryParametersSubChild.Add("@MenuItemId", type.MenuId);

                    var spNameSubChildNode = "usp_MenuItem_Get_RoleMenuItemSubChild ";
                    IEnumerable<MenuFeatureMapping> modelSubChild = await dapperManager.QueryList(parent, spNameSubChildNode, queryParametersSubChild);
                    string randomChild = GenerateRandomNo();
                    foreach (MenuFeatureMapping Subfeature in modelSubChild)
                    {
                        string tableNameFeature = "Setup_RoleMenuItemFeatureMapping";
                        string qryFeature = $"RoleId = @RoleId  AND MenuItemFeatureId = @MenuItemFeatureId and IsActive = 1 ";
                        object paramFeature = new { RoleId = roleId, MenuItemId = type.MenuId, MenuItemFeatureId = Subfeature.MenuItemFeatureId };
                        RoleMenuItemFeatureMapping modelFeature = dapperManager.FindByID<RoleMenuItemFeatureMapping>(qryFeature, paramFeature, tableNameFeature).FirstOrDefault();

                        if (modelFeature != null)
                        {
                            parent.children.Add(new MenuFeatureMapping() { FeatureId = Subfeature.MenuItemFeatureId, MenuItemId = type.MenuId, ParentId = Subfeature.ParentId, Value = Subfeature.FeatureId + randomChild, Label = Subfeature.Feature, MenuItemFeatureId = Subfeature.MenuItemFeatureId, Checked = true });
                        }
                        else
                        {
                            parent.children.Add(new MenuFeatureMapping() { FeatureId = Subfeature.MenuItemFeatureId, MenuItemId = type.MenuId,ParentId= Subfeature.ParentId, Value = Subfeature.FeatureId + randomChild, Label = Subfeature.Feature, MenuItemFeatureId = Subfeature.MenuItemFeatureId, Checked = false });
                        }

                    }
                }
            }
            return nodes.Distinct().ToList();
            
        }
        public async Task<IEnumerable<dynamic>> User_Roles_Get(UserRole obj)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Operation", "0");
            var spName = "usp_UserRole_Get";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public async Task<IEnumerable<dynamic>> Save_Update_Roles(UserRole obj)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Operation", "0");
            queryParameters.Add("@RoleID", obj.RoleId);
            queryParameters.Add("@MenueItemFeatureID", 0);
            queryParameters.Add("@ISActive", obj.ISActive);
            queryParameters.Add("@CreatedBy", obj.CreatedBy);
            queryParameters.Add("@UserIP", obj.UserIP);
            var spName = "usp_UserRole_Get";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        
     
        public async Task<dynamic> CreateRoleMenuItemDataDapper(List<RoleMenuItemFeatureMapping> model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;
            dynamic val = null;


            var queryParametersDeActive = new DynamicParameters();
            string spName = "";
            queryParametersDeActive.Add("@RoleId", model[0].RoleId);
            spName = "usp_RoleAccess_RoleMenuItemFeatureMapping_Insert";
            val = dapperManager.QueryList<dynamic>(objdynamic, spName, queryParametersDeActive);

            var queryParameters = new DynamicParameters();
            
           

            
            foreach (var item in model) // Loop through List with foreach
            {

                if (item.Checked)
                {
                    queryParameters.Add("@RoleId", item.RoleId);
                    queryParameters.Add("@MenuId", item.MenuItemId);
                    queryParameters.Add("@MenuItemFeatureId", item.MenuItemFeatureId);
                    queryParameters.Add("@IsInsert", true);
                    queryParameters.Add("@CreatedBy", item.CreatedBy);

                    queryParameters.Add("@UserIP", UserIP);
                    spName = "usp_RoleAccess_RoleMenuItemFeatureMapping_Insert";
                    val = dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
                }
                   
                   
                
                //if (item.Checked)
                //{
                //    if (item.MenuItemFeatureId == 0)
                //    {
                //        queryParameters.Add("@RoleId", item.RoleId);
                //        queryParameters.Add("@MenuItemId", item.MenuItemId);
                //        queryParameters.Add("@CreatedBy", item.CreatedBy);
                //        queryParameters.Add("@ModifiedBy", item.ModifiedBy);
                //        queryParameters.Add("@UserIP", UserIP);
                //        queryParameters.Add("@MenuID", item.MenuItemId);
                //        spName = "usp_MenuItem_CreateMenuAccessParent";
                //        dapperManager.InsertQuery(spName, queryParameters);
                //        val = "Success";
                //    }
                //    else
                //    {
                //        queryParameters.Add("@OperationId", "1");
                //        queryParameters.Add("@RoleId", item.RoleId);
                //        queryParameters.Add("@MenuItemFeatureId", item.MenuItemFeatureId);
                //        queryParameters.Add("@CreatedBy", item.CreatedBy);
                //        queryParameters.Add("@UserIP", UserIP);
                //        queryParameters.Add("@MenuID", item.MenuItemId);
                //        spName = "usp_Save_UserRoles";
                //        dapperManager.InsertQuery(spName, queryParameters);
                //        val = "Success";
                //    }
                //}
                //else if(!item.Checked)
                //{

                //    if (item.MenuItemFeatureId == 0)
                //    {

                //    }
                //    else
                //    {
                //        //Update Role 
                //        queryParameters.Add("@OperationId", "2");
                //        queryParameters.Add("@RoleId", item.RoleId);
                //        queryParameters.Add("@MenuItemFeatureId", item.MenuItemFeatureId);
                //        queryParameters.Add("@CreatedBy", item.CreatedBy);
                //        queryParameters.Add("@UserIP", UserIP);
                //        queryParameters.Add("@MenuID", item.MenuItemId);
                //        spName = "usp_Save_UserRoles";
                //        dapperManager.InsertQuery(spName, queryParameters);
                //        val = "Success";
                //    }
                //}

                
            }
            return val;
           
        }
    }
  }
