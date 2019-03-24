using FlashCardPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardPOC.Helpers
{
    public interface IDeck
    {
        void CreateDeck(List<FlashCard> flashCards);

        FlashCard GetCard(int? index);
    }
}
