using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("staff", Schema = "public")]
    public class Staff
    {
        [Key]
        public int staff_id{ get; set; }
        public string tc_number { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string password { get; set; }
        public Boolean status { get; set; }
        public ICollection<Events> Eventss { get; set; }

    }
}
