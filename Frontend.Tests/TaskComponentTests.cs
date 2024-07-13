using Bunit;
using Microsoft.Extensions.DependencyInjection;

namespace Frontend.Tests
{
    public class TaskComponentTests : TestContext
    {
        [Fact]
        public void TaskComponent_Should_Render()
        {
            /*
            // Arrange
            Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost") });

            // Act
            var component = RenderComponent<TaskComponent>();

            // Assert
            Assert.Contains("Tasks", component.Markup);
            */

            /*
             // Arrange
            var taskServiceMock = new Mock<ITaskService>();
            taskServiceMock.Setup(s => s.GetTasksAsync()).ReturnsAsync(new List<TaskDto>());

            Services.AddSingleton<ITaskService>(taskServiceMock.Object);

            // Act
            var cut = RenderComponent<TaskComponent>();

            // Assert
            Assert.Contains("Tasks", cut.Markup);
            */
        }

        [Fact]
        public void TaskComponent_Should_Add_Task()
        {
            /*
            // Arrange
            var component = RenderComponent<TaskComponent>();

            // Act
            component.Find("input[id=title]").Change("New Task");
            component.Find("textarea[id=description]").Change("Task Description");
            component.Find("input[id=dueDate]").Change(DateTime.Now.ToString("yyyy-MM-dd"));
            component.Find("select[id=priority]").Change("High");
            component.Find("button[type=submit]").Click();

            // Assert
            component.WaitForState(() => component.Instance.Tasks.Count == 1);
            Assert.Contains("New Task", component.Markup);
            */

            /*
              // Arrange
            var taskServiceMock = new Mock<ITaskService>();
            taskServiceMock.Setup(s => s.AddTaskAsync(It.IsAny<TaskDto>())).Returns(Task.CompletedTask);

            Services.AddSingleton<ITaskService>(taskServiceMock.Object);

            var cut = RenderComponent<TaskComponent>();

            // Act
            cut.Find("#title").Change("New Task");
            cut.Find("#description").Change("Task Description");
            cut.Find("#dueDate").Change(DateTime.Now.ToString("yyyy-MM-dd"));
            cut.Find("#priority").Change("High");
            cut.Find("form").Submit();

            // Assert
            taskServiceMock.Verify(s => s.AddTaskAsync(It.IsAny<TaskDto>()), Times.Once);
            */
        }
    }

}
