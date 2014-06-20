namespace LightSwitchApplication
{
    public partial class Producers
    {
        partial void GoogleMap_Execute()
        {
            // Write your code here.
            string url = Producers1.SelectedItem.GoogleMaps;
            ClientUtility.Instance.OpenWebPage(url);
        }
    }
}