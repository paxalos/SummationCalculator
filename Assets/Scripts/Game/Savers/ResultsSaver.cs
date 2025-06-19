using System.Collections.Generic;

namespace Savers
{
    public abstract class ResultsSaver
    {
        public abstract void SaveResult(string result, bool asNew);
        public abstract bool HasResultsSave(out List<string> results);
    }
}