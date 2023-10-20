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
    public class HoadonDAO
    {
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;
        private static HoadonDAO _instance;
        public static HoadonDAO Instance => _instance ?? (_instance = new HoadonDAO());
        public HoadonDAO()
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            _sqlCommand = new SqlCommand();
        }

        public static List<HoadonDTO> LoadlstHDchuaxuly()
        {
            var lsthdchuaxuly = new List<HoadonDTO>();
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_loadhoadonchuaxuly", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            using (var reader = Instance._sqlCommand.ExecuteReader())
            {
                int ngaygiaoOrdinal = 0;
                int ngaydukienOrdinal = 0;
                while (reader.Read())
                {
                    ngaygiaoOrdinal = reader.GetOrdinal("Ngaygiao");
                    ngaydukienOrdinal = reader.GetOrdinal("Ngaydukiengiao");
                    if (reader.IsDBNull(ngaydukienOrdinal))
                    {
                        lsthdchuaxuly.Add(new HoadonDTO
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
                            IDtaixe = reader.GetInt32(reader.GetOrdinal("IDtaixe"))
                        });
                    }
                    else if (reader.IsDBNull(ngaygiaoOrdinal))
                    {
                        lsthdchuaxuly.Add(new HoadonDTO
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
                            IDtaixe = reader.GetInt32(reader.GetOrdinal("IDtaixe"))
                        });
                    }
                    else
                    {
                        lsthdchuaxuly.Add(new HoadonDTO
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
                            IDtaixe = reader.GetInt32(reader.GetOrdinal("IDtaixe"))
                        });
                    }
                }
            }
            Instance._sqlConnection.Close();
            return lsthdchuaxuly;
        }

        public static List<HoadonDTO> LoadlsttHD()
        {
            var lsthdchuaxuly = new List<HoadonDTO>();
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_loadhoadon", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            using (var reader = Instance._sqlCommand.ExecuteReader())
            {
                int ngaygiaoOrdinal = 0;
                int ngaydukienOrdinal = 0;
                while (reader.Read())
                {
                    ngaygiaoOrdinal = reader.GetOrdinal("Ngaygiao");
                    ngaydukienOrdinal = reader.GetOrdinal("Ngaydukiengiao");
                    if (reader.IsDBNull(ngaydukienOrdinal))
                    {
                        lsthdchuaxuly.Add(new HoadonDTO
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
                            IDtaixe = reader.GetInt32(reader.GetOrdinal("IDtaixe"))
                        });
                    }
                    else if (reader.IsDBNull(ngaygiaoOrdinal))
                    {
                        lsthdchuaxuly.Add(new HoadonDTO
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
                            IDtaixe = reader.GetInt32(reader.GetOrdinal("IDtaixe"))
                        });
                    }
                    else
                    {
                        lsthdchuaxuly.Add(new HoadonDTO
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
                            IDtaixe = reader.GetInt32(reader.GetOrdinal("IDtaixe"))
                        });
                    }
                }
            }
            Instance._sqlConnection.Close();
            return lsthdchuaxuly;
        }

        public static void UpdateHD(string idhd, string idtinhtrang,DateTime ngaydukien)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_UpdateHD", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@idhd", idhd);
            Instance._sqlCommand.Parameters.AddWithValue("@idtinhtrang", idtinhtrang);
            Instance._sqlCommand.Parameters.AddWithValue("@ngaydukien", ngaydukien);
            Instance._sqlCommand.ExecuteNonQuery();
            Instance._sqlConnection.Close();
        }

        public static List<HoadonPhanviecDTO> LoadlsttHDphanviec()
        {
            var lsthdxuly = new List<HoadonPhanviecDTO>();
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_loadhdxacnhan", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            using (var reader = Instance._sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    lsthdxuly.Add(new HoadonPhanviecDTO
                    {
                        IDhoadon = reader.GetInt32(reader.GetOrdinal("IDhoadon")),
                        Ghichu = reader.GetString(reader.GetOrdinal("Ghichu")),
                        Diachi = reader.GetString(reader.GetOrdinal("Diachi")),
                        Thanhtien = reader.GetDouble(reader.GetOrdinal("Thanhtien")),
                        Tenphuongthuc = reader.GetString(reader.GetOrdinal("Tenphuongthuc")),
                        Ngaydukiengiao = reader.GetDateTime(reader.GetOrdinal("Ngaydukiengiao"))
                    });                    
                }
            }
            Instance._sqlConnection.Close();
            return lsthdxuly;
        }

        public static void Phanviecshipper(string iduser, string idbill)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_phanviec", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@iduser", iduser);
            Instance._sqlCommand.Parameters.AddWithValue("@idbill", idbill);
            Instance._sqlCommand.ExecuteNonQuery();
            Instance._sqlConnection.Close();
        }

        public static List<HoadonshipperDTO> LoadlsttHDnhanviec(int idshiper)
        {
            var lsthd = new List<HoadonshipperDTO>();
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_loadlstdondanhan", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@idshiper", idshiper);
            using (var reader = Instance._sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    lsthd.Add(new HoadonshipperDTO
                    {
                        IDhoadon = reader.GetInt32(reader.GetOrdinal("IDhoadon")),
                        HoTen = reader.GetString(reader.GetOrdinal("HoTen")),
                        Sdt = reader.GetString(reader.GetOrdinal("Sdt")),
                        Ghichu = reader.GetString(reader.GetOrdinal("Ghichu")),
                        Diachi = reader.GetString(reader.GetOrdinal("Diachi")),
                        Thanhtien = reader.GetDouble(reader.GetOrdinal("Thanhtien")),
                        Tenphuongthuc = reader.GetString(reader.GetOrdinal("Tenphuongthuc")),
                        Ngaydukiengiao = reader.GetDateTime(reader.GetOrdinal("Ngaydukiengiao")),
                        Ngaygiao = null
                    });
                }
            }
            Instance._sqlConnection.Close();
            return lsthd;
        }

        public static bool Xacnhandonauto(int id)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_xacnhandonauto", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@idhd", id);
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
        public static bool Xacnhandon(int id, DateTime ngaydukien)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_xacnhandon", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@idhd", id);
            Instance._sqlCommand.Parameters.AddWithValue("@ngaydukien", ngaydukien);
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

        public static void Hoanthanhdon(string idbill, int idshiper)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_hoanthanhgiao", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@idshiper", idshiper);
            Instance._sqlCommand.Parameters.AddWithValue("@idbill", idbill);
            Instance._sqlCommand.ExecuteNonQuery();
            Instance._sqlConnection.Close();
        }
        public static void Bomhang(string idbill, int idshiper)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_bomhang", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@idshiper", idshiper);
            Instance._sqlCommand.Parameters.AddWithValue("@idbill", idbill);
            Instance._sqlCommand.ExecuteNonQuery();
            Instance._sqlConnection.Close();
        }

        public static List<HoadonshipperDTO> LoadlsttHDShiperdahuy(int idshiper)
        {
            var lsthd = new List<HoadonshipperDTO>();
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_loadlstdondahuy", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@idshiper", idshiper);
            using (var reader = Instance._sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    lsthd.Add(new HoadonshipperDTO
                    {
                        IDhoadon = reader.GetInt32(reader.GetOrdinal("IDhoadon")),
                        HoTen = reader.GetString(reader.GetOrdinal("HoTen")),
                        Sdt = reader.GetString(reader.GetOrdinal("Sdt")),
                        Ghichu = reader.GetString(reader.GetOrdinal("Ghichu")),
                        Diachi = reader.GetString(reader.GetOrdinal("Diachi")),
                        Thanhtien = reader.GetDouble(reader.GetOrdinal("Thanhtien")),
                        Tenphuongthuc = reader.GetString(reader.GetOrdinal("Tenphuongthuc")),
                        Ngaydukiengiao = reader.GetDateTime(reader.GetOrdinal("Ngaydukiengiao")),
                        Ngaygiao = null
                    });
                }
            }
            Instance._sqlConnection.Close();
            return lsthd;
        }
        public static List<HoadonshipperDTO> LoadlsttHDShiperdagiao(int idshiper)
        {
            var lsthd = new List<HoadonshipperDTO>();
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_loadlstdondagiao", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@idshiper", idshiper);
            using (var reader = Instance._sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    lsthd.Add(new HoadonshipperDTO
                    {
                        IDhoadon = reader.GetInt32(reader.GetOrdinal("IDhoadon")),
                        HoTen = reader.GetString(reader.GetOrdinal("HoTen")),
                        Sdt = reader.GetString(reader.GetOrdinal("Sdt")),
                        Ghichu = reader.GetString(reader.GetOrdinal("Ghichu")),
                        Diachi = reader.GetString(reader.GetOrdinal("Diachi")),
                        Thanhtien = reader.GetDouble(reader.GetOrdinal("Thanhtien")),
                        Tenphuongthuc = reader.GetString(reader.GetOrdinal("Tenphuongthuc")),
                        Ngaydukiengiao = reader.GetDateTime(reader.GetOrdinal("Ngaydukiengiao")),
                        Ngaygiao = reader.GetDateTime(reader.GetOrdinal("Ngaygiao"))
                    });
                }
            }
            Instance._sqlConnection.Close();
            return lsthd;
        }
        public static List<HoadonproDTO> LoadHDbyiduser(string IDuser)
        {
            var lsthd = new List<HoadonproDTO>();
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_loadbilldbyiduser", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@IDuser", IDuser);
            using (var reader = Instance._sqlCommand.ExecuteReader())
            {
                int ngaygiaoOrdinal = 0;
                int ngaydukienOrdinal = 0;
                int taixeOrdinal = 0;
                while (reader.Read())
                {
                    ngaygiaoOrdinal = reader.GetOrdinal("Ngaygiao");
                    ngaydukienOrdinal = reader.GetOrdinal("Ngaydukiengiao");
                    taixeOrdinal = reader.GetOrdinal("Tentaixe");
                    if (reader.IsDBNull(ngaydukienOrdinal))
                    {
                        lsthd.Add(new HoadonproDTO
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
                            IDtaixe = reader.GetInt32(reader.GetOrdinal("IDtaixe")),
                            Diachi = reader.GetString(reader.GetOrdinal("Diachi")),
                            TienShip = reader.GetDouble(reader.GetOrdinal("TienShip")),
                            IDthanhtoan = reader.GetInt32(reader.GetOrdinal("IDthanhtoan")),
                            Danhgia = reader.GetBoolean(reader.GetOrdinal("Danhgia")),
                            Chietkhau = reader.GetDouble(reader.GetOrdinal("Chietkhau")),
                            Tenphuongthuc = reader.GetString(reader.GetOrdinal("Tenphuongthuc")),
                            TentinhtrangHD = reader.GetString(reader.GetOrdinal("TentinhtrangHD")),
                            Tentaixe = "Chưa có",
                            Tenkh = reader.GetString(reader.GetOrdinal("Tenkh")),
                            Sdtkh = reader.GetString(reader.GetOrdinal("Sdtkh")),
                            Tensach = reader.GetString(reader.GetOrdinal("Tensach")),
                            Hinhanh = reader.GetString(reader.GetOrdinal("Hinhanh")),
                            Soluong = reader.GetInt32(reader.GetOrdinal("Soluong")),
                            Tongdongia = reader.GetDouble(reader.GetOrdinal("Tongdongia"))
                        });
                    }
                    else if (reader.IsDBNull(ngaygiaoOrdinal))
                    {
                        if (reader.IsDBNull(taixeOrdinal))
                        {
                            lsthd.Add(new HoadonproDTO
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
                                IDtaixe = reader.GetInt32(reader.GetOrdinal("IDtaixe")),
                                Diachi = reader.GetString(reader.GetOrdinal("Diachi")),
                                TienShip = reader.GetDouble(reader.GetOrdinal("TienShip")),
                                IDthanhtoan = reader.GetInt32(reader.GetOrdinal("IDthanhtoan")),
                                Danhgia = reader.GetBoolean(reader.GetOrdinal("Danhgia")),
                                Chietkhau = reader.GetDouble(reader.GetOrdinal("Chietkhau")),
                                Tenphuongthuc = reader.GetString(reader.GetOrdinal("Tenphuongthuc")),
                                TentinhtrangHD = reader.GetString(reader.GetOrdinal("TentinhtrangHD")),
                                Tentaixe = "Chưa có",
                                Tenkh = reader.GetString(reader.GetOrdinal("Tenkh")),
                                Sdtkh = reader.GetString(reader.GetOrdinal("Sdtkh")),
                                Tensach = reader.GetString(reader.GetOrdinal("Tensach")),
                                Hinhanh = reader.GetString(reader.GetOrdinal("Hinhanh")),
                                Soluong = reader.GetInt32(reader.GetOrdinal("Soluong")),
                                Tongdongia = reader.GetDouble(reader.GetOrdinal("Tongdongia"))
                            });
                        }
                        else
                        {
                            lsthd.Add(new HoadonproDTO
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
                                IDtaixe = reader.GetInt32(reader.GetOrdinal("IDtaixe")),
                                Diachi = reader.GetString(reader.GetOrdinal("Diachi")),
                                TienShip = reader.GetDouble(reader.GetOrdinal("TienShip")),
                                IDthanhtoan = reader.GetInt32(reader.GetOrdinal("IDthanhtoan")),
                                Danhgia = reader.GetBoolean(reader.GetOrdinal("Danhgia")),
                                Chietkhau = reader.GetDouble(reader.GetOrdinal("Chietkhau")),
                                Tenphuongthuc = reader.GetString(reader.GetOrdinal("Tenphuongthuc")),
                                TentinhtrangHD = reader.GetString(reader.GetOrdinal("TentinhtrangHD")),
                                Tentaixe = reader.GetString(reader.GetOrdinal("Tentaixe")),
                                Tenkh = reader.GetString(reader.GetOrdinal("Tenkh")),
                                Sdtkh = reader.GetString(reader.GetOrdinal("Sdtkh")),
                                Tensach = reader.GetString(reader.GetOrdinal("Tensach")),
                                Hinhanh = reader.GetString(reader.GetOrdinal("Hinhanh")),
                                Soluong = reader.GetInt32(reader.GetOrdinal("Soluong")),
                                Tongdongia = reader.GetDouble(reader.GetOrdinal("Tongdongia"))
                            });
                        }
                        
                    }
                    else
                    {
                        lsthd.Add(new HoadonproDTO
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
                            IDtaixe = reader.GetInt32(reader.GetOrdinal("IDtaixe")),
                            Diachi = reader.GetString(reader.GetOrdinal("Diachi")),
                            TienShip = reader.GetDouble(reader.GetOrdinal("TienShip")),
                            IDthanhtoan = reader.GetInt32(reader.GetOrdinal("IDthanhtoan")),
                            Danhgia = reader.GetBoolean(reader.GetOrdinal("Danhgia")),
                            Chietkhau = reader.GetDouble(reader.GetOrdinal("Chietkhau")),
                            Tenphuongthuc = reader.GetString(reader.GetOrdinal("Tenphuongthuc")),
                            TentinhtrangHD = reader.GetString(reader.GetOrdinal("TentinhtrangHD")),
                            Tentaixe = reader.GetString(reader.GetOrdinal("Tentaixe")),
                            Tenkh = reader.GetString(reader.GetOrdinal("Tenkh")),
                            Sdtkh = reader.GetString(reader.GetOrdinal("Sdtkh")),
                            Tensach = reader.GetString(reader.GetOrdinal("Tensach")),
                            Hinhanh = reader.GetString(reader.GetOrdinal("Hinhanh")),
                            Soluong = reader.GetInt32(reader.GetOrdinal("Soluong")),
                            Tongdongia = reader.GetDouble(reader.GetOrdinal("Tongdongia"))
                        });
                    }
                }
            }
            Instance._sqlConnection.Close();
            return lsthd;
        }
        public static List<HoadonproDTO> LoadInfoHDbyiduser(string IDuser,string IDhoadon)
        {
            var lsthd = new List<HoadonproDTO>();
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_loadinfobilldbyiduser", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@IDuser", IDuser);
            Instance._sqlCommand.Parameters.AddWithValue("@IDhoadon", IDhoadon);
            try
            {
                int ngaygiaoOrdinal = 0;
                int ngaydukienOrdinal = 0;
                int taixeOrdinal = 0;
                var reader = Instance._sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    ngaygiaoOrdinal = reader.GetOrdinal("Ngaygiao");
                    ngaydukienOrdinal = reader.GetOrdinal("Ngaydukiengiao");
                    taixeOrdinal = reader.GetOrdinal("Tentaixe");
                    if (reader.IsDBNull(ngaydukienOrdinal))
                    {
                        lsthd.Add(new HoadonproDTO
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
                            IDtaixe = reader.GetInt32(reader.GetOrdinal("IDtaixe")),
                            Diachi = reader.GetString(reader.GetOrdinal("Diachi")),
                            TienShip = reader.GetDouble(reader.GetOrdinal("TienShip")),
                            IDthanhtoan = reader.GetInt32(reader.GetOrdinal("IDthanhtoan")),
                            Danhgia = reader.GetBoolean(reader.GetOrdinal("Danhgia")),
                            Chietkhau = reader.GetDouble(reader.GetOrdinal("Chietkhau")),
                            Tenphuongthuc = reader.GetString(reader.GetOrdinal("Tenphuongthuc")),
                            TentinhtrangHD = reader.GetString(reader.GetOrdinal("TentinhtrangHD")),
                            Tentaixe = "Chưa có",
                            Tenkh = reader.GetString(reader.GetOrdinal("Tenkh")),
                            Sdtkh = reader.GetString(reader.GetOrdinal("Sdtkh")),
                            Tensach = reader.GetString(reader.GetOrdinal("Tensach")),
                            Hinhanh = reader.GetString(reader.GetOrdinal("Hinhanh")),
                            Soluong = reader.GetInt32(reader.GetOrdinal("Soluong")),
                            Tongdongia = reader.GetDouble(reader.GetOrdinal("Tongdongia"))
                        });
                    }
                    else if (reader.IsDBNull(ngaygiaoOrdinal))
                    {
                        if (reader.IsDBNull(taixeOrdinal))
                        {
                            lsthd.Add(new HoadonproDTO
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
                                IDtaixe = reader.GetInt32(reader.GetOrdinal("IDtaixe")),
                                Diachi = reader.GetString(reader.GetOrdinal("Diachi")),
                                TienShip = reader.GetDouble(reader.GetOrdinal("TienShip")),
                                IDthanhtoan = reader.GetInt32(reader.GetOrdinal("IDthanhtoan")),
                                Danhgia = reader.GetBoolean(reader.GetOrdinal("Danhgia")),
                                Chietkhau = reader.GetDouble(reader.GetOrdinal("Chietkhau")),
                                Tenphuongthuc = reader.GetString(reader.GetOrdinal("Tenphuongthuc")),
                                TentinhtrangHD = reader.GetString(reader.GetOrdinal("TentinhtrangHD")),
                                Tentaixe = "Chưa có",
                                Tenkh = reader.GetString(reader.GetOrdinal("Tenkh")),
                                Sdtkh = reader.GetString(reader.GetOrdinal("Sdtkh")),
                                Tensach = reader.GetString(reader.GetOrdinal("Tensach")),
                                Hinhanh = reader.GetString(reader.GetOrdinal("Hinhanh")),
                                Soluong = reader.GetInt32(reader.GetOrdinal("Soluong")),
                                Tongdongia = reader.GetDouble(reader.GetOrdinal("Tongdongia"))
                            });
                        }
                        else
                        {
                            lsthd.Add(new HoadonproDTO
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
                                IDtaixe = reader.GetInt32(reader.GetOrdinal("IDtaixe")),
                                Diachi = reader.GetString(reader.GetOrdinal("Diachi")),
                                TienShip = reader.GetDouble(reader.GetOrdinal("TienShip")),
                                IDthanhtoan = reader.GetInt32(reader.GetOrdinal("IDthanhtoan")),
                                Danhgia = reader.GetBoolean(reader.GetOrdinal("Danhgia")),
                                Chietkhau = reader.GetDouble(reader.GetOrdinal("Chietkhau")),
                                Tenphuongthuc = reader.GetString(reader.GetOrdinal("Tenphuongthuc")),
                                TentinhtrangHD = reader.GetString(reader.GetOrdinal("TentinhtrangHD")),
                                Tentaixe = reader.GetString(reader.GetOrdinal("Tentaixe")),
                                Tenkh = reader.GetString(reader.GetOrdinal("Tenkh")),
                                Sdtkh = reader.GetString(reader.GetOrdinal("Sdtkh")),
                                Tensach = reader.GetString(reader.GetOrdinal("Tensach")),
                                Hinhanh = reader.GetString(reader.GetOrdinal("Hinhanh")),
                                Soluong = reader.GetInt32(reader.GetOrdinal("Soluong")),
                                Tongdongia = reader.GetDouble(reader.GetOrdinal("Tongdongia"))
                            });
                        }
                    }
                    else
                    {
                        lsthd.Add(new HoadonproDTO
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
                            IDtaixe = reader.GetInt32(reader.GetOrdinal("IDtaixe")),
                            Diachi = reader.GetString(reader.GetOrdinal("Diachi")),
                            TienShip = reader.GetDouble(reader.GetOrdinal("TienShip")),
                            IDthanhtoan = reader.GetInt32(reader.GetOrdinal("IDthanhtoan")),
                            Danhgia = reader.GetBoolean(reader.GetOrdinal("Danhgia")),
                            Chietkhau = reader.GetDouble(reader.GetOrdinal("Chietkhau")),
                            Tenphuongthuc = reader.GetString(reader.GetOrdinal("Tenphuongthuc")),
                            TentinhtrangHD = reader.GetString(reader.GetOrdinal("TentinhtrangHD")),
                            Tentaixe = reader.GetString(reader.GetOrdinal("Tentaixe")),
                            Tenkh = reader.GetString(reader.GetOrdinal("Tenkh")),
                            Sdtkh = reader.GetString(reader.GetOrdinal("Sdtkh")),
                            Tensach = reader.GetString(reader.GetOrdinal("Tensach")),
                            Hinhanh = reader.GetString(reader.GetOrdinal("Hinhanh")),
                            Soluong = reader.GetInt32(reader.GetOrdinal("Soluong")),
                            Tongdongia = reader.GetDouble(reader.GetOrdinal("Tongdongia"))
                        });
                    } 
                }
                return lsthd;
            }
            catch (SqlException ex)
            {
                return lsthd = null;
            }
            finally
            {
                Instance._sqlConnection.Close();
            }
        }
        public static void Danhanhang(string IDuser, string IDhoadon)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_danhanhang", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@IDuser", IDuser);
            Instance._sqlCommand.Parameters.AddWithValue("@IDhoadon", IDhoadon);
            Instance._sqlCommand.ExecuteNonQuery();
            Instance._sqlConnection.Close();
        }
        public static void Yeucauhoanhang(string IDuser, string IDhoadon)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_yeucauhoanhang", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@IDuser", IDuser);
            Instance._sqlCommand.Parameters.AddWithValue("@IDhoadon", IDhoadon);
            Instance._sqlCommand.ExecuteNonQuery();
            Instance._sqlConnection.Close();
        }
        public static void Khongxacnhan(string IDhoadon)
        {
            Instance._sqlConnection.Open();
            Instance._sqlCommand = new SqlCommand("sp_khongxacnhan", Instance._sqlConnection);
            Instance._sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            Instance._sqlCommand.Parameters.AddWithValue("@idbill", IDhoadon);
            Instance._sqlCommand.ExecuteNonQuery();
            Instance._sqlConnection.Close();
        }
    }
}