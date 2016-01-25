namespace CommonInterface
{
    public class MenuItem
    {
        public string Name;
        public string RelaxUrl;
        public string VsemenuUrl;

        public MenuItem(string name,string relaxUrl, string vsemenuUrl)
        {
            RelaxUrl = relaxUrl;
            VsemenuUrl = vsemenuUrl;
            Name = name;
        }

        public MenuItem(string name, string vsemenuUrl)
        {
            Name = name;
            VsemenuUrl = vsemenuUrl;
        }
    }
}
