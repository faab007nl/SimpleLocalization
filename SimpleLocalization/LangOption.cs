using System.Globalization;

namespace SimpleLocalization;

public abstract class LangOption
{

    public static CultureInfo FromString(string name)
    {
        try
        {
            return new CultureInfo(name);
        }catch(Exception)
        {
            Console.WriteLine("[Localization] Language not supported. Defaulting to English: " + name);
            return English;
        }
    }
    
    public static readonly CultureInfo English = new CultureInfo("en");
    public static readonly CultureInfo Spanish = new CultureInfo("es");
    public static readonly CultureInfo Chinese = new CultureInfo("zh");
    public static readonly CultureInfo Hindi = new CultureInfo("hi");
    public static readonly CultureInfo Arabic = new CultureInfo("ar");
    public static readonly CultureInfo French = new CultureInfo("fr");
    public static readonly CultureInfo Bengali = new CultureInfo("bn");
    public static readonly CultureInfo Portuguese = new CultureInfo("pt");
    public static readonly CultureInfo Russian = new CultureInfo("ru");
    public static readonly CultureInfo Japanese = new CultureInfo("ja");
    public static readonly CultureInfo German = new CultureInfo("de");
    public static readonly CultureInfo Korean = new CultureInfo("ko");
    public static readonly CultureInfo Italian = new CultureInfo("it");
    public static readonly CultureInfo Turkish = new CultureInfo("tr");
    public static readonly CultureInfo Vietnamese = new CultureInfo("vi");
    public static readonly CultureInfo Polish = new CultureInfo("pl");
    public static readonly CultureInfo Dutch = new CultureInfo("nl");
    public static readonly CultureInfo Greek = new CultureInfo("el");
    public static readonly CultureInfo Thai = new CultureInfo("th");
    public static readonly CultureInfo Swedish = new CultureInfo("sv");
    public static readonly CultureInfo Hungarian = new CultureInfo("hu");
    public static readonly CultureInfo Czech = new CultureInfo("cs");
    public static readonly CultureInfo Ukrainian = new CultureInfo("uk");
    public static readonly CultureInfo Finnish = new CultureInfo("fi");
    public static readonly CultureInfo Danish = new CultureInfo("da");
    public static readonly CultureInfo Romanian = new CultureInfo("ro");
    public static readonly CultureInfo Malay = new CultureInfo("ms");
    public static readonly CultureInfo Hebrew = new CultureInfo("he");
    public static readonly CultureInfo Norwegian = new CultureInfo("no");
    public static readonly CultureInfo Persian = new CultureInfo("fa");
    public static readonly CultureInfo Swahili = new CultureInfo("sw");
    public static readonly CultureInfo Tamil = new CultureInfo("ta");
    public static readonly CultureInfo Marathi = new CultureInfo("mr");
    public static readonly CultureInfo Telugu = new CultureInfo("te");
    public static readonly CultureInfo Kannada = new CultureInfo("kn");
    public static readonly CultureInfo Gujarati = new CultureInfo("gu");
    public static readonly CultureInfo Malayalam = new CultureInfo("ml");
    public static readonly CultureInfo Punjabi = new CultureInfo("pa");
    public static readonly CultureInfo Burmese = new CultureInfo("my");
    public static readonly CultureInfo Khmer = new CultureInfo("km");
    public static readonly CultureInfo Lao = new CultureInfo("lo");
    public static readonly CultureInfo Sinhala = new CultureInfo("si");
    public static readonly CultureInfo Nepali = new CultureInfo("ne");
    public static readonly CultureInfo Amharic = new CultureInfo("am");
    public static readonly CultureInfo Zulu = new CultureInfo("zu");
    public static readonly CultureInfo Xhosa = new CultureInfo("xh");
    public static readonly CultureInfo Shona = new CultureInfo("sn");
    public static readonly CultureInfo Yoruba = new CultureInfo("yo");
    public static readonly CultureInfo Hausa = new CultureInfo("ha");
    public static readonly CultureInfo Igbo = new CultureInfo("ig");
    public static readonly CultureInfo Somali = new CultureInfo("so");
    public static readonly CultureInfo Albanian = new CultureInfo("sq");
    public static readonly CultureInfo Bosnian = new CultureInfo("bs");
    public static readonly CultureInfo Serbian = new CultureInfo("sr");
    public static readonly CultureInfo Croatian = new CultureInfo("hr");
    public static readonly CultureInfo Slovenian = new CultureInfo("sl");
    public static readonly CultureInfo Macedonian = new CultureInfo("mk");
    public static readonly CultureInfo Bulgarian = new CultureInfo("bg");
    public static readonly CultureInfo Latvian = new CultureInfo("lv");
    public static readonly CultureInfo Lithuanian = new CultureInfo("lt");
    public static readonly CultureInfo Estonian = new CultureInfo("et");
    public static readonly CultureInfo Icelandic = new CultureInfo("is");
    public static readonly CultureInfo Maltese = new CultureInfo("mt");
    public static readonly CultureInfo Irish = new CultureInfo("ga");
    public static readonly CultureInfo Welsh = new CultureInfo("cy");
    public static readonly CultureInfo ScotsGaelic = new CultureInfo("gd");
    public static readonly CultureInfo Basque = new CultureInfo("eu");
    public static readonly CultureInfo Catalan = new CultureInfo("ca");
    public static readonly CultureInfo Galician = new CultureInfo("gl");
    public static readonly CultureInfo Armenian = new CultureInfo("hy");
    public static readonly CultureInfo Georgian = new CultureInfo("ka");
    public static readonly CultureInfo Azerbaijani = new CultureInfo("az");
    public static readonly CultureInfo Uzbek = new CultureInfo("uz");
    public static readonly CultureInfo Kazakh = new CultureInfo("kk");
    public static readonly CultureInfo Kyrgyz = new CultureInfo("ky");
    public static readonly CultureInfo Tajik = new CultureInfo("tg");
    public static readonly CultureInfo Turkmen = new CultureInfo("tk");
    public static readonly CultureInfo Pashto = new CultureInfo("ps");
    public static readonly CultureInfo Dari = new CultureInfo("prs");
    public static readonly CultureInfo Kurdish = new CultureInfo("ku");
    public static readonly CultureInfo Tibetan = new CultureInfo("bo");
    public static readonly CultureInfo Mongolian = new CultureInfo("mn");
    public static readonly CultureInfo Tatar = new CultureInfo("tt");
    public static readonly CultureInfo Bashkir = new CultureInfo("ba");
    public static readonly CultureInfo Chuvash = new CultureInfo("cv");
    public static readonly CultureInfo Uyghur = new CultureInfo("ug");
    public static readonly CultureInfo UzbekCyrillic = new CultureInfo("uzc");
    public static readonly CultureInfo KhmerRomanized = new CultureInfo("khr");
    public static readonly CultureInfo LaoRomanized = new CultureInfo("lor");
    public static readonly CultureInfo Cherokee = new CultureInfo("chr");
    public static readonly CultureInfo Navajo = new CultureInfo("nv");
    public static readonly CultureInfo Cree = new CultureInfo("cr");
    public static readonly CultureInfo Maori = new CultureInfo("mi");
    public static readonly CultureInfo Samoan = new CultureInfo("sm");
    public static readonly CultureInfo Tahitian = new CultureInfo("ty");
    public static readonly CultureInfo Tongan = new CultureInfo("to");
    public static readonly CultureInfo Hawaiian = new CultureInfo("haw");
    public static readonly CultureInfo Inuktitut = new CultureInfo("iu");
    public static readonly CultureInfo Greenlandic = new CultureInfo("kl");
    public static readonly CultureInfo Filipino = new CultureInfo("tl");
    public static readonly CultureInfo Javanese = new CultureInfo("jv");
    public static readonly CultureInfo Sundanese = new CultureInfo("su");
    public static readonly CultureInfo Madurese = new CultureInfo("mad");
    public static readonly CultureInfo Tigrinya = new CultureInfo("ti");
    public static readonly CultureInfo Wolof = new CultureInfo("wo");
    public static readonly CultureInfo Quechua = new CultureInfo("qu");
    public static readonly CultureInfo Aymara = new CultureInfo("ay");
    public static readonly CultureInfo Hmong = new CultureInfo("hmn");
    public static readonly CultureInfo Fijian = new CultureInfo("fj");
    public static readonly CultureInfo Bislama = new CultureInfo("bi");
    public static readonly CultureInfo Dzongkha = new CultureInfo("dz");
    public static readonly CultureInfo Luxembourgish = new CultureInfo("lb");
    public static readonly CultureInfo Rundi = new CultureInfo("rn");
    public static readonly CultureInfo Kinyarwanda = new CultureInfo("rw");
    public static readonly CultureInfo Twi = new CultureInfo("tw");
    public static readonly CultureInfo Sango = new CultureInfo("sg");
    public static readonly CultureInfo Faroese = new CultureInfo("fo");
    public static readonly CultureInfo Malagasy = new CultureInfo("mg");
    public static readonly CultureInfo Setswana = new CultureInfo("tn");
    public static readonly CultureInfo Sesotho = new CultureInfo("st");
    public static readonly CultureInfo Oromo = new CultureInfo("om");
    public static readonly CultureInfo Tachelhit = new CultureInfo("shi");
    public static readonly CultureInfo Luo = new CultureInfo("luo");
    public static readonly CultureInfo Fon = new CultureInfo("fon");
    
}