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
    internal class DeleteHandler
    {
        private readonly Form1 form1 = new Form1();
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private string conn_string = "host=localhost;port=2022;username=postgres;password=informatika;database=myNameList";
        private string query;
        private DataTable dt;
        private int gv = 1;

        internal void delete()
        {
            query = "UPDATE karyawan SET (nama,id_dep) VALUES ('" + form1.textBoxNama.Text + "', " + gv + ")";

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
