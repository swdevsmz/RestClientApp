using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;

namespace RestClientApp
{
    public partial class Form1 : Form
    {

        private static HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Text = "http://weather.livedoor.com/forecast/webservice/json/v1?city=400040";
        }


        private async void Button1_Click(object sender, EventArgs e)
        {
            //var response = await client.GetAsync(textBox2.Text);
            
            var request = new HttpRequestMessage(HttpMethod.Get, textBox2.Text);
            request.Headers.Add("ContentType", "application/json; charset=utf-8");
            //request.Headers.Add("Authorization", "Bearer " + "");
            //request.Headers.Add("Content-type", "text/html; charset=UTF-8");
            var response = await client.SendAsync(request);
            //Console.WriteLine(response.StatusCode);
            //var content = await response.Content.ReadAsByteArrayAsync();
            //var encoding = Encoding.ASCII;
            //this.textBox1.Text = encoding.GetString(content);
            //var content = await response.Content.ReadAsStringAsync();
            //string s = await UTF8ResponseMessageAsync(response);

            //var str = System.Text.Encoding.UTF8.GetString(await response.Content.ReadAsStringAsync());

            this.textBox1.Text = Regex.Unescape(response.Content.ReadAsStringAsync().Result);

            //this.textBox1.Text = str;
        }

        private async Task<string> UTF8ResponseMessageAsync(HttpResponseMessage result)
        {
            //str = System.Text.Encoding.UTF8.GetString(bytesData);

            byte[] isoBites = Encoding.GetEncoding("ISO-8859-1").GetBytes(Regex.Unescape(await result.Content.ReadAsStringAsync()));
            return Encoding.UTF8.GetString(isoBites, 0, isoBites.Length);
        }


    }
}
