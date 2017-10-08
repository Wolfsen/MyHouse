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
using System.Text.RegularExpressions;

namespace MyHouse
{
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(connectionString);
        //static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database2.mdf;Integrated Security = True";
        static string connectionString = "Data Source=HOUMPC\\HOUMPC;Initial Catalog=MyHouse;Integrated Security=SSPI";

        SqlCommand cmd = new SqlCommand();
        string sql;
        DataTable dt;

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(59, 160, 232);
            button2.BackColor = Color.FromArgb(59, 160, 232);
            dataGridView1.BackgroundColor = Color.FromArgb(162, 136, 234);
            dataGridView1.Columns[1].DefaultCellStyle.BackColor = Color.FromArgb(162, 136, 234);
            dataGridView2.Columns[1].DefaultCellStyle.BackColor = Color.FromArgb(162, 136, 234);
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Height = 30;
            dataGridView1[0, 0].Value = "E-mail";
            dataGridView1.Rows.Add();
            dataGridView1.Rows[1].Height = 30;
            dataGridView1[0, 1].Value = "Фамилия";
            dataGridView1.Rows.Add();
            dataGridView1.Rows[2].Height = 30;
            dataGridView1[0, 2].Value = "Имя";
            dataGridView1.Rows.Add();
            dataGridView1.Rows[3].Height = 30;
            dataGridView1[0, 3].Value = "Отчество";
            dataGridView1.Rows.Add();
            dataGridView1.Rows[4].Height = 30;
            dataGridView1[0, 4].Value = "Телефон";
            dataGridView2.BackgroundColor = Color.FromArgb(162, 136, 234);
            dataGridView2.Rows.Add();
            dataGridView2.Rows[0].Height = 30;
            dataGridView2[0, 0].Value = "Пароль";
            dataGridView2.Rows.Add();
            dataGridView2.Rows[1].Height = 30;
            dataGridView2[0, 1].Value = "Повтор пароля";
            dataGridView2.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(59, 160, 232);
            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(59, 160, 232);
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            GraphicsPath Button_Path = new GraphicsPath();
            Region Button_Region = new Region(RoundedRect(new Rectangle(0, 0, button1.Width, button1.Height), 10));
            button1.Region = Button_Region;
            button2.Region = Button_Region;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1[1, 0].Value != null && dataGridView1[1, 1].Value != null &&
                dataGridView1[1, 2].Value != null && dataGridView1[1, 3].Value != null &&
                dataGridView1[1, 4].Value != null)
            {


                Regex pass = new Regex(@"^(?=[A-Za-z0-9@%&#,.?!\/*^}{|~)(-_+$]{6,}$)(?=.*\d)(?=.*[A-Za-z])(?=.*[A-Z]).*$");
                Regex tel = new Regex(@"^[+7]{2}\s{1}[0-9]{3}\s{1}[0-9]{3}\s{1}[0-9]{2}\s{1}[0-9]{2}$");
                Regex mail = new Regex(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$");
              

                if (pass.IsMatch(dataGridView2.Rows[0].Cells[1].Value.ToString()) == false)
                {
                    MessageBox.Show("Пароль не отвечает требованиям");
                    return;
                }

                if (mail.IsMatch(dataGridView1.Rows[0].Cells[1].Value.ToString()) == false)
                {
                    MessageBox.Show("Такой почты не существует!!!");
                    return;
                }

                if (tel.IsMatch(dataGridView1.Rows[4].Cells[1].Value.ToString()) == false)
                {
                    MessageBox.Show("Неверный формат телефона");
                    return;
                }
                              
                if (dataGridView2[1, 0].Value != null && dataGridView2[1, 1].Value != null && dataGridView2[1, 0].Value.ToString() == dataGridView2[1, 1].Value.ToString())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    connection.Open();
                    cmd.CommandText = "Insert into Realtor (email,FirstName,LastName,Patronymic,Telephone) values('" + dataGridView1[1, 0].Value.ToString() + "',N'" + dataGridView1[1, 1].Value.ToString() + "',N'" + dataGridView1[1, 2].Value.ToString() + "',N'" + dataGridView1[1, 3].Value.ToString() + "','" + dataGridView1[1, 4].Value.ToString() +  "')";
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    connection.Close();

                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = connection;
                    connection.Open();
                    cmd1.CommandText = "Insert into Users (email,roleid,password) values('" + dataGridView1[1, 0].Value.ToString() + "','" + "2" + "','" + dataGridView2[1, 0].Value.ToString() + "')";
                    cmd1.ExecuteNonQuery();
                    cmd1.Clone();
                    connection.Close();

                    
                    this.Close();

                }
                else
                    MessageBox.Show("Пароли не совпадают!");
            }
            else
                MessageBox.Show("Заполните все поля!");

        
    }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.Value != null)
            {
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }
    }
}
