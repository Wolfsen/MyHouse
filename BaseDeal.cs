using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace MyHouse
{
    public partial class BaseDeal : Form
    {
        public BaseDeal()
        {
            InitializeComponent();
        }
        const string _myConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database2.mdf;Integrated Security = True";
        SqlConnection _fConDb = new SqlConnection(_myConn);
        SqlCommand cmd = new SqlCommand();
        DataTable dt;
        SqlDataAdapter da;
        BindingSource bs;
        private void BaseDeal_Load(object sender, EventArgs e)
        {
            butDeal.FlatAppearance.BorderSize = 0;
            butFilter.FlatAppearance.BorderSize = 0;
            butPrint.FlatAppearance.BorderSize = 0;
            butBack.FlatAppearance.BorderSize = 0;
            GraphicsPath Button_Path = new GraphicsPath();
            Region Button_Region = new Region(RoundedRect(new Rectangle(0, 0, butFilter.Width, butFilter.Height), 10));
            butFilter.Region = Button_Region;
            Region Button_Region2 = new Region(RoundedRect(new Rectangle(0, 0, butPrint.Width, butPrint.Height), 10));
            butPrint.Region = Button_Region2;
            butDeal.Region = Button_Region2;
            butBack.Region = Button_Region2;
            InitDateDeal();

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

        private void butBack_Click(object sender, EventArgs e)
        {
            MenuRealtor mr = new MenuRealtor();
            mr.Show();
            this.Close();
        }

        private void butDeal_Click(object sender, EventArgs e)
        {
            AddDeal ad = new AddDeal();
            ad.ShowDialog();
        }
        DataView dv;
        public void InitDateDeal()
        {

            string sql = "SELECT descriptionType, description, price, dataOfDeal, FirstName FROM ((((Realty inner join Deal on Deal.Id_realty=Realty.Id_Realty)inner join Services.Id_Services=Deal.Id_services) inner join Property_Type on Property_Type.Id_PropertyType=Realty.Id_PropertyType) inner join Clients on Clients.Id_Client=Realty.client";
            da = new SqlDataAdapter(sql, _fConDb);
            dt = new DataTable();
            _fConDb.Open();
            da.Fill(dt);
            _fConDb.Close();
            dgvDeal.DataSource = dt;
            dv = new DataView(dt);
        }
        private void butFilter_Click(object sender, EventArgs e)
        {
            dv.RowFilter = string.Format("dataOfDeal BETWEEN '" + dateTimePickerFrom.Value.Date + "' AND '" + dateTimePickerTo.Value.Date + "'");
            dgvDeal.DataSource = dv;
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            var pd = new PrintDocument();
            pd.PrintPage += (s, q) =>
            {
                var bmp = new Bitmap(dgvDeal.Width, dgvDeal.Height);
                dgvDeal.DrawToBitmap(bmp, dgvDeal.ClientRectangle);
                q.Graphics.DrawImage(bmp, new Point(100, 100));
            };
            pd.Print();
        }

    }
}

