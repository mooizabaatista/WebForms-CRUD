using FuncManager.DataLayer;
using FuncManager.EntityLayer;
using System;
using System.Globalization;
using System.Web.UI;

namespace FuncManager.Web
{
    public partial class AddOrEdit : System.Web.UI.Page
    {
        private static int id = 0;
        DepartamentoDL departamentoDL = new DepartamentoDL();
        FuncionarioDL funcionarioDL = new FuncionarioDL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    id = Convert.ToInt32(Request.QueryString["id"]);

                    if (id != 0)
                    {
                        lblTitulo.Text = "Editar Funcionário";
                        btnSubmit.Text = "Editar";

                        Funcionario funcionario = funcionarioDL.ObterFuncionario(id);

                        txtNomeCompleto.Text = funcionario.NomeCompleto;
                        txtSalario.Text = funcionario.Salario.ToString();
                        txtTerminoContrato.Text = funcionario.TerminoContrato;
                        CarregarDepartamentos(funcionario.Departamento.Id.ToString());
                    }
                    else
                    {
                        lblTitulo.Text = "Adicionar Funcionário";
                        btnSubmit.Text = "Salvar";
                        CarregarDepartamentos();
                    }
                }
                else
                    Response.Redirect("~/Default.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (!ValidarCampos())
                return;


            var funcionario = new Funcionario
            {
                Id = id,
                NomeCompleto = txtNomeCompleto.Text,
                Salario = Convert.ToDecimal(txtSalario.Text),
                TerminoContrato = txtTerminoContrato.Text,
                Departamento = new Departamento { Id = Convert.ToInt32(ddlDepartamentos.SelectedValue) }
            };

            bool result;

            if (id != 0)
                result = funcionarioDL.EditarFuncionario(funcionario);
            else
                result = funcionarioDL.CriarFuncionario(funcionario);

            if (result)
                Response.Redirect("Default.aspx");
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Falha ao cadastrar o funcionário')", true);
        }

        private void CarregarDepartamentos(string departamentoId = "")
        {
            var departamentos = departamentoDL.ObterDepartamentos();

            ddlDepartamentos.DataTextField = "Nome";
            ddlDepartamentos.DataValueField = "Id";
            ddlDepartamentos.DataSource = departamentos;
            ddlDepartamentos.DataBind();

            if (!string.IsNullOrEmpty(departamentoId))
                ddlDepartamentos.SelectedValue = departamentoId;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNomeCompleto.Text))
            {
                MostrarAlerta("Por favor, insira um nome completo");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSalario.Text))
            {
                MostrarAlerta("Por favor, insira um valor para o salário");
                return false;
            }

            decimal salario;
            if (!decimal.TryParse(txtSalario.Text, out salario))
            {
                MostrarAlerta("Por favor, insira um valor de salário válido");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTerminoContrato.Text))
            {
                MostrarAlerta("Por favor, insira uma data para o término do contrato");
                return false;
            }

            if (string.IsNullOrWhiteSpace(ddlDepartamentos.SelectedValue))
            {
                MostrarAlerta("Por favor, selecione um departamento");
                return false;
            }

            return true;
        }

        private void MostrarAlerta(string mensagem)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", $"alert('{mensagem}')", true);
        }
    }
}