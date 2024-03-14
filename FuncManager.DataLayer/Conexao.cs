using System.Configuration;

namespace FuncManager.DataLayer
{
    public class Conexao
    {
        public static string ConexaoBanco = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
    }
}
