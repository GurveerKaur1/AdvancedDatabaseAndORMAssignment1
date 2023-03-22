using AdvancedDatabaseAndORMAssignment1.Models;
using Microsoft.EntityFrameworkCore;
namespace AdvancedDatabaseAndORMAssignment1.Data
{
    public static class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            AdvancedDatabaseAndORMAssignment1Context context = new AdvancedDatabaseAndORMAssignment1Context(serviceProvider.GetRequiredService<DbContextOptions<AdvancedDatabaseAndORMAssignment1Context>>());
            context.Database.EnsureDeleted();
            context.Database.Migrate();
            Album AlbumOne = new Album("MooseTape");
            Album AlbumTwo = new Album("Facts");
            Album AlbumThree = new Album("Moon Child");
            Album AlbumFour = new Album("G.O.A.T");
            Album AlbumFive = new Album("No Need");
            Album AlbumSix = new Album("Dark Circle");
            if (!context.Album.Any())
            {
                context.Album.Add(AlbumOne);
                context.Album.Add(AlbumTwo);
                context.Album.Add(AlbumThree);
                context.Album.Add(AlbumFour);
                context.Album.Add(AlbumFive);
                context.Album.Add(AlbumSix);
            }

            await context.SaveChangesAsync();

            Artist ArtistOne = new Artist("SidhuMooseWala");
            Artist ArtistTwo = new Artist("Diljeet");
            Artist ArtistThree = new Artist("Karan Aujla");

            if (!context.Artist.Any())
            {
                context.Artist.Add(ArtistOne);
                context.Artist.Add(ArtistTwo);
                context.Artist.Add(ArtistThree);
            }
            //context.SaveChanges();
             await context.SaveChangesAsync();

            Song DarkLove = new Song("Dark Love", 240, AlbumOne.Id, 1);
            Song SongTwo = new Song("295", 240, AlbumOne.Id, 2);
            Song Need = new Song("No Need", 360, AlbumFive.Id, 3);
            Song Yarrian = new Song("Yarrian", 280, AlbumSix.Id, 4);
            Song Ahead = new Song("Way Ahead", 120, AlbumFive.Id, 5);
            Song Rim = new Song("Rim", 150, AlbumSix.Id, 6);
            Song Look = new Song("Don't Look", 120, AlbumSix.Id, 7);
            Song Circle = new Song("Circle", 240, AlbumFive.Id, 8);
            Song Bapu = new Song("Bapu", 240, AlbumTwo.Id, 9);
            Song Skool = new Song("Old Skool", 120, AlbumOne.Id, 10);
            Song Bambiha = new Song("Bambiha", 180, AlbumTwo.Id, 11);
            Song Dhakka = new Song("Dhakka", 136, AlbumTwo.Id, 12);
            Song Chilli = new Song("Red Chilli", 120, AlbumThree.Id, 13);
            Song Surma = new Song("Surma", 145, AlbumThree.Id, 14);
            Song Mood = new Song("Mood", 136, AlbumFour.Id, 15);
            Song Peepa = new Song("Peepa", 240, AlbumFour.Id, 16);
            Song Gedi = new Song("Raat Di gedi", 167, AlbumThree.Id, 17);
            Song GOAT = new Song("G.O.A.T", 124, AlbumFour.Id, 18);
            Song Lemonade = new Song("Lemonade", 136, AlbumThree.Id, 19);
            Song Shine = new Song("Born to Shine", 124, AlbumOne.Id, 20);
 

            if (!context.Song.Any())
            {
                context.Song.Add(DarkLove);
                context.Song.Add(SongTwo);
                context.Song.Add(Need);
                context.Song.Add(Shine);
                context.Song.Add(Mood);
                context.Song.Add(Peepa);
                context.Song.Add(Gedi);
                context.Song.Add(GOAT);
                context.Song.Add(Lemonade);
                context.Song.Add(Yarrian);
                context.Song.Add(Ahead);
                context.Song.Add(Look);
                context.Song.Add(Rim);
                context.Song.Add(Circle);
                context.Song.Add(Bapu);
                context.Song.Add(Skool);
                context.Song.Add(Bambiha);
                context.Song.Add(Dhakka);
                context.Song.Add(Chilli);
                context.Song.Add(Surma);

            }
          await  context.SaveChangesAsync();

            SongContributor ContribuitorOne = new SongContributor();
            ContribuitorOne.ArtistId= ArtistOne.Id;
            ContribuitorOne.SongId = DarkLove.Id;
            SongContributor ContributorTwo = new SongContributor();
            ContributorTwo.ArtistId = ArtistTwo.Id;
            ContributorTwo.SongId = SongTwo.Id;
            SongContributor ContributorThree = new SongContributor();
            ContributorThree.ArtistId = ArtistThree.Id;
            ContributorThree.SongId = Need.Id;
            SongContributor ContributorFour = new SongContributor();
            ContributorFour.ArtistId = ArtistThree.Id;
            ContributorFour.SongId = Yarrian.Id;
            SongContributor ContributorFive = new SongContributor();
            ContributorFive.ArtistId = ArtistThree.Id;
            ContributorFive.SongId = Ahead.Id;
            SongContributor ContributorSix = new SongContributor();
            ContributorSix.ArtistId = ArtistThree.Id;
            ContributorSix.SongId = Rim.Id;
            SongContributor ContributorSeven = new SongContributor(ArtistThree.Id, Look.Id);
            SongContributor ContributorEight = new SongContributor(ArtistThree.Id, Circle.Id);
            SongContributor ContributorNine = new SongContributor(ArtistOne.Id, Bapu.Id);
            SongContributor ContributorTen = new SongContributor(ArtistOne.Id, Skool.Id);
            SongContributor ContributorEleven = new SongContributor(ArtistOne.Id, Bambiha.Id);
            SongContributor ContributorTwelve = new SongContributor(ArtistOne.Id, Dhakka.Id);
            SongContributor ContributorThirteen = new SongContributor(ArtistTwo.Id, Chilli.Id);
            SongContributor ContributorForteen = new SongContributor(ArtistTwo.Id, Surma.Id);
            SongContributor ContributorFifteen = new SongContributor(ArtistTwo.Id, Mood.Id);
            SongContributor ContributorSixteen = new SongContributor(ArtistTwo.Id, Peepa.Id);
            SongContributor ContributorSeventeen = new SongContributor(ArtistTwo.Id, Gedi.Id);
            SongContributor ContributorEighteen = new SongContributor(ArtistTwo.Id, GOAT.Id);
            SongContributor ContributorNinteen = new SongContributor(ArtistTwo.Id, Lemonade.Id);
            SongContributor ContributorTwentey = new SongContributor(ArtistOne.Id, Shine.Id);

            if (!context.SongContributor.Any())
            {
                context.SongContributor.Add(ContributorTwo);
                context.SongContributor.Add(ContribuitorOne);
                context.SongContributor.Add(ContributorThree);
                context.SongContributor.Add(ContributorFour);
                context.SongContributor.Add(ContributorFive);
                context.SongContributor.Add(ContributorSix);
                context.SongContributor.Add(ContributorSeven);
                context.SongContributor.Add(ContributorEight);
                context.SongContributor.Add(ContributorNine);
                context.SongContributor.Add(ContributorTen);
                context.SongContributor.Add(ContributorEleven);
                context.SongContributor.Add(ContributorTwelve);
                context.SongContributor.Add(ContributorThirteen);
                context.SongContributor.Add(ContributorForteen);
                context.SongContributor.Add(ContributorFifteen);
                context.SongContributor.Add(ContributorSixteen);
                context.SongContributor.Add(ContributorSeventeen);
                context.SongContributor.Add(ContributorEighteen);
                context.SongContributor.Add(ContributorNinteen);
                context.SongContributor.Add(ContributorTwentey);
            }
            // context.SaveChanges();
            await context.SaveChangesAsync();

            PlayList PlayListOne = new PlayList("Favourite");
            PlayList PlayListTwo = new PlayList("Random");
            PlayList PlayListThree = new PlayList("Liked");

            if(!context.PlayList.Any())
            {
                context.PlayList.Add(PlayListOne);
                context.PlayList.Add(PlayListTwo);
                context.PlayList.Add(PlayListThree);
            }
            // context.SaveChanges();
            await context.SaveChangesAsync();

            PlayListSong playListSongOne = new PlayListSong(PlayListOne.Id, SongTwo.Id, new DateTime(2015, 12, 20));
            PlayListSong playListSongTwo = new PlayListSong(PlayListOne.Id, DarkLove.Id, new DateTime(2015, 12, 21));
            PlayListSong playListSongThree = new PlayListSong(PlayListOne.Id, Need.Id, new DateTime(2015, 11, 20));
            PlayListSong playListSongFour = new PlayListSong(PlayListTwo.Id, Bambiha.Id, new DateTime(2015, 10, 12));
            PlayListSong playListSongFive = new PlayListSong(PlayListTwo.Id, Bapu.Id, new DateTime(2016, 1, 2));
            PlayListSong playListSongSix = new PlayListSong(PlayListTwo.Id, Dhakka.Id, new DateTime(2016, 3, 4));
            PlayListSong playListSongSeven = new PlayListSong(PlayListThree.Id, Chilli.Id, new DateTime(2017, 8, 9));
            PlayListSong playListSongEight = new PlayListSong(PlayListThree.Id, Mood.Id, new DateTime(2018, 10, 19));
            PlayListSong playListSongNine = new PlayListSong(PlayListThree.Id, Skool.Id, new DateTime(2019, 12, 20));
            if (!context.PlayListSong.Any())
            {
                context.PlayListSong.Add(playListSongOne);
                context.PlayListSong.Add(playListSongTwo);
                context.PlayListSong.Add(playListSongThree);
                context.PlayListSong.Add(playListSongFour);
                context.PlayListSong.Add(playListSongFive);
                context.PlayListSong.Add(playListSongSix);
                context.PlayListSong.Add(playListSongSeven);
                context.PlayListSong.Add(playListSongEight);
                context.PlayListSong.Add(playListSongNine);
            }
            await context.SaveChangesAsync();

            Podcast podcastOne = new Podcast("The Daily");
            Podcast podcastTwo = new Podcast("Code Switch");
            Podcast podcastThree = new Podcast("Reply All");
            Podcast podcastFour = new Podcast("Home Coming");

            if (!context.Podcasts.Any())
            {
                context.Podcasts.Add(podcastOne);
                context.Podcasts.Add(podcastTwo);
                context.Podcasts.Add(podcastThree);
                context.Podcasts.Add(podcastFour);
            }

            await context.SaveChangesAsync();

            Episodes episodesOne = new Episodes("First", 2300, new DateTime(2015, 12, 20), podcastOne.Id);
            Episodes episodesTwo = new Episodes("Second", 2700, new DateTime(2016, 8, 19), podcastOne.Id);
            Episodes episodesThree = new Episodes("Third", 2800, new DateTime(2015, 12, 17), podcastOne.Id);
            Episodes episodesFour = new Episodes("Fourth", 3400, new DateTime(2015, 07, 23), podcastTwo.Id);
            Episodes episodesFive = new Episodes("Fifth", 5600, new DateTime(2015, 06, 20), podcastTwo.Id);
            Episodes episodesSix = new Episodes("Sixth", 3900, new DateTime(2015, 04, 12), podcastTwo.Id);
            Episodes episodesSeven = new Episodes("Seven", 40000, new DateTime(2015, 03, 20), podcastThree.Id);
            Episodes episodesEight = new Episodes("Eigth", 7800,new DateTime(2015, 02, 7), podcastThree.Id);
            Episodes episodesNine = new Episodes("Nine", 3000, new DateTime(2015, 01, 20), podcastThree.Id);
            Episodes episodesTen = new Episodes("Tenth", 6789, new DateTime(2015, 05, 30), podcastFour.Id);
            Episodes episodesEleven = new Episodes("Eleventh", 4599,new DateTime(2015, 09, 20), podcastFour.Id);
            Episodes episodesTweleve = new Episodes("Tweleveth", 8000, new DateTime(2015, 10, 27), podcastFour.Id);

            if (!context.Episodes.Any())
            {
                context.Add(episodesOne);
                context.Add(episodesTwo);
                context.Add(episodesThree);
                context.Add(episodesFour);
                context.Add(episodesFive);
                context.Add(episodesSix);
                context.Add(episodesSeven);
                context.Add(episodesEight);
                context.Add(episodesNine);
                context.Add(episodesTen);
                context.Add(episodesEleven);
                context.Add(episodesTweleve);
            }

            await context.SaveChangesAsync();

            ListenerLists listenerOne = new ListenerLists("ListFirst");
            ListenerLists listenerTwo = new ListenerLists("ListTwo");
            ListenerLists listenerThree = new ListenerLists("ListThree");
            if(!context.ListenerLists.Any())
            {
                context.Add(listenerOne);
                context.Add(listenerTwo);
                context.Add(listenerThree);
                
            }
            await context.SaveChangesAsync();

            PodcastListener podcastListenerOne = new PodcastListener(podcastOne.Id, listenerOne.Id);
            PodcastListener podcastListenerTwo = new PodcastListener(podcastTwo.Id, listenerOne.Id);
            PodcastListener podcastListenerThree = new PodcastListener(podcastThree.Id, listenerTwo.Id);

            if(!context.PodcastListeners.Any())
            {
                context.Add(podcastListenerOne);
                context.Add(podcastListenerTwo);
                context.Add(podcastListenerThree);
            }

            await context.SaveChangesAsync();

        }
    }
}
