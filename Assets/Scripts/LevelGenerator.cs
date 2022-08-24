using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _blocks;
    [SerializeField] private Transform _currentPoint;

    
    void Start()
    {
        FT();
    }
    private void FT()
    {
        int preForkLength = Random.Range(3, 8);
        int forkLength = Random.Range(2, 5);
        int postForkLength = 11 - preForkLength - forkLength;
        int j = 0;
        float forkZIndex, postForkZIndex;
        float tempH = 0f;
        Debug.Log($"{preForkLength+forkLength+postForkLength},{preForkLength},{forkLength},{postForkLength}");

        for ( int i = 0; j < preForkLength; j++)
        {
            Instantiate(_blocks[j], _currentPoint.position, Quaternion.identity);
            _currentPoint.position += new Vector3(SizeX(_blocks[j]), 0, 0);
        }
        tempH = _currentPoint.position.y;


        postForkZIndex = _currentPoint.position.y;
        _currentPoint.position -= new Vector3(0f, _currentPoint.position.y - 0.4f * _blocks[0].transform.localScale.y , 0f);
        forkZIndex = _currentPoint.position.y;
        Debug.Log("y pos = " + postForkZIndex);

        for (int i = 0; i < forkLength; i++)
        {
            for (int k = 0; k < 2; k++)
            {
                Instantiate(_blocks[j], _currentPoint.position, Quaternion.identity);
                _currentPoint.position = new Vector3(_currentPoint.position.x, postForkZIndex - 0.6f* _blocks[0].transform.localScale.y, 0);
            }
            Debug.Log("y pos = " + postForkZIndex);

            _currentPoint.position = new Vector3(_currentPoint.position.x + SizeX(_blocks[0]),forkZIndex, 0);
            j++;
        }

        _currentPoint.position = new Vector3(_currentPoint.position.x + _blocks[0].transform.position.x, postForkZIndex, 0);


        for (int i = 0; i < postForkLength; i++)
        {
            Instantiate(_blocks[j], _currentPoint.position, Quaternion.identity);
            _currentPoint.position += new Vector3(_blocks[0].transform.localScale.x, 0, 0);
            j++;
        }


    }

    private float SizeX(GameObject gO)
    {
        return gO.transform.localScale.x;
    }
}
