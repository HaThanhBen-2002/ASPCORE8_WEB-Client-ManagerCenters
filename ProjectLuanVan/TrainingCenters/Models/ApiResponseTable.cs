namespace TrainingCenters.Models
{
    public class ApiResponseTable
    {
        public int RecordsFiltered { get; set; }
        public int RecordsTotal { get; set; }
        public List<TrungTam>? Data { get; set; }
    }
}
