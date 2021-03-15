using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.IO;
using System.Collections;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Types;

namespace OracleDemo {
    class OracleHelper{
        private static string connStr = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
                    "(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));" +
                    "Persist Security Info=True;User ID=system;Password=AN13154e4;";

        #region 执行SQL语句,返回受影响行数
        public static int ExecuteNonQuery(string sql) {
            using (OracleConnection conn = new OracleConnection(connStr)) {
                conn.Open();
                using (OracleCommand cmd = conn.CreateCommand()) {
                    cmd.CommandText = sql;
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region 执行SQL语句,插入数据;
        public static bool InsertBySql(string sql) {
            try {
                using (OracleConnection conn = new OracleConnection(connStr)) {
                    conn.Open();
                    using (OracleCommand cmd = conn.CreateCommand()) {
                        cmd.CommandText = sql;
                        OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0) {
                            Debug.WriteLine("插入成功");
                            return true;
                        }
                        else{
                            Debug.WriteLine("插入失败");
                            return false;
                        }
                    }
                }
            }
            catch (Exception e) {
                Debug.WriteLine("插入失败");
                Debug.WriteLine(e);
                return false;
            }
        }
        #endregion

        #region insert(table, values);
        public static bool Insert(string table,string values) {
            try {
                using (OracleConnection conn = new OracleConnection(connStr)) {
                    conn.Open();
                    using (OracleCommand cmd = conn.CreateCommand()) {
                        string sql = "insert into " + table + " values " + values;
                        Debug.WriteLine(sql);
                        cmd.CommandText = sql;
                        OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0) {
                            Debug.WriteLine("插入成功");
                            return true;
                        }
                        else {
                            Debug.WriteLine("插入失败");
                            return false;
                        }
                    }
                }
            }
            catch (Exception e) {
                Debug.WriteLine("插入失败");
                Debug.WriteLine(e);
                return false;
            }
        }
        #endregion

        #region 执行SQL语句,返回DataTable;
        public static DataTable SelectBySql(string sql) {
            try {
                using (OracleConnection conn = new OracleConnection(connStr)) {
                    conn.Open();
                    using (OracleCommand cmd = conn.CreateCommand()) {
                        cmd.CommandText = sql;
                        OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                        DataTable datatable = new DataTable();
                        adapter.Fill(datatable);
                        Debug.WriteLine("查询成功");
                        return datatable;
                    }
                }
            }
            catch(Exception e) {
                Debug.WriteLine("查询失败");
                Debug.WriteLine(e);
                return new DataTable();
            }
        }
        #endregion

        #region select(attribute,table,where,order by)
        public static DataTable Select(string attr,string table,string where=null,string orderBy=null) { 
            try {
                using (OracleConnection conn = new OracleConnection(connStr)) {
                    conn.Open();
                    using (OracleCommand cmd = conn.CreateCommand()) {
                        string sql = "select " + attr + " from " + table;
                        if (where != null)
                            sql += " where " + where;
                        if (orderBy != null)
                            sql += " order by " + orderBy;
                        Debug.WriteLine(sql);
                        cmd.CommandText = sql;
                        OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                        DataTable datatable = new DataTable();
                        adapter.Fill(datatable);
                        Debug.WriteLine("查询成功");
                        return datatable;
                    }
                }
            }
            catch (Exception e) {
                Debug.WriteLine("查询失败");
                Debug.WriteLine(e);
                return new DataTable();
            }
        }
        #endregion

        #region 格式化输出DataTable
        public static void print(DataTable dt) {
            for (int i = 0; i < dt.Columns.Count; i++) {
                Console.Write("{0,-10}", dt.Columns[i].ColumnName);
            }
            Console.Write('\n');
            for (int i = 0; i < dt.Rows.Count; i++) {
                for(int j = 0; j < dt.Columns.Count; j++) {
                    Console.Write("{0,-10}", dt.Rows[i][j]);
                }
                Console.Write('\n');
            }
        }
        #endregion

        public static void Main(string [] args) {
            
            DataTable dt = OracleHelper.Select("*", "persons", "age>=10", "age");
            print(dt);
            Console.WriteLine(dt.Rows.Count);
            dt = OracleHelper.Select("*", "persons", "age>=30", "age");
            Console.WriteLine(dt.Rows.Count);
        }
    }
}
