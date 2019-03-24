using FlashCardPOC.Models;
using FlashCardPOC.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlashCardPOC.Helpers
{
    public abstract class AbstractDeck : ICreateDeck
    {
        List<FlashCard> flashCardDeck;
        ISqlRepo repo;
        int deckSize { get; set; }
        int numCorrect { get; set; }
        int numAnswered { get; set; }

        public AbstractDeck()
        {
            flashCardDeck = new List<FlashCard>();
        }

        public abstract List<FlashCard> CreateDeck(List<string> Categories);
    }
}