using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace teste_de_crud_em_txt
{
    public partial class FolhaPagamento : UserControl
    {
        public FolhaPagamento()
        {
            InitializeComponent();
        }

        private void btnBuscarFuncionario_Click(object sender, EventArgs e)
        {
            string cpf = textBoxCpf.Text;
            HFuncionarios c = new HFuncionarioBD().buscar(cpf);
            textBoxCpf.Text = c.Cpf;

            string conexao = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HoleriteFuncionarios;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                using (SqlConnection con = new SqlConnection(conexao))
                {
                    con.Open();
                    // Consulta SQL para selecionar o departamento e data de admissão com base no CPF
                    string consultaSql = "SELECT NumeroCarteiraTrabalho,Departamento, DataAdmissao,Salario,CargaHoraria,Imposto,Fgts,ValorVT,ValorVR,ValorVA FROM FuncionarioBD WHERE Cpf = @cpf";
                    SqlCommand cmd = new SqlCommand(consultaSql, con);
                    cmd.Parameters.AddWithValue("@cpf", cpf);

                    // Execute a consulta SQL e obtenha um SqlDataReader
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) // Verifique se há resultados
                    {
                        // Obtém os valores de departamento e data de admissão do SqlDataReader
                        string departamento = reader["Departamento"].ToString();
                        string numerocarteiratrabalho = reader["NumeroCarteiraTrabalho"].ToString();
                        string dataAdmissao = reader["DataAdmissao"].ToString();
                        string cargaHoraria = reader["CargaHoraria"].ToString();
                        string salario = reader["Salario"].ToString();
                        string valorVT = reader["ValorVT"].ToString();
                        string valorVR = reader["ValorVR"].ToString();
                        string valorVA = reader["ValorVA"].ToString();

                        // Converter as strings em valores numéricos
                        decimal vt = decimal.TryParse(valorVT, out decimal parsedVT) ? parsedVT : 0.0m;
                        decimal vr = decimal.TryParse(valorVR, out decimal parsedVR) ? parsedVR : 0.0m;
                        decimal va = decimal.TryParse(valorVA, out decimal parsedVA) ? parsedVA : 0.0m;
                        decimal pag = decimal.TryParse(salario, out decimal parsedPAG) ? parsedPAG : 0.0m;
                        decimal valorIrfMes = 0.10m; // 10%
                        decimal irfMes = pag * valorIrfMes;
                        decimal valorFgtsMes = 0.08m; // 8%
                        decimal fgtsMes = pag * valorFgtsMes;
                        decimal remuneracao = pag + vt + vr + va;
                        decimal beneficios = vt + vr + va;
                        string RemuneracaoBase = pag.ToString();
                        string remuneracaoOfic = remuneracao.ToString();
                        string beneficiosOfic = beneficios.ToString();
                        string status = "ativo";
                        string calcFgts = "8 % de Base Salario";
                        string calcIrf = "10 % de Base Salario";
                        string FgtsValorOfic = fgtsMes.ToString("N2");
                        string IrfValorOfic = irfMes.ToString("N2");

                        // Exiba os valores nos TextBoxes correspondentes
                        textBoxDepartamento.Text = departamento;
                        textBoxDataAdmissao.Text = dataAdmissao;
                        textBoxCargaHoraria.Text = cargaHoraria;
                        textBoxBeneficios.Text = beneficiosOfic;
                        textBoxRemuneracao.Text = remuneracaoOfic;
                        textBoxStatus.Text = status;
                        textBoxMatricula.Text = numerocarteiratrabalho;
                        textBoxRemuneracao.Text = remuneracaoOfic;
                        textBoxSalarioBase.Text = RemuneracaoBase;
                        textBoxCalcFgts.Text = calcFgts;
                        textBoxFgts.Text = FgtsValorOfic;
                        textBoxCalcIrf.Text = calcIrf;
                        textBoxIRF.Text = IrfValorOfic;

                        DataTable dt = new DataTable();
                        // Adicione colunas ao DataTable
                        dt.Columns.Add("Codigo", typeof(string));
                        dt.Columns.Add("Descrição", typeof(string));
                        dt.Columns.Add("Referencia", typeof(decimal));
                        dt.Columns.Add("Vencimentos", typeof(decimal));
                        dt.Columns.Add("Descontos", typeof(decimal));
                        // Adicione informações estáticas ao DataTable
                        dt.Rows.Add("101", "Salario", 30.00m,remuneracaoOfic, 00.00m);
                        dt.Rows.Add("150", "Inss Sobre Salario", 9.00m, 00.00m, 143.00m);
                        dt.Rows.Add("159", "Adiantamento Anterior", 00.00m, 00.00m, 00.00m);
                        dt.Rows.Add("1047", "Assist. Medica", 00.00m, 00.00m, 15.00m);
                        // Atribua o DataTable como a fonte de dados do DataGridView
                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        // Caso contrário, exiba uma mensagem informando que o funcionário não foi encontrado
                        MessageBox.Show("Funcionário não encontrado.");
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
            textBoxDepartamento.Clear();
            textBoxDataAdmissao.Clear();
            textBoxCargaHoraria.Clear();
            textBoxBeneficios.Clear();
            textBoxRemuneracao.Clear();
            textBoxStatus.Clear();
            textBoxMatricula.Clear();
            textBoxRemuneracao.Clear();
            textBoxSalarioBase.Clear();
            textBoxCalcFgts.Clear();
            textBoxFgts.Clear();
            textBoxCalcIrf.Clear();
            textBoxIRF.Clear();

            // Limpa o DataGridView definindo seu DataSource como null
            dataGridView1.DataSource = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Verifique se o campo de pesquisa está vazio
            if (string.IsNullOrWhiteSpace(textBoxCpf.Text))
            {
                MessageBox.Show("Por favor, preencha o campo de CPF e click no Botão Buscar antes de Salvar.");
            }
            else
            {
                // Obtenha as informações atualizadas dos campos TextBox
                string nome = "Holerite";
                string cpf = textBoxCpf.Text;
                string departamento = textBoxDepartamento.Text;
                string dataAdmissao = textBoxDataAdmissao.Text;
                string cargaHoraria = textBoxCargaHoraria.Text;
                string beneficios = textBoxBeneficios.Text;
                string status = textBoxStatus.Text;
                string matricula = textBoxMatricula.Text;
                string remuneracao = textBoxRemuneracao.Text;
                string salarioBase = textBoxSalarioBase.Text;
                string calcFgts = textBoxCalcFgts.Text;
                string fgts = textBoxFgts.Text;
                string calcIrf = textBoxCalcIrf.Text;
                string irf = textBoxIRF.Text;

                // Chame a função para gerar o PDF
                GerarPDF(nome, cpf, departamento, dataAdmissao, cargaHoraria, beneficios, status, matricula, remuneracao, salarioBase, calcFgts, fgts, calcIrf, irf);

            }

        }

        private void GerarPDF(string nome, string cpf, string departamento,string dataAdmissao, string cargaHoraria, string beneficios, string status, string matricula, string remuneracao, string salarioBase, string calcFgts, string fgts, string calcIrf, string irf)
        {
            // Crie um documento PDF
            Document doc = new Document();

            // Especifique o caminho onde deseja salvar o arquivo PDF
            string caminhoPDF = "C:\\Users\\thiag\\OneDrive\\Área de Trabalho\\" + nome + ".pdf";

            // Crie um objeto FileStream para escrever o PDF
            FileStream fs = new FileStream(caminhoPDF, FileMode.Create);

            // Vincule o documento PDF ao objeto FileStream
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            // Abra o documento para escrita
            doc.Open();

            // Adicione conteúdo ao documento
            Paragraph paragraph = new Paragraph("Informações do Funcionário\n\n" +
                "Nome: " + nome + "\n" +
                "CPF: " + cpf + "\n" +
                "Departamento: " + departamento + "\n" +
                "Data de Admissão: " + dataAdmissao + "\n" +
                "Carga Horária: " + cargaHoraria + "\n" +
                "Benefícios: " + beneficios + "\n" +
                "Status: " + status + "\n" +
                "Matrícula: " + matricula + "\n" +
                "Remuneração: " + remuneracao + "\n" +
                "Salário Base: " + salarioBase + "\n" +
                "Cálculo FGTS: " + calcFgts + "\n" +
                "FGTS: " + fgts + "\n" +
                "Cálculo IRF: " + calcIrf + "\n" +
                "IRF: " + irf);

            doc.Add(paragraph);

            // Feche o documento
            doc.Close();

            // Feche o arquivo FileStream
            fs.Close();

            // Abra o PDF no visualizador padrão
            System.Diagnostics.Process.Start(caminhoPDF);
        }

        private void FolhaPagamento_Load(object sender, EventArgs e)
        {

        }
    }
}

