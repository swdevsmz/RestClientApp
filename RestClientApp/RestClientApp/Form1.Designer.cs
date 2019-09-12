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
            this.requestSend = new System.Windows.Forms.Button();
            this.Result = new System.Windows.Forms.TextBox();
            this.Url = new System.Windows.Forms.TextBox();
            this.HttpStatus = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Minus = new System.Windows.Forms.Button();
            this.Plus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // requestSend
            // 
            this.requestSend.Location = new System.Drawing.Point(951, 16);
            this.requestSend.Margin = new System.Windows.Forms.Padding(4);
            this.requestSend.Name = "requestSend";
            this.requestSend.Size = new System.Drawing.Size(100, 29);
            this.requestSend.TabIndex = 0;
            this.requestSend.Text = "Send";
            this.requestSend.UseVisualStyleBackColor = true;
            this.requestSend.Click += new System.EventHandler(this.Send_Click);
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
            // Url
            // 
            this.Url.Location = new System.Drawing.Point(17, 16);
            this.Url.Margin = new System.Windows.Forms.Padding(4);
            this.Url.Name = "Url";
            this.Url.Size = new System.Drawing.Size(891, 22);
            this.Url.TabIndex = 2;
            // 
            // HttpStatus
            // 
            this.HttpStatus.Location = new System.Drawing.Point(17, 245);
            this.HttpStatus.Margin = new System.Windows.Forms.Padding(4);
            this.HttpStatus.Name = "HttpStatus";
            this.HttpStatus.Size = new System.Drawing.Size(1037, 22);
            this.HttpStatus.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(17, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1038, 143);
            this.panel1.TabIndex = 4;
            // 
            // Minus
            // 
            this.Minus.Location = new System.Drawing.Point(123, 66);
            this.Minus.Name = "Minus";
            this.Minus.Size = new System.Drawing.Size(75, 23);
            this.Minus.TabIndex = 1;
            this.Minus.Text = "-";
            this.Minus.UseVisualStyleBackColor = true;
            this.Minus.Click += new System.EventHandler(this.Minus_Click);
            // 
            // Plus
            // 
            this.Plus.Location = new System.Drawing.Point(34, 66);
            this.Plus.Name = "Plus";
            this.Plus.Size = new System.Drawing.Size(75, 23);
            this.Plus.TabIndex = 0;
            this.Plus.Text = "+";
            this.Plus.UseVisualStyleBackColor = true;
            this.Plus.Click += new System.EventHandler(this.Plus_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 698);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.HttpStatus);
            this.Controls.Add(this.Plus);
            this.Controls.Add(this.Minus);
            this.Controls.Add(this.Url);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.requestSend);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button requestSend;
        private System.Windows.Forms.TextBox Result;
        private System.Windows.Forms.TextBox Url;
        private System.Windows.Forms.TextBox HttpStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Minus;
        private System.Windows.Forms.Button Plus;
    }
}

