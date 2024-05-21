
namespace Professional
{
    public class Subject
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
        public Training Training
        {
            get;
            set;
        }

        public Subject(int id, string name, string description, Training training)
        {
            Id = id;
            Name = name;
            Description = description;
            Training = training;
        }
    }
}