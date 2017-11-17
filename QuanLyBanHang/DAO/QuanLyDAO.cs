using QuanLyBanHang.DAO.InterfacesDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyBanHang.DAO
{
    public class QuanLyDAO : IQuanLyDAO
    {
        public DataTable GetData(string query, object[] para = null)
        {
            return DataProvider2.Instance.ExecuteQuery(query,para);
        }

        public object GetFirstData(string query, object[] para = null)
        {
            return DataProvider2.Instance.ExecuteScalar(query, para);
        }

        public int Insert(string query, object[] para = null)
        {
            return DataProvider2.Instance.ExecuteNonQuery(query, para);
            //throw new NotImplementedException();
        }

        public int Update(string query, object[] para = null)
        {
            return DataProvider2.Instance.ExecuteNonQuery(query, para);
            //throw new NotImplementedException();
        }
    }
}
