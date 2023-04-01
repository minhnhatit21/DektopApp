using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi6_ChuongTrinhQLSV
{
    public partial class frmLogincs : Form
    {
        public frmLogincs()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Manager.CON = new MySqlConnection("server=localhost;user=root;database=quanly4;port=3306;password=123456");
                Manager.CON.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM user where UserName='" + txtUserName.Text + "' and password='" + txtPassword.Text +"'", Manager.CON);
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable table= new DataTable();
                table.Load(reader);
                if(table.Rows.Count > 0 )
                {
                    Manager.KT = !Manager.KT;
                    MessageBox.Show("Dang nhap thanh cong: ");
                    Close();
                }
                else
                {
                    MessageBox.Show("Username hoặc mật khẩu không đúng");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
