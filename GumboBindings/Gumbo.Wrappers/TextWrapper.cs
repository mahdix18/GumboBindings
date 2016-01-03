﻿using Gumbo.Bindings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Gumbo.Wrappers
{
    [DebuggerDisplay("Type = {Type}, Text = {Text}")]
    public class TextWrapper : NodeWrapper
    {
        public string Text { get; private set; }

        public GumboSourcePosition StartPosition { get; private set; }

        public override IEnumerable<NodeWrapper> Children => new List<NodeWrapper>().AsReadOnly();

        internal TextWrapper(GumboTextNode node, NodeWrapper parent)
            : base(node, parent)
        {
            Text = NativeUtf8Helper.StringFromNativeUtf8(node.text.text);
            StartPosition = node.text.start_pos;
        }

    }
}
