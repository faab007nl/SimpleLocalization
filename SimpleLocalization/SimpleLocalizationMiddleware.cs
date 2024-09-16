using Microsoft.AspNetCore.Http;

namespace SimpleLocalization;

public class SimpleLocalizationMiddleware
{
    
    private readonly RequestDelegate _next;
    private readonly ISimpleLocalization _service;

    public SimpleLocalizationMiddleware(RequestDelegate next, ISimpleLocalization service)
    {
        _next = next;
        _service = service;
    }

    public async Task Invoke(HttpContext context)
    {
        var enabledLanguages = _service.GetEnabledLanguages();
        var selectedLang = _service.GetCurrentLanguage();
        var queryLang = context.Request.Query["lang"].ToString();

        if(context.Request.Query.ContainsKey("lang"))
        {
            selectedLang = LangOption.FromString(queryLang);
        }
        
        if (!enabledLanguages.Contains(selectedLang))
        {
            Console.WriteLine($"Language {selectedLang.TwoLetterISOLanguageName} not supported");
            selectedLang = _service.GetDefaultLanguage();
        }
        
        _service.SetCurrentLanguage(selectedLang);
        
        // Use _myService
        await _next(context);
    }
    
}