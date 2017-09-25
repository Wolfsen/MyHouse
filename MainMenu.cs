using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyHouse
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(connectionString);
        //static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database2.mdf;Integrated Security = True";
        static string connectionString = "Data Source=HOUMPC\\HOUMPC;Initial Catalog=MyHouse;Integrated Security=SSPI";

        SqlCommand cmd = new SqlCommand();
        string sql;
        private void MainMenu_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(59, 160, 232);
            button2.BackColor = Color.FromArgb(59, 160, 232);
            button3.BackColor = Color.FromArgb(59, 160, 232);
            dataGridView2.Columns[0].DefaultCellStyle.WrapMode=DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView2.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(59, 160, 232);
            dataGridView2.Columns[0].DefaultCellStyle.Font = new Font("Calibri", 8, FontStyle.Regular);
            dataGridView2.Columns[1].DefaultCellStyle.BackColor = Color.FromArgb(162, 136, 234);
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(162, 136, 234);
            dataGridView1.BackgroundColor= Color.FromArgb(162, 136, 234);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 160, 232);
            textBox1.BackColor = Color.FromArgb(162, 136, 234);
            label5.BackColor = Color.FromArgb(59, 160, 232);
            dataGridView2.Rows.Add();
            dataGridView2.Rows[0].Height = 40;
            dataGridView2[0,0].Value = "Вид недвижимости";
            dataGridView2.Rows.Add();
            dataGridView2.Rows[1].Height = 40;
            dataGridView2[0, 1].Value = "Тип объекта";
            dataGridView2.Rows.Add();
            dataGridView2.Rows[2].Height = 40;
            dataGridView2[0, 2].Value = "Вид объекта";
            dataGridView2.Rows.Add();
            dataGridView2.Rows[3].Height = 40;
            dataGridView2[0, 3].Value = "Количество комнат";
            dataGridView2.Rows.Add();
            dataGridView2.Rows[4].Height = 40;
            dataGridView2[0, 4].Value = "Этаж";
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            GraphicsPath Button_Path = new GraphicsPath();
            Region Button_Region = new Region(RoundedRect(new Rectangle(0, 0, button1.Width, button1.Height),10));
            button1.Region = Button_Region;
            button2.Region = Button_Region;
            button3.Region = Button_Region;
            FillDtgvFromBase();
            FillPropertyTypeFromBase();
            FillObjectTypeFromBase();
            FillHouseTypeFromBase();
            FillCount();
        }

       private void  FillPropertyTypeFromBase()
        {
            sql = "Select * from Property_Type";
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
            connection.Close();
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                (dataGridView2[1, 0] as DataGridViewComboBoxCell).Items.Add(ds.Rows[i][1]);
            }
        }

        private void FillObjectTypeFromBase()
        {
            sql = "Select * from Object";
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
            connection.Close();
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                (dataGridView2[1, 1] as DataGridViewComboBoxCell).Items.Add(ds.Rows[i][1]);
            }
        }

        private void FillHouseTypeFromBase()
        {
            sql = "Select * from House_Type";
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
            connection.Close();
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                (dataGridView2[1, 2] as DataGridViewComboBoxCell).Items.Add(ds.Rows[i][1]);
            }
        }

        private void FillDtgvFromBase()
        {
            sql = "Select Id_Realty, descriptionType, descriptionObject, descriptionHouse, numberOfRooms, totalArea, floor, floors, price, descript, city, street, numberHouse, apartment from (((Realty inner join Property_Type On Realty.Id_PropertyType=Property_Type.Id_PropertyType) inner join Object On Realty.Id_Object=Object.Id_Object) inner join House_Type On Realty.Id_houseType=House_Type.Id_houseType) where status='' or status is NULL";
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
            connection.Close();
            FillDgv(ds);
        }

        private void FillDgv(DataTable ds)
        {
            dataGridView1.Rows.Clear();
            for(int i=0; i<ds.Rows.Count; i++)
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
                dataGridView1[7, i].Value = ds.Rows[i][10] +" " + ds.Rows[i][11] + " " + ds.Rows[i][12] + " " + ds.Rows[i][13];
                dataGridView1[8, i].Value = ds.Rows[i][9];
            }
        }

        private void FillCount()
        {
            for (int i = 0; i < 10; i++)
            {
                (dataGridView2[1, 3] as DataGridViewComboBoxCell).Items.Add((i+1).ToString());
            }

            for (int i = 0; i < 20; i++)
            {
                (dataGridView2[1, 4] as DataGridViewComboBoxCell).Items.Add((i + 1).ToString());
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Authorization a = new Authorization();
            a.Show();
            this.Hide();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            sql = "Select Id_Realty, descriptionType, descriptionObject, descriptionHouse, numberOfRooms, totalArea, floor, floors, price, descript, city, street, numberHouse, apartment from (((Realty inner join Property_Type On Realty.Id_PropertyType=Property_Type.Id_PropertyType) inner join Object On Realty.Id_Object=Object.Id_Object) inner join House_Type On Realty.Id_houseType=House_Type.Id_houseType) where status=''";

            if ((dataGridView2[1, 0] as DataGridViewComboBoxCell).Value!=null)
            {
                sql += " and descriptionType=N'"+ (dataGridView2[1, 0] as DataGridViewComboBoxCell).Value.ToString()+ "'";
            }
            if ((dataGridView2[1, 1] as DataGridViewComboBoxCell).Value != null)
            {
               
                    sql += " and descriptionObject=N'" + (dataGridView2[1, 1] as DataGridViewComboBoxCell).Value.ToString() + "'";
               
            }
            if ((dataGridView2[1, 2] as DataGridViewComboBoxCell).Value != null)
            {
                
                    sql += " and descriptionHouse=N'" + (dataGridView2[1, 2] as DataGridViewComboBoxCell).Value.ToString() + "'";
              
            }
            if ((dataGridView2[1, 3] as DataGridViewComboBoxCell).Value != null)
            {
              
                    sql += " and numberOfRooms=N'" + Convert.ToInt32((dataGridView2[1, 3] as DataGridViewComboBoxCell).Value) + "'";
               
            }
            if ((dataGridView2[1, 4] as DataGridViewComboBoxCell).Value != null)
            {
               
                    sql += " and floor=N'" + Convert.ToInt32((dataGridView2[1, 4] as DataGridViewComboBoxCell).Value) + "'";
               
            }
            if (textBox1.Text != "")
            {
                
                    sql += " and price <='" + Convert.ToInt32(textBox1.Text) + "'";
               
            }
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
            connection.Close();
            FillDgv(ds);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                (dataGridView2[1, i] as DataGridViewComboBoxCell).Value = null;
            }
            textBox1.Text = "";
        }
    }
}
