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
    public class ChitietSachDAO
    {
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;
        private static ChitietSachDAO _instance;
        public static ChitietSachDAO Instance => _instance ?? (_instance = new ChitietSachDAO());
        public ChitietSachDAO()
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            _sqlCommand = new SqlCommand();
        }

        //public static List<ChitietSachDTO> LoadchitietSach(int? id)
        //{
        //    var chitietsach = new List<ChitietSachDTO>();
        //    Instance._sqlConnection.Open();
        //    Instance._sqlCommand = new SqlCommand("sp_loadchitietsach", Instance._sqlConnection);
        //    Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //    Instance._sqlCommand.Parameters.AddWithValue("@id", id);
        //    using (var reader = Instance._sqlCommand.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            chitietsach.Add(new ChitietSachDTO
        //            {
        //                IDsach = reader.GetInt32(reader.GetOrdinal("IDsach")),
        //                Tensach = reader.GetString(reader.GetOrdinal("Tensach")),
        //                Tacgia = reader.GetString(reader.GetOrdinal("Tacgia")),
        //                Mota = reader.GetString(reader.GetOrdinal("Mota")),
        //                Gia = reader.GetDouble(reader.GetOrdinal("Gia")),
        //                Hinhanh = reader.GetString(reader.GetOrdinal("Hinhanh")),
        //                SoLuong = reader.GetInt32(reader.GetOrdinal("SoLuong")),
        //                Trangthai = reader.GetBoolean(reader.GetOrdinal("Trangthai")),
        //                IDloai = reader.GetInt32(reader.GetOrdinal("IDloai")),
        //                Tenloai = reader.GetString(reader.GetOrdinal("Tenloai"))
        //            });
        //        }
        //    }
        //    Instance._sqlConnection.Close();
        //    return chitietsach;
        //}
        public static List<Chitietsach> Loadchitietsach(int? id)
        {
            var chitietsach = new List<Chitietsach>();
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_loadchitietsach", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@id", id);
            using (var reader = Instance._sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    chitietsach.Add(new Chitietsach
                    {
                        IDsach = reader.GetInt32(reader.GetOrdinal("IDsach")),
                        IDloai = reader.GetInt32(reader.GetOrdinal("IDloai")),
                    });
                }
            }
            Instance._sqlConnection.Close();
            return chitietsach;
        }
        public static void Addchitietsach(int idsach , int idloai)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_addchitietsach", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@idsach", idsach);
            Instance._sqlCommand.Parameters.AddWithValue("@idloai", idloai);
            Instance._sqlCommand.ExecuteNonQuery();
            Instance._sqlConnection.Close();
        }
        public static void Deletechitietsach(int idsach, int idloai)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_deletechitietsach", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@idsach", idsach);
            Instance._sqlCommand.Parameters.AddWithValue("@idloai", idloai);
            Instance._sqlCommand.ExecuteNonQuery();
            Instance._sqlConnection.Close();
        }
    }
}