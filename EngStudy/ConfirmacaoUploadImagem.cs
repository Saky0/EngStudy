using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EngStudy.bd_connect.classesDoDB;
using EngStudy.bd_connect;
using System.Data.SqlClient;

namespace EngStudy
{
    public partial class ConfirmacaoUploadImagem : Form
    {
        private string caminhoImagemUpload { get; }

        

        /*
        * Construtor recebe o caminho da imagem logo quando instanciado
        * Uma vez definido. não se pode alterar este caminho durante a execução do Objeto
        */
        
        public ConfirmacaoUploadImagem(string caminhoImagemUpload)
        {
            this.caminhoImagemUpload = caminhoImagemUpload;
            InitializeComponent();
        }



        // Carregar Grid
        private void CarregarGridPalavras()
        {
            // Armazena todas as palavras existentes em uma Lista
            List<PalavraParcialDto> palavrasEncontradas = new List<PalavraParcialDto>();

            try
            {
                palavrasEncontradas = ControleCRUDPalavras.RetornarPalavrasParcial();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Após resgatar os dados, passa para o DtvPalavras

            try
            {
                dtvPalavras.DataSource = palavrasEncontradas;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConfirmacaoUploadImagem_Load(object sender, EventArgs e)
        {
            lblLocal.Text = caminhoImagemUpload;
            CarregarGridPalavras();
        }

        
        private void ExcluirImagem()
        {
            bool result = File.Exists(caminhoImagemUpload);

            if(result)
            {
                File.Delete(caminhoImagemUpload);
            }
        }

        private void ConfirmacaoUploadImagem_FormClosing(object sender, FormClosingEventArgs e)
        {
            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ExcluirImagem();
            this.Close();
        }

        // Evento de Troca de texto para pesquisar uma palavra pelos parâmetros fornecidos em txtPalavra
        private void txtPalavra_TextChanged(object sender, EventArgs e)
        {
            if(txtPalavra.Text.Length > 0)
            {
                List<PalavraParcialDto> palavrasEncontradas = new List<PalavraParcialDto>();
                try
                {
                    
                    palavrasEncontradas = ControleCRUDPalavras.PesquisarPalavrasPorNome(txtPalavra.Text.Trim());

                    if (palavrasEncontradas.Count == 0)
                    {
                        txtPalavra.ForeColor = Color.FromArgb(255, 0, 0);
                    } else
                    {
                        txtPalavra.ForeColor = Color.FromArgb(0, 0, 0);
                    }

                    dtvPalavras.DataSource = palavrasEncontradas;

                    
                } catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                CarregarGridPalavras();
            }
        }



        // Coletar os Dados do item atual no dtvPalavras
        private void dtvPalavras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtvPalavras.RowCount != 0)
            {
                int index = dtvPalavras.CurrentRow.Index;

                lblIdPalavra.Text = Convert.ToString(dtvPalavras["idPalavra", index].Value);
                lblNomePalavra.Text = Convert.ToString(dtvPalavras["palavra", index].Value);
                lblClasse.Text = Convert.ToString(dtvPalavras["classe", index].Value);

            }
        }




        /*
         * 
         * Final do Uso do Obejto
         * Encerrar e Realizar sua Função de atribuição
         * 
         */

        // Confirmar, Salvar Imagem na Palavra respectiva e encerrar o Programa
        private void btnUploadFoto_Click(object sender, EventArgs e)
        {
            if(lblIdPalavra.Text.Equals("Id"))
            {
                MessageBox.Show("É preciso ter selecionado alguma Palavra antes!");
                return;
            }
            else
            {
                int i = 0;

                int idPalavraAtual = Convert.ToInt32(dtvPalavras["idPalavra", dtvPalavras.CurrentRow.Index].Value);

                try
                {
                    i = ControleCRUDPalavras.AtualizarFotoEmPalavraExistente(caminhoImagemUpload, idPalavraAtual);

                } catch(SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if(i > 0)
                {
                    MessageBox.Show(String.Format("Foto atualizada/Inserida com Sucesso!\n\nCaminho: {0}\nPalavra: {1}", caminhoImagemUpload, lblNomePalavra.Text), "Info");
                }
            }



            this.Close();
        }
    }
}
