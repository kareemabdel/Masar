// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using FluentValidation;

namespace Masar.Application.Commands
{

    public class UpdateTripCommandValidator : AbstractValidator<UpdateTripCommand>
    {
        public UpdateTripCommandValidator()
        {
            RuleFor(i => i.obj.Id).NotEqual(Guid.Empty).WithMessage("Id can't be null");
            RuleFor(i => i.obj.CityId).NotEqual(Guid.Empty).NotNull().WithMessage("City  is required");

        }
    }

}
