using UnityEngine;

[RequireComponent(typeof(PlayMultipleSound))]
public class playSoundTimer : MonoBehaviour
{
    public float time = 1.0f;
    private float timer;
    public TYPE_AUDIO typeToPlay;

    private PlayMultipleSound sound;

    private void Start()
    {
        timer = time;
        sound = GetComponent<PlayMultipleSound>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            sound.PlaySound(typeToPlay);
            timer = time;
        }
        else
        {
            sound.CheckForPlaySoundOnAwake();
        }
    }
}
