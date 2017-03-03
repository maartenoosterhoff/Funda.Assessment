using System.Collections.Generic;

namespace Funda.Assessment.Entities
{
    public class FundaDataResult
    {
        public List<FundaObject> Objects { get; set; }
        public FundaPaging Paging { get; set; }
        public int TotaalAantalObjecten { get; set; }
    }
}