using UnityEngine;
using UnityEngine.EventSystems;

public class MouseScript : MonoBehaviour
{
    public enum LevelManipulation { Create, Destroy }; // the possible level manipulation types
    public enum ItemList { Cylinder, Cube, Sphere, Tree, itemOption }; // the list of items

    
    public ItemList itemOption = ItemList.Cylinder; // setting the cylinder object as the default object
    
    public LevelManipulation manipulateOption = LevelManipulation.Create; // create is the default manipulation type.
    
    public MeshRenderer mr;
  
 

    public Material goodPlace;
    public Material badPlace;
    public GameObject Enemy;
    public GameObject MainCamera;
    public ManagerScript ms;
    public Transform cubePrefab;

    private Vector3 mousePos;
    private bool colliding;
    private Ray ray;
    private RaycastHit hit;
    private CameraSwitch cameraswitch;

    Vector3 points;

    void Awake()
    {
        cameraswitch = MainCamera.GetComponent<CameraSwitch>();
    }

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>(); // get the mesh renderer component and store it in mr.
    }

    // Update is called once per frame
    void Update()
    {
        
            // Have the object follow the mouse cursor by getting mouse coordinates and converting them to world point.
            mousePos = Input.mousePosition;
        if (Camera.main.GetComponent<CameraSwitch>() == true)
        {
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        }
            transform.position = new Vector3(
                Mathf.Clamp(mousePos.x, -20, 20),
                0.75f,
                Mathf.Clamp(mousePos.z, -20, 20)); // limit object movement to minimum -20 and maximum 20 for both x and z coordinates. Y alwasy remains 0.75.

            ray = Camera.main.ScreenPointToRay(Input.mousePosition); // send out raycast to detect objects
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.layer == 9) // check if raycast hitting user created object.
                {
                    colliding = true; // Unity now knows it cannot create any new object until collision is false.
                    mr.material = badPlace; // change the material to red, indicating that the user cannot place the object there.
                }
                else
                {
                    colliding = false;
                    mr.material = goodPlace;
                }
            }

            // after pressing the left mouse button...
            if (Input.GetMouseButtonDown(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject()) // check if mouse over UI object.
                {
                if (colliding == false && manipulateOption == LevelManipulation.Create) // create an object if not colliding with anything.
                {
                    points.x = hit.point.x;
                    points.y = hit.point.y + 0.5f;
                    points.z = hit.point.z;
                    CreateObject();
                }
                else if (colliding == true && manipulateOption == LevelManipulation.Destroy) // select object under mouse to be destroyed.
                {
                    if (hit.collider.gameObject.name.Contains("PlayerModel")) // if player object, set ms.playerPlaced to false indicating no player object in level.
                        ms.playerPlaced = false;

                    Destroy(hit.collider.gameObject); // remove from game.
                }

                }
            }



    }


    /// <summary>
    /// Object creation
    /// </summary>
    void CreateObject()
    {
        GameObject newObj;

        if (itemOption == ItemList.Cylinder) // cylinder
        {
            //Create object
            newObj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            newObj.transform.position = transform.position;
            newObj.layer = 9; // set to Spawned Objects layer

            //Add editor object component and feed it data.
            EditorObject eo = newObj.AddComponent<EditorObject>();
            eo.data.pos = newObj.transform.position;
            eo.data.objectType = EditorObject.ObjectType.Cylinder;
        }
        else if (itemOption == ItemList.Cube) // cube
        {
            //Create object
            CommandInt command = new PlaceCubeCommand(hit.point, cubePrefab);
            CommandInvoker.AddCommand(command);
            newObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            newObj.transform.position = transform.position;
            command.Execute();
        }
        else if (itemOption == ItemList.Sphere) // sphere
        {
            //Create object
            newObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            newObj.transform.position = transform.position;
            newObj.AddComponent<Rigidbody>();
            newObj.layer = 9; // set to Spawned Objects layer

            //Add editor object component and feed it data.
            EditorObject eo = newObj.AddComponent<EditorObject>();
            eo.data.pos = newObj.transform.position;
            eo.data.objectType = EditorObject.ObjectType.Sphere;
        }
    }

}
