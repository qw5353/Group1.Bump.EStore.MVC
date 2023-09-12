using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Specifications
{
    // 跨表格請避免使用, 沒考慮到別稱
	public class WhereBulider
	{
		private List<string> _whereClauses;

        public WhereBulider()
        {
            _whereClauses = new List<string>();
        }

        public WhereBulider AddFuzzyLike(string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
				_whereClauses.Add($"[{column}] LIKE '%{value}%'");
			}
            
            return this;
        }

        public WhereBulider AddEqual(string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
				_whereClauses.Add($"[{column}] = '{value}'");
			}
			
            return this;
		}

		public WhereBulider AddEqual(string column, int? value)
        {
            if (value.HasValue)
            {
				_whereClauses.Add($"[{column}] = {value}");
			}
			
            return this;
		}

		public string Build()
        {
            if (_whereClauses.Any())
            {
				return "WHERE " + string.Join("\nAND ", _whereClauses);
			}

            return string.Empty;
        }
	}
}
