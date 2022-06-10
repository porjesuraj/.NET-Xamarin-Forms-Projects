using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace dataAccess.Interface
{
   public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}
