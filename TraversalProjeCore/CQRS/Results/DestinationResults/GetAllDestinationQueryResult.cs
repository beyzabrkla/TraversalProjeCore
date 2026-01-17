namespace TraversalProjeCore.CQRS.Results.DestinationResults
{
    public class GetAllDestinationQueryResult
    {
        public int id { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public string Price { get; set; }
        public int Capacity { get; set; }
    }
}
