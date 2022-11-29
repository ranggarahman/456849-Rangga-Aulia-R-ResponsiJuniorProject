using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Responsi
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();


        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            InsertHandler insertHandler = new InsertHandler();

            insertHandler.insert(textBoxNama.Text, comboBoxDepartemen.Text);


        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            UpdateHandler updateHandler = new UpdateHandler(); 

            updateHandler.update(textBoxNama.Text, comboBoxDepartemen.Text);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteHandler deleteHandler = new DeleteHandler();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
