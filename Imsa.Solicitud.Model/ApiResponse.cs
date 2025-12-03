using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imsa.Solicitud.Model
{
    public class ApiResponse<T>
    {
        public int Status { get; set; }  // 0 = éxito, otros = error
        public string Message { get; set; }
        public T? Response { get; set; }
    }
}
