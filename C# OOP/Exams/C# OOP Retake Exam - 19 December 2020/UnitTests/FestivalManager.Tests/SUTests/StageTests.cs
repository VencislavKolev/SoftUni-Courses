// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    //using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {
        readonly Song song1 = new Song("Ветрове", new System.TimeSpan(0, 3, 30));
        readonly Song shortSong = new Song("Бурни Нощи", new System.TimeSpan(0, 0, 30));
        readonly Performer performer1 = new Performer("Ivan", "Ivanov", 19);
        readonly Performer performer2 = new Performer("Ivan", "Ivanov2", 15);
        readonly Stage stage = new Stage();

		[Test]
	    public void TestAddSongs()
	    {
			Assert.DoesNotThrow(() => stage.AddSong(song1));
			Assert.Throws<ArgumentException>(() => stage.AddSong(shortSong));
			Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));

		}

		[Test]
		public void TestAddPerformers()
        {
            stage.AddPerformer(performer1);
            Assert.AreEqual(1, stage.Performers.Count());

            Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer2));
            Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
        }

        [Test]
        public void TestAddSongToPerformer()
        {
            var message = stage.AddSongToPerformer("Ветрове", "Ivan Ivanov");
            Assert.AreEqual("Ветрове (03:30) will be performed by Ivan Ivanov", message);

            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("s", "Ivan Ivanov"));
            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("Ветрове", "Ivan 2"));

            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer("Ветрове", null));
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, "Ivan Ivanov"));

        }

        [Test]
        public void Testplay()
        {
            var message = stage.Play();
            Assert.AreEqual("1 performers played 1 songs", message);
        }

        [Test]
        public void TestPerformersProperty()
        {
            Assert.IsInstanceOf(typeof(IReadOnlyCollection<Performer>), stage.Performers);
        }
	}
}