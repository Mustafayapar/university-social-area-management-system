using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class StudentValidatior : AbstractValidator<Student>
    {
        public StudentValidatior()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("Öğrenci adı boş olamaz.");
            RuleFor(x => x.surname).NotEmpty().WithMessage("Bölümü boş geçemezsin");
            RuleFor(x => x.password).NotEmpty().WithMessage("Şifre Boş olamaz")
                    .MinimumLength(8).WithMessage("En az 8 karakter olmalı")
                    .MaximumLength(16).WithMessage("Maximum 16 karakter olmalıdır")
                    .Matches(@"[A-Z]+").WithMessage("En az bir tane büyük harf içermeli.")
                    .Matches(@"[a-z]+").WithMessage("En az bir tane küçük harf içermeli");
            RuleFor(x => x.student_number).NotEmpty().WithMessage("Öğrenci numarası boş olamaz.");
            RuleFor(x => x.d_id).NotEmpty().WithMessage("Bölümü boş geçemezsin");
            RuleFor(x => x.tc_number).NotEmpty().WithMessage("Tc numarasını boş geçemezsin");
            RuleFor(x => x.email).NotEmpty().WithMessage("Emaili boş geçemezsin").EmailAddress()
        .WithMessage("Geçerli Email adresi giriniz");
            RuleFor(x => x.student_number).MinimumLength(9).WithMessage("öğrenci numarası En az 9 basamaklı olmalıdır.");


        }
    }
}
