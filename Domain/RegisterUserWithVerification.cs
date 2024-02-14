using Domain;
using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class RegisterUserWithVerification : IRegUser
    {
        private readonly IRegUser reg;
        private readonly ILogger log;

        public RegisterUserWithVerification(IRegUser reg, ILogger log)
        {
            this.reg = reg ?? throw new ArgumentNullException(nameof(reg));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public void Execute(User data)
        {
            Verif(data);

            reg.Execute(data);
        }

        private void Verif(User data)
        {
            var context = new ValidationContext(data);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(data, context, results, true))
            {
                foreach (var item in results)
                {
                    log.Log(item.ErrorMessage);
                }
                throw new ValidationException(typeof(User) + " not validated.\nYou can see the details in the logs");
            }
        }
    }
}
