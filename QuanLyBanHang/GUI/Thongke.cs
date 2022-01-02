using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI
{
    public partial class Thongke : Form
    {
        Function Classmate = new Function();
        BLL.BLL_hoadon bllhd;
     

        public Thongke()
        {
            InitializeComponent();
            bllhd = new BLL.BLL_hoadon(this);
        }

        private void btnTimTheoKhoangtg_Click(object sender, EventArgs e)
        {
          
        }

  

        private void dgv_thongke_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Thongke_Load(object sender, EventArgs e)
        {
            bllhd.loadtk();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_tong_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_tinhtong_Click_1(object sender, EventArgs e)
        {
            int sc = dgv_thongke.Rows.Count;
            long thanhtien = 0;
            for (int i = 0; i < sc - 1; i++)
                thanhtien += long.Parse(dgv_thongke.Rows[i].Cells["ThanhTIEN"].Value.ToString());
            txt_tong.Text = thanhtien.ToString();
        }

        private void btn_load_Click_1(object sender, EventArgs e)
        {
            bllhd.loadtk();
        }

        private void btnTimTheoKhoangtg_Click_1(object sender, EventArgs e)
        {
            Classmate.connection().Open();
            string sql = "SELECT * FROM HOADON WHERE 1=1";
            if ((dt_timetruoc.Text != "") && (dt_timesau.Text != ""))
            {
                sql = sql + " AND NgayBAN >= '" + dt_timetruoc.Value.ToString("yyyy'-'MM'-'dd HH':'mm':'ss.fff") + "' AND NgayBAN <= '" + dt_timesau.Value.ToString("yyyy'-'MM'-'dd HH':'mm':'ss.fff") + "'";
            }
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, Classmate.connection());
            da.Fill(ds);
            Classmate.connection().Close();
            dgv_thongke.DataSource = ds.Tables[0];
            dgv_thongke.Refresh();
        }
    }
}
