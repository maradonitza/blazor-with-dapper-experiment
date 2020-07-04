using System;

namespace BlazorApp.Model
{
    public class Contest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string AdditionalInformation { get; set; }
    }

}
