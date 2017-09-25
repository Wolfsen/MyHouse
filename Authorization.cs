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
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database2.mdf;Integrated Security = True;";
        SqlConnection connection = new SqlConnection(connectionString);
        DataTable dt;

        private void Authorization_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(59, 160, 232);
            button2.BackColor = Color.FromArgb(59, 160, 232);
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            GraphicsPath Button_Path = new GraphicsPath();
            Region Button_Region = new Region(RoundedRect(new Rectangle(0, 0, button1.Width, button1.Height), 10));
            button1.Region = Button_Region;
            button2.Region = Button_Region;
            dataGridView2.Columns[1].DefaultCellStyle.BackColor = Color.FromArgb(162, 136, 234);
            dataGridView2.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(59, 160, 232);
            dataGridView2.RowsDefaultCellStyle.ForeColor = Color.White;
            dataGridView2.RowsDefaultCellStyle.Font = new Font("Calibri", 12, FontStyle.Regular);
            dataGridView2.Rows.Add();
            dataGridView2.Rows[0].Height = 30;
            dataGridView2[0, 0].Value = "Ваш E-mail";
            dataGridView2[0, 0].ReadOnly = true;
            dataGridView2.Rows.Add();
            dataGridView2.Rows[1].Height = 30;
            dataGridView2[0, 1].Value = "Пароль";
            dataGridView2[0, 1].ReadOnly = true;
            dataGridView2[0, 1].Style.Format = "";


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

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView2[1, 0].Value != null && dataGridView2[1, 1].Value != null)
            {
                string sql = "Select * From Users Where email='" + dataGridView2[1, 0].Value.ToString() + "' and password='" + dataGridView2[1, 1].Value.ToString() + "'";
                SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
                connection.Open();
                dt = new DataTable();
                dataadapter.Fill(dt);
                connection.Close();
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][1].ToString() == "1")
                    {
                        MenuClient mc = new MenuClient();
                        mc.Usersmail.Text = dataGridView2[1, 0].Value.ToString();
                        mc.Show();
                        this.Close();
                    }
                    else
                if (dt.Rows[0][1].ToString() == "2")
                    {
                        MenuRealtor mc = new MenuRealtor();
                        mc.Usersmail.Text = dataGridView2[1, 0].Value.ToString();
                        mc.Show();
                        this.Close();
                    }
                    else
                if (dt.Rows[0][1].ToString() == "3")
                    {
                        ManagerMenu mc = new ManagerMenu();
                        mc.Usersmail.Text = dataGridView2[1, 0].Value.ToString();
                        mc.Show();
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Проверьте введенные данные", "Ошибка");
            }
            else
                MessageBox.Show("Попробуй еще раз!", "Ошибка");
        }

    }
   
}
