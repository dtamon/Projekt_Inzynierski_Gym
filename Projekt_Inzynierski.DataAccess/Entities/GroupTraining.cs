﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.DataAccess.Entities
{
    public class GroupTraining
    {
        public int Id { get; set; }
        public string TrainingType { get; set; }
        public int MaxCLients { get; set; }
        public DateTime StartDate { get; set; }
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
        public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
        public virtual ICollection<Trainer> Trainers { get; set; } = new List<Trainer>();

        public GroupTraining() { }
    }
}
