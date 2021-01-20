using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Core.Entities
{
    public class EditorPublisher
    {
        public int Id { get; set; }
        public Editor Editor { get; set; }
        public Publisher Publisher { get; set; }
    }
}
