using System.Security.Principal;
using Sinlan.Domain.Enums;

namespace Sinlan.Domain.Entities
{
    public class Word : BaseEntity
    {
        public string Text { get; set; }
        public string Explanation { get; set; }
        public string FotoUrl { get; set; }
        public string Example { get; set; }
//        public WordGroup Group { get; set; }
        public string GroupId { get; set; }
        public WordLevel Level { get; set; }
        public WordLang WordLang { get; set; }
        public int Version { get; set; } = 1;

    }
}