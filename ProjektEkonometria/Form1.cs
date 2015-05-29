﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektEkonometria
{
    public partial class Form1 : Form
    {
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        OleDbDataAdapter adapter = new OleDbDataAdapter();

        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }
        
        private void getExelY_Click(object sender, EventArgs e)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(path, "daneY.ods");
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path +
                                      @";Extended Properties=""Excel 8.0;HDR=YES;""";
            OleDbConnection conn = new OleDbConnection(connectionString);
            string strCmd = "select * from [Arkusz1$A1:A27]";
            OleDbCommand cmd = new OleDbCommand(strCmd, conn);
            try
            {
                conn.Open();
                ds2.Clear();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds2);
                dataGridView2.DataSource = ds2.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                conn.Close();
            }

        }

        private void getExelX_Click(object sender, EventArgs e)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(path, "daneX.ods");
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path +
                                      @";Extended Properties=""Excel 8.0;HDR=YES;""";
            OleDbConnection conn = new OleDbConnection(connectionString);
            string strCmd = "select * from [Arkusz1$A1:D27]";
            OleDbCommand cmd = new OleDbCommand(strCmd,conn);
            try
            {
                conn.Open();
                ds.Clear();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                conn.Close();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}