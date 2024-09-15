using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Localization;

namespace SimpleLocalization;

public abstract class LocalizationHandler
{
    
    public static LocalizedHtmlString HandleLocalization(string name, string? fallback = null)
    {
        var filePath = GetPathByLocalString(name);
        
        if (File.Exists(filePath))
        {
            var translatedString = GetTranslationString(name, filePath);
            if (translatedString != null)
            {
                return GetLocalizedHtmlString(name, translatedString);
            }
        }
        
        Console.WriteLine("[Localization] Translation not found: " + name);
        return GetLocalizedHtmlString(name, fallback ?? name);
    }

    private static LocalizedHtmlString GetLocalizedHtmlString(string name, string value)
    {
        return new LocalizedHtmlString(name, value);
    }

    private static string GetLocalizationFolderPath()
    {
        const string currentLocal = "en";
        
        var path = Path.Combine(Directory.GetCurrentDirectory(), "Localization");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        return Path.Combine(path, currentLocal);
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
    
}