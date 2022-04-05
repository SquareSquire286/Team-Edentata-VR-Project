using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ***********************************************************************
// Purpose: 
//     
//
// ***********************************************************************
public enum SpiderDiversity
{
    Void,
    CommonHouseSpider,
    Tarantula,
    WolfSpider,
    Random
}

public enum SpiderIntensity
{
    Void,
    Low,
    Moderate,
    High,
    Extreme,
    Random
}

public static class SpiderCreatorSingleton
{
    public static SpiderDiversity diversitySettings { set; get; }
    public static SpiderIntensity intensitySettings { set; get; }
    public static int maxSpiders { set; get; }
}