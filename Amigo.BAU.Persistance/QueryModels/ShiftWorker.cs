namespace Amigo.BAU.Persistance.QueryModels
{
    public class ShiftWorker
    {
        public string Name { get; set; }
        public int EngineerId { get; set; }
        public DateTimeOffset? FirstShift { get; set; }
        public DateTimeOffset? LastShift { get; set; }
        public int ShiftCount { get; set; }
    }
}
