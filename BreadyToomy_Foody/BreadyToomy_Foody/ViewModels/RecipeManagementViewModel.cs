using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BreadyToomy_Foody.Models;

namespace BreadyToomy_Foody.ViewModels
{
    public class RecipeManagementViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Recipe> _recipes;
        public ObservableCollection<Recipe> Recipes
        {
            get => _recipes;
            set
            {
                _recipes = value;
                OnPropertyChanged();
            }
        }

        private Recipe _selectedRecipe;
        public Recipe SelectedRecipe
        {
            get => _selectedRecipe;
            set
            {
                _selectedRecipe = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddRecipeCommand { get; }
        public ICommand UpdateRecipeCommand { get; }
        public ICommand DeleteRecipeCommand { get; }

        public RecipeManagementViewModel()
        {
            Recipes = new ObservableCollection<Recipe>();
            SelectedRecipe = new Recipe();

            AddRecipeCommand = new Command(AddRecipe);
            UpdateRecipeCommand = new Command(UpdateRecipe);
            DeleteRecipeCommand = new Command(DeleteRecipe);
        }

        private void AddRecipe()
        {
            if (SelectedRecipe != null)
            {
                Recipes.Add(new Recipe
                {
                    Id = SelectedRecipe.Id,
                    Difficulty = SelectedRecipe.Difficulty,
                    CookTime = SelectedRecipe.CookTime,
                    Archived = SelectedRecipe.Archived
                });

                SelectedRecipe = new Recipe();
                OnPropertyChanged(nameof(SelectedRecipe));
            }
        }

        private void UpdateRecipe()
        {
            var existingRecipe = Recipes.FirstOrDefault(r => r.Id == SelectedRecipe.Id);
            if (existingRecipe != null)
            {
                existingRecipe.Difficulty = SelectedRecipe.Difficulty;
                existingRecipe.CookTime = SelectedRecipe.CookTime;
                existingRecipe.Archived = SelectedRecipe.Archived;
                OnPropertyChanged(nameof(Recipes));
            }
        }

        private void DeleteRecipe()
        {
            var recipeToDelete = Recipes.FirstOrDefault(r => r.Id == SelectedRecipe.Id);
            if (recipeToDelete != null)
            {
                Recipes.Remove(recipeToDelete);
                SelectedRecipe = new Recipe();
                OnPropertyChanged(nameof(SelectedRecipe));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
