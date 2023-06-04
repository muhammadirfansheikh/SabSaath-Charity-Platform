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

    public interface IDashBoardDataDapperRepository
    {
        DataSet DashBoard_Card_List(DashBoard.CardList objData);
        DataSet DashBoard_Card_TotalCounts(DashBoard.CardList objData);
        
    }

    public class DashBoardDataDapperRepository : IDashBoardDataDapperRepository
    {
        dynamic objdynamic = null;
        private string connectionString = "";
        private readonly DapperManager dapperManager;
        public DashBoardDataDapperRepository()
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


        public DataSet DashBoard_Card_List(DashBoard.CardList objData)
        {

            List<SqlParameter> parm = new List<SqlParameter>();

            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = objData.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@TabName", SqlDbType = SqlDbType.NVarChar, Value = objData.TabName });


            

            var spName = "sp_Dashboard_Modal";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }

        public DataSet DashBoard_Card_TotalCounts(DashBoard.CardList objData)
        {

            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = objData.UserId });

            var spName = "GetDashboardData";
            return dapperManager.GetDataSet(spName, parm.ToArray());
        }
    }
}
