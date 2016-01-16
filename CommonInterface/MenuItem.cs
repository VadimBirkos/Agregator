namespace CommonInterface
{
    public class MenuItem
    {
        public string Name;
        public string Url;

        public MenuItem(string name,string url )
        {
            Url = url;
            Name = name;
        }

        public MenuItem(string name)
        {
            Name = name;
        }
    }
}
