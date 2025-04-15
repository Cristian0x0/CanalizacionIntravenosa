using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    private Dictionary<GameObject, HashSet<string>> triggerMap = new();

    public void RegisterTriggerEnter(string triggerID, GameObject obj)
    {
        if (!triggerMap.ContainsKey(obj))
            triggerMap[obj] = new HashSet<string>();

        triggerMap[obj].Add(triggerID);

        if (triggerMap[obj].Count == 2)
        {
            Debug.Log($"hola [ENTER] {obj.name} está tocando ambos triggers.");
        }
    }

    public void RegisterTriggerExit(string triggerID, GameObject obj)
    {
        if (triggerMap.ContainsKey(obj))
        {
            triggerMap[obj].Remove(triggerID);

            if (triggerMap[obj].Count < 2)
            {
                Debug.Log($"hola [EXIT] {obj.name} ya no está tocando ambos triggers.");
            }

            if (triggerMap[obj].Count == 0)
                triggerMap.Remove(obj);
        }
    }
}
