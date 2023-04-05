using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Homework
{
    class UserException : Exception
    {
        public int Value { get; set; }
        public UserException() { }
        public UserException(string message, int Value) : base(message)
        {
            this.Value = Value;
        }

    }
}
