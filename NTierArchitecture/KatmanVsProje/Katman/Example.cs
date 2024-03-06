using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Katman;
public abstract class AbstractValidator<T>
    where T : class
{
    public ValidationResult RuleFor(Expression<Func<T, bool>> expression)
    {
        //değeri kontrol et. Şarta bak
        //değişiklik
        return new ValidationResult(null);

    }

}