# Simple Localization

A simple ASP.NET package that adds laravel like localization using json files.

## How to install
### Install the package
```
TODO
```

### Add the following code to the Program.cs
```
builder.Services.Add(new ServiceDescriptor(typeof(ISimpleLocalization), new SimpleLocalization()));
```

### Add the following code to Views/Shared/_ViewImports.cshtml
```
@using Pictura.Packages.LocalizationPlugin

@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```
