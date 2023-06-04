using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SabSath.Application.Repositiories;
using SabSath.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SabSathWeb.Controllers
{
    [EnableCors("Security")]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentServices _IPaymentService;
        public IHostingEnvironment hostingEnvironment;
        public PaymentController(IPaymentServices objIPaymentService, IHostingEnvironment hostingenv)
        {
            _IPaymentService = objIPaymentService;
            hostingEnvironment = hostingenv;
        }



        [HttpPost("Payment_List_Table")]
        public string Payment_List_Table(PaymentContext.PaymentList objData)
        {
           
            var response = _IPaymentService.Payment_List_Table(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;


        }

        [HttpPost("Payment_History_Table")]
        public string Payment_History_Table(PaymentContext.PaymentHistory objData)
        {
            var response = _IPaymentService.Payment_History_Table(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;


        }
    }
}
