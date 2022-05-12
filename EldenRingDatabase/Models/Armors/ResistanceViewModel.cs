namespace EldenRingDatabase.Models.Armors
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ResistanceViewModel
    {
        [Range(0, 1000)]
        public int Immunity { get; set; }

        [Range(0, 1000)]
        public int Robustness { get; set; }

        [Range(0, 1000)]
        public int Focus { get; set; }

        [Range(0, 1000)]
        public int Vitality { get; set; }

        [Range(0, 1000)]
        public int Poise { get; set; }
    }
}
