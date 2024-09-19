using System.Drawing;

namespace HipatiaVentas.Commun.Utilidades
{
    public interface IUtilidades
    {
        Bitmap RedimencionarImagen(IFormFile file, int vWidth, int vHeight);

        bool CalcularDimensionImagen(IFormFile file, int vWidth, int vHeight);
    }
}
