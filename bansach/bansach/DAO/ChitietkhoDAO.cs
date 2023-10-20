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
    public class ChitietkhoDAO
    {
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;
        private static ChitietkhoDAO _instance;
        public static ChitietkhoDAO Instance => _instance ?? (_instance = new ChitietkhoDAO());
        public ChitietkhoDAO()
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            _sqlCommand = new SqlCommand();
        }
        public static List<Kho> Loadlistkho()
        {
            var listKho = new List<Kho>();
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_loadlistkho", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            using (var reader = Instance._sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    listKho.Add(new Kho
                    {
                        IDkho = reader.GetInt32(reader.GetOrdinal("IDkho")),
                        Tenkho = reader.GetString(reader.GetOrdinal("Tenkho")),
                        Diachikho = reader.GetString(reader.GetOrdinal("Diachikho")),
                        Trangthai = reader.GetBoolean(reader.GetOrdinal("Trangthai"))
                    });
                }
            }
            Instance._sqlConnection.Close();
            return listKho;
        }
        public static List<Kho> Loadlistkhochuyen(int id)
        {
            var listKho = new List<Kho>();
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_loadlistkhochuyen", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@idkho", id);
            using (var reader = Instance._sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    listKho.Add(new Kho
                    {
                        IDkho = reader.GetInt32(reader.GetOrdinal("IDkho")),
                        Tenkho = reader.GetString(reader.GetOrdinal("Tenkho")),
                        Diachikho = reader.GetString(reader.GetOrdinal("Diachikho")),
                        Trangthai = reader.GetBoolean(reader.GetOrdinal("Trangthai"))
                    });
                }
            }
            Instance._sqlConnection.Close();
            return listKho;
        }



        public static List<Kho> LoadlistkhoHoatdong()
        {
            var listKho = new List<Kho>();
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_loadlistkhohoatdong", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            using (var reader = Instance._sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    listKho.Add(new Kho
                    {
                        IDkho = reader.GetInt32(reader.GetOrdinal("IDkho")),
                        Tenkho = reader.GetString(reader.GetOrdinal("Tenkho")),
                        Diachikho = reader.GetString(reader.GetOrdinal("Diachikho")),
                        Trangthai = reader.GetBoolean(reader.GetOrdinal("Trangthai"))
                    });
                }
            }
            Instance._sqlConnection.Close();
            return listKho;
        }
        public static List<ChitietkhoDTO> Loadchitietkhobyid(int? id)
        {
            var listctKho = new List<ChitietkhoDTO>();
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_loadchitietkhobyid", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@idkho", id);
            using (var reader = Instance._sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    listctKho.Add(new ChitietkhoDTO
                    {
                        Tenkho = reader.GetString(reader.GetOrdinal("Tenkho")),
                        IDkho = reader.GetInt32(reader.GetOrdinal("IDkho")),
                        IDsach = reader.GetInt32(reader.GetOrdinal("IDsach")),
                        Tensach = reader.GetString(reader.GetOrdinal("Tensach")),
                        Hinhanh = reader.GetString(reader.GetOrdinal("Hinhanh")),
                        Soluong = reader.GetInt32(reader.GetOrdinal("Soluong"))
                    });
                }
            }
            Instance._sqlConnection.Close();
            return listctKho;
        }
        public static bool Chuyenkho(string idkhodi, string idkhoden, string idsach, string soluong)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_chuyenkho", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@idkhodi", idkhodi);
            Instance._sqlCommand.Parameters.AddWithValue("@idkhoden", idkhoden);
            Instance._sqlCommand.Parameters.AddWithValue("@idsach", idsach);
            Instance._sqlCommand.Parameters.AddWithValue("@soluong", soluong);
            try
            {
                Instance._sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                Instance._sqlConnection.Close();
            }
        }

        public static bool Nhaphang(string IDkho, string IDsach, string Soluong)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_nhaphang", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@IDkho", IDkho);
            Instance._sqlCommand.Parameters.AddWithValue("@IDsach", IDsach);
            Instance._sqlCommand.Parameters.AddWithValue("@Soluong", Soluong);
            try
            {
                Instance._sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                Instance._sqlConnection.Close();
            }
        }
    }
}