using FlashCardPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardPOC.Helpers
{
    public interface ICreateDeck
    {
        List<FlashCard> CreateDeck(List<String> Categories);
    }
}
