using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    public class DataProvider
    {
        private static volatile DataProvider instance;
        private static object syncRoot = new Object();

        private DataProvider() { }

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DataProvider();
                    }
                }

                return instance;
            }
        }
        private string connectionString = "Data Source=.;Initial Catalog = QuanLyBanHang; Integrated Security = True"; //"Data Source=.;Initial Catalog=QuanLyCafeDatabase;Integrated Security=True";

        /// <summary>
        /// Trả về dòng một cộng một của bảng dữ liệu
        /// </summary>
        /// <param name="query"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public object ExecuteScalar(string query, object[] value = null)
        {
            object data = -1;
            using (var objConn = new SqlConnection(connectionString))
            {
                objConn.Open();
                using (var objCommand = new SqlCommand(query, objConn))
                {

                    if (value != null)
                    {
                        var storeQuery = query.Split(' ');
                        int i = 0;
                        foreach (var item in storeQuery)
                        {
                            if (item.StartsWith("@"))
                            {
                                objCommand.Parameters.AddWithValue(item, value[i]);
                                i++;
                            }
                        }
                    }
                    data = objCommand.ExecuteScalar();
                    objConn.Close();
                }
            }
            return data;
        }

        /// <summary>
        /// Trả về số dòng bị câu lệnh truy vấn ảnh hưởng 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string query, object[] value = null)
        {
            int count = -1;
            using (var objConn = new SqlConnection(connectionString))
            {
                objConn.Open();
                using (var objCommand = new SqlCommand(query, objConn))
                {

                    if (value != null)
                    {
                        var storeQuery = query.Split(' ');
                        int i = 0;
                        foreach (var item in storeQuery)
                        {
                            if (item.StartsWith("@"))
                            {
                                objCommand.Parameters.AddWithValue(item, value[i]);
                                i++;
                            }
                        }
                    }
                    count = objCommand.ExecuteNonQuery();
                    objConn.Close();
                }
            }
            return count;
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Thực thi câu lệnh truy vấn ;trả ra các giá trị truy vấn được vào bảng <see cref="DataTable"/>
        /// </summary>
        /// <param name="query"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string query, object[] value = null)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection objConn = new SqlConnection(connectionString))
            {
                objConn.Open();
                using (SqlCommand objCommand = new SqlCommand(query, objConn))
                {

                    if (value != null)
                    {
                        var storeQuery = query.Split(' ');
                        int i = 0;
                        foreach (var item in storeQuery)
                        {
                            if (item.StartsWith("@"))
                            {
                                objCommand.Parameters.AddWithValue(item, value[i]);
                                i++;

                            }
                        }

                    }
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(objCommand);
                    sqlDataAdapter.Fill(dataTable);
                }

                objConn.Close();
            }
            return dataTable;
            //throw new NotImplementedException();
        }
    }
}
