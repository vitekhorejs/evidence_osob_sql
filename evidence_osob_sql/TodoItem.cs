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
        int _age;
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }
        public string RodneCislo { get; set; }
        public string Gender { get; set; }
        public string Added { get; set; }
        public string Edited { get; set; }
        /*public int Age
        {
            get=
        }*/
        public override string ToString()
        {
            return Name + " " + SurName + "  " + RodneCislo;// BirthDate.ToString("dd/MM/yyyy");
            //return "ID:" + ID + " Name: " + Name + " SurName: " + SurName + " RodneCislo: " + RodneCislo + " Datum narození: " + BirthDate + " Pohlaví: " + Gender + " Přidáno: " + Added + " upraveno: " + Edited;
        }
    }
}
