using Donatello.DataAccess;
using Donatello.Models;
using Donatello.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donatello.Services
{
    public class BoardService
    {
        private readonly DonatelloContext context;

        public BoardService(DonatelloContext context)
        {
            this.context = context;
        }

        public BoardView GetBoard(int id)
        {
            var model = new BoardView();

            var board = context.Boards
               .Include(b => b.Columns)
               .ThenInclude(c => c.Cards)
               .FirstOrDefault(x => x.Id == id);

            model.BoardTitle = board.Title;

            foreach (var column in board.Columns)
            {
                var modelColumn = new BoardView.Column
                {
                    Title = column.Title
                };

                foreach (var card in column.Cards)
                {
                    var modelCard = new BoardView.Card
                    {
                        Content = card.Contents
                    };
                    modelColumn.Cards.Add(modelCard);
                }

                model.Columns.Add(modelColumn);
            }

            return model;
        }

        public BoardList ListBoards()
        {
            var model = new BoardList();

            foreach (var board in context.Boards)
            {
                model.Boards.Add(new BoardList.Board
                {
                    Id = board.Id,
                    Title = board.Title
                });
            }

            return model;
        }

        //public BoardView ListCards()
        //{
        //    var model = new BoardView();

        //    var column = new BoardView.Column { Title = "ToDo" };
        //    var card = new BoardView.Card { Content = "A card" };
        //    var card1 = new BoardView.Card { Content = "Another card" };
        //    column.Cards.Add(card);
        //    column.Cards.Add(card1);
        //    model.Columns.Add(column);

        //    var anotherColumn = new BoardView.Column { Title = "Another" };
        //    var card2 = new BoardView.Card { Content = "A card in another column" };
        //    var card3 = new BoardView.Card { Content = "Another card in another column" };
        //    anotherColumn.Cards.Add(card2);
        //    anotherColumn.Cards.Add(card3);
        //    model.Columns.Add(anotherColumn);

        //    var yetAnotherColumn = new BoardView.Column { Title = "More" };
        //    var card4 = new BoardView.Card { Content = "And so on" };
        //    var card5 = new BoardView.Card { Content = "Without limit" };
        //    yetAnotherColumn.Cards.Add(card4);
        //    yetAnotherColumn.Cards.Add(card5);
        //    model.Columns.Add(yetAnotherColumn);
        //    return model;
        //}

        public void AddBoard(NewBoard vm)
        {
            var newBoard = new Board { Title = vm.Title };

            var defaultColumn1 = new Column { Title = "ToDo" };
            var defaultCard1 = new Card { Contents = "Test card" };
            defaultColumn1.Cards.Add(defaultCard1);
            var defaultColumn2 = new Column { Title = "Doing" };
            var defaultCard2 = new Card { Contents = "This card is in progress" };
            defaultColumn2.Cards.Add(defaultCard2);
            var defaultColumn3 = new Column { Title = "Done" };

            newBoard.Columns.Add(defaultColumn1);
            newBoard.Columns.Add(defaultColumn2);
            newBoard.Columns.Add(defaultColumn3);

            context.Add(newBoard);
            context.SaveChanges();
        }
    }
}
