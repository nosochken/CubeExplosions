using UnityEngine;

[RequireComponent(typeof(Breaker))]
public class Explosion : MonoBehaviour
{
    private Breaker _breaker;

    private void Awake()
    {
        _breaker = GetComponent<Breaker>();
    }

    public void Explode(Cube cube)
    {
        float force = 100f;
        float radius = 2f;

        if (_breaker.CanBreak(cube))
        {
            _breaker.BreakIntoCubes(cube);
        }
        else
        {
            force = cube.ExplosionForce;
            radius = cube.ExplosionRadius;
        }

        Collider[] colliders = Physics.OverlapSphere(cube.transform.position, radius);

        foreach (var collider in colliders)
        {
            if (collider.attachedRigidbody != null)
                collider.attachedRigidbody.AddExplosionForce(force, cube.transform.position, radius);
        }
    }
}