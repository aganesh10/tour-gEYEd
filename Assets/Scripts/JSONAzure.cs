using System;
using System.Collections.Generic;
using UnityEngine;

public class JSONAzure
{
    [System.Serializable]
    public class Tools
    {
        public string id;
        public string project;
        public string iteration;
        public string created;
        public List<Predictions> predictions;
    }
    [System.Serializable]
    public class Predictions
    {
        public string tagID;
        public string tagName;
        public double probability;
    }
}
