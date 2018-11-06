namespace RegrasNegocio
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class AlteraStatusFuncionario : IDisposable
    {
        public List<Funcionario> Funcionarios;
        public IPersistenciaFuncionario Persistencia { get; protected set; }

        protected ILogWriter InternalLog;

        protected ILogWriter InternalErrorLog;

        public string Log => InternalLog.LogContent;

        public string ErrorLog => InternalErrorLog.LogContent;


        public AlteraStatusFuncionario(IPersistenciaFuncionario access, ILogWriter logExecucao, ILogWriter logErros)
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

        public int AlteraStatus(int id, string novoStatus)
        {
            int result = 0;
            WriteLog($"****Processo de Alteração de Status - Iniciado em {DateTime.Now}");
            WriteLog(string.Empty);

            if ((id == 0) || (string.IsNullOrWhiteSpace(novoStatus)))
            {
                WriteLog($"Dados de alteração inválidos!");
                return result;
            }
            
            var funcionario = GetFuncionario(id.ToString());
            if (funcionario == null)
            {
                WriteLog($"Funcionário " + id + " não encontrado!");
                return result;
            }
            
            try
            {
                result = Persistencia.AlteraFuncionario(id, novoStatus);
                WriteLog($"Status do funcionário " + id + " alterado com sucesso!");
            }
            catch (Exception ex)
            {
                WriteError($"Erro ao alterar status do funcionário {funcionario.id}/{funcionario.nome}:{ex}");
            }
            return result;
        }


        public void Dispose()
        {
            Persistencia?.Dispose();
            Persistencia = null;
        }
    }
}
