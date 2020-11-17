using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobeyeApplication.Pages.AccountUser
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasePage1Master : ContentPage
    {
        public ListView ListView;

        public BasePage1Master()
        {
            InitializeComponent();

            BindingContext = new BasePage1MasterViewModel();
            ListView = MenuItemsListView;
        }

        class BasePage1MasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<BaseMDMenuItem> MenuItems { get; set; }

            public BasePage1MasterViewModel()
            {
                MenuItems = new ObservableCollection<BaseMDMenuItem>(new[]
                {
                    new BaseMDMenuItem { Id = 0, Title = "Home" },
                    new BaseMDMenuItem { Id = 1, Title = "Dashboard" },
                    new BaseMDMenuItem { Id = 2, Title = "Settings" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}