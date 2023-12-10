using UnityEngine;

public class SimulateProjectile : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;
    [SerializeField] private float lifetime;
    [SerializeField] private int damage;

    private float initialVelocity;
    private float angle;
    private float gravity;
    private float time = 0f;

    void Awake()
    {
        if (lifetime <= 0)
            lifetime = 2.0f;

        Destroy(gameObject, lifetime);

    }
    public void SpawnProjectile(float velocity, float launchAngle, float launchGravity)
    {
        initialVelocity = velocity;
        angle = launchAngle;
        gravity = launchGravity;


    }
    private void Update()
    {

        // Calculate the projectile's position using the inherited parameters
        float horizontalVelocity = initialVelocity * Mathf.Cos(angle * Mathf.Deg2Rad);
        float verticalVelocity = initialVelocity * Mathf.Sin(angle * Mathf.Deg2Rad) + (gravity * time);

        Vector3 newPosition = transform.position + new Vector3(horizontalVelocity, verticalVelocity, 0) * Time.deltaTime;
        transform.position = newPosition;

        // Increment time for the next frame
        time += Time.deltaTime;
    }




}