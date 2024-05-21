
namespace Professional
{
    public class SubjectManager
    {
        private List<Subject> subjectList;

        public SubjectManager()
        {
            subjectList = new List<Subject>();
        }

        public void AddSubject(int id, string name, string description, Training training)
        {
            Subject newSubject = new Subject(id, name, description, training);
            subjectList.Add(newSubject);
            Console.WriteLine("The subject added successfully");
        }

        public void ViewAllSubjects()
        {
            if (subjectList.Count == 0)
            {
                Console.WriteLine("No subjects available");
            }
            else
            {
                Console.WriteLine("All subjects");
                foreach (var subject in subjectList)
                {
                    Console.WriteLine($"ID: {subject.Id}, Name: {subject.Name}, Description: {subject.Description}, Training: {subject.Training}");
                }

            }
        }

        public void ViewSubjetcById(int id)
        {
            Subject toViewSubject = subjectList.Find(subject => subject.Id == id);
            if(toViewSubject != null)
            {
                Console.WriteLine($"ID: {toViewSubject.Id}, Name: {toViewSubject.Name}, Description: {toViewSubject.Description}, Training: {toViewSubject.Training}");
            }
            else
            {
                Console.WriteLine("Subject not found");
            }
        }

        public void UpdateSubject(int id, string newName, string newDescription, Training newTraining)
        {
            Subject toViewSubject = subjectList.Find(subject => subject.Id == id);
            if( toViewSubject != null)
            {
                toViewSubject.Name = newName;
                toViewSubject.Description = newDescription;
                toViewSubject.Training = newTraining;
            }
            else
            {
                Console.WriteLine("Subject not found");
            }
        }

        public void deleteSubject(int id)
        {
            Subject toDeleteSubject = subjectList.Find(subjectList => subjectList.Id == id);
            if(toDeleteSubject != null)
            {
                subjectList.Remove(toDeleteSubject);
                Console.WriteLine("The subject is deleted successfully");
            }
            else
            {
                Console.WriteLine("Subject not found");
            }
        }
    }
}