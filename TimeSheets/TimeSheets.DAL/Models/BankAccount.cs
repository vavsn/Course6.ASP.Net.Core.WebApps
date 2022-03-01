namespace TimeSheets.DAL.Models
{
    public class BankAccount
    {
        public Guid BankAccountId { get; private set; }

        public DateTime DateOfOpening { get; private set; }
        public double Amount { get; private set; }
        public bool IsClosed { get; private set; }
        private Guid BankAccountIdGenerate()
        {
            return Guid.NewGuid();
        }
        public BankAccount Create()
        {
            var ba = new BankAccount();
            ba.BankAccountId = BankAccountIdGenerate();
            ba.DateOfOpening = DateTime.Now;
            ba.Amount = 0;
            ba.IsClosed = false;
            return ba;
        }
        public BankAccount IncludeSheets(BankAccount ba)
        {
            var _ba = new BankAccount();
            _ba.BankAccountId = ba.BankAccountId;
            _ba.DateOfOpening = DateTime.Now;
            _ba.Amount += ba.Amount;
            _ba.IsClosed = false;
            return _ba;
        }
        public BankAccount Close(BankAccount ba)
        {
            var _ba = new BankAccount();
            _ba.BankAccountId = ba.BankAccountId;
            _ba.DateOfOpening = DateTime.Now;
            _ba.Amount = ba.Amount;
            _ba.IsClosed = true;

            return _ba;
        }
    }
}
