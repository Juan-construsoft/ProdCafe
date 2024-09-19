namespace HipatiaVentas.Commun
{
    public class Constantes
    {
        //Constante de login
        //public const string routeLogin = "Authentication/SignInCover";
        public const string routeLogin = "Login";

        //Almacen de azure
        public const string AlmacenAgentes = "agente";
        public const string AlmacenGeneral = "almacen";
        public const string RutaAlmacen = "https://dommunalmacen.blob.core.windows.net/";

        //Tamaño Imagen Foto Agente
        public const int FotoAgenteAncho = 640;
        public const int FotoAgenteAlto = 768;

        //MENSAJES
        public const string msjNoAutorizado = "No autorizado";
        public const string msjLoginErrado = "Usuario o Password Incorrectos";
        public const string msjLoginCorrecto = "Credenciales válidas";

        public const string msjNoHayRegistros = "No se encuentran Registros";

        public const string msjUsuarioEstaRegistrado = "El usuario ya se encuentra registrado";
        public const string msjUsuarioNoGuardado = "El usuario no se pudo guardar";
        public const string msjUsuarioGuardado = "El usuario se registró exitosamente";
        public const string msjDosPasseordNoIguales = "Las contraseñas no son iguales";
        public const string msjNoSepUdoCambiarPass = "No se pudo cambiar la contraseña";
        public const string msjPassCambiado = "La contraseña se cambio con éxito";

        public const string msjRegGuardado = "El registro se guardó con éxito";
        public const string msjRegNoGuardado = "El registro no se puedo guardar";

        public const string msjRegActualizado = "El registro se actualizo con éxito";
        public const string msjRegNoActualizado = "El registro no se puedo actualizar";

        public const string msjRegEliminado = "El registro se eliminó con éxito";
        public const string msjRegNoEliminado = "El registro no se puedo eliminar";
    }
}
