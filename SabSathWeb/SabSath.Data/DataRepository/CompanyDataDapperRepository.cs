using Dapper;
using SabSath.Core.Models;
using SabSath.Core.Utilities;
using SabSath.Data.Manager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabSath.Data.DataRepository
{
    public interface ICompanyDataDapperRepository
    {

        Task<IEnumerable<dynamic>> usp_Company_Operation(List<Companies> obj, DataTable CompData, DataTable CompBankData);
        DataSet Get_CompanyData(List<Companies> obj, DataTable CompData, DataTable CompBankData);

    }

    public class CompanyDataDapperRepository : ICompanyDataDapperRepository
    {
        dynamic objdynamic = null;

        private string connectionString = "";

        private readonly DapperManager dapperManager;


        public CompanyDataDapperRepository()
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
        public async Task<IEnumerable<dynamic>> usp_Company_Operation(List<Companies> obj, DataTable CompData, DataTable CompBankData)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@OperationId", obj[0].OperationId);
            queryParameters.Add("@CompanyId", obj[0].CompanyID);
            queryParameters.Add("@bankid", obj[0].BankId);
            queryParameters.Add("@CompanyName", obj[0].Company);

            queryParameters.Add("@familyid", obj[0].FamilyId);

            queryParameters.Add("@Com_Tab", CompData.AsTableValuedParameter("[CompanyTab]"));
            queryParameters.Add("@Com_Bank", CompBankData.AsTableValuedParameter("[CompanyBankTab]"));

            queryParameters.Add("@userid", obj[0].CreatedBy);
            queryParameters.Add("@UserIP", obj[0].UserIP);
            var spName = "SP_Company_Operation";
            return await dapperManager.QueryList<dynamic>(objdynamic, spName, queryParameters);

        }


        public DataSet Get_CompanyData(List<Companies> obj, DataTable CompData, DataTable CompBankData)
        {
            DataSet ds = new DataSet();

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@OperationId", SqlDbType.Int) {Value = obj[0].OperationId},
                new SqlParameter("@CompanyId", SqlDbType.Int) {Value = obj[0].CompanyID},
                new SqlParameter("@bankid", SqlDbType.Int) {Value = obj[0].BankId},
                new SqlParameter("@CompanyName", SqlDbType.NVarChar) {Value = obj[0].Company},

            new SqlParameter("@familyid", SqlDbType.Int) {Value = obj[0].FamilyId},


                new SqlParameter("@Com_Tab",  SqlDbType.Structured) {Value = CompData},
                new SqlParameter("@Com_Bank", SqlDbType.Structured) {Value = CompBankData}
            };

            var spName = "SP_Company_Operation";
            ds = dapperManager.GetDataSet(spName, parm.ToArray());
            return ds;
        }
    }
}
