﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    // Manage Nuget Package'den : FluentValidation  kurulması gerekir
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1).WithMessage("Ürün Tutarı 10 dan büyük olmalı");
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");
            RuleFor(p => p.UnitsInStock).Must(GreaterThanFour).WithMessage("Ürün sayısı en az 5 adet girilmelidir");

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }

        private bool GreaterThanFour(short arg)
        {
            return arg > 4;
        }

    }
}
