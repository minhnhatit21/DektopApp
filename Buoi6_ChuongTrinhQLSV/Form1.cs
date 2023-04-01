using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Buoi6_ChuongTrinhQLSV
{
    public partial class Form1 : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
            lock_unlock(Manager.KT);
          /*  try
            {
                con = new MySqlConnection("server=localhost;user=root;database=quanly4;port=3306;password=123456");
                con.Open();
                MessageBox.Show("Kết nối  thành công");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        void lock_unlock(bool kt)
        {
            mnuDangNhap.Enabled = mnuThoat.Enabled = kt;
            mnuQuanly.Enabled = mnuTimKiem.Enabled = mnuQuanly.Enabled = mnuBaocao.Enabled= mnuHuyDangNhap.Enabled = !kt; ;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mnuHeThong_Click(object sender, EventArgs e)
        {

        }

        private void mnuQuanly_Click(object sender, EventArgs e)
        {

        }

        private void mnuTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void mnuBaocao_Click(object sender, EventArgs e)
        {

        }

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            frmLogincs f = new frmLogincs();
            f.Show();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            lock_unlock(Manager.KT);
        }

        private void mnuLop_Click(object sender, EventArgs e)
        {
           frmQLLop qLLop= new frmQLLop();
            qLLop.Show();
        }

        private void mnuSinhVien_Click(object sender, EventArgs e)
        {
            frmQLSinhvien frmQLSinhvien= new frmQLSinhvien();
            frmQLSinhvien.Show();
        }
    }
}
