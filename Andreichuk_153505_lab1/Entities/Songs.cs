using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreichuk_153505_lab1.Entities
{
    [Table("Songs")]
    public class Songs
    {
        [PrimaryKey, AutoIncrement, Indexed]
        [Column("Id")]
        public int SongId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        [Indexed]
        public int AuthorId { get; set; }
    }
}
