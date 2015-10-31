using Caliburn.Micro;
using System.Collections.Generic;
using System.Linq;
using TileOrderSample.Model;

namespace TileOrderSample.ViewModels
{

    public class TileViewModel : PropertyChangedBase, ITile
    {

        #region Fields

        private bool _isChecked;

        #endregion

        #region Constructor

        public TileViewModel(int number)
        {
            Number = number;
        }

        #endregion

        #region Properties

        public int Number
        {
            get;
            private set;
        }

        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                _isChecked = value;
                NotifyOfPropertyChange(() => IsChecked);
            }
        }

        #endregion

        #region Methods

        public static IEnumerable<TileViewModel> GetTileCollection(int max = 9)
        {
            return Enumerable.Range(1, max).Select(i => new TileViewModel(i));
        }

        #endregion

    }

}
