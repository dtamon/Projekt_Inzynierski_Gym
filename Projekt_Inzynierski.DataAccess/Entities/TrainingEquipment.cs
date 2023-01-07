using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.DataAccess.Entities
{
    public class TrainingEquipment
    {
        public int Id { get; set; }
        public string SerialNr { get; set; }
        public bool TechnicalState { get; set; }
        public TrainingEquipment() { }
    }
}
