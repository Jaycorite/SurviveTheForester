using UnityEngine;

public class Grass : MonoBehaviour, IInteractable, IPickEmUp
{
    public void Focus()
    {
        Debug.Log("FOKUSS");
    }

    public GameObject pickThisUp()
    {

        return this.gameObject;
    }

    public void PrimaryUse()
    {
        throw new System.NotImplementedException();
    }

    public void SecondaryUse()
    {
        throw new System.NotImplementedException();
    }

    public void Unfocus()
    {
        Debug.Log("IKKEFOKUSS");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
