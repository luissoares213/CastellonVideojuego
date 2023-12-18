using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour {
  [Header("Game Elements")]

  [Range(1, 6)]

  [SerializeField] private int difficulty = 3;
  [SerializeField] private Transform gameHolder;
  [SerializeField] private Transform piecePrefab;

  [Header("UI Elements")]
  [SerializeField] private List<Texture2D> imageTextures;
  [SerializeField] private Transform levelSelectPanel;
  [SerializeField] private Image levelSelectPrefab;
  [SerializeField] private GameObject playAgainButton;

  private List<Transform> pieces;
  private Vector2Int dimensions;
  private float width;
  private float height;

  public const int DIMENSION_X = 6;
  public const int DIMENSION_Y = 7;

  public AudioSource woodblock2;

  public Texture2D textureStart;

  public bool[,] onspot = new bool[DIMENSION_Y,DIMENSION_X];
  public Transform[,] onspotP = new Transform[DIMENSION_Y,DIMENSION_X];
  public bool[,] occupied = new bool[DIMENSION_Y,DIMENSION_X]; // IMPORTANTE --> ESTAS SIGUIENTES HACEN REFERENCIA AL TABLERO
  public Vector2[,] otherPosition = new Vector2[DIMENSION_Y,DIMENSION_X];
  public Transform[,] otherPositionP = new Transform[DIMENSION_Y,DIMENSION_X]; // PIEZA SNAPPED EN UNA POSICION

  public Texture2D[] texturePiece = new Texture2D[9];
  public Transform[] piecePivot = new Transform[9];
  public bool[] sitioCorrecto = new bool[9];
  public int[] pieceZ = new int[9];
  


  private Transform draggingPiece = null;
  private Vector3 offset;
  public Vector3 altura = new Vector3(0,0,0.1f);

  private int piecesCorrect;

  void Start() {
    // Create the UI
    playAgainButton.SetActive(true);
    int i = 0;
    foreach (Texture2D texture in imageTextures) {
      if (texture.name != "Cake")
      {
        print(texture.name);
        texturePiece[i] = texture;
        Image imageTemp = Instantiate(levelSelectPrefab);
        if(i == 1)
        {
          imageTemp.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(166.5f, 48f));
        }
        else
        {
          imageTemp.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
        imageTemp.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        print(texturePiece[i]);
        pieceZ[i] = -1;
        i++;
      }
    }
    foreach (Texture2D texture in imageTextures) {
      if (texture.name == "Cake")
      {
      print(texture.name);
      Image image = Instantiate(levelSelectPrefab, levelSelectPanel);
      image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
      textureStart = texture;

      // Assign button action
      StartGame(texture);
      }
    }
  }

  public void PlayAudio()
  {
    woodblock2.Play();
  }

  public void StartGame(Texture2D jigsawTexture) {
    // Hide the UI
    levelSelectPanel.gameObject.SetActive(false);

    // We store a list of the transform for each jigsaw piece so we can track them later.
    pieces = new List<Transform>();

    // Calculate the size of each jigsaw piece, based on a difficulty setting.
    dimensions = GetDimensions(jigsawTexture, difficulty);

    // Create the pieces of the correct size with the correct texture.
    CreateJigsawPieces(jigsawTexture);

    // Place the pieces randomly into the visible area.
    Scatter();

    // Update the border to fit the chosen puzzle.
    UpdateBorder();

    // As we're starting the puzzle there will be no correct pieces.
    piecesCorrect = 0;
  }

  Vector2Int GetDimensions(Texture2D jigsawTexture, int difficulty) {
    Vector2Int dimensions = Vector2Int.zero;
    // Difficulty is the number of pieces on the smallest texture dimension.
    // This helps ensure the pieces are as square as possible.
    if (jigsawTexture.width < jigsawTexture.height) {
      dimensions.x = DIMENSION_X;
      dimensions.y = DIMENSION_Y;
    } else {
      dimensions.x = DIMENSION_X;
      dimensions.y = DIMENSION_Y;
    }
    return dimensions;
  }

  // Create all the jigsaw pieces
  void CreateJigsawPieces(Texture2D jigsawTexture) {
    // Calculate piece sizes based on the dimensions.
    height = 1f / dimensions.y;
    float aspect = (float)jigsawTexture.width / jigsawTexture.height;
    width = aspect / dimensions.x;

    for (int Irow = 0; Irow < dimensions.y; Irow++) 
        {
           for (int Jcol = 0; Jcol < dimensions.x; Jcol++) 
           {
            otherPosition[Irow,Jcol] = new((-width * dimensions.x / 2) + (width * Jcol) + (width / 2),
                                 (-height * dimensions.y / 2) + (height * Irow) + (height / 2));
            occupied[Irow,Jcol] = false;
            otherPositionP[Irow,Jcol] = null;
           }
        }
    /*
    for (int row = 0; row < dimensions.y; row++) {
      for (int col = 0; col < dimensions.x; col++) {
        // Create the piece in the right location of the right size.
        Transform piece = Instantiate(piecePrefab, gameHolder);
        piece.localPosition = new Vector3(
          (-width * dimensions.x / 2) + (width * col) + (width / 2),
          (-height * dimensions.y / 2) + (height * row) + (height / 2),
          -1);
        piece.localScale = new Vector3(width, height, 1f);

        // We don't have to name them, but always useful for debugging.
        piece.name = $"Piece {(row * dimensions.x) + col}";

        onspot[row,col] = false;
        onspotP[row,col] = piece;

        pieces.Add(piece);

        
      
        // Assign the correct part of the texture for this jigsaw piece
        // We need our width and height both to be normalised between 0 and 1 for the UV.
        float width1 = 1f / dimensions.x;
        float height1 = 1f / dimensions.y;
        // UV coord order is anti-clockwise: (0, 0), (1, 0), (0, 1), (1, 1)
        Vector2[] uv = new Vector2[4];
        uv[0] = new Vector2(width1 * col, height1 * row);
        uv[1] = new Vector2(width1 * (col + 1), height1 * row);
        uv[2] = new Vector2(width1 * col, height1 * (row + 1));
        uv[3] = new Vector2(width1 * (col + 1), height1 * (row + 1));
        // Assign our new UVs to the mesh.
        Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
        mesh.uv = uv;
        // Update the texture on the piece
        piece.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", jigsawTexture);
    
      
      }
    }
    */
    for( int i = 0; i < texturePiece.Length; i++)
    {
      piecePivot[i] = Instantiate(piecePrefab, gameHolder);
        piecePivot[i].localPosition = new Vector3(0, 0,
          -1);
        piecePivot[i].localScale = new Vector3(width, height, 1f);
        if (i == 0)
        {
          piecePivot[i].localScale = new Vector3(width * 3, height * 7, 1f);
        }
        else if (i == 1)
        {
          piecePivot[i].localScale = new Vector3(width * 2, height * 2, 1f);
        }
        else if (i == 2)
        {
          piecePivot[i].localScale = new Vector3(width , height , 1f);
        }
        else if (i == 3)
        {
          piecePivot[i].localScale = new Vector3(width * 2, height * 3, 1f);
        }
        else if (i == 4)
        {
          piecePivot[i].localScale = new Vector3(width * 2, height * 3, 1f);
        }
        else if (i == 5)
        {
          piecePivot[i].localScale = new Vector3(width * 2, height * 3, 1f);
        }
        else if (i == 6)
        {
          piecePivot[i].localScale = new Vector3(width * 2, height , 1f);
        }
        else if (i == 7)
        {
          piecePivot[i].localScale = new Vector3(width , height * 3, 1f);
        }
        else if (i == 8)
        {
          piecePivot[i].localScale = new Vector3(width * 3, height * 2, 1f);
        }
        else
        {
          piecePivot[i].localScale = new Vector3(width, height, 1f);
        }
        

        piecePivot[i].GetComponent<MeshRenderer>().material.mainTexture = texturePiece[i];
        sitioCorrecto[i] = false;
    }
  }

  // Place the pieces randomly in the visible area.
  private void Scatter() {
    // Calculate the visible orthographic size of the screen.
    float orthoHeight = Camera.main.orthographicSize;
    float screenAspect = (float)Screen.width / Screen.height;
    float orthoWidth = (screenAspect * orthoHeight);

    // Ensure pieces are away from the edges.
    float pieceWidth = width * gameHolder.localScale.x;
    float pieceHeight = height * gameHolder.localScale.y;

    orthoHeight -= pieceHeight;
    orthoWidth -= pieceWidth;

    // Place each piece randomly in the visible area.
    foreach (Transform piece in pieces) {
      float x = Random.Range(-orthoWidth, orthoWidth);
      float y = Random.Range(-orthoHeight, orthoHeight);
      piece.position = new Vector3(x, y, -1);
    }
    for( int i = 0; i < texturePiece.Length; i++)
    {
      if (i == 0)
      {
        piecePivot[i].position = new Vector3(-6, 0, -1);
      }
      else if (i == 1)
      {
        piecePivot[i].position = new Vector3(-7.5f, 3.5f, -1);
      }
      else if (i == 3)
      {
        piecePivot[i].position = new Vector3(-3f, -2, -1);
      }
      else if (i == 4)
      {
        piecePivot[i].position = new Vector3(4f, 1, -1);
      }
       else if (i == 5)
      {
        piecePivot[i].position = new Vector3(7f, 1.5f, -1);
      }
       else if (i == 7)
      {
        piecePivot[i].position = new Vector3(5.5f, 0, -1);
      }
       else if (i == 8)
      {
        piecePivot[i].position = new Vector3(6f, -3.5f, -1);
      }
      else
      {
        piecePivot[i].position = new Vector3(-7.5f + 2 *i, 3.5f, -1);
      }
      
    }
  }

  // Update the border to fit the chosen puzzle.
  private void UpdateBorder() {
    LineRenderer lineRenderer = gameHolder.GetComponent<LineRenderer>();

    // Calculate half sizes to simplify the code.
    float halfWidth = (width * dimensions.x) / 2f;
    float halfHeight = (height * dimensions.y) / 2f;

    // We want the border to be behind the pieces.
    float borderZ =  0f;

    // Set border vertices, starting top left, going clockwise.
    lineRenderer.SetPosition(0, new Vector3(-halfWidth, halfHeight, borderZ));
    lineRenderer.SetPosition(1, new Vector3(halfWidth, halfHeight, borderZ));
    lineRenderer.SetPosition(2, new Vector3(halfWidth, -halfHeight, borderZ));
    lineRenderer.SetPosition(3, new Vector3(-halfWidth, -halfHeight, borderZ));

    // Set the thickness of the border line.
    Color black = new Color(1,1,1,1);
    lineRenderer.startWidth = 0.1f;
    lineRenderer.endWidth = 0.1f;

    // Show the border line.
    lineRenderer.enabled = true;
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetMouseButtonDown(0)) {
      RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
      if (hit) {
        // Everything is moveable, so we don't need to check it's a Piece.
        print("imagina");
        draggingPiece = hit.transform;
        offset = draggingPiece.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset += Vector3.back;

         int ind = -1;

        for(int i = 0; i< texturePiece.Length; i++) 
              if(piecePivot[i] == draggingPiece)
              {
                ind = i;
                break;
              } 
        for(int iZ = 0; iZ< texturePiece.Length; iZ++)
              {
                if(pieceZ[iZ] == ind)
                {
                  draggingPiece.position -= altura * (texturePiece.Length - (iZ + 1));
                  for(int jZ = iZ; jZ< texturePiece.Length; jZ++)
                  {
                    if(jZ == (texturePiece.Length-1)) pieceZ[jZ] = -1;
                    else
                    {
                      pieceZ[jZ] = pieceZ[jZ+1];
                    }
                  }
                  break;
                }
              }
        

        for (int Irow = 0; Irow < dimensions.y; Irow++) 
        {
           for (int Jcol = 0; Jcol < dimensions.x; Jcol++) 
           {
            if( onspotP[Irow,Jcol] == draggingPiece)
              {
                onspot[Irow,Jcol] = false;
                //print("la pieza" + row + col + "ha sido agarrada");
                break;
              }              
           }
        }
        // REVISAR SI ESTÁ EN EL TABLERO
        for (int Irow = 0; Irow < dimensions.y; Irow++) 
        {
           for (int Jcol = 0; Jcol < dimensions.x; Jcol++) 
           {
            if( otherPositionP[Irow,Jcol] == draggingPiece)
              {
                otherPositionP[Irow,Jcol] = null;
                occupied[Irow,Jcol] = false;
                break;
              }              
           }
        }

      }
    }

    // When we release the mouse button stop dragging.
    if (draggingPiece && Input.GetMouseButtonUp(0)) {
      SnapAndDisableIfCorrect();
      //draggingPiece.position += Vector3.forward;
      draggingPiece = null;
    }

    // Set the dragged piece position to the position of the mouse.
    if (draggingPiece) {
      Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      //newPosition.z = draggingPiece.position.z;
      newPosition += offset;
      draggingPiece.position = newPosition;
    }
  }

  private void SnapAndDisableIfCorrect() {
    // We need to know the index of the piece to determine it's correct position.
    int pieceIndex = pieces.IndexOf(draggingPiece);

    // The coordinates of the piece in the puzzle.
    int col = pieceIndex % dimensions.x;
    int row = pieceIndex / dimensions.x;
    Vector2 desplazamiento = new Vector2(0,0);

    // The target position in the non-scaled coordinates.

    if(draggingPiece == piecePivot[0]) //Pala
    {
      col = 2;
      row = 3;
    }
    else if(draggingPiece == piecePivot[1]) //Brujula
    {
      col = 5;
      row = 0;
    }
    else if(draggingPiece == piecePivot[2]) //Cepillo
    {
      col = 3;
      row = 1;
    }
    else if(draggingPiece == piecePivot[3]) //Cantimplora
    {
      col = 0;
      row = 3;
    }
    else if(draggingPiece == piecePivot[4]) //Cuchillo
    {
      col = 0;
      row = 1;
    }
    else if(draggingPiece == piecePivot[5]) //Reloj
    {
      col = 4;
      row = 3;
    }
    else if(draggingPiece == piecePivot[6]) //Cerillas
    {
      col = 0;
      row = 6;
    }
    else if(draggingPiece == piecePivot[7]) //Pan
    {
      col = 5;
      row = 3;
    }
    else if(draggingPiece == piecePivot[8]) //Botiquín
    {
      col = 4;
      row = 6;
    }
    Vector2 targetPosition = new((-width * dimensions.x / 2) + (width * col) + (width / 2),
                                 (-height * dimensions.y / 2) + (height * row) + (height / 2));

    if(draggingPiece == piecePivot[1])
    {
      desplazamiento -= new Vector2(width/2,-height/2);
      
    }
    if(draggingPiece == piecePivot[3])
    {
      desplazamiento += new Vector2(width/2,height);
    }
    if(draggingPiece == piecePivot[4])
    {
      desplazamiento += new Vector2(width/2,0);
    }
    if(draggingPiece == piecePivot[5])
    {
      desplazamiento -= new Vector2(width/2,0);
    }

    if(draggingPiece == piecePivot[6])
    {
      desplazamiento += new Vector2(width/2,0);   
    }
    if(draggingPiece == piecePivot[8])
    {
      desplazamiento -= new Vector2(0,height/2);   
    }
    targetPosition = targetPosition + desplazamiento;
    print(col);
    print(row);
    // Snap to our destination.
    for (int Irow = 0; Irow < dimensions.y; Irow++) 
        {
           for (int Jcol = 0; Jcol < dimensions.x; Jcol++) 
           {
            
            if (Vector2.Distance(draggingPiece.localPosition, otherPosition[Irow,Jcol] + desplazamiento) < (width / 2) & occupied[Irow,Jcol] == false)
            {
              if(piecePivot[0] == draggingPiece & (Irow != 3 || Jcol < 1 || Jcol > 4) ) break;
              if(piecePivot[1] == draggingPiece & (Irow > 5 || Jcol < 1) ) break;
              if(piecePivot[3] == draggingPiece & (Irow > 4 || Jcol > 4) ) break;
              if(piecePivot[4] == draggingPiece & (Irow < 1 || Irow > 5 || Jcol > 4) ) break;
              if(piecePivot[5] == draggingPiece & (Jcol < 1 || Irow > 5 || Irow < 1) ) break;
              if(piecePivot[6] == draggingPiece & (Jcol > 4) ) break;
              if(piecePivot[7] == draggingPiece & (Irow > 5 || Irow < 1 ) ) break;
              if(piecePivot[8] == draggingPiece & (Jcol < 1 || Irow < 1 || Jcol > 4) ) break;


              draggingPiece.localPosition = otherPosition[Irow,Jcol] + desplazamiento;
              otherPositionP[Irow,Jcol] = draggingPiece;
              occupied[Irow,Jcol] = true;

              PlayAudio();

              int ind = -1;

              for(int i = 0; i< texturePiece.Length; i++) 
              if(piecePivot[i] == draggingPiece)
              {
                ind = i;
                print("yep");
                break;
              } 
              for(int iZ = 0; iZ< texturePiece.Length; iZ++)
              {
                if(pieceZ[iZ] == -1)
                {
                  pieceZ[iZ] = ind;
                  print(ind);
                  print(iZ);                  
                  draggingPiece.position += altura * (texturePiece.Length - (iZ + 1));
                  break;
                }
              }
              
            }
           }
        }

    // Check if we're in the correct location.
    for(int ig = 0; ig < 2; ig++)
    {
    if(ig == 1)
    {
      if(draggingPiece == piecePivot[2]) //Cepillo
    {
      col = 3;
      row = 6;
      targetPosition = new((-width * dimensions.x / 2) + (width * col) + (width / 2),
                                 (-height * dimensions.y / 2) + (height * row) + (height / 2));
    }
      if(draggingPiece == piecePivot[1]) //Brujula
    {
      col = 5;
      row = 5;
      targetPosition = new((-width * dimensions.x / 2) + (width * col) + (width / 2),
                                 (-height * dimensions.y / 2) + (height * row) + (height / 2));
      print("uep");
    }
    else if(draggingPiece == piecePivot[8]) //Botiquín
    {
      col = 4;
      row = 1;
      targetPosition = new((-width * dimensions.x / 2) + (width * col) + (width / 2),
                                 (-height * dimensions.y / 2) + (height * row) + (height / 2));
      print("eyep");
    }
     targetPosition = targetPosition + desplazamiento;

    }
    if (Vector2.Distance(draggingPiece.localPosition, targetPosition) < (width / 2)) {
      
      
      

      // Disable the collider so we can't click on the object anymore.
      //draggingPiece.GetComponent<BoxCollider2D>().enabled = false;

      // Increase the number of correct pieces, and check for puzzle completion.
      
      

      for (int Irow = 0; Irow < dimensions.y; Irow++) 
        {
           for (int Jcol = 0; Jcol < dimensions.x; Jcol++) 
           {
            for( int i = 0; i < texturePiece.Length; i++)
            if (piecePivot[i] == draggingPiece & otherPositionP[Irow,Jcol] == draggingPiece)
            {
              print("la pieza" + piecePivot[0] + "ha sido colocada en el sitio correcto");
              sitioCorrecto[i] = true;
            }
            if( onspotP[Irow,Jcol] == draggingPiece)
              {
                onspot[Irow,Jcol] = true;
                print("la pieza" + Irow + Jcol + "ha sido colocada en el sitio correcto");
                break;
              }
            
            
           }
        }
      
      piecesCorrect = 0;

      for (int Irow = 0; Irow < dimensions.y; Irow++) 
        {
           for (int Jcol = 0; Jcol < dimensions.x; Jcol++) 
           {
            if( onspot[Irow,Jcol] == true)
              {
                piecesCorrect++;
              }
           }
        }
      for( int i = 0; i < texturePiece.Length; i++)
      {
        if(sitioCorrecto[i] == true) piecesCorrect++;
      }
      if (piecesCorrect == piecePivot.Length) {
        print("Bien Hecho!");
        SceneManager.LoadScene("MenuInicial");
      }
      break;
    }
    else 
    {
    for (int Irow = 0; Irow < dimensions.y; Irow++) 
        {
           for (int Jcol = 0; Jcol < dimensions.x; Jcol++) 
           {
            for( int i = 0; i < texturePiece.Length; i++)
            if (piecePivot[i] == draggingPiece & otherPositionP[Irow,Jcol] == draggingPiece)
            {
              print("la pieza" + piecePivot[0] + "ha sido colocada en el sitio incorrecto");
              sitioCorrecto[i] = false;
            }
            if( onspotP[Irow,Jcol] == draggingPiece)
              {
                onspot[Irow,Jcol] = false;
                print("la pieza" + Irow + Jcol + "ha sido colocada en el sitio incorrecto");
                break;
              }
           }
        }
    }

    }
    
  }

  public void RestartGame() {
    print("opa");
    // Destroy all the puzzle pieces.
    foreach (Transform piece in pieces) {
      Destroy(piece.gameObject);
    }
    for( int i = 0; i < texturePiece.Length; i++)
    {
      Destroy(piecePivot[i].gameObject);
    }
    pieces.Clear();
    // Hide the outline
    gameHolder.GetComponent<LineRenderer>().enabled = false;
    // Show the level select UI.
    StartGame(textureStart);
  }
}
