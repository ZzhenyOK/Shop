using Shop.BLL.DTO;
using Shop.BLL.Services;
using Shop.UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Shop.UI.ViewModels
{
    public class MainViewModel : BaseNotifyPropertyChanged
    {
        #region private fields and properties
        private string loadingTextBlockVisibility = "hidden";
        private string datagridVisibility = "hidden";
        private CategoryService categoryService;
        private ObservableCollection<CategoryDTO> categories;
        private CategoryDTO selectedCategory;

        public CategoryDTO SelectedCategory
        {
            get => selectedCategory;
            set
            {
                selectedCategory = value;
                NotifyOfPropertyChanged();
            }
        }
        public ObservableCollection<CategoryDTO> Categories
        {
            get => categories;
            set
            {
                categories = value;
                NotifyOfPropertyChanged();
            }
        }
        public string LoadingTextBlockVisibility
        {
            get => loadingTextBlockVisibility;
            set
            {
                loadingTextBlockVisibility = value;
                NotifyOfPropertyChanged();
            }
        }
        public string DataGridVisibility
        {
            get => datagridVisibility;
            set
            {
                datagridVisibility = value;
                NotifyOfPropertyChanged();
            }
        }
        #endregion

        public MainViewModel(CategoryService categoryService)
        {
            this.categoryService = categoryService;
            LoadCategories();
            InitCommands();
        }

        #region public methods
        private async void LoadCategories()
        {
            DataGridVisibility = "Hidden";
            LoadingTextBlockVisibility = "Visible";
            var categories = await categoryService.GetAllAsync();
            Categories = new ObservableCollection<CategoryDTO>(categories);
            DataGridVisibility = "Visible";
            LoadingTextBlockVisibility = "Hidden";
        }
        private void InitCommands()
        {
            RemoveCategoryCommand = new RelayCommand(x =>
            {
                categoryService.Delete(SelectedCategory);
                Categories.Remove(SelectedCategory);
            });
            UpdateCategoryCommand = new RelayCommand(x =>
            {
                categoryService.Update(SelectedCategory);
            });
            CreateCategoryCommand = new RelayCommand(x =>
            {
                var categoryDTO = categoryService.Create(new CategoryDTO { Name = "Unknown"});
                Categories.Add(categoryDTO);
            });
        }
        #endregion

        #region commands

        public ICommand RemoveCategoryCommand { get; private set; }
        public ICommand UpdateCategoryCommand { get; private set; }
        public ICommand CreateCategoryCommand { get; private set; }

        #endregion
    }
}
