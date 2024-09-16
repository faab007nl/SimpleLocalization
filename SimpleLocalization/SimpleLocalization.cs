using System.Globalization;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Localization;

namespace SimpleLocalization;

public class SimpleLocalization : ISimpleLocalization
{

    private readonly IHttpContextAccessor _httpContextAccessor;

    public SimpleLocalization(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public LocalizedHtmlString this[string name, string? fallback = null] => LocalizationHandler.HandleLocalizationForView(GetCurrentLanguage(), name, fallback);

    public string GetTranslation(string name, string? fallback = null)
    {
        return LocalizationHandler.HandleLocalization(GetCurrentLanguage(), name, fallback);
    }

    public CultureInfo GetDefaultLanguage()
    {
        var cultureIso = _httpContextAccessor.HttpContext?.Session.GetString("DefaultLanguage") ?? "en";
        return new CultureInfo(cultureIso);
    }

    public void SetDefaultLanguage(CultureInfo culture)
    {
        _httpContextAccessor.HttpContext?.Session.SetString("DefaultLanguage", culture.TwoLetterISOLanguageName);
        _httpContextAccessor.HttpContext?.Session.SetString("CurrentLanguage", culture.TwoLetterISOLanguageName);
    }

    public void UseDefaultLanguage()
    {
        var currentLang = GetDefaultLanguage();
        SetCurrentLanguage(currentLang);
    }

    public void SetEnabledLanguages(params CultureInfo[] cultures)
    {
        var jsonString = cultures.Select(c => c.TwoLetterISOLanguageName).ToArray();
        _httpContextAccessor.HttpContext?.Session.SetString("EnabledLanguages", JsonSerializer.Serialize(jsonString));
    }

    public void AddEnabledLanguages(params CultureInfo[] cultures)
    {
        var enabledLanguages = GetEnabledLanguages().ToList();
        enabledLanguages.AddRange(cultures);
        SetEnabledLanguages(enabledLanguages.ToArray());
    }

    public CultureInfo[] GetEnabledLanguages()
    {
        var jsonString = _httpContextAccessor.HttpContext?.Session.GetString("EnabledLanguages");
        if (jsonString == null)
        {
            return [
                LangOption.English,
                LangOption.Dutch
            ];
        }

        var cultures = JsonSerializer.Deserialize<string[]>(jsonString);
        if (cultures != null) return cultures.Select(c => new CultureInfo(c)).ToArray();

        return [
            LangOption.English,
            LangOption.Dutch
        ];
    }

    public CultureInfo GetCurrentLanguage()
    {
        var cultureIso = _httpContextAccessor.HttpContext?.Session.GetString("CurrentLanguage") ?? "en";
        return new CultureInfo(cultureIso);
    }

    public void SetCurrentLanguage(CultureInfo culture)
    {
        _httpContextAccessor.HttpContext?.Session.SetString("CurrentLanguage", culture.TwoLetterISOLanguageName);
    }
    
}