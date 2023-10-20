using bansach.DTO;
using bansach.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace bansach.DAO
{
    public class VoucherDAO
    {
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;
        private static VoucherDAO _instance;
        public static VoucherDAO Instance => _instance ?? (_instance = new VoucherDAO());
        public VoucherDAO()
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            _sqlCommand = new SqlCommand();
        }
        public static double Checkvoucher(string voucherId)
        {
            double temp = -999;
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_checkcode", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@idvoucher", voucherId);
            using (var reader = Instance._sqlCommand.ExecuteReader())
            {
                if(reader.Read())
                {
                    temp = reader.GetDouble(reader.GetOrdinal("Chietkhau"));
                }
            }
            Instance._sqlConnection.Close();
            return temp;
        }
        public static List<Voucher> Loadvoucherhoatdong()
        {
            var listvoucher = new List<Voucher>();
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_loadvoucherhoatdong", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            using (var reader = Instance._sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    listvoucher.Add(new Voucher
                    {
                        IDvoucher = reader.GetString(reader.GetOrdinal("IDvoucher")),
                        Tenvoucher = reader.GetString(reader.GetOrdinal("Tenvoucher")),
                        Chietkhau = reader.GetDouble(reader.GetOrdinal("Chietkhau")),
                        Soluong = reader.GetInt32(reader.GetOrdinal("Soluong")),
                        Trangthai = reader.GetBoolean(reader.GetOrdinal("Trangthai"))
                    });
                }
            }
            Instance._sqlConnection.Close();
            return listvoucher;
        }
    }
}