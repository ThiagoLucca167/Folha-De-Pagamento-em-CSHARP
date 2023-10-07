using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace teste_de_crud_em_txt
{
    public class HFuncionarioBD
    {
        public SqlConnection con;// conexão com BD 
        public SqlCommand cmd = new SqlCommand();// comandos sql 
        public string strconexao = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HoleriteFuncionarios;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
       
        public bool cadastrarHBD(HFuncionarios c)
        {
            //comando sql de cadastro 

            cmd.CommandText = "INSERT INTO FuncionarioBD( Cpf,Nome, Login, Senha, Email,Telefone, RegistroGeral, DataNascimento, Pis, Nacionalidade, " +
                 "NumeroCarteiraTrabalho, Estado, Cidade, Cep, Bairro, Logradouro, Complemento, NumeroResidencial, " +
                 "NomeBanco, CodigoBanco, ContaBancaria, Agencia, TipoConta, Imposto, Fgts, Inss, Departamento, " +
                 "Cargo, DataAdmissao, CargaHoraria, Salario, ValorVT, ValorVR, ValorVA) " +
                 "VALUES( @cpf, @nome, @login, @senha, @email,@telefone, @registrogeral, @datanascimento, @pis, @nacionalidade, " +
                 "@numerocarteiratrabalho, @estado, @cidade, @cep, @bairro, @logradouro, @complemento, @numeroresidencial, " +
                 "@nomebanco, @codigobanco, @contabancaria, @agencia, @tipoconta, @imposto, @fgts, @inss, @departamento, " +
                 "@cargo, @dataadmissao, @cargahoraria, @salario, @valorvt, @valorvr, @valorva)";

            cmd.Parameters.AddWithValue("@nome", c.Nome);
            cmd.Parameters.AddWithValue("@login", c.Login);
            cmd.Parameters.AddWithValue("@senha", c.Senha);
            cmd.Parameters.AddWithValue("@email", c.Email);
            cmd.Parameters.AddWithValue("@cpf", c.Cpf);
            cmd.Parameters.AddWithValue("@telefone", c.Telefone);
            cmd.Parameters.AddWithValue("@registrogeral", c.RegistroGeral);
            cmd.Parameters.AddWithValue("@datanascimento", c.DataNascimento);
            cmd.Parameters.AddWithValue("@pis", c.Pis);
            cmd.Parameters.AddWithValue("@nacionalidade", c.Nacionalidade);
            cmd.Parameters.AddWithValue("@numerocarteiratrabalho", c.NumeroCarteiraTrabalho);
            cmd.Parameters.AddWithValue("@estado", c.Estado);
            cmd.Parameters.AddWithValue("@cidade", c.Cidade);
            cmd.Parameters.AddWithValue("@cep", c.Cep);
            cmd.Parameters.AddWithValue("@bairro", c.Bairro);
            cmd.Parameters.AddWithValue("@logradouro", c.Logradouro);
            cmd.Parameters.AddWithValue("@complemento", c.Complemento);
            cmd.Parameters.AddWithValue("@numeroresidencial", c.NumeroResidencial);
            cmd.Parameters.AddWithValue("@nomebanco", c.NomeBanco);
            cmd.Parameters.AddWithValue("@codigobanco", c.CodigoBanco);
            cmd.Parameters.AddWithValue("@contabancaria", c.ContaBancaria);
            cmd.Parameters.AddWithValue("@agencia", c.Agencia);
            cmd.Parameters.AddWithValue("@tipoconta", c.TipoConta);
            cmd.Parameters.AddWithValue("@imposto", c.Imposto);
            cmd.Parameters.AddWithValue("@fgts", c.Fgts);
            cmd.Parameters.AddWithValue("@inss", c.Inss);
            cmd.Parameters.AddWithValue("@departamento", c.Departamento);
            cmd.Parameters.AddWithValue("@cargo", c.Cargo);
            cmd.Parameters.AddWithValue("@dataadmissao", c.DataAdmissao);
            cmd.Parameters.AddWithValue("@cargahoraria", c.CargaHoraria);
            cmd.Parameters.AddWithValue("@salario", c.Salario);
            cmd.Parameters.AddWithValue("@valorvt", c.ValorVT);
            cmd.Parameters.AddWithValue("@valorvr", c.ValorVR);
            cmd.Parameters.AddWithValue("@valorva", c.ValorVA);

            SqlConnection con = new SqlConnection(strconexao);
            try
            {
                //tenta abrir a conexão com o BD                
                con.Open();
                cmd.Connection = con;
                //Executa query sql 
                cmd.ExecuteNonQuery();
                //fecha o banco 
                con.Close();// fecha conexão 
                return true;
            }
            catch (SqlException ex)
            {
                string erro = ex.Message;
                MessageBox.Show(erro);
                return false;
            }
            finally
            {
                con.Close();//fecha conexão 
            }
        } //fechamento cadastrar 
        public List<HFuncionarios> listar()
        {
            List<HFuncionarios> lista = new List<HFuncionarios>();
            HFuncionarios c = new HFuncionarios();
            //Seleciona todos os registros da tabela do BD 
            cmd.CommandText = "select Id, Cpf, Nome, Login, Senha, Email, Telefone, RegistroGeral, DataNascimento, Pis, Nacionalidade, " +
                  "NumeroCarteiraTrabalho, Estado, Cidade, Cep, Bairro, Logradouro, Complemento, NumeroResidencial, NomeBanco, " +
                  "CodigoBanco, ContaBancaria, Agencia, TipoConta, Imposto, Fgts, Inss, Departamento, Cargo, DataAdmissao, " +
                  "CargaHoraria, Salario, ValorVT, ValorVR, ValorVA FROM FuncionarioBD";
            // tenta realizar a conexão com o BD 
            try
            {
                // testa e recebe a conexão 
                SqlConnection con = new SqlConnection(strconexao);
                con.Open();
                cmd.Connection = con;
                //Executa query sql 
                SqlDataReader dataReader = cmd.ExecuteReader();
                // iterar Clientes para a lista de clientes 
                while (dataReader.Read())
                {
                    //adiciona clientes do BD na nossa lista de Clientes 
                    int Id = dataReader.GetInt32(0);
                    string Cpf = dataReader.GetString(1);
                    string Nome = dataReader.GetString(2);
                    string Login = dataReader.GetString(3);
                    string Senha = dataReader.GetString(4);
                    string Email = dataReader.GetString(5);
                    string Telefone = dataReader.GetString(6);
                    string RegistroGeral = dataReader.GetString(7);
                    string DataNascimento = dataReader.GetString(8);
                    string Pis = dataReader.GetString(9);
                    string Nacionalidade = dataReader.GetString(10);
                    string NumeroCarteiraTrabalho = dataReader.GetString(11);
                    string Estado = dataReader.GetString(12);
                    string Cidade = dataReader.GetString(13);
                    string Cep = dataReader.GetString(14);
                    string Bairro = dataReader.GetString(15);
                    string Logradouro = dataReader.GetString(16);
                    string Complemento = dataReader.GetString(17);
                    string NumeroResidencial = dataReader.GetString(18);
                    string NomeBanco = dataReader.GetString(19);
                    string CodigoBanco = dataReader.GetString(20);
                    string ContaBancaria = dataReader.GetString(21);
                    string Agencia = dataReader.GetString(22);
                    string TipoConta = dataReader.GetString(23);
                    string Imposto = dataReader.GetString(24);
                    string Fgts = dataReader.GetString(25);
                    string Inss = dataReader.GetString(26);
                    string Departamento = dataReader.GetString(27);
                    string Cargo = dataReader.GetString(28);
                    string CargaHoraria = dataReader.GetString(29);
                    string DataAdmissao = dataReader.GetString(30);
                    string Salario = dataReader.GetString(31);
                    string ValorVT = dataReader.GetString(32);
                    string ValorVR = dataReader.GetString(33);
                    string ValorVA = dataReader.GetString(34);
                    lista.Add(new HFuncionarios(Id, Cpf,Nome, Login, Senha, Email, Telefone, RegistroGeral, DataNascimento
                       , Pis, Nacionalidade, NumeroCarteiraTrabalho, Estado, Cidade, Cep, Bairro, Logradouro, Complemento
                       , NumeroResidencial, NomeBanco, CodigoBanco, ContaBancaria, Agencia, TipoConta, Imposto, Fgts, Inss
                       , Departamento, Cargo, CargaHoraria, DataAdmissao, Salario, ValorVT, ValorVR, ValorVA));
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                string erro = ex.Message;
                MessageBox.Show(erro);
            }
            return lista;
        }//fechamento listar
        public HFuncionarios buscar(string cpf)
        {
            HFuncionarios c = new HFuncionarios();
            //busca 
            cmd.CommandText = "select Id,Cpf,Nome,Login,Senha,Email, Telefone, " +
                "RegistroGeral, DataNascimento, Pis, Nacionalidade,NumeroCarteiraTrabalho, " +
                "Estado, Cidade, Cep, Bairro, Logradouro, Complemento, NumeroResidencial, NomeBanco, " +
                "CodigoBanco, ContaBancaria, Agencia, TipoConta, Imposto, Fgts, Inss, Departamento, Cargo, DataAdmissao," +
                "CargaHoraria, Salario, ValorVT, ValorVR, ValorVA from FuncionarioBD where Cpf= @cpf";
            cmd.Parameters.AddWithValue("@cpf", cpf);
            // tenta realizar a conexão com o BD
            // testa e recebe a conexão
            SqlConnection con = new SqlConnection(strconexao);
            try
            {
                //abre o BD
                con.Open();
                cmd.Connection = con;
                //Executa query sql
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    //adiciona cliente
                    int Id = dataReader.GetInt32(0);
                    string Cpf = dataReader.GetString(1);
                    string Nome = dataReader.GetString(2);
                    string Login = dataReader.GetString(3);
                    string Senha = dataReader.GetString(4);
                    string Email = dataReader.GetString(5);
                    string Telefone = dataReader.GetString(6);
                    string RegistroGeral = dataReader.GetString(7);
                    string DataNascimento = dataReader.GetString(8);
                    string Pis = dataReader.GetString(9);
                    string Nacionalidade = dataReader.GetString(10);
                    string NumeroCarteiraTrabalho = dataReader.GetString(11);
                    string Estado = dataReader.GetString(12);
                    string Cidade = dataReader.GetString(13);
                    string Cep = dataReader.GetString(14);
                    string Bairro = dataReader.GetString(15);
                    string Logradouro = dataReader.GetString(16);
                    string Complemento = dataReader.GetString(17);
                    string NumeroResidencial = dataReader.GetString(18);
                    string NomeBanco = dataReader.GetString(19);
                    string CodigoBanco = dataReader.GetString(20);
                    string ContaBancaria = dataReader.GetString(21);
                    string Agencia = dataReader.GetString(22);
                    string TipoConta = dataReader.GetString(23);
                    string Imposto = dataReader.GetString(24);
                    string Fgts = dataReader.GetString(25);
                    string Inss = dataReader.GetString(26);
                    string Departamento = dataReader.GetString(27);
                    string Cargo = dataReader.GetString(28);
                    string CargaHoraria = dataReader.GetString(29);
                    string DataAdmissao = dataReader.GetString(30);
                    string Salario = dataReader.GetString(31);
                    string ValorVT = dataReader.GetString(32);
                    string ValorVR = dataReader.GetString(33);
                    string ValorVA = dataReader.GetString(34);
                    c = new HFuncionarios(Id, Cpf, Nome, Login, Senha, Email, Telefone, RegistroGeral, DataNascimento
                       , Pis, Nacionalidade, NumeroCarteiraTrabalho, Estado, Cidade, Cep, Bairro, Logradouro, Complemento
                       , NumeroResidencial, NomeBanco, CodigoBanco, ContaBancaria, Agencia, TipoConta, Imposto, Fgts, Inss
                       , Departamento, Cargo, CargaHoraria, DataAdmissao, Salario, ValorVT, ValorVR, ValorVA);
                }
                else // CLIENTE NÃO ENCONTRADO
                {
                    c = new HFuncionarios("null", "Não Encontrado", "null", "null", "null", "null", "null", "null", "null",
                    "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null",
                    "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null");
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                string erro = ex.Message;
                MessageBox.Show(erro);
            }
            finally { con.Close(); }
            return c;
        }//fechamento Buscar
        public bool alterar(HFuncionarios c)
        {
            //comando sql de cadastro
            cmd.CommandText = "update FuncionarioBD set Nome=@nome,Login=@login,Senha=@senha,Email=@email,Telefone=@telefone," +
                "RegistroGeral=@registrogeral,DataNascimento=@datanascimento,Pis=@pis,Nacionalidade=@nacionalidade,NumeroCarteiraTrabalho=@numerocarteiratrabalho," +
                "Estado=@estado,Cidade=@cidade,Cep=@cep,Bairro=@bairro,Logradouro=@logradouro,Complemento=@complemento,NumeroResidencial=@numeroresidencial," +
                "NomeBanco=@nomebanco,CodigoBanco=@codigobanco,ContaBancaria=@contabancaria,Agencia=@agencia,TipoConta=@tipoconta,Imposto=@imposto, Fgts=@fgts," +
                "Inss=@inss,Departamento=@departamento,Cargo=@cargo,DataAdmissao=@dataadmissao,CargaHoraria=@cargahoraria,Salario=@salario,ValorVT=@valorvt, " +
                "ValorVR=@valorvr,ValorVA=@valorva where Cpf = @cpf";
            // parâmetros
            cmd.Parameters.AddWithValue("@nome", c.Nome);
            cmd.Parameters.AddWithValue("@login", c.Login);
            cmd.Parameters.AddWithValue("@senha", c.Senha);
            cmd.Parameters.AddWithValue("@email", c.Email);
            cmd.Parameters.AddWithValue("@cpf", c.Cpf);
            cmd.Parameters.AddWithValue("@telefone", c.Telefone);
            cmd.Parameters.AddWithValue("@registrogeral", c.RegistroGeral);
            cmd.Parameters.AddWithValue("@datanascimento", c.DataNascimento);
            cmd.Parameters.AddWithValue("@pis", c.Pis);
            cmd.Parameters.AddWithValue("@nacionalidade", c.Nacionalidade);
            cmd.Parameters.AddWithValue("@numerocarteiratrabalho", c.NumeroCarteiraTrabalho);
            cmd.Parameters.AddWithValue("@estado", c.Estado);
            cmd.Parameters.AddWithValue("@cidade", c.Cidade);
            cmd.Parameters.AddWithValue("@cep", c.Cep);
            cmd.Parameters.AddWithValue("@bairro", c.Bairro);
            cmd.Parameters.AddWithValue("@logradouro", c.Logradouro);
            cmd.Parameters.AddWithValue("@complemento", c.Complemento);
            cmd.Parameters.AddWithValue("@numeroresidencial", c.NumeroResidencial);
            cmd.Parameters.AddWithValue("@nomebanco", c.NomeBanco);
            cmd.Parameters.AddWithValue("@codigobanco", c.CodigoBanco);
            cmd.Parameters.AddWithValue("@contabancaria", c.ContaBancaria);
            cmd.Parameters.AddWithValue("@agencia", c.Agencia);
            cmd.Parameters.AddWithValue("@tipoconta", c.TipoConta);
            cmd.Parameters.AddWithValue("@imposto", c.Imposto);
            cmd.Parameters.AddWithValue("@fgts", c.Fgts);
            cmd.Parameters.AddWithValue("@inss", c.Inss);
            cmd.Parameters.AddWithValue("@departamento", c.Departamento);
            cmd.Parameters.AddWithValue("@cargo", c.Cargo);
            cmd.Parameters.AddWithValue("@dataadmissao", c.DataAdmissao);
            cmd.Parameters.AddWithValue("@cargahoraria", c.CargaHoraria);
            cmd.Parameters.AddWithValue("@salario", c.Salario);
            cmd.Parameters.AddWithValue("@valorvt", c.ValorVT);
            cmd.Parameters.AddWithValue("@valorvr", c.ValorVR);
            cmd.Parameters.AddWithValue("@valorva", c.ValorVA);
            // tenta realizar a conexão com o BD
            SqlConnection con = new SqlConnection(strconexao);
            try
            {
                //abre o BD
                con.Open();
                cmd.Connection = con;
                //Executa query sql
                cmd.ExecuteNonQuery();
                //fecha o banco
                con.Close();// fecha conexão
                return true;
            }
            catch (SqlException ex)
            {
                string erro = ex.Message;
                MessageBox.Show(erro);
                return false;
            }
            finally { con.Close(); }
        }//fechamento alterar
    }
}
