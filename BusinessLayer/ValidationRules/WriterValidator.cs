﻿
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.ValidationRules
{
	public class WriterValidator:AbstractValidator<Writer>
	{
		public WriterValidator()
		{
			RuleFor(x=>x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı boş geçilemez.");
			RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi boş geçilemez.");
			RuleFor(x => x.WriterPassword).Matches(@"[A-Z]+").WithMessage("Şifre en az 1 büyük harften oluşmalıdır.");
			RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
			RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter veri girişi yapın");
			
		}
	}
}
