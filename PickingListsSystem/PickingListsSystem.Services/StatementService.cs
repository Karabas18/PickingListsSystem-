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

        public StatementService(IMapper mapper, IStatementRepository statementRepository)
        {
            _mapper = mapper;
            _statementRepository = statementRepository;
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
            //return _mapper.Map<MaterialDto>(await _materialRepository.GetMaterialID(id));
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
    }
}