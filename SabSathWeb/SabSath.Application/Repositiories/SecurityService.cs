using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabSath.Data.DataRepository;
using SabSath.Core.Models;
using SabSath.Core.Utilities;
using SabSath.Core.Model;

namespace SabSath.Application.Repositiories
{

    public interface ISecurityService
    {
        dynamic usp_UserRole_Operation(UserRole obj);
        dynamic usp_MenuItem_Operation(MenuItem obj);
        dynamic usp_MenuItem_Side(UserRole obj);
        dynamic usp_MenuItem_Feature_Get(MenuItem_Feature obj);
        dynamic usp_MenuItem_CheckAccess(MenuItem_CheckAccess obj);
        dynamic usp_MenuItem_FeatureMapping_Get(MenuItem_FeatureMapping_Get obj);
        dynamic usp_MenuItem_RoleAccess(MenuItem_RoleAccess obj);

        dynamic GetMenuItemByRoleIdDataDapper(UserRole obj);

        dynamic User_Roles_Get(UserRole obj);

        dynamic Save_Update_Roles(UserRole obj);

        dynamic  CreateRoleMenuItemService(List<RoleMenuItemFeatureMapping> model);


    }

    public class SecurityService : ISecurityService
    {
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        MessageDate_M<dynamic> responseDetailM = new MessageDate_M<dynamic>();

        private readonly ISecurityDataDapperRepository _SecurityDataDapperRepository;
        public SecurityService(ISecurityDataDapperRepository SecurityDataDapperRepository)
        {
            _SecurityDataDapperRepository = SecurityDataDapperRepository;
        }
        public dynamic usp_UserRole_Operation(UserRole obj)
        {
            try
            {
                dynamic obj_response = _SecurityDataDapperRepository.usp_UserRole_Operation(obj);
                if (obj != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic usp_MenuItem_Operation(MenuItem obj)
        {
            try
            {
                dynamic obj_response = _SecurityDataDapperRepository.usp_MenuItem_Operation(obj);
                if (obj != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic usp_MenuItem_Side(UserRole obj)
        {
            try
            {
                dynamic obj_response = _SecurityDataDapperRepository.usp_MenuItem_Side(obj);
                if (obj != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic usp_MenuItem_Feature_Get(MenuItem_Feature obj)
        {
            try
            {
                dynamic obj_response = _SecurityDataDapperRepository.usp_MenuItem_Feature_Get(obj);
                if (obj != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic usp_MenuItem_CheckAccess(MenuItem_CheckAccess obj)
        {
            try
            {
                dynamic obj_response = _SecurityDataDapperRepository.usp_MenuItem_CheckAccess(obj);
                if (obj != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic usp_MenuItem_FeatureMapping_Get(MenuItem_FeatureMapping_Get obj)
        {
            try
            {
                dynamic obj_response = _SecurityDataDapperRepository.usp_MenuItem_FeatureMapping_Get(obj);
                if (obj != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic usp_MenuItem_RoleAccess(MenuItem_RoleAccess obj)
        {
            try
            {
                dynamic obj_response = _SecurityDataDapperRepository.usp_MenuItem_RoleAccess(obj);
                if (obj != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }



        public dynamic GetMenuItemByRoleIdDataDapper(UserRole obj)
        {
            try
            {
                dynamic obj_response = _SecurityDataDapperRepository.GetMenuItemByRoleIdDataDapper(obj.RoleId);
                if (obj != null)
                {
                    responseDetailM = CommonObjects.GetRepsonses_M(obj_response.Result);
                  
                }
                else
                {
                   // responseDetail = CommonObjects.GetRepsonses_M(ResponseMessages.Failure);
                }
                return responseDetailM;
               
            }
            catch (Exception ex)
            {
              //  return responseDetail = CommonObjects.GetRepsonses_M(ResponseMessages.Exception);
            }
            return responseDetailM;
        }


        public dynamic User_Roles_Get(UserRole obj)
        {
            try
            {
                dynamic obj_response = _SecurityDataDapperRepository.User_Roles_Get(obj);
                if (obj != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }   
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }



        public dynamic Save_Update_Roles(UserRole obj)
        {
            try
            {
                dynamic obj_response = _SecurityDataDapperRepository.Save_Update_Roles(obj);
                if (obj != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }

        public dynamic CreateRoleMenuItemService(List<RoleMenuItemFeatureMapping> model)
        {
           
            try
            {
                dynamic obj_response = _SecurityDataDapperRepository.CreateRoleMenuItemDataDapper(model);


                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, obj_response.Result);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);//CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
            
        }

    }
}
