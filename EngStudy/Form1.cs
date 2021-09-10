using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EngStudy.bd_connect;
using EngStudy.bd_connect.classesDoDB;
using EngStudy.classes.recursos;
using EngStudy.exceptions;
using EngStudy.classes;

namespace EngStudy
{
    public partial class FmrPrin : Form
    {
        public FmrPrin()
        {
            InitializeComponent();
            
            
        }

        #region HOTKEYS
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch(keyData)
            {
                // Criar, Novo
                case Keys.F1:
                    if(tabControl1.SelectedTab == tbPgPalavras)
                    {
                        AdicionarPalavra();
                    }
                    else if (tabControl1.SelectedTab == tbPgClasse)
                    {
                        cadastrarClasseNova();
                    }
                    else if (tabControl1.SelectedTab == tbPgFrases)
                    {
                        
                    }
                    else if (tabControl1.SelectedTab == tbPgBlocos)
                    {
                        cadastrarNovoBloco();
                    }
                    
                    break;

                // Atualizar Registro
                case Keys.F2:
                    if (tabControl1.SelectedTab == tbPgPalavras)
                    {

                    }
                    else if (tabControl1.SelectedTab == tbPgClasse)
                    {
                        UpdateClasse();
                    }
                    else if (tabControl1.SelectedTab == tbPgFrases)
                    {

                    }
                    else if (tabControl1.SelectedTab == tbPgBlocos)
                    {
                        AtualizarBlocoExistente();
                    }

                    break;

                // Excluir Registro
                case Keys.F3:
                    if (tabControl1.SelectedTab == tbPgPalavras)
                    {

                    }
                    else if (tabControl1.SelectedTab == tbPgClasse)
                    {
                        ExcluirClasse();
                    }
                    else if (tabControl1.SelectedTab == tbPgFrases)
                    {

                    }
                    else if (tabControl1.SelectedTab == tbPgBlocos)
                    {
                        ExcluirBloco();
                    }


                    break;

                // Desfazer Campos
                case Keys.F4:
                    if (tabControl1.SelectedTab == tbPgPalavras)
                    {
                        LimparCamposPalavras();
                    }
                    else if (tabControl1.SelectedTab == tbPgClasse)
                    {
                        LimparCamposTbPgClasse();
                    }
                    else if (tabControl1.SelectedTab == tbPgFrases)
                    {

                    }
                    else if (tabControl1.SelectedTab == tbPgBlocos)
                    {
                        LimparCamposBlocos();
                    }


                    break;

                // Carregar uma Imagem
                case Keys.F6:
                    if (tabControl1.SelectedTab == tbPgPalavras)
                    {
                        UploadImagemPalavraF6();
                    }
                    break;

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion



        // Exento DRAW para Desenhar o TABCONTROL
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControl1.TabPages[e.Index];


            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);


            // Draw a different background color, and don't paint a focus rectangle.
            _textBrush = new SolidBrush(Color.White);
            g.FillRectangle(new SolidBrush(Color.FromArgb(90, 29, 235)), e.Bounds);


            // Use our own font.
            Font _tabFont = new Font("Segoe UI", 16.0f, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void FmrPrin_Load(object sender, EventArgs e)
        {
            CarregarGridPalavras();

        }

        // Carregar os Dados quando clicar em cada TabPage
        // Carregar o dtv somente quando clicar em Alguma Página específica da TabControl
        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tbPgPalavras)
            {
                carregarCboBlocos();
            }
            else if (tabControl1.SelectedTab == tbPgClasse)
            {
                dtvClasses.DataSource = ControleCRUDClasses.RetornarClassesExistentes();
                txtClasse.Focus();
            }
            else if (tabControl1.SelectedTab == tbPgFrases)
            {

            }
            else if (tabControl1.SelectedTab == tbPgBlocos)
            {
                dtvBlocos.DataSource = ControleCRUDBlocos.RetornarBlocosExistentes();
                txtBloco.Focus();
            }
        } // End LoadDataTbPG



        // CLASSES
        #region Tab Control De Classes

        // Resetar os Campos da Tab Control Classes
        private void btnDesfazerClasses_Click(object sender, EventArgs e)
        {
            LimparCamposTbPgClasse();
        }

        // Carregar os Dados do dtvGrid Classes
        private void CarregarGridClasses()
        {
           dtvClasses.DataSource = ControleCRUDClasses.RetornarClassesExistentes();
        }

        // Limpar os campos da TablePage Classes
        private void LimparCamposTbPgClasse()
        {
            txtClasse.Clear();
            lblIdClasses.Text = " ";
        }

        // CREATE
        // Cadastar uma Nova classe a partir do click do Botão Novo
        private void cadastrarClasseNova()
        {
            // Verifica se os Campos estão nulos
            if (txtClasse.Text.Equals(""))
            {
                MessageBox.Show("Preencha os Campos Restantes!", "Info");
                return;
            }
            else
            {
                /*
                 * Chama o Controlador do CRUD de classes e passa Um objeto do tipo classe
                 * Usa o construtor para passar o nome da classe
                 * A variável inteira recebe um valor caso seja cadastrado com sucesso
                 * caso o valor após o método seja 0, não foi possível cadastrar a pessoa e automaticamente retorna a 
                 * Exceção, mostrando a causa
                 */
                int resultadoCadastro = 0;
                try
                {
                    resultadoCadastro = ControleCRUDClasses.CadastrarNovaClasse(new bd_connect.classesDoDB.ClassesDto(txtClasse.Text.Trim()));

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (resultadoCadastro > 0)
                {
                    MessageBox.Show(string.Format("Classe \"{0}\" Cadastrada com Sucesso!", txtClasse.Text), "Info");
                    CarregarGridClasses();
                    LimparCamposTbPgClasse();

                }


            }
        }
        private void btnNovoClasses_Click(object sender, EventArgs e)
        {
            cadastrarClasseNova();
        } // End CREATE

        private int recolherIndexDtvClasses()
        {
            try
            {
                return Convert.ToInt32(dtvClasses.CurrentRow.Index);

            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
        }

        // DELETE
        // Apaga um Registro de Classe Existente
        // Função do DELETE para aproveitar código
        private void ExcluirClasse()
        {
            // Tratamento para evitar prosseguir caso o DTV não possua nenhum valor
            if (dtvClasses.RowCount == 0)
            {
                MessageBox.Show("Não existe nenhum registro no momento para Prosseguir!", "Alerta");
                return;
            }
            // Tratamento para evitar que não tenha nenhum índice Selecionado do dtvClasse
            int index = 0;
            try
            {
                index = recolherIndexDtvClasses();

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("É preciso Selecionar algum item da Vizualizador de Dados para poder prosseguir!\n\n" + ex.Message, "Alerta");
                return;
            }

            // Verifica se os Campos estão nulos
            if (txtClasse.Text.Equals(""))
            {
                MessageBox.Show("Preencha os Campos Restantes!", "Info");
                return;
            }
            if (lblIdClasses.Text == " ")
            {
                MessageBox.Show("Selecione Algum item no vizualizador de Dados Antes!", "Info");
                return;
            }
            else
            {
                /*
                 * Chama o Controlador do CRUD de classes e passa Um objeto do tipo classe
                 * Usa o construtor para passar o nome da classe
                 * A variável inteira recebe um valor caso seja cadastrado com sucesso
                 * caso o valor após o método seja 0, não foi possível cadastrar a pessoa e automaticamente retorna a 
                 * Exceção, mostrando a causa
                 */
                int resultadoCadastro = 0;
                try
                {
                    resultadoCadastro = ControleCRUDClasses.ExcluirRegistroDeClasseExistente(Convert.ToInt32(dtvClasses["idClasse", index].Value));

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (resultadoCadastro > 0)
                {
                    MessageBox.Show(string.Format("Classe \"{0}\" Excluida com Sucesso!", txtClasse.Text.Trim()), "Info");
                    CarregarGridClasses();
                    LimparCamposTbPgClasse();

                }


            }
        }
        private void btnExcluirClasses_Click(object sender, EventArgs e)
        {
            ExcluirClasse();
        }// End DELETE

        // DTV CLASSES
        private void dtvClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtClasse.Text = Convert.ToString(dtvClasses["nome", dtvClasses.CurrentRow.Index].Value);
            lblIdClasses.Text = Convert.ToString(dtvClasses["idClasse", dtvClasses.CurrentRow.Index].Value);
        }

        // UPDATE
        // Atualiza um Resgistro de Classe
        // Função do UPDATE para aproveitar código
        private void UpdateClasse()
        {
            // Tratamento para evitar prosseguir caso o DTV não possua nenhum valor
            if (dtvClasses.RowCount == 0)
            {
                MessageBox.Show("Não existe nenhum registro no momento para Prosseguir!", "Alerta");
                return;
            }
            // Tratamento para evitar que não tenha nenhum índice Selecionado do dtvClasse
            int index = 0;
            try
            {
                index = recolherIndexDtvClasses();

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("É preciso Selecionar algum item da Vizualizador de Dados para poder prosseguir!\n\n" + ex.Message, "Alerta");
                return;
            }

            // Verifica se os Campos estão nulos
            if (txtClasse.Text.Equals(""))
            {
                MessageBox.Show("Preencha os Campos Restantes!", "Info");
                return;
            }
            if (lblIdClasses.Text == " ")
            {
                MessageBox.Show("Selecione Algum item no vizualizador de Dados Antes!", "Info");
                return;
            }
            else
            {
                /*
                 * Chama o Controlador do CRUD de classes e passa Um objeto do tipo classe
                 * Usa o construtor para passar o nome da classe
                 * A variável inteira recebe um valor caso seja cadastrado com sucesso
                 * caso o valor após o método seja 0, não foi possível cadastrar a pessoa e automaticamente retorna a 
                 * Exceção, mostrando a causa
                 */
                ClassesDto classe = new ClassesDto();
                classe.nome = txtClasse.Text.Trim();
                classe.idClasse = Convert.ToInt32(lblIdClasses.Text.Trim());

                int resultadoCadastro = 0;
                try
                {
                    resultadoCadastro = ControleCRUDClasses.AtualizarRegistroDeClasseExistente(classe);

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (resultadoCadastro > 0)
                {
                    MessageBox.Show(string.Format("Classe \"{0}\" Atualizada com Sucesso!", txtClasse.Text), "Info");
                    CarregarGridClasses();
                    LimparCamposTbPgClasse();

                }


            }
        }
        private void btnSalvarClasses_Click(object sender, EventArgs e)
        {
            UpdateClasse();
        } // End UPDATE

        // Busca nos Registros de Classe uma classe com os parametros digitados em txtClasse
        private void txtPesquisaClasses_TextChanged(object sender, EventArgs e)
        {
            // Evita Erros gerados por valores NULL
            if(txtPesquisaClasses.Text.Length != 0)
            {
                // Lista para armazenar as classes encontradas
                List<ClassesDto> ClassesEncontradas = new List<ClassesDto>();

                try
                {
                    ClassesEncontradas = ControleCRUDClasses.BuscarClasseExistentePorParametros(txtPesquisaClasses.Text);
                    dtvClasses.DataSource = ClassesEncontradas;

                } catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else
            {
                CarregarGridClasses();
            }
        } // End SEARCH


        #endregion



        // BLOCOS
        #region Tab Control de Blocos

        // READ
        // Carregar o dtvBlocos retornando os dados da tbBlocos
        private void CarregarGridBlocos()
        {
            List<bd_connect.classesDoDB.BlocosDto> blocosEncontrados = new List<bd_connect.classesDoDB.BlocosDto>();

            try
            {
                blocosEncontrados = ControleCRUDBlocos.RetornarBlocosExistentes();
                dtvBlocos.DataSource = blocosEncontrados;
            } catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        } // End READ


        // DESFAZER
        // Resetar os Campos da Tab Control Blocos
        private void LimparCamposBlocos()
        {
            txtBloco.Clear();
            lblIdBloco.Text = " ";
        }
        private void btnDesfazerBloco_Click(object sender, EventArgs e)
        {
            LimparCamposBlocos();
        } // End DESFAZER 


        // INDEX
        // Recolhe o index atual do dtvBlocos
        private int recolherIndexDtvBlocos()
        {
            try
            {
                return Convert.ToInt32(dtvBlocos.CurrentRow.Index);

            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
        }


        // CREATE
        // Cadastar uma Nova classe a partir do click do Botão Novo
        private void cadastrarNovoBloco()
        {
            // Verifica se os Campos estão nulos
            if (txtBloco.Text.Equals(""))
            {
                MessageBox.Show("Preencha os Campos Restantes!", "Info");
                return;
            }
            else
            {
                /*
                 * Chama o Controlador do CRUD de classes e passa Um objeto do tipo classe
                 * Usa o construtor para passar o nome da classe
                 * A variável inteira recebe um valor caso seja cadastrado com sucesso
                 * caso o valor após o método seja 0, não foi possível cadastrar a pessoa e automaticamente retorna a 
                 * Exceção, mostrando a causa
                 */
                int resultadoCadastro = 0;
                try
                {
                    resultadoCadastro = ControleCRUDBlocos.CadastrarNovoBloco(new bd_connect.classesDoDB.BlocosDto(txtBloco.Text.Trim()));

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (resultadoCadastro > 0)
                {
                    MessageBox.Show(string.Format("Bloco \"{0}\" Cadastrada com Sucesso!", txtBloco.Text), "Info");
                    CarregarGridBlocos();
                    LimparCamposBlocos();

                }


            }
        }

        private void btnNovoBloco_Click(object sender, EventArgs e)
        {
            cadastrarNovoBloco();
        } // End NOVO


        // UPDATE
        // Atualiza um Resgistro de Classe
        // Função do UPDATE para aproveitar código
        private void AtualizarBlocoExistente()
        {
            // Tratamento para evitar prosseguir caso o DTV não possua nenhum valor
            if (dtvBlocos.RowCount == 0)
            {
                MessageBox.Show("Não existe nenhum registro no momento para Prosseguir!", "Alerta");
                return;
            }
            // Tratamento para evitar que não tenha nenhum índice Selecionado do dtvClasse
            int index = 0;
            try
            {
                index = recolherIndexDtvBlocos();

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("É preciso Selecionar algum item da Vizualizador de Dados para poder prosseguir!\n\n" + ex.Message, "Alerta");
                return;
            }

            // Verifica se os Campos estão nulos
            if (txtBloco.Text.Equals(""))
            {
                MessageBox.Show("Preencha os Campos Restantes!", "Info");
                return;
            }
            if (lblIdBloco.Text.Equals(" "))
            {
                MessageBox.Show("Selecione Algum item no vizualizador de Dados Antes!", "Info");
                return;
            }
            else
            {
                /*
                 * Chama o Controlador do CRUD de blocos e passa objeto do tipo Bloco
                 * A variável inteira recebe um valor caso seja cadastrado com sucesso
                 * caso o valor após o método seja 0, não foi possível cadastrar a pessoa e automaticamente retorna a 
                 * Exceção, mostrando a causa
                 */
                int resultadoCadastro = 0;
                try
                {
                    BlocosDto blocoAtualizado = new BlocosDto();
                    blocoAtualizado.bloco = txtBloco.Text.Trim();
                    blocoAtualizado.idBloco = Convert.ToInt32(lblIdBloco.Text.Trim());

                    resultadoCadastro = ControleCRUDBlocos.AtualizarRegistroDeBlocoExistente(blocoAtualizado);

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (resultadoCadastro > 0)
                {
                    MessageBox.Show(string.Format("Bloco \"{0}\" Atualizado com Sucesso!", txtBloco.Text.Trim()), "Info");
                    CarregarGridBlocos();
                    LimparCamposBlocos();

                }


            }
        }
        private void btnSalvarBloco_Click(object sender, EventArgs e)
        {
            AtualizarBlocoExistente();
        } // End UPDATE


        // DELETE
        // Apaga um Registro de Classe Existente
        // Função do DELETE para aproveitar código
        private void ExcluirBloco()
        {
            // Tratamento para evitar prosseguir caso o DTV não possua nenhum valor
            if (dtvBlocos.RowCount == 0)
            {
                MessageBox.Show("Não existe nenhum registro no momento para Prosseguir!", "Alerta");
                return;
            }
            // Tratamento para evitar que não tenha nenhum índice Selecionado do dtvClasse
            int index = 0;
            try
            {
                index = recolherIndexDtvBlocos();

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("É preciso Selecionar algum item da Vizualizador de Dados para poder prosseguir!\n\n" + ex.Message, "Alerta");
                return;
            }

            // Verifica se os Campos estão nulos
            if (txtBloco.Text.Equals(""))
            {
                MessageBox.Show("Preencha os Campos Restantes!", "Info");
                return;
            }
            if (lblIdBloco.Text.Equals(" "))
            {
                MessageBox.Show("Selecione Algum item no vizualizador de Dados Antes!", "Info");
                return;
            }
            else
            {
                /*
                 * Chama o Controlador do CRUD de blocos e passa Um id do bloco referente
                 * A variável inteira recebe um valor caso seja cadastrado com sucesso
                 * caso o valor após o método seja 0, não foi possível cadastrar a pessoa e automaticamente retorna a 
                 * Exceção, mostrando a causa
                 */
                int resultadoCadastro = 0;
                try
                {
                    
                    resultadoCadastro = ControleCRUDBlocos.ExcluirRegistroDeBlocoExistente(Convert.ToInt32(dtvBlocos["idBloco", dtvBlocos.CurrentRow.Index].Value));

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (resultadoCadastro > 0)
                {
                    MessageBox.Show(string.Format("Bloco \"{0}\" Excluido com Sucesso!", txtBloco.Text.Trim()), "Info");
                    CarregarGridBlocos();
                    LimparCamposBlocos();

                }


            }
        }
        private void btnExcluirBloco_Click(object sender, EventArgs e)
        {
            ExcluirBloco();
        } // End DELETE


        // DTV BLOCOS
        private void dtvBlocos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = 0;
            try
            {
                index = recolherIndexDtvBlocos();

            } catch(NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtBloco.Text = Convert.ToString(dtvBlocos["bloco", index].Value);
            lblIdBloco.Text = Convert.ToString(dtvBlocos["idBloco", index].Value);
        } // End DTV


        // SEARCH Blocos
        private void txtPesquisaBloco_TextChanged(object sender, EventArgs e)
        {
            if(txtPesquisaBloco.Text.Length != 0)
            {
                List<BlocosDto> blocosEncontrados = new List<BlocosDto>();

                try
                {
                    blocosEncontrados = ControleCRUDBlocos.BuscarBlocoExistentePorParametros(txtPesquisaBloco.Text.Trim());
                    dtvBlocos.DataSource = blocosEncontrados;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            } else
            {
                CarregarGridBlocos();
            }
        } // End SEARCH


        #endregion



        // PALAVRAS
        #region Tab Control de Palavras

        // LOAD CBOs
        // Carregar o cboClasses e cboBlocos
        // cboBlocos
        private void cboBlocos_DropDown(object sender, EventArgs e)
        {
            carregarCboBlocos();
        }
        private void carregarCboBlocos()
        {
            try
            {
                cboBlocos.Items.Clear();
                List<BlocosDto> blocosEncontrados = new List<BlocosDto>();
                blocosEncontrados = ControleCRUDBlocos.RetornarBlocosExistentes();

                foreach(BlocosDto bloco in blocosEncontrados)
                {
                    cboBlocos.Items.Add(bloco.bloco.Trim());
                }


            } catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // cboClasses
        private void cboClasses_DropDown(object sender, EventArgs e)
        {
            carregarCboClasses();
        }
        private void carregarCboClasses()
        {
            try
            {
                cboClasses.Items.Clear();
                List<ClassesDto> classesEncontrados = new List<ClassesDto>();
                classesEncontrados = ControleCRUDClasses.RetornarClassesExistentes();


                foreach (ClassesDto classes in classesEncontrados)
                {
                    cboClasses.Items.Add(classes.nome.Trim());
                }


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // End LOAD CBOs



        // READ
        // Carrega as Palavras Existem chamando um método que complea o dtv e atribui uma foto caso existe
        private void CarregarGridPalavras()
        {
            // Armazena todas as palavras existentes em uma Lista
            List<PalavrasDto> palavrasEncontradas = new List<PalavrasDto>();

            try
            {
                palavrasEncontradas = ControleCRUDPalavras.RetornarPalavras();
            } catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Após resgatar os dados, passa para o DtvPalavras

            try
            {
                dtvPalavras.DataSource = palavrasEncontradas;

            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // End READ



        // UPLOAD FOTO
        // Faz Upload de uma foto, e escolhe uma palavra correspondente a mesma 
        private void UploadImagemPalavraF6()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Todos os arquivos (*.*)|*.*";


            // Guarda o local específico da nova imagem caso seja preciso apaga-la
            string novoCaminhoDeImagem = "";

            // Verifica se o usuário Selecionou algo
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    // Cria uma nova string e armazena o novo local da foto após ser processada pelo método chamado
                    novoCaminhoDeImagem = ComprimirCriarBackupLocalDeFotoCadastrada
                        .ComprimirESalvarFotoTamanhoPadrao(openFileDialog.FileName, openFileDialog.SafeFileName);

                    // A partir daqui, segue para cadastrar o caminho da imagem a sua respectiva palavra
                    ConfirmacaoUploadImagem confirm = new ConfirmacaoUploadImagem(novoCaminhoDeImagem);

                    confirm.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

        }
        private void btnUploadFoto_Click(object sender, EventArgs e)
        {
            UploadImagemPalavraF6();
        }



        // DESFAZER
        // Método para Limpar os Campos da tbPgPalavras
        private void LimparCamposPalavras()
        {
            txtPalavra.Clear();
            txtPronuncia.Clear();
            txtSignificado.Clear();
            ritxtFraseEx.Clear();
            carregarCboBlocos();
            carregarCboClasses();

        }
        private void btnDesfazerPalavras_Click(object sender, EventArgs e)
        {
            LimparCamposPalavras();
        } // End DESFAZER PALAVRAS



        // CREATE
        // Adiciona um novo registro de Classe na tb_palavras
        private void AdicionarPalavra()
        {
            // Verifica se todos os Campos estão preenchidos
            if (VerificarCamposPalavras())
            {
                return;
            }


            PalavrasDto palavra = new PalavrasDto();
            palavra = RecolherCamposPalavras();

            int resultado = 0;

            try
            {
                resultado = ControleCRUDPalavras.InserirPalavra(palavra);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (resultado > 0)
            {
                MessageBox.Show(string.Format("Palavra \"{0}\" Cadastrada com Sucesso!!", palavra.palavra));
                CarregarGridPalavras();
                LimparCamposPalavras();
            }

        }
        private void btnNovoPalavras_Click(object sender, EventArgs e)
        {
            AdicionarPalavra();
        } // End CREATE



        // VERIFICAR CAMPOS PALAVRAS
        // Verifica se todos os campos estão preenchidos para recolher os dados
        private bool VerificarCamposPalavras()
        {
            // Se os campos estiverem preenchidos, tudo okay e retorna True, se não, false
            if(txtPalavra.Text != "" && txtSignificado.Text != "" && cboClasses.Text != "" && cboBlocos.Text != "")
            {
                return false;
            } else
            {
                string palavra = txtPalavra.Text.Trim() == "" ? "* Palavra\n" : "";

                string classe = cboClasses.Text.Trim() == "" ? "* Classe\n" : "";

                string significado = txtSignificado.Text.Trim() == "" ? "* Significado\n" : "";

                string bloco = cboBlocos.Text.Trim() == "" ? "* Blocos" : "";


                MessageBox.Show("Preencha os Campos Obrigatórios Restantes: \n\n" + palavra + classe + significado + bloco);
                return true;
            }
        }


        // RECOLHER DADOS PALAVRAS
        // Recolhe todos os dados dos campos e armazena em um Objeto do tipo Palavra
        private PalavrasDto RecolherCamposPalavras()
        {
            
            PalavrasDto palavraFinal = new PalavrasDto();

            palavraFinal.palavra = txtPalavra.Text.Trim();
            try
            {
                palavraFinal.classe = ControleCRUDPalavras.EncontrarClassePorNome(cboClasses.Text.Trim());
                palavraFinal.blocoDePalavras = ControleCRUDPalavras.EncontrarBlocoPorNome(cboBlocos.Text.Trim());

            } catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            palavraFinal.significado = txtSignificado.Text.Trim();
            palavraFinal.pronuncia = txtPronuncia.Text.Trim();
            
            palavraFinal.fraseExemplo = ritxtFraseEx.Text.Trim();


            return palavraFinal;

        }


        // DTV PALAVRAS CLICK
        private void dtvPalavras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtvPalavras.RowCount != 0)
            {
                int index = dtvPalavras.CurrentRow.Index;

                try
                {
                    cboBlocos.Text = ControleCRUDPalavras.EncontrarBlocoPorId(Convert.ToInt32(dtvPalavras["blocoDePalavras", index].Value));
                    cboClasses.Text = ControleCRUDPalavras.EncontrarClassePorId(Convert.ToInt32(dtvPalavras["classe", index].Value));
                    txtPalavra.Text = Convert.ToString(dtvPalavras["palavra", index].Value);
                    txtSignificado.Text = Convert.ToString(dtvPalavras["significado", index].Value);
                    txtPronuncia.Text = Convert.ToString(dtvPalavras["Pronuncia", index].Value);
                    ritxtFraseEx.Text = Convert.ToString(dtvPalavras["fraseExemplo", index].Value);
                    lblIdPalavra.Text = Convert.ToString(dtvPalavras["idPalavra", index].Value);

                    try
                    {
                        string caminhoFoto = Convert.ToString(dtvPalavras["fotoExemplo", index].Value);

                        if (VerificarFotoExistente.VerificarFoto(caminhoFoto))
                        {
                            picFotoPalavra.ImageLocation = caminhoFoto;
                        }

                    } catch (fotoNaoEncontradaExceptioncs ex)
                    {
                        picFotoPalavra.ImageLocation = "C:\\workspace\\EngStudy\\EngStudy\\classes\\recursos\\images\\a.png";
                   
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        } // End DTV PALAVRAS CLICK




        #endregion


    }
}
