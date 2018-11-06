namespace UnitTestsProject
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RegrasNegocio;
    using System;

    [TestClass]
    public class TestAlteraStatusFuncionario : ClasseBaseTestesUnitarios
    {

        public int TestBDD(int id, string status)
        {
            var salario = 999.99M;
            var tablePessoa = CriaTabelaPessoa(salario, 'N', new DateTime(2008, 1, 1));

            var tableDependentes = CriatabelaDependentes(1, new DadosDependente[] {
                new DadosDependente{Sexo = 'F', Nascimento = new DateTime(2009,07,01)},
                new DadosDependente{Sexo = 'F', Nascimento = new DateTime(2009,06,01)}
            });


            var log = new LogWriter();
            var logErros = new LogWriter();
            var persistencia = StubPersistencia(tablePessoa, tableDependentes);
            var altera = new AlteraStatusFuncionario(persistencia, log, logErros);

            int idFuncionario = id;
            string novoStatus = status;

            return altera.AlteraStatus(idFuncionario, novoStatus);

        }

        [TestMethod]
        [TestCategory("AlteraStatus")]
        public void TesteAlteraStatusFuncionarioSucesso()
        {
            var salario = 999.99M;
            var tablePessoa = CriaTabelaPessoa(salario, 'N', new DateTime(2008, 1, 1));

            var tableDependentes = CriatabelaDependentes(1, new DadosDependente[] {
                new DadosDependente{Sexo = 'F', Nascimento = new DateTime(2009,07,01)},
                new DadosDependente{Sexo = 'F', Nascimento = new DateTime(2009,06,01)}
            });


            var log = new LogWriter();
            var logErros = new LogWriter();
            var persistencia = StubPersistencia(tablePessoa, tableDependentes);
            var altera = new AlteraStatusFuncionario(persistencia, log, logErros);

            int idFuncionario = 1;
            string novoStatus = "S";

            int result = altera.AlteraStatus(idFuncionario, novoStatus);

            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        [TestCategory("AlteraStatus")]
        public void TesteAlteraStatusFuncionarioNaoEncontrado()
        {
            var salario = 999.99M;
            var tablePessoa = CriaTabelaPessoa(salario, 'N', new DateTime(2008, 1, 1));

            var tableDependentes = CriatabelaDependentes(1, new DadosDependente[] {
                new DadosDependente{Sexo = 'F', Nascimento = new DateTime(2009,07,01)},
                new DadosDependente{Sexo = 'F', Nascimento = new DateTime(2009,06,01)}
            });


            var log = new LogWriter();
            var logErros = new LogWriter();
            var persistencia = StubPersistencia(tablePessoa, tableDependentes);
            var altera = new AlteraStatusFuncionario(persistencia, log, logErros);

            int idFuncionario = 2;
            string novoStatus = "S";

            int result = altera.AlteraStatus(idFuncionario, novoStatus);

            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        [TestCategory("AlteraStatus")]
        public void TesteAlteraStatusFuncionarioStatusInvalido()
        {
            var salario = 999.99M;
            var tablePessoa = CriaTabelaPessoa(salario, 'N', new DateTime(2008, 1, 1));

            var tableDependentes = CriatabelaDependentes(1, new DadosDependente[] {
                new DadosDependente{Sexo = 'F', Nascimento = new DateTime(2009,07,01)},
                new DadosDependente{Sexo = 'F', Nascimento = new DateTime(2009,06,01)}
            });


            var log = new LogWriter();
            var logErros = new LogWriter();
            var persistencia = StubPersistencia(tablePessoa, tableDependentes);
            var altera = new AlteraStatusFuncionario(persistencia, log, logErros);

            int idFuncionario = 0;
            string novoStatus = "X";

            int result = altera.AlteraStatus(idFuncionario, novoStatus);

            Assert.AreEqual(result, 0);
        }
    }

}
