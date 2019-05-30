﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kompression.LempelZiv.Occurrence.Models
{
    [DebuggerDisplay("Length: {Length}")]
    class SuffixTreeNode
    {
        public SuffixTreeNode[] Children { get; } = new SuffixTreeNode[256];

        public SuffixTreeNode SuffixLink { get; set; }

        public int Start { get; set; }
        public IntValue End { get; set; }

        public int SuffixIndex { get; set; } = -1;

        public bool IsRoot => Start == -1 && End.Value == -1;

        public bool IsLeaf => SuffixIndex >= 0;

        public int Length => End.Value - Start + 1;

        // Path label is the combination of values from start to end inclusive of this node

        public SuffixTreeNode(int start, IntValue end, SuffixTreeNode link)
        {
            SuffixLink = link;
            Start = start;
            End = end;
        }
    }
}