

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter 
{
    public float maxTime;
    private float counter;
    public Counter(float maxTime, bool startFull = false){
        this.maxTime = maxTime;
        this.counter = 0.0f;
        if (startFull)
        {
            this.counter = maxTime;
        }
    }

    public void incriment(){
        counter += Time.deltaTime;
    }

    public void reset(bool resetHigh = false){
        if (resetHigh){ counter = maxTime; }
        else { counter = 0.0f; }
    }

    public bool isOver(){
        if (counter >= maxTime){
            reset();
            return true;
        }
        return false;
    }

    public float currentCount(){
        return counter;
    }
}