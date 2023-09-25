using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("students", Schema = "public")]
    public class Student
    {
        
        [Key]
        public int studentid{ get; set; }
        public string name { get; set; }    
        public string surname { get; set; }
        public string password { get; set; }
        public string student_number { get; set; }
        public string tc_number { get; set; }
        public string email { get; set; }
        public int? president_id { get; set; }
        public ICollection<CourseMessage> CourseMessages { get; set; }

        public int? community_president_id{ get; set;}

        public int d_id { get; set; }// department id
        [ForeignKey("d_id")]
        public virtual Department Department { get; set; }

        public Boolean status { get; set; }

        public ICollection<EventRegisteration>  EventRegisterations { get; set; }  
        public ICollection<Course> Courses { get; set; }
        public ICollection<CourseRegisteration> CourseRegisterations { get; set; }

        public ICollection<Community> Communities { get; set; }
        public ICollection<CommunityRegisteration> CommunityRegisterations { get; set; }
        
    }
}
