using SabSath.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Reflection;
using System.Data.SqlClient;

namespace SabSath.Data.BaseRepository
{
    public class Repository<T> : IRepository<T> where T : class //EntityBase, IAggregateRoot
    {

        private readonly string DBConnection = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=EmployeeDB;Trusted_Connection=True";


        internal IDbConnection Connection
        {
            get
            {
                return new SqlConnection(DBConnection);
            }
        }

        //public Repository(string tableName)
        //{
        //    _tableName = tableName;
        //}

        internal virtual dynamic Mapping(T item)
        {
            return item;
        }


        /// <summary>
        /// Insert row with SQL Stored Procedure
        /// </summary>
        /// <param name="entity">Business Entity</param>
        /// <returns>Identity of newly row created</returns>
        public virtual int Add(T entity)
        {
            using (IDbConnection cn = Connection)
            {
                var parameters = (object)Mapping(entity);
                //cn.Open();
                //item.ID = cn.Insert<int>(_tableName, parameters);

                return cn.Execute(typeof(T).Name + "Insert", parameters, null, null, CommandType.StoredProcedure);
            }
        }




        //public virtual int Add2(T entity)
        //{
        //    using (IDbConnection cn = Connection)
        //    {
        //        var parameters = (object)Mapping(entity);
        //        //cn.Open();
        //        //item.ID = cn.Insert<int>(_tableName, parameters);

        //        return cn.Execute(typeof(T).Name + "Insert", parameters, null, null, CommandType.StoredProcedure);
        //    }
        //}


        /// <summary>
        /// Insert row by auto-generate SQL Query
        /// </summary>
        /// <param name="entity">Business Entity</param>
        /// <returns>Identity of newly row created</returns>
        public virtual int Insert(T entity)
        {
            var insertQuery = GenerateInsertQuery(typeof(T).Name);

            using (IDbConnection cn = Connection)
            {
                return cn.Execute(insertQuery, entity);
            }
        }


        private string GenerateInsertQuery(string _tableName)
        {
            var insertQuery = new StringBuilder($"INSERT INTO {_tableName} ");

            insertQuery.Append("(");

            var properties = GenerateListOfProperties(GetProperties);

            properties.ForEach(prop => { insertQuery.Append($"[{prop}],"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");

            properties.ForEach(prop => { insertQuery.Append($"@{prop},"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(")");

            return insertQuery.ToString();
        }


        /// <summary>
        /// Insert row by auto-generate SQL Query
        /// </summary>
        /// <param name="entity">Business Entity</param>
        /// <returns>Identity of newly row created</returns>
        public virtual int InsertScalar(T entity)
        {
            var insertQuery = GenerateInsertQuery(typeof(T).Name);

            using (IDbConnection cn = Connection)
            {
                return int.Parse(cn.ExecuteScalar(insertQuery + " SELECT @@IDENTITY", entity).ToString());
            }
        }





        /// <summary>
        /// Update row by auto-generate SQL Query
        /// </summary>
        /// <param name="entity">Business Entity</param>
        public void UpdateSQL(T entity)
        {
            //var updateQuery = GenerateUpdateQuery(typeof(T).Name);

            string _tableName = typeof(T).Name;

            var updateQuery = new StringBuilder($"UPDATE {_tableName} SET ");
            var properties = GenerateListOfProperties(GetProperties);




            properties.ForEach(property =>
            {

                Type t = entity.GetType();
                PropertyInfo prop = t.GetProperty(property);
                object list = prop.GetValue(entity);



                if (((!property.Equals("Id")) && (list != null)) && (!(prop.PropertyType.Name == "DateTime" && list.ToString() == "1/1/0001 12:00:00 AM")) && (!property.Equals("CreatedBy")))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
            });




            updateQuery.Remove(updateQuery.Length - 1, 1); //remove last comma
            updateQuery.Append(" WHERE " + _tableName + "ID=@" + _tableName + "ID");







            using (IDbConnection cn = Connection)
            {
                //cn.Execute(updateQuery, entity);
                cn.Execute(updateQuery.ToString(), entity);
            }
        }

        /// <summary>
        /// Update row with SQL Stored Procedure
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            //IEnumerable<T> result;

            //var parameters = (object)Mapping(entity);

            using (IDbConnection cn = Connection)
            {
                cn.Execute(typeof(T).Name + "Update", entity, null, null, CommandType.StoredProcedure);
            }

            //return result;
        }


        private string GenerateUpdateQuery(string _tableName)
        {
            var updateQuery = new StringBuilder($"UPDATE {_tableName} SET ");
            var properties = GenerateListOfProperties(GetProperties);

            properties.ForEach(property =>
            {
                if (!property.Equals("Id"))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
            });

            updateQuery.Remove(updateQuery.Length - 1, 1); //remove last comma
            updateQuery.Append(" WHERE " + _tableName + "ID=@" + _tableName + "ID");

            return updateQuery.ToString();
        }


        private IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();


        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            List<string> properties = (from prop in listOfProperties
                                       let attributes = prop.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false)
                                       where attributes.Length <= 0 || (attributes[0] as System.ComponentModel.DescriptionAttribute)?.Description != "ignore"
                                       select prop.Name).ToList();

            properties.RemoveAt(0); // ********* removing identity column, otherwise we need to add an attribute  [System.ComponentModel.Description("ignore")] in identity column property attribute

            return properties;
        }






        //public virtual void Update(T item)
        //{
        //    using (IDbConnection cn = Connection)
        //    {
        //        var parameters = (object)Mapping(item);
        //        cn.Open();
        //        //cn.Update("", parameters);
        //        cn.Execute("", parameters);
        //    }
        //}



        /// <summary>
        /// Delete row by ID
        /// </summary>
        /// <param name="item"></param>
        public virtual void Remove(T entity)
        {
            using (IDbConnection cn = Connection)
            {

                cn.Execute("DELETE FROM " + typeof(T).Name + " WHERE ID=@ID", new { ID = entity });
            }
        }

        public virtual void Remove(int ID)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Execute("DELETE FROM " + typeof(T).Name + " WHERE " + typeof(T).Name + "ID=@" + "ID", new { ID = ID });
            }
        }

        /// <summary>
        /// Search record by ID with SQL Query
        /// </summary>
        /// <param name="id">ID of row</param>
        /// <returns></returns>
        public virtual T FindByID(int id)
        {
            T item = default(T);

            using (IDbConnection cn = Connection)
            {
                //cn.Open();
                item = cn.Query<T>("SELECT * FROM " + typeof(T).Name + " WHERE " + typeof(T).Name + "ID=@" + "ID", new { ID = id }).SingleOrDefault();
            }

            return item;
        }


        /// <summary>
        /// Find record(s) by SQL Stored Procedure
        /// </summary>
        /// <param name="para">Filter Parameters</param>
        /// <returns></returns>
        public IEnumerable<T> Find(object para)
        {
            IEnumerable<T> result;

            //var parameters = (object)Mapping(entity);

            using (IDbConnection cn = Connection)
            {
                result = cn.Query<T>(typeof(T).Name + "SelectByParam", para, null, true, null, CommandType.StoredProcedure);
            }

            return result;
        }


        /// <summary>
        /// Find record(s) by Auto-Generate SQL Query
        /// </summary>
        /// <param name="filter">Filter string</param>
        /// <param name="parameters">Filter Parameters</param>
        /// <returns></returns>
        public IEnumerable<T> FindByID(string filter, object parameters)
        {
            IEnumerable<T> result;

            ValidateString(filter, nameof(filter));

            using (IDbConnection cn = Connection)
            {
                result = cn.Query<T>("SELECT * FROM " + typeof(T).Name + " WHERE " + filter, parameters);
            }

            return result;
        }

        public static void ValidateString(string str, string nameParameter, string customMessage = null)
        {
            if (string.IsNullOrWhiteSpace(str)) throw new ArgumentNullException(nameParameter, customMessage ?? $"The parameter {nameParameter} it is not null/empty/white");
        }

        /// <summary>
        /// Find all rows by Auto-Generated SQL Query
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> FindAll_SQL()
        {
            IEnumerable<T> items = null;

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                items = cn.Query<T>("SELECT * FROM " + typeof(T).Name);
            }

            return items;
        }


        /// <summary>
        /// Find all rows by Auto-Generated SQL Query
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> FindAll()
        {
            IEnumerable<T> items = null;

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                items = cn.Query<T>(typeof(T).Name + "Select", null, null, true, null, CommandType.StoredProcedure);
            }

            return items;
        }


        /// <summary>
        /// Find all rows by Auto-Generated SQL Query (Async)
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> FindAll_Async()
        {
            //IEnumerable<T> items = null;

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                return await cn.QueryAsync<T>("SELECT * FROM " + typeof(T).Name);
            }

            //return items;
        }


    }
}
