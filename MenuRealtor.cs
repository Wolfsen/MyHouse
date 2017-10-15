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

namespace MyHouse
{
    public partial class MenuRealtor : Form
    {
        public MenuRealtor()
        {
            InitializeComponent();
        }

        private void MenuRealtor_Load(object sender, EventArgs e)
        {
            //label1    Color.FromArgb(59,160,232);
            butClients.FlatAppearance.BorderSize = 0;
            butRealty.FlatAppearance.BorderSize = 0;
            butDeal.FlatAppearance.BorderSize = 0;
            butExit.FlatAppearance.BorderSize = 0;
            GraphicsPath Button_Path = new GraphicsPath();
            Region Button_Region = new Region(RoundedRect(new Rectangle(0, 0, butClients.Width, butClients.Height), 10));
            butClients.Region = Button_Region;
            butRealty.Region = Button_Region;
            butDeal.Region = Button_Region;
            butExit.Region = Button_Region;
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

        private void butExit_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Close();
        }

        private void butClients_Click(object sender, EventArgs e)
        {
            BaseClient bc = new BaseClient();
            bc.SetEmail(Usersmail.Text);
            bc.Show();
            this.Hide();
        }

        private void butRealty_Click(object sender, EventArgs e)
        {
            BaseRealty br = new BaseRealty();
            br.SetEmail(Usersmail.Text);
            br.Show();
            this.Hide();
        }

        private void butDeal_Click(object sender, EventArgs e)
        {
            BaseDeal bd = new BaseDeal();
            bd.SetEmail(Usersmail.Text);
            bd.Show();

            this.Hide();
        }
    }
}
