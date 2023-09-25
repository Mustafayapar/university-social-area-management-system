using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CommunityRegisterValidatior : AbstractValidator<CommunityRegisteration>
    {
        public CommunityRegisterValidatior()
        {
           // RuleFor(x => x.studentid).NotEmpty().WithMessage("Öğrenci Alanı boş geçemezsin");
            RuleFor(x => x.community_id).NotEmpty().WithMessage("Topluluğu seçiniz");
        }
    }

}
