﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorsApp.Domain.Models;
using AuthorsApp.Infrastructure;

namespace AuthorsApp.Domain.Remoting
{
	public interface IAuthorsAppRemoting : IRemotingBase
	{
		Task<IEnumerable<Author>> GetAll();
		Task<Author> Get(Guid id);
	}
}
