using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using dataAccess.Interface;
using SQLite;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace dataAccess.DataPages
{
 
    public class Recipe :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        [PrimaryKey,AutoIncrement ]
        public int Id { get; set; }

        private string _name;

        [MaxLength(255)]
        public string Name
        {
            get { return _name; }


            set
            {
                if (_name == value)
                    return;

                _name = value;

                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
           /* if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
*/
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SQLitePage1 : ContentPage
    {
        private SQLiteAsyncConnection _connection;

        private ObservableCollection<Recipe> _recipeslist;
        public SQLitePage1()
        {
            InitializeComponent();


       
        }

        protected async override void OnAppearing()
        {
            _connection = DependencyService.Get<ISQLiteDB>().GetConnection();

           await _connection.CreateTableAsync<Recipe>();

           var recipes = await _connection.Table<Recipe>().ToListAsync();

            _recipeslist = new ObservableCollection<Recipe>(recipes);

            recipeList.ItemsSource = _recipeslist;

            base.OnAppearing();
        }

        private async void OnDelete(object sender, EventArgs e)
        {
            var recipe = _recipeslist[0];
            await _connection.DeleteAsync(recipe);

            _recipeslist.Remove(recipe);
        }

        private async void OnUpdate(object sender, EventArgs e)
        {
            var recipe = _recipeslist[0];

            recipe.Name += "Updated";

            await _connection.UpdateAsync(recipe);
            

        }

        private async void OnAdd(object sender, EventArgs e)
        {
            var recipe = new Recipe { Name = "Recipe" + DateTime.Now.Ticks };

            await _connection.InsertAsync(recipe);

            _recipeslist.Add(recipe);
        }
    }
}