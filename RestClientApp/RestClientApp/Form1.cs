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
            Url.Text = "http://weather.livedoor.com/forecast/webservice/json/v1?city=400040";
        }

        private async void Send_Click(object sender, EventArgs e)
        {          
            var request = new HttpRequestMessage(HttpMethod.Get, Url.Text);

            for(int i = 1; i <= panel1.Controls.Count / 2; i++)
            {
                MessageBox.Show(panel1.Controls.Find($"Key{i}", false)[0].Text + panel1.Controls.Find($"Value{i}", false)[0].Text);
            }

            // リクエストヘッダの設定
            //request.Headers.Add("Authorization", "Bearer " + "12345678");
            //request.Headers.Add("User-Agent", "User-Agent-Here");
            //request.Headers.Add("AAAA", "User-Agent-Here");
            // リクエストボディの設定
            //var json = @"{""foo"":""hoge"", ""bar"":123, ""baz"":[""あ"", ""い"", ""う""]}";
            //request.Content = new StringContent(json, Encoding.UTF8, @"application/json");

            // 送信
            var response = await client.SendAsync(request);

            // 結果の表示
            this.HttpStatus.Text = ((int)response.StatusCode).ToString();
            this.Result.Text = Regex.Unescape(response.Content.ReadAsStringAsync().Result);
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            TextBox key   = new TextBox();
            TextBox value = new TextBox();

            key.Width = value.Width = 180;
            key.Height = value.Height = 24;
            key.Top = value.Top = 10 + (15 * panel1.Controls.Count);
            key.Left = 10;
            value.Left = key.Left + key.Width + 10;
            key.Name = "Key" + (panel1.Controls.Count / 2 + 1);
            value.Name = "Value" + (panel1.Controls.Count / 2 + 1);

            this.panel1.Controls.Add(key);
            this.panel1.Controls.Add(value);
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            if (this.panel1.Controls.Count == 0) return;

            this.panel1.Controls.RemoveAt(panel1.Controls.Count - 1);
            this.panel1.Controls.RemoveAt(panel1.Controls.Count - 1);
        }
    }
}
