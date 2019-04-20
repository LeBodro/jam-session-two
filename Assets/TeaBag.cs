using UnityEngine;

public class TeaBag : MonoBehaviour
{
    const float STUMBLING = 0.75f;
    const float DECAY = 0.20f;
    const float TARGET_REACH = 0.8f;

    public KeyCode b1;
    public KeyCode b2;
    public float advance;
    new public AudioSource audio;
    public AudioClip stumble;
    public ParticleSystem spooner;

    ParticleSystem.EmissionModule emission;
    KeyCode good;
    KeyCode bad;
    float tilt = 15;
    float target;

    void Start()
    {
        good = b1;
        bad = b2;
        emission = spooner.emission;
    }

    void Update()
    {
        bool progress = Input.GetKeyDown(good);
        bool stumble = Input.GetKeyDown(bad);

        if (stumble) Stumble();
        else if (progress) Progress();

        advance -= advance * DECAY * Time.deltaTime;
        MoveTowardTarget();

        emission.rateOverTimeMultiplier = advance * 50;
    }

    void Progress()
    {
        advance += 0.02f;
        advance = Mathf.Min(1, advance);
        audio.Play();
        SwapButtons();
    }

    void Stumble()
    {
        advance *= STUMBLING;
        audio.PlayOneShot(stumble);
    }

    void SwapButtons()
    {
        KeyCode cache = good;
        good = bad;
        bad = cache;
        tilt *= -1;
        transform.eulerAngles = new Vector3(0, 0, tilt);
    }

    public void GoTo(float target)
    {
        this.target = target;
    }

    void MoveTowardTarget()
    {
        Vector3 pos = transform.position;
        //pos.x = (target - pos.x) * TARGET_REACH;
        pos.x = target;
        transform.position = pos;
    }
}
