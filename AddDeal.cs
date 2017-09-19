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

namespace MyHouse
{
    public partial class AddDeal : Form
    {
        public AddDeal()
        {
            InitializeComponent();
        }
        const string _myConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database2.mdf;Integrated Security = True";
        SqlConnection _fConDb = new SqlConnection(_myConn);
        SqlCommand cmd = new SqlCommand();
        DataTable dt;
        SqlDataAdapter da;
        BindingSource bs;
        int idTypeRealty=0;
        int idDeal=0;
        private void AddDeal_Load(object sender, EventArgs e)
        {
            butAdd.FlatAppearance.BorderSize = 0;
            butBack.FlatAppearance.BorderSize = 0;
            GraphicsPath Button_Path = new GraphicsPath();
            Region Button_Region = new Region(RoundedRect(new Rectangle(0, 0, butAdd.Width, butAdd.Height), 10));
            butAdd.Region = Button_Region;
            butBack.Region = Button_Region;
            InitDate();
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
            this.Close();
        }
        public void InitDate()
        {
            string sql = "SELECT * FROM Property_Type";
            da = new SqlDataAdapter(sql, _fConDb);
            dt = new DataTable();
            _fConDb.Open();
            da.Fill(dt);
            bs = new BindingSource();
            bs.DataSource = dt;
            cbRealty.DataSource = bs;
            cbRealty.DisplayMember = "descriptionType";
            cbRealty.ValueMember = "Id_PropertyType";
            _fConDb.Close();

            sql = "SELECT * FROM Services";
            da = new SqlDataAdapter(sql, _fConDb);
            dt = new DataTable();
            _fConDb.Open();
            da.Fill(dt);
            bs = new BindingSource();
            bs.DataSource = dt;
            cbDeal.DataSource = bs;
            cbDeal.DisplayMember = "description";
            cbDeal.ValueMember = "Id_Services";
            _fConDb.Close();
        }
        private void tbPrice_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbPrice.Text) <= 0)
            {
                tbPrice.Clear();
                MessageBox.Show("Не корректный ввод цены", "Ошибка");
            }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            if (tbPrice.Text != "")
            {
                cmd.Connection = _fConDb;
                _fConDb.Open();
               // cmd.CommandText = "Insert into Deal (FIO ,Passport,WhomGiven,WhenGiven,Address,IdPosition) values('" + tbFIO.Text + "','" + tbSeria.Text + "','" + tbWhom.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + tbAddress.Text + "','" + IdPos + "')";
                try
                {
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Ошибка:\r\n" + exc.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    _fConDb.Close();
                }
                MessageBox.Show("Сделка успешно заключена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                butAdd.Enabled = false;
                this.Owner.Show();
                this.Close();
            }
            else MessageBox.Show("Не все поля заполнены!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void cbRealty_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbRealty.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                idTypeRealty = Convert.ToInt32(cbRealty.SelectedValue);
            }
        }

        private void cbDeal_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbDeal.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                idDeal = Convert.ToInt32(cbDeal.SelectedValue);
            }
        }
    }
}

