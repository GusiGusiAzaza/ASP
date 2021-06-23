using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinClient
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient Client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var dictionary = new Dictionary<string, string> { { "x_value", textBox1.Text }, { "y_value", textBox2.Text } };
            var content = new FormUrlEncodedContent(dictionary);
            var response = await Client.PostAsync("http://172.16.193.234:44115/asp1/sum", content);
            resultLabel.Text = await response.Content.ReadAsStringAsync();
        }
    }
}
