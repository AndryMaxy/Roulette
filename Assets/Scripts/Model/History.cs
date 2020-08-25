using System.Collections.Generic;
using System;

[Serializable]
public class History
{

    public List<Number> Numbers { get; set; }

    public History()
    {
        Numbers = new List<Number>();
    }
}