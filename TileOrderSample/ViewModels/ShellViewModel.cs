namespace TileOrderSample.ViewModels
{
    using Caliburn.Micro;
    using System.ComponentModel.Composition;
    using Services;
    using Model;

    [Export(typeof(IShell))]
    public class ShellViewModel : PropertyChangedBase, IShell
    {

        #region Fields

        private ITileService _tileService;
        private ITile _selectedTile;
        private BindableCollection<ITile> _tiles;
        private bool _isOrdered;

        #endregion

        #region Constructor

        /// <remarks>
        /// Here we inject the ITileService via the constructor.
        /// </remarks>
        [ImportingConstructor]
        public ShellViewModel(ITileService tileService)
        {
            _tileService = tileService;
        }

        #endregion

        #region Properties

        public BindableCollection<ITile> Tiles
        {
            get
            {
                if (_tiles == null)
                {
                    _tiles = new BindableCollection<ITile>(TileViewModel.GetTileCollection());
                    _tileService.Reset(_tiles);
                    CheckIfTilesAreOrdered();
                }
                return _tiles;
            }
        }

        public bool IsOrdered
        {
            get
            {
                return _isOrdered;
            }
            set
            {
                _isOrdered = value;
                NotifyOfPropertyChange(() => IsOrdered);
            }
        }

        #endregion

        #region Methods

        public void ResetCommand()
        {
            if (_selectedTile != null)
            {
                _selectedTile.IsChecked = false;
                _selectedTile = null;
            }
            _tileService.Reset(Tiles);
            CheckIfTilesAreOrdered();
        }

        public void PressCommand(ITile tile)
        {
            if (_selectedTile == null)
                _selectedTile = tile;
            else
            {
                _tileService.Swap(Tiles, tile, _selectedTile);
                tile.IsChecked = false;
                _selectedTile.IsChecked = false;
                _selectedTile = null;
                CheckIfTilesAreOrdered();
            }
        }

        private void CheckIfTilesAreOrdered()
        {
            IsOrdered = _tileService.IsOrdered(Tiles);
        }

        #endregion

    }
}
