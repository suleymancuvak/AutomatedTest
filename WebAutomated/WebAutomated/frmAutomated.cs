using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Newtonsoft.Json.Linq;
using System.IO;

namespace WebAutomated
{
    public partial class frmAutomated : Form
    {
        public frmAutomated()
        {
            InitializeComponent();

            
        }


        public IWebElement isPAgeLoad(IWebDriver driver,string elementPath) {


            IWebElement element = null;
            bool isLoaded = false;

            while (true)
            {



                try
                {

                    IWebElement elementx = driver.FindElement(By.XPath(elementPath));
                    if (elementx.Displayed && elementx.Enabled)
                    {
                        isLoaded = true;
                        element = driver.FindElement(By.XPath(elementPath));
                        break;

                    }
                    else
                    {
                        isLoaded = false;
                    }

                }
                catch (Exception ex)
                {
                    continue;
                }
               


            }

            return element;




        }

        public IWebDriver createDriver()
        {
          

            ChromeDriverService service = ChromeDriverService.CreateDefaultService(System.IO.Path.GetFullPath(@"..\..\"));
            service.HideCommandPromptWindow = true;

            //  var options = new ChromeOptions();
            // options.AddArgument("--window-position=-32000,-32000");

            return new ChromeDriver(service);


        }

        public bool SummaryDisplayed(IWebDriver _driver, string elementname )
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
                var myElement = wait.Until(x => x.FindElement(By.Name("password")));
                return myElement.Displayed;
            }
            catch
            {
                return false;
            }
        }


        public IWebElement waitElementLoad(IWebDriver driver, string elmXpath, bool isbtn)
        {

            WebDriverWait waitx = new WebDriverWait(driver, TimeSpan.FromMinutes(5));
            IWebElement elementxx=null;

            if (isbtn)
            {

              

                waitx.Until<IWebElement>((d) =>
                {
                    IWebElement elementx = d.FindElement(By.XPath(elmXpath));
                    if (elementx.Displayed &&
                        elementx.Enabled
                       )
                    {
                        elementxx= elementx;
                    }

                    return elementxx;
                });

            }
            else

            {
                waitx.Until<IWebElement>((d) =>
                {
                    IWebElement elementx = d.FindElement(By.XPath(elmXpath));
                    if (elementx.Displayed &&
                        elementx.Enabled &&
                        elementx.GetAttribute("aria-disabled") == null)
                    {
                        elementxx= elementx;
                    }

                    return elementxx;
                });

            }

            return elementxx;


        }


        private void button1_Click(object sender, EventArgs e)
        {





            mail_setting o1 = new mail_setting(File.ReadAllText(Path.GetFullPath(@"..\..\Setting.json")));



            IWebDriver chdriver = createDriver();
           
            chdriver.Navigate().GoToUrl("http:\\mail.google.com");

            ////  chdriver.Url="http://www.gmail.com";
            // IWebElement element = chdriver.FindElement(By.XPath("//*[@id='identifierId']"));

            IWebElement elementxx = isPAgeLoad(chdriver, "//*[@id='identifierId']");
            elementxx.SendKeys(o1.email_add);
            // IWebElement btnelement = chdriver.FindElement(By.XPath("//*[@id='identifierNext']"));
            IWebElement btnelement = waitElementLoad(chdriver, "//*[@id='identifierNext']", true);
            btnelement.Click();



            //Call wait function  to wait page load is completed
            IWebElement passelementxx = isPAgeLoad(chdriver, "//*[@id='password']/div[1]/div/div[1]/input");
            passelementxx.SendKeys(o1.email_password);

            //Call wait function  to wait page load is completed
          
            IWebElement btnelementpass = isPAgeLoad(chdriver, "//*[@id='passwordNext']");
            btnelementpass.Click();

            
            IWebElement elementCompso = isPAgeLoad(chdriver, "//*[@id=':ix']/div/div");
            elementCompso.Click();

            chdriver.SwitchTo().ActiveElement();


            
            IWebElement emailReceipents = chdriver.FindElement(By.ClassName("vO"));
            emailReceipents.SendKeys(o1.email_receipents);

           
            IWebElement emailSubjectAddelement = isPAgeLoad(chdriver, "//*[@id=':oe']");
            emailSubjectAddelement.SendKeys(o1.email_subject);


          
            IWebElement printbody = isPAgeLoad(chdriver, "//*[@id=':pf']");
            printbody.SendKeys(o1.email_body);



           
          
            IWebElement btnSend = waitElementLoad(chdriver, "//*[@id=':o4']", false);

            btnSend.Click();

            chdriver.Quit();












        }

    }
}
