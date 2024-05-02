using UnityEngine;

public class Explosion : MonoBehaviour
{
    public void Explode(Cube cube)
    {
        if (CanBreak(cube))
        {
            BreakIntoCubes(cube);
            Scatter(cube.transform.position);
        }

        Destroy(cube.gameObject);
    }

    private bool CanBreak(Cube cube)
    {
        int minChanceOfDivision = 0;
        int maxChanceOfDivision = 100;

        int result = Random.Range(minChanceOfDivision, maxChanceOfDivision);

        return cube.ChanceOfDivision > result ? true : false;
    }

    private void BreakIntoCubes(Cube cube)
    {
        float reductionOfNewCube = 2f;
        float reducingChanceOfDivision = 2f;

        Vector3 newCubeScale = cube.transform.localScale / reductionOfNewCube;
        float chanceOfDivisionNewCubes = cube.ChanceOfDivision / reducingChanceOfDivision;

        for (int i = 0; i < GetAmountOfNewCubes(); i++)
        {
            Cube newCube = cube.Clone();
            newCube.Initialize(newCubeScale, chanceOfDivisionNewCubes);
        }
    }

    private void Scatter(Vector3 origin)
    {
        float force = 500;
        float radius = 2f;

        Collider[] colliders = Physics.OverlapSphere(origin, radius);

        foreach (var collider in colliders)
        {
            if (collider.attachedRigidbody != null)
                collider.attachedRigidbody.AddExplosionForce(force, origin, radius);
        }
    }

    private int GetAmountOfNewCubes()
    {
        int minAmountOfCubes = 2;
        int maxAmountOfCubes = 6;

        return Random.Range(minAmountOfCubes, maxAmountOfCubes);
    }
}