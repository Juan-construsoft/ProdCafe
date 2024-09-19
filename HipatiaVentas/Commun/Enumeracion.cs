namespace HipatiaVentas.Commun
{
    public class Enumeracion
    {
        public enum TipoUsuario
        {
            Admin = 1,
            Agente = 2
        }

        public enum TipoCategoria
        {
            TipoDocumento = 1,
            TipoMovimiento = 2,
            Presentacion = 3,
            TipoLavado = 4,
            TipoTostion = 5,
            TipoMolienda = 6,
            Categoria = 7,
            Marca = 8,
            TipoPersona = 9,
            TipoComprobante = 10,
            Variedad = 11
        }

        public enum Alerts
        {
            Success,
            Info,
            Warning,
            Danger
        }
    }
}
