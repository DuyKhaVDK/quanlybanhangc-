﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAL
{
    class DAL_nhanvien
    {
        Function lopchung = new Function();

        public int ThemNV(string manv, string tennv, DateTime ngaysinh, string gioitinh, string diachi, string sdt)
        {

            string sql = "Insert into NHANVIEN values(N'" + manv + "',N'" + tennv + "',N'" + ngaysinh.ToString("yyyy'-'MM'-'dd HH':'mm':'ss.fff") + "',N'" + gioitinh + "',N'" + diachi + "',N'" + sdt + "')";
            return lopchung.AddDel(sql);
        }
        public int Suanv(string manv, string hoten, DateTime ngaysinh, string gioitinh, string diachi, string sdt)
        {
            string sql = "Update NHANVIEN set TenNV =N'" + hoten + "',NgaySINH =N'" + ngaysinh.ToString("yyyy'-'MM'-'dd HH':'mm':'ss.fff") + "',GioiTINH =N'" + gioitinh + "',DiaCHI =N'" + diachi + "',SDT =N'" + sdt + "'where MaNV = '" + manv + "'";
            return lopchung.AddDel(sql);
        }
        public int xoanv(string manv)
        {
            string sql = "Delete NHANVIEN where MaNV = N'" + manv + "'";
            return lopchung.AddDel(sql);

        }
        public DataTable Loadnv()
        {
            string sql = "Select * from NHANVIEN";
            return lopchung.LoadDuLieu(sql);

        }
    }
}
