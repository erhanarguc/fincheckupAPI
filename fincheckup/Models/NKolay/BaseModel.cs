using Dapper;
using fincheckup.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

public class BaseModel : IDisposable, INotifyPropertyChanged
{
    public static string ConnectionString = Database.ConnectionString;// "server=213.238.179.61;database=EDEFTER;user id=sa;password=QaWsEdRfTg321*;Connection Timeout=55";

    //"server=localhost\\WISESQL;database=EDEFTER;user id=sa;password=As123;MultipleActiveResultSets=true;Connection Timeout=55;";

    //"Data Source=SQL5080.site4now.net;Initial Catalog=DB_A67EE8_nsistkurs;User ID=DB_A67EE8_nsistkurs_admin;Password=QWEasz251***;";
    //public static string ConnectionString = "Data Source=.;Initial Catalog=Hvvn;Integrated Security=True";

    public BaseModel()
    {
        Dapper.SqlMapper.Settings.CommandTimeout = 0;
        Connection = new SqlConnection(ConnectionString);
    }

    private IDbConnection _connection;
    [ValidateNever]
    private IDbTransaction _transaction {get;set; }

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
    internal int Execute(string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = 0, CommandType? commandType = null)
    {
        if (transaction == null)
            transaction = _transaction;

        OpenConnection();
        try
        {
            return SqlMapper.Execute(_connection, sql, param, transaction, commandTimeout, commandType);
        }
        finally
        {
            CloseConnection();
        }
    }



    internal IEnumerable<T> Query<T>(string sql, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = 0, CommandType? commandType = null)
    {
        if (transaction == null)
            transaction = _transaction;

        OpenConnection();
        try
        {
            return SqlMapper.Query<T>(_connection, sql, param, transaction, buffered, commandTimeout, commandType);
        }
        finally
        {
            if (buffered)
                CloseConnection();
        }
    }
    internal static IEnumerable<T> StaticQuery<T>(string sql, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = 0, CommandType? commandType = null)
    {

        using (IDbConnection con = new SqlConnection(ConnectionString))
        {
            try
            {
                if (con != null && con.State != ConnectionState.Open)
                    con.Open();
                return SqlMapper.Query<T>(con, sql, param, transaction, buffered, commandTimeout, commandType);
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




    internal static IEnumerable<dynamic> StaticQuery(string sql, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = 0, CommandType? commandType = null)
    {

        using (IDbConnection con = new SqlConnection(ConnectionString))
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
    internal static int StaticExecute(string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = 0, CommandType? commandType = null)
    {
        using (IDbConnection con = new SqlConnection(ConnectionString))
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



}

