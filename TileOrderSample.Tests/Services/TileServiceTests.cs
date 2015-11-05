using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TileOrderSample.Model;
using TileOrderSample.Services;

namespace TileOrderSample.Tests.Services
{
    [TestClass]
    public class TileServiceTests
    {

        [TestMethod]
        public void IsOrderedTrueTest()
        {
            // Arrange
            TileService service = new TileService();
            List<ITile> tiles = new List<ITile> {
                new Model.Fakes.StubITile { NumberGet =() => 1 },
                new Model.Fakes.StubITile { NumberGet =() => 2 },
                new Model.Fakes.StubITile { NumberGet =() => 3 },
                new Model.Fakes.StubITile { NumberGet =() => 4 },
                new Model.Fakes.StubITile { NumberGet =() => 5 },
                new Model.Fakes.StubITile { NumberGet =() => 6 },
                new Model.Fakes.StubITile { NumberGet =() => 7 },
                new Model.Fakes.StubITile { NumberGet =() => 8 },
                new Model.Fakes.StubITile { NumberGet =() => 9 },
            };

            // Act
            bool condition = service.IsOrdered(tiles);

            // Assert
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void IsOrderedFalseTest()
        {
            // Arrange
            TileService service = new TileService();
            List<ITile> tiles = new List<ITile> {
                new Model.Fakes.StubITile { NumberGet =() => 5 },
                new Model.Fakes.StubITile { NumberGet =() => 2 },
                new Model.Fakes.StubITile { NumberGet =() => 3 },
                new Model.Fakes.StubITile { NumberGet =() => 4 },
                new Model.Fakes.StubITile { NumberGet =() => 1 },
                new Model.Fakes.StubITile { NumberGet =() => 6 },
                new Model.Fakes.StubITile { NumberGet =() => 3 },
                new Model.Fakes.StubITile { NumberGet =() => 2 },
                new Model.Fakes.StubITile { NumberGet =() => 9 },
            };

            // Act
            bool condition = service.IsOrdered(tiles);

            // Assert
            Assert.IsFalse(condition);
        }

        [TestMethod]
        public void SwapTest()
        {

            // Arrange
            TileService service = new TileService();
            ITile tile3 = new Model.Fakes.StubITile { NumberGet = () => 3 };
            ITile tile7 = new Model.Fakes.StubITile { NumberGet = () => 7 };
            List<ITile> tiles = new List<ITile> {
                new Model.Fakes.StubITile { NumberGet =() => 1 },
                new Model.Fakes.StubITile { NumberGet =() => 2 },
                tile3,
                new Model.Fakes.StubITile { NumberGet =() => 4 },
                new Model.Fakes.StubITile { NumberGet =() => 5 },
                new Model.Fakes.StubITile { NumberGet =() => 6 },
                tile7,
                new Model.Fakes.StubITile { NumberGet =() => 8 },
                new Model.Fakes.StubITile { NumberGet =() => 9 },
            };
            int tile3Pos = tiles.IndexOf(tile3);
            int tile7Pos = tiles.IndexOf(tile7);

            // Act
            service.Swap(tiles, tile3, tile7);

            // Assert
            Assert.IsTrue(tiles[tile7Pos] == tile3);
            Assert.IsTrue(tiles[tile3Pos] == tile7);
        }
    }
}