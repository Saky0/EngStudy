
namespace EngStudy
{
    partial class ConfirmacaoUploadImagem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPalavra = new System.Windows.Forms.TextBox();
            this.dtvPalavras = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblIdPalavra = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLocal = new System.Windows.Forms.Label();
            this.lblNomePalavra = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblClasse = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.palavrasDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.palavraParcialDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idPalavra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.palavra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtvPalavras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palavrasDtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palavraParcialDtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(29)))), ((int)(((byte)(235)))));
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnConfirmar.Location = new System.Drawing.Point(140, 380);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(98, 36);
            this.btnConfirmar.TabIndex = 33;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnUploadFoto_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(29)))), ((int)(((byte)(235)))));
            this.label2.Location = new System.Drawing.Point(15, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Busca:";
            // 
            // txtPalavra
            // 
            this.txtPalavra.BackColor = System.Drawing.SystemColors.Menu;
            this.txtPalavra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPalavra.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPalavra.Location = new System.Drawing.Point(86, 122);
            this.txtPalavra.Multiline = true;
            this.txtPalavra.Name = "txtPalavra";
            this.txtPalavra.Size = new System.Drawing.Size(184, 30);
            this.txtPalavra.TabIndex = 31;
            this.txtPalavra.TextChanged += new System.EventHandler(this.txtPalavra_TextChanged);
            // 
            // dtvPalavras
            // 
            this.dtvPalavras.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(162)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(29)))), ((int)(((byte)(235)))));
            this.dtvPalavras.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtvPalavras.AutoGenerateColumns = false;
            this.dtvPalavras.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtvPalavras.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dtvPalavras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtvPalavras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPalavra,
            this.palavra,
            this.classe});
            this.dtvPalavras.DataSource = this.palavraParcialDtoBindingSource;
            this.dtvPalavras.Location = new System.Drawing.Point(306, 127);
            this.dtvPalavras.Name = "dtvPalavras";
            this.dtvPalavras.ReadOnly = true;
            this.dtvPalavras.Size = new System.Drawing.Size(504, 289);
            this.dtvPalavras.TabIndex = 30;
            this.dtvPalavras.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtvPalavras_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(43)))), ((int)(((byte)(189)))));
            this.label1.Location = new System.Drawing.Point(278, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 26);
            this.label1.TabIndex = 29;
            this.label1.Text = "Upload Imagem";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(29)))), ((int)(((byte)(235)))));
            this.label3.Location = new System.Drawing.Point(15, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Id:";
            // 
            // lblIdPalavra
            // 
            this.lblIdPalavra.AutoSize = true;
            this.lblIdPalavra.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdPalavra.ForeColor = System.Drawing.Color.Gray;
            this.lblIdPalavra.Location = new System.Drawing.Point(78, 171);
            this.lblIdPalavra.Name = "lblIdPalavra";
            this.lblIdPalavra.Size = new System.Drawing.Size(23, 20);
            this.lblIdPalavra.TabIndex = 35;
            this.lblIdPalavra.Text = "Id";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(29)))), ((int)(((byte)(235)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.Location = new System.Drawing.Point(27, 380);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(98, 36);
            this.btnCancelar.TabIndex = 36;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(29)))), ((int)(((byte)(235)))));
            this.label4.Location = new System.Drawing.Point(15, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 37;
            this.label4.Text = "Local Imagem:";
            // 
            // lblLocal
            // 
            this.lblLocal.AutoSize = true;
            this.lblLocal.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocal.ForeColor = System.Drawing.Color.Gray;
            this.lblLocal.Location = new System.Drawing.Point(137, 60);
            this.lblLocal.Name = "lblLocal";
            this.lblLocal.Size = new System.Drawing.Size(51, 18);
            this.lblLocal.TabIndex = 38;
            this.lblLocal.Text = "Busca:";
            // 
            // lblNomePalavra
            // 
            this.lblNomePalavra.AutoSize = true;
            this.lblNomePalavra.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomePalavra.ForeColor = System.Drawing.Color.Gray;
            this.lblNomePalavra.Location = new System.Drawing.Point(78, 205);
            this.lblNomePalavra.Name = "lblNomePalavra";
            this.lblNomePalavra.Size = new System.Drawing.Size(54, 20);
            this.lblNomePalavra.TabIndex = 40;
            this.lblNomePalavra.Text = "Nome";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(29)))), ((int)(((byte)(235)))));
            this.label6.Location = new System.Drawing.Point(15, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 39;
            this.label6.Text = "Nome:";
            // 
            // lblClasse
            // 
            this.lblClasse.AutoSize = true;
            this.lblClasse.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClasse.ForeColor = System.Drawing.Color.Gray;
            this.lblClasse.Location = new System.Drawing.Point(78, 238);
            this.lblClasse.Name = "lblClasse";
            this.lblClasse.Size = new System.Drawing.Size(56, 20);
            this.lblClasse.TabIndex = 42;
            this.lblClasse.Text = "Classe";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(29)))), ((int)(((byte)(235)))));
            this.label7.Location = new System.Drawing.Point(15, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 20);
            this.label7.TabIndex = 41;
            this.label7.Text = "Classe:";
            // 
            // palavrasDtoBindingSource
            // 
            this.palavrasDtoBindingSource.DataSource = typeof(EngStudy.bd_connect.classesDoDB.PalavrasDto);
            // 
            // palavraParcialDtoBindingSource
            // 
            this.palavraParcialDtoBindingSource.DataSource = typeof(EngStudy.bd_connect.classesDoDB.PalavraParcialDto);
            // 
            // idPalavra
            // 
            this.idPalavra.DataPropertyName = "idPalavra";
            this.idPalavra.HeaderText = "idPalavra";
            this.idPalavra.Name = "idPalavra";
            this.idPalavra.ReadOnly = true;
            // 
            // palavra
            // 
            this.palavra.DataPropertyName = "palavra";
            this.palavra.HeaderText = "palavra";
            this.palavra.Name = "palavra";
            this.palavra.ReadOnly = true;
            this.palavra.Width = 220;
            // 
            // classe
            // 
            this.classe.DataPropertyName = "classe";
            this.classe.HeaderText = "classe";
            this.classe.Name = "classe";
            this.classe.ReadOnly = true;
            this.classe.Width = 140;
            // 
            // ConfirmacaoUploadImagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(822, 428);
            this.Controls.Add(this.lblClasse);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblNomePalavra);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblLocal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblIdPalavra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPalavra);
            this.Controls.Add(this.dtvPalavras);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfirmacaoUploadImagem";
            this.Text = "ConfirmacaoUploadImagem";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfirmacaoUploadImagem_FormClosing);
            this.Load += new System.EventHandler(this.ConfirmacaoUploadImagem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtvPalavras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palavrasDtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palavraParcialDtoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPalavra;
        private System.Windows.Forms.DataGridView dtvPalavras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblIdPalavra;
        private System.Windows.Forms.BindingSource palavrasDtoBindingSource;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLocal;
        private System.Windows.Forms.Label lblNomePalavra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblClasse;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPalavra;
        private System.Windows.Forms.DataGridViewTextBoxColumn palavra;
        private System.Windows.Forms.DataGridViewTextBoxColumn classe;
        private System.Windows.Forms.BindingSource palavraParcialDtoBindingSource;
    }
}