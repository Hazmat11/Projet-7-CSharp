﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_7.src
{
    internal class Waiter
    {
        private bool _isPressed { get; set; }
        public Waiter()
        {
            _isPressed = false;

        }
        public void Wait()
        {

            do
            {
                ConsoleKeyInfo input = Console.ReadKey();
                if (input.Key == ConsoleKey.Enter) _isPressed = true;
            } while (!_isPressed);
        }
    }
}
