using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommandLine;
using CommandLine.Text;


namespace ZPLPrint
{
    class Options
    {
        [Option('a', "PrinterAddr", Required = true,
            HelpText = "Printer Address")]
        public string Printer_Address { get; set; }

        [Option('p', "PrinterPort", Required = false, DefaultValue = 9100,
            HelpText = "Printer Port")]
        public int Printer_Port { get; set; }

        [Option('z', "ZPLFile", Required = true,
            HelpText = "Zebra output formated file")]
        public string ZPL_File { get; set; }

        [Option('d', "DataFile", Required = false,
            HelpText = "Data file (One data item per line).")]
        public string Data_File { get; set; }

    }
}
