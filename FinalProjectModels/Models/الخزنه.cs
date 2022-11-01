using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDB.Models
{
    public class الخزنه
    {
        [Key]
        public int رقم_المسلسل { get; set; }
        public string الحركه { get; set; }
        public DateTime التاريخ { get; set; }
        public double وارد { get; set; }
        public double منصرف { get; set; }
        public double رصيد { get; set; }
        public double الحساب { get; set; }

        //public virtual بيع بيع { get; set; }
        //public virtual البضاعه البضاعه { get; set; }

    }
}
