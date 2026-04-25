namespace FrontDesktop
{
    partial class frmSalvarProfessor
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
            this.lblNome = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();

            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();

            this.btnSalvarProfessor = new System.Windows.Forms.Button();
            this.btnAtualizarProfessor = new System.Windows.Forms.Button();
            this.btnExcluirProfessor = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();

            this.dataGridViewProfessores = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProfessores)).BeginInit();
            this.SuspendLayout();

            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(24, 45);
            this.lblNome.Text = "Nome:";

            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(24, 81);
            this.lblEmail.Text = "Email:";

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(24, 117);
            this.lblTitulo.Text = "Título:";

            this.txtNome.Location = new System.Drawing.Point(125, 42);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(100, 20);

            this.txtEmail.Location = new System.Drawing.Point(125, 78);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);

            this.txtTitulo.Location = new System.Drawing.Point(125, 114);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(100, 20);

            this.btnSalvarProfessor.Location = new System.Drawing.Point(27, 160);
            this.btnSalvarProfessor.Name = "btnSalvarProfessor";
            this.btnSalvarProfessor.Size = new System.Drawing.Size(120, 23);
            this.btnSalvarProfessor.Text = "Salvar Professor";
            this.btnSalvarProfessor.Click += new System.EventHandler(this.btnSalvarProfessor_Click);

            this.btnAtualizarProfessor.Location = new System.Drawing.Point(27, 190);
            this.btnAtualizarProfessor.Name = "btnAtualizarProfessor";
            this.btnAtualizarProfessor.Size = new System.Drawing.Size(120, 23);
            this.btnAtualizarProfessor.Text = "Atualizar Professor";
            this.btnAtualizarProfessor.Click += new System.EventHandler(this.btnAtualizarProfessor_Click);

            this.btnExcluirProfessor.Location = new System.Drawing.Point(27, 220);
            this.btnExcluirProfessor.Name = "btnExcluirProfessor";
            this.btnExcluirProfessor.Size = new System.Drawing.Size(120, 23);
            this.btnExcluirProfessor.Text = "Excluir Professor";
            this.btnExcluirProfessor.Click += new System.EventHandler(this.btnExcluirProfessor_Click);

            this.btnSair.Location = new System.Drawing.Point(689, 377);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.Text = "Sair";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);

            this.dataGridViewProfessores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProfessores.Location = new System.Drawing.Point(250, 42);
            this.dataGridViewProfessores.Name = "dataGridViewProfessores";
            this.dataGridViewProfessores.Size = new System.Drawing.Size(514, 221);
            this.dataGridViewProfessores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProfessores_CellClick);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 412);
            this.ControlBox = false;

            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.btnSalvarProfessor);
            this.Controls.Add(this.btnAtualizarProfessor);
            this.Controls.Add(this.btnExcluirProfessor);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.dataGridViewProfessores);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSalvarProfessor";
            this.Text = "frmSalvarProfessor";
            this.Load += new System.EventHandler(this.frmSalvarProfessor_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProfessores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblTitulo;

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTitulo;

        private System.Windows.Forms.Button btnSalvarProfessor;
        private System.Windows.Forms.Button btnAtualizarProfessor;
        private System.Windows.Forms.Button btnExcluirProfessor;
        private System.Windows.Forms.Button btnSair;

        private System.Windows.Forms.DataGridView dataGridViewProfessores;
    }
}