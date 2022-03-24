using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class TetroCourrant : MonoBehaviour
{
    #region 
        
    public GameObject TetroI;
    public GameObject TetroJ;
    public GameObject TetroL;
    public GameObject TetroO;
    public GameObject TetroS;
    public GameObject TetroZ;
    public GameObject TetroT;
        
    #endregion
    
    public GameObject tetroGenerator;
    private TetroGenerator _tetroGenerator;

    public GameObject _shapeTetromino;
    
    public float temps;
    public float tempsChute = 0.5f;

    private const int DistanceCarre = 50;
    
    
    
    // Start is called before the first frame update
    public void InitialiserTetromino()
    {
        _tetroGenerator = tetroGenerator.GetComponent<TetroGenerator>();
        
        _tetroGenerator.ListTetrominos = new Queue<TypeTetromino>(10);
        while (_tetroGenerator.ListTetrominos.Count < 10)
        {
            _tetroGenerator.GenerateTetro();
        }
        
    }
    
    public void UpdateTetromino()
    {
        if (_shapeTetromino == null)
        {
            switch (_tetroGenerator.ListTetrominos.Dequeue())
            {
                case TypeTetromino.TetroI:
                    _shapeTetromino = Instantiate(TetroI, new Vector3(200, 950, 0), Quaternion.identity);
                    break;
                case TypeTetromino.TetroJ:
                    _shapeTetromino = Instantiate(TetroJ, new Vector3(200, 950, 0), Quaternion.identity);
                    break;
                case TypeTetromino.TetroL:
                    _shapeTetromino = Instantiate(TetroL, new Vector3(200, 950, 0), Quaternion.identity);
                    break;
                case TypeTetromino.TetroO:
                    _shapeTetromino = Instantiate(TetroO, new Vector3(200, 950, 0), Quaternion.identity);
                    break;
                case TypeTetromino.TetroS:
                    _shapeTetromino = Instantiate(TetroS, new Vector3(200, 950, 0), Quaternion.identity);
                    break;
                case TypeTetromino.TetroZ:
                    _shapeTetromino = Instantiate(TetroZ, new Vector3(200, 950, 0), Quaternion.identity);
                    break;
                case TypeTetromino.TetroT:
                    _shapeTetromino = Instantiate(TetroT, new Vector3(200, 950, 0), Quaternion.identity);
                    break;
                default:
                    _shapeTetromino = null;
                    break;
            }
        }
        
        if (_tetroGenerator.ListTetrominos.Count < 10)
        {
            _tetroGenerator.GenerateTetro();
        }
    }
    
    public void AGauche()
    {
        Debug.Log("Déplacement gauche");
        _shapeTetromino.transform.position += new Vector3(-1 * DistanceCarre, 0, 0);
        //transform.position += new Vector3(-50, 0, 0);
    }
           
    public void ADroite()
    {
        Debug.Log("Déplacement droit");
        _shapeTetromino.transform.position += new Vector3(1 * DistanceCarre, 0, 0);
        //transform.position += new Vector3(50, 0, 0);
    
    }
           
    public void Descente()
    {
        Debug.Log("Descente verticale plus rapide de la pièce");
        _shapeTetromino.transform.position += new Vector3(0, -1, 0);
        //transform.position += new Vector3(0, -50, 0);
    }
            
    public void RotationGauche()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        { 
            Debug.Log("Flèche haut appuyée : effectuer la rotation à gauche de la pièce de 90°"); 
            transform.Rotate(0, 0, -90);
        }
                
    }
            
    public void RotationDroite()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Flèche haut appuyée : effectuer la rotation à droite de la pièce de 90°");
            transform.Rotate(0, 0, 90);
        }
    }
    
    public void Chute()
    {
        if (Time.time - temps > tempsChute)
        {
            _shapeTetromino.transform.position += new Vector3(0, -1 * DistanceCarre, 0);
            temps = Time.time;
        }
    }
}
        
