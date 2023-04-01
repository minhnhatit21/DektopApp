using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Buoi6_ChuongTrinhQLSV
{
    public partial class frmQLLop : Form
    {
        public frmQLLop()
        {
            InitializeComponent();
            Manager manager= new Manager();
            manager.hienthi(dataGridView1, "SELECT * FROM Lop");
            lock_unlock(true);
        }

        void lock_unlock(bool kt)
        {
            btnNew.Enabled =  kt;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = !kt;
        }

        void lock_unlock1(bool kt)
        {
            btnNew.Enabled = btnEdit.Enabled = btnDelete.Enabled = !kt;
            btnAdd.Enabled = kt;
        }

        void lock_unlock2(bool kt)
        {
            btnEdit.Enabled = btnDelete.Enabled = kt;
            btnAdd.Enabled = btnNew.Enabled = !kt;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTenGVCN.Text = txtTenLop.Text = "";
            txtTenLop.Focus();
            lock_unlock1(true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string s = "insert into Lop(TenLop,GVCN) values(N'" + txtTenLop.Text + "',N'" + txtTenGVCN.Text + "')";
                MySqlCommand cmd = new MySqlCommand(s, Manager.CON);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Hien Thi thanh cong");
                Manager manager = new Manager();
                lock_unlock(true);
                manager.hienthi(dataGridView1, "SELECT * FROM Lop");
            } catch (Exception ex)
            {
                MessageBox.Show("The giu lieu bi loi: " + ex);
            }
           

        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string s = "UPDATE lop SET TenLop = N'"+txtTenLop.Text+"', GVCN = N'"+txtTenGVCN.Text+ "' WHERE ID = '"+txtID.Text+"'";
                MySqlCommand cmd = new MySqlCommand(s, Manager.CON);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sua thanh cong");
                Manager manager = new Manager();
                lock_unlock(true);
                manager.hienthi(dataGridView1, "SELECT * FROM Lop");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sua bi loi: " + ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string s = "delete from Lop Where ID = '"+txtID.Text+"' ";
                MySqlCommand cmd = new MySqlCommand(s, Manager.CON);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xoa thanh cong");
                Manager manager = new Manager();
                lock_unlock(true);
                manager.hienthi(dataGridView1, "SELECT * FROM Lop");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xoa giu lieu bi loi: " + ex);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1[0, dataGridView1.CurrentCellAddress.Y].Value.ToString();
            txtTenLop.Text = dataGridView1[1, dataGridView1.CurrentCellAddress.Y].Value.ToString();
            txtTenGVCN.Text = dataGridView1[2, dataGridView1.CurrentCellAddress.Y].Value.ToString();

            lock_unlock2(true);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
