using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.EnterpriseTask
{
    public class Enterprise
    {
        //public readonly Guid guid;
        //public Guid Guid
        //{
        //    get
        //    {
        //        return guid;
        //    } 
        //    private set
        //    {
        //        this.Guid = guid;
        //    }
        //}
        public readonly Guid Guid;

        public Enterprise(Guid guid)
        {
            this.Guid = guid;
        }
        public string Name { get;set; }
        private readonly string inn;
        public string Inn
        {
            get { return inn; }
            set
            {
                if (inn.Length != 10 || !inn.All(z => char.IsDigit(z)))
                    throw new ArgumentException();
                this.Inn = inn;
            }
        }

        public DateTime EstablishDate { get; set; }
        private TimeSpan activeTimeSpan;
        public TimeSpan ActiveTimeSpan
        {
            get
            {
                return DateTime.Now - EstablishDate;
            }
        }

        public double GetTotalTransactionsAmount()
        {
            DataBase.OpenConnection();
            var amount = 0.0;
            foreach (Transaction t in DataBase.Transactions().Where(z => z.EnterpriseGuid == Guid))
                amount += t.Amount;
            return amount;
        }
    }
}
