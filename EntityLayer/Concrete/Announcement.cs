using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("announcements", Schema="public")]
    public class Announcement
    {
        [Key]
        public int announcement_id{ get; set; }
        public Boolean status { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }


        public int staff_id { get; set; }
        [ForeignKey("staff_id")]
        public virtual Staff Staff { get; set; }    

    }
}
