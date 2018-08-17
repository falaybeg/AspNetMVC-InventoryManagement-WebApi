using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Domain
{
    public class Orders
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ConfirmDate { get; set; }
        public bool ConfirmStatus { get; set; }
        public string ShippingAddress { get; set; }

        public virtual Product Product { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUserr User { get; set; }


    }
}
