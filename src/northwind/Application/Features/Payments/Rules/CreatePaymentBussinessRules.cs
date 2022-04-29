using Core.CrossCuttingConserns.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Payments.Rules
{
    public class CreatePaymentBussinessRules
    {


        public void CheckExpirationDate(string expDate)

        {try
            {
                DateTime date = DateTime.ParseExact(expDate, "MMyy", CultureInfo.InvariantCulture);
                DateTime dt = DateTime.Now;
                if (!(date.Year >= dt.Year && date.Month >= dt.Month))

                    throw new BusinessException("Son Kullanma Tarihi geçersiz");

            }
            catch (Exception ex)
            {
                throw new BusinessException("Hatalı tarih formatı");
            }

        }
    }
}
