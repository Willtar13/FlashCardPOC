using FlashCardPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardPOC.Repo
{
    interface ISqlRepo
    {
        List<FlashCard> GetSingleCategoryDeck(String category);
    }
}
