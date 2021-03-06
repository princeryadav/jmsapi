﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Services.Entities
{
    public interface IDbConnections
    {
        string strConnectionString();
        bool openConnection();
        void closeConnection();
        object ExecuteScalar(string query);
        object ExecuteProcedure(string procName, params SqlParameter[] parameters);
        object ExecuteProcedureWithOpenConnection(string procName, params SqlParameter[] parameters);
        int ExecuteNonQuery(string query);
        DataTable ExecuteProcedureForDataTable(string procName, params SqlParameter[] parameters);
        DataSet ExecuteProcedureForDataSet(string procName, params SqlParameter[] parameters);
        DataTable ToDataTable<T>(List<T> items);
        List<T> ConvertDataTable<T>(DataTable dt);
        T GetItem<T>(DataRow dr);

    } 
}
