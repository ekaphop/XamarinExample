using SQLite;

namespace XamarinExample.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}