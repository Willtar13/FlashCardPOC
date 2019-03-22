using FlashCardPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FlashCardPOC.Repo
{
    interface ISqlRepo
    {
        List<FlashCard> GetSingleCategoryDeck(ViewDataDictionary category);
    }
}
