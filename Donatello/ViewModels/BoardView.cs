﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donatello.ViewModels
{
    public class BoardView
    {
        public int Id { get; set; }
        public string BoardTitle { get; set; }
        public List<Column> Columns { get; set; } = new List<Column>();
        public class Column
        {
            public string Title { get; set; }

            public List<Card> Cards { get; set; } = new List<Card>();
        }

        public class Card
        {
            public int Id { get; set; }
            public string Content { get; set; }
        }
    }
}
