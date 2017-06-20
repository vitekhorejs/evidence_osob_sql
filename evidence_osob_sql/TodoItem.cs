﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace evidence_osob_sql
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }

        public override string ToString()
        {
            return Name + " - " + Cost + " Kč ";
        }
    }
}
