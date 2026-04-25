using System;
using System.Windows.Forms;
using Model;
using Data;

namespace FrontDesktop
{
    public partial class frmSalvarAluno : Form
    {
        public frmSalvarAluno()
        {
            InitializeComponent();
        }

        private void frmSalvarAluno_Load(object sender, EventArgs e)
        {
            CarregarAlunos();
        }

        private void btnSalvarAluno_Click(object sender, EventArgs e)
        {
            try
            {
                Aluno aluno = new Aluno
                {
                    Nome = txtNome.Text,
                    Email = txtEmail.Text,
                    DataNascimento = Convert.ToDateTime(txtDataNascimento.Text)
                };

                AlunoRepository repository = new AlunoRepository();

                if (repository.Salvar(aluno))
                {
                    MessageBox.Show("Aluno salvo com sucesso!");
                    LimparCampos();
                    CarregarAlunos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
            }
        }

        private void btnAtualizarAluno_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewAlunos.CurrentRow == null)
                {
                    MessageBox.Show("Selecione um aluno.");
                    return;
                }

                Aluno aluno = new Aluno
                {
                    AlunoId = Convert.ToInt32(dataGridViewAlunos.CurrentRow.Cells["AlunoId"].Value),
                    Nome = txtNome.Text,
                    Email = txtEmail.Text,
                    DataNascimento = Convert.ToDateTime(txtDataNascimento.Text)
                };

                AlunoRepository repository = new AlunoRepository();

                if (repository.Atualizar(aluno))
                {
                    MessageBox.Show("Aluno atualizado com sucesso!");
                    LimparCampos();
                    CarregarAlunos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar: " + ex.Message);
            }
        }

        private void btnExcluirAluno_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewAlunos.CurrentRow == null)
                {
                    MessageBox.Show("Selecione um aluno.");
                    return;
                }

                int id = Convert.ToInt32(dataGridViewAlunos.CurrentRow.Cells["AlunoId"].Value);

                AlunoRepository repository = new AlunoRepository();

                if (repository.Excluir(id))
                {
                    MessageBox.Show("Aluno excluído com sucesso!");
                    LimparCampos();
                    CarregarAlunos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir: " + ex.Message);
            }
        }

        private void dataGridViewAlunos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtNome.Text = dataGridViewAlunos.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
                txtEmail.Text = dataGridViewAlunos.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtDataNascimento.Text = Convert.ToDateTime(dataGridViewAlunos.Rows[e.RowIndex].Cells["DataNascimento"].Value).ToShortDateString();
            }
        }

        private void CarregarAlunos()
        {
            AlunoRepository repository = new AlunoRepository();
            dataGridViewAlunos.DataSource = repository.Listar();
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtDataNascimento.Clear();
            txtNome.Focus();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}