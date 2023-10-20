using bansach.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace bansach.DAO
{
    public  class SachDAO
    {
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;
        private static SachDAO _instance;
        public static SachDAO Instance => _instance ?? (_instance = new SachDAO());
        public SachDAO()
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            _sqlCommand = new SqlCommand();
        }
        public static void EditSach(Sach sach, string temp)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_editsach", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@id", sach.IDsach);
            Instance._sqlCommand.Parameters.AddWithValue("@ten", sach.Tensach);
            Instance._sqlCommand.Parameters.AddWithValue("@tgia", sach.Tacgia);
            Instance._sqlCommand.Parameters.AddWithValue("@mota", sach.Mota);
            Instance._sqlCommand.Parameters.AddWithValue("@gia", sach.Gia);
            Instance._sqlCommand.Parameters.AddWithValue("@img", temp);
            Instance._sqlCommand.Parameters.AddWithValue("@trangthai", sach.Trangthai);
            Instance._sqlCommand.ExecuteNonQuery();
            Instance._sqlConnection.Close();
        }
        public static void Addsach(Sach sach,string temp)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_addsach", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@Tensach", sach.Tensach);
            Instance._sqlCommand.Parameters.AddWithValue("@Tacgia", sach.Tacgia);
            Instance._sqlCommand.Parameters.AddWithValue("@Mota", sach.Mota);
            Instance._sqlCommand.Parameters.AddWithValue("@Gia", sach.Gia);
            Instance._sqlCommand.Parameters.AddWithValue("@Hinhanh", temp);
            Instance._sqlCommand.Parameters.AddWithValue("@Trangthai", sach.Trangthai);
            Instance._sqlCommand.ExecuteNonQuery();
            Instance._sqlConnection.Close();
        }
        public static List<Sach> Loadlstsachhoatdong()
        {
            var listsach = new List<Sach>();
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_loadsphoatdong", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            using (var reader = Instance._sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    listsach.Add(new Sach
                    {
                        IDsach = reader.GetInt32(reader.GetOrdinal("IDsach")),
                        Tensach = reader.GetString(reader.GetOrdinal("Tensach")),
                        Tacgia = reader.GetString(reader.GetOrdinal("Tacgia")),
                        Mota = reader.GetString(reader.GetOrdinal("Mota")),
                        Gia = reader.GetDouble(reader.GetOrdinal("Gia")),
                        Hinhanh = reader.GetString(reader.GetOrdinal("Hinhanh")),
                        SoLuong = reader.GetInt32(reader.GetOrdinal("SoLuong")),
                        Trangthai = reader.GetBoolean(reader.GetOrdinal("Trangthai"))
                    });
                }
            }
            Instance._sqlConnection.Close();
            return listsach;
        }
        public static List<Sach> LoadlstsachhoatdongbyCatevName(string IDloai, string Tensach)
        {
            var listsach = new List<Sach>();
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_loadsphoatdongbyCatevName", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@IDloai", IDloai);
            Instance._sqlCommand.Parameters.AddWithValue("@Tensach", Tensach);
            using (var reader = Instance._sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    listsach.Add(new Sach
                    {
                        IDsach = reader.GetInt32(reader.GetOrdinal("IDsach")),
                        Tensach = reader.GetString(reader.GetOrdinal("Tensach")),
                        Tacgia = reader.GetString(reader.GetOrdinal("Tacgia")),
                        Gia = reader.GetDouble(reader.GetOrdinal("Gia")),
                        Hinhanh = reader.GetString(reader.GetOrdinal("Hinhanh")),
                    });
                }
            }
            Instance._sqlConnection.Close();
            return listsach;
        }
        public static Sach Loadsachbyid(string IDsach)
        {
            var sach = new Sach();
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_loadsachbyID", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@IDsach", IDsach);
            using (var reader = Instance._sqlCommand.ExecuteReader())
            {
                if (reader.Read())
                {
                    sach.IDsach = reader.GetInt32(reader.GetOrdinal("IDsach"));
                    sach.Tensach = reader.GetString(reader.GetOrdinal("Tensach"));
                    sach.Tacgia = reader.GetString(reader.GetOrdinal("Tacgia"));
                    sach.Mota = reader.GetString(reader.GetOrdinal("Mota"));
                    sach.Gia = reader.GetDouble(reader.GetOrdinal("Gia"));
                    sach.Hinhanh = reader.GetString(reader.GetOrdinal("Hinhanh"));
                    sach.SoLuong = reader.GetInt32(reader.GetOrdinal("SoLuong"));
                    sach.Trangthai = reader.GetBoolean(reader.GetOrdinal("Trangthai"));
                }
                else
                {
                    sach = null;
                }
            }
            Instance._sqlConnection.Close();
            return sach;
        }
        public static List<Int32> Getidsachinbill(string IDuser,string IDhoadon) {
            var lst = new List<Int32>();

            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_loadIDsach", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@IDuser", IDuser);
            Instance._sqlCommand.Parameters.AddWithValue("@IDhoadon", IDhoadon);
            using (var reader = Instance._sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    lst.Add(reader.GetInt32(reader.GetOrdinal("IDsach")));
                }
            }
            Instance._sqlConnection.Close();
            return lst;
        }
        public static List<String> LoadloaibyIDsach(string IDsach)
        {
            var lst = new List<String>();

            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_loadtheloaibyIDsach", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@IDsach", IDsach);
            using (var reader = Instance._sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    lst.Add(reader.GetString(reader.GetOrdinal("Tenloai")));
                }
            }
            Instance._sqlConnection.Close();
            return lst;
        }
    }
}