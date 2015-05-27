using System;

namespace Intranet.Home.Code
{
    public class Event
    {
        public Event(string title, DateTime eventDate, string path)
        {
            Title = title;
            EventDate = eventDate;
            Path = path;
        }

        public string Title { get; private set; }

        public DateTime EventDate { get; private set; }

        public string Path { get; private set; }
            
    }
}