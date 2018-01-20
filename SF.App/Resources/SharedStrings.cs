namespace SF.App.Resources
{
    public static class SharedStrings
    {
        public static string IncomeLevelAboveThen3500 { get;} = "Oświadczam, że średni dochód brutto* na osobę w moim gospodarstwie domowym wynosi więcej niż 3500 zł,";
        public static string IncomeLevelBetween2000and3000 { get; } ="Oświadczam, że średni dochód brutto* na osobę w moim gospodarstwie domowym wynosi mniej niż 3500 zł, ale więcej niż 2000 zł,";
        public static string IncomeLevelBelowThen2000 { get; } = "Oświadczam, że średni dochód brutto* na osobę w moim gospodarstwie domowym wynosi poniżej 2000 zł,"; 
        public static string MissingIncomeLevelValidationError { get; } = "Brak zaznaczonego właściwego średniego dochodu brutto.";
    }
}