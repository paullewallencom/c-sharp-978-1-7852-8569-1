namespace Packt.LearningCS
{
    public class BankAccount
    {
        public string AccountName;
        public decimal Balance;
        public static decimal InterestRate;
        public void Withdraw(decimal amount)
        {
            if (Balance < 0M)
            {
                throw new BankAccountException("Balance cannot be less than zero!");
            }
            else
            {
                Balance -= amount;
            }
        }
    }
}
