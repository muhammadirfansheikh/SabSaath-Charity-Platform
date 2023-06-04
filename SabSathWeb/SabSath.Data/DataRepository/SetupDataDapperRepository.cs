using Dapper;
using SabSath.Core.Models;
using SabSath.Core.Utilities;
using SabSath.Data.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace SabSath.Data.DataRepository
{
    public interface ISetupDataDapperRepository
    {
        Task<IEnumerable<dynamic>> usp_MasterDetail_Operation(MasterDetail obj);

        Task<IEnumerable<dynamic>> MasterDetail_Operation_District(MasterDetail obj);
        
        Task<IEnumerable<dynamic>> usp_Category_Operation(Category obj);
        Task<IEnumerable<dynamic>>  usp_FundCategory_Operation(FundCategory obj);


        Task<IEnumerable<dynamic>> usp_Beneficiary_Operation(Beneficiary obj);
       

        Task<IEnumerable<dynamic>> usp_CompanyFamily_Operation(CompanyFamily obj);

        Task<IEnumerable<dynamic>> usp_CompanyLocation_Operation(CompanyLocation obj);

        Task<IEnumerable<dynamic>> usp_Frequency_Operation(Frequency obj);

        Task<IEnumerable<dynamic>> usp_PaymentType_Operation(PaymentType obj);
        DataSet usp_GetCaseStatusByRoleMap(int UserId, int ApplicantCase_InvestigationId);


    }

    public class SetupDataDapperRepository : ISetupDataDapperRepository
    {
        dynamic objdynamic = null;

        private string connectionString = "";

        private readonly DapperManager dapperManager;

        public SetupDataDapperRepository()
        {

            connectionString = GenericConstants.ConnectionString;
            dapperManager = new DapperManager(connectionString);
        }

        public IDbConnection _Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public async Task<IEnumerable<dynamic>> usp_MasterDetail_Operation(MasterDetail obj)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@OperationId", obj.OperationId);
            queryParameters.Add("@SetupMasterId", obj.SetupMasterId);
            queryParameters.Add("@ParentId", obj.ParentId);
            queryParameters.Add("@SetupDetailName", obj.SetupDetailName);
            queryParameters.Add("@Flex1", obj.Flex1);
            queryParameters.Add("@Flex2", obj.Flex2);
            queryParameters.Add("@Flex3", obj.Flex3);
            queryParameters.Add("@SetupDetailId", obj.SetupDetailId);
            queryParameters.Add("@CreatedBy", obj.CreatedBy);
            queryParameters.Add("@UserIP", obj.UserIP);
            var spName = "usp_MasterDetail_Operation";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }

        public async Task<IEnumerable<dynamic>> MasterDetail_Operation_District(MasterDetail obj)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@OperationId", obj.OperationId);
            queryParameters.Add("@SetupMasterId", obj.SetupMasterId);
            queryParameters.Add("@ParentId", obj.ParentId);
            queryParameters.Add("@SetupDetailName", obj.SetupDetailName);
            queryParameters.Add("@Flex1", obj.Flex1);
            queryParameters.Add("@Flex2", obj.Flex2);
            queryParameters.Add("@Flex3", obj.Flex3);
            queryParameters.Add("@SetupDetailId", obj.SetupDetailId);
            queryParameters.Add("@CreatedBy", obj.CreatedBy);
            queryParameters.Add("@UserIP", obj.UserIP);
            var spName = "sp_MasterDetail_Operation_District";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }

        
        public async Task<IEnumerable<dynamic>> usp_Category_Operation(Category obj)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@OperationId", obj.OperationId);
            queryParameters.Add("@CategoryId", obj.CategoryId);
            queryParameters.Add("@CategoryName", obj.CategoryName);
            queryParameters.Add("@CreatedBy", obj.CreatedBy);
            queryParameters.Add("@UserIP", obj.UserIP);
            var spName = "usp_Category_Operation";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }

        public async Task<IEnumerable<dynamic>> usp_FundCategory_Operation(FundCategory obj)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@OperationId", obj.OperationId);
            queryParameters.Add("@FundCategoryId", obj.FundCategoryId);
            queryParameters.Add("@CategoryId", obj.CategoryId);
            queryParameters.Add("@FundCategoryName", obj.FundCategoryName);
            queryParameters.Add("@CreatedBy", obj.CreatedBy);
            queryParameters.Add("@UserIP", obj.UserIP);
            var spName = "usp_FundCategory_Operation";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }

        public async Task<IEnumerable<dynamic>> usp_Beneficiary_Operation(Beneficiary obj)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@OperationId", obj.OperationId);
            queryParameters.Add("@BeneficiaryId", obj.BeneficiaryId);
            queryParameters.Add("@BeneficiaryName", obj.BeneficiaryName);
            queryParameters.Add("@CreatedBy", obj.CreatedBy);
            queryParameters.Add("@UserIP", obj.UserIP);
            var spName = "usp_Beneficiary_Operation";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }

       

        public async Task<IEnumerable<dynamic>> usp_CompanyFamily_Operation(CompanyFamily obj)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@OperationId", obj.OperationId);
            queryParameters.Add("@CompanyFamilyId", obj.CompanyFamilyId);
            queryParameters.Add("@CompanyId", obj.CompanyId);
            queryParameters.Add("@FamilyName", obj.FamilyName);
            queryParameters.Add("@CreatedBy", obj.CreatedBy);
            queryParameters.Add("@UserIP", obj.UserIP);
            var spName = "usp_CompanyFamily_Operation";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }

        public async Task<IEnumerable<dynamic>> usp_CompanyLocation_Operation(CompanyLocation obj)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@OperationId", obj.OperationId);
            queryParameters.Add("@CompanyLocationId", obj.CompanyLocationId);
            queryParameters.Add("@CompanyId", obj.CompanyId);
            queryParameters.Add("@LocationName", obj.LocationName);
            queryParameters.Add("@CreatedBy", obj.CreatedBy);
            queryParameters.Add("@UserIP", obj.UserIP);
            var spName = "usp_CompanyLocation_Operation";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
       
        public async Task<IEnumerable<dynamic>> usp_Frequency_Operation(Frequency obj)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@OperationId", obj.OperationId);
            queryParameters.Add("@FrequencyId", obj.FrequencyId);
            queryParameters.Add("@FrequencyName", obj.FrequencyName);
            queryParameters.Add("@CreatedBy", obj.CreatedBy);
            queryParameters.Add("@UserIP", obj.UserIP);
            var spName = "usp_Frequency_Operation";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }
        public async Task<IEnumerable<dynamic>> usp_PaymentType_Operation(PaymentType obj)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@OperationId", obj.OperationId);
            queryParameters.Add("@PaymentTypeId", obj.PaymentTypeId);
            queryParameters.Add("@PaymentTypeName", obj.PaymentTypeName);
            queryParameters.Add("@CreatedBy", obj.CreatedBy);
            queryParameters.Add("@UserIP", obj.UserIP);
            var spName = "usp_PaymentType_Operation";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);
        }


        public DataSet usp_GetCaseStatusByRoleMap(int UserId, int ApplicantCase_InvestigationId)
        {

            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = UserId });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = ApplicantCase_InvestigationId });

            var spName = "SP_GetCaseStatusByRoleMap";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }




    }
}







    

