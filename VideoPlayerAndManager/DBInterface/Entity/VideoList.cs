
namespace DBInterface
{
    public class VideoList
    {
        public int ListID { get; set; }
        public string Name { get; set; }

        public VideoList(int i, string name)
        {
            this.ListID = i;
            this.Name = name;
        }

        public override bool Equals(object obj)
        {
            VideoList list = obj as VideoList;
            if (list == null) return false;
            return this.ListID == list.ListID && this.Name == list.Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
