using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;

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
    }
    }

