using Snappy.Sharp;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour {

    public Text text;
    public InputField input;

    public Text item;
    public Transform resultNode;

	// Use this for initialization
	void Start () {
        Application.logMessageReceived += OnLogMessageReceived;
        onClickLoad();
	}

    private void OnLogMessageReceived(string condition, string stackTrace, LogType type)
    {
        Text newLog = GameObject.Instantiate(item);
        newLog.text = "=>" + condition;
        newLog.transform.SetParent(resultNode, false);
        newLog.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void onClickLoad()
    {
        this.input.text = text.text;
    }

    public void onClickDecompress()
    {
        string text = this.input.text;
        Debug.Log("Depress:" + text);

        string[] txts = text.Trim().Split(',');
        Debug.Log("src Length:" + txts.Length);

        //byte[] byteArray = System.Text.Encoding.Default.GetBytes(text);

        byte[] compressed = new byte[txts.Length];
        for (int i = 0; i < txts.Length; ++i)
        {
            compressed[i] = (byte)Convert.ToSByte(txts[i]);
        }

        var target = new SnappyDecompressor();
        var data = target.Decompress(compressed, 0, compressed.Length);

        Debug.Log("Depress Length:" + data.Length);

        string result = System.Text.Encoding.UTF8.GetString(data);
        Debug.Log("result:" + result);
    }
}
