using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace teste_de_crud_em_txt
{
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }
        public string NomeFuncionario { get; set; }

        private void btnValidaLogin_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string senha = textBoxSenha.Text;
            string nomeFuncionario = string.Empty;
            string conexao = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HoleriteFuncionarios;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                using (SqlConnection con = new SqlConnection(conexao))
                {
                    con.Open();

                    // Consulta SQL para verificar se o login e a senha correspondem a um funcionário
                    string consultaSql = "SELECT Nome FROM FuncionarioBD WHERE Login = @login AND Senha = @senha";

                    // Cria um comando SQL com a consulta e associa os parâmetros
                    SqlCommand cmd = new SqlCommand(consultaSql, con);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    // Executa a consulta e obtém o resultado (nome do funcionário)
                    nomeFuncionario = cmd.ExecuteScalar() as string;
                    string userLogin = "Admin";
                    string userSenha = "Pass123";

                    if (!string.IsNullOrEmpty(nomeFuncionario))
                    {
                        // Se o nome do funcionário não estiver vazio, o login e a senha são válidos
                        this.NomeFuncionario = nomeFuncionario;
                        string primeiroNome = nomeFuncionario.Split(' ')[0];
                        TelaFuncionario telaFun = new TelaFuncionario();
                        telaFun.AtualizarNomeFuncionario(primeiroNome); // Atualize o nome no formulário de funcionário
                        telaFun.Show();

                        // Fecha a tela de login
                        //this.Close();
                    }
                    else if(login == userLogin && senha == userSenha)
                    {
                        TeladeRH telaRH = new TeladeRH();
                        telaRH.Show();

                        // Fecha a tela de login
                        //this.Close();
                    }
                    else
                    {
                        // Caso contrário, não existe um funcionário com essas credenciais
                        MessageBox.Show("Não existe funcionário cadastrado com essas credenciais.");
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                // Trata exceções, se ocorrerem, e exibe uma mensagem de erro
                MessageBox.Show("Erro: " + ex.Message);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Olá! Se você esqueceu seu login e/ou senha, por favor, entre em contato com o administrador.","                                    Esqueceu a Senha?");
        }
    }
}
