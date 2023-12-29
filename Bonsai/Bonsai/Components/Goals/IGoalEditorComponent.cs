using Bonsai.Model;

namespace Bonsai.Components.Goals
{
	public interface IGoalEditorComponent<TGoal> : IGoalComponent<TGoal> where TGoal : Goal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="goal"></param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <returns></returns>
        public bool TrySubmit(out TGoal? goal);
    }
}
