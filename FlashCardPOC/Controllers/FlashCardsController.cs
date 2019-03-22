using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using FlashCardPOC.Models;
using FlashCardPOC.Repo;

namespace FlashCardPOC.Controllers
{
    public class FlashCardsController : Controller
    {
        SqlRepo repo = new SqlRepo();

        // GET: FlashCards/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string category, string style, string question, string answer, string subCategory1, string subCategory2, string subCategory3)
        {
            try
            {
                ViewData["category"] = category;
                ViewData["style"] = style;
                ViewData["question"] = question;
                ViewData["answer"] = answer;
                ViewData["subCategory1"] = style;
                ViewData["subCategory2"] = question;
                ViewData["subCategory3"] = answer;

                repo.PostCardToDB(ViewData);

                return View("Index");
            }

            catch
            {
                return View();
            }
        }

        public ActionResult CreateDeck()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDeck(string category)
        {
            try
            {
                ViewData["category"] = category;

                repo.GetSingleCategoryDeck(ViewData);

                return View("Index");
            }

            catch
            {
                return View();
            }
        }

        public ActionResult Quiz(int? id = 1)
        {

            FlashCard flashCard = repo.GetQuestion(id);

            if (flashCard == null)
            {
                return HttpNotFound();
            }
            return View(flashCard);
        }
                                 
        public ActionResult BackOfCard(int? id)
        {
            FlashCard flashCard = repo.GetQuestion(id);
            if (flashCard == null)
            {
                return HttpNotFound();
            }

            return View(flashCard);
        }

        public ActionResult Correct(int? id)
        {
            FlashCard temp = repo.LogCorrectResult(id);

            temp.percentageRight = (decimal)temp.numRight / (decimal)temp.numAttempts;

            return View(temp);
        }

        public ActionResult InCorrect(int? id)
        {
            FlashCard temp = repo.LogInCorrectResult(id);

            temp.percentageRight = (decimal)temp.numRight / (decimal)temp.numAttempts;

            return View(temp);
        }

        // GET: FlashCards
        public ActionResult Index()
        {
            return View();
        }



        // GET: FlashCards/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    FlashCard flashCard = db.FlashCards.Find(id);
        //    if (flashCard == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(flashCard);
        //}

        // POST: FlashCards/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    FlashCard flashCard = db.FlashCards.Find(id);
        //    db.FlashCards.Remove(flashCard);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}