using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;


using System.Net;

namespace ZPLPrint
{
    class Program
    {
        static int Main(string[] args)
        {

            var options = new Options();
            var isValid = CommandLine.Parser.Default.ParseArguments(args, options);

            if (!isValid)
            {
                Console.WriteLine(CommandLine.Text.HelpText.AutoBuild(options).ToString());
                return -1;
            }


            string zpl_file_loc = options.ZPL_File;
            string zpl_frmt = File.ReadAllText(zpl_file_loc);

            string data_file_loc = options.Data_File;
            string[] data = new string[] { };
            string[] stringSeparators = new string[] { "\r\n" };
            if (data_file_loc != null)
            {
                string datastr = File.ReadAllText(data_file_loc);
                data = datastr.Split(stringSeparators, StringSplitOptions.None);
            }


            string ipAddress = options.Printer_Address;
            int port = options.Printer_Port;

            // Open connection
            System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
            client.Connect(ipAddress, port);

            // Write ZPL String to connection
            System.IO.StreamWriter writer =
                new System.IO.StreamWriter(client.GetStream());

            //object[] data = new object[3] { uid, mac, boardid };
            string label = string.Format(zpl_frmt, data );

            int count = options.Repeat_Count;
            for (int i = 0; i < count; i++)
            {
                writer.Write(label);
                writer.Flush();
            }
            // Close Connection
            writer.Close();
            client.Close();


            return 0;
        }
    }
}
