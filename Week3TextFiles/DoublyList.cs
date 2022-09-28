using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3TextFiles
{
    internal class DoublyList
    {
        //set properties of doubly linked list
        public string Result { get; set; }

        public bool IsHead { get; set; }

        public bool IsTail { get; set; }

        public DoublyList? Next { get; set; }

        public DoublyList? Previous { get; set; }

        public Rooms Room { get; set; }

        //create list
        public DoublyList(bool _isHead, bool _isTail, Rooms _room)
        {
            IsHead = _isHead;
            IsTail = _isTail;
            Room = _room;
        }
    }
}
