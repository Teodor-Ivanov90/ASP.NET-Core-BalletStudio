using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static BalletStudio.Data.DataConstants.Teacher;

namespace BalletStudio.Data.Models
{
    public class Teacher
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; }

        public IEnumerable<Group> Groups { get; set; } = new List<Group>();

        public IEnumerable<Dancer> Dancers { get; set; } = new List<Dancer>();
    }
}
