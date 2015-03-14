using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BAT.Models
{
    public class Input
    {
        public int CodeSetID; //FK CodeSet.ID
        public int InputID;
        public string Name;
        public string InputType;
        public string Color;
    }

    public class InputsDbContext : DbContext
    {
        public DbSet<Input> Inputs { get; set; }
    }
}