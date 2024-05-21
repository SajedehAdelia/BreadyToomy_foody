
namespace Professional
{
    public class TrainingManager
    {
        private List<Training> trainingList;

        public TrainingManager()
        {
            trainingList = new List<Training>();
        }

        public void AddTraining(int id, string name, string description)
        {
            Training newTraining = new Training(id, name, description);
            trainingList.Add(newTraining);
            Console.WriteLine("The training is added successfully");
        }

        public void ViewAllTrainings()
        {
            if ( trainingList.Count == 0 ){
                 Console.WriteLine("No trainings available.");
            }
            else
            {
                Console.WriteLine("All trainings:");
                foreach (var training in trainingList)
                {
                    Console.WriteLine($"ID: {training.Id}, Name: {training.Name}, Description: {training.Description}");
                }
            }

        }

        public void ViewTrainingById(int id)
        {
           Training toViewTraining = trainingList.Find(training => training.Id == id);
           if(toViewTraining != null)
           {
            Console.WriteLine($"ID: {toViewTraining.Id}, Name: {toViewTraining.Name}, Description: {toViewTraining.Description}");
           }
           else
            {
                Console.WriteLine("Training not found");
            }
        }

        public void UpdateTraining(int id, string newName, string newDescription)
        {
            Training toUpdateTraining = trainingList.Find(training => training.Id == id);
            if(toUpdateTraining != null )
            {
                toUpdateTraining.Name = newName;
                toUpdateTraining.Description = newDescription;
                Console.WriteLine("The training is updated successfully");
            }
            else
            {
                Console.WriteLine("Training not found");
            }
        }

        public void DeleteTraining(int id)
        {
            Training toDeleteTraining = trainingList.Find(training => training.Id ==id);
            if(toDeleteTraining != null )
            {
                trainingList.Remove(toDeleteTraining);
                Console.WriteLine("The training is deleted successfully");
            }
            else
            {
                 Console.WriteLine("Training not found");
            }
        }
    }

}

