using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using Newtonsoft.Json;
using static BitBucketBrowser.JsonSchema;

namespace BitBucketBrowser
{
    public partial class Form1 : Form
    { 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            string jsonString = Get("").Result;
            Root<Project> r = JSONStringToObject<Project>(jsonString);
            foreach (Project p in r.values)
            {
                treeView1.Nodes[0].Nodes.Add(new TreeNode(p.name));
            }
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            string jsonString = Get("").Result;
            Root<Project> r = JSONStringToObject<Project>(jsonString);
            foreach (Project p in r.values)
            {
                treeView1.Nodes[0].Nodes.Add(new TreeNode(p.name));
            }
            */
            test();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private async void test()
        {
            HttpClient client = new HttpClient();
            //string auth = string.Empty;
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty)
            {
                string auth = textBox1.Text + ":" + textBox2.Text;
                byte[] authentic = Encoding.ASCII.GetBytes(auth);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authentic));
            }
            client.BaseAddress = new Uri(Properties.Settings.Default.baseURL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(Properties.Settings.Default.baseAPI);
            if (response.IsSuccessStatusCode)
            {
                Task<string> dataObjects = response.Content.ReadAsStringAsync();
                Root<Project> t = JsonConvert.DeserializeObject<Root<Project>>(dataObjects.Result);
                foreach (Project p in t.values)
                {
                    treeView1.Nodes[0].Nodes.Add(new TreeNode(p.name));
                    Console.WriteLine(p.links.self[0].href);
                }
                //Console.Write(t.values[0].key);
                Console.WriteLine(dataObjects.Result);

            }
            else
            {
                Console.WriteLine("nope");
            }
            client.Dispose();
        }

        private async Task<string> Get(string url)
        {
            Task<string> returnTask = null;
            HttpClient client = new HttpClient();
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty)
            {
                string auth = textBox1.Text + ":" + textBox2.Text;
                byte[] authentic = Encoding.ASCII.GetBytes(auth);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authentic));
            }
            client.BaseAddress = new Uri(Properties.Settings.Default.baseURL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(Properties.Settings.Default.baseAPI);
            if (response.IsSuccessStatusCode)
            {
                returnTask = response.Content.ReadAsStringAsync();
            }
            else
            {
                Console.WriteLine("nope");
            }
            client.Dispose();
            return await returnTask;
        }

        public Root<T> JSONStringToObject<T>(string JSONString)
        {
            return JsonConvert.DeserializeObject<Root<T>>(JSONString);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            /*
            string jsonString = Get("").Result;
            Root<Project> r = JSONStringToObject<Project>(jsonString);
            foreach (Project p in r.values)
            {
                treeView1.Nodes[0].Nodes.Add(new TreeNode(p.name));
            }
            */
        }
    }
}
