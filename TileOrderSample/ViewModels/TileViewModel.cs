using System;
using Caliburn.Micro;
using TileOrderSample.Model;

namespace TileOrderSample.ViewModels
{

    public class TileViewModel : PropertyChangedBase, ITile
    {

        #region Fields

        private readonly ITile _tile;

        #endregion

        #region Constructor

        public TileViewModel(ITile tile)
        {
            if (tile == null)
                throw new ArgumentNullException(nameof(tile));
            _tile = tile;
        }

        #endregion

        #region Properties

        public int Number => _tile.Number;

        public bool IsChecked
        {
            get
            {
                return _tile.IsChecked;
            }
            set
            {
                if (_tile.IsChecked == value)
                    return;
                _tile.IsChecked = value;
                NotifyOfPropertyChange(() => IsChecked);
            }
        }

        #endregion

    }

}
