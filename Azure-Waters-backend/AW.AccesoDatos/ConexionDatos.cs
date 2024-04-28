using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.AccesoDatos
{
    internal class ConexionDatos
    {
        public static string CONECTION_LAPTOP = "Server=DESKTOP-FEUS1TM;Database=Azure_Waters;User Id=sa;Password=sa123456;TrustServerCertificate=true;";
        public static string CONECTION_PC = "Server=DESKTOP-N2FI4RE;Database=Azure_Waters;User Id=sa;Password=sa123456;TrustServerCertificate=true;";
        public static string CONECTION_RAUL = "Server=localhost; Initial Catalog=Azure_Waters;Integrated Security=True;TrustServerCertificate=true;";

        public static string CONECTION_BRAYAN = "Server=localhost;Database=Azure_Waters;User Id=sa;Password=Antonart.08;TrustServerCertificate=true;";
        public static string CONECTION_WEB = "workstation id=DBif7100.mssql.somee.com;packet size=4096;user id=lab-insectos_SQLLogin_1;pwd=ue68h3xpeq;data source=DBif7100.mssql.somee.com;persist security info=False;initial catalog=DBif7100;TrustServerCertificate=True";
    
        public static string ACTIVE_CONECTION = ConexionDatos.CONECTION_WEB;
    }
}
