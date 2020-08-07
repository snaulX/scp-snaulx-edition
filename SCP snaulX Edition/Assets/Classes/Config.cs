using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class Config
{
    #region Fields
    public Dictionary<string, int> nameID = new Dictionary<string, int>();
    public Dictionary<int, object> parameters = new Dictionary<int, object>();
    public Dictionary<int, bool> parametersBool = new Dictionary<int, bool>();
    public Dictionary<int, char> parametersChar = new Dictionary<int, char>();
    public Dictionary<int, int> parametersInt = new Dictionary<int, int>();
    public Dictionary<int, float> parametersFloat = new Dictionary<int, float>();
    public Dictionary<int, string> parametersString = new Dictionary<int, string>();
    public Dictionary<int, float[]> parametersVector = new Dictionary<int, float[]>(),
        parametersQuaternion = new Dictionary<int, float[]>();
    public Dictionary<int, KeyCode> parametersKey = new Dictionary<int, KeyCode>();
    #endregion

    #region Save&load parameters
    public void LoadParameters()
    {
        using (StreamReader sr = File.OpenText("config.json"))
        {
            Config cfg = JsonConvert.DeserializeObject<Config>(sr.ReadToEnd());
            nameID = cfg.nameID;
            parameters = cfg.parameters;
            parametersBool = cfg.parametersBool;
            parametersChar = cfg.parametersChar;
            parametersFloat = cfg.parametersFloat;
            parametersInt = cfg.parametersInt;
            parametersKey = cfg.parametersKey;
            parametersQuaternion = cfg.parametersQuaternion;
            parametersVector = cfg.parametersVector;
            parametersString = cfg.parametersString;
        }
    }
    public void SaveParameters()
    {
        using (StreamWriter sw = new StreamWriter("config.json"))
        {
            sw.Write(JsonConvert.SerializeObject(this));
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
    /// <summary>
    /// Check parameters of any types
    /// </summary>
    /// <param name="parameterID"></param>
    /// <returns>parameter. If parameter not found - return null</returns>
    public object GetParameter(int parameterID)
    {
        try
        {
            return parameters[parameterID]; // object
        }
        catch (KeyNotFoundException)
        {
            try
            {
                return parametersBool[parameterID]; // bool
            }
            catch (KeyNotFoundException)
            {
                try
                {
                    return parametersChar[parameterID]; // char
                }
                catch (KeyNotFoundException)
                {
                    try
                    {
                        return parametersInt[parameterID]; // int
                    }
                    catch (KeyNotFoundException)
                    {
                        try
                        {
                            return parametersFloat[parameterID]; // float
                        }
                        catch (KeyNotFoundException)
                        {
                            try
                            {
                                return parametersString[parameterID]; // string
                            }
                            catch (KeyNotFoundException)
                            {
                                try
                                {
                                    return parametersVector[parameterID]; // Vector3
                                }
                                catch (KeyNotFoundException)
                                {
                                    try
                                    {
                                        return parametersQuaternion[parameterID]; // Quaternion
                                    }
                                    catch (KeyNotFoundException)
                                    {
                                        try
                                        {
                                            return parametersKey[parameterID]; // KeyCode
                                        }
                                        catch (KeyNotFoundException)
                                        {
                                            return null;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    public bool? GetBool(int parameterID)
    {
        try
        {
            return parametersBool[parameterID];
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
            return parametersChar[parameterID];
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
            return parametersInt[parameterID];
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
            return parametersFloat[parameterID];
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
            float[] points = parametersVector[parameterID];
            return new Vector3(points[0], points[1], points[2]);
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
            float[] points = parametersQuaternion[parameterID];
            return new Quaternion(points[0], points[1], points[2], points[3]);
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
            return parametersString[parameterID];
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
            return parametersKey[parameterID];
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
        if (value is bool b)
            SetBool(parameterID, b);
        else if (value is char c)
            SetChar(parameterID, c);
        else if (value is int i)
            SetInt(parameterID, i);
        else if (value is float f)
            SetFloat(parameterID, f);
        else if (value is string s)
            SetString(parameterID, s);
        else if (value is Vector3 v)
            SetVector3(parameterID, v);
        else if (value is Quaternion q)
            SetQuaternion(parameterID, q);
        else if (value is KeyCode k)
            SetKeyCode(parameterID, k);
        else
            parameters[parameterID] = value;
    }
    public void SetBool(int parameterID, bool value)
    {
        parametersBool[parameterID] = value;
    }
    public void SetChar(int parameterID, char value)
    {
        parametersChar[parameterID] = value;
    }
    public void SetInt(int parameterID, int value)
    {
        parametersInt[parameterID] = value;
    }
    public void SetFloat(int parameterID, float value)
    {
        parametersFloat[parameterID] = value;
    }
    public void SetVector3(int parameterID, Vector3 value)
    {
        parametersVector[parameterID] = new float[] { value.x, value.y, value.z };
    }
    public void SetQuaternion(int parameterID, Quaternion value)
    {
        parametersQuaternion[parameterID] = new float[] { value.x, value.y, value.z, value.w };
    }
    public void SetString(int parameterID, string value)
    {
        parametersString[parameterID] = value;
    }
    public void SetKeyCode(int parameterID, KeyCode value)
    {
        parametersKey[parameterID] = value;
    }
    #endregion

    #region Add parameters
    public void AddParameter(string name, int id, object value)
    {
        nameID.Add(name, id);
        if (value is bool b)
            parametersBool.Add(id, b);
        else if (value is char c)
            parametersChar.Add(id, c);
        else if (value is int i)
            parametersInt.Add(id, i);
        else if (value is float f)
            parametersFloat.Add(id, f);
        else if (value is string str)
            parametersString.Add(id, str);
        else if (value is Vector3 vect)
            parametersVector.Add(id, new float[] { vect.x, vect.y, vect.z });
        else if (value is Quaternion q)
            parametersQuaternion.Add(id, new float[] { q.x, q.y, q.z, q.w});
        else if (value is KeyCode key)
            parametersKey.Add(id, key);
        else
            parameters.Add(id, value);
    }
    /// <summary>
    /// Add empty parameter with getted name, ID and type
    /// </summary>
    /// <remarks>Type can be only: bool, char, int, float, string, Vector3, Quanternion, KeyCode</remarks>
    public void AddParameter(string name, int id, Type type)
    {
        nameID.Add(name, id);
        if (type == typeof(bool))
        {
            parametersBool.Add(id, false);
        }
        else if (type == typeof(char))
        {
            parametersChar.Add(id, '\0');
        }
        else if (type == typeof(int))
        {
            parametersInt.Add(id, 0);
        }
        else if (type == typeof(float))
        {
            parametersFloat.Add(id, 0f);
        }
        else if (type == typeof(Vector3))
        {
            parametersVector.Add(id, new float[] { 0, 0, 0 });
        }
        else if (type == typeof(Quaternion))
        {
            parametersQuaternion.Add(id, new float[] { 0, 0, 0, 0 });
        }
        else if (type == typeof(string))
        {
            parametersString.Add(id, "");
        }
        else if (type == typeof(KeyCode))
        {
            parametersKey.Add(id, KeyCode.None);
        }
        else
        {
            nameID.Remove(name);
            throw new ArgumentException($"Not valid type of parameter '{type.Name}'");
        }
    }
    public void AddParameter(string name, Type type)
    {
        int id = new System.Random().Next(0, 99999); // 5-значный ID
        if (parameters.ContainsKey(id))
            AddParameter(name, type);
        else
            AddParameter(name, id, type);
    }
    public void AddParameter(string name, object value)
    {
        int id = new System.Random().Next(0, 99999); // 5-значный ID
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
