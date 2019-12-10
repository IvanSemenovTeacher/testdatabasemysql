/*
 * Created by SharpDevelop.
 * User: Преподаватель
 * Date: 05.12.2019
 * Time: 14:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.Sockets;
using System.Data;
namespace testbd
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		MySqlConnection connection;
		void Button1Click(object sender, EventArgs e)
		{
			string tablename = textBox1.Text;
			string connect ="server=192.168.8.100;database="+tablename+";port=3306;user id=root;password=123Qq_123;SSL mode = none";
			connection = new MySqlConnection(connect);
			try
			{
				connection.Open();
				button1.BackColor = Color.GreenYellow;
				
				MySqlCommand com = new MySqlCommand("show tables;",connection);
				MySqlDataReader reader = com.ExecuteReader();
				while(reader.Read())
				{
					listBox1.Items.Add(reader.GetValue(0).ToString());
				}
				reader.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			string tablename = listBox1.SelectedItem.ToString();
			MySqlCommand com = new MySqlCommand("select * from "+tablename,connection);
			DataTable table = new DataTable();
			table.Load(com.ExecuteReader());
			dataGridView1.DataSource = table;
		}
		
		void Button2Click(object sender, EventArgs e)
		{
string sql = textBox2.Text;
MySqlCommand com = new MySqlCommand(sql,connection);

DataTable table = new DataTable();
			table.Load(com.ExecuteReader());
			dataGridView1.DataSource = table;
		}
	}
}
