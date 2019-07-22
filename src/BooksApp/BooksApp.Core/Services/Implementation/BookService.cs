﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BooksApp.Data.Services;
using BooksApp.Domain.Models;
using BooksApp.Domain.Remoting;

namespace BooksApp.Core.Services.Implementation
{
	public class BookService : IBookService, IBooksAppRemoting
	{
		private readonly IBookRepository _bookRepository;

		public BookService(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public Task<IEnumerable<Book>> GetAll()
		{
			return _bookRepository.GetAll();
		}

		public Task<Book> Get(Guid id)
		{
			return _bookRepository.Get(id);
		}
	}
}
