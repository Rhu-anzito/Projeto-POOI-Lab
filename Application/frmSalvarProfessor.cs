using System;
using System.Windows.Forms;
using Model;
using Data;

namespace FrontDesktop
{
    public partial class frmSalvarProfessor : Form
    {
        public frmSalvarProfessor()
        {
            InitializeComponent();
        }

        private void frmSalvarProfessor_Load(object sender, EventArgs e)
        {
            CarregarProfessores();
        }

        private void btnSalvarProfessor_Click(object sender, EventArgs e)
        {
            try
            {
                Professor professor = new Professor
                {
                    Nome = txtNome.Text,
                    Email = txtEmail.Text,
                    Titulo = txtTitulo.Text
                };

                ProfessorRepository repository = new ProfessorRepository();

                if (repository.Salvar(professor))
                {
                    MessageBox.Show("Professor salvo com sucesso!");
                    LimparCampos();
                    CarregarProfessores();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
            }
        }

        private void btnAtualizarProfessor_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewProfessores.CurrentRow == null)
                {
                    MessageBox.Show("Selecione um professor.");
                    return;
                }

                Professor professor = new Professor
                {
                    ProfessorId = Convert.ToInt32(dataGridViewProfessores.CurrentRow.Cells["ProfessorId"].Value),
                    Nome = txtNome.Text,
                    Email = txtEmail.Text,
                    Titulo = txtTitulo.Text
                };

                ProfessorRepository repository = new ProfessorRepository();

                if (repository.Atualizar(professor))
                {
                    MessageBox.Show("Professor atualizado com sucesso!");
                    LimparCampos();
                    CarregarProfessores();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar: " + ex.Message);
            }
        }

        private void btnExcluirProfessor_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewProfessores.CurrentRow == null)
                {
                    MessageBox.Show("Selecione um professor.");
                    return;
                }

                int id = Convert.ToInt32(dataGridViewProfessores.CurrentRow.Cells["ProfessorId"].Value);

                ProfessorRepository repository = new ProfessorRepository();

                if (repository.Excluir(id))
                {
                    MessageBox.Show("Professor excluído com sucesso!");
                    LimparCampos();
                    CarregarProfessores();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir: " + ex.Message);
            }
        }

        private void dataGridViewProfessores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtNome.Text = dataGridViewProfessores.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
                txtEmail.Text = dataGridViewProfessores.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtTitulo.Text = dataGridViewProfessores.Rows[e.RowIndex].Cells["Titulo"].Value.ToString();
            }
        }

        private void CarregarProfessores()
        {
            ProfessorRepository repository = new ProfessorRepository();
            dataGridViewProfessores.DataSource = repository.Listar();
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtTitulo.Clear();
            txtNome.Focus();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}