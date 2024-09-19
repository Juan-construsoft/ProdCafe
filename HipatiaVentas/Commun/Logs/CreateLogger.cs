namespace HipatiaVentas.Commun.Logs
{
    public class CreateLogger : ICreateLogger
    {
        private string logFormat = string.Empty;
        private string logPath = string.Empty;

        public CreateLogger()
        {
        }

        /// <summary>
        /// Logs the write.
        /// The log message.
        /// </summary>
        /// <param name="logMessage"></param>
        public void LogWriteExcepcion(string logMessage)
        {
            string fileName = "Log" + DateTime.Now.ToString("ddMMyyyy") + ".txt";
            string logPath = "Logs";

            var fullPath = Path.GetFullPath(logPath);

            logFormat = "dddd, d 'de' MMMM 'de' yyyy h:mm:ss.ff tt";

            logFormat = "\n------------------------------------------------------------------------------------\n" + DateTime.Now.ToString(logFormat) + "\n"; //DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss zzz") + "\n";

            try
            {
                using (StreamWriter logFileWriter = File.AppendText(fullPath + "//" + fileName))
                {
                    logFileWriter.WriteLine(logFormat + logMessage);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
