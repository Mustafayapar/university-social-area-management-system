using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CommunityValidatior : AbstractValidator<Community>
    {
        public CommunityValidatior()
        {
            
            RuleFor(x => x.community_president_id).NotEmpty().WithMessage("Kurs başkanı boş olamaz");
            RuleFor(x => x.community_name).NotEmpty().WithMessage("Kursun adını giriniz");
            RuleFor(x => x.description).NotEmpty().WithMessage("Kursun tanımını yapınız");
        }
    }
}
