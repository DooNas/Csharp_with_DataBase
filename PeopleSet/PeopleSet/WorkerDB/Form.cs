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

namespace WindowsFormsDB
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            btnInsert.Click += BtnInsert_Click;
            btnSearch.Click += BtnSearch_Click;
            myComDataGridView.CellClick += MyComDataGridView_CellClick;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(mySqlConnStr);
                conn.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(" delete from `MYCOMPANY1`.`mycompany1`");
                sb.Append(" where ");
                sb.Append(" id = '"); sb.Append(txtId.Text); sb.Append("' ");
                string sql = sb.ToString();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                Search();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void MyComDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //e.RowIndex
            string id = myComDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            string name = myComDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            string email = myComDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            string dept = myComDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            string job = myComDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
            string level = myComDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
            string flaType = myComDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
            string flaValue = myComDataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
            string flbType = myComDataGridView.Rows[e.RowIndex].Cells[8].Value.ToString();
            string flbValue = myComDataGridView.Rows[e.RowIndex].Cells[9].Value.ToString();
            string score = myComDataGridView.Rows[e.RowIndex].Cells[10].Value.ToString();
            string salary = myComDataGridView.Rows[e.RowIndex].Cells[11].Value.ToString();
            txtId.Text = id;
            txtName.Text = name;
            txtEmail.Text = email;
            txtDept.Text = dept;
            txtJob.Text = job;
            txtLevel.Text = level;
            txtFlaType.Text = flaType;
            txtFlaValue.Text = flaValue;
            txtFlbType.Text = flbType;
            txtFlbValue.Text = flbValue;
            txtScore.Text = score;
            txtSalary.Text = salary;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(mySqlConnStr);
                conn.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(" update `MYCOMPANY1`.`mycompany1`");
                sb.Append(" set ");
                sb.Append(" `name` = '"); sb.Append(txtName.Text); sb.Append("', ");
                sb.Append(" `email` = '"); sb.Append(txtEmail.Text); sb.Append("', ");
                sb.Append(" `dept` = '"); sb.Append(txtDept.Text); sb.Append("', ");
                sb.Append(" `job` = '"); sb.Append(txtJob.Text); sb.Append("', ");
                sb.Append(" `level` = '"); sb.Append(txtLevel.Text); sb.Append("', ");
                sb.Append(" `flatype` = '"); sb.Append(txtFlaType.Text); sb.Append("', ");
                sb.Append(" `flavalue` = '"); sb.Append(txtFlaValue.Text); sb.Append("', ");
                sb.Append(" `flbtype` = '"); sb.Append(txtFlbType.Text); sb.Append("', ");
                sb.Append(" `flbvalue` = '"); sb.Append(txtFlbValue.Text); sb.Append("', ");
                sb.Append(" `score` = '"); sb.Append(txtScore.Text); sb.Append("', ");
                sb.Append(" salary = '"); sb.Append(txtSalary.Text); sb.Append("' ");
                sb.Append(" where ");
                sb.Append(" id = '"); sb.Append(txtId.Text); sb.Append("' ");

                string sql = sb.ToString();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                Search();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private static string mySqlConnStr = DB_Key.GetKey();
        DataSet ds;

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //데이터 조회를 위해서..
            Search();
        }

        private void Search()
        {
            try
            {
                ds = new DataSet();
                MySqlConnection conn = new MySqlConnection(mySqlConnStr);
                conn.Open();
                string sql = "select * from MYCOMPANY1.mycompany1";
                //쿼리와 커넥션으로 쿼리 실행
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                //데이터 채우고
                adapter.Fill(ds, "mycompany1");
                //채워진 데이터를 데이터그리드뷰에 할당
                myComDataGridView.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(mySqlConnStr);
                conn.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(" insert into `MYCOMPANY1`.`mycompany1` ");
                sb.Append(" values ( ");
                sb.Append(" '");sb.Append(txtId.Text); sb.Append("', ");
                sb.Append(" '"); sb.Append(txtName.Text); sb.Append("', ");
                sb.Append(" '"); sb.Append(txtEmail.Text); sb.Append("', ");
                sb.Append(" '"); sb.Append(txtDept.Text); sb.Append("', ");
                sb.Append(" '"); sb.Append(txtJob.Text); sb.Append("', ");
                sb.Append(" '"); sb.Append(txtLevel.Text); sb.Append("', ");
                sb.Append(" '"); sb.Append(txtFlaType.Text); sb.Append("', ");
                sb.Append(" '"); sb.Append(txtFlaValue.Text); sb.Append("', ");
                sb.Append(" '"); sb.Append(txtFlbType.Text); sb.Append("', ");
                sb.Append(" '"); sb.Append(txtFlbValue.Text); sb.Append("', ");
                sb.Append(" '"); sb.Append(txtScore.Text); sb.Append("', ");
                sb.Append(" '"); sb.Append(txtSalary.Text); sb.Append("' ");
                sb.Append(" ) ");
                string sql = sb.ToString();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                Search();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
