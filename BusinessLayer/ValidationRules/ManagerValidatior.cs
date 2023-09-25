using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ManagerValidatior:AbstractValidator<Manager>
    {
       
        public ManagerValidatior()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("Öğrenci adı boş olamaz.");
            RuleFor(x => x.surname).NotEmpty().WithMessage("Bölümü boş geçemezsin");
            RuleFor(x => x.password).NotEmpty().WithMessage("Şifre Boş olamaz")
                    .MinimumLength(8).WithMessage("En az 8 karakter olmalı")
                    .MaximumLength(16).WithMessage("Maximum 16 karakter olmalıdır")
                    .Matches(@"[A-Z]+").WithMessage("En az bir tane büyük harf içermeli.")
                    .Matches(@"[a-z]+").WithMessage("En az bir tane küçük harf içermeli");
            RuleFor(x => x.user_name).NotEmpty().WithMessage("Kullanıcı adı boş olamaz.");
          
        }
       

    }


}
