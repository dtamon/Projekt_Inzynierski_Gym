using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Core.DTOs
{
    public class DataToGeneratePdfDto
    {
        public ClientAccountDto Client { get; set; }
        public ContractDto Contract { get; set; }
    }
}
