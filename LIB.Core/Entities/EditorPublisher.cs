using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Core.Entities
{
    class EditorPublisher
    {
        public int EditorId { get; set; }
        public Editor Editor { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }
}
