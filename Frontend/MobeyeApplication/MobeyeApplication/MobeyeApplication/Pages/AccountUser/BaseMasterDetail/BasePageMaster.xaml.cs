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

namespace MobeyeApplication.Pages.AccountUser.BaseMasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasePageMaster : ContentPage
    {
        public ListView ListView;

        public BasePageMaster()
        {
            InitializeComponent();

            BindingContext = new BasePageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class BasePageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<BasePageMasterMenuItem> MenuItems { get; set; }

            public BasePageMasterViewModel()
            {
                MenuItems = new ObservableCollection<BasePageMasterMenuItem>(new[]
                {
                    new BasePageMasterMenuItem { Id = 0, Title = "Dashboard" },
                    new BasePageMasterMenuItem { Id = 1, Title = "Account" },
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