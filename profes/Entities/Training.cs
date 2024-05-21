
namespace Professional

{
    public class Training
    {
        public int Id 
        {
            get;
            set;
        }
        public string Name 
        {
            get;
            set;
        }
        public string Description 
        {
            get;
            set;
        }

        public Training (int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

    }
}
