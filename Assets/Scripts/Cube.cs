using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _chanceOfBreaking = 100f;
    private float _explosionRadius = 10f;
    private float _explosionForce = 500f;

    public float ChanceOfBreaking => _chanceOfBreaking;
    public float ExplosionRadius => _explosionRadius;
    public float ExplosionForce => _explosionForce;

    public void Initialize(Vector3 scale, float chanceOfBreaking,
        float explosionRadius, float explosionForce)
    {
        transform.localScale = scale;
        _chanceOfBreaking = chanceOfBreaking;
        _explosionRadius = explosionRadius;
        _explosionForce = explosionForce;
    }

    public Cube Clone()
    {
        return Instantiate(this);
    }
}