using MyFeedback.Domain.Entities;

namespace MyFeedback.Test
{


    public class ExitSlipTests
        {
            [Fact]
            public void Create_ShouldInitializeProperties()
            {
                // Arrange
                var lessonId = Guid.NewGuid();
                var questionList = new List<Question> { new Question() };
                var isPublished = true;

                // Act
                var exitSlip = ExitSlip.Create(lessonId, questionList, isPublished);

                // Assert
                Assert.Equal(lessonId, exitSlip.LessonId);
                Assert.Equal(questionList, exitSlip.QuestionList);
                Assert.Equal(isPublished, exitSlip.IsPublished);
            }

            [Fact]
            public void Update_ShouldUpdateProperties_WhenNotPublished()
            {
                // Arrange
                var lessonId = Guid.NewGuid();
                var questionList = new List<Question> { new Question() };
                var isPublished = false;
                var exitSlip = ExitSlip.Create(lessonId, questionList, isPublished);

                var newLessonId = Guid.NewGuid();
                var newQuestionList = new List<Question> { new Question(), new Question() };
                var newIsPublished = true;

                // Act
                var result = exitSlip.Update(newLessonId, newQuestionList, newIsPublished);

                // Assert
                Assert.Equal("Update successful", result);
                Assert.Equal(newLessonId, exitSlip.LessonId);
                Assert.Equal(newQuestionList, exitSlip.QuestionList);
                Assert.Equal(newIsPublished, exitSlip.IsPublished);
            }

            [Fact]
            public void Update_ShouldNotUpdateProperties_WhenPublished()
            {
                // Arrange
                var lessonId = Guid.NewGuid();
                var questionList = new List<Question> { new Question() };
                var isPublished = true;
                var exitSlip = ExitSlip.Create(lessonId, questionList, isPublished);

                var newLessonId = Guid.NewGuid();
                var newQuestionList = new List<Question> { new Question(), new Question() };
                var newIsPublished = false;

                // Act
                var result = exitSlip.Update(newLessonId, newQuestionList, newIsPublished);

                // Assert
                Assert.Equal("Update not succesful; can't update when slip already published!", result);
                Assert.Equal(lessonId, exitSlip.LessonId);
                Assert.Equal(questionList, exitSlip.QuestionList);
                Assert.Equal(isPublished, exitSlip.IsPublished);
            }

            [Fact]
            public void AssureQuestionListIsNotNull_ShouldInitializeQuestionList_WhenNull()
            {
                // Arrange
                var exitSlip = new ExitSlip();

                // Act
                exitSlip.AssureQuestionListIsNotNull();

                // Assert
                Assert.NotNull(exitSlip.QuestionList);
            }

            [Fact]
            public void AssureUpdateImpossibleIfPublished_ShouldReturnTrue_WhenPublished()
            {
                // Arrange
                var exitSlip = new ExitSlip();
                var isPublished = true;

                // Act
                var result = exitSlip.AssureUpdateImpossibleIfPublished(isPublished);

                // Assert
                Assert.True(result);
            }

            [Fact]
            public void AssureUpdateImpossibleIfPublished_ShouldReturnFalse_WhenNotPublished()
            {
                // Arrange
                var exitSlip = new ExitSlip();
                var isPublished = false;

                // Act
                var result = exitSlip.AssureUpdateImpossibleIfPublished(isPublished);

                // Assert
                Assert.False(result);
            }
        }
    }




public class ForumPostTests
    {
        [Fact]
        public void Create_ShouldInitializeProperties()
        {
            // Arrange
            var problemText = "Problem";
            var solutionText = "Solution";

            // Act
            var forumPost = ForumPost.Create(problemText, solutionText);

            // Assert
            Assert.Equal(problemText, forumPost.ProblemText);
            Assert.Equal(solutionText, forumPost.SolutionText);
            Assert.Empty(forumPost.Comments);
            Assert.False(forumPost.IsLocked);
        }

        [Fact]
        public void AssureTextNotTooLong_ShouldReturnErrorMessage_WhenSolutionTextTooLong()
        {
            // Arrange
            var problemText = "Problem";
            var solutionText = new string('a', 151);
            var forumPost = ForumPost.Create(problemText, solutionText);

            // Act
            var result = forumPost.AssureTextNotTooLong();

            // Assert
            Assert.Equal("Solution text is too long; it can't be longer than 200 characters!", result);
        }

        [Fact]
        public void AssureTextNotTooLong_ShouldReturnErrorMessage_WhenProblemTextTooLong()
        {
            // Arrange
            var problemText = new string('a', 151);
            var solutionText = "Solution";
            var forumPost = ForumPost.Create(problemText, solutionText);

            // Act
            var result = forumPost.AssureTextNotTooLong();

            // Assert
            Assert.Equal("Problem text is too long; it can't be longer than 200 characters!", result);
        }

        [Fact]
        public void AssureTextNotTooLong_ShouldReturnEmptyString_WhenTextsAreValid()
        {
            // Arrange
            var problemText = "Problem";
            var solutionText = "Solution";
            var forumPost = ForumPost.Create(problemText, solutionText);

            // Act
            var result = forumPost.AssureTextNotTooLong();

            // Assert
            Assert.Equal("", result);
        }
    }
