using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using System;

using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace selen_bot
{
    public class ffCheck
    {
        const string url = "https://www.roblox.com/games/510411669/Fantastic-Frontier";
        public string upd()
        {

            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Url = url;

                //implicit wait
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector("#about > div.section.game-about-container > div.section-content.remove-panel > ul > li:nth-child(5) > p.text-lead.font-caption-body")));
                DateTime current = DateTime.Parse(element.Text);
                DateTime lastUpd = DateTime.Parse("4/17/2019");
                DateTime today = DateTime.Parse(DateTime.Today.ToString("M/dd/yyyy").Replace("-", "/"));

                if (current != DateTime.Parse("4/14/2023"))
                {
                    return "ff update";
                }
                else
                {
                    TimeSpan timeSpan = DateTime.UtcNow - new DateTime(2019, 4, 17, 0, 0, 0);
                    //TimeSpan difference = today - lastUpd;
                    //int days = (int) difference.TotalDays

                    double unixVersion = Math.Round(timeSpan.TotalMilliseconds);

                    return "ff was last updated " + unixVersion + " milliseconds ago, ff will never update.";
                }
            }
        }
    }
}
