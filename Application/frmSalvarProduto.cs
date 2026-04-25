using Data;
using Model;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace FrontDesktop
{
    public partial class frmSalvarProduto : Form
    {
        private readonly ProdutoRepository _repo = new ProdutoRepository();
        private int _idProdutoEdicao = 0;
        public frmSalvarProduto()
        {
            InitializeComponent();
        }

        private void btnSalvarProduto_Click(object sender, EventArgs e)
        {
            bool sucesso;
            try
            {
                if (!ValidarCampos(out decimal preco))
                    return;

                Produto produto = new Produto
                {
                    Nome = txtNome.Text.Trim(),
                    Preco = preco
                };

                if (_idProdutoEdicao == 0)
                {
                    sucesso = _repo.Salvar(produto);
                }
                else
                {
                    produto.Id = _idProdutoEdicao;
                    sucesso = _repo.Atualizar(produto);
                }

                if (sucesso)
                {
                    MessageBox.Show(
                        _idProdutoEdicao == 0
                        ? "Produto incluído com sucesso"
                        : "Produto atualizado com sucesso"
                    );

                    CarregarGrid();
                    LimparCampos();

                    _idProdutoEdicao = 0;

                    btnSalvarProduto.Text = "Salvar";
                }
                else
                {
                    MessageBox.Show("Não foi possível salvar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNome.Text) || !string.IsNullOrWhiteSpace(txtPreco.Text))
            {
                var confirm = MessageBox.Show(
                    "Existem dados não salvos. Deseja sair mesmo assim?",
                    "Atenção",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm != DialogResult.Yes)
                    return;
            }
            Close();
        }

        private void frmSalvarProduto_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CarregarGrid();
        }

        private bool ValidarCampos(out decimal preco)
        {
            preco = 0;

            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Informe o nome do produto.");
                txtNome.Focus();
                return false;
            }

            string valorTexto = txtPreco.Text
                .Replace("R$", "")
                .Replace(".", "")
                .Replace(",", ".")
                .Trim();

            if (!decimal.TryParse(valorTexto, NumberStyles.Any, CultureInfo.InvariantCulture, out preco))
            {
                MessageBox.Show("Preço inválido.");
                txtPreco.Focus();
                return false;
            }

            if (preco <= 0)
            {
                MessageBox.Show("Preço deve ser maior que zero.");
                txtPreco.Focus();
                return false;
            }

            return true;
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtPreco.Clear();
            txtNome.Focus();
        }

        private void CarregarGrid()
        {
            ProdutoRepository repo = new ProdutoRepository();

            var lista = repo.Listar();

            dataGridViewProdutos.DataSource = null;
            dataGridViewProdutos.DataSource = lista;
        }

        private void ConfigurarGrid()
        {
            dataGridViewProdutos.AutoGenerateColumns = true;

            // Botão Editar
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.Name = "Editar";
            btnEditar.HeaderText = "Editar";
            btnEditar.Text = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            dataGridViewProdutos.Columns.Add(btnEditar);

            // Botão Excluir
            DataGridViewButtonColumn btnExcluir = new DataGridViewButtonColumn();
            btnExcluir.Name = "Excluir";
            btnExcluir.HeaderText = "Excluir";
            btnExcluir.Text = "Excluir";
            btnExcluir.UseColumnTextForButtonValue = true;
            dataGridViewProdutos.Columns.Add(btnExcluir);
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)8 &&
                e.KeyChar != ',' &&
                e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',' || e.KeyChar == '.') &&
                (txtPreco.Text.Contains(",") || txtPreco.Text.Contains(".")))
            {
                e.Handled = true;
            }
        }

        private void txtPreco_Enter(object sender, EventArgs e)
        {
            txtPreco.Text = txtPreco.Text
                    .Replace("R$", "")
                    .Replace(".", "")
                    .Replace(",", "")
                    .Trim();
        }

        private void txtPreco_Leave(object sender, EventArgs e)
        {
            string valorTexto = txtPreco.Text
                   .Replace("R$", "")
                   .Replace(".", "")
                   .Replace(",", ".")
                   .Trim();

            if (decimal.TryParse(valorTexto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
            {
                txtPreco.Text = valor.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));
            }
        }

        private void dataGridViewProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewProdutos.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells["Id"].Value);

            if (dataGridViewProdutos.Columns[e.ColumnIndex].Name == "Excluir")
            {
                var confirm = MessageBox.Show("Deseja excluir?", "Confirmação", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    bool excluiu = _repo.Excluir(id);

                    if (excluiu)
                    {
                        MessageBox.Show("Excluído com sucesso");
                        CarregarGrid();
                    }
                }
            }

            if (dataGridViewProdutos.Columns[e.ColumnIndex].Name == "Editar")
            {
                txtNome.Text = row.Cells["Nome"].Value.ToString();
                txtPreco.Text = Convert.ToDecimal(row.Cells["Preco"].Value).ToString("N2");

                _idProdutoEdicao = id;
            }
        }
    }
}