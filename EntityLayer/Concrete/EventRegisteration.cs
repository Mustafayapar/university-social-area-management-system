using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("eventregisterations", Schema = "public")]
    public class EventRegisteration
    {
        [Key]
        public int id { get; set; }

        public int eid { get; set; }
        [ForeignKey("eid")]
        public virtual Events Events { get; set; }

        public int studentid { get; set; }
        [ForeignKey("studentid")]
        public virtual Student Student { get; set; }
        public Boolean status { get; set; }
    }
}
