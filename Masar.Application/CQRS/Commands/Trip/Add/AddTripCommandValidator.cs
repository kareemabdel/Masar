// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using FluentValidation;

namespace Masar.Application.Commands
{

    public class AddTripCommandValidator : AbstractValidator<AddTripCommand>
    {
        public AddTripCommandValidator()
        {
            RuleFor(i => i.obj.Name).NotEmpty().NotNull().WithMessage("Name  is required");
            RuleFor(i => i.obj.CityId).NotEqual(Guid.Empty).NotNull().WithMessage("City  is required");
        }
    }

}
