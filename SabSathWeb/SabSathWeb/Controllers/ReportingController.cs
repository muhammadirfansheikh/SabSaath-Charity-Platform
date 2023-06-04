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
    public class ReportingController : ControllerBase
    {
        private readonly IReportingService _IReportingService;
        public IHostingEnvironment hostingEnvironment;
        public ReportingController(IReportingService objIApplicantService, IHostingEnvironment hostingenv)
        {
            _IReportingService = objIApplicantService;
            hostingEnvironment = hostingenv;
        }
        [HttpPost("Report_Job_List")]
        public string Report_Job_List(ReportingContext.Report_Job_List objData)
        {
            var response = _IReportingService.Usp_Report_Get_Job_List(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }


        [HttpPost("Report_Applicant_Case_List")]
        public string Report_Applicant_Case_List(ReportingContext.Report_Applicant_Case_List objData)
        {
            var response = _IReportingService.Usp_Report_Get_Applicant_Case_List(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }


        [HttpPost("Report_Payment_List")]
        public string Report_Payment_List(ReportingContext.Report_Payment_List objData)
        {
            var response = _IReportingService.Usp_Report_Get_Payment_List(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("Report_Donation_List")]
        public string Report_Donation_List(ReportingContext.Report_Donation_List objData)
        {
            var response = _IReportingService.Usp_Report_Donation_List(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("Report_Case_Donation_Details")]
        public string Report_Case_Donation_Details(ReportingContext.Report_Case_Donation_Details objData)
        {
            var response = _IReportingService.Report_Case_Donation_Details(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("Report_Donor_List")]
        public string Report_Donor_List(ReportingContext.Report_Donord_List objData)
        {
            var response = _IReportingService.Usp_Report_Get_Donor_List(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }


        [HttpPost("Report_Referral_List")]
        public string Report_Referral_List(ReportingContext.Report_Referral_List objData)
        {
            var response = _IReportingService.Usp_Report_Get_Referral_List(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("Report_Company_List")]
        public string Report_Company_List(ReportingContext.Report_Company_List objData)
        {
            var response = _IReportingService.Usp_Report_Get_Company_List(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }


        [HttpPost("Report_Institute_Wise_List")]
        public string Report_Institute_Wise_List(ReportingContext.Report_Institute_Wise_List objData)
        {
            var response = _IReportingService.Usp_Report_Get_Institute_Wise_List(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("Report_Patient_List")]
        public string Report_Patient_List(ReportingContext.Report_Patient_List objData)
        {
            var response = _IReportingService.Usp_Report_Get_Patient_List(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("Report_Payment_Reverse_Disburs")]
        public string Report_Payment_Reverse_Disburs(ReportingContext.Report_Payment_Reverse_Disburs objData)
        {
            var response = _IReportingService.Report_Payment_Reverse_Disburs(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }


        [HttpPost("Report_DonationHistory")]
        public string Report_DonationHistory(ReportingContext.Report_DonationHistory objData)
        {
            var response = _IReportingService.Report_DonationHistory(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("Report_Task_Sechduler")]
        public string Report_Task_Sechduler(ReportingContext.Report_Task_Sechduler objData)
        {
            var response = _IReportingService.Report_Task_Sechduler(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("Report_SubscriptionDetail")]
        public string Report_SubscriptionDetail(ReportingContext.Report_Subscription objData)
        {
            var response = _IReportingService.Report_SubscriptionDetail(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("Report_Subscription_List_Detail")]
        public string Report_Subscription_List_Detail(ReportingContext.Report_Subscription_List_Detail objData)
        {
            var response = _IReportingService.Report_Subscription_List_Detail(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("Report_Subscription_List")]
        public string Report_Subscription_List(ReportingContext.Report_Subscription_List objData)
        {
            var response = _IReportingService.Report_Subscription_List(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        [HttpPost("Report_SubscriptionCancel")]
        public string Report_SubscriptionCancel(ReportingContext.Report_SubscriptionCancel objData)
        {
            var response = _IReportingService.Report_SubscriptionCancel(objData);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
    }
}
