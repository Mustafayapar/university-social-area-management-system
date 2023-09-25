using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CourseMessageValidatior:AbstractValidator<CourseMessage>
    {
        public CourseMessageValidatior()
        {
            RuleFor(x => x.president_id).NotEmpty().WithMessage("mesaj başkan alanı boş olamaz.");
            RuleFor(x => x.message).NotEmpty().WithMessage("Mesaj alanı boş geçemezsin");
            RuleFor(x => x.date).NotEmpty().WithMessage("Boş olamaz..");
        }
    }
}
