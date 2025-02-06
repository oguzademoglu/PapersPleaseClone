using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] DocumentData documentData;

    public string RandomName { get; private set; }
    public string RandomCountry { get; private set; }
    public int RandomAge { get; private set; }

    public void GenerateNewDocument()
    {
        RandomName = documentData.names[Random.Range(0, documentData.names.Count)];
        RandomCountry = documentData.countries[Random.Range(0, documentData.countries.Count)];
        RandomAge = Random.Range(documentData.minAge, documentData.maxAge + 1);
    }
}
