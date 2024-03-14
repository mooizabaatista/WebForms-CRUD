using FuncManager.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FuncManager.DataLayer
{
    public class DepartamentoDL
    {
        public List<Departamento> ObterDepartamentos()
        {
            var departamentos = new List<Departamento>();

            using (SqlConnection conn = new SqlConnection(Conexao.ConexaoBanco))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM fn_departamentos()", conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            departamentos.Add(new Departamento
                            {
                                Id = Convert.ToInt32(dr["id"]),
                                Nome = dr["Nome"].ToString()
                            });
                        }
                    }

                    conn.Close();

                    return departamentos;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
