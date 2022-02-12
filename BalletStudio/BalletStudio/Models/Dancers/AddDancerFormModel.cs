using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static BalletStudio.Data.DataConstants.Dancer;

namespace BalletStudio.Models.Dancers
{
    public class AddDancerFormModel
    {

        [Required]
        [StringLength(FirstNameMaxLength),MinLength(FirstNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(LastNameMaxLength), MinLength(LastNameMinLength)]
        public string LastName { get; set; }

        [Range(4,50)]
        public int Age { get; set; }

        [Display(Name ="Teacher")]
        public int TeacherId { get; set; }

        public IEnumerable<TeacherNameFormModel> Teachers { get; set; }
    }
}
