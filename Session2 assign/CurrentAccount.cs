namespace Session2_assign
{
    public class CurrentAccount : Account
    {
        public decimal OverdraftLimit;

        public CurrentAccount(decimal bal, decimal limit) : base(bal)
        {
            OverdraftLimit = limit;
        }

        public override bool Withdraw(decimal amt)
        {
            if (amt > Balance + OverdraftLimit) return false;
            Balance -= amt;
            return true;
        }

        public override decimal MonthlyInterest()
        {
            return 0;
        }
    }

}
