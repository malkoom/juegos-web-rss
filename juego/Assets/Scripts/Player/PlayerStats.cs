using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStats : MonoBehaviour
{
    [Header("Profile")]
    private PlayerClassManager playerClassManager;

    [SerializeField] private Profile characterClass;

    public PlayerData data;

    [SerializeField] private float health = 100;

    private void Awake()
    {
        playerClassManager = FindFirstObjectByType<PlayerClassManager>();
        characterClass = playerClassManager.characterClass;
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
