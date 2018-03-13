using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBullet : BaseBullet
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private int _damage;
    OrbitadorBala ob;
    public float tiempoActivarOrbiador;

    private void Awake()
    {
        ob = GetComponent<OrbitadorBala>();
        ob.enabled = false;
        Invoke("ActivadoOrbitador", tiempoActivarOrbiador);
    }
    public override void OnShot(int shooter)
    {
        base.OnShot(shooter);
        GetComponent<Rigidbody2D>().velocity = transform.right * _speed;
    }

    protected override void ApplyEffectOnPlayer(GameObject player)
    {
        base.ApplyEffectOnPlayer(player);
        player.GetComponent<Vida>().Damage(_damage);
    }

    void ActivadoOrbitador()
    {
        ob.enabled = true;
    }
}
