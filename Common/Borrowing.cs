﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public struct Borrowing
    {
        public string BorrowedDate { get; set; }
        public string UserID { get; set; }
        public Copy copy { get; set; }
        public Book book { get; set; }
    }
}