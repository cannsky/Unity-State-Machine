using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial.StateMachine.State
{
    public abstract class State
    {
        public Enemy enemy;

        public abstract State HandleState();

    }
}