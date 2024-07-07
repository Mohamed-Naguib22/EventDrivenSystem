using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSender.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(IEnumerable<string> errors) : base(string.Join(", ", errors))
        {
            Errors = errors.ToArray();
        }

        public string[] Errors { get; set; }
    }
}
