using System.Collections.Generic;

namespace SF.App.Models.ViewModels
{
    public class ReportFamilyIncomeViewModel {
        public bool IsVoucherRequested {get; set; }
        public IEnumerable<IncomeLevel> IncomeLevels { get;set; }
        public int SelectedIncomeLevel { get; set; }

        public ReportFamilyIncomeViewModel()
        {
            this.IsVoucherRequested = false;
            this.IncomeLevels = new List<IncomeLevel>{
                new IncomeLevel {Id = 10, Level = IncomeLevelType.AboveThen3500, Text = "Oświadczam, że średni dochód brutto* na osobę w moim gospodarstwie domowym wynosi więcej niż 3500 zł,"},
                new IncomeLevel {Id = 11, Level = IncomeLevelType.BelowThen2000, Text = "Oświadczam, że średni dochód brutto* na osobę w moim gospodarstwie domowym wynosi mniej niż 3500 zł, ale więcej niż 2000 zł,"},
                new IncomeLevel {Id = 12, Level = IncomeLevelType.Between3500And2000, Text = "Oświadczam, że średni dochód brutto* na osobę w moim gospodarstwie domowym wynosi poniżej 2000 zł,"}
            };
        }
    }

    public class IncomeLevel {
        public int Id { get; set; }
        public IncomeLevelType Level { get; set;}
        public string Text { get; set; }
    }

    public enum IncomeLevelType {
        AboveThen3500,
        Between3500And2000,
        BelowThen2000
    }
}