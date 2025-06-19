using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Game
{
    public class CalculatorModel
    {
        [Inject] protected CalculatorView view;
        private const int RESULT_STORE_MAX = 10;
        private List<string> results = new();

        public bool CanAddResultAsNew => results.Count < RESULT_STORE_MAX;

        public void AddResult(string result, bool asNew)
        {
            if (asNew)
            {
                results.Add(result);
                view.AddResult(result, true);
            }
            else
            {
                results.RemoveAt(0);
                results.Add(result);
                view.AddResult(result, false);
            }
        }

        public void SetResults(List<string> resultsToSet)
        {
            if (resultsToSet.Count > RESULT_STORE_MAX)
            {
                results = resultsToSet.Skip(resultsToSet.Count - RESULT_STORE_MAX)
                                      .ToList();
            }
            else
            {
                results = resultsToSet;
            }

            view.SetResults(results);
        }

        public void SetInput(string input)
        {
            view.SetInput(input);
        }
    }
}