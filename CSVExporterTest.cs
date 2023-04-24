using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Hirai;
using UnityEngine;

public class CSVExporterTest : MonoBehaviour
{
    [SerializeField] private string saveName;
    [SerializeField] private string saveFolderPath;
    [SerializeField] private string[] labels;

    [SerializeField] private int[] contents;
    // Start is called before the first frame update
    void Start()
    {
        var exporter = new CSVExporter(saveName, saveFolderPath, labels);
        var objects = contents.Select(x => x as object).ToArray();
        exporter.Add(objects);
        exporter.Add(objects);
        exporter.Save();
    }
}
