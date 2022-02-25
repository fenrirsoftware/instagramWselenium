using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace followers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)

        {
            //renk fln veriyorum burası boş 
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#7900FF");
            label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#93FFD8");
            groupBox1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#548CFF");
            listBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#548CFF");
            listBox2.BackColor = System.Drawing.ColorTranslator.FromHtml("#548CFF");
            listBox3.BackColor = System.Drawing.ColorTranslator.FromHtml("#548CFF");
            button1.BackColor = System.Drawing.ColorTranslator.FromHtml("#548CFF");





        }

     

       

        private void button1_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new ChromeDriver();  //web driver açıyorum
            driver.Navigate().GoToUrl("https://www.instagram.com"); // web driverin ha bu verdiğim adrese gitmesini sağlıyorum
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Siteye Gidildi!");
            Thread.Sleep(2000); //bunu aralara serpiştirmek önemli hızlı hızlı yapınca genelde hata veriyor

            //biraz html css felan 
            IWebElement userName = driver.FindElement(By.Name("username"));
            IWebElement password = driver.FindElement(By.Name("password"));
            IWebElement loginBtn = driver.FindElement(By.CssSelector(".sqdOP.L3NKy.y3zKF"));  //bunu almayı gösterdim konuda


            
            //yukardki yerlere gidecek şeyleri ayarlıyorum
            string kulad, sif, gidhesap;
            kulad = textBox1.Text;
            sif = textBox2.Text;
            gidhesap = textBox3.Text;

            Thread.Sleep(1500);
            userName.SendKeys(kulad);
            Thread.Sleep(1500);
            password.SendKeys(sif);
            Thread.Sleep(1500);
            loginBtn.Click();
            Thread.Sleep(1500);
            Console.WriteLine("Hesap Bilgileri Girildi!");

            Thread.Sleep(1500);
            driver.Navigate().GoToUrl($"https://www.instagram.com/" + gidhesap + "/");
            Console.WriteLine("Profile Yönlendirildi!");


            Thread.Sleep(1500);



            Thread.Sleep(1500);
            

                Thread.Sleep(1500);
            // burası bazen hata veriyor sebebini bilmiyorum çünkü css bilmiyorum
                IWebElement followerLink = driver.FindElement(By.CssSelector("#react-root > section > main > div > header > section > ul > li:nth-child(2) > a > div"));
                followerLink.Click();
                Thread.Sleep(2000);

                //ScrollDown Start
                //isgrP

            //biraz js 
                string jsCommand = "" +
                    "sayfa = document.querySelector('.isgrP');" +     //takipçiler sekmesindeki scrollu hareket ettirmek için 
                    "sayfa.scrollTo(0,sayfa.scrollHeight);" +
                    "var sayfaSonu = sayfa.scrollHeight;" +
                    "return sayfaSonu;";

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                var sayfaSonu = Convert.ToInt32(js.ExecuteScript(jsCommand));

                while (true)
                {
                    var son = sayfaSonu;
                    Thread.Sleep(1500);
                    sayfaSonu = Convert.ToInt32(js.ExecuteScript(jsCommand));
                    if (son == sayfaSonu)
                        break;
                }

                //ScrollDown End


                //Takipçi Listeleme Start

                int sayac = 0;
                IReadOnlyCollection<IWebElement> follwers = driver.FindElements(By.CssSelector(".FPmhX.notranslate._0imsa"));

                foreach (IWebElement follower in follwers)
                {

                    sayac++;


                    listBox1.Items.Add(" ==> " + follower.Text);

                }
                groupBox2.Text = ("takipçi:" + sayac + "kişi vardır");


                //Takipçi Listeleme END

                driver.Navigate().GoToUrl($"https://www.instagram.com/" + gidhesap + "/");
                Console.WriteLine("Profile Yönlendirildi!");
                Thread.Sleep(2000);
                IWebElement followsLink = driver.FindElement(By.CssSelector("#react-root > section > main > div > header > section > ul > li:nth-child(3) > a"));
                followsLink.Click();
                Thread.Sleep(1000);


                //ScrollDown Start
                //isgrP
                string jsCommand1 = "" +
                    "sayfa = document.querySelector('.isgrP');" +
                    "sayfa.scrollTo(0,sayfa.scrollHeight);" +
                    "var sayfaSonu = sayfa.scrollHeight;" +
                    "return sayfaSonu;";

                IJavaScriptExecutor js1 = (IJavaScriptExecutor)driver;
                var sayfaSonu1 = Convert.ToInt32(js.ExecuteScript(jsCommand));

                while (true)
                {
                    var son = sayfaSonu;
                    Thread.Sleep(1000);
                    sayfaSonu = Convert.ToInt32(js.ExecuteScript(jsCommand));
                    if (son == sayfaSonu)
                        break;
                }

                //ScrollDown End


                //Takip edilen Listeleme Start

                int sayac1 = 0;
                IReadOnlyCollection<IWebElement> follows = driver.FindElements(By.CssSelector(".FPmhX.notranslate._0imsa"));

                foreach (IWebElement follower in follows)
                {

                    sayac1++;

                    listBox2.Items.Add(" ==> " + follower.Text);

                }
                groupBox4.Text = ("takip edilen:" + sayac1 + "kişi vardır");


                //Takip edilen Listeleme END

                string[] veriler1 = new string[listBox1.Items.Count];
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    veriler1[i] = listBox1.Items[i].ToString();
                }

                List<string> veriler2 = new List<string>();
                foreach (var item in listBox1.Items)
                {
                    veriler2.Add(item.ToString());
                }

                var veriler3 = listBox1.Items.Cast<String>().ToArray();






                string[] veriler4 = new string[listBox2.Items.Count];
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    veriler4[i] = listBox2.Items[i].ToString();
                }

                List<string> veriler5 = new List<string>();
                foreach (var item in listBox1.Items)
                {
                    veriler5.Add(item.ToString());
                }

                var veriler6 = listBox2.Items.Cast<String>().ToArray();

                listBox3.DataSource = veriler4.Except(veriler3).ToList();




                driver.Close();
                Console.WriteLine("----------------------");



            
        }

       

      
 

    }
}

       
    


