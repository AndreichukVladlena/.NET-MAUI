using Andreichuk_153505_lab1.Entities;
using SQLite;

namespace Andreichuk_153505_lab1.Services
{
    public class SQLiteService : IDbService
    {
        public const string dbFilename = "lab3.db";

            SQLiteOpenFlags Flags =
    // open the database in read/write mode
    SQLite.SQLiteOpenFlags.ReadWrite |
    // create the database if it doesn't exist
    SQLite.SQLiteOpenFlags.Create |
     // enable multi-threaded database access
     SQLite.SQLiteOpenFlags.SharedCache;

        public static string dbPath => Path.Combine(FileSystem.AppDataDirectory, dbFilename);

        private SQLiteConnection _db;

        public IEnumerable<Author> GetAllAuthors()
        {
           return _db.Table<Author>().ToList();
        }
        public IEnumerable<Songs> GetAuthorsSongs(int id)
        {
            return _db.Table<Songs>().Where(t => t.AuthorId == id).ToList();
        }
        public void Init()
        {
            _db = new SQLiteConnection(dbPath, Flags);
            if (_db == null) return;

            _db.DropTable<Author>();
            _db.DropTable<Songs>();

            _db.CreateTable<Author>();

            _db.Insert(new Author() { Name = "Imagine Dragons", Age = 5 });
            _db.Insert(new Author() { Name = "djdsjliefoif", Age = 5 });
            _db.Insert(new Author() { Name = "uigui", Age = 78 });
            _db.Insert(new Author() { Name = "uooi", Age = 79 });

            _db.CreateTable<Songs>();

            _db.Insert(new Songs() { Name = "hudufdud", Duration = 5.45, AuthorId = 1 });
            _db.Insert(new Songs() { Name = "gd", Duration = 2.00, AuthorId = 1 });

            _db.Insert(new Songs() { Name = "okgkodf", Duration = 3.00, AuthorId = 2 });
            _db.Insert(new Songs() { Name = "jlkdfjlkdrf", Duration = 1.00, AuthorId = 2 });

            _db.Insert(new Songs() { Name = "jlkdff", Duration = 3.00, AuthorId = 3 });
            _db.Insert(new Songs() { Name = "fdggd", Duration = 1.55, AuthorId = 3 });
            _db.Insert(new Songs() { Name = "fdoko", Duration = 1.50, AuthorId = 3 });
            _db.Insert(new Songs() { Name = "fd", Duration = 1.25, AuthorId = 3 });

            _db.Insert(new Songs() { Name = "kj", Duration = 6.55, AuthorId = 4 });
            _db.Insert(new Songs() { Name = "hugiu", Duration = 3.55, AuthorId = 4 });
            _db.Insert(new Songs() { Name = "kjkkk", Duration = 2.00, AuthorId = 4 });
            _db.Insert(new Songs() { Name = "vvvvvvv", Duration = 3.55, AuthorId = 4 });
        }
    }
}
