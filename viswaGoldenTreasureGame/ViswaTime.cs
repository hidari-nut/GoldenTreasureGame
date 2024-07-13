using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace viswaGoldenTreasureGame
{
    public class ViswaTime
    {
        #region DATA MEMBER
        private int hour;
        private int minute;
        private int second;
        #endregion
        #region CONSTRUCTOR

        public ViswaTime(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }
        #endregion
        #region PROPERTIES
        public int Hour
        {
            get => hour;
            set
            {
                if (value >= 0 && value < 24)
                {
                    hour = value;
                }
                else
                {
                    throw new Exception("Please enter hour in the range 0-23");
                }
            }
        }
        public int Minute
        {
            get => minute;
            set
            {
                if (value >= 0 && value < 60)
                {
                    minute = value;
                }
                else
                {
                    throw new Exception("Please enter minute in the range 0-59");
                }
            }
        }
        public int Second
        {
            get => second;
            set
            {
                if (value >= 0 && value < 60)
                {
                    second = value;
                }
                else
                {
                    throw new Exception("Please enter second in the range 0-59");
                }
            }
        }
        #endregion
        #region METHOD
        public int ConvertToSecond()
        {
            int totalSecond = Hour * 3600 + Minute * 60 + Second;
            return totalSecond;
        }
        public void AddSecond(int addedSecond)
        {
            int totalSecond = this.ConvertToSecond();
            int newTotalSecond = totalSecond + addedSecond;
            Hour = newTotalSecond / 3600;
            Minute = (newTotalSecond % 3600) / 60;
            Second = (newTotalSecond % 3600) % 60;
        }
        #endregion
    }
}
