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
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-K1FLG14\SQLEXPRESS;Initial Catalog=Database2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        string sql;
        private void MainMenu_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(59, 160, 232);
            button2.BackColor = Color.FromArgb(59, 160, 232);
            dataGridView2.Columns[0].DefaultCellStyle.WrapMode=DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor= Color.FromArgb(59, 160, 232);
            dataGridView2.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(59, 160, 232);
            dataGridView2.Columns[0].DefaultCellStyle.Font = new Font("Calibri", 8, FontStyle.Regular);
            dataGridView2.Columns[1].DefaultCellStyle.BackColor = Color.FromArgb(162, 136, 234);
            dataGridView1.BackgroundColor= Color.FromArgb(162, 136, 234);
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
            dataGridView2.Rows.Add();
            dataGridView2.Rows[5].Height = 40;
            dataGridView2[0, 5].Value = "Цена до";
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            GraphicsPath Button_Path = new GraphicsPath();
            Region Button_Region = new Region(RoundedRect(new Rectangle(0, 0, button1.Width, button1.Height),10));
            button1.Region = Button_Region;
            button2.Region = Button_Region;
            FillDtgv();
        }

        private void FillDtgv()
        {
            sql = "Select * from Realty";
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
            connection.Close();
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
    }
}
