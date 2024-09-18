# Simple Localization

A simple ASP.NET package that adds laravel like localization using json files.

## Issues
If you have any problems of suggestions please open an issue on [GitHub](https://github.com/faab007nl/SimpleLocalization/issues)
https://github.com/faab007nl/SimpleLocalization/issues

## How to install
### 1. Install the package
```shell
dotnet add package Faab007NL.SimpleLocalization --version 1.1.0
```

### 2. Add the following code to the Program.cs
This registers the SimpleLocalization service.
```csharp
builder.Services.Add(new ServiceDescriptor(typeof(ISimpleLocalization), new SimpleLocalization()));
```

### 2b. Add the following code the the Startup.cs (Optional)
This registers the SimpleLocalizationMiddleware allowing you to add *?lang=en* in the url to change the language.
```csharp
app.UseMiddleware<SimpleLocalizationMiddleware>();
```

### 3. Add the following code to Views/Shared/_ViewImports.cshtml
The following code adds the localization tag helper to the views.
```csharp
@using Pictura.Packages.LocalizationPlugin

@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

### Translating in a view
The following code shows how to translate a string in a view.
```html
<h1 class="display-4">@L["home.welcome"]</h1>
```

### Translating in a controller
The following code shows how to translate a string in a controller.
```csharp
public MyControllerClass(ISimpleLocalization service)
{
    _service = service;
}

public IActionResult Index()
{
    ViewData["Title"] = _service.GetTranslation("Hello World");
    return View();
}
```

### Adding a translation
The app creates a folder called Localization.  
In this folder you can create folders for each language you want to support.  
For example the folders: ***en*** and ***nl***.  
***Always use the 2 letter language code in lowercase for the folder names.***  
In these folders you can create json files.  
For example the file: *home.json* or *home/index.json*.  

The json file should look like this:
```json
{
    "welcome": "Hello World"
}
```

When writing a key. A slash (/) is used to separate the folder and file name.  
The word after the last slash is the key of the json file.  
For example: *home/index.json* -> *home/index*  

A dot (.) is used to separate the keys inside the json file.  
Writing *home/index.welcome* will get the value of the key welcome in the file *home/index.json*.  
You can also *home/index.welcome.text* to get sub keys.  

## Using variables in translations
You can use variables in translations as follows:
```json
{
    "welcome": "Hello :name"
}
```

You can then use the following code to replace the variable:
```csharp
_service.GetTranslation("home/index.welcome", new Dictionary<string, string> { { "name", "John" } });
```

Or in a view:
```html
<h1 class="display-4">@L["home.welcome", new Dictionary<string, string> { { "name", "John" } }]</h1>
```


## Service Functions

### GetTranslation
Returns: string  
Parameters: string key, string fallback = null
```csharp
_service.GetTranslation("Hello World");
```

### GetDefaultLanguage
Returns: CultureInfo  
Parameters: none
```csharp
_service.GetDefaultLanguage();
```

### SetDefaultLanguage
Returns: none  
Parameters: CultureInfo culture
```csharp
_service.SetDefaultLanguage(CultureInfo.GetCultureInfo("en"));
```

### UseDefaultLanguage
Returns: none  
Parameters: none
```csharp
_service.UseDefaultLanguage();
```

### SetEnabledLanguages
Returns: none  
Parameters: CultureInfo[] cultures
```csharp
_service.SetEnabledLanguages(new CultureInfo[] { CultureInfo.GetCultureInfo("en"), CultureInfo.GetCultureInfo("nl") });
```

### AddEnabledLanguages
Returns: none  
Parameters: CultureInfo[] cultures
```csharp
_service.AddEnabledLanguages(new CultureInfo[] { CultureInfo.GetCultureInfo("en"), CultureInfo.GetCultureInfo("nl") });
```

### GetEnabledLanguages
Returns: CultureInfo[]   
Parameters: none
```csharp
_service.GetEnabledLanguages();
```

### GetCurrentLanguage
Returns: CultureInfo  
Parameters: none
```csharp
_service.GetCurrentLanguage();
```

### SetCurrentLanguage
Returns: none  
Parameters: CultureInfo culture
```csharp
_service.SetCurrentLanguage(CultureInfo.GetCultureInfo("en"));
```
