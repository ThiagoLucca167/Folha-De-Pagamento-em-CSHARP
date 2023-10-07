using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace teste_de_crud_em_txt
{
    public partial class Funcionario : UserControl
    {
        public Funcionario()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnCadastrarFuncionario_Click(object sender, EventArgs e)
        {
            string cpf = "", nome = "", login = "", senha = "", email = "", telefone = "", registroGeral = "", dataNascimento="", pis = "", nacionalidade = "",
                numeroCarteiraTrabalho="", estado = "", cidade = "", cep = "", bairro = "", logradouro = "", complemento = "", numeroResidencial = "",
                nomeBanco = "", codigoBanco = "", contaBancaria = "", agencia = "", tipoConta = "", imposto = "", fgts = "", inss = "",
                departamento = "", cargo = "", dataAdmissao = "", cargaHoraria = "", salario = "", valorVT = "", valorVR = "", valorVA = "";
            

            cpf = textBoxCpf.Text;
            nome = textBoxNomeCompleto.Text;
            login = textBoxLogin.Text;
            senha = textBoxSenha.Text;
            email = textBoxEmail.Text;
            telefone = textBoxTelefone.Text;
            registroGeral = textBoxRegistroGeral.Text;
            dataNascimento = textBoxDataNascimento.Text;
            pis = textBoxPis.Text;
            nacionalidade = textBoxNacionalidade.Text;
            numeroCarteiraTrabalho = textBoxNumeroCarteiraTrabalho.Text;
            estado = textBoxEstado.Text;
            cidade = textBoxCidade.Text;
            cep = textBoxCep.Text;
            bairro = textBoxBairro.Text;
            logradouro = textBoxLogradouro.Text;
            complemento = textBoxComplemento.Text;
            numeroResidencial = textBoxNumeroResidencial.Text;
            nomeBanco = textBoxNomeBanco.Text;
            codigoBanco = textBoxCodigoBanco.Text;
            contaBancaria = textBoxContaBancaria.Text;
            agencia = textBoxAgencia.Text;
            tipoConta = textBoxTipoConta.Text;
            imposto = textBoxImposto.Text;
            fgts = textBoxFgts.Text;
            inss = textBoxInss.Text;
            departamento = textBoxDepartamento.Text;
            cargo = textBoxCargo.Text;
            dataAdmissao = textBoxDataAdmissao.Text;
            cargaHoraria = textBoxCargaHoraria.Text;
            salario = textBoxSalario.Text;
            valorVT = textBoxValorVt.Text;
            valorVR = textBoxValorVr.Text;
            valorVA = textBoxValorVa.Text;
            bool ok = new HFuncionarioBD().cadastrarHBD(new HFuncionarios(cpf,nome, login, senha,email, telefone, registroGeral, dataNascimento, pis
                , nacionalidade, numeroCarteiraTrabalho, estado, cidade, cep, bairro, logradouro, complemento, numeroResidencial, nomeBanco, codigoBanco
                , contaBancaria, agencia, tipoConta, imposto, fgts, inss, departamento, cargo, dataAdmissao, cargaHoraria, salario, valorVT, valorVR, valorVA));
            if (ok)

            {
                List<HFuncionarios> lista = new HFuncionarioBD().listar();
                MessageBox.Show("Dados cadastrados com sucesso!", "Novo Cadastro");
            }
            else
                MessageBox.Show("Erro ao tentar realizar novo cadastro", "Novo Cadastro");
            // limpar TextBox 
            textBoxNomeCompleto.Text = "";
            textBoxLogin.Text = "";
            textBoxSenha.Text = "";

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAlterarFuncionario_Click(object sender, EventArgs e)
        {
            string cpf, nome, login, senha, email, telefone, registroGeral, dataNascimento, pis, nacionalidade,
                numeroCarteiraTrabalho, estado, cidade, cep, bairro, logradouro, complemento, numeroResidencial,
                nomeBanco, codigoBanco, contaBancaria, agencia, tipoConta, imposto, fgts, inss,
                departamento, cargo, dataAdmissao, cargaHoraria, salario, valorVT, valorVR, valorVA;
            //int id;
            //id = Convert.ToInt32(textBoxId.Text);
            cpf = textBoxCpf.Text;
            nome = textBoxNomeCompleto.Text;
            login = textBoxLogin.Text;
            senha = textBoxSenha.Text;
            email = textBoxEmail.Text;
            telefone = textBoxTelefone.Text;
            registroGeral = textBoxRegistroGeral.Text;
            dataNascimento = textBoxDataNascimento.Text;
            pis = textBoxPis.Text;
            nacionalidade = textBoxNacionalidade.Text;
            numeroCarteiraTrabalho = textBoxNumeroCarteiraTrabalho.Text;
            estado = textBoxEstado.Text;
            cidade = textBoxCidade.Text;
            cep = textBoxCep.Text;
            bairro = textBoxBairro.Text;
            logradouro = textBoxLogradouro.Text;
            complemento = textBoxComplemento.Text;
            numeroResidencial = textBoxNumeroResidencial.Text;
            nomeBanco = textBoxNomeBanco.Text;
            codigoBanco = textBoxCodigoBanco.Text;
            contaBancaria = textBoxContaBancaria.Text;
            agencia = textBoxAgencia.Text;
            tipoConta = textBoxTipoConta.Text;
            imposto = textBoxImposto.Text;
            fgts = textBoxFgts.Text;
            inss = textBoxInss.Text;
            departamento = textBoxDepartamento.Text;
            cargo = textBoxCargo.Text;
            dataAdmissao = textBoxDataAdmissao.Text;
            cargaHoraria = textBoxCargaHoraria.Text;
            salario = textBoxSalario.Text;
            valorVT = textBoxValorVt.Text;
            valorVR = textBoxValorVr.Text;
            valorVA = textBoxValorVa.Text;

            bool ok = new HFuncionarioBD().alterar(new HFuncionarios(cpf, nome, login, senha, email, telefone, registroGeral, dataNascimento, pis
                , nacionalidade, numeroCarteiraTrabalho, estado, cidade, cep, bairro, logradouro, complemento, numeroResidencial, nomeBanco, codigoBanco
                , contaBancaria, agencia, tipoConta, imposto, fgts, inss, departamento, cargo, dataAdmissao, cargaHoraria, salario, valorVT, valorVR, valorVA));
            if (ok)
            {
                List<HFuncionarios> lista = new HFuncionarioBD().listar();
                MessageBox.Show("Dados alterados com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro ao tentar alterar cadastro");
            }

        }
        
        private void btnBuscarFuncionario_Click(object sender, EventArgs e)
        {
            string cpf = textBoxCpf.Text;
            HFuncionarios c = new HFuncionarioBD().buscar(cpf) ;
            textBoxCpf.Text = c.Cpf;
            textBoxNomeCompleto.Text = c.Nome;
            textBoxLogin.Text = c.Login;
            textBoxSenha.Text = c.Senha;
            textBoxEmail.Text = c.Email;
            textBoxTelefone.Text = c.Telefone;
            textBoxRegistroGeral.Text = c.RegistroGeral;
            textBoxDataNascimento.Text = c.DataNascimento;
            textBoxPis.Text = c.Pis;
            textBoxNacionalidade.Text = c.Nacionalidade;
            textBoxNumeroCarteiraTrabalho.Text = c.NumeroCarteiraTrabalho;
            textBoxEstado.Text = c.Estado;
            textBoxCidade.Text = c.Cidade;
            textBoxCep.Text = c.Cep;
            textBoxBairro.Text = c.Bairro;
            textBoxLogradouro.Text = c.Logradouro;
            textBoxComplemento.Text = c.Complemento;
            textBoxNumeroResidencial.Text = c.NumeroResidencial;
            textBoxNomeBanco.Text = c.NomeBanco;
            textBoxCodigoBanco.Text = c.CodigoBanco;
            textBoxContaBancaria.Text = c.ContaBancaria;
            textBoxAgencia.Text = c.Agencia;
            textBoxTipoConta.Text = c.TipoConta;
            textBoxImposto.Text = c.Imposto;
            textBoxFgts.Text = c.Fgts;
            textBoxInss.Text = c.Inss;
            textBoxDepartamento.Text = c.Departamento;
            textBoxCargo.Text = c.Cargo;
            textBoxDataAdmissao.Text = c.DataAdmissao;
            textBoxCargaHoraria.Text = c.CargaHoraria;
            textBoxSalario.Text = c.Salario;
            textBoxValorVt.Text = c.ValorVT;
            textBoxValorVr.Text = c.ValorVR;
            c.ValorVA = textBoxValorVa.Text;
        }
    }

}

