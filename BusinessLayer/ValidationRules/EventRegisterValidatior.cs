using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class EventRegisterValidatior :AbstractValidator<EventRegisteration>
    {
        public EventRegisterValidatior() 
        {
            //RuleFor(x => x.id).NotEmpty().WithMessage("Course başkan alanı boş olamaz.");
            RuleFor(x => x.studentid).NotEmpty().WithMessage("Kayıt alanı boş olamaz");
            RuleFor(x => x.eid).NotEmpty().WithMessage("Etkinlik boş olamaz");
        }
    }
    
}
