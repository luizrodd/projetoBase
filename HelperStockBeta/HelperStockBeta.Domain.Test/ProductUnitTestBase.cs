using FluentAssertions;
using HelperStockBeta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperStockBeta.Domain.Test
{
    public class ProductUnitTestBase
    {
        [Fact(DisplayName = "Product name is not null")]
        public void CreateProduct_WithValidParemeters_ResultValid()
        {
            Action action = () => new Product(1,"Iphone","Iphone é um celular",1.99M,2, "https://m.media-amazon.com/images/I/41rfDU6FGqL.__AC_SY445_SX342_QL70_ML2_.jpg");
            action.Should()
                .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Product no present id parameter.")]
        public void CreateProduct_IdParameterLess_ResultValid()
        {
            Action action = () => new Product("Iphone", "Iphone é um celular", 1.99M, 2, "https://m.media-amazon.com/images/I/41rfDU6FGqL.__AC_SY445_SX342_QL70_ML2_.jpg");
            action.Should()
                .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Product negative exception.")]
        public void CreateProduct_NegativeId_ResultValid()
        {
            Action action = () => new Product(-1, "Iphone", "Iphone é um celular", 1.99M, 2, "https://m.media-amazon.com/images/I/41rfDU6FGqL.__AC_SY445_SX342_QL70_ML2_.jpg");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid negative values for id.");
        }
        [Fact(DisplayName = "Product name is null.")]
        public void CreateProduct_NameNull_ResultValid()
        {
            Action action = () => new Product(1, null, "Iphone é um celular", 1.99M, 2, "https://m.media-amazon.com/images/I/41rfDU6FGqL.__AC_SY445_SX342_QL70_ML2_.jpg");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }
        [Fact(DisplayName = "Product name is short.")]
        public void CreateProduct_NameShort_ResultValid()
        {
            Action action = () => new Product(1, "I", "Iphone é um celular", 1.99M, 2, "https://m.media-amazon.com/images/I/41rfDU6FGqL.__AC_SY445_SX342_QL70_ML2_.jpg");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid short names, minimum 3 characteres.");
        }
        [Fact(DisplayName = "Product description is null.")]
        public void CreateProduct_DescriptionNull_ResultValid()
        {
            Action action = () => new Product(1, "Iphone", null, 1.99M, 2, "https://m.media-amazon.com/images/I/41rfDU6FGqL.__AC_SY445_SX342_QL70_ML2_.jpg");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, description is required.");
        }
        [Fact(DisplayName = "Product description is short.")]
        public void CreateProduct_DescriptionShort_ResultValid()
        {
            Action action = () => new Product(1, "Iphone", "Ipho", 1.99M, 2, "https://m.media-amazon.com/images/I/41rfDU6FGqL.__AC_SY445_SX342_QL70_ML2_.jpg");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid short descriptions, minimum 5 characters.");
        }
        [Fact(DisplayName = "Product price is negative.")]
        public void CreateProduct_PriceNegative_ResultValid()
        {
            Action action = () => new Product(1, "Iphone", "Iphone é um celular", -1.99M, 2, "https://m.media-amazon.com/images/I/41rfDU6FGqL.__AC_SY445_SX342_QL70_ML2_.jpg");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid negative values for price.");
        }
        [Fact(DisplayName = "Product stock is negative.")]
        public void CreateProduct_StockNegative_ResultValid()
        {
            Action action = () => new Product(1, "Iphone", "Iphone é um celular", 1.99M, -2, "https://m.media-amazon.com/images/I/41rfDU6FGqL.__AC_SY445_SX342_QL70_ML2_.jpg");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid negative values for stock.");
        }
        [Fact(DisplayName = "Product image is long.")]
        public void CreateProduct_ImageLong_ResultValid()
        {
            Action action = () => new Product(1, "Iphone", "Iphone é um celular", 1.99M, 2, "https://m.media-amazon.com/images/I/41rfDU6FGqL.__AC_SY445_SX342_QL70_ML2_.jpghttps://m.media-amazon.com/images/I/41rfDU6FGqL.__AC_SY445_SX342_QL70_ML2_.jpghttps://m.media-amazon.com/images/I/41rfDU6FGqL.__AC_SY445_SX342_QL70_ML2_.jpghttps://m.media-amazon.com/images/I/41rfDU6FGqL.__AC_SY445_SX342_QL70_ML2_.jpghttps://m.media-amazon.com/images/I/41rfDU6FGqL.__AC_SY445_SX342_QL70_ML2_.jpg");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid long URL, maximum 250 characteres.");
        }

    }
}
