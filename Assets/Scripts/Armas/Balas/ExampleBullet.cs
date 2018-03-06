using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExampleBullet : BaseBullet
{
    private Weapon _weapon;

	public override void OnShot(int shooter)
    {
        Debug.Log("ExampleBullet disparada", gameObject);
    }

    protected override void ApplyEffectOnPlayer(GameObject player)
    {
        Destroy(player);
    }
}
