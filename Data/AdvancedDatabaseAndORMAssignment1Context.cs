using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdvancedDatabaseAndORMAssignment1.Models;

namespace AdvancedDatabaseAndORMAssignment1.Data
{
    public class AdvancedDatabaseAndORMAssignment1Context : DbContext
    {
        public AdvancedDatabaseAndORMAssignment1Context (DbContextOptions<AdvancedDatabaseAndORMAssignment1Context> options)
            : base(options)
        {
        }

        public DbSet<Song> Song { get; set; } = default!;
        public DbSet<Album> Album { get; set; } = default!;
        public DbSet<Artist> Artist { get; set; } = default!;
        public DbSet<PlayList> PlayList { get; set; } = default!;
        public DbSet<PlayListSong> PlayListSong { get; set; } = default!;
        public DbSet<SongContributor> SongContributor { get; set; } = default!;




    }
}
