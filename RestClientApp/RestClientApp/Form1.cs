using Codeplex.Data;
using Newtonsoft.Json;
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
using System.Windows.Forms;

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
            UrlList.DataSource = ReadURLList();
            Enumerable.Range(1, 5).ToList().ForEach(x => AddHeaderPanel());
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {          
            var request = new HttpRequestMessage(HttpMethod.Post, UrlList.Text);
            string contenType = @"application/json";

            // リクエストヘッダの設定
            for (int i = 0; i < HeadersAreaPanel.Controls.Count; i++)
            {
                var key = HeadersAreaPanel.Controls[i].Controls[0].Text;
                var value = HeadersAreaPanel.Controls[i].Controls[1].Text;

                if (!key.Contains("Content-Type")) { 
                    if(!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                    request.Headers.Add(key,value);
                }
                else
                {
                    contenType = value;
                }
            }

            // リクエストボディの設定
            var json = @"{""foo"":""hoge"", ""bar"":123, ""baz"":[""あ"", ""い"", ""う""]}";
            //request.Content = new StringContent(json, Encoding.UTF8, @"application/json");
            request.Content = new StringContent(json, Encoding.UTF8, contenType);

            // 送信
            var response = await client.SendAsync(request);

            // 結果の表示
            this.HttpStatus.Text = ((int)response.StatusCode).ToString() + $" {response.StatusCode}";
            var responseContent =  Regex.Unescape(response.Content.ReadAsStringAsync().Result);
            this.Result.Text = PareseJson(responseContent);
        }

        /// <summary>
        /// レスポンスボディをJSONにパースします。
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private string PareseJson(string responseContent)
        {
            try
            { 
                var parsedJson = JsonConvert.DeserializeObject(responseContent);
                return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            }
            catch (JsonReaderException ex)
            {
                // jsonparseエラーが発生した場合はレスポンスボディをそのまま返却
                Console.WriteLine(ex.StackTrace);
                return responseContent;
            }
        }

        /// <summary>
        /// +ボタン押下時処理です。
        /// KeyTextBox,ValueTextBox,DeleteButtonが配置されたHedarPanelを追加します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlusButton_Click(object sender, EventArgs e)
        {
            AddHeaderPanel();
        }

        private void AddHeaderPanel()
        {
            AddedHeaderIndex++;

            Panel headerPanel = new Panel()
            {
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
            HeadersAreaPanel.Controls.RemoveByKey(((Button)sender).Parent.Name);
            relocateHeaderPanel();
        }

        /// <summary>
        /// HeaderPanelの位置を再配置します。
        /// </summary>
        private void relocateHeaderPanel()
        {
            // LINQ版
            //HeadersAreaPanel.Controls.Cast<Control>().ToList().ForEach(x => {
            //    x.Top = 
            //};

            for(int i = 0; i  < HeadersAreaPanel.Controls.Count; i++)
            {
                HeadersAreaPanel.Controls[i].Top = i * 20;
            }
        }

        private string[] ReadURLList()
        {
            var path = @"./urllist.txt";
            Console.WriteLine(System.Environment.CurrentDirectory);
            if (File.Exists(path))
            {
                //ここにファイルIO処理を記述する
                return File.ReadLines(path).ToArray();
            }
            return new string[0];
        }
    }
}
