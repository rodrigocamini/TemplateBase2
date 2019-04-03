using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
    public class BugReportPage : PageBase
    {
        #region Mapping
        By categoryComboBox = By.Name("category_id");
        By summaryField = By.Name("summary");
        By descriptionField = By.Name("description");
        By uploadFileField = By.Id("ufile[]");
        By submitButton = By.XPath("//input[@type='submit']");
        #endregion

        #region Actions
        public void SelecionarCategoria(string categoria)
        {
            ComboBoxSelectByVisibleText(categoryComboBox, categoria);
        }
        
        public void PreencherResumo(string resumo)
        {
            SendKeys(summaryField, resumo);
        }

        public void PreencherDescricao(string descricao)
        {
            SendKeys(descriptionField, descricao);
        }

        public void InserirAnexo(string caminhoArquivo)
        {
            SendKeysWithoutWaitVisible(uploadFileField, caminhoArquivo);
        }

        public void ClicarEmSubmitReport()
        {
            Click(submitButton);
        }
        #endregion
    }
}