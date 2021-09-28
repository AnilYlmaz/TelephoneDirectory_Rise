using System.ComponentModel.DataAnnotations;

namespace TelephoneDirectory.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}