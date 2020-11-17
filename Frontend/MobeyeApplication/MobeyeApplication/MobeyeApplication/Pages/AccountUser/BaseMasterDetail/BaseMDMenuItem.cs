using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobeyeApplication.Pages.AccountUser
{

    public class BaseMDMenuItem
    {
        public BaseMDMenuItem()
        {
            TargetType = typeof(BaseMDMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}