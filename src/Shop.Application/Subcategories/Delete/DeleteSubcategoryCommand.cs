﻿using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Subcategories.Delete
{
    public sealed record DeleteSubcategoryCommand(int Id) : ICommand<Result<string>>;
}
