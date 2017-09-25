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
using Assoc = System.Collections.Generic.Dictionary<string, int>;

namespace MyHouse
{
    public partial class AddRealtyClient : Form
    {
        public AddRealtyClient()
        {
            InitializeComponent();
        }
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database2.mdf;Integrated Security = True;";
        SqlConnection connection = new SqlConnection(connectionString);
        DataTable dt;
        Assoc propertyType = new Assoc();
        Assoc objectType = new Assoc();
        Assoc houseType = new Assoc();
        private void AddRealtyClient_Load(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(59, 160, 232);
            button3.BackColor = Color.FromArgb(59, 160, 232);
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            GraphicsPath Button_Path = new GraphicsPath();
            Region Button_Region = new Region(RoundedRect(new Rectangle(0, 0, button2.Width, button2.Height), 10));
            button2.Region = Button_Region;
            button3.Region = Button_Region;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 160, 232);
            dataGridView1.BackgroundColor = Color.FromArgb(162, 136, 234);
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(162, 136, 234);
            dataGridView1.Rows.Add();

            CBInfo();

          
                   
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
            this.Close();
        }

        private void CBInfo()
        {
            ///вид недвижимости
            string sql = "Select * From Property_Type";
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            connection.Open();
            dt = new DataTable();
            dataadapter.Fill(dt);
            connection.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                (dataGridView1.Rows[0].Cells[0] as DataGridViewComboBoxCell).Items.Add(dt.Rows[i][1].ToString());
                propertyType[dt.Rows[i][1].ToString()] = Convert.ToInt32(dt.Rows[i][0]);
            }
            ////тип объекта
            sql = "Select * From House_Type";
             dataadapter = new SqlDataAdapter(sql, connection);
            connection.Open();
            dt = new DataTable();
            dataadapter.Fill(dt);
            connection.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                (dataGridView1.Rows[0].Cells[1] as DataGridViewComboBoxCell).Items.Add(dt.Rows[i][1].ToString());
                houseType[dt.Rows[i][1].ToString()] = Convert.ToInt32(dt.Rows[i][0]);
            }

            ////вид объекта
            sql = "Select * From Object";
            dataadapter = new SqlDataAdapter(sql, connection);
            connection.Open();
            dt = new DataTable();
            dataadapter.Fill(dt);
            connection.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                (dataGridView1.Rows[0].Cells[2] as DataGridViewComboBoxCell).Items.Add(dt.Rows[i][1].ToString());
                objectType[dt.Rows[i][1].ToString()] = Convert.ToInt32(dt.Rows[i][0]);
            }
            for (int i = 0; i < 10; i++)
            {
                (dataGridView1.Rows[0].Cells[3] as DataGridViewComboBoxCell).Items.Add((i+1).ToString());
            }

        }

        public void SetEmail(string email)
        {
            this.Tag = email;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1[0, 0].Value != null && dataGridView1[1, 0].Value != null &&
            dataGridView1[2, 0].Value != null && dataGridView1[3, 0].Value != null &&
            dataGridView1[4, 0].Value != null && dataGridView1[5, 0].Value != null &&
            dataGridView1[6, 0].Value != null && dataGridView1[7, 0].Value != null && dataGridView1[8, 0].Value != null)
            {
                string sql = "Select Id_Client from Clients where email='" + this.Tag.ToString() + "'";
                SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
                DataTable ds = new DataTable();
                connection.Open();
                dataadapter.Fill(ds);
                connection.Close();

                string[] address = dataGridView1[7, 0].Value.ToString().Split(',');
                string[] floor = dataGridView1[5, 0].Value.ToString().Split(',');
                SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    connection.Open();
                    if(address.Length==4)
                    cmd.CommandText = "Insert into Realty (Id_PropertyType, Id_Object, Id_houseType, numberOfRooms, totalArea, floor, floors, price, descript, city, street, numberHouse, apartment, client) values('" + propertyType[(dataGridView1[0, 0] as DataGridViewComboBoxCell).Value.ToString()] + "','" + objectType[(dataGridView1[2, 0] as DataGridViewComboBoxCell).Value.ToString()] + "','" + houseType[(dataGridView1[1, 0] as DataGridViewComboBoxCell).Value.ToString()] + "','" + Convert.ToInt32((dataGridView1[3, 0] as DataGridViewComboBoxCell).Value) + "','" + Convert.ToInt32(dataGridView1[4, 0].Value)+ "','" + Convert.ToInt32(floor[0]) + "','" + Convert.ToInt32(floor[1]) + "','" + Convert.ToInt32(dataGridView1[6,0].Value) + "',N'" + dataGridView1[8, 0].Value.ToString() + "',N'" + address[0] + "',N'" + address[1] + "','" + Convert.ToInt32(address[2]) + "','" + Convert.ToInt32(address[3]) + "','" + Convert.ToInt32(ds.Rows[0][0]) + "')";
                    else
                    cmd.CommandText = "Insert into Realty (Id_PropertyType, Id_Object, Id_houseType, numberOfRooms, totalArea, floor, floors, price, descript, city, street, numberHouse, client) values('" + propertyType[(dataGridView1[0, 0] as DataGridViewComboBoxCell).Value.ToString()] + "','" + objectType[(dataGridView1[2, 0] as DataGridViewComboBoxCell).Value.ToString()] + "','" + houseType[(dataGridView1[1, 0] as DataGridViewComboBoxCell).Value.ToString()] + "','" + Convert.ToInt32((dataGridView1[0, 0] as DataGridViewComboBoxCell).Value) + "','" + Convert.ToInt32(dataGridView1[4, 0].Value) + "','" + Convert.ToInt32(floor[0]) + "','" + Convert.ToInt32(floor[1]) + "','" + Convert.ToInt32(dataGridView1[6, 0].Value) + "',N'" + dataGridView1[8, 0].Value.ToString() + "',N'" + address[0] + "',N'" + address[1] + "','" + Convert.ToInt32(address[2]) + "','" + Convert.ToInt32(ds.Rows[0][0]) + "')";
                cmd.ExecuteNonQuery();
                    cmd.Clone();
                    connection.Close();
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name == "RealtyClient")
                    {
                        (f as RealtyClient).FillDtgvFromBase();
                        return;
                    }
                }
                MessageBox.Show("Недвижимость добавлена!");
            }
            else
                MessageBox.Show("Заполните все поля!");
        }
    }
}
