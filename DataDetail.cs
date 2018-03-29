using System.Collections;
using System.Collections.Generic;

namespace TestFormDB
{
    public class DataDetail
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Table { get; set; }     
        public string Language { get; set; }
        public ICollection<Detail> Details { get; set; }
        public string Condition { get; set; }
    }
    public class Detail
    {
        public string ID { get; set; }
        public string DetailName { get; set; }
        public string ConditionDetail { get; set; }
    }
}