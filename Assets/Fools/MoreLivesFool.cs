using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreLivesFool : NormalFool
{
    [SerializeField]
    private int maxLives;

    private int currentLives;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        currentLives = maxLives;
    }

    protected override void ReactToClick() {
        MinusLife();
        if(currentLives == 0) {
            currentLives = maxLives;
            base.ReactToClick();
        }
    }

    protected virtual void MinusLife() {
        currentLives--;
    }
}
