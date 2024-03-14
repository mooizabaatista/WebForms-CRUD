using System;

namespace FuncManager.EntityLayer
{
    public class Funcionario
    {
        public int? Id { get; set; }
        public string NomeCompleto { get; set; }
        public decimal Salario { get; set; }
        public string TerminoContrato{ get; set; }
        public Departamento Departamento { get; set; }
    }
}
