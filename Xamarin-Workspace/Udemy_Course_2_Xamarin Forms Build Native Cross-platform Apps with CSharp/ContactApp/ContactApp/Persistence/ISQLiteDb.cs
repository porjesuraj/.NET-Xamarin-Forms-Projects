﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Persistence
{
   public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
