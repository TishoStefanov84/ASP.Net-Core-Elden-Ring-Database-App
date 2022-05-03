using System.ComponentModel.DataAnnotations;

namespace EldenRingDatabase.Models
{
    public class RequiresViewModel
    {
        [Range(0, 1000)]
        public int Endurance { get; set; }

        [Range(0, 1000)]
        public int Strength { get; set; }

        [Range(0, 1000)]
        public int Dexterity { get; set; }

        [Range(0, 1000)]
        public int Intelligence { get; set; }

        [Range(0, 1000)]
        public int Faith { get; set; }

        [Range(0, 1000)]
        public int Arcane { get; set; }
    }
}