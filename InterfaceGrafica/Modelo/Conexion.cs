using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceGrafica.Modelo
{
    public class Conexion
    {

        public static string getLocalIPAddressWithNetworkInterface(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                            
                        }
                    }
                }
            }
            return output;
        }

        public static string ConexionPruebas()
        {
            bool Persist_Security = false;
            string userName ="Ricardo";
            string pass ="rhvjinzo101212";
            string db ="zemog";
            string server = "Localhost";

            string conexionDB =
                $"Persist Security Info={Persist_Security};" +
                $"User ID={userName};" +
                $"Password={pass};" +
                $"Initial Catalog={db};" +
                $"Server={server};";



            return conexionDB;
        }

        public static string ConexionProduccion()
        {
            bool Persist_Security = false;
            string userName = "Zemog";
            string pass = "Rhvjinzo101212";
            string db = "zemog";
            string server = "SRVJZZEMOG-03";

            string conexionDB =
                $"Persist Security Info={Persist_Security};" +
                $"User ID={userName};" +
                $"Password={pass};" +
                $"Initial Catalog={db};" +
                $"Server={server};";

            return conexionDB;
        }


    }
}
