using UnityEngine;

public class PersistantObj : MonoBehaviour
{
    public static GameObject Current;
    [SerializeField]GameObject Persistant;


    private void Start()
    {
        if (Current == null)
        {
            var Object = Instantiate(Persistant, Vector3.zero, gameObject.transform.rotation) as GameObject;
            DontDestroyOnLoad(Object);
            Current = Object;

        }
        else 
        {
            if (this != Current) 
            {
                Destroy(this);
            }
            
        }


    }





}
