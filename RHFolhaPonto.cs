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
    public partial class RHFolhaPonto : UserControl
    {
        public RHFolhaPonto()
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
                using (SqlConnection con = new SqlConnection(conexao))
                {
                    con.Open();
                    // Consulta SQL para selecionar o cliente com base no CPF
                    string consultaSql = "SELECT * FROM FuncionarioBD WHERE Cpf = @cpf";
                    SqlCommand cmd = new SqlCommand(consultaSql, con);
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    


                    DataTable dt = new DataTable();
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    // Adicione colunas ao DataTable
                    dt.Columns.Add("Dia", typeof(string));
                    dt.Columns.Add("Pontos de registro no sistema\nEntrada", typeof(string));
                    dt.Columns.Add("Saida Almoço", typeof(string));
                    dt.Columns.Add("Entrada Almoço", typeof(string));
                    dt.Columns.Add("Saida", typeof(string));
                    dt.Columns.Add("Horas Extras", typeof(decimal));
                    dt.Columns.Add("Adicional noturno", typeof(decimal));
                    // Adicione informações estáticas ao DataTable
                    dt.Rows.Add("13/09/2022", "08:00", "12:00", "13:00", "18:00", 00.00m, 00.00m);
                    dt.Rows.Add("12/09/2022", "08:00", "12:00", "13:00", "18:00", 00.00m, 00.00m);
                    dt.Rows.Add("11/09/2022", "08:00", "12:00", "13:00", "18:00", 00.00m, 00.00m);
                    dt.Rows.Add("10/09/2022", "08:00", "12:00", "13:00", "18:00", 00.00m, 00.00m);
                    dt.Rows.Add("09/09/2022", "08:00", "12:00", "13:00", "18:00", 00.00m, 00.00m);
                    dt.Rows.Add("06/09/2022", "08:00", "12:00", "13:00", "18:00", 00.00m, 00.00m);
                    dt.Rows.Add("05/09/2022", "08:00", "12:00", "13:00", "18:00", 00.00m, 00.00m);
                    dt.Rows.Add("04/09/2022", "08:00", "12:00", "13:00", "18:00", 00.00m, 00.00m);
                    dt.Rows.Add("03/09/2022", "08:00", "12:00", "13:00", "18:00", 00.00m, 00.00m);
                    dt.Rows.Add("02/09/2022", "08:00", "12:00", "13:00", "18:00", 00.00m, 00.00m);
                    // Atribua o DataTable como a fonte de dados do DataGridView
                    dataGridView1.DataSource = dt;


                    adapt.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        // Caso contrário, exiba uma mensagem informando que o cliente não foi encontrado
                        MessageBox.Show("Cliente não encontrado.");
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
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
