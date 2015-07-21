using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Configuration;
using System.IO;


namespace AndroidMvcServer.DAL
{
    public static class MySqlHelper
    {
        public static MySqlConnection Getconn()
        {
            string Strconn = AndroidMvcServer.Common.Utility.GetConnectionString();
            //if (Strconn == null || Strconn.Length == 0) throw new ArgumentNullException("connectionString");
            //MySqlConnection conn = new MySqlConnection(Strconn);
            //conn.Open();
            MySqlConnection connection = new MySqlConnection(Strconn);
            //connection.Open();
            return connection;
        }

        public static string getFirstRow(string strSql)
        {
            MySqlConnection connection = Getconn();
            if (connection == null) throw new ArgumentNullException("connection");
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(strSql, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0] != null)
                {
                    da.Dispose();
                    cmd.Dispose();
                    connection.Close();
                    return dt.Rows[i][0].ToString();
                }
            }
            da.Dispose();
            cmd.Dispose();
            connection.Close();
            return null;
        }

        public class SqlHelper
        {
            private DataSet ds;
            private MySqlConnection conn;
            private MySqlCommand cmd;
            private MySqlDataAdapter sda;

            //数据库操作类
            public int RunSQL(string sql)
            {
                int count = 0;
                try
                {
                    conn = Getconn();
                    conn.Open();
                    cmd = new MySqlCommand(sql, conn);
                    count = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
                return count;
            }

            //返回首行首列
            public int ReturnSQL(string sql)
            {
                int count = 0;
                try
                {
                    conn = Getconn();
                    conn.Open();
                    cmd = new MySqlCommand(sql, conn);
                    count = (int)cmd.ExecuteScalar();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
                return count;

            }

            //返回首行首列
            public decimal ReturnDecimalSQL(string sql)
            {
                decimal count = 0;
                try
                {
                    conn = Getconn();
                    conn.Open();
                    cmd = new MySqlCommand(sql, conn);
                    count = (decimal)cmd.ExecuteScalar();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
                return count;

            }
            //返回DataSet
            public DataSet GetDataSet(string sql)
            {
                try
                {
                    conn = Getconn();
                    sda = new MySqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                }
                catch (Exception e)
                {

                    //throw;
                }
                finally
                {
                    conn.Close();
                }
                return ds;
            }

            //数据库操作存储过程
            public int RunProc(string procName, MySqlParameter[] sp)
            {
                int count = 0;
                try
                {
                    conn = Getconn();
                    conn.Open();
                    cmd = new MySqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procName;
                    cmd.Connection = conn;

                    foreach (MySqlParameter para in sp)
                    {
                        cmd.Parameters.Add(para);
                    }

                    count = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    conn.Close();
                }
                return count;
            }

            //查询存储过程
            public DataSet GetProcDataSet(string procName, MySqlParameter[] sp)
            {
                try
                {
                    conn = Getconn();
                    conn.Open();
                    cmd = new MySqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procName;
                    cmd.Connection = conn;
                    foreach (MySqlParameter para in sp)
                    {
                        cmd.Parameters.Add(para);
                    }
                    sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmd;
                    ds = new DataSet();
                    sda.Fill(ds);
                    return ds;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    conn.Close();
                }

            }

            //带输出参数存储过程 
            public string OutPutProc(string procName, MySqlParameter[] sp)
            {
                try
                {
                    conn = Getconn();
                    conn.Open();
                    cmd = new MySqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procName;
                    cmd.Connection = conn;
                    if (sp != null && sp.Length > 0)
                    {
                        foreach (MySqlParameter para in sp)
                        {
                            cmd.Parameters.Add(para);
                        }
                    }
                    cmd.ExecuteNonQuery();
                    string allmoney = string.Empty;
                    if (sp != null && sp.Length > 0)
                    {
                        for (int i = 0; i < sp.Length; i++)
                        {
                            if (sp[i].Direction == ParameterDirection.Output)
                            {
                                allmoney = Convert.ToString(sp[i].Value);
                            }

                        }
                    }
                    return allmoney;

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }

            }

            //存储过程输出参数
            public string OutPutProcToSp(string procName, MySqlParameter[] sp)
            {
                try
                {
                    conn = Getconn();
                    conn.Open();
                    cmd = new MySqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procName;
                    cmd.Connection = conn;
                    if (sp != null && sp.Length > 0)
                    {
                        foreach (MySqlParameter para in sp)
                        {
                            cmd.Parameters.Add(para);
                        }
                    }
                    cmd.ExecuteNonQuery();
                    string str = string.Empty;
                    if (sp != null && sp.Length > 0)
                    {
                        for (int i = 1; i < 5; i++)
                        {
                            if (sp[i].Direction == ParameterDirection.Output)
                            {
                                str = str + ">>" + Convert.ToString(sp[i].Value);
                            }
                        }
                    }
                    int startIndex = 0;
                    if (str.IndexOf("北京侏罗纪") >= 0)
                        startIndex = str.IndexOf("北京侏罗纪");
                    else if (str.IndexOf("武汉侏罗纪") >= 0)
                        startIndex = str.IndexOf("武汉侏罗纪");
                    else if (str.IndexOf("西安侏罗纪") >= 0)
                        startIndex = str.IndexOf("西安侏罗纪");
                    else if (str.IndexOf("北京雅丹科技") >= 0)
                        startIndex = str.IndexOf("北京雅丹科技");
                    else if (str.IndexOf("北京雅丹石油") >= 0)
                        startIndex = str.IndexOf("北京雅丹石油");
                    return str.Substring(startIndex);

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    conn.Close();
                }

            }

            /// <summary>
            /// SqlGetDataTable [ 执行查询-返DataTable]
            /// </summary>
            /// <param name="proc">存储过程名称</param>
            /// <param name="type">存储过程类型</param>
            /// <param name="paramValue">参数值-[字符串数组]{详细参数请看pro_logPage存储过程里面的注释}</param>
            /// <param name="OutTotalCount">out总记录数</param>
            /// <returns>DataTable</returns>
            public DataTable SqlGetDataTable(string proc, CommandType type, string[] paramValue, out int OutTotalCount)
            {
                try
                {
                    conn = Getconn();
                    conn.Open();
                    cmd = new MySqlCommand(proc, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    //分页开始 
                    MySqlParameter[] myParms = new MySqlParameter[11];

                    myParms[0] = new MySqlParameter("@TableName", MySqlDbType.VarChar, 50);
                    myParms[0].Value = paramValue[0];

                    myParms[1] = new MySqlParameter("@FieldList", MySqlDbType.VarChar, 50);
                    myParms[1].Value = paramValue[1];

                    myParms[2] = new MySqlParameter("@PrimaryKey", MySqlDbType.VarChar, 50);
                    myParms[2].Value = paramValue[2];

                    myParms[3] = new MySqlParameter("@Where", MySqlDbType.VarChar, 500);
                    myParms[3].Value = paramValue[3];

                    myParms[4] = new MySqlParameter("@Order", MySqlDbType.VarChar, 50);
                    myParms[4].Value = paramValue[4];

                    myParms[5] = new MySqlParameter("@SortType", MySqlDbType.Int32, 4);
                    myParms[5].Value = paramValue[5];

                    myParms[6] = new MySqlParameter("@RecorderCount", MySqlDbType.Int32, 4);
                    myParms[6].Value = paramValue[6];

                    myParms[7] = new MySqlParameter("@PageSize", MySqlDbType.Int32, 4);
                    myParms[7].Value = paramValue[7];

                    myParms[8] = new MySqlParameter("@PageIndex", MySqlDbType.Int32, 4);
                    myParms[8].Value = paramValue[8];

                    myParms[9] = new MySqlParameter("@TotalCount", MySqlDbType.Int32, 4);
                    myParms[9].Direction = ParameterDirection.Output;

                    myParms[10] = new MySqlParameter("@TotalPageCount", MySqlDbType.Int32, 4);
                    myParms[10].Direction = ParameterDirection.Output;
                    foreach (MySqlParameter parameter in myParms)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    cmd.CommandType = type;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);
                    //out 总记录数
                    OutTotalCount = Convert.ToInt32(myParms[9].Value);

                    return ds.Tables[0];

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }

        }
    }
}