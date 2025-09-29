using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Day8.Events1;

namespace Day8
{
    internal class Button
    {
        public event ButtonClickHandler OnClick;
        public void Click()
        {
            Console.WriteLine("Button was clicked!");
            OnClick?.Invoke();
        }
    }
}
