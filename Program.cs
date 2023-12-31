﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace _1_Selenium_UlifeTest
{
    public class SeleniumCore
    {
        public static string selectedNav;
        public static string selectedWebsite;
        public static string loginInput; 
        public static string passInput;
        public string navAddress;

        public IWebDriver driver;

        private IWebElement txtLoginWeb;
        private IWebElement txtSenhaWeb;
        private IWebElement btnSubmit;

        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public SeleniumCore()
        {
            if (selectedNav == "Chrome")
            {
            driver = new ChromeDriver();
            }

            else if (selectedNav == "Firefox")
            {
            driver = new FirefoxDriver();
            }

            else if (selectedNav == "Edge")
            {
                driver = new EdgeDriver();
            }




        }

        public void TestWeb()
        {
            
            if (selectedWebsite == "Sala Virtual")
            {
               navAddress = "https://www.ulife.com.br/login.aspx";
            }

            else if (selectedWebsite == "Portal")
            {
                navAddress = "https://aluno.anhembi.br/SOL/aluno/index.php/index/seguranca/dev/instituicao/125";
            }

            else
            {
                Console.WriteLine("Opa");
            }


            driver.Navigate().GoToUrl(navAddress);
            txtLoginWeb = driver.FindElement(By.XPath("//input[@name='ctl00$b$txtLogin' and @id='txtLogin' and @type='text']"));
            txtSenhaWeb = driver.FindElement(By.XPath("//input[@name='ctl00$b$txtPassword' and @id='txtPassword' and @type='password']"));
            btnSubmit = driver.FindElement(By.XPath("//button[@id='ctl00_b_imbLogin']"));


            txtLoginWeb.SendKeys(loginInput);
            txtSenhaWeb.SendKeys(passInput);
            btnSubmit.Click();
        }





    }
}
