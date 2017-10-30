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
using System.Drawing.Printing;

namespace MyHouse
{
    public partial class ListRealtors : Form
    {
        public ListRealtors()
        {
            InitializeComponent();
            dgvRealtor.AutoGenerateColumns = false;
        }
       // const string _myConn = "Data Source=HOUMPC\\HOUMPC;Initial Catalog=MyHouse;Integrated Security=SSPI";
        //const string _myConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database2.mdf;Integrated Security = True";

        static string name = Environment.MachineName;
        static string _myConn = "Data Source=" + name + "\\SQLEXPRESS;Initial Catalog=MyHouse;Integrated Security=True";

        SqlConnection _fConDb = new SqlConnection(_myConn);
        SqlCommand cmd = new SqlCommand();
        DataTable dt;
        SqlDataAdapter da;
        BindingSource bs;
        private void ListRealtors_Load(object sender, EventArgs e)
        {
            InitDataRealtor();
            butAdd.BackColor = Color.FromArgb(59, 160, 232);
            butPrint.BackColor = Color.FromArgb(59, 160, 232);
            butBack.BackColor = Color.FromArgb(59, 160, 232);
            butAdd.FlatAppearance.BorderSize = 0;
            butPrint.FlatAppearance.BorderSize = 0;
            butBack.FlatAppearance.BorderSize = 0;
            GraphicsPath Button_Path = new GraphicsPath();
            Region Button_Region = new Region(RoundedRect(new Rectangle(0, 0, butAdd.Width, butAdd.Height), 10));
            butAdd.Region = Button_Region;
            butPrint.Region = Button_Region;
            butBack.Region = Button_Region;
            dgvRealtor.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 160, 232);
            dgvRealtor.BackgroundColor = Color.FromArgb(162, 136, 234);
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

        private void butAdd_Click(object sender, EventArgs e)
        {
            AddEmployee ae = new AddEmployee();
            ae.ShowDialog();
        }

        private void butBack_Click(object sender, EventArgs e)
        {
            ManagerMenu mm = new ManagerMenu();
            mm.Show();
            this.Close();
        }
        public void InitDataRealtor()
        {
            string sql = "SELECT (FirstName+' '+LastName+' '+Patronymic) as FIO, email, Telephone FROM Realtor";
            da = new SqlDataAdapter(sql, _fConDb);
            dt = new DataTable();
            _fConDb.Open();
            da.Fill(dt);
            _fConDb.Close();
            dgvRealtor.DataSource = dt;
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            var pd = new PrintDocument();
            pd.PrintPage += (s, q) =>
            {
                var bmp = new Bitmap(dgvRealtor.Width, dgvRealtor.Height);
                dgvRealtor.DrawToBitmap(bmp, dgvRealtor.ClientRectangle);
                q.Graphics.DrawImage(bmp, new Point(100, 100));
            };
            pd.Print();
        }

        private void ListRealtors_Activated(object sender, EventArgs e)
        {
            InitDataRealtor();
        }
        DataRowCollection allRows;
            DataRow[] searchedRows;
        private void butSearch_Click(object sender, EventArgs e)
        {
            if(searchedRows!=null)
            for (int i = 0; i < searchedRows.Length; i++)
            {
                dgvRealtor.Rows[allRows.IndexOf(searchedRows[i])].DefaultCellStyle.BackColor = Color.White;

            }
            string selectStringFIO = "FIO Like '%" + textBox1.Text.Trim() + "%'";
            string selectStringEmail = "email Like '%" + textBox1.Text.Trim() + "%'";
            string selectStringPhone = "Telephone Like '%" + textBox1.Text.Trim() + "%'";
            allRows = ((DataTable)dgvRealtor.DataSource).Rows;

            searchedRows = ((DataTable)dgvRealtor.DataSource).Select(selectStringFIO);
            if(searchedRows.Length==0)
            {
                searchedRows = ((DataTable)dgvRealtor.DataSource).Select(selectStringEmail);
                if(searchedRows.Length==0)
                {
                    searchedRows = ((DataTable)dgvRealtor.DataSource).Select(selectStringPhone);
                }
            }
            if (searchedRows.Length > 0)
            {
                int rowIndex = allRows.IndexOf(searchedRows[0]);

                dgvRealtor.CurrentCell = dgvRealtor[0, rowIndex];
                for (int i = 0; i < searchedRows.Length; i++)
                {
                    dgvRealtor.Rows[allRows.IndexOf(searchedRows[i])].DefaultCellStyle.BackColor = Color.Blue;

                }
                this.Activated -= new EventHandler(ListRealtors_Activated);
            }
            else
            {
                textBox1.Clear();
                MessageBox.Show("Ничего не найдено по запросу!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                if (searchedRows != null)
                    for (int i = 0; i < searchedRows.Length; i++)
                    {
                        dgvRealtor.Rows[allRows.IndexOf(searchedRows[i])].DefaultCellStyle.BackColor = Color.White;

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
