﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mybooks.Data.Services;
using mybooks.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mybooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;
        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost("add-book")]
        public IActionResult AddBook ([FromBody]BookVM book)
        {
            _booksService.AddBook(book);
            return Ok();
        }
    }
}
