using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TestSQL
{
    public partial class TableFrom : Form
    {
        string ConnectionAddress = Mysql_data.ConnectionAddress();

        public void sqlconnect(DataGridView dataGridView, string sql)//table 구현 장소 지정, sql문 지정
        {
            DataSet ds; //쿼리를 이용하여, 가져올 데이터 저장 공간 선언(DataSet)(Datatable 들의 리스트로 볼 수 있다.)
            //Chk_list();
            try
            {
                ds = new DataSet(); //데이터 공간 생성

                //접속하기
                MySqlConnection conn = new MySqlConnection(ConnectionAddress);
                 
                //오픈
                conn.Open();

                //비연결 모드 : DB연결
                //비연결 모드 : 데이터베이스에서 가져온 값을 클라이언트 메모리로 저장한 후, 연결을 끊는 방식
                //즉, 데이터를 가져와서 본 프로그램의 연결 공간에 데이터 저장
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                adapter.Fill(ds, "friends");
                //DataSet내에 myCompany1이라는 Table 공간을 만들어 저장
                //즉, DataSet은 여러개의 DataTable을 가질 수 있음.

                dataGridView.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}
    }

}