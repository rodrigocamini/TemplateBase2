using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
    public class MainPage : PageBase
    {
        #region Mapping
        By usernameLoginInfoTextArea = By.XPath("//td[@class='login-info-left']/span[@class='italic']");
        By reportIssueLink = By.XPath("//a[@href='/bug_report_page.php']");
        #endregion

        #region Actions
        public string RetornaUsernameDasInformacoesDeLogin()
        {
            return GetText(usernameLoginInfoTextArea);
        }

        public void ClicarEmReportIssue()
        {
            Click(reportIssueLink);
        }
        #endregion
    }
}
