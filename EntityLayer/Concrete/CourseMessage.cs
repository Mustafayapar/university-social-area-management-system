using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("coursemessages", Schema = "public")]
    public class CourseMessage
    {
        [Key]
        public int message_id { get; set; }
        
        public string message { get; set; }
        public Boolean status { get; set; }
        public DateTime date { get; set;}

        public int president_id { get; set; }
        [ForeignKey("president_id")]
        public virtual Student Student { get; set; }  

    }
}
