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

        public async Task AddToStatement(int projectId, int? workId, List<int> materialIds)
        {
            //var statement = new Statement();
            var statement = new Statement
            {
                StatementStatus = "Обрабатывается",
                StatementDate = DateTime.Now
            };

            var project = await _projectRepository.GetProjectID(projectId);//
            if (project == null)
            {
                throw new ArgumentException("Project not found.");
            }
            if (!project.Work.Any(x=>x.Id==workId)) 
                throw new ArgumentException("Project not found.");

            var materials = await _materialRepository.GetMaterials(materialIds);

            statement.Project = project;
            
            statement.Work = project.Work.First(x => x.Id == workId);

            statement.Materials = materials;

            await _statementRepository.AddStatement(statement);

        }

    }
}