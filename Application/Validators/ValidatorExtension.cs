using FluentValidation;

namespace Application.Validators
{
    public static class ValidatorExtension
    {
        public static IRuleBuilder<T,string> Password<T>(this IRuleBuilder<T,string> ruleBuilder){
            var options= ruleBuilder.NotEmpty()
                .MinimumLength(6)
                .WithMessage("Şifre minimum 6 karakter olmalıdır.")
                .Matches("[A-Z]").WithMessage("Şifrenizde en az 1 tane büyük harf olmalıdır")
                .Matches("[a-z]").WithMessage("Şifrenizde en az 1 tane küçük harf olmalıdır")
                .Matches("[0-9]").WithMessage("Şifrenizde en az 1 tane sayı olmalıdır");

            return options;
        }
    }
}