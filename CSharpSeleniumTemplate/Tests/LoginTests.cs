using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.DataBaseSteps;
using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Pages;
using NUnit.Framework;
using System.Collections;

namespace CSharpSeleniumTemplate.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        #region Pages and Flows Objects
        [AutoInstance] LoginPage loginPage;
        [AutoInstance] MainPage mainPage;
        #endregion

        #region Data Driven Providers
        public static IEnumerable EfetuarLoginInformandoUsuarioInvalidoIProvider()
        {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.ReturnProjectPath() + "Resources/TestData/Login/EfetuarLoginInformandoUsuarioInvalidoData.csv");
        }
        #endregion

        [Test]
        public void EfetuarLoginComSucesso()
        {
            #region Parameters
            string usuario = "templateautomacao";
            string senha = "123456";
            #endregion

            loginPage.PreenhcerUsuario(usuario);
            loginPage.PreencherSenha(senha);
            loginPage.ClicarEmLogin();

            Assert.AreEqual(usuario, mainPage.RetornaUsernameDasInformacoesDeLogin());
        }

        //Exemplo utilizando um retorno de uma query de banco de dados
        [Test]
        public void EfetuarLoginComSucesso2()
        {
            #region Parameters
            string usuario = "templateautomacao";
            string senha = UsuariosDBSteps.RetornaSenhaDoUsuario(usuario);
            #endregion

            loginPage.PreenhcerUsuario(usuario);
            loginPage.PreencherSenha(senha);
            loginPage.ClicarEmLogin();

            Assert.AreEqual(usuario, mainPage.RetornaUsernameDasInformacoesDeLogin());
        }

        [Test, TestCaseSource("EfetuarLoginInformandoUsuarioInvalidoIProvider")]
        public void EfetuarLoginInformandoUsuarioInvalido(ArrayList testData)
        {
            #region Parameters
            string usuario = testData[0].ToString();
            string senha = testData[1].ToString();
            string mensagemErroEsperada = "Your account may be disabled or blocked or the username/password you entered is incorrect.";
            #endregion

            loginPage.PreenhcerUsuario(usuario);
            loginPage.PreencherSenha(senha);
            loginPage.ClicarEmLogin();

            Assert.AreEqual(mensagemErroEsperada, loginPage.RetornaMensagemDeErro());
        }
    }
}
