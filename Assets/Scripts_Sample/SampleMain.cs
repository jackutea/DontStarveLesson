using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStarve.Sample {

    public class SampleMain : MonoBehaviour {

        DelegateSample delegateSample;
        UISample uiSample;

        void Start() {

            delegateSample = new DelegateSample();
            delegateSample.Enter();

            uiSample = new UISample();
            uiSample.Ctor();

        }

        void Update() {

            delegateSample.Tick();

        }

    }
}
