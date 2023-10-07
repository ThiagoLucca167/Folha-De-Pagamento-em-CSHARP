using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste_de_crud_em_txt
{
    public class HFuncionarios
    {
        private int id;
        private string cpf = "";
        private string nome = "";
        private string login = "";
        private string senha = "";
        private string email = "";
        private string telefone = "";
        private string registroGeral = "";
        private string dataNascimento = "";
        private string pis = "";
        private string nacionalidade = "";
        private string numeroCarteiraTrabalho = "";
        private string estado = "";
        private string cidade = "";
        private string cep = "";
        private string bairro = "";
        private string logradouro = "";
        private string complemento = "";
        private string numeroResidencial = "";
        private string nomeBanco = "";
        private string codigoBanco = "";
        private string contaBancaria = "";
        private string agencia = "";
        private string tipoConta = "";
        private string imposto = "";
        private string fgts = "";
        private string inss = "";
        private string departamento = "";
        private string cargo = "";
        private string cargaHoraria = "";
        private string dataAdmissao = "";
        private string salario = "";
        private string valorVT = "";
        private string valorVR = "";
        private string valorVA = "";

        public HFuncionarios()
        {
        }
        public HFuncionarios(string cpf, string nome, string login, string senha, string email, string telefone, string registroGeral, string dataNascimento, string pis, string nacionalidade, string numeroCarteiraTrabalho, string estado, string cidade, string cep, string bairro, string logradouro, string complemento, string numeroResidencial, string nomeBanco, string codigoBanco, string contaBancaria, string agencia, string tipoConta, string imposto, string fgts, string inss, string departamento, string cargo, string dataAdmissao, string cargaHoraria, string salario, string valorVT, string valorVR, string valorVA)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.login = login;
            this.senha = senha;
            this.email = email;
            this.telefone = telefone;
            this.registroGeral = registroGeral;
            this.dataNascimento = dataNascimento;
            this.pis = pis;
            this.nacionalidade = nacionalidade;
            this.numeroCarteiraTrabalho = numeroCarteiraTrabalho;
            this.estado = estado;
            this.cidade = cidade;
            this.cep = cep;
            this.bairro = bairro;
            this.logradouro = logradouro;
            this.complemento = complemento;
            this.numeroResidencial = numeroResidencial;
            this.nomeBanco = nomeBanco;
            this.codigoBanco = codigoBanco;
            this.contaBancaria = contaBancaria;
            this.agencia = agencia;
            this.tipoConta = tipoConta;
            this.imposto = imposto;
            this.fgts = fgts;
            this.inss = inss;
            this.departamento = departamento;
            this.cargo = cargo;
            this.dataAdmissao = dataAdmissao;
            this.cargaHoraria = cargaHoraria;
            this.salario = salario;
            this.valorVT = valorVT;
            this.valorVR = valorVR;
            this.valorVA = valorVA;
        }

        public HFuncionarios(int id, string cpf, string nome, string login, string senha, string email, string telefone, string registroGeral, string dataNascimento, string pis, string nacionalidade, string numeroCarteiraTrabalho, string estado, string cidade, string cep, string bairro, string logradouro, string complemento, string numeroResidencial, string nomeBanco, string codigoBanco, string contaBancaria, string agencia, string tipoConta, string imposto, string fgts, string inss, string departamento, string cargo, string dataAdmissao, string cargaHoraria, string salario, string valorVT, string valorVR, string valorVA)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.login = login;
            this.senha = senha;
            this.email = email;
            this.telefone = telefone;
            this.registroGeral = registroGeral;
            this.dataNascimento = dataNascimento;
            this.pis = pis;
            this.nacionalidade = nacionalidade;
            this.numeroCarteiraTrabalho = numeroCarteiraTrabalho;
            this.estado = estado;
            this.cidade = cidade;
            this.cep = cep;
            this.bairro = bairro;
            this.logradouro = logradouro;
            this.complemento = complemento;
            this.numeroResidencial = numeroResidencial;
            this.nomeBanco = nomeBanco;
            this.codigoBanco = codigoBanco;
            this.contaBancaria = contaBancaria;
            this.agencia = agencia;
            this.tipoConta = tipoConta;
            this.imposto = imposto;
            this.fgts = fgts;
            this.inss = inss;
            this.departamento = departamento;
            this.cargo = cargo;
            this.dataAdmissao = dataAdmissao;
            this.cargaHoraria = cargaHoraria;
            this.salario = salario;
            this.valorVT = valorVT;
            this.valorVR = valorVR;
            this.valorVA = valorVA;
        }

        public int Id { get => id; set => id = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Login { get => login; set => login = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Email { get => email; set => email = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string RegistroGeral { get => registroGeral; set => registroGeral = value; }
        public string DataNascimento { get => dataNascimento; set => dataNascimento = value; }
        public string Pis { get => pis; set => pis = value; }
        public string Nacionalidade { get => nacionalidade; set => nacionalidade = value; }
        public string NumeroCarteiraTrabalho { get => numeroCarteiraTrabalho; set => numeroCarteiraTrabalho = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Cidade { get => cidade; set => cidade = value; }
        public string Cep { get => cep; set => cep = value; }
        public string Bairro { get => bairro; set => bairro = value; }
        public string Logradouro { get => logradouro; set => logradouro = value; }
        public string Complemento { get => complemento; set => complemento = value; }
        public string NumeroResidencial { get => numeroResidencial; set => numeroResidencial = value; }
        public string NomeBanco { get => nomeBanco; set => nomeBanco = value; }
        public string CodigoBanco { get => codigoBanco; set => codigoBanco = value; }
        public string ContaBancaria { get => contaBancaria; set => contaBancaria = value; }
        public string Agencia { get => agencia; set => agencia = value; }
        public string TipoConta { get => tipoConta; set => tipoConta = value; }
        public string Imposto { get => imposto; set => imposto = value; }
        public string Fgts { get => fgts; set => fgts = value; }
        public string Inss { get => inss; set => inss = value; }
        public string Departamento { get => departamento; set => departamento = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public string CargaHoraria { get => cargaHoraria; set => cargaHoraria = value; }
        public string DataAdmissao { get => dataAdmissao; set => dataAdmissao = value; }
        public string Salario { get => salario; set => salario = value; }
        public string ValorVT { get => valorVT; set => valorVT = value; }
        public string ValorVR { get => valorVR; set => valorVR = value; }
        public string ValorVA { get => valorVA; set => valorVA = value; }
    }
}
