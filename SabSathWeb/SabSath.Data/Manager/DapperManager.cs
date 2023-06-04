﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace SabSath.Data.Manager
{
    public interface IDapperService<TEntity> where TEntity : class
    {
        void UpdateSQL(TEntity entity);
    }

    public class DapperManager
    {

        private string connectionString = "";

        public DapperManager(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public IDbConnection _Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }


        #region Internal Operations

        public void InsertQuery(string spName, DynamicParameters queryParameters)
        {
            try
            {
                using (IDbConnection db = _Connection)
                {
                    db.Open();
                    db.Execute(spName, queryParameters, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Error occured during InsertQuery method : {0}", ex.Message), ex);
            }

        }

        public void DeleteRecord(string spName, DynamicParameters queryParameters)
        {
            try
            {
                using (IDbConnection db = _Connection)
                {
                    db.Open();
                    db.Execute(spName, queryParameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error occured during DeleteRecord method : {0}", ex.Message), ex);
            }

        }

        public DataSet GetDataSet(string spName, SqlParameter[] queryParameters)
        {
            try
            {
                DataSet ds = new DataSet();

                using (SqlConnection db = new SqlConnection(connectionString))
                {

                    SqlCommand oaCommand = new SqlCommand();
                    oaCommand.Connection = db;
                    oaCommand.CommandType = CommandType.StoredProcedure;
                    oaCommand.Parameters.AddRange(queryParameters);
                    oaCommand.CommandText = spName;
                    oaCommand.CommandTimeout = 600000;
                    SqlDataAdapter da = new SqlDataAdapter(oaCommand);
                    da.SelectCommand = oaCommand;
                    da.Fill(ds);



                    return ds;

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public DataTable GetQueryResult(string tableName,string filter)
        {

            DataTable dt = new DataTable();


                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(tableName+ filter, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (dt)
                            {
                                sda.Fill(dt);
                                
                            }
                        }
                    }
                }
            

        


            return dt;
        }

        public void DeleteRecordByQuery(string tableName, string deleteId, int Id)
        {
            using (IDbConnection db = _Connection)
            {
                string deleteQuery = "DELETE FROM " + tableName + " WHERE " + deleteId + "=" + Id;
                db.Open();
                db.Execute(deleteQuery);

            }
        }

        public void UpdateRecord(string spName, DynamicParameters queryParameters)
        {
            try
            {
                using (IDbConnection db = _Connection)
                {
                    db.Open();
                    db.Execute(spName, queryParameters, commandType: CommandType.StoredProcedure);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error occured during UpdateRecord method : {0}", ex.Message), ex);
            }

        }

        public async Task<T> QueryFirstOrDefault<T>(T model, string spName, DynamicParameters queryParameters)
        {
            try
            {
                using (IDbConnection db = _Connection)
                {
                    db.Open();
                    return db.Query<T>(spName, queryParameters, commandType: CommandType.StoredProcedure).FirstOrDefault(); ;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error occured during QueryFirstOrDefault method : {0}", ex.Message), ex);
            }

        }

        public async Task<IEnumerable<T>> QueryList<T>(T model, string spName, DynamicParameters queryParameters)
        {
            try
            {

                using (IDbConnection db = _Connection)
                {
                    db.Open();
                    return db.Query<T>(spName, queryParameters, commandType: CommandType.StoredProcedure).ToList();

                }

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error occured during QueryList method : {0}", ex.Message), ex);
            }

        }

        public virtual IEnumerable<T> FindDataByID<T>(int id, string tableName, DynamicParameters queryParameters)
        {
            IEnumerable<T> items = null;
            using (IDbConnection cn = _Connection)
            {
                cn.Open();
                items = cn.Query(tableName, queryParameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                return items;
            }
        }


        public IEnumerable<T> FindByID<T>(string filter, object parameters, string tableName)
        {
            IEnumerable<T> result;

            using (IDbConnection cn = _Connection)
            {
                result = cn.Query<T>("SELECT * FROM " + tableName + " WHERE " + filter, parameters);
            }

            return result;
        }

        public virtual IEnumerable<T> FindAll_SQL<T>(string tableName)
        {
            IEnumerable<T> items = null;

            using (IDbConnection cn = _Connection)
            {
                cn.Open();
                items = cn.Query<T>("SELECT * FROM " + tableName);
            }

            return items;
        }

    }




    #endregion

}
