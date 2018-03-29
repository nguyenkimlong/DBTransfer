namespace TestFormDB
{
    public class DataTransfer
    {
        public string ID { get; set; }
        public string SrcSQL { get; set; }
        public string ListTable { get; set; }
        public string Table { get; set; }        
        public string Join { get; set; }
        public string Condition { get; set; }       
    }
}