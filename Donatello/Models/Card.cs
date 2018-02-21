using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donatello.Models
{
    public class Card
    {
      public int Id { get; set; }
      public string Contents { get; set; }
      public int ColumnId { get; set; }
      public Column Column { get; set; }
   }
}
