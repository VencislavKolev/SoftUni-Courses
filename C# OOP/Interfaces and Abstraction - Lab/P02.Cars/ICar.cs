using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public interface ICar
    {
        public string Model { get; }
        public string Color { get; }
        public abstract string Start();
        //{
        //    return $"Engine start";
        //}
        public string Stop();
        //{
        //    return $"Breaaak!";
        //}
    }
}
