﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace MVVMExercise.Persistence
{
   public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();

    }
}
