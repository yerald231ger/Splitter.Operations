﻿using Microsoft.EntityFrameworkCore;
using Splitter.Operations.Infrastructure;
using Splitter.Operations.Models;

namespace Splitter.Operations.Data.SqlServer;

public class EventTableRepository(DbContext dbContext)
: Repository<EventTable, Guid>(dbContext), IEventTableRepository
{
}
