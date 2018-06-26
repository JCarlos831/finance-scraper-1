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
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService("/Users/JuanCMontoya/Projects/vscode/csharp/finance-scraper-1/bin/Debug/netcoreapp2.1");
            var driver = new FirefoxDriver(service);

            // Open the browser and navigate to the Yahoo! Finance login page.
            driver.Url = "https://login.yahoo.com/config/login?.intl=us&.lang=en-US&.src=finance&.done=https%3A%2F%2Ffinance.yahoo.com%2F";

            // Maximize the window.
            driver.Manage().Window.Maximize();
            
            // If element cannot be found in ten seconds, timeout.
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            // Find username text box, enter username, and press Enter.
            driver.FindElement(By.Id("login-username")).SendKeys("testfinance@yahoo.com" + Keys.Enter);

            // If element cannot be found in ten seconds, timeout.
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            // Find password text box, enter password, and press Enter.
            driver.FindElement(By.Id("login-passwd")).SendKeys("3eggWhites6Almonds" + Keys.Enter);

            // Find 'My Portfolio' link and click
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/div/div[1]/div[2]/div[1]/div/div/div/div/div/div/div/nav/div/div/div/div[3]/div/div[1]/ul/li[2]/a")).Click();
            driver.FindElement(By.XPath("/html/body/dialog/section/button")).Click();

            // Click the 'x' on the pop up box
            driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section/div[2]/table/tbody/tr[1]/td[1]/a")).Click();

            // If element cannot be found in ten seconds, timeout.
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            // Find table with stock data
            IWebElement table = driver.FindElement(By.ClassName("_1TagL"));

            // Find all rows in the table
            IList<IWebElement> rows = new List<IWebElement>(table.FindElements(By.TagName("tr")));
            String strRowData = "";

            // Get Table Headers
            String strThData = "";
            // get table header for stock symbols
            strThData = strThData + driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section[2]/div[1]/table/thead/tr/th[1]/span")).Text + "\t";
            // get table header for last price
            strThData = strThData + driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section[2]/div[1]/table/thead/tr/th[2]")).Text + "\t";
            // get table header for change
            strThData = strThData + driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section[2]/div[1]/table/thead/tr/th[3]")).Text + "\t";
            // get table header for %chg
            strThData = strThData + driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section[2]/div[1]/table/thead/tr/th[4]")).Text + "\t";
            // get table header for currency
            strThData = strThData + driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section[2]/div[1]/table/thead/tr/th[5]")).Text + "\t";
            // get table header for market time
            strThData = strThData + driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section[2]/div[1]/table/thead/tr/th[6]")).Text + "\t";
            // get table header for volume
            strThData = strThData + driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section[2]/div[1]/table/thead/tr/th[7]")).Text + "\t";
            // get table header for shares
            strThData = strThData + driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section[2]/div[1]/table/thead/tr/th[8]")).Text + "\t";
            // get table header for avg volume (3m)
            strThData = strThData + driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section[2]/div[1]/table/thead/tr/th[9]")).Text + "\t";
            // get table header for day range
            strThData = strThData + driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section[2]/div[1]/table/thead/tr/th[10]")).Text + "\t";
            // get table header for 52-wk range
            strThData = strThData + driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section[2]/div[1]/table/thead/tr/th[11]")).Text + "\t";
            // get table header for day chart
            strThData = strThData + driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section[2]/div[1]/table/thead/tr/th[12]")).Text + "\t";
            // get table header for market cap
            strThData = strThData + driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section[2]/div[1]/table/thead/tr/th[13]")).Text;
            // print table headers to console
            System.Console.WriteLine(strThData);

            // Go through each row
            foreach (var row in rows)
            {
                // Get the columns from a particular row
                List<IWebElement> lstTdElem = new List<IWebElement>(row.FindElements(By.TagName("td")));
                if (lstTdElem.Count > 0)
                {
                    // Go through each column
                    foreach (var elemTd in lstTdElem)
                    {
                        // Add text found from each cell to strRowData
                        strRowData = strRowData + elemTd.Text + "\t";
                    }
                }
                else
				{
					// To print the data into the console and tab space between text
					Console.WriteLine(rows[0].Text.Replace(" ", "\t"));
				}

                // Print the data to the console
				System.Console.WriteLine(strRowData);

                // 
				strRowData = String.Empty;
                System.Console.WriteLine(strRowData);
            }

            System.Console.WriteLine("\n");

            driver.Close();  
        }
    }
}
