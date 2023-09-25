using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CourseRegisterValidatior:AbstractValidator<CourseRegisteration>
    {
        public CourseRegisterValidatior()
        {
            RuleFor(x => x.register_id).NotEmpty().WithMessage("Kurs .");
            RuleFor(x => x.studentid).NotEmpty().WithMessage("Öğrenci adını boş geçemezsin");
            RuleFor(x => x.course_id).NotEmpty().WithMessage("Kursu seçiniz");
        }
    }
}
