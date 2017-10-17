using System;

namespace WebApplication1.Models
{
    public class PersonRecord
    {
        public PersonRecord(int sn, int id, string name, decimal weight, decimal height, DateTime date, string note) {
            RecordSn = sn;
            PersonId = id;
			Name = name;
            Weight = weight;
            Height = height;
            RecordDate = date;
            Note = note;
        }

        int RecordSn;

        public int PersonId;

		public string Name;

        public decimal? Weight;

        public decimal? Height;

		public DateTime RecordDate;

        public string Note;
    }
}