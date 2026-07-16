using UnityEngine;
using UnityEngine.Events;

public class PiecesGenerator : MonoBehaviour
{

    [SerializeField] GameObject piecesPrefabs ;


    private GameObject lastGeneratedPiece ;
    private BuildingHight buildingHight;
    private Transform mainCamera;

    [SerializeField] private UnityEvent OnNewPiece ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main.transform;
        buildingHight = GetComponent<BuildingHight>();
        pieceSpawn();
        
        
    }

    // Update is called once per frame
    void Update()
    {
          if ( lastGeneratedPiece == null) return;

        Vector3 playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 cameraDirection = mainCamera.TransformDirection(playerInput);
        cameraDirection.y = 0;

        lastGeneratedPiece.transform.position += cameraDirection.normalized * Time.deltaTime * 3;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NewPiece();
            Invoke(nameof(pieceSpawn), 3f);
        }
    }

    public void pieceSpawn()
    {
        lastGeneratedPiece = Instantiate(piecesPrefabs, new Vector3(Random.Range(-3, 4), buildingHight.CurrentHight() + 2, Random.Range(-3, 4)), Quaternion.identity);

        int scaleX = Random.Range(1, 7);
        int scaleY = Random.Range(1, 5);
        int scaleZ = Random.Range(1, 7);

        lastGeneratedPiece.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        lastGeneratedPiece.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }
    
    
    private void NewPiece()
    {
        lastGeneratedPiece.GetComponent<Rigidbody>().useGravity = true;
        lastGeneratedPiece.transform.GetChild(0).gameObject.SetActive(false);
        lastGeneratedPiece = null;

        OnNewPiece.Invoke();
    }

    
}