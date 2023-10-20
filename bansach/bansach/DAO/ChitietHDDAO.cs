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
    public class ChitietHDDAO
    {
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;
        private static ChitietHDDAO _instance;
        public static ChitietHDDAO Instance => _instance ?? (_instance = new ChitietHDDAO());
        public ChitietHDDAO()
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            _sqlCommand = new SqlCommand();
        }
        public static List<ChitietHDDTO> LoadchitietHD(int? id)
        {
            var lstchitietHD = new List<ChitietHDDTO>();
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_loadchitiethoadon", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@id", id);
            using (var reader = Instance._sqlCommand.ExecuteReader())
            {
                int ngaydukienOrdinal = 0;
                int ngaygiaoOrdinal = 0;
                while (reader.Read())
                {
                    ngaygiaoOrdinal = reader.GetOrdinal("Ngaygiao");
                    ngaydukienOrdinal = reader.GetOrdinal("Ngaydukiengiao");
                    if (reader.IsDBNull(ngaydukienOrdinal))
                    {
                        lstchitietHD.Add(new ChitietHDDTO
                        {
                            IDhoadon = reader.GetInt32(reader.GetOrdinal("IDhoadon")),
                            IDuser = reader.GetInt32(reader.GetOrdinal("IDuser")),
                            IDvoucher = reader.GetString(reader.GetOrdinal("IDvoucher")),
                            Ghichu = reader.GetString(reader.GetOrdinal("Ghichu")),
                            Tongtien = reader.GetDouble(reader.GetOrdinal("Tongtien")),
                            Thanhtien = reader.GetDouble(reader.GetOrdinal("Thanhtien")),
                            Ngaydat = reader.GetDateTime(reader.GetOrdinal("Ngaydat")),
                            Ngaydukiengiao = null,
                            Ngaygiao = null,
                            IDtinhtrang = reader.GetInt32(reader.GetOrdinal("IDtinhtrang")),
                            TentinhtrangHD = reader.GetString(reader.GetOrdinal("TentinhtrangHD")),
                            IDsach = reader.GetInt32(reader.GetOrdinal("IDsach")),
                            Tensach = reader.GetString(reader.GetOrdinal("Tensach")),
                            Hinhanh = reader.GetString(reader.GetOrdinal("Hinhanh")),
                            Soluong = reader.GetInt32(reader.GetOrdinal("Soluong")),
                            Tongdongia = reader.GetDouble(reader.GetOrdinal("Tongdongia")),
                            IDtaixe = reader.GetInt32(reader.GetOrdinal("IDtaixe"))
                        });
                    }
                    else if(reader.IsDBNull(ngaygiaoOrdinal))
                    {
                        lstchitietHD.Add(new ChitietHDDTO
                        {
                            IDhoadon = reader.GetInt32(reader.GetOrdinal("IDhoadon")),
                            IDuser = reader.GetInt32(reader.GetOrdinal("IDuser")),
                            IDvoucher = reader.GetString(reader.GetOrdinal("IDvoucher")),
                            Ghichu = reader.GetString(reader.GetOrdinal("Ghichu")),
                            Tongtien = reader.GetDouble(reader.GetOrdinal("Tongtien")),
                            Thanhtien = reader.GetDouble(reader.GetOrdinal("Thanhtien")),
                            Ngaydat = reader.GetDateTime(reader.GetOrdinal("Ngaydat")),
                            Ngaydukiengiao = reader.GetDateTime(reader.GetOrdinal("Ngaydukiengiao")),                          
                            Ngaygiao = null,
                            IDtinhtrang = reader.GetInt32(reader.GetOrdinal("IDtinhtrang")),
                            TentinhtrangHD = reader.GetString(reader.GetOrdinal("TentinhtrangHD")),
                            IDsach = reader.GetInt32(reader.GetOrdinal("IDsach")),
                            Tensach = reader.GetString(reader.GetOrdinal("Tensach")),
                            Hinhanh = reader.GetString(reader.GetOrdinal("Hinhanh")),
                            Soluong = reader.GetInt32(reader.GetOrdinal("Soluong")),
                            Tongdongia = reader.GetDouble(reader.GetOrdinal("Tongdongia")),
                            IDtaixe = reader.GetInt32(reader.GetOrdinal("IDtaixe"))
                        });
                    }    
                    else
                    {
                        lstchitietHD.Add(new ChitietHDDTO
                        {
                            IDhoadon = reader.GetInt32(reader.GetOrdinal("IDhoadon")),
                            IDuser = reader.GetInt32(reader.GetOrdinal("IDuser")),
                            IDvoucher = reader.GetString(reader.GetOrdinal("IDvoucher")),
                            Ghichu = reader.GetString(reader.GetOrdinal("Ghichu")),
                            Tongtien = reader.GetDouble(reader.GetOrdinal("Tongtien")),
                            Thanhtien = reader.GetDouble(reader.GetOrdinal("Thanhtien")),
                            Ngaydat = reader.GetDateTime(reader.GetOrdinal("Ngaydat")),
                            Ngaydukiengiao = reader.GetDateTime(reader.GetOrdinal("Ngaydukiengiao")),
                            Ngaygiao = reader.GetDateTime(reader.GetOrdinal("Ngaygiao")),
                            IDtinhtrang = reader.GetInt32(reader.GetOrdinal("IDtinhtrang")),
                            TentinhtrangHD = reader.GetString(reader.GetOrdinal("TentinhtrangHD")),
                            IDsach = reader.GetInt32(reader.GetOrdinal("IDsach")),
                            Tensach = reader.GetString(reader.GetOrdinal("Tensach")),
                            Hinhanh = reader.GetString(reader.GetOrdinal("Hinhanh")),
                            Soluong = reader.GetInt32(reader.GetOrdinal("Soluong")),
                            Tongdongia = reader.GetDouble(reader.GetOrdinal("Tongdongia")),
                            IDtaixe = reader.GetInt32(reader.GetOrdinal("IDtaixe"))
                        });
                    }
                }
            }
            Instance._sqlConnection.Close();
            return lstchitietHD;
        }
    }
}