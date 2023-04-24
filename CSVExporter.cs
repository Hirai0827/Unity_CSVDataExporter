using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Hirai
{
    public class CSVExporter
    {
        private string saveName;
        private string saveFolderPath;
        private string[] labels;
        private List<string[]> data;
        /// <summary>
        /// CSVに書き出してくれるやつ
        /// </summary>
        /// <param name="saveName">保存先ファイル名（csv抜きで指定）</param>
        /// <param name="saveFolderPath">保存先フォルダ名</param>
        /// <param name="labels">一行目につくラベル　Addするデータはこれと同じ長さじゃないとダメ</param>
        public CSVExporter(string saveName,string saveFolderPath,string[] labels)
        {
            this.saveName = saveName;
            this.saveFolderPath = saveFolderPath;
            this.labels = labels;
            this.data = new List<string[]>();
        }
    
        /// <summary>
        /// データの追加
        /// </summary>
        /// <param name="line">追加するデータ配列　labelsと同じ長さにすること</param>
        /// <exception cref="Exception"></exception>
        public void Add(object[] line)
        {
            if (line.Length != labels.Length)
            {
                throw new Exception("Data Length and Line Length must be Equal");
            }
            var strArray = line.Select(x => x.ToString()).ToArray();
            data.Add(strArray);
        }
    
        /// <summary>
        /// 事前に指定したパスにファイルを保存する
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void Save()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Path.Join(saveFolderPath,saveName + ".csv"), false, System.Text.Encoding.GetEncoding("shift_jis")))
                {
                    sw.WriteLine(string.Join(",", labels));
                    foreach (string[] rowData in data)
                    {
                        sw.WriteLine(string.Join(",", rowData));
                    }
                }
            }
            catch(Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}

