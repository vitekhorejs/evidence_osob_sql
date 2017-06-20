using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace evidence_osob_sql
{
    public class CategoryItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ID_Category { get; set; }
        public int ID_TodoItem { get; set; }

        public override string ToString()
        {
            return ID_Category + "idcategory " + ID_TodoItem + "iditem ";
        }
    }
}
