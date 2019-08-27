using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;

namespace RestClientApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            // クライアント＆リクエストの作成
            var client = new RestClient();
            var request = new RestRequest();

            // URLの設定
            client.BaseUrl = new Uri("http://localhost:8080/json");

            // メソッド、パラメータの指定
            request.Method = Method.POST;
            //request.AddParameter("パラメータ名", "パラメータの値", ParameterType.GetOrPost);
            request.AddParameter("application/json", "body", ParameterType.RequestBody);
            // Authorization: Basic Zm9vOmJhcg==
            // ParameterTypeはいろいろあるが、GETとPOSTで特に指定なく
            // stringパラメータを設定する場合は、GetOrPost

            // ファイルをアップロードする場合
            //request.AddFile("ファイルパラメータ名", "ファイルパス", "ContentType");
            // ContentTypeは拡張子などから適切なものを選ぶ

            // リクエスト送信
            var response = client.Execute(request);

            // レスポンスがファイルなどで、復元したい場合
            //File.WriteAllBytes("出力先のパス", response.RawBytes);

            // レスポンスのステータスコードが欲しいなどの場合
            bool isOK = response.StatusCode == HttpStatusCode.OK;
            // ステータスコード以外にも様々な情報がresponseに入っているので適宜

            //Console.WriteLine(response);

            textBox1.Text = response.Content;

        }
    }
}
