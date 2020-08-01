using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Config
{
    #region Private fields
    private Dictionary<string, int> nameID;
    private Dictionary<int, object> parameters;
    #endregion

    public Config()
    {
        nameID = new Dictionary<string, int>();
        parameters = new Dictionary<int, object>();
    }

    #region Save&load parameters
    public void LoadParameters()
    {
        using (StreamReader sr = File.OpenText("config.json"))
        {
            Config cfg = JsonUtility.FromJson<Config>(sr.ReadToEnd());
            nameID = cfg.nameID;
            parameters = cfg.parameters;
        }
    }
    public void SaveParameters()
    {
        using (StreamWriter sw = new StreamWriter("config.json"))
        {
            sw.Write(JsonUtility.ToJson(this));
        }
    }
    #endregion

    #region Get parameters by name
    // If parameter with this name not found - returned null
    public object GetParameter(string name)
    {
        try
        {
            return GetParameter(GetParameterID(name));
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }
    public bool? GetBool(string name)
    {
        try
        {
            return GetBool(GetParameterID(name));
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }
    public char? GetChar(string name)
    {
        try
        {
            return GetChar(GetParameterID(name));
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }
    public int? GetInt(string name)
    {
        try
        {
            return GetInt(GetParameterID(name));
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }
    public float? GetFloat(string name)
    {
        try
        {
            return GetFloat(GetParameterID(name));
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }
    public Vector3? GetVector3(string name)
    {
        try
        {
            return GetVector3(GetParameterID(name));
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }
    public Quaternion? GetQuaternion(string name)
    {
        try
        {
            return GetQuaternion(GetParameterID(name));
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }
    public string GetString(string name)
    {
        try
        {
            return GetString(GetParameterID(name));
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }
    public KeyCode? GetKeyCode(string name)
    {
        try
        {
            return GetKeyCode(GetParameterID(name));
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }
    #endregion

    #region Get parameters by ID
    // If parameter with this ID not found - returned null
    public object GetParameter(int parameterID)
    {
        try
        {
            return parameters[parameterID];
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }
    public bool? GetBool(int parameterID)
    {
        try
        {
            return (bool)parameters[parameterID];
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }
    public char? GetChar(int parameterID)
    {
        try
        {
            return (char)parameters[parameterID];
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }
    public int? GetInt(int parameterID)
    {
        try
        {
            return (int)parameters[parameterID];
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }
    public float? GetFloat(int parameterID)
    {
        try
        {
            return (float)parameters[parameterID];
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }
    public Vector3? GetVector3(int parameterID)
    {
        try
        {
            return (Vector3)parameters[parameterID];
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }
    public Quaternion? GetQuaternion(int parameterID)
    {
        try
        {
            return (Quaternion)parameters[parameterID];
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }
    public string GetString(int parameterID)
    {
        try
        {
            return (string)parameters[parameterID];
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }
    public KeyCode? GetKeyCode(int parameterID)
    {
        try
        {
            return (KeyCode)parameters[parameterID];
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }
    #endregion

    #region Set parameters by name
    public void SetParameter(string name, object value)
    {
        SetParameter(GetParameterID(name), value);
    }
    public void SetBool(string name, bool value)
    {
        SetBool(GetParameterID(name), value);
    }
    public void SetChar(string name, char value)
    {
        SetChar(GetParameterID(name), value);
    }
    public void SetInt(string name, int value)
    {
        SetInt(GetParameterID(name), value);
    }
    public void SetFloat(string name, float value)
    {
        SetFloat(GetParameterID(name), value);
    }
    public void SetVector3(string name, Vector3 value)
    {
        SetVector3(GetParameterID(name), value);
    }
    public void SetQuaternion(string name, Quaternion value)
    {
        SetQuaternion(GetParameterID(name), value);
    }
    public void SetString(string name, string value)
    {
        SetString(GetParameterID(name), value);
    }
    public void SetKeyCode(string name, KeyCode value)
    {
        SetKeyCode(GetParameterID(name), value);
    }
    #endregion

    #region Set parameters by ID
    public void SetParameter(int parameterID, object value)
    {
        parameters[parameterID] = value;
    }
    public void SetBool(int parameterID, bool value)
    {
        parameters[parameterID] = value;
    }
    public void SetChar(int parameterID, char value)
    {
        parameters[parameterID] = value;
    }
    public void SetInt(int parameterID, int value)
    {
        parameters[parameterID] = value;
    }
    public void SetFloat(int parameterID, float value)
    {
        parameters[parameterID] = value;
    }
    public void SetVector3(int parameterID, Vector3 value)
    {
        parameters[parameterID] = value;
    }
    public void SetQuaternion(int parameterID, Quaternion value)
    {
        parameters[parameterID] = value;
    }
    public void SetString(int parameterID, string value)
    {
        parameters[parameterID] = value;
    }
    public void SetKeyCode(int parameterID, KeyCode value)
    {
        parameters[parameterID] = value;
    }
    #endregion

    #region Add parameters
    public void AddParameter(string name, int id, object value)
    {
        nameID.Add(name, id);
        parameters.Add(id, value);
    }
    /// <summary>
    /// Add empty parameter with getted name, ID and type
    /// </summary>
    /// <remarks>Type can be only: bool, char, int, float, string, Vector3, Quanternion, KeyCode</remarks>
    public void AddParameter(string name, int id, Type type)
    {
        object value;
        if (type == typeof(bool))
        {
            value = false;
        }
        else if (type == typeof(char))
        {
            value = '\0';
        }
        else if (type == typeof(int))
        {
            value = 0;
        }
        else if (type == typeof(float))
        {
            value = 0f;
        }
        else if (type == typeof(Vector3))
        {
            value = new Vector3();
        }
        else if (type == typeof(Quaternion))
        {
            value = new Quaternion();
        }
        else if (type == typeof(string))
        {
            value = "";
        }
        else if (type == typeof(KeyCode))
        {
            value = KeyCode.None;
        }
        else
        {
            throw new ArgumentException($"Not valid type of parameter '{type.Name}'");
        }
        AddParameter(name, id, value);
    }
    public void AddParameter(string name, Type type)
    {
        int id = (int) new System.Random().NextDouble() * 1000; // 5-значный ID
        if (parameters.ContainsKey(id))
            AddParameter(name, type);
        else
            AddParameter(name, id, type);
    }
    public void AddParameter(string name, object value)
    {
        int id = (int)new System.Random().NextDouble() * 1000; // 5-значный ID
        if (parameters.ContainsKey(id))
            AddParameter(name, value);
        else
            AddParameter(name, id, value);
    }
    #endregion

    /// <summary>
    /// Get parameter ID by name
    /// </summary>
    /// <param name="name">Name of parameter for ID</param>
    /// <returns>Parameter ID or if this ID not exists - return -1</returns>
    public int GetParameterID(string name)
    {
        try
        {
            return nameID[name];
        }
        catch (KeyNotFoundException)
        {
            return -1;
        }
    }
}
