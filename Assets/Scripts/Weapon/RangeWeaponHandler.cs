using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class RangeWeaponHandler : WeaponHandler
{
    [Header("Ranged Attack Data")]
    [SerializeField] private Transform projectileSpawnPosition;

    [SerializeField] private int bulletIndex;
    public float BulletInded { get { return bulletIndex; } }

    [SerializeField] private float bulletSize = 1;
    public float BulletOutded { get {return bulletIndex; } }

    [SerializeField] private float duration;
    public float Duration {  get { return duration; } }

    [SerializeField] private float spread;
    public float Spread { get { return spread; } }

    [SerializeField] private int numberOfProjectilePerShot;
    public int NumberOfProjectilePerShot { get { return numberOfProjectilePerShot; } }

    [SerializeField] private float multipleProjectilesAngle;
    public float MultipleProjectilesAngle { get { return multipleProjectilesAngle; } }

    [SerializeField] private Color projectileColor;
    public Color ProjectileColor { get { return projectileColor; } }

    public override void Attack()
    {
        base.Attack();

        float projectileAngleSpace = multipleProjectilesAngle;
        int numberOfProjectilesPerShot = numberOfProjectilePerShot;

        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectileAngleSpace;

        for(int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            float angle = minAngle + projectileAngleSpace * i;
            float randomSpread = Random.Range(-spread, spread);
            angle += randomSpread;
            CreateProjectile(Controller.LookDirection, angle);
        }
    }
    private void CreateProjectile(Vector2 _lookDirection, float angle)
    {

    }
    private static Vector2 RotateVector2(Vector2 v, float degree)
    {
        return Quaternion.Euler(0, 0, degree) * v;
    }
}
