namespace RestClientApp
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.SendButton = new System.Windows.Forms.Button();
            this.Result = new System.Windows.Forms.TextBox();
            this.UrlList = new System.Windows.Forms.ComboBox();
            this.HttpStatus = new System.Windows.Forms.TextBox();
            this.HeadersAreaPanel = new System.Windows.Forms.Panel();
            this.PlusButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(951, 16);
            this.SendButton.Margin = new System.Windows.Forms.Padding(4);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(100, 29);
            this.SendButton.TabIndex = 0;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // Result
            // 
            this.Result.Location = new System.Drawing.Point(17, 275);
            this.Result.Margin = new System.Windows.Forms.Padding(4);
            this.Result.Multiline = true;
            this.Result.Name = "Result";
            this.Result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Result.Size = new System.Drawing.Size(1034, 410);
            this.Result.TabIndex = 1;
            // 
            // UrlList
            // 
            this.UrlList.Location = new System.Drawing.Point(17, 16);
            this.UrlList.Margin = new System.Windows.Forms.Padding(4);
            this.UrlList.Name = "UrlList";
            this.UrlList.Size = new System.Drawing.Size(891, 23);
            this.UrlList.TabIndex = 2;
            // 
            // HttpStatus
            // 
            this.HttpStatus.Location = new System.Drawing.Point(17, 245);
            this.HttpStatus.Margin = new System.Windows.Forms.Padding(4);
            this.HttpStatus.Name = "HttpStatus";
            this.HttpStatus.Size = new System.Drawing.Size(1037, 22);
            this.HttpStatus.TabIndex = 3;
            // 
            // HeadersAreaPanel
            // 
            this.HeadersAreaPanel.AutoScroll = true;
            this.HeadersAreaPanel.Location = new System.Drawing.Point(17, 95);
            this.HeadersAreaPanel.Name = "HeadersAreaPanel";
            this.HeadersAreaPanel.Size = new System.Drawing.Size(1038, 143);
            this.HeadersAreaPanel.TabIndex = 4;
            // 
            // PlusButton
            // 
            this.PlusButton.Location = new System.Drawing.Point(34, 66);
            this.PlusButton.Name = "PlusButton";
            this.PlusButton.Size = new System.Drawing.Size(75, 23);
            this.PlusButton.TabIndex = 0;
            this.PlusButton.Text = "+";
            this.PlusButton.UseVisualStyleBackColor = true;
            this.PlusButton.Click += new System.EventHandler(this.PlusButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 698);
            this.Controls.Add(this.HeadersAreaPanel);
            this.Controls.Add(this.HttpStatus);
            this.Controls.Add(this.PlusButton);
            this.Controls.Add(this.UrlList);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.SendButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox Result;
        private System.Windows.Forms.ComboBox UrlList;
        private System.Windows.Forms.TextBox HttpStatus;
        private System.Windows.Forms.Panel HeadersAreaPanel;
        private System.Windows.Forms.Button PlusButton;
    }
}

