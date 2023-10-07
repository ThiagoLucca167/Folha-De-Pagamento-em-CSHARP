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
    public partial class RHHistoricoFuncionario : UserControl
    {
        public RHHistoricoFuncionario()
        {
            InitializeComponent();
        }

        private void btnListarFuncionario_Click(object sender, EventArgs e)
        {
            string conexao = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HoleriteFuncionarios; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            try
            {
                SqlConnection con = new SqlConnection(conexao);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM FuncionarioBD", con);
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch
            {
                throw;
            }
        }

        private void btnBuscarFuncionario_Click(object sender, EventArgs e)
        {
            string cpf = textBoxCpf.Text;
            HFuncionarios c = new HFuncionarioBD().buscar(cpf);
            textBoxCpf.Text = c.Cpf;
            List<string> cpfList = new List<string> { c.Cpf };
            string conexao = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HoleriteFuncionarios;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                // Usando uma declaração 'using' para garantir que a conexão seja fechada automaticamente
                using (SqlConnection con = new SqlConnection(conexao))
                {
                    con.Open(); // Abre a conexão com o banco de dados
                    // Consulta SQL para selecionar o cliente com base no CPF
                    string consultaSql = "SELECT * FROM FuncionarioBD WHERE Cpf = @cpf";
                    // Cria um comando SQL com a consulta e associa o parâmetro @cpf ao valor do CPF digitado
                    SqlCommand cmd = new SqlCommand(consultaSql, con);
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    DataTable dt = new DataTable(); // Cria uma tabela de dados para armazenar os resultados da consulta
                    // Um SqlDataAdapter é usado para preencher a tabela de dados com os resultados da consulta
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(dt); // Preenche a tabela de dados com os resultados
                    if (dt.Rows.Count > 0)
                    {
                        // Se encontrou resultados, exiba as informações no DataGridView
                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        // Caso contrário, exiba uma mensagem informando que o cliente não foi encontrado
                        MessageBox.Show("Cliente não encontrado.");
                    }
                    con.Close(); // Fecha a conexão com o banco de dados após a conclusão da operação
                }
            }
            catch (Exception ex)
            {
                // Trata exceções, se ocorrerem, e exibe uma mensagem de erro
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
                // Chama a função LimparTela para limpar a tela
                LimparTela();
        }
        private void LimparTela()
        {
            // Limpa todos os campos de entrada (TextBoxes)
            textBoxCpf.Clear();

            // Limpa o DataGridView definindo seu DataSource como null
            dataGridView1.DataSource = null;
        }
    }
}
