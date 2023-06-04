using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SabSath.Application.Helper;
using SabSath.Core.Models;
using SabSath.Core.Utilities;
using SabSath.Data.DataRepository;
using System.Data;

namespace SabSath.Application.Repositiories
{
    public interface ICompanyServices
    {
        dynamic usp_Company_Operation(List<Companies> obj);
        dynamic Get_CompanyData(List<Companies> obj);

    }

    public class CompanyServices : ICompanyServices
    {
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        private readonly ICompanyDataDapperRepository _ICompoanyDataDapperRepository;
        public CompanyServices(ICompanyDataDapperRepository CompanyDataDapperRepository)
        {
            _ICompoanyDataDapperRepository = CompanyDataDapperRepository;
        }
        public dynamic usp_Company_Operation(List<Companies> obj)
        {
            try
            {
                List<CompanyBankInformation> objBankInfoList = new List<CompanyBankInformation>();
                List<Companies> objCompnaies = new List<Companies>();
                DataTable CompData;
                DataTable CompBankData;
                dynamic CompListdata;
                dynamic BankListData;

                string UserIp = obj[0].UserIP;

                if (obj[0].CompanyBankInfoList != null)
                    objBankInfoList = obj[0].CompanyBankInfoList;

                if (obj[0].OperationId == 2)
                {
                    CompListdata = obj.AsEnumerable().Select(x => new
                    {
                        CompanyID = x.CompanyID
                        ,
                        Company = x.Company
                        ,
                        IsSuperCompany = x.IsSuperCompanyBool
                        ,
                        IsTrusted = x.IsTrustedBool
                        ,
                        IsActive = x.IsActiveBool
                        ,
                        IsBlock = x.IsBlockBool
                        ,
                        Block_UnblockReason = x.Block_UnblockReason
                        ,
                        ParentId = x.ParentId == 0 ? null : x.ParentId
                        ,
                        Address = x.Address
                        ,
                        PhoneNo = x.PhoneNo
                        ,
                        Ext = x.Ext
                        ,
                        FamilyId = x.FamilyId == 0 ? null : x.FamilyId
                    }).ToList();
                    BankListData = objBankInfoList.AsEnumerable().Select(x => new
                    {
                        ID = x.ID
                        ,
                        BankID = x.BankID == 0 ? null : x.BankID
                        ,
                        BankBranchName = x.BankBranchName
                        ,
                        IBAN = x.IBAN
                        ,
                        AccountNo = x.AccountNo
                        ,
                        IsActive = x.IsActive
                        ,
                        CompanyID = x.CompanyID

                        ,
                        SwiftCode = x.SwiftCode
                        ,
                        AccountTitle = x.AccountTitle
                        ,
                        BranchAddress = x.BranchAddress
                    }).ToList();


                    CompData = CommonMethodHelper.ToDataTable(CompListdata);
                    CompBankData = CommonMethodHelper.ToDataTable(BankListData);
                }
                else
                {
                    CompListdata = objCompnaies.AsEnumerable().Select(x => new
                    {
                        CompanyID = x.CompanyID
                        ,
                        Company = x.Company
                        ,
                        IsSuperCompany = x.IsSuperCompanyBool
                        ,
                        IsTrusted = x.IsTrustedBool
                        ,
                        IsActive = x.IsActiveBool
                        ,
                        IsBlock = x.IsBlockBool
                        ,
                        Block_UnblockReason = x.Block_UnblockReason
                        ,
                        ParentId = x.ParentId == 0 ? null : x.ParentId
                        ,
                        Address = x.Address
                        ,
                        PhoneNo = x.PhoneNo
                        ,
                        Ext = x.Ext
                        ,
                        FamilyId = x.FamilyId == 0 ? null : x.FamilyId
                    }).ToList();
                    BankListData = objBankInfoList.AsEnumerable().Select(x => new
                    {
                        ID = x.ID
                        ,
                        BankID = x.BankID == 0 ? null : x.BankID
                        ,
                        BankBranchName = x.BankBranchName
                        ,
                        IBAN = x.IBAN
                        ,
                        AccountNo = x.AccountNo
                        ,
                        IsActive = x.IsActive
                        ,
                        CompanyID = x.CompanyID
                        ,
                        SwiftCode = x.SwiftCode
                        ,
                        AccountTitle = x.AccountTitle
                        ,
                        BranchAddress = x.BranchAddress
                    }).ToList();

                    CompData = CommonMethodHelper.ToDataTable(CompListdata);
                    CompBankData = CommonMethodHelper.ToDataTable(BankListData);
                }



                dynamic obj_response = _ICompoanyDataDapperRepository.usp_Company_Operation(obj, CompData, CompBankData);
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


        public dynamic Get_CompanyData(List<Companies> obj)
        {
            DataSet ds = new DataSet();
            try
            {

                List<CompanyBankInformation> objBankInfoList = new List<CompanyBankInformation>();
                List<Companies> objCompnaies = new List<Companies>();
                DataTable CompData = new DataTable();
                DataTable CompBankData = new DataTable();
                dynamic CompListdata;
                dynamic BankListData;

                string UserIp = obj[0].UserIP;

                if (obj[0].OperationId == 2)
                {
                    CompListdata = obj.AsEnumerable().Select(x => new
                    {
                        CompanyID = x.CompanyID
                        ,
                        Company = x.Company
                        ,
                        IsSuperCompany = x.IsSuperCompanyBool
                        ,
                        IsTrusted = x.IsTrustedBool
                        ,
                        IsActive = x.IsActiveBool
                        ,
                        IsBlock = x.IsBlockBool
                        ,
                        Block_UnblockReason = x.Block_UnblockReason
                        ,
                        ParentId = x.ParentId == 0 ? null : x.ParentId
                        ,
                        Address = x.Address
                        ,
                        PhoneNo = x.PhoneNo
                        ,
                        Ext = x.Ext
                        ,
                        FamilyId = x.FamilyId == 0 ? null : x.FamilyId
                    }).ToList();
                    BankListData = objBankInfoList.AsEnumerable().Select(x => new
                    {
                        ID = x.ID
                        ,
                        BankID = x.BankID == 0 ? null : x.BankID
                        ,
                        BankBranchName = x.BankBranchName
                        ,
                        IBAN = x.IBAN,
                        AccountNo = x.AccountNo
                        ,
                        IsActive = x.IsActive
                        ,
                        CompanyID = x.CompanyID

                        ,
                        SwiftCode = x.SwiftCode
                        ,
                        AccountTitle = x.AccountTitle
                        ,
                        BranchAddress = x.BranchAddress
                    }).ToList();


                    CompData = CommonMethodHelper.ToDataTable(CompListdata);
                    CompBankData = CommonMethodHelper.ToDataTable(BankListData);
                }
                else
                {
                    CompListdata = objCompnaies.AsEnumerable().Select(x => new
                    {
                        CompanyID = x.CompanyID
                     ,
                        Company = x.Company
                     ,
                        IsSuperCompany = x.IsSuperCompanyBool
                     ,
                        IsTrusted = x.IsTrustedBool
                     ,
                        IsActive = x.IsActiveBool
                     ,
                        IsBlock = x.IsBlockBool
                     ,
                        Block_UnblockReason = x.Block_UnblockReason
                     ,
                        ParentId = x.ParentId == 0 ? null : x.ParentId
                     ,
                        Address = x.Address
                     ,
                        PhoneNo = x.PhoneNo
                     ,
                        Ext = x.Ext
                     ,
                        FamilyId = x.FamilyId == 0 ? null : x.FamilyId
                    }).ToList();
                    BankListData = objBankInfoList.AsEnumerable().Select(x => new
                    {
                        ID = x.ID
                        ,
                        BankID = x.BankID == 0 ? null : x.BankID
                        ,
                        BankBranchName = x.BankBranchName
                        ,
                        IBAN = x.IBAN,
                        AccountNo = x.AccountNo
                        ,
                        IsActive = x.IsActive
                        ,
                        CompanyID = x.CompanyID

                        ,
                        SwiftCode = x.SwiftCode
                        ,
                        AccountTitle = x.AccountTitle
                        ,
                        BranchAddress = x.BranchAddress
                    }).ToList();
                    CompData = CommonMethodHelper.ToDataTable(CompListdata);
                    CompBankData = CommonMethodHelper.ToDataTable(BankListData);
                }




                ds = _ICompoanyDataDapperRepository.Get_CompanyData(obj, CompData, CompBankData);

                List<Companies> lstComp = ds.Tables[0].AsEnumerable().Select(
                                        dataRow => new Companies
                                        {
                                            OperationId = 5,
                                            CompanyID = dataRow.Field<int>("CompanyID"),
                                            ParentId = dataRow.Field<int?>("ParentId") == null ? 0 : dataRow.Field<int>("ParentId"),
                                            FamilyId = dataRow.Field<int?>("FamilyId") == null ? 0 : dataRow.Field<int>("FamilyId"),

                                            Company = dataRow.Field<string>("Company"),
                                            Block_UnblockReason = dataRow.Field<string>("Block_UnblockReason"),
                                            Address = dataRow.Field<string>("Address"),

                                            PhoneNo = dataRow.Field<string>("PhoneNo"),
                                            Ext = dataRow.Field<string>("Ext"),
                                            IsSuperCompanyBool = dataRow.Field<bool>("IsSuperCompany"),
                                            IsTrustedBool = dataRow.Field<bool>("IsTrusted"),

                                            IsBlockBool = dataRow.Field<bool>("IsBlock"),
                                            IsActiveBool = dataRow.Field<bool>("IsActive"),



                                            CreatedBy = 0,
                                            ModifiedBy = 0

                                        }).ToList();



                List<CompanyBankInformation> lstBankInfo = ds.Tables[1].AsEnumerable().Select(
                                         dataRow => new CompanyBankInformation
                                         {
                                             GuidId = "1",
                                             ID = dataRow.Field<int>("ID"),
                                             CompanyID = dataRow.Field<int>("CompanyID"),
                                             BankID = dataRow.Field<int>("BankID"),
                                             IBAN = dataRow.Field<string>("IBAN"),
                                             BankName = dataRow.Field<string>("BankName"),
                                             BankBranchName = dataRow.Field<string>("BankBranchName"),
                                             UserIP = dataRow.Field<string>("UserIP"),
                                             AccountTitle = dataRow.Field<string>("AccountTitle"),
                                             SwiftCode = dataRow.Field<string>("SwiftCode"),
                                             BranchAddress = dataRow.Field<string>("BranchAddress"),
                                             AccountNo = dataRow.Field<string>("AccountNo"),
                                             IsActive = dataRow.Field<bool>("IsActive"),
                                             CreatedBy = 0,
                                             ModifiedBy = 0
                                         }).ToList();


                List<dynamic> lstComp_BankInfo = new List<dynamic>();

                lstComp_BankInfo.Add(lstComp);
                lstComp_BankInfo.Add(lstBankInfo);

                if (obj != null)
                {
                    responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, lstComp_BankInfo);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }

                // return ds;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
            return responseDetail;
            //return ds;
        }

    }
}
