namespace TraineeTracker
{
    public class Fresher : Trainee
    {
        public override double FeedbackScore =>
            Math.Round(((Module1Score + Module2Score) / 2.0) + (ProjectCompleted ? 5 : 0), 1);
    }
}
