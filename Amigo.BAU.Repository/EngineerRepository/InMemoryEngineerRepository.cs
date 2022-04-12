using Amigo.BAU.Persistance.Models;
using Amigo.BAU.Persistance.QueryModels;

namespace Amigo.BAU.Repository.EngineerRepository
{
    public class InMemoryEngineerRepository : IEngineerRepository
    {
        private readonly List<ShiftWorker> workers = new()
        {
            new ShiftWorker
            {
                Name = "Paul",
                Email = "Paul@mail.com",
                EngineerId = 1,
                FirstShift = DateTimeOffset.UtcNow.AddDays(-3).Date,
                LastShift = DateTimeOffset.UtcNow.AddDays(-3).Date,
                ShiftCount = 1
            },
            new ShiftWorker
            {
                Name = "Rae",
                Email = "Rae@mail.com",
                EngineerId = 2,
                FirstShift = null,
                LastShift = null,
                ShiftCount = 0
            },
            new ShiftWorker
            {
                Name = "Phil",
                Email = "Phil@mail.com",
                EngineerId = 3,
                FirstShift = DateTimeOffset.UtcNow.AddDays(-6).Date,
                LastShift = DateTimeOffset.UtcNow.AddDays(-1).Date,
                ShiftCount = 2
            },
            new ShiftWorker
            {
                Name = "Rob",
                Email = "Rob@mail.com",
                EngineerId = 4,
                FirstShift = DateTimeOffset.UtcNow.AddDays(-1).Date,
                LastShift = DateTimeOffset.UtcNow.AddDays(-1).Date,
                ShiftCount = 1
            },
            new ShiftWorker
            {
                Name = "Anne",
                Email = "Anne@mail.com",
                EngineerId = 5,
                FirstShift = DateTimeOffset.UtcNow.AddDays(-14).Date,
                LastShift = DateTimeOffset.UtcNow.AddDays(-3).Date,
                ShiftCount = 2
            },
            new ShiftWorker
            {
                Name = "Marlon",
                Email = "Marlon@mail.com",
                EngineerId = 6,
                FirstShift = DateTimeOffset.UtcNow.AddDays(-13).Date,
                LastShift = DateTimeOffset.UtcNow.AddDays(-4).Date,
                ShiftCount = 2
            },
            new ShiftWorker
            {
                Name = "Elan",
                Email = "Elan@mail.com",
                EngineerId = 7,
                FirstShift = DateTimeOffset.UtcNow.AddDays(-12).Date,
                LastShift = DateTimeOffset.UtcNow.AddDays(-7).Date,
                ShiftCount = 2
            },
            new ShiftWorker
            {
                Name = "Mouse",
                Email = "Mouse@mail.com",
                EngineerId = 8,
                FirstShift = null,
                LastShift = null,
                ShiftCount = 0
            },
            new ShiftWorker
            {
                Name = "Puca",
                Email = "Puca@mail.com",
                EngineerId = 9,
                FirstShift = DateTimeOffset.UtcNow.AddDays(-7).Date,
                LastShift = DateTimeOffset.UtcNow.AddDays(-4).Date,
                ShiftCount = 2
            },
            new ShiftWorker
            {
                Name = "Manx",
                Email = "Manx@mail.com",
                EngineerId = 10,
                FirstShift = DateTimeOffset.UtcNow.AddDays(-4).Date,
                LastShift = DateTimeOffset.UtcNow.AddDays(-4).Date,
                ShiftCount = 1
            }
        };

        public async Task<Engineer> GetById(int id)
        {
            var engineer = workers.FirstOrDefault(w => w.EngineerId == id);
            return new Engineer
            {
                EngineerId = engineer.EngineerId,
                FirstShift = engineer.FirstShift,
                LastShift = engineer.LastShift,
                ShiftCount = engineer.ShiftCount,
                EmployeeId = engineer.EngineerId
            };
        }

        public async Task<Engineer> Add(Engineer entity)
        {
            entity.EmployeeId = workers.Max(x => x.EngineerId) + 1;
            return entity;
        }

        public async Task Update(Engineer entity, int id)
        {
            var eng = workers.FirstOrDefault(x => x.EngineerId == id);
            eng.FirstShift = entity.FirstShift;
            eng.LastShift = entity.LastShift;
            eng.ShiftCount = entity.ShiftCount;
        }

        public async Task Delete(int id)
        {
            var engineer = workers.FirstOrDefault(x => x.EngineerId == id);
            workers.Remove(engineer);
        }

        public async Task<IEnumerable<Engineer>> GetAll()
        {
            var engineers = new List<Engineer>();
            foreach (var shiftWorker in workers)
            {
                engineers.Add(new Engineer
                {
                    EngineerId = shiftWorker.EngineerId,
                    FirstShift = shiftWorker.FirstShift,
                    LastShift = shiftWorker.LastShift,
                    ShiftCount = shiftWorker.ShiftCount,
                    EmployeeId = shiftWorker.EngineerId
                });
            }
            return engineers;
        }

        public async Task<IEnumerable<ShiftWorker>> GetNamedEngineers()
        {
            return workers;
        }

        public async Task UpdateAll(IEnumerable<Engineer> workers)
        {
            foreach (var shiftWorker in workers)
            {
                await Update(shiftWorker, shiftWorker.EngineerId);

            }
        }
    }
}
