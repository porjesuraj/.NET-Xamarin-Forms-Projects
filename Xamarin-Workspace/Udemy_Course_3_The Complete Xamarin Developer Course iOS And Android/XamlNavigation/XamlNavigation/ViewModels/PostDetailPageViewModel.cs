using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using XamlNavigation.Models;

namespace XamlNavigation.ViewModels
{
    public class PostDetailPageViewModel : ViewModelBase
    {
        public Post post { get; set; } = new Post();

        
        public DelegateCommand UpdateCommand { get; }
        public DelegateCommand DeleteCommand { get; }

        public Services.ISQLService _sqlService { get; private set; }

        public IPageDialogService _pageDialogService { get; }

        public INavigationService _navigationService { get; }
        public PostDetailPageViewModel(INavigationService navigationService, Services.ISQLService sQLService, IPageDialogService pageDialogService):base(navigationService)
        {
            

          //  UpdateCommand = new DelegateCommand(UpdateExecuted);
            UpdateCommand = new DelegateCommand(async () => await UpdateExecutedAsync());
            DeleteCommand = new DelegateCommand(async () => await DeleteExecutedAsync());

            _sqlService = sQLService;

            _pageDialogService = pageDialogService;
            _navigationService = navigationService;

           


        }

        

        public async  Task DeleteExecutedAsync()
        {
       
            int row = await Post.DeleteUserPost(post);

      



            if (row > 0)
            {
                await _pageDialogService.DisplayAlertAsync("Success", "Experience Deleted", "OK");
                await _navigationService.GoBackAsync();
            }
            else
                await _pageDialogService.DisplayAlertAsync("Failure", "Experience Not Deleted", "OK");


           
        }

       public  async Task UpdateExecutedAsync()
        {
        
            int row =  await Post.UpdateUserPost(post);
        

            if (row > 0)
            {
                await _pageDialogService.DisplayAlertAsync("Success", "Experience Updated", "OK");
                await _navigationService.GoBackAsync();

            }else
            await _pageDialogService.DisplayAlertAsync("Failure", "Experience Not Updated", "OK");



           
        }





        private string _exp;
        public string Experience
        {
            get { return _exp; }
            set {
                if (_exp == value)
                    return;
                
                SetProperty(ref _exp, value);

                post.Experience = value;

                
            }
        }

       
        

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            post = parameters.GetValue<Post>("post");

            Experience = post.Experience; 
            
        }


    }
}
