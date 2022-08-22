using Microsoft.Data.SqlClient;

namespace Cursos.Conection
{
    public class Conexao
    {
        SqlConnection con = new SqlConnection();
        const string connectionString = @"Data Source=usinacompany.com;User ID=usina_usrmentoria;Password=Abc12345;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Conexao()
        {
            con.ConnectionString = connectionString;
        }

        public SqlConnection conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
