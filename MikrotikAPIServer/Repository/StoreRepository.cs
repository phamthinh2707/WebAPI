using MikrotikAPIServer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MikrotikAPIServer.Repository
{
    public class StoreRepository
    {
        public List<Store> GetListStore(string brandID)
        {
            List<Store> list = new List<Store>();
            string sqlconect = @"data source=THINHPVDSE62638\THINHPVDSE62638;initial catalog=PassioStore;User Id=sa;Password=123456;integrated security=False;MultipleActiveResultSets=True";
            SqlConnection conn = new SqlConnection(sqlconect);
            conn.Open();
            string sql = "select * from store where brandid='" + brandID + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Store s = new Store(dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4));
                list.Add(s);
            }
            conn.Close();
            return list;
        }

        public string getStoreName(string brandID, string token)
        {
            string storeName = string.Empty;
            string sqlconect = @"data source=THINHPVDSE62638\THINHPVDSE62638;initial catalog=PassioStore;User Id=sa;Password=123456;integrated security=False;MultipleActiveResultSets=True";
            SqlConnection conn = new SqlConnection(sqlconect);
            conn.Open();
            try
            {
                string sql = "Select Stores from Store where Brands='" + brandID + "' AND Token='" + token + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    storeName = dr.GetString(0);
                }
            }
            finally
            {
                conn.Close();
            }
            return storeName;
        }

        public bool checkStore(string brandID, string token)
        {
            bool check = false;
            string sqlconnect = @"data source=THINHPVDSE62638\THINHPVDSE62638;initial catalog=PassioStore;User Id=sa;Password=123456;integrated security=False;MultipleActiveResultSets=True";
            SqlConnection conn = new SqlConnection(sqlconnect);
            conn.Open();
            try
            {
                string sql = "Select Stores from Store where Brands='" + brandID + "' AND Token='" + token + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.GetString(0).Count() > 0)
                        check = true;
                }
            }
            finally
            {
                conn.Close();
            }
            return check;
        }
    }
}