using bansach.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace bansach.DAO
{
    public class ShipperDAO
    {
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;
        private static ShipperDAO _instance;
        public static ShipperDAO Instance => _instance ?? (_instance = new ShipperDAO());
        public ShipperDAO()
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            _sqlCommand = new SqlCommand();
        }
        public static List<ShipperDTO> Loadshipperhoatdong()
        {
            var listshipper = new List<ShipperDTO>();
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_loadshipperhoatdong", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            using (var reader = Instance._sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    listshipper.Add(new ShipperDTO
                    {
                        IDuser = reader.GetInt32(reader.GetOrdinal("IDuser")),
                        Tk = reader.GetString(reader.GetOrdinal("Tk")),
                        HoTen = reader.GetString(reader.GetOrdinal("HoTen")),
                        Mail = reader.GetString(reader.GetOrdinal("Mail")),
                        Sdt = reader.GetString(reader.GetOrdinal("Sdt")),
                        IDrole = reader.GetInt32(reader.GetOrdinal("IDrole")),
                        TrangThai = reader.GetBoolean(reader.GetOrdinal("TrangThai"))
                    });
                }
            }
            Instance._sqlConnection.Close();
            return listshipper;
        }
    }
}