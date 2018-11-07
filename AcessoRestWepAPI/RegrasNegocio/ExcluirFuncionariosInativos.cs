namespace RegrasNegocio
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class ExcluirFuncionariosInativos : IDisposable
    {
        public List<Funcionario> Funcionarios;
        public IPersistenciaFuncionario Persistencia { get; protected set; }

        protected ILogWriter InternalLog;

        protected ILogWriter InternalErrorLog;

        public string Log => InternalLog.LogContent;

        public string ErrorLog => InternalErrorLog.LogContent;


        public ExcluirFuncionariosInativos(IPersistenciaFuncionario access, ILogWriter logExecucao, ILogWriter logErros)
        {
            Persistencia = access;
            InternalLog = logExecucao;
            InternalErrorLog = logErros;
        }

        protected void WriteLog(string line)
        {
            InternalLog.WriteLog(line);
        }

        protected void WriteError(string line)
        {
            InternalErrorLog.WriteLog(line);
        }

        public Funcionario GetFuncionario(string id)
        {
            return Persistencia.BuscaFuncionario(id);
        }

        public int ExcluirInativos()
        {
            int result = 0;
            WriteLog($"****Processo de Exclusão de Inatvios - Iniciado em {DateTime.Now}");
            WriteLog(string.Empty);

            var funcionarios = Persistencia.RetornaFuncionarios();
            if (funcionarios == null || !funcionarios.Any())
            {
                WriteLog($"Nenhum funcionário encontrado!");
                return result;
            }

            var funcionariosInativos = funcionarios.Where((f) => f.ativo == 'N');
            if (funcionariosInativos == null || !funcionariosInativos.Any())
            {
                WriteLog($"Nenhum funcionário inativo encontrado!");
                return result;
            }

            int qtddFuncionatiosExcluidos = 0;

            try
            {
                foreach (var item in funcionariosInativos)
                {
                    Persistencia.ExcluiFuncionario(item.id);
                    WriteLog($"Funcionário " + item.id + " excluído com sucesso!");
                    qtddFuncionatiosExcluidos++;
                }
            }
            catch (Exception)
            {
                WriteError($"Erro ao excluir funcionário inativos!");
            }
            WriteLog(qtddFuncionatiosExcluidos + $" funcionário(s) inativo(s) excluído(s) com sucesso!");
            return qtddFuncionatiosExcluidos;
        }

        public void Dispose()
        {
            Persistencia?.Dispose();
            Persistencia = null;
        }
    }
}
