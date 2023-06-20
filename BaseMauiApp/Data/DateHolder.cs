namespace BaseMauiApp.Data
{
    public class DateHolder
    {
        private DateTime UTCDateTime;
        private DateTime LocalDateTime;
        public DateTime _TradeDate {get; private set;}
        TimeZoneInfo _localTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Tasmania Standard Time");
        public DateTime _UTCDateTime
        {
            get { return UTCDateTime; }
            set
            {
                UTCDateTime = value;
                UTCDateTime = DateTime.SpecifyKind(UTCDateTime, DateTimeKind.Utc);
                LocalDateTime = TimeZoneInfo.ConvertTime(UTCDateTime, _localTimeZoneInfo);
                LocalDateTime = DateTime.SpecifyKind(LocalDateTime, DateTimeKind.Local);
                _TradeDate = TimeZoneInfo.ConvertTime(LocalDateTime, _localTimeZoneInfo).AddHours(-6).Date;
            }
        }

        public DateTime _LocalDateTime
        {
            get { return LocalDateTime; } 
            set
            {
                LocalDateTime = value;
                LocalDateTime = DateTime.SpecifyKind(LocalDateTime, DateTimeKind.Local);
                UTCDateTime = LocalDateTime.ToUniversalTime();
                UTCDateTime = DateTime.SpecifyKind(UTCDateTime, DateTimeKind.Utc);
                _TradeDate = TimeZoneInfo.ConvertTime(LocalDateTime, _localTimeZoneInfo).AddHours(-6).Date;
            }
        }

        public DateHolder(DateTime utcDateTime)
        {

            if (utcDateTime.Kind != DateTimeKind.Utc)
            {
                throw new Exception("Date time is in incorrect format please set to utc");
            };
            _UTCDateTime = utcDateTime;
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, _localTimeZoneInfo);

            _LocalDateTime = DateTime.SpecifyKind(localTime, DateTimeKind.Local);
        }

        //public void GetLocalTime()
        //{
        //    var currentDateTime = _UTCDateTime;
        //    _LocalDateTime = TimeZoneInfo.ConvertTime(currentDateTime, _localTimeZoneInfo);
        //}

        //public void GetTradeDate()
        //{
        //    var currentDateTime = _UTCDateTime;
        //    _TradeDate = TimeZoneInfo.ConvertTime(currentDateTime, _localTimeZoneInfo).AddHours(-6).Date;
        //}

        //public void GetUTCTime()
        //{
        //    _UTCDateTime = _LocalDateTime.ToUniversalTime();
        //}
    }
}
