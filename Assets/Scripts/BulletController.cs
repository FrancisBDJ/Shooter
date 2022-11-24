using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameController gameController;

    private void OnCollisionEnter(Collision obj)
    {
        gameController.TargetHit(obj.gameObject);
    }
}
