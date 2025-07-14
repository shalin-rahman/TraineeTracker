using NUnit.Framework;

namespace TraineeTracker.Test
{
    public class TraineeTests
    {
        [Test]
        public void Fresher_FeedbackScore_IncludesBonus_WhenProjectCompleted()
        {
            var t = new Fresher
            {
                Module1Score = 80,
                Module2Score = 90,
                ProjectCompleted = true
            };

            double expected = (80 + 90) / 2.0 + 5; // average + bonus
            Assert.That(t.FeedbackScore, Is.EqualTo(expected));
        }

        [Test]
        public void Fresher_FeedbackScore_WithoutBonus_WhenProjectNotCompleted()
        {
            var t = new Fresher
            {
                Module1Score = 80,
                Module2Score = 90,
                ProjectCompleted = false
            };

            double expected = (80 + 90) / 2.0; // average only
            Assert.That(t.FeedbackScore, Is.EqualTo(expected));
        }

        [Test]
        public void Intern_FeedbackScore_AverageOnly()
        {
            var t = new Intern
            {
                Module1Score = 70,
                Module2Score = 80,
                ProjectCompleted = true // irrelevant for Intern
            };

            double expected = (70 + 80) / 2.0;
            Assert.That(t.FeedbackScore, Is.EqualTo(expected));
        }
    }
}
