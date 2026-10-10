using UnityEngine;

public class PlayerChangeRole : MonoBehaviour
{
    public PlayerClassManager manager;

    public int role;

    public void ChangeRole()
    {
        manager.characterClass = (Profile)role;
    }
}
