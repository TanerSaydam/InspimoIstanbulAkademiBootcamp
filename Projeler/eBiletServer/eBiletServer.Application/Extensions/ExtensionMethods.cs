namespace eBiletServer.Application.Extensions;
public static class ExtensionMethods
{
    public static string ReplaceAllTurkishLettersAndDeleteEmpty(this string str)
    {
        str = str.Trim();
        str = str.ToLower();
        str = str.Replace("ğ","g");
        str = str.Replace("ş","s");
        str = str.Replace("ı","i");
        str = str.Replace("ü","u");
        str = str.Replace("ö","o");


        return str;
    }
}
