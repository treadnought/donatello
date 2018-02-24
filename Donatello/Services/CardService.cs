using Donatello.DataAccess;
using Donatello.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donatello.Services
{
    public class CardService
    {
        private readonly DonatelloContext _context;

        public CardService(DonatelloContext context)
        {
            _context = context;
        }
        public CardDetails GetCardDetails(int id)
        {
            var model = new CardDetails();

            var card = _context.Cards.SingleOrDefault(x => x.Id == id);
            if (card == null) return new CardDetails();
            return new CardDetails
            {
                Id = card.Id,
                Contents = card.Contents,
                Notes = card.Notes
            };
        }

        public void Update(CardDetails details)
        {
            var card = _context.Cards.SingleOrDefault(x => x.Id == details.Id);
            card.Contents = details.Contents;
            card.Notes = details.Notes;

            _context.SaveChanges();
        }
    }
}
