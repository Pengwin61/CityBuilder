using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public interface IPoolCreator
    {
        public string Path { get; }
        public void CreateObj();
    }
}