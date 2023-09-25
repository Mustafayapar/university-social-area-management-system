using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidatior:AbstractValidator<Announcement>
    {
        public AnnouncementValidatior()
        {

            RuleFor(x => x.staff_id).NotEmpty().WithMessage("Duyuruyu Yapan alanı boş olamaz.");
            RuleFor(x => x.title).NotEmpty().WithMessage("Duyuru Başlığını boş geçemezsin");
            RuleFor(x => x.description).NotEmpty().WithMessage("Tanım boş olamaz.");
            RuleFor(x => x.date).NotEmpty().WithMessage("Tarih boş olamaz");
        }
    }
}
