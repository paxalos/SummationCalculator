using System.Text.RegularExpressions;
using Zenject;
using Popups;
using System;
using Savers;

namespace Game
{
    public class SummationCalculatorPresenter : CalculatorPresenter
    {
        private PopupsManager popupsManager;

        [Inject]
        public SummationCalculatorPresenter(CalculatorModel model, 
                                            InputSaver inputSaver, 
                                            ResultsSaver resultsSaver,
                                            PopupsManager popupsManager) : base(model, 
                                                                                inputSaver, 
                                                                                resultsSaver)
        {
            this.popupsManager = popupsManager;

            if (inputSaver.HasRestoreInput(out string input))
            {
                model.SetInput(input);
            }

            if (resultsSaver.HasResultsSave(out var results))
            {
                model.SetResults(results);
            }
        }

        public override bool CalculateInput(string input)
        {
            string result = string.Empty;
            bool isResultCalculated = true;
            // check that the input contains only numbers and plus
            // check that the input doesn't start and end with plus
            // check that the input doesn't have double plus
            if (!Regex.IsMatch(input, "^[0-9+]+$") ||
                input[0] == '+' ||
                input[^1] == '+'||
                input.Contains("++"))
            {
                popupsManager.ShowErrorMessage();
                result = $"{input}=ERROR";
                isResultCalculated = false;
            }
            else
            {
                ulong sum = 0;
                string[] numbers = input.Split('+');
                for (int i = 0; i < numbers.Length; i++)
                    sum += Convert.ToUInt64(numbers[i]);
                result = $"{input}={sum}";
            }


            bool asNew = model.CanAddResultAsNew;
            model.AddResult(result, asNew);
            resultsSaver.SaveResult(result, asNew);

            return isResultCalculated;
        }
    }
}