﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhotoComponent : POIScriptComponent     {

    public string dataPath;

    private GameObject loaderObj;

    // Use this for initialization
    void Start() {
        loaderObj = new GameObject();
        loaderObj.transform.position = this.transform.position;
        loaderObj.transform.parent = this.transform;

        loaderObj.AddComponent<LoadPhotos>();
        loaderObj.GetComponent<LoadPhotos>().photoPath = dataPath;

        // Load the photos. Should only happen once on scene start.
        loaderObj.GetComponent<LoadPhotos>().Load();
	}

    public override void Activate()
    {
        // Calls Activate on parent object.
        base.Activate();

        // Sets the photo loader to active.
        loaderObj.SetActive(true);

        // Place photos in the correct location.
        loaderObj.GetComponent<LoadPhotos>().PlacePhotos();
    }

    public override void Deactivate()
    {
        base.Deactivate();

        // Deactivate the loader object.
        loaderObj.SetActive(false);

    }
}
