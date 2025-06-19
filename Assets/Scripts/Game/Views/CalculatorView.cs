using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game
{
    public class CalculatorView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private Button resultButton;
        [SerializeField] private ResultView resultViewPrefab;
        [SerializeField] private ScrollRect resultsScrollRect;
        [SerializeField] private Transform resultsContent;

        [Inject] private CalculatorPresenter presenter;
        private List<ResultView> resultViews = new();

        public void AddResult(string result, bool asNew)
        {
            ResultView resultView = null;
            if (asNew)
            {
                resultView = Instantiate(resultViewPrefab, resultsContent);
                resultViews.Add(resultView);
            }
            else
            {
                resultView = resultViews[0];
                resultViews.RemoveAt(0);
                resultViews.Add(resultView);
                resultView.transform.SetAsLastSibling();
            }
            resultView.SetResultLabel(result);
            resultsScrollRect.verticalNormalizedPosition = 1f;
        }

        public void SetResults(List<string> results)
        {
            for (int i = 0; i < results.Count; i++)
            {
                if (i < resultViews.Count)
                {
                    resultViews[i].SetResultLabel(results[i]);
                }
                else
                    AddResult(results[i], true);
            }
            // Destroy if there were extra objects
            for (int i = results.Count; i < resultViews.Count; i++)
            {
                Destroy(resultViews[i].gameObject);
            }
        }

        public void SetInput(string input)
        {
            inputField.text = input;
        }

        private void Awake()
        {
            resultButton.onClick.AddListener(ResultButton_Clicked);
        }

        private void ResultButton_Clicked()
        {
            string input = inputField.text;
            if (!string.IsNullOrEmpty(input))
            {
                bool isCalculated = presenter.CalculateInput(input);
                if (isCalculated)
                    inputField.text = string.Empty;
            }
        }

        private void OnApplicationQuit()
        {
            string input = inputField.text;
            if (!string.IsNullOrEmpty(input))
                presenter.SaveInput(input);
        }
    }
}