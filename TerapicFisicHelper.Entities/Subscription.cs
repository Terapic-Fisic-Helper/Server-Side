using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerapicFisicHelper.Entities
{
    public class Subscription
    {
        public int CustomerId { get; set; }
        public int SubscriptionPlanId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime StartDate { get; set; }
        public SubscriptionPlan SubscriptionPlan { get; set; }
        public Customer Customer { get; set; }
    }
}
