using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestSQL
{
    public partial class TableFrom : Form
    {
        public TableFrom()
        {
            InitializeComponent();
            sqlconnect(dataGridView1, "SELECT * FROM Test_db.friends;");
        }

    }
}
