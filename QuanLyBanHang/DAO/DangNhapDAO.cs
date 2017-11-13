﻿using QuanLyBanHang.DAO.InterfacesDAO;
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
            return DataProvider.Instance.ExecuteScalar("EXEC USP_CheckChucVu @Name", name);
        }

        public object GetFirstData(string query, object[] para = null)
        {
            return DataProvider.Instance.ExecuteScalar(query, para);
            //throw new NotImplementedException();
        }

        public int GetPassHashCode(string query,string name)
        {
            var Pass = DataProvider.Instance.ExecuteScalar(query,new object[] { name }).GetHashCode();
            return Pass;
            //throw new NotImplementedException();
        }
        
    }
}