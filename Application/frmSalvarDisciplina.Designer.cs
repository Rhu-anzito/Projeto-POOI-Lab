namespace FrontDesktop
{
    partial class frmSalvarDisciplina
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblCargaHoraria = new System.Windows.Forms.Label();

            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtCargaHoraria = new System.Windows.Forms.TextBox();

            this.btnSalvarDisciplina = new System.Windows.Forms.Button();
            this.btnAtualizarDisciplina = new System.Windows.Forms.Button();
            this.btnExcluirDisciplina = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();

            this.dataGridViewDisciplinas = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDisciplinas)).BeginInit();
            this.SuspendLayout();

            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(24, 45);
            this.lblCodigo.Text = "Código:";

            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(24, 81);
            this.lblNome.Text = "Nome:";

            this.lblCargaHoraria.AutoSize = true;
            this.lblCargaHoraria.Location = new System.Drawing.Point(24, 117);
            this.lblCargaHoraria.Text = "Carga Horária:";

            this.txtCodigo.Location = new System.Drawing.Point(125, 42);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);

            this.txtNome.Location = new System.Drawing.Point(125, 78);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(100, 20);

            this.txtCargaHoraria.Location = new System.Drawing.Point(125, 114);
            this.txtCargaHoraria.Name = "txtCargaHoraria";
            this.txtCargaHoraria.Size = new System.Drawing.Size(100, 20);

            this.btnSalvarDisciplina.Location = new System.Drawing.Point(27, 160);
            this.btnSalvarDisciplina.Name = "btnSalvarDisciplina";
            this.btnSalvarDisciplina.Size = new System.Drawing.Size(120, 23);
            this.btnSalvarDisciplina.Text = "Salvar Disciplina";
            this.btnSalvarDisciplina.Click += new System.EventHandler(this.btnSalvarDisciplina_Click);

            this.btnAtualizarDisciplina.Location = new System.Drawing.Point(27, 190);
            this.btnAtualizarDisciplina.Name = "btnAtualizarDisciplina";
            this.btnAtualizarDisciplina.Size = new System.Drawing.Size(120, 23);
            this.btnAtualizarDisciplina.Text = "Atualizar Disciplina";
            this.btnAtualizarDisciplina.Click += new System.EventHandler(this.btnAtualizarDisciplina_Click);

            this.btnExcluirDisciplina.Location = new System.Drawing.Point(27, 220);
            this.btnExcluirDisciplina.Name = "btnExcluirDisciplina";
            this.btnExcluirDisciplina.Size = new System.Drawing.Size(120, 23);
            this.btnExcluirDisciplina.Text = "Excluir Disciplina";
            this.btnExcluirDisciplina.Click += new System.EventHandler(this.btnExcluirDisciplina_Click);

            this.btnSair.Location = new System.Drawing.Point(689, 377);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.Text = "Sair";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);

            this.dataGridViewDisciplinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDisciplinas.Location = new System.Drawing.Point(250, 42);
            this.dataGridViewDisciplinas.Name = "dataGridViewDisciplinas";
            this.dataGridViewDisciplinas.Size = new System.Drawing.Size(514, 221);
            this.dataGridViewDisciplinas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDisciplinas_CellClick);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 412);
            this.ControlBox = false;

            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblCargaHoraria);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtCargaHoraria);
            this.Controls.Add(this.btnSalvarDisciplina);
            this.Controls.Add(this.btnAtualizarDisciplina);
            this.Controls.Add(this.btnExcluirDisciplina);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.dataGridViewDisciplinas);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSalvarDisciplina";
            this.Text = "frmSalvarDisciplina";
            this.Load += new System.EventHandler(this.frmSalvarDisciplina_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDisciplinas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblCargaHoraria;

        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCargaHoraria;

        private System.Windows.Forms.Button btnSalvarDisciplina;
        private System.Windows.Forms.Button btnAtualizarDisciplina;
        private System.Windows.Forms.Button btnExcluirDisciplina;
        private System.Windows.Forms.Button btnSair;

        private System.Windows.Forms.DataGridView dataGridViewDisciplinas;
    }
}