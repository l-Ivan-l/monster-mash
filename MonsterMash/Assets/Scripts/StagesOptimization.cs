using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagesOptimization : MonoBehaviour
{
    private List<StageController> stages = new List<StageController>();

    void Awake()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            stages.Add(transform.GetChild(i).GetComponent<StageController>());
        }
    }

    public void OptimizeScene(StageController _currentStage)
    {
        int currentIndex = 0;
        for(int i = 0; i < stages.Count; i++)
        {
            if(stages[i] == _currentStage)
            {
                currentIndex = i;
            }
        }

        List<int> indexesToActivate = new List<int>();
        indexesToActivate.Add(currentIndex);
        indexesToActivate.Add(currentIndex + 1);
        indexesToActivate.Add(currentIndex + 2);
        indexesToActivate.Add(currentIndex - 1);
        indexesToActivate.Add(currentIndex - 2);

        List<StageController> stagesToActivate = new List<StageController>();

        for(int i = 0; i < indexesToActivate.Count; i++)
        {
            if(indexesToActivate[i] >= 0 && indexesToActivate[i] <= 9)
            {
                stagesToActivate.Add(stages[indexesToActivate[i]]);
            }
        }

        for(int i = 0; i < stages.Count; i++)
        {
            for(int j = 0; j < stagesToActivate.Count; j++)
            {
                if(stages[i] == stagesToActivate[j])
                {
                    stages[i].gameObject.SetActive(true);
                    break;
                }
                else 
                {
                    stages[i].gameObject.SetActive(false);
                }
            }
        }
    }
}
