using BalletStudio.Data.Enums;
using System.Collections.Generic;

namespace BalletStudio.Data.Models
{
    public class Group
    {
        public int Id { get; init; }

        public Teacher Teacher { get; set; }

        public IEnumerable<Dancer> Dancers { get; set; } = new List<Dancer>();
    }
}
