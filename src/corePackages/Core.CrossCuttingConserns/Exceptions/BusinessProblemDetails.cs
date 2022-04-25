using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core.CrossCuttingConserns.Exceptions
{
    public partial class BusinessException
    {
        public class BusinessProblemDetails : ProblemDetails
        {
            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }
        }
    }
}
