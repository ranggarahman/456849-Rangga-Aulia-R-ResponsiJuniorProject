using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Responsi
{
    internal class UpdateHandler
    {
        private readonly Form1 form1 = new Form1();
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private string conn_string = "host=localhost;port=2022;username=postgres;password=informatika;database=myNameList";
        private string query;
        private DataTable dt;
        private int insertion;

        internal void update(string nama, string dep)
        {
            if (dep == "HR")
            {
                insertion = 1;
            }
            else if (dep == "ENG")
            {
                insertion = 2;
            }
            else if (dep == "DEV")
            {
                insertion = 3;
            }
            else if (dep == "PM")
            {
                insertion = 4;
            }
            else
                insertion = 5;
            query = "UPDATE karyawan SET nama  = '" + form1.textBoxNama.Text + "' ,id_dep=  " + insertion + " ";

            conn = new NpgsqlConnection(conn_string);
            cmd = new NpgsqlCommand(query, conn);


            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();
                }
                dt = new DataTable();
                NpgsqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);

                if (dt.Rows.Count != 1)
                {
                    MessageBox.Show("Success");
                }

            }
            catch (PostgresException ex)
            {
                MessageBox.Show(form1.comboBoxDepartemen.ToString());
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
