using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.JSONSerializeModule;

public class ExtractingJSON
 {
   
    public static ExtractingJSON CreateFromJSON(string thing)
    {
        return JsonUtility.FromJson<ExtractingJSON>(thing);
    }

        public GameObject hoover;
        public GameObject huang;
        public GameObject memorial;
        public GameObject oval;
        public GameObject rodin;
        public GameObject sather;
        public GameObject church;

        public void statusChecker(string tagName)
        {
            // string output = JsonConvert.SerializeObject(product);
            switch (tagName)
            {
                case "Hoover Tower":
                    hoover.SetActive(true);
                    break;
                case "huang":
                    huang.SetActive(true);
                    break;
                case "Memorial Stadium":
                    memorial.SetActive(true);
                    break;
                case "Oval Flowers":
                    oval.SetActive(true);
                    break;
                case "RodinSculptures":
                    rodin.SetActive(true);
                    break;
                case "Sather Tower":
                    sather.SetActive(true);
                    break;
                case "Stanford Church":
                    church.SetActive(true);
                    break;
                default:
                    break;
            }
        }
        public static void Main()
        {
            var results = ExtractingJSON.CreateFromJSON();
            var x = results.predictions[0].probability;
            if (x >= .8)
            {
                statusChecker(predictions[0].tagName);
            }
        }
    }

