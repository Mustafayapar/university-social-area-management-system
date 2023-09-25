using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class DepartmentValidatior:AbstractValidator<Department>
    {
        public DepartmentValidatior() 
        {
            RuleFor(x=> x.name).NotEmpty().WithMessage("Bölüm adı boş olamaz");
        }

    }
}
