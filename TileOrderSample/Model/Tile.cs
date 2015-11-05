using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileOrderSample.Model
{
    public class Tile : ITile
    {
        public Tile(int number)
        {
            Number = number;
        }

        public int Number { get; }

        public bool IsChecked { get; set; }
    }
}
