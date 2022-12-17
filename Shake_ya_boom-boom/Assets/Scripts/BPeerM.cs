using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPeerM : MonoBehaviour
{
    private static BPeerM _BPeerMInstatce;
    public float _bpm;
    private float _beatInterval, _beatTimer, _beatIntervalD8, _beatTimerD8, _beatIntervalD16, _beatTimerD16;
    public static bool _beatFull, _beatD8, _beatD16;
    public static int _beatCountFull, _beatCountD8, _beatCountD16;

    private void Awake()
    {
        if (_BPeerMInstatce != null && _BPeerMInstatce != this)
        {
            Destroy(this.gameObject);
        }
        else 
        {
            _BPeerMInstatce = this;
            DontDestroyOnLoad(this.gameObject);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BeatDetection();
    }

    void BeatDetection()
    {
        //full beat count - рассчет бита на 4/4, 8/4, 16/4, 32/4

        _beatFull = false;
        _beatInterval = 60 / _bpm;
        _beatTimer += Time.deltaTime;
        if (_beatTimer >= _beatInterval)
        {
            _beatTimer -= _beatInterval;
            _beatFull = true;
            _beatCountFull++;
            Debug.Log("Beat_Full");
        }

        //divided beat count - рассчет бита на 8/4, 16/4, 32/4
        _beatD8 = false;
        _beatIntervalD8 = _beatInterval / 8;
        _beatTimerD8 += Time.deltaTime;
        if (_beatTimerD8 >= _beatIntervalD8)
        {
            _beatTimerD8 -= _beatIntervalD8;
            _beatD8 = true;
            _beatCountD8++;
            Debug.Log("Beat_8");
        }

        _beatD16 = false;
        _beatIntervalD16 = _beatInterval / 16;
        _beatTimerD16 += Time.deltaTime;
        if (_beatTimerD16 >= _beatIntervalD16)
        {
            _beatTimerD16 -= _beatIntervalD16;
            _beatD16 = true;
            _beatCountD16++;
            Debug.Log("Beat_16");
        }

    }

}
