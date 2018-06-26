using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace finance_scraper_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService("/Users/JuanCMontoya/Projects/vscode/csharp/finance-scraper-0/bin/Debug/netcoreapp2.0");
            var driver = new FirefoxDriver(service);

            driver.Url = "https://login.yahoo.com/config/login?.intl=us&.lang=en-US&.src=finance&.done=https%3A%2F%2Ffinance.yahoo.com%2F";

            driver.Manage().Window.Maximize();
            
            driver.FindElement(By.Id("login-username")).SendKeys("testfinance@yahoo.com" + Keys.Enter);
            driver.FindElement(By.Id("login-passwd")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(By.Id("login-passwd")).SendKeys("3eggWhites6Almonds" + Keys.Enter);

            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/div/div[1]/div[2]/div[1]/div/div/div/div/div/div/div/nav/div/div/div/div[3]/div/div[1]/ul/li[2]/a")).Click();
            driver.FindElement(By.XPath("/html/body/dialog/section/button")).Click();
            driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section/div[2]/table/tbody/tr[1]/td[1]/a")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            IWebElement table = driver.FindElement(By.ClassName("_1TagL"));
            IList<IWebElement> rows = new List<IWebElement>(table.FindElements(By.TagName("tr")));
            String strRowData = "";
            var rows_count = rows.Count();
            System.Console.WriteLine("There are " + rows_count + ".\n");

            foreach (var row in rows)
            {
                List<IWebElement> lstTdElem = new List<IWebElement>(row.FindElements(By.TagName("td")));
                if (lstTdElem.Count > 0)
                {
                    foreach (var elemTd in lstTdElem)
                    {
                        strRowData = strRowData + elemTd.Text + "\t\t";
                    }
                }
                else
				{
					// To print the data into the console
					Console.WriteLine("This is Header Row");
					Console.WriteLine(rows[0].Text.Replace(" ", "\t\t"));
				}
				Console.WriteLine(strRowData);
				strRowData = String.Empty;
            }

            IList<IWebElement> columns = driver.FindElements(By.TagName("th"));
            var column_count = columns.Count()/2;
            System.Console.WriteLine(column_count);

            IList<IWebElement> stockSymbols =  driver.FindElements(By.ClassName("_61PYt"));
            var lastPrices = driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section[2]/div[2]/table/tbody/tr[1]/td[2]/span"));

            System.Console.WriteLine("Total number of stocks in portfolio: " + stockSymbols.Count);
            System.Console.WriteLine("You have the following stocks:");

            foreach (var stockSymbol in stockSymbols)
            {
                Console.WriteLine(stockSymbol.Text);
            }

            System.Console.WriteLine(lastPrices.Text);

            System.Console.WriteLine("\n");

            driver.Close();  
        }


    }
}
