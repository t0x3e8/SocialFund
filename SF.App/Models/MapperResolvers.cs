using AutoMapper;
using SF.App.Models.Data;
using SF.App.Models.ViewModels;

namespace SF.App.Models {
    internal class ReportTypeResolver : IValueResolver<Report, ReportIndexViewModel, string>
    {
        string IValueResolver<Report, ReportIndexViewModel, string>.Resolve(Report source, ReportIndexViewModel destination, string destMember, ResolutionContext context)
        {
            string resultText = "__MissingReportName__";

            switch(source.Type) {
                case ReportType.FamilyIncome :
                    resultText = "Oświadczenie o dochodach rodziny";
                    break;
                case ReportType.MissingProfileInfo :
                    resultText = "Zmiana danych użytkownika";
                    break;
                default :
                    break;
            }

            return resultText;
        }
    }
}