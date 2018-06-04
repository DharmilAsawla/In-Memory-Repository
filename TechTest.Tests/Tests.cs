
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Interview
{
    [TestFixture]
    public class Tests
    {
        private Repository<Storeable> repository;
        private Storeable anExistingItem;
        private Storeable newItemToBeSaved;
        private object expected;
        private Storeable item1;
        private Storeable item2;
        private Storeable item3;

        private void CreateNewRepository()
        {
            repository = new Repository<Storeable>();
        }

        [Test]
        public void Should_Return_IEnumarable_Of_Correct_Type()
        {
            CreateNewRepository();
            expected = repository.All();
            Assert.IsInstanceOf<IEnumerable<Storeable>>(expected);
        }


        [Test]
        public void Should_Save_New_Item()
        {
            CreateNewRepository();
            newItemToBeSaved = new Storeable { Id = 1, Name = "ItemToBeSaved" };
            repository.Save(newItemToBeSaved);
            expected = repository.All();
            Assert.IsTrue(((IEnumerable<Storeable>)expected).Contains(newItemToBeSaved));
        }

        [Test]
        public void Should_Delete_An_Existing_Item()
        {
            CreateNewRepository();
            anExistingItem = new Storeable { Id = 1, Name = "AnExistingItemToBeDeleted" };

            repository.Save(anExistingItem);
            repository.Delete(1);
            expected = repository.All();

            Assert.IsFalse(((IEnumerable<Storeable>)expected).Contains(anExistingItem));
        }

        [Test]
        public void Should_Return_Correct_Item_By_Id()
        {
            CreateNewRepository();

            item1 = new Storeable { Id = 1, Name = "Item1" };
            item2 = new Storeable { Id = 2, Name = "Item2" };
            item3 = new Storeable { Id = 3, Name = "Item3" };

            repository.Save(item1);
            repository.Save(item2);
            repository.Save(item3);

            expected = repository.FindById(2);

            Assert.AreEqual(item2, expected);

        }
    }
}
