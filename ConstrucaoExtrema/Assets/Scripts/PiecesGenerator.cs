using UnityEngine;

public class PiecesGenerator : MonoBehaviour
{

    [SerializeField] GameObject piecesPrefabs ;


    private GameObject lastGeneratedPiece ;
    private BuildingHight buildingHight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buildingHight = GetComponent<BuildingHight>();
        pieceSpawn();
        
        
    }

    // Update is called once per frame
    void Update()
    {
          if ( lastGeneratedPiece == null) return;

        Vector2 playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        lastGeneratedPiece.transform.position += new Vector3(playerInput.x, 0, playerInput.y) * Time.deltaTime * 3;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PieceRelease();
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
    
    
    private void PieceRelease()
    {
        lastGeneratedPiece.GetComponent<Rigidbody>().useGravity = true;
        lastGeneratedPiece = null;
    }

    
}