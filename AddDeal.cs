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

        //const string _myConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database2.mdf;Integrated Security = True";
        const string _myConn = "Data Source=HOUMPC\\HOUMPC;Initial Catalog=MyHouse;Integrated Security=SSPI";

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
        public void SetEmail(string email)
        {
            this.Tag = email;
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
            string sql = "SELECT * FROM Realty where status='' or status is NULL";
            da = new SqlDataAdapter(sql, _fConDb);
            dt = new DataTable();
            _fConDb.Open();
            da.Fill(dt);
            dt.Columns.Add("realty");
              for(int i=0; i<dt.Rows.Count;i++)
            {
             dt.Rows[i][16] = (dt.Rows[i][11].ToString() +","+ dt.Rows[i][12].ToString()+","+ dt.Rows[i][13].ToString()+","+ dt.Rows[i][14].ToString());
            }
            bs = new BindingSource();
            bs.DataSource = dt;
            cbRealty.DataSource = bs;

        


            cbRealty.DisplayMember = "realty";




            cbRealty.ValueMember = "Id_Realty";
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
           
        }

        private int GetIdRealtor()
        {
           string sql = "SELECT Id FROM Realtor where email='"+this.Tag.ToString()+"'";
            da = new SqlDataAdapter(sql, _fConDb);
            dt = new DataTable();
            _fConDb.Open();
            da.Fill(dt);
            _fConDb.Close();
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        private void UppdateRealty()
        {
            cmd.Connection = _fConDb;
            _fConDb.Open();
            cmd.CommandText = "Update Realty Set status =N'"+cbDeal.Text+"', price='"+Convert.ToInt32(tbPrice.Text)+ "' where Id_Realty='"+idTypeRealty+"'";
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
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            if (tbPrice.Text != "")
            {
                if (Convert.ToInt32(tbPrice.Text) <= 0)
                {
                    tbPrice.Clear();
                    MessageBox.Show("Не корректный ввод цены", "Ошибка");
                }
                else
                {
                    int idrealtor = GetIdRealtor();
                    cmd.Connection = _fConDb;
                    _fConDb.Open();
                    cmd.CommandText = "Insert into Deal (Id_realty,Id_realtor,Id_services,dateOfDeal) values('" + idTypeRealty + "','" + idrealtor + "','" + idDeal + "','" + dateTimePickerTo.Value.ToString("yyyyMMdd HH:mm:ss") + "')";
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
                    UppdateRealty();
                    MessageBox.Show("Сделка успешно заключена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    butAdd.Enabled = false;
                    this.Close();
                }
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

