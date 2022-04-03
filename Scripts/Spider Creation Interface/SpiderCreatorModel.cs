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
        return userDeterminedMax - activeSpiders.Count;
    }

    public void CreateSpider()
    {
        GameObject newSpider = Instantiate(this.SelectSpider(), spawnPoints.ElementAt(Random.Range(0, spawnPoints.Count)).transform.position, Quaternion.Euler(0f, Random.Range(-180f, 180f), 0f));
        activeSpiders.Add(newSpider);
    }

    public void CreateAllSpiders(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject newSpider = Instantiate(this.SelectSpider(), spawnPoints.ElementAt(i).transform.position, Quaternion.Euler(0f, Random.Range(-180f, 180f), 0f));
            activeSpiders.Add(newSpider);
        }
    }

    private GameObject SelectSpider()
    {
        int diversityIndex = Random.Range(0, 3);
        int intensityIndex = Random.Range(0, 4);

        if (intensity == SpiderIntensity.Low || (intensity == SpiderIntensity.Random && intensityIndex == 0))
        {
            if (diversity == SpiderDiversity.CommonHouseSpider || (diversity == SpiderDiversity.Random && diversityIndex == 0))
                return basicHouseSpider;

            else if (diversity == SpiderDiversity.Tarantula || (diversity == SpiderDiversity.Random && diversityIndex == 1))
                return basicTarantula;

            else if (diversity == SpiderDiversity.WolfSpider || (diversity == SpiderDiversity.Random && diversityIndex == 2))
                return basicWolfSpider;

            else return null;
        }

        else if (intensity == SpiderIntensity.Moderate || (intensity == SpiderIntensity.Random && intensityIndex == 1))
        {
            if (diversity == SpiderDiversity.CommonHouseSpider || (diversity == SpiderDiversity.Random && diversityIndex == 0))
                return intermediateHouseSpider;

            else if (diversity == SpiderDiversity.Tarantula || (diversity == SpiderDiversity.Random && diversityIndex == 1))
                return intermediateTarantula;

            else if (diversity == SpiderDiversity.WolfSpider || (diversity == SpiderDiversity.Random && diversityIndex == 2))
                return intermediateWolfSpider;

            else return null;
        }

        else if (intensity == SpiderIntensity.High || (intensity == SpiderIntensity.Random && intensityIndex == 2))
        {
            if (diversity == SpiderDiversity.CommonHouseSpider || (diversity == SpiderDiversity.Random && diversityIndex == 0))
                return complexHouseSpider;

            else if (diversity == SpiderDiversity.Tarantula || (diversity == SpiderDiversity.Random && diversityIndex == 1))
                return complexTarantula;

            else if (diversity == SpiderDiversity.WolfSpider || (diversity == SpiderDiversity.Random && diversityIndex == 2))
                return complexWolfSpider;

            else return null;
        }

        else // if intensity is set to Extreme, or intensity is set to Random and the randomly generated intensity index is 3
        {
            if (diversity == SpiderDiversity.CommonHouseSpider || (diversity == SpiderDiversity.Random && diversityIndex == 0))
                return extremeHouseSpider;

            else if (diversity == SpiderDiversity.Tarantula || (diversity == SpiderDiversity.Random && diversityIndex == 1))
                return extremeTarantula;

            else if (diversity == SpiderDiversity.WolfSpider || (diversity == SpiderDiversity.Random && diversityIndex == 2))
                return extremeWolfSpider;

            else return null;
        }
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
            Destroy(spider);

        activeSpiders = new List<GameObject>();
    }
}