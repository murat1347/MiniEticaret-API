using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEticaret.Application.RequestParameters
{
    public record Pagination
    {
        public int Page { get; set; } = 5;
        public int Size { get; set; } = 0;
    }
}
