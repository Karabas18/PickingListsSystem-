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
        private readonly IMaterialRepository _materialRepository;
        private readonly IWorkRepository _workRepository;
        //конструктор исправить
        //public StatementService(IMapper mapper, IStatementRepository statementRepository, IMaterialRepository materialRepository)
        //{
        //    _mapper = mapper;
        //    _statementRepository = statementRepository;
        //    _materialRepository = materialRepository; 
        //}
        public StatementService(IMapper mapper, IStatementRepository statementRepository, IMaterialRepository materialRepository, IWorkRepository workRepository)
        {
            _mapper = mapper;
            _statementRepository = statementRepository;
            _materialRepository = materialRepository;
            _workRepository = workRepository;
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
        //
        public async Task AddMaterialsToStatement(int statementId, List<int> materialIds)
        {
            var statement = await _statementRepository.GetStatementID(statementId);

            if (statement != null)
            {
                foreach (var materialId in materialIds)
                {
                    var material = await _materialRepository.GetMaterialID(materialId);
                    if (material != null)
                    {
                        statement.Materials.Add(material);
                    }
                }
                await _statementRepository.UpdateStatement(statement);
            }
        }
        //
        public async Task AddWorkToStatement(int statementId, List<int> workIds)
        {
            var statement = await _statementRepository.GetStatementID(statementId);

            if (statement != null)
            {
                foreach (var workId in workIds)
                {
                    var work = await _workRepository.GetWorkID(workId);
                    if (work != null)
                    {
                        statement.Work.Add(work);
                    }
                }
                await _statementRepository.UpdateStatement(statement);
            }
        }
    }
}