using UnityEngine;

public class PlanetAnimation : MonoBehaviour
{
    private int multiplier = 1;

    private void FixedUpdate()
    {
        if (transform.localScale.x >= 1.1) { multiplier = -1; }
        if (transform.localScale.x <= 0.9) { multiplier = 1; }

        transform.localScale += multiplier * new Vector3(0.001f, 0.001f, 0);
    }
}
