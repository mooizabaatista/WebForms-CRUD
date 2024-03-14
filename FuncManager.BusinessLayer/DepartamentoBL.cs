using FuncManager.DataLayer;
using FuncManager.EntityLayer;
using System;
using System.Collections.Generic;

namespace FuncManager.BusinessLayer
{
    public class DepartamentoBL
    {
        DepartamentoDL departamentoDL = new DepartamentoDL();
        
        public List<Departamento> ObterDepartamentos()
        {
            try
            {
                return departamentoDL.ObterDepartamentos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
