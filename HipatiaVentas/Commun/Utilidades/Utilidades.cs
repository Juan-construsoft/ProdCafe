using System.Drawing;

namespace HipatiaVentas.Commun.Utilidades
{
    public class Utilidades : IUtilidades
    {
        /// <summary>
        /// Juan Carlos Reyes
        /// Calcula el alto y el ancho de la imagen
        /// </summary>
        /// <param name="file"></param>
        /// <param name="vWidth"></param>
        /// <param name="vHeight"></param>
        /// <returns></returns>
        public bool CalcularDimensionImagen(IFormFile file, int vWidth, int vHeight)
        {

            bool vRespuesta = true;

            Image image = Image.FromStream(file.OpenReadStream(), true, true);

            if (image.Width != vWidth || image.Height != vHeight)
            {
                vRespuesta = false;
            }

            return vRespuesta;
        }

        public Bitmap RedimencionarImagen(IFormFile file, int vWidth, int vHeight)
        {
            Image image = Image.FromStream(file.OpenReadStream(), true, true);

            var newImage = new Bitmap(vWidth, vHeight);

            using (var g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, vWidth, vHeight);
            }

            return newImage;
        }
    }
}