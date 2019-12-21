using System.ComponentModel.DataAnnotations;

namespace MianXiangProject.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}