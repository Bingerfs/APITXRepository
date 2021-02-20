using System;

namespace apiExercise
{
    public class Workshop
    {
        public int Id { get; set; }

        private string _status;

        public string Status 
        { 
            get
            {
                return _status;
            }
            set
            {
                _status = "";
                switch (value)
                {
                    case "Scheduled":
                        _status = value;
                        break;
                    case "Postponed":
                        _status = value;
                        break;
                    case "Cancelled":
                        _status = value;
                        break;
                }
            } 
         }

        public string Name { get; set; }

    }
}
