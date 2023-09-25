using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("communitymessages", Schema = "public")]
    public class CommunityMessage
    {
        [Key]
        public int message_id { get; set; }
        
        public string messages { get; set; }
        public DateTime date { get; set; }
        public Boolean status { get; set; }
        public int community_president_id { get; set; }
        [ForeignKey("community_president_id")]
        public virtual Community Community { get; set; }
    }
}
