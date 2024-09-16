using System.Globalization;
using Microsoft.AspNetCore.Mvc.Localization;

namespace SimpleLocalization;

public interface ISimpleLocalization
{
    
    public LocalizedHtmlString this[string name, string? fallback = null] { get; }
    public string GetTranslation(string name, string? fallback = null);

    public CultureInfo GetDefaultLanguage();
    public void SetDefaultLanguage(CultureInfo culture);
    public void UseDefaultLanguage();
    
    public void SetEnabledLanguages(params CultureInfo[] cultures);
    public void AddEnabledLanguages(params CultureInfo[] cultures);
    public CultureInfo[] GetEnabledLanguages();
    
    public CultureInfo GetCurrentLanguage();
    public void SetCurrentLanguage(CultureInfo culture);
    
}