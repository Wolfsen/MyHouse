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
    public partial class Rating : Form
    {
        public Rating()
        {
            InitializeComponent();
        }
        const string _myConn = "Data Source=HOUMPC\\HOUMPC;Initial Catalog=MyHouse;Integrated Security=SSPI";
        //const string _myConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database2.mdf;Integrated Security = True";
        SqlConnection _fConDb = new SqlConnection(_myConn);
        SqlCommand cmd = new SqlCommand();
        DataTable dt;
        SqlDataAdapter da;
        private void Rating_Load(object sender, EventArgs e)
        {
            dgv.BackgroundColor = Color.FromArgb(162, 136, 234);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 160, 232);
            butCount.BackColor = Color.FromArgb(59, 160, 232);
            butSum.BackColor = Color.FromArgb(59, 160, 232);
            butBack.BackColor = Color.FromArgb(59, 160, 232);
            butPrint.BackColor = Color.FromArgb(59, 160, 232);
            butCount.FlatAppearance.BorderSize = 0;
            butSum.FlatAppearance.BorderSize = 0;
            butBack.FlatAppearance.BorderSize = 0;
            butPrint.FlatAppearance.BorderSize = 0;
            GraphicsPath Button_Path = new GraphicsPath();
            Region Button_Region = new Region(RoundedRect(new Rectangle(0, 0, butCount.Width, butCount.Height), 10));
            butCount.Region = Button_Region;
            butSum.Region = Button_Region;
            Button_Region = new Region(RoundedRect(new Rectangle(0, 0, butBack.Width, butBack.Height), 10));
            butBack.Region = Button_Region;
            butPrint.Region = Button_Region;
            InitDataDeal();
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
        // novik.13.03@gmail.com
        private void butBack_Click(object sender, EventArgs e)
        {
            ManagerMenu mm = new ManagerMenu();
            mm.Show();
            this.Close();
        }
        public void InitDataDeal()
        {
            string sql = "SELECT (FirstName+' '+LastName+' '+Patronymic) as FIO, COUNT(Id_deal) as CountDeal, SUM(price) as SumDeal FROM ((Deal inner join Realty on Realty.Id_Realty=Deal.Id_realty)  inner join Realtor on Realtor.Id=Deal.Id_realtor) Group By FirstName, LastName, Patronymic";
            da = new SqlDataAdapter(sql, _fConDb);
            dt = new DataTable();
            _fConDb.Open();
            da.Fill(dt);
            _fConDb.Close();
            dgv.DataSource = dt;
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            var pd = new PrintDocument();
            pd.PrintPage += (s, q) =>
            {
                var bmp = new Bitmap(dgv.Width, dgv.Height);
                dgv.DrawToBitmap(bmp, dgv.ClientRectangle);
                q.Graphics.DrawImage(bmp, new Point(100, 100));
            };
            pd.Print();
        }
    }
}
