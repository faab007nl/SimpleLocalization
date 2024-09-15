using Microsoft.AspNetCore.Mvc.Localization;

namespace SimpleLocalization;

public class SimpleLocalization : ISimpleLocalization
{
    
    public LocalizedHtmlString this[string name, string? fallback = null] => LocalizationHandler.HandleLocalization(name, fallback);
    
}