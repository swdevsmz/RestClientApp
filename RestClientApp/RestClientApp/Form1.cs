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

        private int AddedHeaderIndex = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Url.Text = "http://weather.livedoor.com/forecast/webservice/json/v1?city=400040";
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {          
            var request = new HttpRequestMessage(HttpMethod.Get, Url.Text);

            for(int i = 0; i < HeadersAreaPanel.Controls.Count; i++)
            {
                Console.WriteLine($"【key】{HeadersAreaPanel.Controls[i].Controls[0].Text}【value】{HeadersAreaPanel.Controls[i].Controls[1].Text}"); 
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

        /// <summary>
        /// +ボタン押下時処理です。
        /// KeyTextBox,ValueTextBox,DeleteButtonが配置されたHedarPanelを追加します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlusButton_Click(object sender, EventArgs e)
        {

            AddedHeaderIndex++;

            Panel headerPanel = new Panel() {
                Width = 300,
                Height = 20,
                Name = $"HeaderPanel{AddedHeaderIndex}",
            };

            TextBox keyTextBox = new TextBox()
            {
                Width = 100,
                Height = 30,
                Top = 0,
                Left = 0,
                Name = $"KeyTextBox{AddedHeaderIndex}"
            };
            TextBox valueTextBox = new TextBox()
            {
                Width = 100,
                Height = 30,
                Top = 0,
                Left = 110,
                Name = $"valueTextBox{AddedHeaderIndex}"
            };

            Button deleteButton = new Button()
            {
                Width = 20,
                Height = 20,
                Top = 0,
                Left = 220,
                Text = "－",
                Name = $"DeleteButton{AddedHeaderIndex}",
            };
            deleteButton.Click += DeleteButton_Click;

            headerPanel.Controls.Add(keyTextBox);
            headerPanel.Controls.Add(valueTextBox);
            headerPanel.Controls.Add(deleteButton);
            HeadersAreaPanel.Controls.Add(headerPanel);

            this.relocateHeaderPanel();

        }

        /// <summary>
        /// 削除ボタン押下時処理です。
        /// ボタン名からaddheaderIndexを取得し,対応するHeaderPanelを削除します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int addedHeaderIndex = int.Parse(((Button)sender).Name.Replace("DeleteButton", ""));
            HeadersAreaPanel.Controls.RemoveByKey($"HeaderPanel{addedHeaderIndex}");
            relocateHeaderPanel();
        }

        /// <summary>
        /// HeaderPanelの位置を再配置します。
        /// </summary>
        private void relocateHeaderPanel()
        {
            for(int i = 0; i  < HeadersAreaPanel.Controls.Count; i++)
            {
                HeadersAreaPanel.Controls[i].Top = i * 20;
            }
        }
    }
}
