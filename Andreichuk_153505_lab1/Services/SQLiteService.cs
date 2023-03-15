using Andreichuk_153505_lab1.Entities;
using SQLite;

namespace Andreichuk_153505_lab1.Services
{
    internal class SQLiteService : IDbService
    {
        static string dbPath;
        SQLiteConnection _db;
        IEnumerable<Author> _authors;
        IEnumerable<Songs> _songs;
        public IEnumerable<Author> GetAllAuthors()
        {
            _db.Table<Author>().Where(t => t.CourseId == id).ToList();
        }
        public IEnumerable<Songs> GetAuthorsSongs(int id)
        {
            //foreach (var songs in _songs)
            //{
            //    if (songs.AuthorId == id) yield return songs;
            //}
        }
        public void Init()
        {
            SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create;

            dbPath = Path.Combine(FileSystem.AppDataDirectory, "lab3.db");
            _db = new(dbPath);

            _db.CreateTable<Author>();
            _db.CreateTable<Songs>();

            _authors{

            };

        }
    }
}
