using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceManager
{

    //sunlight
    //fertilizer / neutrients / biomass

    private static int _energy;
    private static int _water;
    private static int _minerals;
    private static int _co2;


    private static int _maxResourceAmount;
    private static int _maxEnergy;
    private static int _maxWater;
    private static int _maxMinerals;
    private static int _maxCO2;

    public static event EventHandler OnResourceAmountChanged;

    public static int AmountEnergy
    {
        get => _energy;
        set => _energy = value;
    }

    public static int AmountWater
    {
        get => _water;
        set => _water = value;
    }

    public static int AmountMinerals
    {
        get => _minerals;
        set => _minerals = value;
    }

    public static int AmountCO2
    {
        get => _co2;
        set => _co2 = value;
    }

    public static int MaxResourceAmount
    {
        get => _maxResourceAmount;
        set => _maxResourceAmount = value;
    }

    public static int MaxEnergy
    {
        get => _maxEnergy;
        set => _maxEnergy = value;
    }

    public static int MaxWater
    {
        get => _maxWater;
        set => _maxWater = value;
    }

    public static int MaxMinerals
    {
        get => _maxMinerals;
        set => _maxMinerals = value;
    }

    public static int MaxCO2
    {
        get => _maxCO2;
        set => _maxCO2 = value;
    }

    private static Dictionary<Resource, int> resourceAmountDictionary;

    public static void Init()
    {
        resourceAmountDictionary = new Dictionary<Resource, int>();

        MaxResourceAmount = 500;

        foreach(Resource resourceType in System.Enum.GetValues(typeof(Resource))) {
            resourceAmountDictionary[resourceType] = 0;
        }
    }

    public static void AddResourceAmount(Resource resourceType, int amount) {
        resourceAmountDictionary[resourceType] += amount;
        if(resourceAmountDictionary[resourceType] > _maxResourceAmount)
        {
            resourceAmountDictionary[resourceType] = _maxResourceAmount;
        }
    }

    public static int GetResourceAmount(Resource resourceType)
    {
        return resourceAmountDictionary[resourceType];
    }

    public static void RemoveResourceAmount(Resource resourceType, int amount)
    {
        resourceAmountDictionary[resourceType] -= amount;
        if (resourceAmountDictionary[resourceType] < 0)
        {
            resourceAmountDictionary[resourceType] = 0;
        }
    }

    public static bool TrySpendResourcesCost(Resource resourceType, int amountNeeded)
    {
        if(resourceAmountDictionary[resourceType] >= amountNeeded) {
            RemoveResourceAmount(resourceType, amountNeeded);
            return true;
        } else
        {
            return false;
        }
    }

}

public enum Resource {

    Energy,
    Water,
    Neutrients,
    CO2
}

