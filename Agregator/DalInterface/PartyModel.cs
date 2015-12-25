using System.ComponentModel.DataAnnotations.Schema;
using CommonInterface;

namespace DalInterface
{
    [Table("PartyModel")]
   public class PartyModel:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
    }
}
