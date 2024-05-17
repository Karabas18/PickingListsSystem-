﻿using PickingListsSystem.Dto.Work;

namespace PickingListsSystem.Services.Contracts
{
    public interface IWorkService
    {
        Task<List<WorkDto>> GetWork();
        Task<WorkDto> GetWorkID(int id);
        Task DeleteWork(int id);
        Task<int> AddWork(CreateWorkDto work);
        Task<int> UpdateWork(WorkDto work);
        //
        Task AddMaterialsToWork(int statementId, List<int> materialIds);
    }
}
