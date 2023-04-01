using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Buoi6_ChuongTrinhQLSV
{
    class Manager
    {
        static bool kt = true;
        private static MySqlConnection con = null;
        private static MySqlCommand cmd;

        public static bool KT {
            get { return kt; }
            set { kt = value; }
        }

        public static MySqlConnection CON
        {
            get { return con; }
            set { con = value; }
        }

        public void hienthi(DataGridView dgv, string s)
        {
            MySqlCommand cmd = new MySqlCommand(s, con);
            MySqlDataReader dataReader= cmd.ExecuteReader();
            DataTable table= new DataTable();
            table.Load(dataReader);
            table.Columns.Add("TT");
            for(int i = 1; i <= table.Rows.Count; i++)
            {
                table.Rows[i - 1]["TT"] = i;
            }
            dgv.DataSource= table;
            dataReader.Close();
        }

        public void hienthiCB(ComboBox combo, string s)
        {
            MySqlCommand cmd = new MySqlCommand(s, con);
            MySqlDataReader dataReader= cmd.ExecuteReader();
            while(dataReader.Read())
            {
                combo.Items.Add(dataReader.GetString(0));
            }
            combo.SelectedIndex = 0;
            dataReader.Close();
        }
    }
}
