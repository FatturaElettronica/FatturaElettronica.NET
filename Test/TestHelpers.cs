﻿using System;
using System.Linq;
using System.Linq.Expressions;
using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.TestHelper;
using FluentValidation.Validators;

namespace FatturaElettronica.Test
{
    public static class TestHelpers
    {
        public static void ShouldHaveDelegatePropertyChildValidator<T, TProperty>(this IValidator<T> validator,
            Expression<Func<T, TProperty>> expression, Type propertyValidatorType)
        {
            var descriptor = validator.CreateDescriptor();
            var expressionMemberName = expression.GetMember().Name;
            var matchingValidators = descriptor.GetValidatorsForMember(expressionMemberName).ToArray();
            var propertyValidatorTypes = matchingValidators
                .Select(v => ((ChildValidatorAdaptor<T,TProperty>) v).ValidatorType);

            if (propertyValidatorTypes.All(x => x != propertyValidatorType))
            {
                throw new ValidationTestException(
                    $"Expected property '{expressionMemberName}' to have a property validator of type '{propertyValidatorType.Name}.'");
            }
        }
    }
}