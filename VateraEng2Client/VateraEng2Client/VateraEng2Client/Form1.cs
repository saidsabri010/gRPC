using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grpc.Core;
using Grpc.Net.Client;
using VateraEng2;
using VateraEng2Client;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace VateraEng2Client
{
    public partial class Form1 : Form
    {
        GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:5001");
        Vatera.VateraClient client;
        string uid = null;
        MySqlConnection sqlcon =
        new MySqlConnection("datasource=localhost;port=3306;AllowUserVariables=True;database=api_data;username=root;password=");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new Vatera.VateraClient(channel);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User(); user.Name = textBox1.Text; user.Passwd = textBox2.Text;
            Session_Id tempuid = client.Login(user); //remote procedure call
            label1.Text = tempuid.ToString();
            string temp = tempuid.ToString();
            uid = temp.Substring(9, 36);

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (var call = client.Display(new Empty { }))
            {

                while (await call.ResponseStream.MoveNext())
                {
                    sqlcon.Open();

                    string query1 = "SELECT * FROM cars";
                    MySqlCommand cmd = new MySqlCommand(query1, sqlcon);
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    sqlcon.Close();

                    foreach (DataRow item in dt.Rows)
                    {

                        listBox1.Items.Add(" name is :" + item[0].ToString() + ",model : " + item[1].ToString() + ",price : " + item[2].ToString());

                    }
                    Data2 cars = call.ResponseStream.Current;
                    listBox1.Items.Add(cars.Items);
                    listBox1.BackColor = Color.WhiteSmoke;
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Data data = new Data();
            data.Model = textBox3.Text; data.Name = textBox4.Text; 
            data.Price = int.Parse(textBox5.Text);
            data.Uid = uid;
            Result res = client.Add(data);   //remote procedure call
           
            label1.Text = res.ToString();
          

        }
        private void button10_Click(object sender, EventArgs e)
        {
            Data data = new Data();
            data.Model = textBox6.Text; data.Name = textBox7.Text;
            data.Price = int.Parse(textBox9.Text);
            data.Uid = uid;
            Result res = client.Update(data);
            label1.Text = res.ToString();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Data p = new Data();
            p.Model = textBox8.Text;
            p.Uid = uid;
            Result res = client.Delete(p);
            label1.Text = res.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Data data = new Data();
            //data.Code = textBox6.Text; data.Uid = uid;
            //data.Price = int.Parse(textBox7.Text);
            //Result ered = client.Bid(data);
            //label1.Text = ered.ToString();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Session_Id id = new Session_Id();
            id.Id = button5.Text;
            Result tempuid = client.Logout(id);
            label1.Text = tempuid.ToString();
            string temp = tempuid.ToString();
            uid = temp.Substring(0, 0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void Buy_Click(object sender, EventArgs e)
        {
            //Data data = new Data();
            //data.Code = textBox6.Text; data.Uid = uid;
            //data.Price = int.Parse(textBox7.Text);
            //Result ered = client.Bid(data);
            //label1.Text = ered.ToString();
        }
    }
}
