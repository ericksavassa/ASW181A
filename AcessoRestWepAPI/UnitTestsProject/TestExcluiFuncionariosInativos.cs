namespace UnitTestsProject
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RegrasNegocio;
    using System;

    [TestClass]
    public class TestExcluiFuncionariosInativos : ClasseBaseTestesUnitarios
    {

        public int TestBDD(Funcionario tablePessoa)
        {
            var salario = 999.99M;

            var tableDependentes = CriatabelaDependentes(1, new DadosDependente[] {
                new DadosDependente{Sexo = 'F', Nascimento = new DateTime(2009,07,01)},
                new DadosDependente{Sexo = 'F', Nascimento = new DateTime(2009,06,01)}
            });


            var log = new LogWriter();
            var logErros = new LogWriter();
            var persistencia = StubPersistencia(tablePessoa, tableDependentes);
            var exclui = new ExcluirFuncionariosInativos(persistencia, log, logErros);

            return exclui.ExcluirInativos();
        }

        [TestMethod]
        [TestCategory("ExcluiInativos")]
        public void TesteExcluiFuncionariosInativosSucesso()
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
            var exclui = new ExcluirFuncionariosInativos(persistencia, log, logErros);

            int result = exclui.ExcluirInativos();

            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        [TestCategory("ExcluiInativos")]
        public void TesteExcluiFuncionariosInativosNaoEncontrados()
        {
            var salario = 999.99M;
            var tablePessoa = CriaTabelaPessoa(salario, 'S', new DateTime(2008, 1, 1));

            var tableDependentes = CriatabelaDependentes(1, new DadosDependente[] {
                new DadosDependente{Sexo = 'F', Nascimento = new DateTime(2009,07,01)},
                new DadosDependente{Sexo = 'F', Nascimento = new DateTime(2009,06,01)}
            });

            var log = new LogWriter();
            var logErros = new LogWriter();
            var persistencia = StubPersistencia(tablePessoa, tableDependentes);
            var exclui = new ExcluirFuncionariosInativos(persistencia, log, logErros);

            int result = exclui.ExcluirInativos();

            Assert.AreEqual(result, 0);
        }
    }
}
