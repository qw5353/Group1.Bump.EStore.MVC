using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels.MemberLevels
{
    public class MemberLevelCreateVM
    {
        [Required]
        [Display(Name = "會員等級")]
        public int LevelOrder { get; set; }

        [Required]
        [Display(Name = "等級名稱")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "升級總金額")]
        public int UpgradePrice { get; set; }

        [Required]
        [Display(Name = "升級總訂單數")]
        public int UpgradeOrderCount { get; set; }

        [Required]
        [Display(Name = "等級效期")]
        public int TimePeriod { get; set; }

        [Required]
        [Display(Name = "會員點數利率")]
        public decimal GainPointRate { get; set; }
        [Required]
        [Display(Name = "描述")]
        public string Description { get; set; }
    }
    public static class MemberLevelCreateExt
    {
        public static MemberLevel ToMemberLevelCreateEntity(this MemberLevelCreateVM vm)
        {
            return new MemberLevel
            {
                LevelOrder = vm.LevelOrder,
                Name = vm.Name,
                UpgradePrice = vm.UpgradePrice,
                UpgradeOrderCount = vm.UpgradeOrderCount,
                TimePeriod = vm.TimePeriod,
                GainPointRate = vm.GainPointRate,
                Description = vm.Description
            };
        }
    }
}