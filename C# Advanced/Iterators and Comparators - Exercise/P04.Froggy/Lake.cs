﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private readonly int[] stones;
        public Lake(params int[] stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Length; i+=2)
            {
                yield return this.stones[i];
            }
            for (int i = this.stones.Length - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return this.stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
