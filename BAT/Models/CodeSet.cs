using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;

namespace BAT.Models
{
    public class CodeSet
    {
        public int CodeSetID { get; set; }
        public string CodeSetName { get; set; }
        public string CodeSetDescription { get; set; }
    }
    
    public class CodeSetDbContext : DbContext
    {
        public DbSet<CodeSet> CodeSets { get; set; }
    }
}