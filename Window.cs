using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9_P
{
    using System;
    class Window
    {
        public virtual void Draw()
        {
            Console.WriteLine("Drawing window");
        }
    }
    class ScrollingDecorator : Window
    {
        private readonly Window _decoratedWindow;

        public ScrollingDecorator(Window decoratedWindow)
        {
            _decoratedWindow = decoratedWindow;
        }

        public override void Draw()
        {
            _decoratedWindow.Draw();
            Console.WriteLine("Adding scrolling functionality");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Window simpleWindow = new Window();
            simpleWindow.Draw();
            Console.WriteLine();
            Window scrollingWindow = new ScrollingDecorator(simpleWindow);
            scrollingWindow.Draw();
        }
    }
}
