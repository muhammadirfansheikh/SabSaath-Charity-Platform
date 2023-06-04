using SabSath.Application.Helper;
using SabSath.Core.Models;
using SabSath.Core.Utilities;
using SabSath.Data.DataRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace SabSath.Application.Repositiories
{
    public interface IPaymentServices
    {
        dynamic Payment_List_Table(PaymentContext.PaymentList obj);

        dynamic Payment_History_Table(PaymentContext.PaymentHistory obj);
    }
    public class PaymentServices : IPaymentServices
    {
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();

        private readonly IPaymentDataDapperRepository _IPaymentDataDapperRepository;
        public PaymentServices(IPaymentDataDapperRepository PaymentDataDapperRepository)
        {
            _IPaymentDataDapperRepository = PaymentDataDapperRepository;
        }
        public dynamic Payment_List_Table(PaymentContext.PaymentList obj)
        {
            try
            {
                List<PaymentContext.PaymentList_UD> objPaymentData = new List<PaymentContext.PaymentList_UD>();
                DataTable PaymentData;
                dynamic PaymentListData;

                if (obj.ArrayPaymentList != null)
                    PaymentListData = obj.ArrayPaymentList.AsEnumerable().ToList();
                else
                    PaymentListData = objPaymentData.AsEnumerable().ToList();


                PaymentData = CommonMethodHelper.ToDataTable(PaymentListData);


                DataSet obj_response = _IPaymentDataDapperRepository.Payment_Table_List(obj, PaymentData);

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
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, e.Message);
            }



        }

        public dynamic Payment_List_Table_Doc(PaymentContext.PaymentList obj, List<IFormFile> FilesData, IHostingEnvironment hostingEnvironment)
        {
            try
            {
                List<DocumentAttachmentContext.CommonTableDocumentAttachment> objDocData = new List<DocumentAttachmentContext.CommonTableDocumentAttachment>();

                if (FilesData.Count > 0 && FilesData != null)
                {
                    objDocData = CommonMethodHelper.UploadDocument(FilesData, hostingEnvironment, "/wwwroot/UploadImages/Applicant_Case_Registration/");

                    if (objDocData.Count > 0)
                    {
                        objDocData[0].DocTypeId = (Int32)EnumHelper.Document_Type.NIC_Front;
                    }
                }

                List<PaymentContext.PaymentList_UD> objPaymentData = new List<PaymentContext.PaymentList_UD>();
                DataTable PaymentData;
                dynamic PaymentListData;

                if (obj.ArrayPaymentList != null)
                    PaymentListData = obj.ArrayPaymentList.AsEnumerable().ToList();
                else
                    PaymentListData = objPaymentData.AsEnumerable().ToList();


                PaymentData = CommonMethodHelper.ToDataTable(PaymentListData);


                DataSet obj_response = _IPaymentDataDapperRepository.Payment_Table_List(obj, PaymentData);

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
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, e.Message);
            }



        }

        public dynamic Payment_History_Table(PaymentContext.PaymentHistory obj)
        {
            try
            {

                DataSet obj_response = _IPaymentDataDapperRepository.PaymentHistory(obj);
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

        //public dynamic usp_RegisteredApplicantCase(ApplicantContext.ApplicantCaseRegistration objApplicantRegistartion, List<IFormFile> FilesData, IHostingEnvironment hostingEnvironment)
        //{
        //    try
        //    {
        //        List<DocumentAttachmentContext.CommonTableDocumentAttachment> objDocData = new List<DocumentAttachmentContext.CommonTableDocumentAttachment>();

        //        DataTable DocumentData;

        //        dynamic DocumentListData;


        //        if (FilesData.Count > 0 && FilesData != null)
        //        {

        //            objDocData = CommonMethodHelper.UploadDocument(FilesData, hostingEnvironment, "/wwwroot/UploadImages/Applicant_Case_Registration/");

        //            if (objDocData.Count > 0)
        //                objDocData[0].DocTypeId = (Int32)EnumHelper.Document_Type.NIC_Front;
        //            if (objDocData.Count > 1)
        //                objDocData[1].DocTypeId = (Int32)EnumHelper.Document_Type.NIC_Back;
        //            if (objDocData.Count > 2)
        //                objDocData[2].DocTypeId = (Int32)EnumHelper.Document_Type.Application;
        //            if (objDocData.Count > 3)
        //                objDocData[3].DocTypeId = (Int32)EnumHelper.Document_Type.Applicant_Photo;
        //            if (objDocData.Count > 4)
        //                objDocData[4].DocTypeId = (Int32)EnumHelper.Document_Type.Thumb_Print;

        //            objDocData = objDocData.Where(x => x.FileName != "NoFile.txt").ToList();

        //            DocumentListData = objDocData;



        //        }
        //        else
        //            DocumentListData = objDocData.AsEnumerable().ToList();



        //        DocumentData = CommonMethodHelper.ToDataTable(DocumentListData);

        //        DataSet obj_response = _IApplicantDataDapperRepository.usp_RegisteredApplicantCase(objApplicantRegistartion, DocumentData);
        //        if (obj_response != null)
        //        {
        //            responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
        //        }
        //        else
        //        {
        //            responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
        //        }
        //        return responseDetail;
        //    }
        //    catch (Exception e)
        //    {
        //        return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, e.Message);
        //    }
        //}
    }
}
