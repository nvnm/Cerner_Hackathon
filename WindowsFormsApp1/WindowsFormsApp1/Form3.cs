using AutoItX3Lib;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        IWebDriver driver;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = "Hi " + Environment.UserName;
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            label1.Text = "Environment Details";

            if (search.TextLength == 4)
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=usmlvv1sc2582.usmlvv1d0a.smshsc.net;Initial Catalog=WebInt;User ID=TestAuto;Password=TA@CdB$s]!");

                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("Select distinct ComputerName from vew_test_automation where environmentid = '" + search.Text + "' and (FunctionName='SVR App/Web Server' OR FunctionName='SVR Application Server' OR FunctionName='SVR Cluster/Virtual App Server')", con);
                    SqlCommand cmd2 = new SqlCommand("Select EnvironmentID, LogonID, Password, URL from inv_Environments where environmentid = '" + search.Text + "'", con);

                    SqlDataReader dr1, dr2;
                    dr1 = cmd1.ExecuteReader();

                    while (dr1.Read())
                    {
                        appserver.Text = dr1[0].ToString();
                    }
                    if (appserver.Text != null)
                        buttonAppServer.Visible = true;
                        dr1.Close();

                    dr2 = cmd2.ExecuteReader();

                    while (dr2.Read())
                    {
                        envid.Text = dr2[0].ToString();
                        username.Text = dr2[1].ToString();
                        password.Text = dr2[2].ToString();
                        url.Text = dr2[3].ToString();
                        if (url.Text != null)
                            buttonURL.Visible = true;
                    }

                    dr2.Close();
                    con.Close();
                }
                catch (Exception ex)
                {
                    label1.ForeColor = System.Drawing.Color.Red;
                    label1.Text = "Try Again";
                }
            }
            else
            {
                label1.ForeColor = System.Drawing.Color.Red;
                label1.Text = "Enter correct Environment ID";
            }
        }

        private void buttonURL_Click(object sender, EventArgs e)
        {
            try
            {
                driver = new InternetExplorerDriver();

                driver.Url = url.Text;
                System.Threading.Thread.Sleep(5000);
                driver.FindElement(By.XPath("//input[@type='text']")).SendKeys(username.Text);
                IWebElement password = driver.FindElement(By.XPath("//input[@type='password']"));
                password.Clear();
                password.SendKeys(password.Text);
                try { driver.FindElement(By.Id("en_US")).Click(); }
                catch (NoSuchElementException nse) { }
                driver.FindElement(By.XPath("//*[@id='btnLogin']")).Click();
            }
            catch (Exception ex1)
            {
                buttonURL.Text = "Try Again";
                MessageBox.Show(ex1.Message.ToString());
            }
        }

        private void buttonAppServer_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("CMD.exe", "/C mstsc");
                AutoItX3 a = new AutoItX3();
                a.WinWaitActive("Remote Desktop Connection");
                a.ControlSend("Remote Desktop Connection", "", "[CLASS:Edit; INSTANCE:1]", "{LSHIFT}" + appserver.Text.ToString() + ".usmlvv1d0a.smshsc.net");
                a.ControlClick("Remote Desktop Connection", "", "[CLASS:Button; INSTANCE:5]");
            }
            catch (Exception e3)
            {
                buttonAppServer.Text = "Try Again";
            }
        }

        public IWebDriver Login()
        {
            try
            {
                driver = new InternetExplorerDriver();
                driver.Manage().Window.Maximize();
                driver.Url = url.Text;
                System.Threading.Thread.Sleep(5000);
                IWebElement password = driver.FindElement(By.XPath("//input[@type='password']"));
                password.Clear();
                password.SendKeys(password.Text);
                driver.FindElement(By.XPath("//input[@type='text']")).SendKeys(username.Text);
                
                try {// driver.FindElement(By.Id("en_US")).Click(); 
                }
                catch (NoSuchElementException nse) { }
                driver.FindElement(By.XPath("//*[@id='btnLogin']")).Click();
            }
            catch (Exception ex1)
            {
                buttonURL.Text = "Try Again";
                MessageBox.Show(ex1.Message.ToString());
            }
            return driver;
        }

        public IWebDriver selectPatient()
        {
            string newTabHandle = driver.WindowHandles.Last();
            driver.SwitchTo().Window(newTabHandle);

            driver.SwitchTo().Frame("sframeInner");
            driver.SwitchTo().Frame("wellFrame");
            driver.SwitchTo().Frame("dkMainFrame");
            driver.SwitchTo().Frame("legacyCensusIFrame");
            driver.SwitchTo().Frame("PatientCensus");
            driver.SwitchTo().Frame("SUI_CENSUS_WELL");

            driver.FindElement(By.XPath("//td[contains(text(), 'nvn, test1')]")).Click();

            return driver;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Login();
            Form1 f1 = new Form1();
            f1.dri = url.Text + " " + username + " " + password;
            Form3 f3 = new Form3();
            f3.Show();
            this.Close();
        }
    }
}
