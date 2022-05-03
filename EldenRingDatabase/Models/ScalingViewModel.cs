namespace EldenRingDatabase
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class ScalingViewModel
    {
        [MaxLength(ScalingMaxLen)]
        public string Endurance { get; set; }

        [MaxLength(ScalingMaxLen)]
        public string Strength { get; set; }

        [MaxLength(ScalingMaxLen)]
        public string Dexterity { get; set; }

        [MaxLength(ScalingMaxLen)]
        public string Intelligence { get; set; }

        [MaxLength(ScalingMaxLen)]
        public string Faith { get; set; }

        [MaxLength(ScalingMaxLen)]
        public string Arcane { get; set; }
    }
}