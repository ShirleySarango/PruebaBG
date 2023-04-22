namespace WsMiStream.Conexion
{
    public class ConexionBD
    {
        private string conexionString = string.Empty;
        public ConexionBD() {

            var contructor = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            conexionString = contructor.GetSection("ConnectionStrings:conexionBG").Value;
        }

        public string ConexionSql()
        {
            return conexionString;
        }


    }
}
