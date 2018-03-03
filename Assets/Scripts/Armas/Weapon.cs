using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private BaseBullet _bullet;

    [SerializeField]
    private float _cooldown;

    private float _lastTimeShot;

    private Transform _bulletSpawnPoint;
    private ParticleSystem _particles;

    public bool IsEmpty
    {
        get
        {
            return _ammo != -1 && _ammo <= 0;
        }
    }

    public bool CanShoot
    {
        get
        {
            return Time.time - _lastTimeShot > _cooldown || _lastTimeShot == 0;
        }
    }

    [SerializeField]
    // "Cantidad de balas que va a tener el arma. Usar -1 si el arma no se gasta nunca."
    [Tooltip("Cantidad de balas que va a tener el arma. Usar -1 si el arma no se gasta nunca.")]
    private int _ammo;

    private void Awake()
    {
        _bulletSpawnPoint = transform.Find("BulletSpawnPoint");
        Debug.Assert(_bulletSpawnPoint != null, "Weapon prefab missing BulletSpawnPoint child.", gameObject);

        _particles = transform.Find("Particles").GetComponent<ParticleSystem>();
        Debug.Assert(_particles != null, "Weapon prefab missing Particles child.", gameObject);
    }

    public void Shoot()
    {
        if (!CanShoot)
        {
            Debug.Log("Weapon in cooldown state.", gameObject);
            return;
        }

        if (_ammo == 0)
        {
            Debug.LogError("Trying to fire a weapon with no ammo. Should have switched to the default weapon!", gameObject);
            return;
        }

        _particles.Play();
        BaseBullet newBullet = Instantiate(_bullet, _bulletSpawnPoint.position, Quaternion.identity, null);
        newBullet.transform.right = _bulletSpawnPoint.transform.right;

        newBullet.OnShot();

        if (_ammo != -1)
            _ammo--;

        _lastTimeShot = Time.time;
    }
}
