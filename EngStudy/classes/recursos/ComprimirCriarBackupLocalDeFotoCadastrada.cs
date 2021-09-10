using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EngStudy.classes.recursos
{
    public class ComprimirCriarBackupLocalDeFotoCadastrada
    {

        // Método 1
        // Reduz e Salva uma imagem com o tamanho e Local de Destino padrão dentro da pasta images
        public static string ComprimirESalvarFotoTamanhoPadrao(string fileName, string safeFileName)
        {

            string ResultadoPesquisa = fileName;
            string imgNome = safeFileName;

            //
            //Carrega uma imagem do disco
            Image imageToResize = Image.FromFile(ResultadoPesquisa);

            //Nova altura da imagem
            float novaAltura = 140;
            //Nova largura da imagem
            float novaLagura = 140;

            //Cria um novo objeto do tipo Bitmap, é esse objeto que irá renderizar a imagem redimensionada
            Bitmap novaImagem = new Bitmap((int)novaAltura, (int)novaLagura);

            //Cria um objeto Graphics a partir do objeto Bitmap criado.
            Graphics g = Graphics.FromImage((Image)novaImagem);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //Renderiza a imagem no objeto Bitmap já com a nova largura e altura
            g.DrawImage(imageToResize, 0, 0, novaLagura, novaAltura);
            g.Dispose();

            // Salva a nova imagem no disco
            try
            {
                novaImagem.Save(@"C:\workspace\EngStudy\EngStudy\classes\recursos\images\" + imgNome);

            } catch(Exception ex)
            {
                throw ex;
            }
            string ImagemDoSistema = "C:\\workspace\\EngStudy\\EngStudy\\classes\\recursos\\images\\"
                    + imgNome;
            //

            return ImagemDoSistema;
            
        }
    }
}
