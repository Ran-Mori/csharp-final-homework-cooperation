using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.SQLite;

namespace Helper
{
    public class SqLiteCRUD
    {
        /// 数据库连接定义
        public SQLiteConnection dbConnection = null;

        /// SQL命令定义
        private SQLiteCommand dbCommand = null;

        /// 数据读取定义
        private SQLiteDataReader dataReader = null;

        /// 数据库连接字符串定义
        private SQLiteConnectionStringBuilder dbConnectionstr = null;

        /// 构造函数
        /// <param name="connectionString">连接SQLite库字符串，也是创建数据库的物理路径</param>
        public SqLiteCRUD(string connectionString)
        {
            SQLiteConnection.CreateFile(connectionString);
            dbConnection = new SQLiteConnection("data source = " + connectionString);
            dbConnection.Open();
            /* try
             {
                 dbConnection = new SQLiteConnection();
                 dbConnectionstr = new SQLiteConnectionStringBuilder();
                 dbConnectionstr.DataSource = connectionString;
                 dbConnectionstr.Password = "admin";      //设置密码，SQLite ADO.NET实现了数据库密码保护
                 dbConnection.ConnectionString = dbConnectionstr.ToString();
                 dbConnection.Open();
             }
             catch (Exception e)
             {
                 Log(e.ToString());
             }*/
        }

        /// 执行SQL命令
        /// <returns>The query.</returns>
        /// <param name="queryString">SQL命令字符串</param>
        public SQLiteDataReader ExecuteQuery(string queryString)
        {
            try
            {
                dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandText = queryString;       //设置SQL语句
                dataReader = dbCommand.ExecuteReader();
            }
            catch (Exception e)
            {
                //注释掉，不然会打印一些警告
                //Log(e.Message);
            }
            return dataReader;
        }

        /// 关闭数据库连接
        public void CloseConnection()
        {
            //销毁Command
            if (dbCommand != null)
            {
                dbCommand.Cancel();
            }
            dbCommand = null;
            //销毁Reader
            if (dataReader != null)
            {
                dataReader.Close();
            }
            dataReader = null;
            //销毁Connection
            if (dbConnection != null)
            {
                dbConnection.Close();
            }
            dbConnection = null;

        }

        /// 读取整张数据表
        /// <returns>The full table.</returns>
        /// <param name="tableName">数据表名称</param>
        public SQLiteDataReader ReadFullTable(string tableName)
        {
            string queryString = "SELECT * FROM " + tableName;  //获取所有可用的字段
            return ExecuteQuery(queryString);
        }

        /// 向指定数据表中插入数据
        /// <returns>The values.</returns>
        /// <param name="tableName">数据表名称</param>
        /// <param name="values">插入的数值</param>
        public SQLiteDataReader InsertValues(string tableName, string[] values)
        {
            //获取数据表中字段数目
            int fieldCount = ReadFullTable(tableName).FieldCount;
            //当插入的数据长度不等于字段数目时引发异常
            if (values.Length != fieldCount)
            {
                throw new SQLiteException("values.Length!=fieldCount");
            }
            string queryString = "INSERT INTO " + tableName + " VALUES (" + "'" + values[0] + "'";
            for (int i = 1; i < values.Length; i++)
            {
                queryString += ", " + "'" + values[i] + "'";
            }
            queryString += " )";
            return ExecuteQuery(queryString);
        }

        /// 更新指定数据表内的数据
        /// <returns>The values.</returns>
        /// <param name="tableName">数据表名称</param>
        /// <param name="colNames">字段名</param>
        /// <param name="colValues">字段名对应的数据</param>
        /// <param name="colConditionNames">关键字</param>
        /// <param name="conditionOperations">运算符：=,<,>,...，默认“=”</param>
        /// <param name="colConditionValues">关键字对应的值</param>
        public SQLiteDataReader UpdateValues(string tableName, string[] colNames, string[] colValues, string[] colConditionNames, string[] conditionOperations, string[] colConditionValues)
        {
            // operation="=";  //默认
            //当字段名称和字段数值不对应时引发异常
            if (colNames.Length != colValues.Length || colConditionNames.Length != colConditionValues.Length)
            {
                throw new SQLiteException("colNames.Length!=colValues.Length or colConditionNames!=colConditionValues");
            }
            string queryString = "UPDATE " + tableName + " SET " + colNames[0] + "=" + "'" + colValues[0] + "'";

            for (int i = 1; i < colValues.Length; i++)
            {
                queryString += ", " + colNames[i] + "=" + "'" + colValues[i] + "'";
            }
            queryString += " WHERE " + colConditionNames[0] + conditionOperations[0] + "'" + colConditionValues[0] + "'";
            for (int i = 1; i < colConditionNames.Length; i++)
            {
                queryString += ", " + colConditionNames[i] + conditionOperations[i] + "'" + colConditionValues[i] + "'";
            }
            return ExecuteQuery(queryString);
        }


        /// 删除指定数据表内的数据
        /// <returns>The values.</returns>
        /// <param name="tableName">数据表名称</param>
        /// <param name="colNames">字段名</param>
        /// /// <param name="operations">操作符号</param>
        /// <param name="colValues">字段名对应的数据</param>
        public SQLiteDataReader DeleteValuesOR(string tableName, string[] colNames, string[] operations, string[] colValues)
        {
            //当字段名称和字段数值不对应时引发异常
            if (colNames.Length != colValues.Length || operations.Length != colNames.Length || operations.Length != colValues.Length)
            {
                throw new SQLiteException("colNames.Length!=colValues.Length || operations.Length!=colNames.Length || operations.Length!=colValues.Length");
            }

            string queryString = "DELETE FROM " + tableName + " WHERE " + colNames[0] + operations[0] + "'" + colValues[0] + "'";
            for (int i = 1; i < colValues.Length; i++)
            {
                queryString += "OR " + colNames[i] + operations[i] + "'" + colValues[i] + "'";
            }
            return ExecuteQuery(queryString);
        }

        /// 删除指定数据表内的数据
        /// <returns>The values.</returns>
        /// <param name="tableName">数据表名称</param>
        /// <param name="colNames">字段名</param>
        /// /// /// <param name="operations">操作符号</param>
        /// <param name="colValues">字段名对应的数据</param>
        public SQLiteDataReader DeleteValuesAND(string tableName, string[] colNames, string[] operations, string[] colValues)
        {
            //当字段名称和字段数值不对应时引发异常
            if (colNames.Length != colValues.Length || operations.Length != colNames.Length || operations.Length != colValues.Length)
            {
                throw new SQLiteException("colNames.Length!=colValues.Length || operations.Length!=colNames.Length || operations.Length!=colValues.Length");
            }

            string queryString = "DELETE FROM " + tableName + " WHERE " + colNames[0] + operations[0] + "'" + colValues[0] + "'";

            for (int i = 1; i < colValues.Length; i++)
            {
                queryString += " AND " + colNames[i] + operations[i] + "'" + colValues[i] + "'";
            }
            return ExecuteQuery(queryString);
        }


        /// 创建数据表
        /// <returns>The table.</returns>
        /// <param name="tableName">数据表名</param>
        /// <param name="colNames">字段名</param>
        /// <param name="colTypes">字段名类型</param>
        public SQLiteDataReader CreateTable(string tableName, string[] colNames, string[] colTypes)
        {
            string queryString = "CREATE TABLE IF NOT EXISTS " + tableName + "( " + colNames[0] + " " + colTypes[0];
            for (int i = 1; i < colNames.Length; i++)
            {
                queryString += ", " + colNames[i] + " " + colTypes[i];
            }
            queryString += "  ) ";
            return ExecuteQuery(queryString);
        }


        /// Reads the table.
        /// <returns>The table.</returns>
        /// <param name="tableName">Table name.</param>
        /// <param name="items">Items.</param>
        /// <param name="colNames">Col names.</param>
        /// <param name="operations">Operations.</param>
        /// <param name="colValues">Col values.</param>
        public SQLiteDataReader ReadTable(string tableName, string[] items, string[] colNames, string[] operations, string[] colValues)
        {
            string queryString = "SELECT " + items[0];
            for (int i = 1; i < items.Length; i++)
            {
                queryString += ", " + items[i];
            }
            queryString += " FROM " + tableName + " WHERE " + colNames[0] + " " + operations[0] + " " + colValues[0];
            for (int i = 0; i < colNames.Length; i++)
            {
                queryString += " AND " + colNames[i] + " " + operations[i] + " " + colValues[0] + " ";
            }
            return ExecuteQuery(queryString);
        }

        /// 本类log
        /// </summary>
        /// <param name="s"></param>
        static void Log(string s)
        {
            Console.WriteLine("class SqLiteCRUD:::" + s);
        }
    }
}

