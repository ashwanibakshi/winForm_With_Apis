using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace winForm_With_Apis
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = connect();
            HttpResponseMessage response = client.GetAsync("api/demo").Result;
            addData(response);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
                HttpClient client = connect();
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name",textBox1.Text),
                new KeyValuePair<string, string>("age", textBox2.Text)
            });
   
            HttpResponseMessage response = client.PostAsync("api/add",formContent).Result;
            addData(response);

            textBox1.Text = "";
            textBox2.Text = "";
        }
        public void addData(HttpResponseMessage response)
        {
            var dataa = response.Content.ReadAsStringAsync();
            dynamic x = JsonConvert.DeserializeObject(dataa.Result);
            dataGridView1.DataSource = x.data;
        }

        private HttpClient connect()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:3000");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
