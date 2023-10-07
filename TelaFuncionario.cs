using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teste_de_crud_em_txt
{
    public partial class TelaFuncionario : Form
    {
        public TelaFuncionario()
        {
            InitializeComponent();
        }
        private Control controleAtual;
        private void btnCadatrarFuncionario_Click(object sender, EventArgs e)
        {

            // Verifique se há um controle atual e o remova se existir
            if (controleAtual != null)
            {
                this.Controls.Remove(controleAtual);
                controleAtual.Dispose();
            }

            // Crie e adicione o novo controle
            InfoPessoais control = new InfoPessoais();
            control.Location = new Point(350, 50); // Defina a posição desejada
            control.Size = new Size(800, 500);       // Defina o tamanho desejado
            this.Controls.Add(control);
            controleAtual = control; // Atualize o controle atual
            control.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirTelaFolhaPagamento();
        }
        private void AbrirTelaFolhaPagamento()
        {
            // Verifique se há um controle atual e o remova se existir
            if (controleAtual != null)
            {
                this.Controls.Remove(controleAtual);
                controleAtual.Dispose();
            }

            // Crie e adicione o novo controle
            FolhaPagamento control = new FolhaPagamento();
            control.Location = new Point(200, 100); // Defina a posição desejada
            control.Size = new Size(800, 500);       // Defina o tamanho desejado
            this.Controls.Add(control);
            controleAtual = control; // Atualize o controle atual
            control.Visible = true;
        }

        private void TelaFuncionario_Load(object sender, EventArgs e)
        {
            AbrirTelaFolhaPagamento();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Verifique se há um controle atual e o remova se existir
            if (controleAtual != null)
            {
                this.Controls.Remove(controleAtual);
                controleAtual.Dispose();
            }

            // Crie e adicione o novo controle
            RHFolhaPonto control = new RHFolhaPonto();
            control.Location = new Point(240, 100); // Defina a posição desejada
            control.Size = new Size(800, 500);       // Defina o tamanho desejado
            this.Controls.Add(control);
            controleAtual = control; // Atualize o controle atual
            control.Visible = true;
        }
        public void AtualizarNomeFuncionario(string nome)
        {
            labelNomeFuncionario.Text = "Bem-vindo, \n" + nome + "!";
        }
        public void labelNomeFuncionario_Click(object sender, EventArgs e)
        {

        }
    }
}
