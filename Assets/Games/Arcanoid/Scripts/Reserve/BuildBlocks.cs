using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBlocks : MonoBehaviour
{
    private GameObject _block;
    [SerializeField] private GameObject _mainBlocks;
    //private GameObject _pok;
    [SerializeField] private List<GameObject> _blocks = new List<GameObject>(); // список блоков, которые нужно поставить
    [SerializeField] public static List<GameObject> _standartStartBlocks = new List<GameObject>(); // список стартовых блоков на сцене
    [SerializeField] public static List<GameObject> _smallStartBlocks = new List<GameObject>(); // список маленьких стартовых блоков на сцене
    [SerializeField] public static List<GameObject> _bigStartBlocks = new List<GameObject>(); // список больших стартовых блоков на сцене
    //[SerializeField] public static GameObject[] _startBlocks;
    //[SerializeField] private GameObject[] _smallStartBlocks;
    //[SerializeField] private GameObject[] _bigStartBlocks;
    void Start()
    {
        
        //_bigStartBlocks = FindObjectsOfType<BigStartBlock>();
        //_smallStartBlocks = FindObjectsOfType<SmallStartBlock>();
        //_pok = _startBlocks[5];
        //Debug.Log(_pok.name);

        BuildLevel();

    }
    private void BuildLevel()
    {
        foreach (var item in _smallStartBlocks) //перебираем массив маленьких блоков
        {
            Vector2 _pos = item.transform.position; // запоминает положение объекта
            Destroy(item.gameObject); //уничтожает объект
            int rand = Random.Range(0, 3);
            _block = Instantiate(_blocks[rand], _pos, Quaternion.identity); // создает новый объект на месте уничтоженного
            _block.transform.SetParent(_mainBlocks.transform);

            Debug.Log("Small");
        }

        foreach (var item in _standartStartBlocks) //перебираем массив
        {
            Vector2 _pos = item.transform.position; // запоминает положение объекта
            Destroy(item.gameObject); //уничтожает объект
            int rand = Random.Range(3, 6);
            _block = Instantiate(_blocks[rand], _pos, Quaternion.Euler(0f, 0f, -90f)); // создает новый объект на месте уничтоженного
            _block.transform.SetParent(_mainBlocks.transform);
            Debug.Log("Standart");
        }

        foreach (var item in _bigStartBlocks) //перебираем массив больших блоков
        {
            Vector2 _pos = item.transform.position; // запоминает положение объекта
            Destroy(item.gameObject); //уничтожает объект
            int rand = Random.Range(6, 9);
            _block = Instantiate(_blocks[rand], _pos, Quaternion.identity); // создает новый объект на месте уничтоженного
            _block.transform.SetParent(_mainBlocks.transform);
            Debug.Log("Big");
        }

    }
}
