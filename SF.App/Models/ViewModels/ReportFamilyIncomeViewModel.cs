using System.Collections.Generic;
using SF.App.Resources;

namespace SF.App.Models.ViewModels
{
    public class ReportFamilyIncomeViewModel {
        public bool IsVoucherRequested {get; set; } = false;
        public IEnumerable<IncomeLevel> IncomeLevels { get;set; }
        public IncomeLevelType SelectedIncomeLevel { get; set; } = IncomeLevelType.None;

        public string ValidationErrorMessage { get; set; }
        public bool IsSuccess { get; set;} = false;

        public ReportFamilyIncomeViewModel()
        {
            this.IncomeLevels = new List<IncomeLevel>{
                new IncomeLevel { Level = IncomeLevelType.AboveThen3500, Text = SharedStrings.IncomeLevelAboveThen3500 },
                new IncomeLevel { Level = IncomeLevelType.Between3500And2000, Text = SharedStrings.IncomeLevelBetween2000and3000 },
                new IncomeLevel { Level = IncomeLevelType.BelowThen2000, Text = SharedStrings.IncomeLevelBelowThen2000 }
            };
        }
    }

    public class IncomeLevel {
        public IncomeLevelType Level { get; set;}
        public string Text { get; set; }
    }

    public enum IncomeLevelType : int {
        AboveThen3500 = 10,
        Between3500And2000 = 11,
        BelowThen2000 = 12,
        None = 0
    }
}