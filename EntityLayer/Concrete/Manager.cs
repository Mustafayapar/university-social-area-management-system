using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("managers", Schema = "public")]
    public class Manager
    {
        [Key]
        public int manager_id { get; set; }
        public string user_name { get; set; }

        public string name { get; set; }
        public string surname { get; set; }
        public string password { get; set; }

        public Boolean status { get; set; }
    }

}
