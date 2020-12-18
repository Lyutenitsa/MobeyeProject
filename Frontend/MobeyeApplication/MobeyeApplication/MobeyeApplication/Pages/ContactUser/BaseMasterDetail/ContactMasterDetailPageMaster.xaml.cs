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

namespace MobeyeApplication.Pages.ContactUser.BaseMasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public ContactMasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new ContactMasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class ContactMasterDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<ContactMasterDetailPageMasterMenuItem> MenuItems { get; set; }

            public ContactMasterDetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<ContactMasterDetailPageMasterMenuItem>(new[]
                {
                    new ContactMasterDetailPageMasterMenuItem { Id = 0, Title = "Dashboard" },
                    new ContactMasterDetailPageMasterMenuItem { Id = 1, Title = "Chat" },
                    new ContactMasterDetailPageMasterMenuItem { Id = 2, Title = "Settings" },
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