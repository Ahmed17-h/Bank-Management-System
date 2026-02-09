namespace Session2_assign
{
    public class SavingsAccount : Account
    {
        public decimal InterestRate;

        public SavingsAccount(decimal bal, decimal rate) : base(bal)
        {
            InterestRate = rate;
        }

        public override decimal MonthlyInterest()
        {
            return Balance * InterestRate / 12;
        }
    }

}
