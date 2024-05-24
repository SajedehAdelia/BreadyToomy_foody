using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using BreadyToomy_Foody.Models;

namespace BreadyToomy_Foody.ViewModels
{
	public class RecipeManagementViewModel : INotifyPropertyChanged
    {
		private ObservableCollection<Recipe> _recipes;
		private Recipe _selectedRecipe;

        public ObservableCollection<Recipe> Recipes
		{
			get => _recipes;
			set
			{
				_recipes = value;
				OnPropertyChanged();
			}
		}

        public Recipe SelectedRecipe
        {
            get => _selectedRecipe;
            set
            {
                _selectedRecipe = value;
                OnPropertyChanged();
            }
        }

        public void AddRecipe(Recipe recipe)
        {
            Recipes.Add(recipe);
        }

        public void UpdateRecipe(Recipe recipe)
        {
            var existingRecipe = Recipes.FirstOrDefault(r => r.Id == recipe.Id);
            if (existingRecipe != null)
            {
                existingRecipe.Difficulty = recipe.Difficulty;
                existingRecipe.CookTime = recipe.CookTime;
                existingRecipe.Archived = recipe.Archived;
                OnPropertyChanged(nameof(Recipes));
            }
        }

        public void DeleteRecipe(Recipe recipe)
        {
            Recipes.Remove(recipe);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public RecipeManagementViewModel()
		{
            Recipes = new ObservableCollection<Recipe>
            {
                //DATA
            };
		}
	}
}

