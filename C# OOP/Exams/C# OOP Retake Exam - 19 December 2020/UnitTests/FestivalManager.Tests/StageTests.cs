// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class StageTests
    {
        private Stage myStage;
        private Performer myPerformer = new Performer("venci", "kolev", 22);
        private Song mySong = new Song("mySong", new TimeSpan(0, 2, 20));

        [SetUp]
        public void SetUp()
        {
            this.myStage = new Stage();
        }
        [Test]
        public void CtorShouldWorkCorrectly()
        {
            Stage stage = new Stage();
            Assert.IsNotNull(stage.Performers);
        }
        [Test]
        public void AddPerformerShouldThrowExceptionWhenNull()
        {
            Performer performer = null;

            Assert.That(() =>
            {
                this.myStage.AddPerformer(performer);
            }, Throws.Exception.InstanceOf<ArgumentNullException>());

        }
        [Test]
        public void AddPerformerShoulThrowExceptionWhenUnder18()
        {
            Performer performer = new Performer("venci", "kolev", 6);

            Assert.That(() =>
            {
                this.myStage.AddPerformer(performer);
            }, Throws.Exception.InstanceOf<ArgumentException>()
            .With.Message.EqualTo("You can only add performers that are at least 18."));
        }
        [Test]
        public void AddPerformerShouldWorkCorrecty()
        {

            Performer performer = new Performer("venci", "kolev", 20);
            this.myStage.AddPerformer(performer);

            Assert.AreEqual(1, myStage.Performers.Count);
        }


        //ADD SONG TESTS
        [Test]
        public void AddSongShouldThrowExceptionWhenNull()
        {
            Song song = null;

            Assert.That(() =>
            {
                this.myStage.AddSong(song);
            }, Throws.Exception.InstanceOf<ArgumentNullException>());
        }
        [Test]
        public void AddSongShoulThrowExceptionWhenUnder18()
        {
            Song song = new Song("SomeName", new TimeSpan(0, 0, 40));

            Assert.That(() =>
            {
                this.myStage.AddSong(song);
            }, Throws.Exception.InstanceOf<ArgumentException>()
            .With.Message.EqualTo("You can only add songs that are longer than 1 minute."));
        }
        [Test]
        public void AddSongShouldWorkCorrecty()
        {

            Song song = new Song("SomeName", new TimeSpan(0, 1, 40));
            this.myStage.AddSong(song);
        }


        [Test]
        public void AddSongToPerformerShouldWork()
        {
            this.myStage.AddPerformer(this.myPerformer);
            this.myStage.AddSong(this.mySong);

            var res = this.myStage.AddSongToPerformer(this.mySong.Name, this.myPerformer.FullName);
            var eRes = $"{mySong} will be performed by {myPerformer}";

            Assert.AreEqual(eRes, res);
        }

        [Test]
        public void AddSongToPerformerShouldWork2()
        {
            var eRes = $"{mySong} will be performed by {myPerformer}";
            this.myPerformer.SongList.Add(this.mySong);
            Assert.AreEqual(eRes, eRes);
        }
        [Test]
        public void PlayWork2()
        {
            var song1 = new Song("Ветрове", new TimeSpan(0, 3, 30));
            var performer = new Performer("Ivan", "Ivanov", 19);

            this.myStage.AddSong(song1);
            this.myStage.AddPerformer(performer);
            this.myStage.AddSongToPerformer(song1.Name, performer.FullName);


            var eRes = $"1 performers played 1 songs";
            var aRes = this.myStage.Play();
            Assert.AreEqual(eRes, aRes);
        }

        [Test]
        public void GetSongShouldThrowException()
        {
            this.myStage.AddPerformer(this.myPerformer);
            Assert.That(() =>
            {
                this.myStage.AddSongToPerformer(this.mySong.Name, this.myPerformer.FullName);
            }, Throws.Exception.InstanceOf<ArgumentException>()
            .With.Message.EqualTo("There is no song with this name."));
        }
        [Test]
        public void GetPerformerShouldThrowException()
        {
            this.myStage.AddSong(this.mySong);
            Assert.That(() =>
            {
                this.myStage.AddSongToPerformer(this.mySong.Name, this.myPerformer.FullName);
            }, Throws.Exception.InstanceOf<ArgumentException>()
            .With.Message.EqualTo("There is no performer with this name."));
        }
    }
}