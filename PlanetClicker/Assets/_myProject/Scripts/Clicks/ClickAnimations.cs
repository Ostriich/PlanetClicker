using UnityEngine;

public class ClickAnimations : MonoBehaviour
{
    [SerializeField] private GameObject clickSpawnText;
    [SerializeField] private float radius;
    [SerializeField] private AudioSource audioSourse;

    public void SpawnClick(int strength, bool isRed)
    {
        // Determine the point of spawn

        int angle = Random.Range(0, 359);
        radius = Random.Range(0, 4);
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        // Spawn the clickText

        GameObject clickText = Instantiate(clickSpawnText, new Vector3(x, y, -0.5f), Quaternion.identity);
        clickText.GetComponent<TextMesh>().text = strength.ToString();
        if (isRed) { clickText.GetComponent<TextMesh>().color = Color.red; }
    }

    public void SpawnAudio(AudioClip clip)
    {
        audioSourse.PlayOneShot(clip);
    }
}
