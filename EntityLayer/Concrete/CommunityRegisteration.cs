using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("communityregisterations", Schema = "public")]
    public class CommunityRegisteration
    {
        [Key]
        public int id { get; set; }
        
        public int studentid { get; set; }
        [ForeignKey("studentid")]
        public virtual Student Student { get; set; }    

        public int community_id { get; set; }
        [ForeignKey("community_id")]
        public virtual Community Community { get; set; }

        public Boolean status { get; set; }
    }
}
