using System.Globalization;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Localization;

namespace SimpleLocalization;

public abstract class LocalizationHandler
{
    
    private static string? _currentLocal;

    public static LocalizedHtmlString HandleLocalizationForView(CultureInfo lang, string name, string? fallback = null)
    {
        var translatedString = HandleLocalization(lang, name, [], fallback);
        return GetLocalizedHtmlString(name, translatedString);
    }
    
    public static LocalizedHtmlString HandleLocalizationForView(CultureInfo lang, string name, List<Dictionary<string, string>> vars)
    {
        var translatedString = HandleLocalization(lang, name, vars);
        return GetLocalizedHtmlString(name, translatedString);
    }
    
    public static LocalizedHtmlString HandleLocalizationForView(CultureInfo lang, string name, List<Dictionary<string, string>> vars, string? fallback)
    {
        var translatedString = HandleLocalization(lang, name, vars, fallback);
        return GetLocalizedHtmlString(name, translatedString);
    }

    public static string HandleLocalization(CultureInfo lang, string name, List<Dictionary<string, string>> vars, string? fallback = null)
    {
        _currentLocal = lang.TwoLetterISOLanguageName;
        
        var filePath = GetPathByLocalString(name);
        
        if (File.Exists(filePath))
        {
            var translatedString = GetTranslationString(name, filePath);
            if (translatedString != null)
            {
                translatedString = ReplaceVars(translatedString, vars);
                return translatedString;
            }
        }

        Console.WriteLine("[Localization] Translation not found: " + name);
        return fallback ?? name;
    }

    private static LocalizedHtmlString GetLocalizedHtmlString(string name, string value)
    {
        return new LocalizedHtmlString(name, value);
    }

    private static string GetLocalizationFolderPath()
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "Localization");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        return Path.Combine(path, _currentLocal);
    }

    private static string? GetPathByLocalString(string name)
    {
        var nameWithoutKeys = name.Split(".").First();
        var nameParts = nameWithoutKeys.Split("/");
        var path = GetLocalizationFolderPath();
        
        foreach (var namePart in nameParts)
        {
            if (namePart == nameParts.Last())
            {
                path = Path.Combine(path, namePart+".json");
            }
            else
            {
                path = Path.Combine(path, namePart);
                if (!Directory.Exists(path))
                {
                    return null;
                }
            }
        }
        return path;
    }

    private static string? GetTranslationString(string name, string filePath)
    {
        var json = File.ReadAllText(filePath);
        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;
        
        var nameParts = name.Split(".").Skip(1).ToArray();
        var currentElement = root;
        
        foreach (var namePart in nameParts)
        {
            if (currentElement.TryGetProperty(namePart, out var property))
            {
                currentElement = property;
            }
            else
            {
                return null;
            }
        }
        
        return currentElement.GetString();
    }
    
    private static string ReplaceVars(string translatedString, List<Dictionary<string, string>> vars)
    {
        foreach (var var in vars)
        {
            foreach (var (key, value) in var)
            {
                translatedString = translatedString.Replace(":"+key, value);
            }
        }
        return translatedString;
    }
    
}