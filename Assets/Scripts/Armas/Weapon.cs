using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private BaseBullet _bullet;

    public string nombre;

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

    private void Start()
    {
        if (GetComponentInParent<WeaponController>() != null){
            WeaponController wp = GetComponentInParent<WeaponController>();
            Collider2D col = GetComponent<Collider2D>();
            Destroy(wp.weapon);
            wp.weapon = gameObject;
            Destroy(col);
        }
    }

    //[Berdy] Agrego el shooter para identificar el PlayerName que dispara y evitar un autodisparo (bug de disparo sobre planeta con Pusher Gun)
    //[Berdy] Tener en cuenta que solo sirve para comparar, si la comparacion no se hace se puede permitir el autodisparo (ej. Bala orbital)
    public void Shoot(int shooter)
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

	//[Berdy] Nuevo llamado a OnShoot pasandole el shooter
		newBullet.OnShot(shooter);
		//

        if (_ammo != -1)
            _ammo--;

        _lastTimeShot = Time.time;
    }
}
