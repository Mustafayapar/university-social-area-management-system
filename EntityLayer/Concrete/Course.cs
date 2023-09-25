using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("courses",Schema ="public")]
    public class Course
    {
        [Key]
        public int course_id { get; set; }
       
        public string course_name { get; set;}
        public string description { get; set; }

        public int president_id { get; set; }
        [ForeignKey("president_id")]
        public virtual Student Student { get; set; }
        public Boolean status { get; set; }

        public ICollection<CourseRegisteration> CourseRegisterations { get; set; }
        
    }
}
