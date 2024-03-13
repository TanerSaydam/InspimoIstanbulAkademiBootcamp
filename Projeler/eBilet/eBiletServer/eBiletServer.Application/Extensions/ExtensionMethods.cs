using eBiletServer.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eBiletServer.Application.Extensions;
public static class ExtensionMethods
{
    public static string ReplaceAllTurkishLettersAndDeleteEmptySpace(
        this string str)
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

    public static async Task<AppUser?> FindByEmailConfirmCode(
        this UserManager<AppUser> userManager,
        int emailConfirmCode, 
        CancellationToken cancellationToken = default)
    {
        AppUser? appUser =
        await userManager
        .Users
            .FirstOrDefaultAsync(p => p.EmailConfirmCode == emailConfirmCode, cancellationToken);

        return appUser;
    }
}
