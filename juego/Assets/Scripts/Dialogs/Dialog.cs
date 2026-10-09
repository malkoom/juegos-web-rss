using System;
using System.Collections.Generic;
using UnityEngine;

public class Dialog
{
    public string id;
    public List<Tuple<string, string>> lines = new List<Tuple<string, string>>();

    public Dialog(string id)
    {
        this.id = id;
    }

    // Agrega una línea de texto al diálogo
    public void AddLine(string charId, string text)
    {
        var dialogTuple = new Tuple<string, string>(charId, text);
        lines.Add(dialogTuple);
    }

    // Retorna la cantidad total de líneas
    public int GetLineCount()
    {
        return lines.Count;
    }
}
