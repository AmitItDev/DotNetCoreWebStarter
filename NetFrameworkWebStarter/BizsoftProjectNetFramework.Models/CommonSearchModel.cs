namespace NetFrameworkWebStarter.Models
{
    public class CommonSearchModel
    {
        public string SearchString { get; set; }
        public int StartRowIndex { get; set; }
        public int EndRowIndex { get; set; }
        public string SortExpression { get; set; }
        public string SortDirection { get; set; }
    }
}
