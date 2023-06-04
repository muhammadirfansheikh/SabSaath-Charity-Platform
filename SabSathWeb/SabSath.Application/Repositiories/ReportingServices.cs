using SabSath.Core.Models;
using SabSath.Core.Utilities;
using SabSath.Data.DataRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabSath.Application.Repositiories
{
    public interface IReportingService
    {
        //dynamic usp_Primary_Operation(ApplicantInformation objApplicantInformation, ApplicantCaseDetail objApplicantCaseDetail);

        dynamic Usp_Report_Get_Job_List(ReportingContext.Report_Job_List obj);
        dynamic Usp_Report_Get_Applicant_Case_List(ReportingContext.Report_Applicant_Case_List obj);
        dynamic Usp_Report_Get_Payment_List(ReportingContext.Report_Payment_List obj);
        dynamic Usp_Report_Donation_List(ReportingContext.Report_Donation_List obj);
        dynamic Report_Case_Donation_Details(ReportingContext.Report_Case_Donation_Details obj);
        dynamic Usp_Report_Get_Donor_List(ReportingContext.Report_Donord_List obj);
        dynamic Usp_Report_Get_Referral_List(ReportingContext.Report_Referral_List obj);
        dynamic Usp_Report_Get_Company_List(ReportingContext.Report_Company_List obj);
        dynamic Usp_Report_Get_Institute_Wise_List(ReportingContext.Report_Institute_Wise_List obj);
        dynamic Usp_Report_Get_Patient_List(ReportingContext.Report_Patient_List obj);
        dynamic Report_Payment_Reverse_Disburs(ReportingContext.Report_Payment_Reverse_Disburs obj);
        dynamic Report_DonationHistory(ReportingContext.Report_DonationHistory objData );
        dynamic Report_SubscriptionDetail(ReportingContext.Report_Subscription objData);
        dynamic Report_Task_Sechduler(ReportingContext.Report_Task_Sechduler objData);
        dynamic Report_Subscription_List_Detail(ReportingContext.Report_Subscription_List_Detail objData);
        dynamic Report_Subscription_List(ReportingContext.Report_Subscription_List objData);
        dynamic Report_SubscriptionCancel(ReportingContext.Report_SubscriptionCancel objData);
    }
    public class ReportingServices : IReportingService
    {
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        private readonly IReportingDataDapperRepository _IReportingDataDapperRepository;
        public ReportingServices(IReportingDataDapperRepository ReportingDataDapperRepository)
        {
            _IReportingDataDapperRepository = ReportingDataDapperRepository;
        }
        public dynamic Usp_Report_Get_Job_List(ReportingContext.Report_Job_List objData)
        {
            try
            {

                DataSet obj_response = _IReportingDataDapperRepository.Get_Report_Job_List(objData);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic Usp_Report_Get_Applicant_Case_List(ReportingContext.Report_Applicant_Case_List objData)
        {
            try
            {

                DataSet obj_response = _IReportingDataDapperRepository.Get_Report_Applicant_Case_List(objData);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic Usp_Report_Get_Payment_List(ReportingContext.Report_Payment_List objData)
        {
            try
            {

                DataSet obj_response = _IReportingDataDapperRepository.Get_Report_Payment_List(objData);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic Usp_Report_Donation_List(ReportingContext.Report_Donation_List objData)
        {
            try
            {
                DataSet obj_response = _IReportingDataDapperRepository.Get_Report_Donation_List(objData);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic Report_Case_Donation_Details(ReportingContext.Report_Case_Donation_Details objData)
        {
            try
            {
                DataSet obj_response = _IReportingDataDapperRepository.Report_Case_Donation_Details(objData);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        
        public dynamic Usp_Report_Get_Donor_List(ReportingContext.Report_Donord_List objData)
        {
            try
            {

                DataSet obj_response = _IReportingDataDapperRepository.Get_Report_Donor_List(objData);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic Usp_Report_Get_Referral_List(ReportingContext.Report_Referral_List objData)
        {
            try
            {

                DataSet obj_response = _IReportingDataDapperRepository.Get_Report_Referral_List(objData);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic Usp_Report_Get_Company_List(ReportingContext.Report_Company_List objData)
        {
            try
            {

                DataSet obj_response = _IReportingDataDapperRepository.Get_Report_Company_List(objData);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic Usp_Report_Get_Institute_Wise_List(ReportingContext.Report_Institute_Wise_List objData)
        {
            try
            {

                DataSet obj_response = _IReportingDataDapperRepository.Get_Report_Institute_Wise_List(objData);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic Usp_Report_Get_Patient_List(ReportingContext.Report_Patient_List objData)
        {
            try
            {

                DataSet obj_response = _IReportingDataDapperRepository.Get_Report_Patient_List(objData);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic Report_Payment_Reverse_Disburs(ReportingContext.Report_Payment_Reverse_Disburs objData)
        {
            try
            {

                DataSet obj_response = _IReportingDataDapperRepository.Report_Payment_Reverse_Disburs(objData);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic Report_DonationHistory(ReportingContext.Report_DonationHistory objData)
        {
            try
            {

                DataSet obj_response = _IReportingDataDapperRepository.Report_DonationHistory(objData);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic Report_Task_Sechduler(ReportingContext.Report_Task_Sechduler objData)
        {
            try
            {

                DataSet obj_response = _IReportingDataDapperRepository.Report_Task_Sechduler(objData);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic Report_SubscriptionDetail(ReportingContext.Report_Subscription objData)
        {
            try
            {

                DataSet obj_response = _IReportingDataDapperRepository.Report_SubscriptionDetail(objData);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic Report_Subscription_List_Detail(ReportingContext.Report_Subscription_List_Detail objData)
        {
            try
            {

                DataSet obj_response = _IReportingDataDapperRepository.Report_Subscription_List_Detail(objData);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }

        public dynamic Report_Subscription_List(ReportingContext.Report_Subscription_List objData)
        {
            try
            {

                DataSet obj_response = _IReportingDataDapperRepository.Report_Subscription_List(objData);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
        public dynamic Report_SubscriptionCancel(ReportingContext.Report_SubscriptionCancel objData)
        {
            try
            {

                DataSet obj_response = _IReportingDataDapperRepository.Report_SubscriptionCancel(objData);
                if (obj_response != null)
                {
                    if (obj_response.Tables[0].Rows[0][0].ToString() == "0")
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, obj_response.Tables[0].Rows[0][1].ToString(), obj_response);
                    }
                    else
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, obj_response.Tables[0].Rows[0][1].ToString());
                    }
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
    }
}
