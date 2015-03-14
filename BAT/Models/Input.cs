using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BAT.Models
{
    public class Input
    {
        public int CodeSetID { get; set; } //FK CodeSet.ID
        public int InputID { get; set; }
        public string Name { get; set; }
        public string InputType { get; set; }
        public string Color { get; set; }
    }

    public class InputsDbContext : DbContext
    {
        public DbSet<Input> Inputs { get; set; }
    }
}