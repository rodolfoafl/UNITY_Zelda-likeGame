using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeldaTutorial.Objects{
    public class Pot : Breakable {

        Animator _animator;

        public Animator Animator
        {
            get
            {
                return _animator;
            }

            set
            {
                _animator = value;
            }
        }

        void Start()
        {
            _animator = GetComponent<Animator>();
        }
    }
}
