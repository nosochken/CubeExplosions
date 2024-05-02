using UnityEngine;

public class Explosion : MonoBehaviour
{
    public void Explode(Cube cube)
    {
        float force = 500;
        float radius = 2f;

        Collider[] colliders = Physics.OverlapSphere(cube.transform.position, radius);

        foreach (var collider in colliders)
        {
            if (collider.attachedRigidbody != null)
                collider.attachedRigidbody.AddExplosionForce(force, cube.transform.position, radius);
        }
    }
}