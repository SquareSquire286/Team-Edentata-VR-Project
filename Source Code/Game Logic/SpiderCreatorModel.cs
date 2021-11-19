using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/*
 *  Stores settings for diversity and intensity, which are then pulled by the creator
*/

public class SpiderCreatorModel : MonoBehaviour
{
    private SpiderDiversity diversity;
    private SpiderIntensity intensity;
    private List<GameObject> activeSpiders;
    private int userDeterminedMax;

    public List<GameObject> spawnPoints;
    public GameObject basicHouseSpider, basicTarantula, basicWolfSpider;
    public GameObject intermediateHouseSpider, intermediateTarantula, intermediateWolfSpider;
    public GameObject complexHouseSpider, complexTarantula, complexWolfSpider;
    public GameObject extremeHouseSpider, extremeTarantula, extremeWolfSpider;
    public Text maxSpiderText;

    void Start()
    {
        SpiderCreatorSingleton.maxSpiders = 20;
        userDeterminedMax = 10;
        maxSpiderText.text = "" + userDeterminedMax;
        activeSpiders = new List<GameObject>();
    }

    public void ChangeMaxAmount(int modifier)
    {
        if (modifier == -1 && userDeterminedMax == 0)
            return;

        else if (modifier == 1 && userDeterminedMax == SpiderCreatorSingleton.maxSpiders)
            return;

        else
        {
            userDeterminedMax += modifier;
            maxSpiderText.text = "" + userDeterminedMax;
        }
    }

    public void SetDiversity(SpiderDiversity diversity)
    {
        this.diversity = diversity;
    }

    public void SetIntensity(SpiderIntensity intensity)
    {
        this.intensity = intensity;
    }

    public SpiderDiversity GetDiversity()
    {
        return diversity;
    }

    public SpiderIntensity GetIntensity()
    {
        return intensity;
    }

    public int GetRemainingSpiders()
    {
        return SpiderCreatorSingleton.maxSpiders - activeSpiders.Count;
    }

    public void CreateSpider() // EXTREMELY UNCLEAN, NEED TO REFACTOR AT SOME POINT IN WINTER 2022
    {
        int diversityIndex = Random.Range(0, 3);
        int intensityIndex = Random.Range(0, 4);
        int spawnerIndex = Random.Range(0, spawnPoints.Count);

        GameObject newSpider;

        if (intensity == SpiderIntensity.Low || (intensity == SpiderIntensity.Random && intensityIndex == 0))
        {
            if (diversity == SpiderDiversity.CommonHouseSpider || (diversity == SpiderDiversity.Random && diversityIndex == 0))
                newSpider = Instantiate(basicHouseSpider, spawnPoints.ElementAt(spawnerIndex).transform.position, Quaternion.Euler(0f, Random.Range(-180f, 180f), 0f));

            else if (diversity == SpiderDiversity.Tarantula || (diversity == SpiderDiversity.Random && diversityIndex == 1))
                newSpider = Instantiate(basicTarantula, spawnPoints.ElementAt(spawnerIndex).transform.position, Quaternion.Euler(0f, Random.Range(-180f, 180f), 0f));
            
            else newSpider = Instantiate(basicWolfSpider, spawnPoints.ElementAt(spawnerIndex).transform.position, Quaternion.Euler(0f, Random.Range(-180f, 180f), 0f));
        }

        else if (intensity == SpiderIntensity.Moderate || (intensity == SpiderIntensity.Random && intensityIndex == 1))
        {
            if (diversity == SpiderDiversity.CommonHouseSpider || (diversity == SpiderDiversity.Random && diversityIndex == 0))
                newSpider = Instantiate(intermediateHouseSpider, spawnPoints.ElementAt(spawnerIndex).transform.position, Quaternion.Euler(0f, Random.Range(-180f, 180f), 0f));

            else if (diversity == SpiderDiversity.Tarantula || (diversity == SpiderDiversity.Random && diversityIndex == 1))
                newSpider = Instantiate(intermediateTarantula, spawnPoints.ElementAt(spawnerIndex).transform.position, Quaternion.Euler(0f, Random.Range(-180f, 180f), 0f));

            else newSpider = Instantiate(intermediateWolfSpider, spawnPoints.ElementAt(spawnerIndex).transform.position, Quaternion.Euler(0f, Random.Range(-180f, 180f), 0f));
        }

        else if (intensity == SpiderIntensity.High || (intensity == SpiderIntensity.Random && intensityIndex == 2))
        {
            if (diversity == SpiderDiversity.CommonHouseSpider || (diversity == SpiderDiversity.Random && diversityIndex == 0))
                newSpider = Instantiate(complexHouseSpider, spawnPoints.ElementAt(spawnerIndex).transform.position, Quaternion.Euler(0f, Random.Range(-180f, 180f), 0f));

            else if (diversity == SpiderDiversity.Tarantula || (diversity == SpiderDiversity.Random && diversityIndex == 1))
                newSpider = Instantiate(complexTarantula, spawnPoints.ElementAt(spawnerIndex).transform.position, Quaternion.Euler(0f, Random.Range(-180f, 180f), 0f));

            else newSpider = Instantiate(complexWolfSpider, spawnPoints.ElementAt(spawnerIndex).transform.position, Quaternion.Euler(0f, Random.Range(-180f, 180f), 0f));
        }

        else
        {
            if (diversity == SpiderDiversity.CommonHouseSpider || (diversity == SpiderDiversity.Random && diversityIndex == 0))
                newSpider = Instantiate(extremeHouseSpider, spawnPoints.ElementAt(spawnerIndex).transform.position, Quaternion.Euler(0f, Random.Range(-180f, 180f), 0f));

            else if (diversity == SpiderDiversity.Tarantula || (diversity == SpiderDiversity.Random && diversityIndex == 1))
                newSpider = Instantiate(extremeTarantula, spawnPoints.ElementAt(spawnerIndex).transform.position, Quaternion.Euler(0f, Random.Range(-180f, 180f), 0f));

            else newSpider = Instantiate(extremeWolfSpider, spawnPoints.ElementAt(spawnerIndex).transform.position, Quaternion.Euler(0f, Random.Range(-180f, 180f), 0f));
        }

        activeSpiders.Add(newSpider);
    }

    public void RemoveSpider()
    {
        int removalIndex = Random.Range(0, activeSpiders.Count);
        GameObject spiderToRemove = activeSpiders.ElementAt(removalIndex);
        activeSpiders.Remove(spiderToRemove);
        Destroy(spiderToRemove);
    }

    public void RemoveAllSpiders()
    {
        foreach (GameObject spider in activeSpiders)
        {
            activeSpiders.Remove(spider);
            Destroy(spider);
        }
    }
}