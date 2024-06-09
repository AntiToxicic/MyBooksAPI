using Microsoft.AspNetCore.Mvc;
using MyBooks.Core.Entities;
using MyBooks.Core.Enums;
using MyBooks.Core.Interfaces;
using MyBooks.Infrastructure.Repositories;
using MyBooksAPI.DTOs;

namespace MyBooksAPI.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
   private readonly IBookRepository _bookRepository;

   public BooksController(IBookRepository bookRepository)
   {
      _bookRepository = bookRepository;
   }
   
   [HttpPost("{userId}")]
   public async Task<IActionResult> PostBook(uint userId, [FromBody] BookDto bookDto)
   {
      Book book = new Book(bookDto.Title)
      {
         Author = bookDto.Author,
         Description = bookDto.Description,
         UserId = userId
      };
      
      var createdBook = await _bookRepository.Create(book);
      return Ok(createdBook);
   }
   
   [HttpGet("{bookId}")]
   public async Task<IActionResult> GetBook(uint bookId)
   {
      var book = await _bookRepository.Get(bookId);
      if (book == null) return NotFound();
      return Ok(book);
   }
   
   [HttpGet("{userId}/allBooks")]
   public async Task<IActionResult> GetAllBook(uint userId)
   {
      var books = await _bookRepository.GetAll(userId);
      return Ok(books);
   }
   
   [HttpPut("{bookId}")]
   public async Task<IActionResult> PutBook(uint bookId, [FromBody] BookDto bookDto)
   {
      var existingBook = await _bookRepository.Get(bookId);
      if (existingBook == null) return NotFound();

      existingBook.Title = bookDto.Title;
      existingBook.Description = bookDto.Description;
      existingBook.Author = bookDto.Author;

      await _bookRepository.Update(existingBook);
      return Ok();
   }
   
   [HttpDelete("{bookId}")]
   public async Task<IActionResult> DeleteBook(uint bookId)
   {
      var book = await _bookRepository.Get(bookId);
      if (book == null) return NotFound();

      await _bookRepository.Delete(book);
      return Ok();
   }
}