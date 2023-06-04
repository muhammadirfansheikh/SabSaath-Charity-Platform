using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabSath.Data.DataRepository;
using SabSath.Core.Models;
using SabSath.Core.Utilities;
using System.Data;

namespace SabSath.Application.Repositiories
{
    public interface ISetupService
    {
        dynamic usp_MasterDetail_Operation(MasterDetail obj);

        dynamic MasterDetail_Operation_District(MasterDetail obj);
        dynamic usp_Category_Operation(Category obj);
        dynamic usp_FundCategory_Operation(FundCategory obj);
        dynamic usp_Beneficiary_Operation(Beneficiary obj);
        
        
        dynamic usp_CompanyLocation_Operation(CompanyLocation obj);
        dynamic usp_CompanyFamily_Operation(CompanyFamily obj);
        dynamic  usp_Frequency_Operation(Frequency obj);
        dynamic usp_PaymentType_Operation(PaymentType obj);
        dynamic usp_GetCaseStatusByRoleMap(int UserId, int ApplicantCase_InvestigationId);





    }

    public class SetupService : ISetupService
    {
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();

        private readonly ISetupDataDapperRepository _ISetupDataDapperRepository;
        public SetupService(ISetupDataDapperRepository SetupDataDapperRepository)
        {
            _ISetupDataDapperRepository = SetupDataDapperRepository;
        }
        public dynamic usp_MasterDetail_Operation(MasterDetail obj)
        {
            try
            {
                dynamic obj_response = _ISetupDataDapperRepository.usp_MasterDetail_Operation(obj);
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
            catch(Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }

        public dynamic MasterDetail_Operation_District(MasterDetail obj)
        {
            try
            {
                dynamic obj_response = _ISetupDataDapperRepository.MasterDetail_Operation_District(obj);
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
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }

        
        public dynamic usp_Category_Operation(Category obj)
        {
            try
            {
                dynamic obj_response = _ISetupDataDapperRepository.usp_Category_Operation(obj);
                if (obj_response != null )
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
        public dynamic usp_FundCategory_Operation(FundCategory obj)
        {
            try
            {
                dynamic obj_response = _ISetupDataDapperRepository.usp_FundCategory_Operation(obj);
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
        public dynamic usp_Beneficiary_Operation(Beneficiary obj)
        {
            try
            {
                dynamic obj_response = _ISetupDataDapperRepository.usp_Beneficiary_Operation(obj);
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
        
        public dynamic usp_CompanyFamily_Operation(CompanyFamily obj)
        {
            try
            {
                dynamic obj_response = _ISetupDataDapperRepository.usp_CompanyFamily_Operation(obj);
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
        public dynamic usp_CompanyLocation_Operation(CompanyLocation obj)
        {
            try
            {
                dynamic obj_response = _ISetupDataDapperRepository.usp_CompanyLocation_Operation(obj);
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
        public dynamic usp_Frequency_Operation(Frequency obj)
        {
            try
            {
                dynamic obj_response = _ISetupDataDapperRepository.usp_Frequency_Operation(obj);
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


        public dynamic usp_GetCaseStatusByRoleMap(int UserId, int ApplicantCase_InvestigationId)
        {
            try
            {

                DataSet obj_response = _ISetupDataDapperRepository.usp_GetCaseStatusByRoleMap(UserId, ApplicantCase_InvestigationId);
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
            catch (Exception e)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
        public dynamic usp_PaymentType_Operation(PaymentType obj)
        {
            try
            {
                dynamic obj_response = _ISetupDataDapperRepository.usp_PaymentType_Operation(obj);
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


    }


}
