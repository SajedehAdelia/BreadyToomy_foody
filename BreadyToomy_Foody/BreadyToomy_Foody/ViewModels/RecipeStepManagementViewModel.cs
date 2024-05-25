using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
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

        public ICommand AddRecipeStepCommand { get; }
        public ICommand UpdateRecipeStepCommand { get; }
        public ICommand DeleteRecipeStepCommand { get; }

        public RecipeStepManagementViewModel()
        {
            RecipeSteps = new ObservableCollection<RecipeStep>();
            SelectedRecipeStep = new RecipeStep();

            AddRecipeStepCommand = new Command(AddRecipeStep);
            UpdateRecipeStepCommand = new Command(UpdateRecipeStep);
            DeleteRecipeStepCommand = new Command(DeleteRecipeStep);
        }

        private void AddRecipeStep()
        {
            if (SelectedRecipeStep != null)
            {
                RecipeSteps.Add(new RecipeStep
                {
                    Id = SelectedRecipeStep.Id,
                    RecipeId = SelectedRecipeStep.RecipeId,
                    Index = SelectedRecipeStep.Index,
                    StepDetails = SelectedRecipeStep.StepDetails,
                    Archived = SelectedRecipeStep.Archived
                });

                SelectedRecipeStep = new RecipeStep();
                OnPropertyChanged(nameof(SelectedRecipeStep));
            }
        }

        private void UpdateRecipeStep()
        {
            var existingRecipeStep = RecipeSteps.FirstOrDefault(rs => rs.Id == SelectedRecipeStep.Id);
            if (existingRecipeStep != null)
            {
                existingRecipeStep.RecipeId = SelectedRecipeStep.RecipeId;
                existingRecipeStep.Index = SelectedRecipeStep.Index;
                existingRecipeStep.StepDetails = SelectedRecipeStep.StepDetails;
                existingRecipeStep.Archived = SelectedRecipeStep.Archived;
                OnPropertyChanged(nameof(RecipeSteps));
            }
        }

        private void DeleteRecipeStep()
        {
            var recipeStepToDelete = RecipeSteps.FirstOrDefault(rs => rs.Id == SelectedRecipeStep.Id);
            if (recipeStepToDelete != null)
            {
                RecipeSteps.Remove(recipeStepToDelete);
                SelectedRecipeStep = new RecipeStep();
                OnPropertyChanged(nameof(SelectedRecipeStep));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
