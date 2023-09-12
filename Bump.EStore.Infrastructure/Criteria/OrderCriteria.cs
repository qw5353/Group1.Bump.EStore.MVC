using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bump.EStore.Infrastructure.Criteria
{
	public class OrderCriteria
	{
        public int? MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }
        public string MemberPhone { get; set; }
        public string RecipientName { get; set; }
        public string RecipientPhone { get; set; }
        public string RecipientAddress { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int? OrderId { get; set; }
        public string CreateTime { get; set; }
        public int? OrderStatus { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }


    }
}