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
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing.Printing;

namespace MyHouse
{
    public partial class BaseClient : Form
    {
        public BaseClient()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(connectionString);
        //static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database2.mdf;Integrated Security = True";
        static string connectionString = "Data Source=HOUMPC\\HOUMPC;Initial Catalog=MyHouse;Integrated Security=SSPI";

        SqlCommand cmd = new SqlCommand();
        string sql;
        DataTable dt;

        private void BaseClient_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(59, 160, 232);
            button2.BackColor = Color.FromArgb(59, 160, 232);
            button3.BackColor = Color.FromArgb(59, 160, 232);
            button4.BackColor = Color.FromArgb(59, 160, 232);
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.BorderSize = 0;
            GraphicsPath Button_Path = new GraphicsPath();
            Region Button_Region = new Region(RoundedRect(new Rectangle(0, 0, button1.Width, button1.Height), 10));
            button1.Region = Button_Region;
            button2.Region = Button_Region;
            button3.Region = Button_Region;
            button4.Region = Button_Region;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 160, 232);
            dataGridView1.BackgroundColor = Color.FromArgb(162, 136, 234);

            LoadBaseClient();

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
            MenuRealtor mr = new MenuRealtor();
            mr.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddClient ac = new AddClient();
            ac.ShowDialog();
        }

        public void LoadBaseClient()
        {
            dataGridView1.Rows.Clear();

            sql = "Select * from Clients";
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            connection.Open();
            dt = new DataTable();
            dataadapter.Fill(dt);
            connection.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
                dataGridView1.Rows.Add(dt.Rows[i][2]+" "+ dt.Rows[i][3]+" "+ dt.Rows[i][4], dt.Rows[i][1], dt.Rows[i][6], dt.Rows[i][7]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 15;

            ExcelApp.Cells[1, 1] = "ФИО";
            ExcelApp.Cells[1, 2] = "E-mail";
            ExcelApp.Cells[1, 3] = "Телефон";
            ExcelApp.Cells[1, 4] = "Адрес";
           

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    ExcelApp.Cells[j + 2, i + 1] = (dataGridView1[i, j].Value).ToString();
                }
            }
            //Вызываем нашу созданную эксельку. 
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var pd = new PrintDocument();
            pd.PrintPage += (s, q) =>
            {
                var bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
                dataGridView1.DrawToBitmap(bmp, dataGridView1.ClientRectangle);
                q.Graphics.DrawImage(bmp, new Point(100, 100));
            };
            pd.Print();
        }

        private void BaseClient_Activated(object sender, EventArgs e)
        {
            LoadBaseClient();
        }
        DataRowCollection allRows;
        DataRow[] searchedRows;
        private void butSearch_Click(object sender, EventArgs e)
        {
            if (searchedRows != null)
                for (int i = 0; i < searchedRows.Length; i++)
                {
                    dataGridView1.Rows[allRows.IndexOf(searchedRows[i])].DefaultCellStyle.BackColor = Color.White;

                }
            string selectStringFIO = "FIO Like '%" + textBox1.Text.Trim() + "%'";
            string selectStringEmail = "email Like '%" + textBox1.Text.Trim() + "%'";
            string selectStringPhone = "Telephone Like '%" + textBox1.Text.Trim() + "%'";
            string selectStringAddress = "Address Like '%" + textBox1.Text.Trim() + "%'";
            allRows = ((DataTable)dataGridView1.DataSource).Rows;

            searchedRows = ((DataTable)dataGridView1.DataSource).Select(selectStringFIO);
            if (searchedRows.Length == 0)
            {
                searchedRows = ((DataTable)dataGridView1.DataSource).Select(selectStringEmail);
                if (searchedRows.Length == 0)
                {
                    searchedRows = ((DataTable)dataGridView1.DataSource).Select(selectStringPhone);
                    if (searchedRows.Length == 0)
                    {
                        searchedRows = ((DataTable)dataGridView1.DataSource).Select(selectStringAddress);
                    }
                }
            }
            if (searchedRows.Length > 0)
            {
                int rowIndex = allRows.IndexOf(searchedRows[0]);

                dataGridView1.CurrentCell = dataGridView1[0, rowIndex];
                for (int i = 0; i < searchedRows.Length; i++)
                {
                    dataGridView1.Rows[allRows.IndexOf(searchedRows[i])].DefaultCellStyle.BackColor = Color.Blue;

                }
                this.Activated -= new EventHandler(BaseClient_Activated);
            }
            else
            {
                textBox1.Clear();
                MessageBox.Show("Ничего не найдено по запросу!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                if (searchedRows != null)
                    for (int i = 0; i < searchedRows.Length; i++)
                    {
                        dataGridView1.Rows[allRows.IndexOf(searchedRows[i])].DefaultCellStyle.BackColor = Color.White;

                    }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                butSearch_Click(sender, e);
            }
        }
    }
}
