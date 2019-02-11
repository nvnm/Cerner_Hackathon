using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Xml;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Boolean clicked = false;
        String opt = null;
        static IWebDriver driver = null;
        SpeechSynthesizer ss = new SpeechSynthesizer();
        PromptBuilder pb = new PromptBuilder();
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        SpeechRecognitionEngine sre1 = new SpeechRecognitionEngine();
        Choices clist = new Choices();
       
        public Form1()
        {
            InitializeComponent();
            label1.Visible = false;
        }

        private void appointmentsInRange()
        {
            Microsoft.Office.Interop.Outlook.Application a = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.Folder calFolder = a.Session.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderCalendar) as Microsoft.Office.Interop.Outlook.Folder;
            DateTime start = DateTime.Now;
            DateTime end = start.AddDays(1);
            Microsoft.Office.Interop.Outlook.Items rangeAppts = GetAppointmentsInRange(calFolder, start, end);
            if (rangeAppts != null)
            {
                int size = 0;
                foreach (Microsoft.Office.Interop.Outlook.AppointmentItem appt in rangeAppts)
                {
                    size++;
                }
                    ss.SpeakAsync("You have " + size + " items on your calendar today");
                foreach (Microsoft.Office.Interop.Outlook.AppointmentItem appt in rangeAppts)
                {
                    

                    setLabel(appt.Subject + " starts at " + appt.Start.ToString());
                    ss.SpeakAsync(appt.Subject + " starts at " + appt.Start.ToString());
                    opt += appt.Subject + " " + appt.Start.ToString() + "#";
                  
                }
            }
            else
            {
                ss.SpeakAsync("Sorry i could not find anything! Try again later");
            }
        }
        private Microsoft.Office.Interop.Outlook.Items GetAppointmentsInRange(Microsoft.Office.Interop.Outlook.Folder folder, DateTime startTime, DateTime endTime)
        {
            string filter = "[Start] >= '" + startTime.ToString("g") + "' AND [End] <= '" + endTime.ToString("g") + "'";
            try
            {
                Microsoft.Office.Interop.Outlook.Items calItems = folder.Items;
                calItems.IncludeRecurrences = true;
                calItems.Sort("[Start]", Type.Missing);
                Microsoft.Office.Interop.Outlook.Items restrictItems = calItems.Restrict(filter);
                if (restrictItems.Count > 0)
                {
                    return restrictItems;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }


            private void pictureBox1_Click(object sender, EventArgs e)
        {
            /*   


            appointmentsInRange();
            Form2 frm2 = new Form2();
            frm2.LabelText = this.opt; ;
            frm2.Show();
*/
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("C:\\Users\\nm045365\\Documents\\voicecommands.xml");
            XmlNodeList nodeList = null;

            nodeList = xmlDoc.DocumentElement.GetElementsByTagName("*");
            XmlNode k;
            String p = "";
            for (int i = nodeList.Count; i > -1; i--)
            {
                k = nodeList[i];
                while (k != null)
                {
                    p += k.Name+" ";
                    k = k.ParentNode;
  
                }
                p += "/";
                
            }
            p = p.Replace("data", "");
            p = p.Replace("#document", "");
            p = p.TrimStart('/');
            p = p.TrimEnd('/');
            String[] input = p.Split('/');
            String j=null;

            foreach (String s in input)
            {
                
                String[] h = s.Trim(' ').Split(' ');
                
                for (int n= h.Length-1; n > -1; n--)
                {
                    j += h[n].ToString()+" ";
                }
                j.TrimStart(' ');
                j.TrimEnd(' ');
                j += '/';
            }
            j=j.Remove(j.Length - 1, 1) + "";
            j = j.Remove(j.Length - 1, 1) + "";
            String[] kk = j.Split('/');
            clist.Add(kk);

          //  foreach (String nm in kk)
            //    MessageBox.Show(nm);






                                    if (!clicked)
                                   for(int i=0; i<8; i++)
                                   {
                                       pictureBox1.Top += i;Thread.Sleep(30);
                                   }
                                   clicked = true;
                                   label1.Visible = true;
                                   ss.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
                                   ss.Rate = -1;

                                   ss.SpeakAsync("Hi there!");
                                      Grammar gr = new Grammar(new GrammarBuilder(clist));

                                   try
                                   {
                                       sre.RequestRecognizerUpdate();
                                       sre.LoadGrammar(gr);
                                       sre.SetInputToDefaultAudioDevice();
                                       sre.SpeechRecognized += sre_SpeechRecognized;
                                       
                                       sre.RecognizeAsync(RecognizeMode.Multiple);
                                   }
                                   catch (Exception ex)
                                   {
                                       MessageBox.Show(ex.Message, "Error");
                                   }

        }

        Boolean skip = false;
        String xpath=null;

        private void setLabel(String value)
        {
            label1.Text = value;

            Point a = new Point(this.Width, label1.Location.Y);
            Point b = new Point(label1.Location.X - 10, label1.Location.Y);
            if (label1.Location.X < 0 - label1.Width + 1)
            {
                label1.Location = a;
            }
            else
            {
                label1.Location = b;
            }
        }


        private void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            setLabel("Wait...");
            XmlDocument xmlDoc1=null;
            XmlNodeList nodeList1 = null;
            if (!skip)
            {
                xmlDoc1 = new XmlDocument();
                xmlDoc1.Load("C:\\Users\\nm045365\\Documents\\voicecommands.xml");
                xpath = "/data/" + e.Result.Text.ToString().Replace(' ', '/');
                nodeList1 = xmlDoc1.DocumentElement.SelectNodes(xpath);
                
            }
            else
            {
                Thread.Sleep(5000);
                xmlDoc1 = new XmlDocument();
                xmlDoc1.Load("C:\\Users\\nm045365\\Documents\\voicecommands.xml");
                xpath = xpath + "/" + e.Result.Text;
                nodeList1 = xmlDoc1.DocumentElement.SelectNodes(xpath);
                skip = false;
            }
            foreach (XmlNode node in nodeList1)
            {
                if(node.ChildNodes.Count > 1)
                {
                    String option = null;
                  
                    ss.Speak("I can see "+node.ChildNodes.Count+" options");
                    foreach (XmlNode eh in node.ChildNodes)
                    {
                        ss.SpeakAsync(eh.Name + " ");
                        option += eh.Name + "/";
                    }
                    ss.Speak("please select ?");
                    skip = true;
                   
                    String i = option.Remove(option.Length - 1, 1) + "";
                    String[] g = i.Split('/');

                    Choices clist1 = new Choices();
                    clist1.Add(g);
                    Grammar gr = new Grammar(new GrammarBuilder(clist1));
                    sre.LoadGrammar(gr);
                    setLabel("Listening...");
                }
                else if(node.ChildNodes.Count==1)
                {
                    String pro = node.FirstChild.InnerText;
                    setLabel("Processing");
                    if (pro.Contains("appointments"))
                        appointmentsInRange();
                    else if (pro.Contains("see you later"))
                        ss.Speak(pro);
                    else if(pro.Contains("environment"))
                    {
                        MessageBox.Show("hi");
                        Form3 f3 = new Form3();
                        f3.Show();
                    }
                    else if(pro.Contains("selectPatient"))
                    {
                        selectPatient();
                    }
                    else
                    System.Diagnostics.Process.Start(pro);
                }
                setLabel("Ask me");
            }
        }

        String v1 = null;
        public String dri
        {
            set
            {
                this.v1 = value;
            
            }
            get
            {
                return this.v1;
            }
        }

        /*       protected override bool ProcessDialogKey(Keys keyData)
               {

                   if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
                   {
                       ss.SpeakAsync("See you later");
                       Thread.Sleep(2000);
                       this.Close();
                       return true;
                   }
                   return base.ProcessDialogKey(keyData);
               }
       */

        public IWebDriver Login()
        {
            try
            {
                String[] data = v1.Split(' ');
                driver = new InternetExplorerDriver();
                driver.Manage().Window.Maximize();
                driver.Url = data[0];
                System.Threading.Thread.Sleep(5000);
                IWebElement password = driver.FindElement(By.XPath("//input[@type='password']"));
                password.Clear();
                password.SendKeys(data[2]);
                driver.FindElement(By.XPath("//input[@type='text']")).SendKeys(data[1]);

                try
                {// driver.FindElement(By.Id("en_US")).Click(); 
                }
                catch (NoSuchElementException nse) { }
                driver.FindElement(By.XPath("//*[@id='btnLogin']")).Click();



                  string newTabHandle = driver.WindowHandles.Last();
                 driver.SwitchTo().Window(newTabHandle);

                driver.SwitchTo().Frame("sframeInner");
                driver.SwitchTo().Frame("wellFrame");
                driver.SwitchTo().Frame("dkMainFrame");
                driver.SwitchTo().Frame("legacyCensusIFrame");
                driver.SwitchTo().Frame("PatientCensus");
                driver.SwitchTo().Frame("SUI_CENSUS_WELL");

                driver.FindElement(By.XPath("//td[contains(text(), 'test, nvn2')]")).Click();


            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message.ToString());
            }
            return driver;
        }

        public IWebDriver selectPatient()
        {
          //  string newTabHandle = driver.WindowHandles.Last();
           // driver.SwitchTo().Window(newTabHandle);

            driver.SwitchTo().Frame("sframeInner");
            driver.SwitchTo().Frame("wellFrame");
            driver.SwitchTo().Frame("dkMainFrame");
            driver.SwitchTo().Frame("legacyCensusIFrame");
            driver.SwitchTo().Frame("PatientCensus");
            driver.SwitchTo().Frame("SUI_CENSUS_WELL");

            driver.FindElement(By.XPath("//td[contains(text(), 'test, nvn2')]")).Click();

            return driver;
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
