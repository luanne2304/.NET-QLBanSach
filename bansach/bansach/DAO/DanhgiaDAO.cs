using bansach.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace bansach.DAO
{
    public class DanhgiaDAO
    {
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;
        private static DanhgiaDAO _instance;
        public static DanhgiaDAO Instance => _instance ?? (_instance = new DanhgiaDAO());
        public DanhgiaDAO()
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            _sqlCommand = new SqlCommand();
        }
        public static void Danhgiasach(string IDuser, int IDsach, string Chitietrv,string IDhoadon)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_danhgia", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@IDuser", IDuser);
            Instance._sqlCommand.Parameters.AddWithValue("@IDsach", IDsach);
            Instance._sqlCommand.Parameters.AddWithValue("@Chitietrv", Chitietrv);
            Instance._sqlCommand.Parameters.AddWithValue("@IDhoadon", IDhoadon);
            Instance._sqlCommand.ExecuteNonQuery();
            Instance._sqlConnection.Close();
        }
        public static void CloseDanhgia(string IDuser, string IDhoadon)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_dongdanhgia", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@IDuser", IDuser);
            Instance._sqlCommand.Parameters.AddWithValue("@IDhoadon", IDhoadon);
            Instance._sqlCommand.ExecuteNonQuery();
            Instance._sqlConnection.Close();
        }
        public static List<DanhgiaDTO> LoadDanhgiabyIDsach(string IDsach)
        {
            var listgh = new List<DanhgiaDTO>();
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_loadDanhgiabyIDsach", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@IDsach", IDsach);
            using (var reader = Instance._sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    listgh.Add(new DanhgiaDTO
                    {
                        Ngayrv = reader.GetDateTime(reader.GetOrdinal("Ngayrv")),
                        Hoten = reader.GetString(reader.GetOrdinal("Hoten")),
                        Chitietrv = reader.GetString(reader.GetOrdinal("Chitietrv"))
                    });
                }
            }
            Instance._sqlConnection.Close();
            return listgh;
        }
    }
}