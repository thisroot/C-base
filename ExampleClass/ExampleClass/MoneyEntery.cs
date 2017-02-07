using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleClass
{
    class MoneyEntery
    {
        private double _amount;
        /// <summary>
        /// Стандартный конструктор
        /// </summary>

        public MoneyEntery()
        {
            _amount = 0;
            EnteryDate = DateTime.Now;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="amount">Сумма записи</param>
        /// <param name="data">Дата записи</param>
        public MoneyEntery(double amount, DateTime data)
        {
            _amount = amount;
            EnteryDate = data;
        }

        /// <summary>
        /// Инициализация объекта строками
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="date"></param>
        public void InitWithString(string amount, string date)
        {
            Double.TryParse(amount, out _amount);
            DateTime dt;
            DateTime.TryParse(date, out dt);
        }

        public override string ToString()
        {
            return string.Format("{0} от {1}", _amount, EnteryDate.Date);
        }


        /// <summary>
        /// Определяет является ли запись доходом
        /// </summary>
        public bool IsDebit
        {
            get { return (_amount >= 0); }
            set { if(value && _amount < 0) _amount = -_amount;}
        }

        /// <summary>
        /// Сумма записи
        /// </summary>
        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        /// <summary>
        /// Дата записи
        /// </summary>
        public DateTime EnteryDate { get; set; }
    }
}
