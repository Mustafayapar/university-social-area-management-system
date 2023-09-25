using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("departments", Schema = "public")]

    public class Department
    {
        [Key]
        public int d_id { get; set; }
        public string name { get; set; }
        public Boolean status { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
