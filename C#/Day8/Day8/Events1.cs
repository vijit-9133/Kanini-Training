using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    internal class Events1
    {
        public delegate void ButtonClickHandler();
        class Button
        {
            public event ButtonClickHandler OnClick;
            public void Click()
            {
                Console.WriteLine("Button was clicked!");
                OnClick?.Invoke();
            }
        }
    }
}
