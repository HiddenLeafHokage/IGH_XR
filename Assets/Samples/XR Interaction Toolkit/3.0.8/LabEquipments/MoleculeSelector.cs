using UnityEngine;

public class MoleculeSelector : MonoBehaviour
{
    public GameObject[] moleculePrefabs;
    public Transform spawnPoint;
    private GameObject currentInstance;

    public void SelectMolecule(int index)
    {
        if (currentInstance != null) Destroy(currentInstance);
        currentInstance = Instantiate(moleculePrefabs[index], spawnPoint.position, Quaternion.identity);
    }
}