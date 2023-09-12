using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Dtos.Inventories
{
	public class InventoryProductStyleIndexDto
	{
		public int Id { get; set; }
		public string Style { get; set; }
		public int Inventory { get; set; }
		public int MinimumStock { get; set; }
	}
}
