﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Repositories
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }

        DateTime UtcNow { get; }

        DateTimeOffset OffsetNow { get; }

        DateTimeOffset OffsetUtcNow { get; }
    }

}
