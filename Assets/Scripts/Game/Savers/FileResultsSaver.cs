using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Savers
{
    public class FileResultsSaver : ResultsSaver
    {
        private const string STORE_FILENAME = "ResultsStore";

        private string ResultsStorePath => Path.Combine(Application.persistentDataPath, STORE_FILENAME);

        public override bool HasResultsSave(out List<string> results)
        {
            string filePath = ResultsStorePath;
            if (File.Exists(filePath))
            {
                results = File.ReadAllLines(filePath).ToList();
                return true;
            }

            results = null;
            return false;
        }

        public override void SaveResult(string result, bool asNew)
        {
            SaveResultInFileAsync(result, asNew);
        }

        private async void SaveResultInFileAsync(string result, bool asNew)
        {
            string filePath = ResultsStorePath;
            if (asNew)
            {
                await File.AppendAllTextAsync(filePath, $"{result}{Environment.NewLine}");
            }
            else
            {
                if (File.Exists(filePath))
                {
                    // reading all results without first
                    var lines = (await File.ReadAllLinesAsync(filePath)).Skip(1).ToList();
                    lines.Add(result);
                    await File.WriteAllLinesAsync(filePath, lines);
                }
                else
                {
                    Debug.LogError("Trying to reset result but save file not exists. This will cause data loss after application reboot");
                    await File.WriteAllTextAsync(filePath, $"{result}{Environment.NewLine}");
                }
            }
        }
    }
}