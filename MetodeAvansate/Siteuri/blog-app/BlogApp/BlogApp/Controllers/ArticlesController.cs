﻿using BlogApp.Models;
using BlogApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [Controller]
    [Route("/api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticlesService _articlesService;

        public ArticlesController(IArticlesService articlesService)
        {
            _articlesService = articlesService;
        }

        [HttpGet]
        public ActionResult GetAllArticles()
        {
            try
            {
                var articles = _articlesService.GetAllArticles();
                return new OkObjectResult(articles);
            }
            catch
            {
                return new ObjectResult("Something went wrong!")
                {
                    StatusCode = 500
                };
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetArticle(int id)
        {
            try
            {
                var article = _articlesService.GetArticle(id);
                return new OkObjectResult(article);
            }
            catch (KeyNotFoundException ex)
            {
                return new NotFoundObjectResult(ex.Message);
            }
            catch
            {
                return new ObjectResult("Something went wrong!")
                {
                    StatusCode = 500
                };
            }
        }

        [HttpPost]
        public ActionResult PostArticle([FromBody] Article article)
        {
            try
            {
                var dbArticle = _articlesService.PostArticle(article);
                return new OkObjectResult(dbArticle);
            }
            catch
            {
                return new ObjectResult("Something went wrong!")
                {
                    StatusCode = 500
                };
            }
        }

        [HttpPut("{id}")]
        public ActionResult EditArticle(int id, [FromBody] Article article)
        {
            try
            {
                _articlesService.EditArticle(id, article);
                return new NoContentResult();
            }
            catch (KeyNotFoundException ex)
            {
                return new NotFoundObjectResult(ex.Message);
            }
            catch
            {
                return new ObjectResult("Something went wrong!")
                {
                    StatusCode = 500
                };
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteArticle(int id)
        {
            try
            {
                Article dbArticle = _articlesService.DeleteArticle(id);
                return new OkObjectResult(dbArticle);
            }
            catch (KeyNotFoundException ex)
            {
                return new NotFoundObjectResult(ex.Message);
            }
            catch
            {
                return new ObjectResult("Something went wrong!")
                {
                    StatusCode = 500
                };
            }
        }
    }
}
