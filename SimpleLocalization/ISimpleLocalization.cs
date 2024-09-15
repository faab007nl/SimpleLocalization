using Microsoft.AspNetCore.Mvc.Localization;

namespace SimpleLocalization;

public interface ISimpleLocalization
{
    
    public LocalizedHtmlString this[string name, string? fallback = null] { get; }
    
}