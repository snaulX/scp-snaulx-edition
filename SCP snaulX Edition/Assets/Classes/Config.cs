using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class Config
{
    #region Private fields and methods
    [JsonRequired]
    private Dictionary<string, int> nameID;
    [JsonRequired]
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
        using (StreamReader file = File.OpenText("config.json"))
        {
        }
    }
    public void SaveParameters()
    {
        JsonSerializer serializer = new JsonSerializer();
        serializer.NullValueHandling = NullValueHandling.Ignore;

        using (StreamWriter sw = new StreamWriter("config.json"))
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            serializer.Serialize(writer, this);
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
    // сорри если не любите goto
    public void SetParameter(string name, object value)
    {
        if (nameID.ContainsKey(name))
            SetParameter(nameID[name], value);
        else
        {
            generate_id:
            int id = new System.Random().Next(0, 99999);
            if (!parameters.ContainsKey(id))
            {
                SetParameter(id, value);
                nameID.Add(name, id);
            }
            else
                goto generate_id;
        }
    }
    public void SetBool(string name, bool value)
    {
        if (nameID.ContainsKey(name))
            SetBool(nameID[name], value);
        else
        {
            generate_id:
            int id = new System.Random().Next(0, 99999);
            if (!parameters.ContainsKey(id))
            {
                SetBool(id, value);
                nameID.Add(name, id);
            }
            else
                goto generate_id;
        }
    }
    public void SetChar(string name, char value)
    {
        if (nameID.ContainsKey(name))
            SetChar(nameID[name], value);
        else
        {
            generate_id:
            int id = new System.Random().Next(0, 99999);
            if (!parameters.ContainsKey(id))
            {
                SetChar(id, value);
                nameID.Add(name, id);
            }
            else
                goto generate_id;
        }
    }
    public void SetInt(string name, int value)
    {
        if (nameID.ContainsKey(name))
            SetInt(nameID[name], value);
        else
        {
            generate_id:
            int id = new System.Random().Next(0, 99999);
            if (!parameters.ContainsKey(id))
            {
                SetInt(id, value);
                nameID.Add(name, id);
            }
            else
                goto generate_id;
        }
    }
    public void SetFloat(string name, float value)
    {
        if (nameID.ContainsKey(name))
            SetFloat(nameID[name], value);
        else
        {
            generate_id:
            int id = new System.Random().Next(0, 99999);
            if (!parameters.ContainsKey(id))
            {
                SetFloat(id, value);
                nameID.Add(name, id);
            }
            else
                goto generate_id;
        }
    }
    public void SetVector3(string name, Vector3 value)
    {
        if (nameID.ContainsKey(name))
            SetVector3(nameID[name], value);
        else
        {
            generate_id:
            int id = new System.Random().Next(0, 99999);
            if (!parameters.ContainsKey(id))
            {
                SetVector3(id, value);
                nameID.Add(name, id);
            }
            else
                goto generate_id;
        }
    }
    public void SetQuaternion(string name, Quaternion value)
    {
        if (nameID.ContainsKey(name))
            SetQuaternion(nameID[name], value);
        else
        {
            generate_id:
            int id = new System.Random().Next(0, 99999);
            if (!parameters.ContainsKey(id))
            {
                SetQuaternion(id, value);
                nameID.Add(name, id);
            }
            else
                goto generate_id;
        }
    }
    public void SetString(string name, string value)
    {
        if (nameID.ContainsKey(name))
            SetString(nameID[name], value);
        else
        {
            generate_id:
            int id = new System.Random().Next(0, 99999);
            if (!parameters.ContainsKey(id))
            {
                SetString(id, value);
                nameID.Add(name, id);
            }
            else
                goto generate_id;
        }
    }
    public void SetKeyCode(string name, KeyCode value)
    {
        if (nameID.ContainsKey(name))
            SetKeyCode(nameID[name], value);
        else
        {
            generate_id:
            int id = new System.Random().Next(0, 99999);
            if (!parameters.ContainsKey(id))
            {
                SetKeyCode(id, value);
                nameID.Add(name, id);
            }
            else
                goto generate_id;
        }
    }
    #endregion

    #region Set parameters by ID
    public void SetParameter(int parameterID, object value)
    {
        try
        {
            parameters[parameterID] = value;
        }
        catch (KeyNotFoundException)
        {
            // something
        }
    }
    public void SetBool(int parameterID, bool value)
    {
        try
        {
            parameters[parameterID] = value;
        }
        catch (KeyNotFoundException)
        {
            // something
        }
    }
    public void SetChar(int parameterID, char value)
    {
        try
        {
            parameters[parameterID] = value;
        }
        catch (KeyNotFoundException)
        {
            // something
        }
    }
    public void SetInt(int parameterID, int value)
    {
        try
        {
            parameters[parameterID] = value;
        }
        catch (KeyNotFoundException)
        {
            // something
        }
    }
    public void SetFloat(int parameterID, float value)
    {
        try
        {
            parameters[parameterID] = value;
        }
        catch (KeyNotFoundException)
        {
            // something
        }
    }
    public void SetVector3(int parameterID, Vector3 value)
    {
        try
        {
            parameters[parameterID] = value;
        }
        catch (KeyNotFoundException)
        {
            // something
        }
    }
    public void SetQuaternion(int parameterID, Quaternion value)
    {
        try
        {
            parameters[parameterID] = value;
        }
        catch (KeyNotFoundException)
        {
            // something
        }
    }
    public void SetString(int parameterID, string value)
    {
        try
        {
            parameters[parameterID] = value;
        }
        catch (KeyNotFoundException)
        {
            // something
        }
    }
    public void SetKeyCode(int parameterID, KeyCode value)
    {
        try
        {
            parameters[parameterID] = value;
        }
        catch (KeyNotFoundException)
        {
            // something
        }
    }
    #endregion

    /// <summary>
    /// Get parameter ID by name
    /// </summary>
    /// <param name="name">Name of parameter for ID</param>
    /// <remarks>Return -1 if not found parameter</remarks>
    /// <returns>Parameter ID</returns>
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
