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
        const string _myConn = "Data Source=HOUMPC\\HOUMPC;Initial Catalog=MyHouse;Integrated Security=SSPI";
        //const string _myConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database2.mdf;Integrated Security = True";
        SqlConnection _fConDb = new SqlConnection(_myConn);
        SqlCommand cmd = new SqlCommand();
        DataTable dt;
        SqlDataAdapter da;
        BindingSource bs;

        public void SetEmail(string email)
        {
            this.Tag = email;
        }
        int flagClient = 0;
        public int FlagClient
        {
            get
            {
                return flagClient;
            }
            set
            {
                flagClient = value;
            }
        }
        public int GetEmailClient()
        {
            string sql = "SELECT Id_Client FROM Clients Where email='"+ this.Tag.ToString() +"'";
            da = new SqlDataAdapter(sql, _fConDb);
            dt = new DataTable();
            _fConDb.Open();
            da.Fill(dt);
            int count = dt.Rows.Count;
            _fConDb.Close();
            return count;
        }
        public int GetIdClient()
        {
            string sql = "SELECT Id_Client FROM Clients Where email='" + this.Tag.ToString() + "'";
            da = new SqlDataAdapter(sql, _fConDb);
            dt = new DataTable();
            _fConDb.Open();
            da.Fill(dt);
            int count = Convert.ToInt32(dt.Rows[0][0]);
            _fConDb.Close();
            return count;
        }
        public int GetIdRealtor()
        {
            string sql = "SELECT Id FROM Realtor Where email='" + this.Tag.ToString() + "'";
            da = new SqlDataAdapter(sql, _fConDb);
            dt = new DataTable();
            _fConDb.Open();
            da.Fill(dt);
            int count = Convert.ToInt32(dt.Rows[0][0]);
            _fConDb.Close();
            return count;
        }
        private void BaseDeal_Load(object sender, EventArgs e)
        {
            dgvDeal.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 160, 232);
            butDeal.FlatAppearance.BorderSize = 0;
            butFilter.FlatAppearance.BorderSize = 0;
            butPrint.FlatAppearance.BorderSize = 0;
            butBack.FlatAppearance.BorderSize = 0;
            GraphicsPath Button_Path = new GraphicsPath();
            Region Button_Region = new Region(RoundedRect(new Rectangle(0, 0, butDeal.Width, butFilter.Height), 10));
            butDeal.Region = Button_Region;
            Region Button_Region2 = new Region(RoundedRect(new Rectangle(0, 0, butPrint.Width, butPrint.Height), 10));
            butPrint.Region = Button_Region2;
            butFilter.Region = Button_Region2;
            butBack.Region = Button_Region2;
           
            FlagClient = GetEmailClient();
            InitDataDeal();
            if (FlagClient>0)
            {
                butDeal.Visible = false;
                label1.Text = "Мои сделки";
            }

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
            if (FlagClient > 0)
            {
                MenuClient mc = new MenuClient();
                mc.SetEmail(this.Tag.ToString());
                mc.Show();
                this.Close();
            }
            else
            {
                MenuRealtor mr = new MenuRealtor();
                mr.Show();
                this.Close();
            }
        }

        private void butDeal_Click(object sender, EventArgs e)
        {
            AddDeal ad = new AddDeal();
            ad.SetEmail(this.Tag.ToString());
            ad.ShowDialog();
        }
        public void InitDataDeal()
        {
            string sql = "";
            if (FlagClient > 0)
            {
                butDeal.Visible = false;
                label1.Text = "Мои сделки";

                sql = "SELECT descriptionType, description, price, dateOfDeal, (FirstName+' '+LastName+' '+Patronymic) as FIO FROM ((((Realty inner join Deal on Deal.Id_realty=Realty.Id_Realty)inner join Services on Services.Id_Services=Deal.Id_services) inner join Property_Type on Property_Type.Id_PropertyType=Realty.Id_PropertyType) inner join Clients on Clients.Id_Client=Realty.client) Where Realty.client=" + GetIdClient();
            }
            else
                sql = "SELECT descriptionType, description, price, dateOfDeal, (FirstName+' '+LastName+' '+Patronymic) as FIO FROM ((((Realty inner join Deal on Deal.Id_realty=Realty.Id_Realty)inner join Services on Services.Id_Services=Deal.Id_services) inner join Property_Type on Property_Type.Id_PropertyType=Realty.Id_PropertyType) inner join Clients on Clients.Id_Client=Realty.client) Where Deal.Id_realtor=" + GetIdRealtor();

            da = new SqlDataAdapter(sql, _fConDb);
            dt = new DataTable();
            _fConDb.Open();
            da.Fill(dt);
            _fConDb.Close();
            dgvDeal.DataSource = dt;
        }
        private void butFilter_Click(object sender, EventArgs e)
        {
            string dateInIsoFormat1 = dateTimePickerFrom.Value.ToString("yyyyMMdd HH:mm:ss");
            string dateInIsoFormat2 = dateTimePickerTo.Value.ToString("yyyyMMdd HH:mm:ss");
            string sql = "SELECT descriptionType, description, price, dateOfDeal, (FirstName+' '+LastName+' '+Patronymic) as FIO  FROM ((((Realty inner join Deal on Deal.Id_realty=Realty.Id_Realty)inner join Services on Services.Id_Services=Deal.Id_services) inner join Property_Type on Property_Type.Id_PropertyType=Realty.Id_PropertyType) inner join Clients on Clients.Id_Client=Realty.client) Where   Deal.Id_realtor=" + GetIdRealtor() + " AND dateOfDeal BETWEEN '" + dateInIsoFormat1 + "' AND '" + dateInIsoFormat2 + "' " ;
            da = new SqlDataAdapter(sql, _fConDb);
            dt = new DataTable();
            _fConDb.Open();
            da.Fill(dt);
            _fConDb.Close();
            dgvDeal.DataSource = dt;
            dgvDeal.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 160, 232);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BaseDeal_Activated(object sender, EventArgs e)
        {
            InitDataDeal();
        }
    }
}

