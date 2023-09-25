using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class EventValidatior: AbstractValidator<Events>
    {
        public EventValidatior() 
        {
            RuleFor(x => x.eid).NotEmpty().WithMessage("Boş olamaz.");
            RuleFor(x => x.staff_id).NotEmpty().WithMessage("Personel adı boş olamaz.");
            RuleFor(x => x.event_name).NotEmpty().WithMessage("Etkinlik adını boş geçemezsin");
            RuleFor(x => x.description).NotEmpty().WithMessage("Etkinliği açıklayınız");
                    
            RuleFor(x => x.date).NotEmpty().WithMessage("Tarih alanı boş olamaz.");
            RuleFor(x => x.location).NotEmpty().WithMessage("Lütfen etkinliğin olacağı yeri giriniz.");
        }    
    }
}
