using System;
using System.Linq;
using System.Web;

namespace AlternativePayments
{
    public abstract class BaseFilter
    {
        public BaseFilter()
        {
        }

        public virtual string GetQueryString()
        {
            var properties = from p in this.GetType().GetProperties()
                             where p.GetValue(this, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(GetStringValue(p.GetValue(this, null)));

            return String.Join("&", properties.ToArray());
        }

        private string GetStringValue(object obj)
        {
            if (obj.GetType() == typeof(DateTime))
            {
                return ((DateTime)obj).ToUniversalTime().ToString("o");
            }

            return obj.ToString();
        }
    }
}
