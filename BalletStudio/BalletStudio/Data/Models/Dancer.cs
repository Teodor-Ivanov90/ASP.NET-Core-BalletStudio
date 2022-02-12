using BalletStudio.Data.Enums;
using System.ComponentModel.DataAnnotations;

using static BalletStudio.Data.DataConstants.Dancer;

namespace BalletStudio.Data.Models
{
    public class Dancer
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public int  TeacherId { get; set; }

        public Teacher  Teacher { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }

    }
}
