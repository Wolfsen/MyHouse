﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyHouse
{
    public partial class AddRealtyClient : Form
    {
        public AddRealtyClient()
        {
            InitializeComponent();
        }
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database2.mdf;Integrated Security = True;";
        SqlConnection connection = new SqlConnection(connectionString);
        DataTable dt;

        private void AddRealtyClient_Load(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(59, 160, 232);
            button3.BackColor = Color.FromArgb(59, 160, 232);
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            GraphicsPath Button_Path = new GraphicsPath();
            Region Button_Region = new Region(RoundedRect(new Rectangle(0, 0, button2.Width, button2.Height), 10));
            button2.Region = Button_Region;
            button3.Region = Button_Region;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 160, 232);
            dataGridView1.BackgroundColor = Color.FromArgb(162, 136, 234);
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(162, 136, 234);
            dataGridView1.Rows.Add();


            CBInfo();

          
                   
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
            this.Close();
        }

        private void CBInfo()
        {
            ///вид недвижимости
            string sql = "Select descriptionType From Property_Type";
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            connection.Open();
            dt = new DataTable();
            dataadapter.Fill(dt);
            connection.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                (dataGridView1.Rows[0].Cells[0] as DataGridViewComboBoxCell).Items.Add(dt.Rows[i][0]);
            }
            ////тип объекта
            sql = "Select descriptionHouse From House_Type";
             dataadapter = new SqlDataAdapter(sql, connection);
            connection.Open();
            dt = new DataTable();
            dataadapter.Fill(dt);
            connection.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                (dataGridView1.Rows[0].Cells[1] as DataGridViewComboBoxCell).Items.Add(dt.Rows[i][0]);
            }

            ////вид объекта
            sql = "Select descriptionObject From Object";
            dataadapter = new SqlDataAdapter(sql, connection);
            connection.Open();
            dt = new DataTable();
            dataadapter.Fill(dt);
            connection.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                (dataGridView1.Rows[0].Cells[2] as DataGridViewComboBoxCell).Items.Add(dt.Rows[i][0]);
            }

            }
    }
}
