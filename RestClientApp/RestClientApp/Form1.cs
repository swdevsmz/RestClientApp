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
            var request = new HttpRequestMessage(HttpMethod.Post, Url.Text);
            
            // リクエストヘッダー情報の設定
            // Content-typeはContentの第3引数で設定
            //request.Headers.Add("ContentType", "application/json; charset=utf-8");
            //request.Headers.Add("Content-Type", "MIME-Type-Here");
            request.Headers.Add("Authorization", "Bearer " + "12345678");
            request.Headers.Add("User-Agent", "User-Agent-Here");
            request.Headers.Add("AAAA", "User-Agent-Here");

            // リクエストボディ情報の設定
            var json = @"{""foo"":""hoge"", ""bar"":123, ""baz"":[""あ"", ""い"", ""う""]}";
            request.Content = new StringContent(json, Encoding.UTF8, @"application/json");

            // 送信
            var response = await client.SendAsync(request);

            // 結果の表示
            this.HttpStatus.Text = ((int)response.StatusCode).ToString();
            this.Result.Text = Regex.Unescape(response.Content.ReadAsStringAsync().Result);

        }


    }
}
