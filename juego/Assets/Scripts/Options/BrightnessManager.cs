using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BrightnessManager : MonoBehaviour
{
    public static BrightnessManager instance;

    [HideInInspector] public Image image; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void LoadBrightness()
    {
        Debug.Log("Cambiando brillo");

        float brightness = PlayerPrefs.HasKey("Brightness") ? PlayerPrefs.GetFloat("Brightness") : 1f;

        Color color = image.color;

        color.a = Mathf.Clamp((1f-brightness), 0.001f, 1f);
        
        image.color = color;
    }

    public void SetBrightness(float bright)
    {
        Color color = image.color;

        bright = Mathf.Clamp(bright, 0.001f, 1f);

        color.a = Mathf.Clamp((1f - bright), 0.001f, 1f);
        
        image.color = color;

        Debug.Log($"Brillo aplicado: {bright} | Alfa de la imagen: {color.a}");

        PlayerPrefs.SetFloat("Brightness", bright);
        PlayerPrefs.Save();
    }

    public void SaveBrightness(float bright)
    {
        PlayerPrefs.GetFloat("Brightness", bright);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        //image = GameObject.FindGameObjectWithTag("BrightnessFilter").GetComponent<Image>();
        //LoadBrightness();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //image = GameObject.FindGameObjectWithTag("BrightnessFilter").GetComponent<Image>();

        GameObject obj = GameObject.FindGameObjectWithTag("BrightnessFilter");

        if(obj != null)
        {
            image = obj.GetComponent<Image>();
            LoadBrightness();
        }
        else
        {
            Debug.Log("NO HAY IMAGEN");
            image = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
