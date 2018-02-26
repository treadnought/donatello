using Donatello.DataAccess;
using Donatello.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var card = _context.Cards
                .Include(c => c.Column)
                .SingleOrDefault(x => x.Id == id);

            if (card == null) return new CardDetails();

            var board = _context.Boards
                .Include(b => b.Columns)
                .SingleOrDefault(b => b.Id == card.Column.BoardId);

            var availableColumns = board.Columns
                .Select(x => new SelectListItem
                {
                    Text = x.Title,
                    Value = x.Id.ToString()
                });

            return new CardDetails
            {
                Id = card.Id,
                Contents = card.Contents,
                Notes = card.Notes,
                Columns = availableColumns.ToList(),
                Column = card.ColumnId
            };
        }

        public void Update(CardDetails details)
        {
            var card = _context.Cards.SingleOrDefault(x => x.Id == details.Id);
            card.Contents = details.Contents;
            card.Notes = details.Notes;
            card.ColumnId = details.Column;

            _context.SaveChanges();
        }
    }
}
