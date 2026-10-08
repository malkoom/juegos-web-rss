using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Profile")]
    [SerializeField] private Profile characterClass;

    public PlayerData data;

    [SerializeField] private float health = 100;

    private void Awake()
    {
        CacheReferences();
    }

    private void OnEnable()
    {
        CacheReferences();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CacheReferences()
    {
        if (data == null)
        {
            data = PlayerDataFactory.GetData(characterClass);
        }
    }
}
