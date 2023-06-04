using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SabSath.Application.Repositiories;
using SabSath.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SabSathWeb.Controllers
{
    [EnableCors("Security")]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyServices _CompanyService;

        public CompanyController(ICompanyServices CompanyService)
        {
            _CompanyService = CompanyService;
        }


        [HttpPost("Company_Operation")]
        public JsonResult Company_Operation(List<Companies> lstCopmany)
        {
            try
            {
                if (lstCopmany.Count <= 0 && lstCopmany == null)
                {
                    return null;
                }


                var response = _CompanyService.usp_Company_Operation(lstCopmany);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {

                throw;
                return new JsonResult("");
            }

            }


        [HttpPost("Get_CompanyData")]
        public JsonResult Get_CompanyData(List<Companies> lstCopmany)
        {

            try
            {
                if (lstCopmany.Count <= 0 && lstCopmany == null)
                {
                    return null;
                }


                var response  = _CompanyService.Get_CompanyData(lstCopmany);

                //List<Companies> lstEmployee = ds.Tables[0].AsEnumerable().Select(
                //                            dataRow => new Companies
                //                            {

                //                                Company = dataRow.Field<string>("Company")
                //                            }).ToList();


                //List<CompanyBankInformation> lstBankInfo = ds.Tables[1].AsEnumerable().Select(
                //                           dataRow => new CompanyBankInformation
                //                           {
                //                               GuidId = "1",
                //                               ID  = dataRow.Field<int>("ID"),
                //                               CompanyID = dataRow.Field<int>("CompanyID"),
                //                               BankID = dataRow.Field<int>("BankID"),
                //                               IBAN = dataRow.Field<string>("IBAN"),
                //                               BankName = dataRow.Field<string>("BankName"),
                //                               BankBranchName = dataRow.Field<string>("BankBranchName"),
                //                               UserIP = dataRow.Field<string>("UserIP"),
                //                               AccountNo = dataRow.Field<string>("AccountNo"),
                //                               IsActive = dataRow.Field<bool>("IsActive"),
                //                               CreatedBy = 0,
                //                               ModifiedBy = 0
                                               
                                               

                //                           }).ToList();

                //var data = lstBankInfo;
                //  return new JsonResult(new { listEmployee = lstEmployee, listBankInfo = lstBankInfo });
                return new JsonResult(response);
                //return null;
              //  return Ok(lstBankInfo);
            }
            catch (Exception ex)
            {
               // throw;
                return new JsonResult("");
            }
        }

       
    }

}
