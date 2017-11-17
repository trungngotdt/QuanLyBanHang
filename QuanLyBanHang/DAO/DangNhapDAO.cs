using QuanLyBanHang.DAO.InterfacesDAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    public class DangNhapDAO:IDangNhapDAO
    {
        

        public object ChucVu(string query,object[] name)
        {

            return DataProvider2.Instance.ExecuteScalar("EXEC USP_CheckChucVu @Name", name);
        }

        public object GetFirstData(string query, object[] para = null)
        {
            return DataProvider2.Instance.ExecuteScalar(query, para);
            //throw new NotImplementedException();
        }

        public int GetPassHashCode(string query,string name)
        {
            try
            {
                var Pass = DataProvider2.Instance.ExecuteScalar(query, new object[] { name }).GetHashCode();
                return Pass;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            //throw new NotImplementedException();
        }
        
    }
}
