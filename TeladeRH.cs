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
    public partial class TeladeRH : Form
    {
        public TeladeRH()
        {
            InitializeComponent();
            
        }
       

        private void TeladeRH_Load(object sender, EventArgs e)
        {
            AbrirTelaFolhaPagamento();
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
            Funcionario control = new Funcionario();
            control.Location = new Point(350, 50); // Defina a posição desejada
            control.Size = new Size(800, 500);       // Defina o tamanho desejado
            this.Controls.Add(control);
            controleAtual = control; // Atualize o controle atual
            control.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Verifique se há um controle atual e o remova se existir
            if (controleAtual != null)
            {
                this.Controls.Remove(controleAtual);
                controleAtual.Dispose();
            }

            // Crie e adicione o novo controle
            RHHistoricoFuncionario control = new RHHistoricoFuncionario();
            control.Location = new Point(240, 100); // Defina a posição desejada
            control.Size = new Size(800, 500);       // Defina o tamanho desejado
            this.Controls.Add(control);
            controleAtual = control; // Atualize o controle atual
            control.Visible = true;
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
    }
}
