using System.Collections;
using UnityEngine;
public class Launcher : MonoBehaviour
{

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private SimulateProjectile projectile;
    [SerializeField] private Transform firePoint;
    [SerializeField] private PlayerInputHandler inputs;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float initialVelocity;
    //[SerializeField] private float time;

    public float velocity = 1;
    public float angle = 4;

    [SerializeField] private Vector3 initialPosition;


    private void Start()
    {
        gravity = Physics.gravity.y;


    }

    public void LaunchProjectile()
    {

        initialVelocity = CalculateInitialVelocity(velocity, angle);

        initialPosition = firePoint.position;

        GameObject newProjectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        SimulateProjectile projectile = newProjectile.GetComponent<SimulateProjectile>();

        projectile.SpawnProjectile(initialVelocity, angle, gravity);
    }


    private float CalculateInitialVelocity(float velocity, float theta)
    {

        float angleInRadians = theta * Mathf.Deg2Rad;


        float initialVelocity = velocity / Mathf.Cos(angleInRadians);


        return initialVelocity;
    }


}