using UnityEngine;

public class Breaker : MonoBehaviour
{ 
    public bool CanBreak(Cube cube)
    {
        int minChanceOfBreaking = 0;
        int maxChanceOfBreaking = 100;

        int result = Random.Range(minChanceOfBreaking, maxChanceOfBreaking);

        return cube.ChanceOfBreaking > result;
    }

    public void BreakIntoCubes(Cube cube)
    {
        float reductionOfNewCube = 2f;
        float reducingChanceOfBreaking = 2f;
        float radiusIncrease = 2f;
        float forceIncrease = 1.5f;

        Vector3 newCubeScale = cube.transform.localScale / reductionOfNewCube;
        float chanceOfBreakingNewCubes = cube.ChanceOfBreaking / reducingChanceOfBreaking;
        float explosionRadiusOfNewCube = cube.ExplosionRadius * radiusIncrease;
        float explosionForceOfNewCube = cube.ExplosionForce * forceIncrease;

        for (int i = 0; i < GetAmountOfNewCubes(); i++)
        {
            Cube newCube = cube.Clone();
            newCube.Initialize(newCubeScale, chanceOfBreakingNewCubes,
                explosionRadiusOfNewCube, explosionForceOfNewCube);
        }
    }

    private int GetAmountOfNewCubes()
    {
        int minAmountOfCubes = 2;
        int maxAmountOfCubes = 6;

        return Random.Range(minAmountOfCubes, maxAmountOfCubes);
    }
}