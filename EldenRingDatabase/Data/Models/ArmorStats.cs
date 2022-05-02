namespace EldenRingDatabase.Data.Models
{
    public class ArmorStats
    {
        public int Id { get; init; }

        public int DmgNegationId { get; set; }

        public DmgNegation DmgNegation { get; init; }

        public int ResistanceId { get; set; }

        public Resistance Resistance { get; init; }

    }
}