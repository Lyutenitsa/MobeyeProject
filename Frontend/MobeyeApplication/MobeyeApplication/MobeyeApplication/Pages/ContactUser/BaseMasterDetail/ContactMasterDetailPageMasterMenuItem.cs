using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobeyeApplication.Pages.ContactUser.BaseMasterDetail
{

    public class ContactMasterDetailPageMasterMenuItem
    {
        public ContactMasterDetailPageMasterMenuItem()
        {
            TargetType = typeof(ContactMasterDetailPageMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Type TargetType { get; set; }
    }
}