
using Dapper;
using fincheckup.Models.NKolay;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace fincheckup.Models
{
    public class BaseModel : IDisposable, INotifyPropertyChanged
    {

        public BaseModel()
        {
            Connection = new SqlConnection(Database.ConnectionString);
        }

        private IDbConnection _connection;
        private IDbTransaction _transaction;

        internal IDbConnection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        public IDbTransaction Transaction
        {
            get { return _transaction; }
            set
            {
                _transaction = value;
                if (_transaction != null)
                    _connection = _transaction.Connection;
            }
        }

        public IDbTransaction BeginTransaction()
        {
            _transaction = _connection.BeginTransaction();
            return _transaction;
        }

        public IDbTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            _transaction = _connection.BeginTransaction(isolationLevel);
            return _transaction;
        }


        internal int Execute(string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            OpenConnection();
            try
            {
                return SqlMapper.Execute(_connection, sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = 0;
                lg.CsvID = 0;
                lg.ERLOG = sql + "  ------- param: " + param + "---------" + ex.ToString();
                lg.Save_AppLogs();
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }



        internal IEnumerable<T> Query<T>(string sql, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            OpenConnection();
            try
            {
                return SqlMapper.Query<T>(_connection, sql, param, transaction, buffered, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = 0;
                lg.CsvID = 0;
                lg.ERLOG = sql + "  ------- param: " + param + "---------" + ex.ToString();
                lg.Save_AppLogs();
                throw;
            }
            finally
            {
                if (buffered)
                    CloseConnection();
            }
        }

        internal static IEnumerable<T> StaticQuery<T>(string sql, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {

            using (IDbConnection con = Database.GetConnection())
            {
                try
                {
                    if (con != null && con.State != ConnectionState.Open)
                        con.Open();

                    return SqlMapper.Query<T>(con, sql, param, transaction, buffered, commandTimeout, commandType);

                }
                catch (Exception ex)
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = 0;
                    lg.CsvID = 0;
                    lg.ERLOG = sql + "  ------- param: " + param + "---------" + ex.ToString();
                    lg.Save_AppLogs();
                    throw;
                }
                finally
                {
                    if (buffered)
                    {
                        if (con != null)
                        {
                            con.Close();
                            con.Dispose();
                        }
                    }
                }
            }

        }

        internal static IEnumerable<TReturn> StaticQuery<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            using (IDbConnection con = Database.GetConnection())
            {
                try
                {
                    if (con != null && con.State != ConnectionState.Open)
                        con.Open();

                    return SqlMapper.Query<TFirst, TSecond, TReturn>(con, sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
                }
                finally
                {
                    if (buffered)
                    {
                        if (con != null)
                        {
                            con.Close();
                            con.Dispose();
                        }
                    }
                }
            }
        }


        internal static IEnumerable<dynamic> StaticQuery(string sql, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {

            using (IDbConnection con = Database.GetConnection())
            {
                try
                {
                    if (con != null && con.State != ConnectionState.Open)
                        con.Open();

                    return SqlMapper.Query(con, sql, param, transaction, buffered, commandTimeout, commandType);
                }
                finally
                {
                    if (buffered)
                    {
                        if (con != null)
                        {
                            con.Close();
                            con.Dispose();
                        }
                    }
                }
            }

        }



        internal static int StaticExecute(string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (IDbConnection con = Database.GetConnection())
            {
                try
                {

                    if (con != null && con.State != ConnectionState.Open)
                        con.Open();

                    return SqlMapper.Execute(con, sql, param, transaction, commandTimeout, commandType);
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                        con.Dispose();
                    }
                }
            }

        }

        internal static SqlMapper.GridReader Multiple(CommandDefinition command)
        {
            using (IDbConnection con = Database.GetConnection())
            {
                try
                {
                    if (con != null && con.State != ConnectionState.Open)
                        con.Open();

                    return con.QueryMultiple(command);
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                        con.Dispose();
                    }
                }
            }
        }

        internal static SqlMapper.GridReader Multiple(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            SqlMapper.GridReader result = null;
            using (IDbConnection con = Database.GetConnection())
            {

                if (con != null && con.State != ConnectionState.Open)
                    con.Open();

                result = con.QueryMultiple(sql, param, transaction, commandTimeout, commandType);


            }
            return result;
        }


        internal static DataTable ConvertToDataTable(IEnumerable<dynamic> items)
        {
            var t = new DataTable();
            var first = (IDictionary<string, object>)items.FirstOrDefault();
            foreach (var k in first.Keys)
            {
                var c = t.Columns.Add(k);
                var val = first[k];
                if (val != null) c.DataType = val.GetType();
            }

            foreach (var item in items)
            {
                var r = t.NewRow();
                var i = (IDictionary<string, object>)item;
                foreach (var k in i.Keys)
                {
                    var val = i[k];
                    if (val == null) val = DBNull.Value;
                    r[k] = val;
                }
                t.Rows.Add(r);
            }
            return t;
        }

        protected void OpenConnection()
        {
            if (_connection != null && _connection.State != ConnectionState.Open)
                _connection.Open();
        }

        protected void CloseConnection()
        {
            if (_connection != null)
                _connection.Close();
        }


        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();

            _connection = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void AllPropertyUpdate<T>(T source)
        {
            var plist = this.GetType().GetProperties();

            foreach (var p in plist)
            {
                if (p != null && p.CanWrite)
                {
                    var st = source.GetType().GetProperty(p.Name).GetValue(source, null);

                    p.SetValue(this, st, null);
                }
            }
        }




    }
}
