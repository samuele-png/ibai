namespace Domain_Layer.Interfaces
{
    interface ISetUserLevel
    {
        void SetAsSeller();
        void SetAsPremiumSeller();
        void SetAsAdmin();
        void SetAsStandard();
        void SetAsPremium();
    }
}
