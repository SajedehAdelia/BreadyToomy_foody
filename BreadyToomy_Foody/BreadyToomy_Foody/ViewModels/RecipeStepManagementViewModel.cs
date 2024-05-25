using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using BreadyToomy_Foody.Models;

namespace BreadyToomy_Foody.ViewModels
{
    public class RecipeStepManagementViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<RecipeStep> _recipeSteps;
        public ObservableCollection<RecipeStep> RecipeSteps
        {
            get => _recipeSteps;
            set
            {
                _recipeSteps = value;
                OnPropertyChanged();
            }
        }

        private RecipeStep _selectedRecipeStep;
        public RecipeStep SelectedRecipeStep
        {
            get => _selectedRecipeStep;
            set
            {
                _selectedRecipeStep = value;
                OnPropertyChanged();
            }
        }

        public RecipeStepManagementViewModel()
        {
            RecipeSteps = new ObservableCollection<RecipeStep>
            {
                //just to check if it works :)  
                new RecipeStep { Id = 1, RecipeId = 1, Index = 0, StepDetails = "Preheat the oven to 200°C", Archived = false },
                new RecipeStep { Id = 2, RecipeId = 1, Index = 1, StepDetails = "Mix flour and water", Archived = false }
            };
        }

        public void AddRecipeStep(RecipeStep recipeStep)
        {
            RecipeSteps.Add(recipeStep);
        }

        public void UpdateRecipeStep(RecipeStep recipeStep)
        {
            var existingRecipeStep = RecipeSteps.FirstOrDefault(rs => rs.Id == recipeStep.Id);
            if (existingRecipeStep != null)
            {
                existingRecipeStep.RecipeId = recipeStep.RecipeId;
                existingRecipeStep.Index = recipeStep.Index;
                existingRecipeStep.StepDetails = recipeStep.StepDetails;
                existingRecipeStep.Archived = recipeStep.Archived;
                OnPropertyChanged(nameof(RecipeSteps));
            }
        }

        public void DeleteRecipeStep(RecipeStep recipeStep)
        {
            RecipeSteps.Remove(recipeStep);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
