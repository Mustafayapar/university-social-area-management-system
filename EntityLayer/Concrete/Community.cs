using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("communities", Schema = "public")]
    public class Community
    {
        [Key]
        public int community_id { get; set; }
        
        public string community_name{ get; set; }
        public Boolean status { get; set; }
        public string description { get; set; }

        public int community_president_id { get; set; }
        [ForeignKey("community_president_id")]
        public virtual Student Student { get; set; }


        public ICollection<CommunityMessage> CommunityMessages { get; set; }
        public ICollection<CommunityRegisteration> CommunityRegisterations { get; set; }
    }
}
