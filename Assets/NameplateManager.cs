using UnityEngine;
using TMPro;
public class NameplateManager : MonoBehaviour
{
    public TextMeshPro textoDeTabla;
    public bool puedePasarPagina = false;
    public int currentPage = 0;
    public string[] textosDeTabla = new string[2];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textoDeTabla.text = textosDeTabla[currentPage];
    }

    // Update is called once per frame
    void Update()
    {
     if(GameManagerExample.instance.Confirm())
            if(puedePasarPagina)
            {
                currentPage = currentPage + 1 == textosDeTabla.Length ? 0 : currentPage + 1;
                textoDeTabla.text = textosDeTabla[currentPage];
            }
            
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log(other.gameObject.name);
            puedePasarPagina = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other.gameObject.name);
            puedePasarPagina = false;
        }
    }
}
