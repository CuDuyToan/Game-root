using Mono.Cecil;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    public static GameRoot Instance;

    public TimeSystem TimeSystem;
    public SoundSystem SoundSystem;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }


}