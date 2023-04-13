using Andreichuk_153505_lab1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Andreichuk_153505_lab1.Services
{
    public interface IDbService
    {
        IEnumerable<Author> GetAllAuthors();
        IEnumerable<Songs> GetAuthorsSongs(int id);
        void Init();
    }
}
