using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public struct TimeInterval
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeInterval (DateTime start, DateTime end)
        {
            if (!CheckInterval(start, end))
                throw new Exception("Invalid time interval");
            Start = start;
            End = end;
        }
        private static bool CheckInterval(DateTime start, DateTime end)
        {
            return start<end;
        }
        public TimeSpan GetTimeSpan()
        {
            return End - Start;
        }
        public override string ToString()
        {
            return string.Format("Start of event is {0}, end of event is {1}", Start, End);
        }
        public static bool operator ==(TimeInterval first, TimeInterval second)
        {
            return first.Start == second.Start && first.End == second.End;
        }
        public static bool operator !=(TimeInterval first, TimeInterval second)
        {
            return first.Start != second.Start || first.End != second.End;
        }
        public override bool Equals(object obj)
        {
            if (obj ==null)
                return false;
            if (obj.GetType() != typeof (TimeInterval))
                return false;
            return (TimeInterval)obj == this;
        }
        public override int GetHashCode()
        {
            int result = 17;
            result = 37 * result + (int)(Start.ToBinary() - (Start.ToBinary() >> 32));
            result = 37 * result + (int)(End.ToBinary() - (End.ToBinary()>> 32));
            return result;
            
        }
    }
}
