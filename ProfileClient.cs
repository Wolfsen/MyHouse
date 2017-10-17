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
    public partial class ProfileClient : Form
    {
        public ProfileClient()
        {
            InitializeComponent();
        }


        //static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database2.mdf;Integrated Security = True;";
        static string connectionString = "Data Source=HOUMPC\\HOUMPC;Initial Catalog=MyHouse;Integrated Security=SSPI";

        SqlConnection connection = new SqlConnection(connectionString);
        DataTable dt;

        private void ProfileClient_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(59, 160, 232);
            button4.BackColor = Color.FromArgb(59, 160, 232);
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
            dataGridView1[0, 4].Value = "Дата рождения";
            dataGridView1.Rows.Add();
            dataGridView1.Rows[5].Height = 30;
            dataGridView1[0, 5].Value = "Адрес";
            dataGridView1.Rows.Add();
            dataGridView1.Rows[6].Height = 30;
            dataGridView1[0, 6].Value = "Телефон";
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
            button4.FlatAppearance.BorderSize = 0;
            GraphicsPath Button_Path = new GraphicsPath();
            Region Button_Region = new Region(RoundedRect(new Rectangle(0, 0, button1.Width, button1.Height), 10));
            button1.Region = Button_Region;
            button4.Region = Button_Region;

            DgvAdd();
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
            MenuClient mc = new MenuClient();
            mc.SetEmail(this.Tag.ToString());
            mc.Show();
            this.Close();
        }

        private void DgvAdd()
        {
            string sql = "Select * from Clients where email='" + this.Tag+"'";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dt = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dt.Fill(ds);
            connection.Close();

            for (int i = 1;i<ds.Columns.Count; i++)
            {
                dataGridView1.Rows[i-1].Cells[1].Value = ds.Rows[0][i];
            }
            label1.Tag = ds.Rows[0][0];
            label11.Tag = ds.Rows[0][1];

        }

        public bool PassVerif(string password)
        {
            Regex pass = new Regex(@"^(?=[A-Za-z0-9@%&#,.?!\/*^}{|~)(-_+$]{6,}$)(?=.*\d)(?=.*[A-Za-z])(?=.*[A-Z]).*$");
            return pass.IsMatch(password);
        }

        private void button4_Click(object sender, EventArgs e)
        {


            if (dataGridView1.Rows[0].Cells[1].Value != null && dataGridView1.Rows[1].Cells[1].Value != null && 
                dataGridView1.Rows[2].Cells[1].Value != null && dataGridView1.Rows[3].Cells[1].Value != null && 
                dataGridView1.Rows[4].Cells[1].Value != null && dataGridView1.Rows[5].Cells[1].Value != null && 
                dataGridView1.Rows[6].Cells[1].Value != null)
            {
                 Regex pass = new Regex(@"^(?=[A-Za-z0-9@%&#,.?!\/*^}{|~)(-_+$]{6,}$)(?=.*\d)(?=.*[A-Za-z])(?=.*[A-Z]).*$");
                Regex tel = new Regex(@"^[+7]{ 2 }\s{ 1}[0-9]{3}\s{1}[0-9]{3}\s{1}[0-9]{2}\s{1}[0-9]{2}$");

                if (PassVerif(dataGridView2.Rows[0].Cells[1].Value.ToString()))
                {
                    MessageBox.Show("Пароль не отвечает требованиям");
                    MessageBox.Show("Требования\n" + "1)Минимум 6 символов\n" + "2)Минимум одна заглавная буква\n" + "3)Минимум одна цифра\n" + "4)Хотя бы один символ");

                    return;
                }

                if (tel.IsMatch(dataGridView1.Rows[6].Cells[1].Value.ToString()) == false)
                {
                    MessageBox.Show("Неверный формат телефона");
                    MessageBox.Show("Верный формат: +7 XXX XXX XX XX");

                    return;
                }

                DateTime dateNow = DateTime.Now;
                DateTime clientyear = Convert.ToDateTime(dataGridView1.Rows[4].Cells[1].Value);
                int year = dateNow.Year - clientyear.Year;
                if (dateNow.Month < clientyear.Month ||
                    (dateNow.Month == clientyear.Month && dateNow.Day < clientyear.Day)) year--;

                if(year<18)
                {
                    MessageBox.Show("Клиенту не может быть меньше 18ти лет!");
                    return;
                }


                if (dataGridView1.Rows[0].Cells[1].Value.ToString() != label11.Tag.ToString())
                {
                    MessageBox.Show("Почта не должна меняться!");
                }
                else if (dataGridView2.Rows[0].Cells[1].Value != null && dataGridView2.Rows[1].Cells[1].Value != null && dataGridView2.Rows[0].Cells[1].Value.ToString() == dataGridView2.Rows[1].Cells[1].Value.ToString())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    connection.Open();
                    cmd.CommandText = "Update Clients set email=N'" + dataGridView1.Rows[0].Cells[1].Value +
                         "',FirstName=N'" + dataGridView1.Rows[1].Cells[1].Value + "',LastName=N'"
                         + dataGridView1.Rows[2].Cells[1].Value + "',Patronymic=N'" + dataGridView1.Rows[3].Cells[1].Value +
                         "',DateOfBirth=N'" + dataGridView1.Rows[4].Cells[1].Value + "',Telephone=N'" +
                         dataGridView1.Rows[5].Cells[1].Value + "',Address=N'" + dataGridView1.Rows[6].Cells[1].Value +
                         "' Where Id_Client=N'" + Convert.ToInt32(label1.Tag) + "'";
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    connection.Close();

                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = connection;
                    connection.Open();
                    cmd1.CommandText = "Update Users set password=N'" + dataGridView2.Rows[0].Cells[1].Value +
                         "' Where email=N'" + label11.Tag + "'";
                    cmd1.ExecuteNonQuery();
                    cmd1.Clone();
                    connection.Close();
                    MessageBox.Show("Данные профиля и пароль изменены");
                    DgvAdd();

                }
                else if (dataGridView2.Rows[0].Cells[1].Value != null && dataGridView2.Rows[1].Cells[1].Value != null && dataGridView2.Rows[0].Cells[1].Value.ToString() != dataGridView2.Rows[1].Cells[1].Value.ToString())
                {
                    MessageBox.Show("Пароли не совпадают!");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    connection.Open();
                    cmd.CommandText = "Update Clients set email=N'" + dataGridView1.Rows[0].Cells[1].Value +
                         "',FirstName=N'" + dataGridView1.Rows[1].Cells[1].Value + "',LastName=N'"
                         + dataGridView1.Rows[2].Cells[1].Value + "',Patronymic=N'" + dataGridView1.Rows[3].Cells[1].Value +
                         "',DateOfBirth=N'" + dataGridView1.Rows[4].Cells[1].Value + "',Telephone=N'" +
                         dataGridView1.Rows[5].Cells[1].Value + "',Address=N'" + dataGridView1.Rows[6].Cells[1].Value +
                         "' Where Id_Client=N'" + Convert.ToInt32(label1.Tag) + "'";
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    connection.Close();
                    MessageBox.Show("Данные профиля изменены");
                    DgvAdd();
                }

            }

        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 &&  e.Value != null)
            {
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }
    }
}
