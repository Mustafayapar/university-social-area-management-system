using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("courseregisterations", Schema = "public")]
    public class CourseRegisteration
    {
        [Key]
        public int register_id { get; set; }
        public int studentid { get; set; }
        [ForeignKey("studentid")]
        public virtual Student Student { get; set; }    

        public int course_id { get; set; }
        [ForeignKey("course_id")]
        public virtual Course Course { get; set; }
        public Boolean status { get; set; }
    }
}
