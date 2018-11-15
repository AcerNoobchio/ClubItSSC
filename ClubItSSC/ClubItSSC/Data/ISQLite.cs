using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClubItSSC.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}


