namespace WindowsFormsApp1
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.envid = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.url = new System.Windows.Forms.Label();
            this.appserver = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.TextBox();
            this.buttonGet = new System.Windows.Forms.Button();
            this.buttonURL = new System.Windows.Forms.Button();
            this.buttonAppServer = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(126, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the environment ID";
            // 
            // envid
            // 
            this.envid.AutoSize = true;
            this.envid.Location = new System.Drawing.Point(126, 90);
            this.envid.Name = "envid";
            this.envid.Size = new System.Drawing.Size(83, 13);
            this.envid.TabIndex = 1;
            this.envid.Text = "Environment ID:";
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Location = new System.Drawing.Point(126, 130);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(75, 13);
            this.username.TabIndex = 2;
            this.username.Text = "SC Username:";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Location = new System.Drawing.Point(126, 169);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(73, 13);
            this.password.TabIndex = 3;
            this.password.Text = "SC Password:";
            // 
            // url
            // 
            this.url.AutoSize = true;
            this.url.Location = new System.Drawing.Point(126, 204);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(49, 13);
            this.url.TabIndex = 4;
            this.url.Text = "SC URL:";
            // 
            // appserver
            // 
            this.appserver.AutoSize = true;
            this.appserver.Location = new System.Drawing.Point(126, 241);
            this.appserver.Name = "appserver";
            this.appserver.Size = new System.Drawing.Size(63, 13);
            this.appserver.TabIndex = 5;
            this.appserver.Text = "App Server:";
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(281, 48);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(100, 20);
            this.search.TabIndex = 6;
            // 
            // buttonGet
            // 
            this.buttonGet.Location = new System.Drawing.Point(392, 47);
            this.buttonGet.Name = "buttonGet";
            this.buttonGet.Size = new System.Drawing.Size(75, 23);
            this.buttonGet.TabIndex = 7;
            this.buttonGet.Text = "Get";
            this.buttonGet.UseVisualStyleBackColor = true;
            this.buttonGet.Click += new System.EventHandler(this.buttonGet_Click);
            // 
            // buttonURL
            // 
            this.buttonURL.Location = new System.Drawing.Point(32, 200);
            this.buttonURL.Name = "buttonURL";
            this.buttonURL.Size = new System.Drawing.Size(66, 21);
            this.buttonURL.TabIndex = 8;
            this.buttonURL.Text = "Launch";
            this.buttonURL.UseVisualStyleBackColor = true;
            this.buttonURL.Click += new System.EventHandler(this.buttonURL_Click);
            // 
            // buttonAppServer
            // 
            this.buttonAppServer.Location = new System.Drawing.Point(32, 238);
            this.buttonAppServer.Name = "buttonAppServer";
            this.buttonAppServer.Size = new System.Drawing.Size(67, 20);
            this.buttonAppServer.TabIndex = 9;
            this.buttonAppServer.Text = "Launch";
            this.buttonAppServer.UseVisualStyleBackColor = true;
            this.buttonAppServer.Click += new System.EventHandler(this.buttonAppServer_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(391, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Automate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 291);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonAppServer);
            this.Controls.Add(this.buttonURL);
            this.Controls.Add(this.buttonGet);
            this.Controls.Add(this.search);
            this.Controls.Add(this.appserver);
            this.Controls.Add(this.url);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.envid);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Environment Detail";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label envid;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.Label url;
        private System.Windows.Forms.Label appserver;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.Button buttonGet;
        private System.Windows.Forms.Button buttonURL;
        private System.Windows.Forms.Button buttonAppServer;
        private System.Windows.Forms.Button button1;
    }
}