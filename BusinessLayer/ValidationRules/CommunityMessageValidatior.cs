using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CommunityMessageValidatior : AbstractValidator<CommunityMessage>
    {
        public CommunityMessageValidatior()
        {
            RuleFor(x => x.community_president_id).NotEmpty().WithMessage("Mesaj başkan alanı boş olamaz.");
            RuleFor(x => x.messages).NotEmpty().WithMessage("Mesaj alanı boş geçemezsin");
            RuleFor(x => x.date).NotEmpty().WithMessage("Boş olamaz..");
        }
    }
}
