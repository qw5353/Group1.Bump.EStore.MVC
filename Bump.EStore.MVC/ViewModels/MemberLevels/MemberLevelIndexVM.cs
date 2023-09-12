using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels.MemberLevels
{
    public class MemberLevelIndexVM
    {
        public int Id { get; set; }
        
        [Display(Name = "會員等級")]
        public int LevelOrder { get; set; }

        [Display(Name = "等級名稱")]
        public string Name { get; set; }

        
        [Display(Name = "升級總金額")]
        public int UpgradePrice { get; set; }

        
        [Display(Name = "升級總訂單數")]
        public int UpgradeOrderCount { get; set; }

        
        [Display(Name = "等級效期")]
        public int TimePeriod { get; set; }

        
        [Display(Name = "會員點數利率")]
        public decimal GainPointRate { get; set; }
        
        [Display(Name = "描述")]
        public string Description { get; set; }
    }

    public static class MemberLavelExt
    {
        public static MemberLevelIndexVM ToMemberLevelIndexVM(this MemberLevel entity)
        {
            return new MemberLevelIndexVM
            {
                Id = entity.Id,
                LevelOrder = entity.LevelOrder,
                Name = entity.Name,
                UpgradePrice = entity.UpgradePrice,
                UpgradeOrderCount = entity.UpgradeOrderCount,
                TimePeriod = entity.TimePeriod,
                GainPointRate = entity.GainPointRate,
                Description = entity.Description,
            };
        }
    }
}