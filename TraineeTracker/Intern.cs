namespace TraineeTracker
{
    public class Intern : Trainee
    {
        public override double FeedbackScore =>
            Math.Round((Module1Score + Module2Score) / 2.0, 1);
    }
}
