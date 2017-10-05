using System;

namespace AlternativePayments
{
    public class CommonFilter : BaseFilter
    {
        public CommonFilter()
        {
        }

        public CommonFilter WithOffset(int offset)
        {
            Offset = offset;
            return this;
        }

        public CommonFilter WithLimit(int limit)
        {
            Limit = limit;
            return this;
        }

        public CommonFilter WithStartDate(DateTime startDate)
        {
            StartDate = startDate;
            return this;
        }

        public CommonFilter WithEndDate(DateTime endDate)
        {
            EndDate = endDate;
            return this;
        }

        public int? Offset { get; set; }
        public int? Limit { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
