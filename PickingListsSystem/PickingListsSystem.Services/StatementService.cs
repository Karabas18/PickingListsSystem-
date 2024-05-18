using AutoMapper;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Dto.Statement;
using PickingListsSystem.Entities;
using PickingListsSystem.Services.Contracts;

namespace PickingListsSystem.Services
{
    public class StatementService : IStatementService
    {
        private readonly IMapper _mapper;
        private readonly IStatementRepository _statementRepository;

        private readonly IProjectRepository _projectRepository;
        private readonly IWorkRepository _workRepository;
        private readonly IMaterialRepository _materialRepository;

        public StatementService(IMapper mapper, IStatementRepository statementRepository, IProjectRepository projectRepository, IWorkRepository workRepository, IMaterialRepository materialRepository)
        {
            _mapper = mapper;
            _statementRepository = statementRepository;
            _projectRepository = projectRepository;
            _workRepository = workRepository;
            _materialRepository = materialRepository;
        }

        public async Task<int> AddStatement(CreateStatementDto statement)
        {
            var entitytoAdd = _mapper.Map<CreateStatementDto, Statement>(statement);
            await _statementRepository.AddStatement(entitytoAdd);
            return entitytoAdd.Id;
        }

        public async Task DeleteStatement(int id)
        {
            await _statementRepository.DeleteStatement(id);
        }

        public async Task<StatementDto> GetStatementID(int id)
        {
            var statement = await _statementRepository.GetStatementID(id);
            return _mapper.Map<StatementDto>(statement);
        }

        public async Task<List<StatementDto>> GetStatement()
        {
            var statement = await _statementRepository.GetStatement();
            return _mapper.Map<List<StatementDto>>(statement);
        }

        public async Task<int> UpdateStatement(StatementDto statement)
        {
            var entitytoUpdate = _mapper.Map<CreateStatementDto, Statement>(statement);
            await _statementRepository.UpdateStatement(entitytoUpdate);
            return entitytoUpdate.Id;
        }



        public async Task AddToStatement(int statementId, int projectId, int? workId, List<int> materialIds)
        {
            //нахуй создавать раньше объект типа statement
            // Получение ведомости из репозитория
            var statement = await _statementRepository.GetStatementID(statementId);
            if (statement == null)
            {
                throw new ArgumentException("Statement not found.");
            }

            // Проверка и добавление проекта в ведомость
            if (projectId != 0)
            {
                var project = await _projectRepository.GetProjectIDSt(projectId);//
                if (project == null)
                {
                    throw new ArgumentException("Project not found.");
                }

                if (!statement.Project.Any(p => p.Id == projectId))
                {
                    statement.Project.Add(project);
                }
            }

            // Если workId указан, проверяем и добавляем работу в проект
            if (workId.HasValue && workId.Value != 0)
            {
                var work = await _workRepository.GetWorkIDSt(workId.Value);//
                if (work == null)
                {
                    throw new ArgumentException("Work not found.");
                }

                var project = statement.Project.FirstOrDefault(p => p.Id == projectId);
                if (project == null)
                {
                    throw new ArgumentException("Project not found in statement.");
                }

                if (!project.Work.Any(w => w.Id == workId.Value))
                {
                    project.Work.Add(work);
                }
            }

            // Если указаны materialIds, добавляем материалы в работу
            if (materialIds != null && materialIds.Any())
            {
                var work = statement.Project
                                    .SelectMany(p => p.Work)
                                    .FirstOrDefault(w => w.Id == workId.Value);
                if (work == null)
                {
                    throw new ArgumentException("Work not found in project.");
                }

                foreach (var materialId in materialIds)
                {
                    var material = await _materialRepository.GetMaterialID(materialId);//
                    if (material != null)
                    {
                        work.Materials.Add(material);
                    }
                }
            }

            await _statementRepository.UpdateStatement(statement);
        }

        //public async Task AddToStatement(int statementId, int projectId, int? workId, List<int> materialIds)
        //{
        //    // Получение ведомости из репозитория
        //    var statement = await _statementRepository.GetStatementID(statementId);
        //    if (statement == null)
        //    {
        //        throw new ArgumentException("Statement not found.");
        //    }

        //    // Проверка и добавление проекта в ведомость
        //    if (projectId != 0)
        //    {
        //        var project = await _projectRepository.GetProjectID(projectId);
        //        if (project == null)
        //        {
        //            throw new ArgumentException("Project not found.");
        //        }

        //        if (!statement.Project.Any(p => p.Id == projectId))
        //        {
        //            statement.Project.Add(project);
        //        }
        //    }

        //    // Если workId указан, проверяем и добавляем работу в проект
        //    if (workId.HasValue && workId.Value != 0)
        //    {
        //        var work = await _workRepository.GetWorkID(workId.Value);
        //        if (work == null)
        //        {
        //            throw new ArgumentException("Work not found.");
        //        }

        //        var project = statement.Project.FirstOrDefault(p => p.Id == projectId);
        //        if (project == null)
        //        {
        //            throw new ArgumentException("Project not found in statement.");
        //        }

        //        if (!project.Work.Any(w => w.Id == workId.Value))
        //        {
        //            project.Work.Add(work);
        //        }
        //    }

        //    // Удаление работ из проекта, которые не указаны в workId
        //    if (workId.HasValue && workId.Value != 0)
        //    {
        //        var project = statement.Project.FirstOrDefault(p => p.Id == projectId);
        //        if (project != null)
        //        {
        //            var worksToRemove = project.Work.Where(w => w.Id != workId.Value).ToList();
        //            foreach (var work in worksToRemove)
        //            {
        //                project.Work.Remove(work);
        //            }
        //        }
        //    }

        //    // Если указаны materialIds, добавляем материалы в работу
        //    if (materialIds != null && materialIds.Any())
        //    {
        //        var work = statement.Project
        //                            .SelectMany(p => p.Work)
        //                            .FirstOrDefault(w => w.Id == workId.Value);
        //        if (work == null)
        //        {
        //            throw new ArgumentException("Work not found in project.");
        //        }

        //        foreach (var materialId in materialIds)
        //        {
        //            var material = await _materialRepository.GetMaterialID(materialId);
        //            if (material != null && !work.Materials.Any(m => m.Id == materialId))
        //            {
        //                work.Materials.Add(material);
        //            }
        //        }

        //        // Удаление материалов из работы, которые не указаны в materialIds
        //        var materialsToRemove = work.Materials.Where(m => !materialIds.Contains(m.Id)).ToList();
        //        foreach (var material in materialsToRemove)
        //        {
        //            work.Materials.Remove(material);
        //        }
        //    }

        //    await _statementRepository.UpdateStatement(statement);
        //}






        //
        //public async Task AddMaterialsToStatement(int statementId, List<int> materialIds)
        //{
        //    var statement = await _statementRepository.GetStatementID(statementId);

        //    if (statement != null)
        //    {
        //        foreach (var materialId in materialIds)
        //        {
        //            var material = await _materialRepository.GetMaterialID(materialId);
        //            if (material != null)
        //            {
        //                statement.Materials.Add(material);
        //            }
        //        }
        //        await _statementRepository.UpdateStatement(statement);
        //    }
        //}
        ////
        //public async Task AddWorkToStatement(int statementId, List<int> workIds)
        //{
        //    var statement = await _statementRepository.GetStatementID(statementId);

        //    if (statement != null)
        //    {
        //        foreach (var workId in workIds)
        //        {
        //            var work = await _workRepository.GetWorkID(workId);
        //            if (work != null)
        //            {
        //                statement.Work.Add(work);
        //            }
        //        }
        //        await _statementRepository.UpdateStatement(statement);
        //    }
        //}
    }
}