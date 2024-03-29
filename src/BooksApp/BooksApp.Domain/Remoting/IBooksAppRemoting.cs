﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BooksApp.Domain.Models;
using BooksApp.Infrastructure;

namespace BooksApp.Domain.Remoting
{
	public interface IBooksAppRemoting : IRemotingBase
	{
		Task<IEnumerable<Book>> GetAll();
		Task<Book> Get(Guid id);
	}
}
