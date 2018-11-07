using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegrasNegocio;
using System;
using TechTalk.SpecFlow;

namespace UnitTestsProject
{
    [Binding]
    public class ExcluirFuncionariosInativosSteps
    {

        private int result = 0;
        TestExcluiFuncionariosInativos test = new TestExcluiFuncionariosInativos();
        Funcionario tableFuncionario = new Funcionario();

        [Given(@"I have one inactive employee in database")]
        public void GivenIHaveOneInactiveEmployeeInDatabase()
        {
            tableFuncionario = new Funcionario()
            {
                id = 1,
                ativo = 'N',
                nome = "NomeFuncionário",
                email = "email@email.com",
                nascimento = new DateTime(1990, 1, 1),
                inicioContrato = new DateTime(2008, 1, 1),
                sexo = 'M',
                salario = 1000
            };
        }

        [When(@"I press ExcluirInativos")]
        public void WhenIPressExcluirInativos()
        {
            result = test.TestBDD(tableFuncionario);
        }

        [Then(@"the amount should be (.*)")]
        public void ThenTheAmountShouldBe(int expectedResult)
        {
            Assert.AreEqual(expectedResult, result);
        }
    }
}
