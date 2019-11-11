using System;

namespace NicaSource.Models
{
    public class BookModel
    {
        public const int IndexFirst = 1;

        public BookModel()
        {
            this.Last = 0;
        }

        public bool DisablePrev()
        {
            return this.Num == IndexFirst;
        }
        public bool DisableNext()
        {
            return this.Num == this.Last;
        }
        public string Month { get; set; }
        public int Num { get; set; }
        public string Link { get; set; }
        public string Year { get; set; }
        public string News { get; set; }
        public string Transcript { get; set; }
        public string Alt { get; set; }
        public string Img { get; set; }
        public string Title { get; set; }
        public string Day { get; set; }
        public int First
        {
            get
            {
                return BookModel.IndexFirst;
            }
        }
        public int Prev()
        {

            int _prev;

            if (this.Num > BookModel.IndexFirst)
                _prev = (this.Num - 1);
            else _prev = 0;
            return _prev;
        }
        public int Next()
        {
            int _next;
            if (this.Num < this.Last)
                _next = (this.Num + 1);
            else _next = this.Last;
            return _next;
        }
        public int Last { get; set; }

    }
}
