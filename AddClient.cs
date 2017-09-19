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
    public partial class AddClient : Form
    {
        public AddClient()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(connectionString);
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database2.mdf;Integrated Security = True";
        SqlCommand cmd = new SqlCommand();
        string sql;
        DataTable dt;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddClient_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(59, 160, 232);
            button4.BackColor = Color.FromArgb(59, 160, 232);
            dataGridView1.BackgroundColor = Color.FromArgb(162, 136, 234);
            dataGridView1.Columns[1].DefaultCellStyle.BackColor = Color.FromArgb(162, 136, 234);
            dataGridView2.Columns[1].DefaultCellStyle.BackColor = Color.FromArgb(162, 136, 234);
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Height = 30;
            dataGridView1[0, 0].Value = "E-mail";
            dataGridView1[0, 0].ReadOnly = true;
            dataGridView1.Rows.Add();
            dataGridView1.Rows[1].Height = 30;
            dataGridView1[0, 1].Value = "Фамилия";
            dataGridView1[0, 1].ReadOnly = true;
            dataGridView1.Rows.Add();
            dataGridView1.Rows[2].Height = 30;
            dataGridView1[0, 2].Value = "Имя";
            dataGridView1[0, 2].ReadOnly = true;
            dataGridView1.Rows.Add();
            dataGridView1.Rows[3].Height = 30;
            dataGridView1[0, 3].Value = "Отчество";
            dataGridView1[0, 3].ReadOnly = true;
            dataGridView1.Rows.Add();
            dataGridView1.Rows[4].Height = 30;
            dataGridView1[0, 4].Value = "Дата рождения";
            dataGridView1[0, 4].ReadOnly = true;
            dataGridView1.Rows.Add();
            dataGridView1.Rows[5].Height = 30;
            dataGridView1[0, 5].Value = "Адрес";
            dataGridView1[0, 5].ReadOnly = true;
            dataGridView1.Rows.Add();
            dataGridView1.Rows[6].Height = 30;
            dataGridView1[0, 6].Value = "Телефон";
            dataGridView1[0, 6].ReadOnly = true;
            dataGridView2.BackgroundColor = Color.FromArgb(162, 136, 234);
            dataGridView2.Rows.Add();
            dataGridView2.Rows[0].Height = 30;
            dataGridView2[0, 0].Value = "Пароль";
            dataGridView2[0, 0].ReadOnly = true;
            dataGridView2.Rows.Add();
            dataGridView2.Rows[1].Height = 30;
            dataGridView2[0, 1].Value = "Повтор пароля";
            dataGridView2[0, 1].ReadOnly = true;
            dataGridView2.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(59, 160, 232);
            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(59, 160, 232);
            button1.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.BorderSize = 0;
            GraphicsPath Button_Path = new GraphicsPath();
            Region Button_Region = new Region(RoundedRect(new Rectangle(0, 0, button1.Width, button1.Height), 10));
            button1.Region = Button_Region;
            button4.Region = Button_Region;
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1[1, 0].Value!= null && dataGridView1[1, 1].Value != null &&
                dataGridView1[1, 2].Value != null && dataGridView1[1, 3].Value != null &&
                dataGridView1[1, 4].Value != null && dataGridView1[1, 5].Value != null &&
                dataGridView1[1, 6].Value != null)
            {
                if (dataGridView2[1, 0].Value != null && dataGridView2[1, 1].Value != null && dataGridView2[1, 0].Value.ToString() == dataGridView2[1, 1].Value.ToString())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    connection.Open();
                    cmd.CommandText = "Insert into Clients (email,FirstName,LastName,Patronymic,DateOfBirth,Telephone,Address) values('" + dataGridView1[1, 0].Value.ToString() + "','" + dataGridView1[1, 1].Value.ToString() + "','" + dataGridView1[1, 2].Value.ToString() + "','" + dataGridView1[1, 3].Value.ToString() + "','" + dataGridView1[1, 4].Value.ToString() + "','" + dataGridView1[1, 5].Value.ToString() + "','" + dataGridView1[1, 6].Value.ToString() + "')";
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    connection.Close();

                    cmd = new SqlCommand();
                    cmd.Connection = connection;
                    connection.Open();
                    cmd.CommandText = "Insert into Users (email,roleid,password) values('" + dataGridView1[1, 0].Value.ToString() + "','" +"1"+ "','" + dataGridView2[1, 0].Value.ToString() + "')";
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    connection.Close();
                                                                              
                    this.Close();
                    
                }
                else
                    MessageBox.Show("Что-то с паролем!");
                        }
            else
                MessageBox.Show("Заполните все поля!");

        }
    }
}
