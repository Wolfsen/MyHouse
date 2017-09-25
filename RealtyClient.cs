using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyHouse
{
    public partial class RealtyClient : Form
    {
        public RealtyClient()
        {
            InitializeComponent();
        }
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database2.mdf;Integrated Security = True;";
        SqlConnection connection = new SqlConnection(connectionString);
        DataTable dt;
        string sql;

        private void RealtyClient_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(59, 160, 232);
            button2.BackColor = Color.FromArgb(59, 160, 232);
            button3.BackColor = Color.FromArgb(59, 160, 232);
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            GraphicsPath Button_Path = new GraphicsPath();
            Region Button_Region = new Region(RoundedRect(new Rectangle(0, 0, button1.Width, button1.Height), 10));
            button1.Region = Button_Region;
            button2.Region = Button_Region;
            button3.Region = Button_Region;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 160, 232);
            dataGridView2.BackgroundColor = Color.FromArgb(162, 136, 234);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 160, 232);
            dataGridView1.BackgroundColor = Color.FromArgb(162, 136, 234);
            dataGridView2.Rows.Add();


            FillDtgvFromBase();
            CBInfo();
        }
        public void SetEmail(string email)
        {
            this.Tag = email;
        }
        public void FillDtgvFromBase()
        {
            string sql = "Select Id_Client from Clients where email='"+this.Tag.ToString()+"'";
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
            connection.Close();


            sql = "Select Id_Realty, descriptionType, descriptionObject, descriptionHouse, numberOfRooms, totalArea, floor, floors, price, descript, city, street, numberHouse, apartment from (((Realty inner join Property_Type On Realty.Id_PropertyType=Property_Type.Id_PropertyType) inner join Object On Realty.Id_Object=Object.Id_Object) inner join House_Type On Realty.Id_houseType=House_Type.Id_houseType) where client='"+Convert.ToInt32(ds.Rows[0][0])+"'";
            dataadapter = new SqlDataAdapter(sql, connection);
            ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
            connection.Close();
            FillDgv(ds);
        }

        private void FillDgv(DataTable ds)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, i].Value = ds.Rows[i][1];
                dataGridView1[1, i].Value = ds.Rows[i][2];
                dataGridView1[2, i].Value = ds.Rows[i][3];
                dataGridView1[3, i].Value = ds.Rows[i][4];
                dataGridView1[4, i].Value = ds.Rows[i][5];
                dataGridView1[5, i].Value = ds.Rows[i][6];
                dataGridView1[5, i].Value += "," + ds.Rows[i][7];
                dataGridView1[6, i].Value = ds.Rows[i][8];
                dataGridView1[7, i].Value = ds.Rows[i][10] + " " + ds.Rows[i][11] + " " + ds.Rows[i][12] + " " + ds.Rows[i][13];
                dataGridView1[8, i].Value = ds.Rows[i][9];
            }
        }

        public static GraphicsPath RoundedRect(Rectangle baseRect, int radius)
        {
            var diameter = radius * 2;
            var sz = new Size(diameter, diameter);
            var arc = new Rectangle(baseRect.Location, sz);
            var path = new GraphicsPath();

            path.AddArc(arc, 180, 90);

            arc.X = baseRect.Right - diameter;
            path.AddArc(arc, 270, 90);

            arc.Y = baseRect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            arc.X = baseRect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MenuClient mc = new MenuClient();
            mc.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddRealtyClient arc = new AddRealtyClient();
            arc.SetEmail(this.Tag.ToString());
            arc.ShowDialog();
        }

        private void CBInfo()
        {
            ///вид недвижимости
            string sql = "Select descriptionType From Property_Type";
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            connection.Open();
            dt = new DataTable();
            dataadapter.Fill(dt);
            connection.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                (dataGridView2.Rows[0].Cells[0] as DataGridViewComboBoxCell).Items.Add(dt.Rows[i][0]);
            }
            ////тип объекта
            sql = "Select descriptionHouse From House_Type";
            dataadapter = new SqlDataAdapter(sql, connection);
            connection.Open();
            dt = new DataTable();
            dataadapter.Fill(dt);
            connection.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                (dataGridView2.Rows[0].Cells[2] as DataGridViewComboBoxCell).Items.Add(dt.Rows[i][0]);
            }

            ////вид объекта
            sql = "Select descriptionObject From Object";
            dataadapter = new SqlDataAdapter(sql, connection);
            connection.Open();
            dt = new DataTable();
            dataadapter.Fill(dt);
            connection.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                (dataGridView2.Rows[0].Cells[1] as DataGridViewComboBoxCell).Items.Add(dt.Rows[i][0]);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql = "Select Id_Realty, descriptionType, descriptionObject, descriptionHouse, numberOfRooms, totalArea, floor, floors, price, descript, city, street, numberHouse, apartment, FirstName from ((((Realty inner join Property_Type On Realty.Id_PropertyType=Property_Type.Id_PropertyType) inner join Object On Realty.Id_Object=Object.Id_Object) inner join House_Type On Realty.Id_houseType=House_Type.Id_houseType) inner join Clients On Realty.client=Clients.Id_Client) where status=''";

            if ((dataGridView2[0, 0] as DataGridViewComboBoxCell).Value != null)
            {
                sql += " and descriptionType=N'" + (dataGridView2[0, 0] as DataGridViewComboBoxCell).Value.ToString() + "'";
            }
            if ((dataGridView2[1, 0] as DataGridViewComboBoxCell).Value != null)
            {

                sql += " and descriptionObject=N'" + (dataGridView2[1, 0] as DataGridViewComboBoxCell).Value.ToString() + "'";

            }
            if ((dataGridView2[2, 0] as DataGridViewComboBoxCell).Value != null)
            {

                sql += " and descriptionHouse=N'" + (dataGridView2[2, 0] as DataGridViewComboBoxCell).Value.ToString() + "'";

            }
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
            connection.Close();
            FillDgv(ds);
        }

        private void RealtyClient_Shown(object sender, EventArgs e)
        {
            FillDtgvFromBase();
        }
    }
}
