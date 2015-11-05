using System.Collections.Generic;
using TileOrderSample.Model;

namespace TileOrderSample.Services
{
    public interface ITileService
    {

        void Reset(IList<ITile> tiles);

        bool IsOrdered(IList<ITile> tiles);

        void Swap(IList<ITile> tiles, ITile first, ITile second);

        IEnumerable<ITile> GetTileCollection(int max = 9);

    }
}