using FuncManager.DataLayer;
using FuncManager.EntityLayer;
using System;
using System.Collections.Generic;

namespace FuncManager.BusinessLayer
{
    public class FuncionarioBL
    {
        FuncionarioDL funcionarioDL = new FuncionarioDL();

        public List<Funcionario> ObterFuncionarios()
        {
            try
            {
                return funcionarioDL.ObterFuncionarios();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Funcionario ObterFuncionario(int id)
        {
            try
            {
                return funcionarioDL.ObterFuncionario(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CriarFuncionario(Funcionario funcionario)
        {
            try
            {
                if (!ValidarFuncionario(funcionario))
                    return false;

                return funcionarioDL.CriarFuncionario(funcionario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditarFuncionario(Funcionario funcionario)
        {
            try
            {
                if(funcionario.Id == null || funcionario.Id <= 0)
                    throw new OperationCanceledException("Informe um funcionário válido para a edição!");

                var funcionarioEncontrado = funcionarioDL.ObterFuncionario(funcionario.Id);

                if(funcionarioEncontrado == null)
                    throw new OperationCanceledException("Funcionário não localizado!");

                if (!ValidarFuncionario(funcionario))
                    return false;

                return funcionarioDL.EditarFuncionario(funcionario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoverFuncionario(int id)
        {
            try
            {
                if(id <= 0)
                    throw new OperationCanceledException("Informe um funcionário válido para a exclusão!");

                return funcionarioDL.RemoverFuncionario(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidarFuncionario(Funcionario funcionario)
        {
            if (string.IsNullOrEmpty(funcionario.NomeCompleto))
                throw new OperationCanceledException("O nome do funcionário é obrigatório!");

            else if (funcionario.TerminoContrato == DateTime.MinValue ||
                    funcionario.TerminoContrato == null ||
                    funcionario.TerminoContrato < DateTime.Now)
                throw new OperationCanceledException("Informe uma data de término de contrato válida!");

            else if (funcionario.Departamento.Id <= 0)
                throw new OperationCanceledException("Informe um departamento válido!");

            else if(funcionario.Salario <= 0)
                throw new OperationCanceledException("Informe um valor de salário válido!");

            return true;
        }
    }
}
