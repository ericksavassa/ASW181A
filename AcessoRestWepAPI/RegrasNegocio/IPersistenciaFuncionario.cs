using System.Data;
using DatabaseLib;
using System;
using System.Collections.Generic;

namespace RegrasNegocio
{
    public interface IPersistenciaFuncionario : IDisposable
    {
        //IDbAccess Access { get; }

        //ILogWriter Log { get; }

        //int PersisteFuncionario(DataRow row);
        //int PersisteFuncionario(DataSet dataSet);
        //int PersisteFuncionario(DataTable table);

        string LogContent { get; }
        DataSet RetornaFuncionariosDataSet();
        int PersisteFuncionario(Funcionario funcionario);
        int PersisteFuncionario(List<Funcionario> funcionarios);
        List<Funcionario> RetornaFuncionarios();
        Funcionario BuscaFuncionario(string id);
        int AlteraFuncionario(int id, string novoStatus);
        int ExcluiFuncionario(int id);
        void ClearLog();
    }
}