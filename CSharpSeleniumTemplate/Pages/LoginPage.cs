using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
    public class LoginPage : PageBase
    {
        #region Mapping
        By usernameField = By.Name("username");
        By passwordField = By.Name("password");
        By loginButton = By.XPath("//input[@type='submit']");
        By mensagemErroTextArea = By.XPath("/html/body/div[2]/font");
        #endregion

        #region Actions
        public void PreenhcerUsuario(string usuario)
        {
            SendKeys(usernameField, usuario);
        }

        public void PreencherSenha(string senha)
        {
            SendKeys(passwordField, senha);
        }

        public void ClicarEmLogin()
        {
            Click(loginButton);
        }

        public string RetornaMensagemDeErro()
        {
            return GetText(mensagemErroTextArea);
        }
        #endregion
    }
}
