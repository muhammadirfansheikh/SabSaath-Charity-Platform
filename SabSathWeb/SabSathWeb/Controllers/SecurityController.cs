using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SabSath.Application.Repositiories;
using SabSath.Core.Model;
using SabSath.Core.Models;
using SabSath.Core.Utilities;
using System;
using System.Collections.Generic;

namespace SabSathWeb.Controllers
{            
    [EnableCors("Security")]
    [Route("api/[controller]")]
    [ApiController]

    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _SecurityService;
        public SecurityController(ISecurityService SecurityService)
        {
            _SecurityService = SecurityService;
        }

        [HttpPost("UserRole_Operation")]
        public JsonResult UserRole_Operation(UserRole obj)
        {
            var response = _SecurityService.usp_UserRole_Operation(obj);
            return new JsonResult(response);
        }

        [HttpPost("MenuItem_Operation")]
        public JsonResult MenuItem_Operation(MenuItem obj)
        {
            var response = _SecurityService.usp_MenuItem_Operation(obj);
            return new JsonResult(response);

        }

        [HttpPost("MenuItem_Side")]
        public JsonResult MenuItem_Side(UserRole obj)
        {
            var response = _SecurityService.usp_MenuItem_Side(obj);
            return new JsonResult(response);
        }

        [HttpPost("MenuItem_Feature_Get")]
        public JsonResult MenuItem_Feature_Get(MenuItem_Feature obj)
        {
            var response = _SecurityService.usp_MenuItem_Feature_Get(obj);
            return new JsonResult(response);
        }

        [HttpPost("MenuItem_CheckAccess")]
        public JsonResult MenuItem_CheckAccess(MenuItem_CheckAccess obj)
        {
            var response = _SecurityService.usp_MenuItem_CheckAccess(obj);
            return new JsonResult(response);
        }

        [HttpPost("MenuItem_CheckAccess")]
        public JsonResult MenuItem_FeatureMapping_Get(MenuItem_FeatureMapping_Get obj)
        {
            var response = _SecurityService.usp_MenuItem_FeatureMapping_Get(obj);
            return new JsonResult(response);
        }

        [HttpPost("MenuItem_RoleAccess")]
        public JsonResult usp_MenuItem_RoleAccess(MenuItem_RoleAccess obj)
        {
            var response = _SecurityService.usp_MenuItem_RoleAccess(obj);
            return new JsonResult(response);
        }

        [HttpPost("Test_RoleAccess")]
        public JsonResult Test_RoleAccess(MenuItem_RoleAccess obj)
        {
            Dictionary<string, object> objResponse = new Dictionary<string, object>();
            try
            {
                List<ParentMenu> nodes = CommonObjects.GetMenusRolesAccess();
                objResponse.Add("nodes", nodes);
            }
            catch (Exception ex)
            {

                objResponse = CommonObjects.GetRepsonse(false, ResponseCodes.Exception, ResponseMessages.ExceptionMessage);
            }
            return new JsonResult(objResponse);
        }




       
        [HttpPost("GetMenuItemByRoleIdDataDapper")]
        public JsonResult GetMenuItemByRoleIdDataDapper(UserRole obj)
        {
            var response = _SecurityService.GetMenuItemByRoleIdDataDapper(obj);
            return new JsonResult(response);
        }

        [HttpPost("Save_Update_Roles")]
        public JsonResult Save_Update_Roles(UserRole obj)
        {
            var response = _SecurityService.Save_Update_Roles(obj);
            return new JsonResult(response);
        }


        [HttpPost("User_Roles_Get")]
        public JsonResult User_Roles_Get(UserRole obj)
        {
            var response = _SecurityService.User_Roles_Get(obj);
            return new JsonResult(response);
        }

        [HttpPost("CreateRoleMenuItemService")]
        public JsonResult CreateRoleMenuItemService(List<RoleMenuItemFeatureMapping> val)
        {
            var response =  _SecurityService.CreateRoleMenuItemService(val);
           // JObject json = JObject.Parse(response);
           
            return new JsonResult(response);
        }

      
    }
}
