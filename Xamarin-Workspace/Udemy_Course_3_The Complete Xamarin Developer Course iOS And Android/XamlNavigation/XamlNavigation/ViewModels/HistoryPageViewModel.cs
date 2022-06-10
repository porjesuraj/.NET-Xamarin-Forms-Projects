using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using XamlNavigation.Models;
using Prism.Navigation;
using XamlNavigation.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Services;
using System.Threading.Tasks;

namespace XamlNavigation.ViewModels
{
    public class HistoryPageViewModel : ViewModelBase, IPageLifecycleAware
    {
        private Post selectedPost;

        public Post SelectedPost { get => selectedPost; set => SetProperty(ref selectedPost, value); }


        private bool isRefresh;
        public bool IsRefresh
        {
            get { return isRefresh; }
            set { SetProperty(ref isRefresh, value); }
        }
        public ObservableCollection<Post> ListSource { get; set; } = new ObservableCollection<Post>();

        public DelegateCommand<Post> PostSelectedCommand { get; }
        public DelegateCommand<Post> DeletePostCommand { get; }
         
        public DelegateCommand RefreshCommand { get; }

        public INavigationService _navigationService;
        public IPageDialogService _pageDialogService { get; }
        public ISQLService _sqlService { get; private set; }

        public HistoryPageViewModel(INavigationService navigationService, ISQLService SQLService, IPageDialogService pageDialogService) :base(navigationService)
        {
            _navigationService = navigationService;

            PostSelectedCommand = new DelegateCommand<Post>(ExecutePostSelected);

          //  DeletePostCommand = new DelegateCommand<Post>(DeletingPost);

            DeletePostCommand = new DelegateCommand<Post>( DeleteExecutedAsync);

            RefreshCommand = new DelegateCommand(RefreshList);

            _sqlService = SQLService;

            _pageDialogService = pageDialogService;



        }

        private async void DeleteExecutedAsync(Post obj)
        {
            int row = await Post.DeleteUserPost(obj);





            if (row > 0)
            {
                await _pageDialogService.DisplayAlertAsync("Success", "Experience Deleted", "OK");
               await LoadList();
            }
            else
                await _pageDialogService.DisplayAlertAsync("Failure", "Experience Not Deleted", "OK");
        }

      

       

        private async void RefreshList()
        {
           await LoadList();
            IsRefresh = false;
        }

        private void ExecutePostSelected(Post obj)
        {
            if (obj == null)
                return;

           

            
            var par = new NavigationParameters
            {
                {"post", obj}
            };

            obj = null;
            _navigationService.NavigateAsync("PostDetailPage",par);
            
        }
        public async  void OnAppearing()
        {

         await   LoadList();
        
        }


        public async Task<bool> LoadList()
        {
            try
            {
                var posts = await Post.LoadUserPost();
                if (posts != null)
                {
                    ListSource.Clear();

                    foreach (var p in posts)
                        ListSource.Add(p);
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }

           
        }


        /*public void OnAppearing()
        {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();

                var posts = conn.Table<Post>().ToList();

                ListSource = posts;
            }
        }*/

        public void OnDisappearing()
        {
            
        }

   
    }
}
