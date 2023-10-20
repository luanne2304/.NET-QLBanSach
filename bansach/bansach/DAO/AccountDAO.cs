using bansach.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace bansach.DAO
{
    public class AccountDAO
    {
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;
        private static AccountDAO _instance;
        public static AccountDAO Instance => _instance ?? (_instance = new AccountDAO());
        public AccountDAO()
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            _sqlCommand = new SqlCommand();
        }
        public static bool TaoAcc(string Tk, string Mk, string Hoten, string Mail, string Sdt,string TokenActive)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_dangki", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@Tk", Tk);
            Instance._sqlCommand.Parameters.AddWithValue("@Mk", Mk);
            Instance._sqlCommand.Parameters.AddWithValue("@Hoten", Hoten);
            Instance._sqlCommand.Parameters.AddWithValue("@Mail", Mail);
            Instance._sqlCommand.Parameters.AddWithValue("@Sdt", Sdt);
            Instance._sqlCommand.Parameters.AddWithValue("@TokenActive", TokenActive);
            try
            {
                Instance._sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
            finally
            {
                Instance._sqlConnection.Close();
            }
        }

        public static User Login(string Tk, string Mk)
        {
            User user  = new User();
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_login", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@Tk", Tk);
            Instance._sqlCommand.Parameters.AddWithValue("@Mk", Mk);
            var reader = Instance._sqlCommand.ExecuteReader();      
            if (reader.Read())
            {
                user.IDuser = reader.GetInt32(reader.GetOrdinal("IDuser"));
                user.Tk = reader.GetString(reader.GetOrdinal("Tk"));
                user.Mk = reader.GetString(reader.GetOrdinal("Mk"));
                user.HoTen = reader.GetString(reader.GetOrdinal("HoTen"));
                user.Mail = reader.GetString(reader.GetOrdinal("Mail"));
                user.Sdt = reader.GetString(reader.GetOrdinal("Sdt"));
                user.Tichluy = reader.GetDouble(reader.GetOrdinal("Tichluy"));
                user.Thanhvien = reader.GetString(reader.GetOrdinal("Thanhvien"));
                user.IDrole = reader.GetInt32(reader.GetOrdinal("IDrole"));
                user.TrangThai = reader.GetBoolean(reader.GetOrdinal("TrangThai"));
                user.Active = reader.GetBoolean(reader.GetOrdinal("Active"));
            }
            else
            {
                user = null;
            }
            Instance._sqlConnection.Close();
            
            return user;
        }

        public static void Editprofile(string IDuser,string HoTen, string Mail, string Sdt)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_editprofile", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@IDuser", IDuser);
            Instance._sqlCommand.Parameters.AddWithValue("@HoTen", HoTen);
            Instance._sqlCommand.Parameters.AddWithValue("@Mail", Mail);
            Instance._sqlCommand.Parameters.AddWithValue("@Sdt", Sdt);
            Instance._sqlCommand.ExecuteNonQuery();
            Instance._sqlConnection.Close();
        }
        public static bool Changepass(string IDuser, string oldpass, string newpass)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_doipass", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@IDuser", IDuser);
            Instance._sqlCommand.Parameters.AddWithValue("@oldpass", oldpass);
            Instance._sqlCommand.Parameters.AddWithValue("@newpass", newpass);
            try
            {
                Instance._sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
            finally
            {
                Instance._sqlConnection.Close();
            }
        }
        public static void EditUserbyAdmin(int id,bool trangthai, int idrole)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_edituserbyadmin", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@id", id);
            Instance._sqlCommand.Parameters.AddWithValue("@trangthai", trangthai);
            Instance._sqlCommand.Parameters.AddWithValue("@idrole", idrole);
            Instance._sqlCommand.ExecuteNonQuery();
            Instance._sqlConnection.Close();
        }
        public static bool Xacnhanmail(string Tk, string TokenActive)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_xacnhanMail", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@Tk", Tk);
            Instance._sqlCommand.Parameters.AddWithValue("@TokenActive", TokenActive);
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