using System.Collections.Generic;
using Dal.Interface;

namespace Agregator.Models
{
    public class PagingModel
    {
        public int CurrentPage { get; set; }
        public int CountPage { get; set; }
        public IEnumerable<PartyModel> PartyModelList;
    }
}