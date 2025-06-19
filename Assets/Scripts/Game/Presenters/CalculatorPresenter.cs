using Savers;
using Zenject;

namespace Game
{
    public abstract class CalculatorPresenter
    {
        protected CalculatorModel model;
        protected InputSaver inputSaver;
        protected ResultsSaver resultsSaver;

        [Inject]
        protected CalculatorPresenter(CalculatorModel model, 
                                      InputSaver inputSaver, 
                                      ResultsSaver resultsSaver)
        {
            this.model = model;
            this.inputSaver = inputSaver;
            this.resultsSaver = resultsSaver;
        }

        public abstract void CalculateInput(string input);

        public void SaveInput(string input)
        {
            inputSaver.SaveInput(input);
        }
    }
}