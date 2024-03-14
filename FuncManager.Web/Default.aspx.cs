using FuncManager.DataLayer;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FuncManager.Web
{
    public partial class _Default : Page
    {
        FuncionarioDL funcionarioDL = new FuncionarioDL();

        protected void Page_Load(object sender, EventArgs e)
        {
            ObterFuncionarios();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddOrEdit.aspx?id=0");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            LinkButton btnEditar = sender as LinkButton;
            var id = btnEditar.CommandArgument;

            Response.Redirect($"~/AddOrEdit.aspx?id={id}");
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            LinkButton btnExcluir = sender as LinkButton;
            var id = btnExcluir.CommandArgument;

            bool resultadoExclusao = funcionarioDL.RemoverFuncionario(Convert.ToInt32(id));

            if (resultadoExclusao)
                ObterFuncionarios();
        }

        private void ObterFuncionarios()
        {
            gvFuncionarios.DataSource = funcionarioDL.ObterFuncionarios();
            gvFuncionarios.DataBind();
        }

        
    }
}