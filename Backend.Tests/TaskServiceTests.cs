using Moq;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Services;

// TODO - complete this
namespace Backend.Tests
{    
    public class TaskServiceTests
    {
        private readonly Mock<AppDbContext> _mockAppDbContext;
        private readonly TaskService _taskService;

        public TaskServiceTests()
        {
            _mockAppDbContext = new Mock<AppDbContext>();
            _taskService = new TaskService(_mockContext.Object);
        }

        [Fact]
        public async Task AddTask_Should_Add_Task()
        {
            var task = new Task
            {
                Title = "Test Task",
                Description = "Test Description",
                DueDate = DateTime.Now,
                Priority = "High",
                Status = "Not Started"
            };

            await _taskService.AddTaskAsync(task);

            _mockAppDbContext.Verify(m => m.Tasks.AddAsync(task, default), Times.Once());
            _mockAppDbContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
        }

        [Fact]
        public async Task GetTasks_Should_Return_All_Tasks()
        {
            var tasks = new List<Task>
            {
                new Task { Title = "Test Task 1" },
                new Task { Title = "Test Task 2" }
            }
            .AsQueryable();

            var mockSet = new Mock<DbSet<Task>>();
            mockSet.As<IQueryable<Task>>().Setup(m => m.Provider).Returns(tasks.Provider);
            mockSet.As<IQueryable<Task>>().Setup(m => m.Expression).Returns(tasks.Expression);
            mockSet.As<IQueryable<Task>>().Setup(m => m.ElementType).Returns(tasks.ElementType);
            mockSet.As<IQueryable<Task>>().Setup(m => m.GetEnumerator()).Returns(tasks.GetEnumerator());

            _mockAppDbContext.Setup(c => c.Tasks).Returns(mockSet.Object);

            var result = await _taskService.GetTasksAsync();

            Assert.Equal(2, result.Count());
        }
    }
}
