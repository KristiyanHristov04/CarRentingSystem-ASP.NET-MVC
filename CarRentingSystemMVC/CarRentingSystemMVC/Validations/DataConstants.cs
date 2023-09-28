namespace CarRentingSystemMVC.Validations
{
    public static class DataConstants
    {
        public const int BrandMaxLength = 50;
        public const int BrandMinLength = 1;

        public const int ModelMaxLength = 50;
        public const int ModelMinLength = 1;

        public const int DesriptionMaxLength = 500;
        public const int DesriptionMinLength = 10;

        public const double PriceMax = 2000;
        public const double PriceMin = 50;
        public const double PriceDefault = 50;

        public const int IdentityUserNameMaxLength = 20;
        public const int IdentityUserNameMinLength = 4;

        public const int DaysMaxLength = 365;
        public const int DaysMinLength = 1;

        public const int CreditCardCVVMinLength = 3;
        public const int CreditCardCVVMaxLength = 3;

        public const int CVVMinValue = 100;
        public const int CVVMaxValue = 999;

        public const string CreditCardRegularExpression = @"[0-9]{4}\s[0-9]{4}\s[0-9]{4}";
        public const string CreditCardCVVRegularExpression = @"[0-9]{3}";
    }
}
