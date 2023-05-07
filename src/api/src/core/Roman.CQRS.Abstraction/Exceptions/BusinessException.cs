using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman.CQRS.Abstraction.Exceptions
{
    public class BusinessException : Exception
    {
        public IEnumerable<KeyValuePair<string, string>> ValidationErrors { get; protected set; }

        protected BusinessException()
            : base()
        {
            ValidationErrors = new List<KeyValuePair<string, string>>();
        }

        public BusinessException(string property, string errorMessage)
            : this()
        {
            ValidationErrors = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>(property, errorMessage) };
        }

        public BusinessException(IEnumerable<KeyValuePair<string, string>> errors)
            : this()
        {
            ValidationErrors = errors;
        }

        public BusinessException(params KeyValuePair<string, string>[] errors)
            : this()
        {
            ValidationErrors = errors;
        }
    }
}