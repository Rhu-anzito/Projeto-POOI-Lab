using System;
using System.Windows.Forms;
using Model;
using Data;

namespace FrontDesktop
{
    public partial class frmSalvarDisciplina : Form
    {
        public frmSalvarDisciplina()
        {
            InitializeComponent();
        }

        private void frmSalvarDisciplina_Load(object sender, EventArgs e)
        {
            CarregarDisciplinas();
        }

        private void btnSalvarDisciplina_Click(object sender, EventArgs e)
        {
            try
            {
                Disciplina disciplina = new Disciplina
                {
                    Codigo = txtCodigo.Text,
                    Nome = txtNome.Text,
                    CargaHoraria = Convert.ToInt32(txtCargaHoraria.Text)
                };

                DisciplinaRepository repository = new DisciplinaRepository();

                if (repository.Salvar(disciplina))
                {
                    MessageBox.Show("Disciplina salva com sucesso!");
                    LimparCampos();
                    CarregarDisciplinas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
            }
        }

        private void btnAtualizarDisciplina_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewDisciplinas.CurrentRow == null)
                {
                    MessageBox.Show("Selecione uma disciplina.");
                    return;
                }

                Disciplina disciplina = new Disciplina
                {
                    DisciplinaId = Convert.ToInt32(dataGridViewDisciplinas.CurrentRow.Cells["DisciplinaId"].Value),
                    Codigo = txtCodigo.Text,
                    Nome = txtNome.Text,
                    CargaHoraria = Convert.ToInt32(txtCargaHoraria.Text)
                };

                DisciplinaRepository repository = new DisciplinaRepository();

                if (repository.Atualizar(disciplina))
                {
                    MessageBox.Show("Disciplina atualizada com sucesso!");
                    LimparCampos();
                    CarregarDisciplinas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar: " + ex.Message);
            }
        }

        private void btnExcluirDisciplina_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewDisciplinas.CurrentRow == null)
                {
                    MessageBox.Show("Selecione uma disciplina.");
                    return;
                }

                int id = Convert.ToInt32(dataGridViewDisciplinas.CurrentRow.Cells["DisciplinaId"].Value);

                DisciplinaRepository repository = new DisciplinaRepository();

                if (repository.Excluir(id))
                {
                    MessageBox.Show("Disciplina excluída com sucesso!");
                    LimparCampos();
                    CarregarDisciplinas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir: " + ex.Message);
            }
        }

        private void dataGridViewDisciplinas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCodigo.Text = dataGridViewDisciplinas.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
                txtNome.Text = dataGridViewDisciplinas.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
                txtCargaHoraria.Text = dataGridViewDisciplinas.Rows[e.RowIndex].Cells["CargaHoraria"].Value.ToString();
            }
        }

        private void CarregarDisciplinas()
        {
            DisciplinaRepository repository = new DisciplinaRepository();
            dataGridViewDisciplinas.DataSource = repository.Listar();
        }

        private void LimparCampos()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtCargaHoraria.Clear();
            txtCodigo.Focus();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}