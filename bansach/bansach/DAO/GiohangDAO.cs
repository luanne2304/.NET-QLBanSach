using bansach.DTO;
using bansach.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace bansach.DAO
{
    public class GiohangDAO
    {
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;
        private static GiohangDAO _instance;
        public static GiohangDAO Instance => _instance ?? (_instance = new GiohangDAO());
        public GiohangDAO()
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            _sqlCommand = new SqlCommand();
        }
        public static void Addsanpham(int iduser, int idsach, int soluong)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_themvaogiohang", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@iduser", iduser);
            Instance._sqlCommand.Parameters.AddWithValue("@idsach", idsach);
            Instance._sqlCommand.Parameters.AddWithValue("@soluong", soluong);
            Instance._sqlCommand.ExecuteNonQuery();
            Instance._sqlConnection.Close();
        }

        public static void Updatesanpham(int iduser, int idsach, int soluong)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_updategiohang", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@iduser", iduser);
            Instance._sqlCommand.Parameters.AddWithValue("@idsach", idsach);
            Instance._sqlCommand.Parameters.AddWithValue("@soluong", soluong);
            Instance._sqlCommand.ExecuteNonQuery();
            Instance._sqlConnection.Close();
        }
        public static void Botsanpham(int iduser, int idsach)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_botragiohang", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@iduser", iduser);
            Instance._sqlCommand.Parameters.AddWithValue("@idsach", idsach);
            Instance._sqlCommand.ExecuteNonQuery();
            Instance._sqlConnection.Close();
        }
        public static List<GiohangDTO> Loadlistgio(int iduser)
        {
            var listgh = new List<GiohangDTO>();
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_loadgiohang", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@iduser", iduser);
            using (var reader = Instance._sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    listgh.Add(new GiohangDTO
                    {
                        IDsach = reader.GetInt32(reader.GetOrdinal("IDsach")),
                        Tensach = reader.GetString(reader.GetOrdinal("Tensach")),
                        Hinhanh = reader.GetString(reader.GetOrdinal("Hinhanh")),
                        Tacgia = reader.GetString(reader.GetOrdinal("Tacgia")),
                        Gia = reader.GetDouble(reader.GetOrdinal("Gia")),
                        Soluong = reader.GetInt32(reader.GetOrdinal("Soluong"))
                    });
                }
            }
            Instance._sqlConnection.Close();
            return listgh;
        }
        public static int Thanhtoan(int iduser, string idthanhtoan,string diachi,string ghichu, string idvoucher)
        {
            int IDHD=0;
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_thanhtoan", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@iduser", iduser);
            Instance._sqlCommand.Parameters.AddWithValue("@idthanhtoan", idthanhtoan);
            Instance._sqlCommand.Parameters.AddWithValue("@diachi", diachi);
            Instance._sqlCommand.Parameters.AddWithValue("@ghichu", ghichu);
            Instance._sqlCommand.Parameters.AddWithValue("@idvoucher", idvoucher);
            try
            {
                var reader = Instance._sqlCommand.ExecuteReader();
                reader.Read();
            }
            catch (SqlException ex)
            {
                if (ex.Class == 16 && ex.State == 1 && ex.Message.Contains("errorIDvoucher"))
                {
                    IDHD = -555;
                }
                else
                {
                    IDHD = -999;
                }
            }
            finally
            {
                Instance._sqlConnection.Close();
            }
            return IDHD;
        }
        public static int soluongtronggio(int iduser)
        {
            int quantity = 0;
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("SELECT dbo.ft_soluongtronggio(@iduser)", Instance._sqlConnection);
            Instance._sqlCommand.Parameters.AddWithValue("@iduser", iduser);
            quantity = (int)Instance._sqlCommand.ExecuteScalar();
            var reader = Instance._sqlCommand.ExecuteReader();
            Instance._sqlConnection.Close();
            return quantity;
        }
        public static bool Checkgiohang(int IDuser)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_checkgiohang", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@IDuser", IDuser);
            var reader = Instance._sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                Instance._sqlConnection.Close();
                return true;
            }
            else
            {
                Instance._sqlConnection.Close();
                return false;
            }
        }
    }
}