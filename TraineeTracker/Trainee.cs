namespace TraineeTracker
{
    public abstract class Trainee
    {
        public int Id { get; set; }
        public string TraineeId { get; set; }
        public string Name { get; set; }
        public string Technology { get; set; }
        public int Module1Score { get; set; }
        public int Module2Score { get; set; }
        public bool ProjectCompleted { get; set; }
        public string Type { get; set; }

        public virtual double FeedbackScore => 0; // overridden in derived types
    }
}
