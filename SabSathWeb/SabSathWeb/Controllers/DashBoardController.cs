using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SabSath.Application.Repositiories;
using SabSath.Core.Models;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System;
using Microsoft.AspNetCore.Http;
using MailKit;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text;
using Microsoft.JSInterop;

namespace SabSathWeb.Controllers
{

    [EnableCors("Security")]
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IDashboardService _IdashboardService;
        public IHostingEnvironment hostingEnvironment;
        public DashBoardController(IDashboardService objIDashboardService, IHostingEnvironment hostingenv)
        {
            _IdashboardService = objIDashboardService;
            hostingEnvironment = hostingenv;

        }
        [HttpPost("DashBoard_Card_List")]
        public string DashBoard_Card_List(DashBoard.CardList objData)
        {
            var response = _IdashboardService.DashBoard_Card_List(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("DashBoard_Card_TotalCounts")]
        public string DashBoard_Card_TotalCounts(DashBoard.CardList objData)
        {
            var response = _IdashboardService.DashBoard_Card_TotalCounts(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
    }
}
