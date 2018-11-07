using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegrasNegocio.Models;
using System;
using TechTalk.SpecFlow;

namespace UnitTestsProject
{
    [Binding]
    public class AlterarStatusFuncionarioSteps
    {
        Status status = new Status();
        private int result = 0;
        TestAlteraStatusFuncionario testAlteraStatus = new TestAlteraStatusFuncionario();

        [Given(@"I have entered (.*) into the Id")]
        public void GivenIHaveEnteredIntoTheStatus(int idFuncionario)
        {
            status.IdFuncionario = idFuncionario;
        }
        
        [Given(@"I have entered ""(.*)"" into the Status")]
        public void GivenIHaveEnteredIntoTheStatus(string novoStatus)
        {
            status.StatusFuncionario = novoStatus;
        }
        
        [When(@"I press AlterarStatus")]
        public void WhenIPressAlterarStatus()
        {
            result = testAlteraStatus.TestBDD(status.IdFuncionario, status.StatusFuncionario);
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedResult)
        {
            Assert.AreEqual(expectedResult, result);
        }
    }
}
