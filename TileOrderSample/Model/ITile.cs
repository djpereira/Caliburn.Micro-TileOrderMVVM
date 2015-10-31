namespace TileOrderSample.Model
{

    public interface ITile
    {
        int Number
        {
            get;
        }

        bool IsChecked
        {
            get; set;
        }
    }
}
