﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using TileOrderSample.Model;

namespace TileOrderSample.Services
{
    [Export(typeof(ITileService))]
    public class TileService : ITileService
    {

        #region Fields

        private readonly Random _rng = new Random();

        #endregion

        #region Methods

        public IEnumerable<ITile> GetTileCollection(int max = 9)
        {
            return Enumerable.Range(1, max).Select(i => new Tile(i));
        }


        public bool IsOrdered(IList<ITile> tiles)
        {
            return tiles.Select(t => t.Number).SequenceEqual(Enumerable.Range(1, tiles.Count));
        }

        public void Reset(IList<ITile> tiles)
        {
            int n = tiles.Count;
            while (n > 1)
            {
                n--;
                int k = _rng.Next(n + 1);
                ITile value = tiles[k];
                tiles[k] = tiles[n];
                tiles[n] = value;
            }
        }

        public void Swap(IList<ITile> tiles, ITile first, ITile second)
        {
            int firstIndex = tiles.IndexOf(first);
            int secondIndex = tiles.IndexOf(second);
            if (firstIndex == -1 || secondIndex == -1)
                return;
            tiles[firstIndex] = second;
            tiles[secondIndex] = first;
        }

        #endregion

    }
}
