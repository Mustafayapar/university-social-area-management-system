using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("eventss",Schema="public")]
    public class Events
    {
        [Key]
        public int eid { get; set; }
        public ICollection<EventRegisteration> EventRegisterations { get; set; }

        public int staff_id { get; set; }
        [ForeignKey("staff_id")]
        public virtual Staff Staff { get; set; }


        public string event_name { get; set; }
        public string description { get; set; }

        public DateTime date { get; set; }
        public string location { get; set; }
        public Boolean status { get; set; }

    }
}
