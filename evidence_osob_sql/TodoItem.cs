using System;
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
        public int ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }
        public string RodneCislo { get; set; }
        public string Gender { get; set; }
        public string Added { get; set; }
        public string Edited { get; set; }
        public int Age
        {
            get { return _age(); }
        }
        public int _age()
        {
            DateTime now = DateTime.Today;
            int age = now.Year - BirthDate.Year;
            if (now < BirthDate.AddYears(age)) age--;
            return age;
        }

        public override string ToString()
        {
            return Name + " " + SurName + "  " + RodneCislo + " " + Age;
        }
    }
}
