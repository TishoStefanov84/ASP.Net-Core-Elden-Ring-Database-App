namespace EldenRingDatabase.Data.Models
{
    public class Resistance
    {
        public int Id { get; init; }

        public int Immunity { get; set; }

        public int Robustness { get; set; }

        public int Focus { get; set; }

        public int Vitality { get; set; }

        public int Poise { get; set; }
    }
}