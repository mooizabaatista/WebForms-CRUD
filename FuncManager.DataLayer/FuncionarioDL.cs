using FuncManager.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FuncManager.DataLayer
{
    public class FuncionarioDL
    {
        public List<Funcionario> ObterFuncionarios()
        {
            var funcionarios = new List<Funcionario>();

            using (SqlConnection conn = new SqlConnection(Conexao.ConexaoBanco))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM fn_funcionarios()", conn);
                cmd.CommandType = CommandType.Text;

                try
                {
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            funcionarios.Add(new Funcionario
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                NomeCompleto = dr["NomeCompleto"].ToString(),
                                Departamento = new Departamento
                                {
                                    Id = Convert.ToInt32(dr["DepartamentoId"]),
                                    Nome = dr["Departamento"].ToString()
                                },
                                Salario = Convert.ToDecimal(dr["Salario"]),
                                TerminoContrato = Convert.ToDateTime(dr["TerminoContrato"]).ToString("dd/MM/yyyy")
                            });
                        }
                    }

                    conn.Close();

                    return funcionarios;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public Funcionario ObterFuncionario(int? id)
        {
            var funcionario = new Funcionario();

            using (SqlConnection conn = new SqlConnection(Conexao.ConexaoBanco))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM fn_funcionario(@Id)", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandType = CommandType.Text;

                try
                {
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        if (dr.Read())
                        {
                            funcionario = new Funcionario
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                NomeCompleto = dr["NomeCompleto"].ToString(),
                                Departamento = new Departamento
                                {
                                    Id = Convert.ToInt32(dr["DepartamentoId"]),
                                    Nome = dr["Departamento"].ToString()
                                },
                                Salario = Convert.ToDecimal(dr["Salario"]),
                                TerminoContrato = dr["TerminoContrato"].ToString()
                            };
                        }
                    }

                    conn.Close();

                    return funcionario;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool CriarFuncionario(Funcionario funcionario)
        {
            bool resultadoCadastro = false;

            using (SqlConnection conn = new SqlConnection(Conexao.ConexaoBanco))
            {
                SqlCommand cmd = new SqlCommand("sp_CriarFuncionario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NomeCompleto", funcionario.NomeCompleto);
                cmd.Parameters.AddWithValue("@DepartamentoId", funcionario.Departamento.Id);
                cmd.Parameters.AddWithValue("@Salario", funcionario.Salario);
                cmd.Parameters.AddWithValue("@TerminoContrato", funcionario.TerminoContrato);

                try
                {
                    conn.Open();

                    int linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                        resultadoCadastro = true;

                    conn.Close();

                    return resultadoCadastro;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool EditarFuncionario(Funcionario funcionario)
        {
            bool resultadoEdicao = false;

            using (SqlConnection conn = new SqlConnection(Conexao.ConexaoBanco))
            {
                SqlCommand cmd = new SqlCommand("sp_EditarFuncionario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", funcionario.Id);
                cmd.Parameters.AddWithValue("@NomeCompleto", funcionario.NomeCompleto);
                cmd.Parameters.AddWithValue("@DepartamentoId", funcionario.Departamento.Id);
                cmd.Parameters.AddWithValue("@Salario", funcionario.Salario);
                cmd.Parameters.AddWithValue("@TerminoContrato", funcionario.TerminoContrato);

                try
                {
                    conn.Open();

                    int linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                        resultadoEdicao = true;

                    conn.Close();

                    return resultadoEdicao;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool RemoverFuncionario(int id)
        {
            bool resultadoRemocao = false;

            using (SqlConnection conn = new SqlConnection(Conexao.ConexaoBanco))
            {
                SqlCommand cmd = new SqlCommand("sp_RemoverFuncionario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    conn.Open();

                    int linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                        resultadoRemocao = true;

                    conn.Close();

                    return resultadoRemocao;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
