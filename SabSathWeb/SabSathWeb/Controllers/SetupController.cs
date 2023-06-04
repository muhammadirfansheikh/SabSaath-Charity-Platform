using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SabSath.Application.Repositiories;
using SabSath.Core.Models;


namespace SabSathWeb.Controllers
{
    [EnableCors("Security")]
    [Route("api/[controller]")]
    [ApiController]
    public class SetupController : ControllerBase
    {
        private readonly ISetupService _SetupService;
        public SetupController(ISetupService SetupService)
        {
            _SetupService = SetupService;
        }

        [HttpPost("MasterDetail_Operation")]
        public JsonResult MasterDetail_Operation(MasterDetail obj)
        {
            if (obj == null)
            {
                return null;
            }
            var response = _SetupService.usp_MasterDetail_Operation(obj);
            return new JsonResult(response);
        }

        [HttpPost("MasterDetail_Operation_District")]
        public JsonResult MasterDetail_Operation_District(MasterDetail obj)
        {
            if (obj == null)
            {
                return null;
            }
            var response = _SetupService.MasterDetail_Operation_District(obj);
            return new JsonResult(response);
        }



        [HttpPost("Category_Operation")]
        public JsonResult Category_Operation(Category obj)
        {
            if (obj == null)
            {
                return null;
            }
            var response = _SetupService.usp_Category_Operation(obj);
            return new JsonResult(response);
        }

        [HttpPost("FundCategory_Operation")]
        public JsonResult FundCategory_Operation(FundCategory obj)
        {
            if (obj == null)
            {
                return null;
            }
            var response = _SetupService.usp_FundCategory_Operation(obj);
            return new JsonResult(response);
        }

        [HttpPost("Beneficiary_Operation")]
        public JsonResult Beneficiary_Operation(Beneficiary obj)
        {
            if (obj == null)
            {
                return null;
            }
            var response = _SetupService.usp_Beneficiary_Operation(obj);
            return new JsonResult(response);
        }



        [HttpPost("CompanyFamily_Operation")]
        public JsonResult CompanyFamily_Operation(CompanyFamily obj)
        {
            if (obj == null)
            {
                return null;
            }
            var response = _SetupService.usp_CompanyFamily_Operation(obj);
            return new JsonResult(response);
        }

        [HttpPost("CompanyLocation_Operation")]
        public JsonResult CompanyLocation_Operation(CompanyLocation obj)
        {
            if (obj == null)
            {
                return null;
            }
            var response = _SetupService.usp_CompanyLocation_Operation(obj);
            return new JsonResult(response);
        }

        [HttpPost("Frequency_Operation")]
        public JsonResult Frequency_Operation(Frequency obj)
        {
            if (obj == null)
            {
                return null;
            }
            var response = _SetupService.usp_Frequency_Operation(obj);
            return new JsonResult(response);
        }

        [HttpPost("PaymentType_Operation")]
        public JsonResult PaymentType_Operation(PaymentType obj)
        {
            if (obj == null)
            {
                return null;
            }
            var response = _SetupService.usp_PaymentType_Operation(obj);
            return new JsonResult(response);
        }


        [HttpPost("Get_Case_Status_By_Role_Map")]
        //public string Get_Case_Status_By_Role_Map(int RoleId)
        public string Get_Case_Status_By_Role_Map(int UserId, int ApplicantCase_InvestigationId)
        {

            var response = _SetupService.usp_GetCaseStatusByRoleMap(UserId, ApplicantCase_InvestigationId);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
    }
}
