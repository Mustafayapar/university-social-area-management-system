using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CourseValidatior: AbstractValidator<Course>
    {
        public CourseValidatior() 
        {
            RuleFor(x => x.president_id).NotEmpty().WithMessage("Course başkan alanı boş olamaz.");
            RuleFor(x => x.course_name).NotEmpty().WithMessage("Kurs adını boş geçemezsin");
            RuleFor(x => x.description).NotEmpty().WithMessage("Kursu Açıklayınız..");
        }
    }
}
