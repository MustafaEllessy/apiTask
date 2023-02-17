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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace apiTask
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public static async Task<string> Post(string name)
        {
            var data = new Dictionary<string, string>
            {
                { "name", name},
         
            };
            var input = new FormUrlEncodedContent(data);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsync(token , input))
                {
                    using (HttpContent content = res.Content)

                    {
                        string localData = await content.ReadAsStringAsync();
                        if (localData != null)
                        {
                            return localData;
                        }


                    }
                }
            }
            return string.Empty;
        }
      static  string token = "";
        private async void btnSave_Click(object sender, EventArgs e)
        {
            token = txtToken.Text;
            var response = await Post(txtName.Text);
            JToken parseJson = JToken.Parse(response);
            string finalRes = parseJson.ToString();
            MessageBox.Show(finalRes);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
