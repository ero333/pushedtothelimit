using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private BaseBullet _bullet;

    private Transform _bulletSpawnPoint;
    private ParticleSystem _particles;

    private void Awake()
    {
        _bulletSpawnPoint = transform.Find("BulletSpawnPoint");
        Debug.Assert(_bulletSpawnPoint != null, "Weapon prefab missing BulletSpawnPoint child.", gameObject);

        _particles = transform.Find("Partices").GetComponent<ParticleSystem>();
        Debug.Assert(_particles != null, "Weapon prefab missing Particles child.", gameObject);
    }

    public void Shoot()
    {
        _particles.Play();
        BaseBullet newBullet = Instantiate(_bullet, _bulletSpawnPoint.position, Quaternion.identity, null);
        newBullet.transform.right = _bulletSpawnPoint.transform.right;

        newBullet.OnShot();
    }
}
