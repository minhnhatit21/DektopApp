using MySql.Data.MySqlClient;
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

namespace Buoi6_ChuongTrinhQLSV
{
    public partial class frmQLSinhvien : Form
    {
        private static string queryHTSV = "SELECT SV.ID, HoTen, Dtb, TenLop FROM SV\nINNER JOIN Lop \n\tON SV.ID_lop = Lop.ID";
        public frmQLSinhvien()
        {
            InitializeComponent();
            Manager manager= new Manager();
            manager.hienthi(dataGVSinhVien, queryHTSV);
            manager.hienthiCB(cbLop, "SELECT TenLop From Lop");
            manager.hienthiCB(cbID, "SELECT ID From Lop");
            lock_unlock(true);
        }

        void lock_unlock(bool kt)
        {
            btnActive.Enabled = kt;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = !kt;
        }

        void lock_unlock1(bool kt)
        {
            btnActive.Enabled = btnEdit.Enabled = btnDelete.Enabled = !kt;
            btnAdd.Enabled = kt;
        }

        void lock_unlock2(bool kt)
        {
            btnEdit.Enabled = btnDelete.Enabled = kt;
            btnAdd.Enabled = btnActive.Enabled = !kt;
        }
        private void btnActive_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = txtDTB.Text = "";
            txtHoTen.Focus();
            lock_unlock1(true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
               // string tenlop = Convert.ToString(cbLop.SelectedItem);
                string s = "INSERT INTO SV(HoTen,Dtb,ID_lop) select N'" + txtHoTen.Text + "',N'" + txtDTB.Text + "', ID from Lop where TenLop = N'" + Convert.ToString(cbLop.SelectedItem) + "'";
               
                MySqlCommand cmd = new MySqlCommand(s, Manager.CON);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Them thanh cong");
                Manager manager = new Manager();
                lock_unlock(true);
                manager.hienthi(dataGVSinhVien, queryHTSV);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The giu lieu bi loi: " + ex);
            }


        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            /*try
            {
                string s = "UPDATE lop SET TenLop = N'" + txtTenLop.Text + "', GVCN = N'" + txtTenGVCN.Text + "' WHERE ID = '" + txtID.Text + "'";
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
            }*/
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            /*try
            {
                string s = "delete from Lop Where ID = '" + txtID.Text + "' ";
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
            }*/
        }

        private void dataGVSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbLop_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbLop.
        }
    }
}
