namespace eBiletServer.Application.Extensions;
public static class ExtensionMethods
{
    public static string ReplaceAllTurkishLettersAndDeleteEmptySpace(this string str)
    {
        Dictionary<string, string> letters = new()
        {
            {"ğ","g" },
            {"ş","s" },
            {"ı", "i" },
            {"ü", "u" },
            {"ö", "o" }
        };        

        str = str.Trim();
        str = str.ToLower();

        int x = 0;
        foreach (var letter in letters)
        {
            str = str.Replace(letter.Key, letter.Value);
            x++;

            if (x == 2) break;
        }

        return str;
    }
}
