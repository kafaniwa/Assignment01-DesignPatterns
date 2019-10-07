using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


/*public abstract class Command
{
    public void SetFactory(Factory f)
    {
        factory = f;
    }
    public abstract GameObject Execute();

    protected Factory factory;
}

public class CylinderCommand : Command
{
    public override GameObject Execute()
    {
        return factory.GetNewInstance();
    }
}

public class CubeCommand : Command
{
    public override GameObject Execute()
    {
        return factory.GetNewInstance();
    }
}

public class SphereCommand : Command
{
    public override GameObject Execute()
    {
        return factory.GetNewInstance();
    }
}

public class EnemyCommand : Command
{
    public override GameObject Execute()
    {
        return factory.GetNewInstance();
    }
} */

public class ManagerScript : MonoBehaviour
{

    public bool playerPlaced = false;

    public bool saveLoadMenuOpen = false;

   /* public bool cylindery = false;
    public bool cubey = false;
    public bool spherey = false;*/

    public MeshFilter mouseObject;
    public MouseScript user;
    public Mesh playerMarker;
    private LevelEditor level;

   /* CylinderFactory cylinderFactory;
    public GameObject cylinderPrefab;

    CubeFactory cubeFactory;
    public GameObject cubePrefab;

    SphereFactory sphereFactory;
    public GameObject spherePrefab;

    EnemyFactory enemyFactory;
    public GameObject enemyPrefab;*/



    // Start is called before the first frame update
    void Start()
    {
        /*
        cylinderFactory.SetObjectToClone(cylinderPrefab);
        cubeFactory.SetObjectToClone(cubePrefab);
        sphereFactory.SetObjectToClone(spherePrefab);
        enemyFactory.SetObjectToClone(spherePrefab);
        */

        //Example usage:
       // CylinderCommand cm = new CylinderCommand();
        //cm.SetFactory(cylinderFactory);
        //GameObject thingToSpawnInEditor = cm.Execute();

        CreateEditor(); // create new instance of level.
    }

    LevelEditor CreateEditor()
    {
        level = new LevelEditor();
        level.editorObjects = new List<EditorObject.Data>(); // make new list of editor object data.
        return level;
    }

    // Choosing an object
    public void ChooseCylinder()
    {
        user.itemOption = MouseScript.ItemList.Cylinder; // set object to place as cylinder
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder); // create object, get new object's mesh and set mouse object's mesh to that, then destroy
        mouseObject.mesh = cylinder.GetComponent<MeshFilter>().mesh;
        Destroy(cylinder);
    }

    public void ChooseCube()
    {
        user.itemOption = MouseScript.ItemList.Cube; // set object to place as cube
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube); // create object, get new object's mesh and set mouse object's mesh to that, then destroy
        mouseObject.mesh = cube.GetComponent<MeshFilter>().mesh;
        Destroy(cube);
    }

    public void ChooseSphere()
    {
        user.itemOption = MouseScript.ItemList.Sphere; // set object to place as sphere
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere); // create object, get new object's mesh and set mouse object's mesh to that, then destroy
        mouseObject.mesh = sphere.GetComponent<MeshFilter>().mesh;
        Destroy(sphere);
    }





    // Choosing an option for level manipulation
    public void ChooseCreate()
    {
        user.manipulateOption = MouseScript.LevelManipulation.Create; // set mode to create
        user.mr.enabled = true; // show mouse object mesh

    }


    public void ChooseDestroy()
    {
        user.manipulateOption = MouseScript.LevelManipulation.Destroy; // set mode to destroy
        user.mr.enabled = false; // hide mouse mesh

    }

    public void SaveLevel() //not working
    {
        if (Input.GetKeyDown("n"))
        {
            // Gather all objects with EditorObject component
            EditorObject[] foundObjects = FindObjectsOfType<EditorObject>();
            foreach (EditorObject obj in foundObjects)
                level.editorObjects.Add(obj.data); // add these objects to the list of editor objects

            string json = JsonUtility.ToJson(level); // write the level data to json
            string folder = Application.dataPath + "/LevelData/"; // create a folder
            string levelFile = "Save";

            string path = Path.Combine(folder, levelFile); // set filepath

            // create and save file
            File.WriteAllText(path, json);
        }
    }
    public void LoadLevel() //not working either
    {
        if (Input.GetKeyDown("m"))
        {
            string folder = Application.dataPath + "/LevelData/";
            string levelFile = "Save";

            string path = Path.Combine(folder, levelFile); // set filepath

            if (File.Exists(path)) // if the file could be found in LevelData
            {
                // The objects currently in the level will be deleted
                EditorObject[] foundObjects = FindObjectsOfType<EditorObject>();
                foreach (EditorObject obj in foundObjects)
                    Destroy(obj.gameObject);

              
                string json = File.ReadAllText(path); // provide text from json file
                level = JsonUtility.FromJson<LevelEditor>(json); // level information filled from json file
                CreateFromFile(); // create objects from level data.
            }
        }
    }






    // create objects based on data within level.
    void CreateFromFile()
    {
        GameObject newObj; // make a new object.

        for (int i = 0; i < level.editorObjects.Count; i++)
        {
            if (level.editorObjects[i].objectType == EditorObject.ObjectType.Cylinder) // if a cylinder object
            {
                // create cylinder
                newObj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                newObj.transform.position = level.editorObjects[i].pos; // set position from data in level

                newObj.layer = 9; // assign to SpawnedObjects layer.

                //Add editor object component and feed data.
                EditorObject eo = newObj.AddComponent<EditorObject>();
                eo.data.pos = newObj.transform.position;
                eo.data.objectType = EditorObject.ObjectType.Cylinder;
            }
            else if (level.editorObjects[i].objectType == EditorObject.ObjectType.Cube)
            {
                // create cube
                newObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                newObj.transform.position = level.editorObjects[i].pos; // set position from data in level
                newObj.layer = 9; // assign to SpawnedObjects layer.

                //Add editor object component and feed data.
                EditorObject eo = newObj.AddComponent<EditorObject>();
                eo.data.pos = newObj.transform.position;
                eo.data.objectType = EditorObject.ObjectType.Cube;
            }
            else if (level.editorObjects[i].objectType == EditorObject.ObjectType.Sphere)
            {
                // create sphere
                newObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                newObj.transform.position = level.editorObjects[i].pos; // set position from data in level
                newObj.AddComponent<Rigidbody>();
                newObj.layer = 9; // assign to SpawnedObjects layer.

                //Add editor object component and feed data.
                EditorObject eo = newObj.AddComponent<EditorObject>();
                eo.data.pos = newObj.transform.position;
                eo.data.objectType = EditorObject.ObjectType.Sphere;
            }
           
        }


    }
}