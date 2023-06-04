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
    public interface IPaymentDataDapperRepository
    {

        DataSet Payment_Table_List(PaymentContext.PaymentList obj, DataTable DtPaymentListTable);

        DataSet PaymentHistory(PaymentContext.PaymentHistory objData);

    }
    public class PaymentDataDapperRepository : IPaymentDataDapperRepository
    {
        dynamic objdynamic = null;

        private string connectionString = "";

        private readonly DapperManager dapperManager;

        public PaymentDataDapperRepository()
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


        public DataSet Payment_Table_List(PaymentContext.PaymentList objData, DataTable DtPaymentTable)
        {
            DateTime? DateNull = null;
            //DateTime? DateNull = Convert.ToDateTime( "2022-01-01");
            List<SqlParameter> parm = new List<SqlParameter>();

            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = objData.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@CreatedDateFrom", SqlDbType = SqlDbType.Date, Value = (objData.CreatedDateFrom == null || objData.CreatedDateFrom == "") ? DateNull : Convert.ToDateTime(objData.CreatedDateFrom) });
            parm.Add(new SqlParameter() { ParameterName = "@CreatedDateTo", SqlDbType = SqlDbType.Date, Value = (objData.CreatedDateTo == null || objData.CreatedDateTo == "") ? DateNull : Convert.ToDateTime(objData.CreatedDateTo) });
            parm.Add(new SqlParameter() { ParameterName = "@PaymentListStatusId", SqlDbType = SqlDbType.Int, Value = objData.PaymentListStatusId });
            parm.Add(new SqlParameter() { ParameterName = "@PaymentListMasterId", SqlDbType = SqlDbType.Int, Value = objData.PaymentListMasterId });
            parm.Add(new SqlParameter() { ParameterName = "@Remarks", SqlDbType = SqlDbType.NVarChar, Value = objData.Remarks });
            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = objData.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = objData.UserIP });
            parm.Add(new SqlParameter() { ParameterName = "@Tbl_Type_PaymentListDetail", SqlDbType = SqlDbType.Structured, Value = DtPaymentTable });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCaseCode", SqlDbType = SqlDbType.NVarChar, Value = objData.ApplicantCaseCode });
            parm.Add(new SqlParameter() { ParameterName = "@Cnic", SqlDbType = SqlDbType.NVarChar, Value = objData.ApplicantCNIC });
            parm.Add(new SqlParameter() { ParameterName = "@FundCategoryId", SqlDbType = SqlDbType.Int, Value = objData.PrimaryFundCategoryId });
            parm.Add(new SqlParameter() { ParameterName = "@PaymentTypeId", SqlDbType = SqlDbType.Int, Value = objData.PaymentType });
            parm.Add(new SqlParameter() { ParameterName = "@ReceiverName", SqlDbType = SqlDbType.NVarChar, Value = objData.ReceiverName });
            parm.Add(new SqlParameter() { ParameterName = "@ReceiverCNIC", SqlDbType = SqlDbType.NVarChar, Value = objData.ReceiverCNIC });
            parm.Add(new SqlParameter() { ParameterName = "@ReceiverContactNumber", SqlDbType = SqlDbType.NVarChar, Value = objData.ReceiverContactNumber });
            parm.Add(new SqlParameter() { ParameterName = "@UploadReceipt", SqlDbType = SqlDbType.NVarChar, Value = objData.UploadReceipt });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCode", SqlDbType = SqlDbType.NVarChar, Value = objData.ApplicantCode });
            parm.Add(new SqlParameter() { ParameterName = "@ApplicantName", SqlDbType = SqlDbType.NVarChar, Value = objData.ApplicantName});
            parm.Add(new SqlParameter() { ParameterName = "@PaymentStatusId", SqlDbType = SqlDbType.NVarChar, Value = objData.PaymentStatusId });
            parm.Add(new SqlParameter() { ParameterName = "@PaymentListDetailId", SqlDbType = SqlDbType.NVarChar, Value = objData.PaymentListDetailId });
            parm.Add(new SqlParameter() { ParameterName = "@FundSubCategoryId", SqlDbType = SqlDbType.Int, Value = objData.FundSubCategoryId });
            
            var spName = "SP_Tbl_PaymentList";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }

        public DataSet PaymentHistory(PaymentContext.PaymentHistory objData)
        {
            List<SqlParameter> parm = new List<SqlParameter>();

            parm.Add(new SqlParameter() { ParameterName = "@ApplicantCase_InvestigationId", SqlDbType = SqlDbType.Int, Value = objData.ApplicantCase_InvestigationId });
         
            var spName = "SP_Payment_History_Schudule";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
    }
}
