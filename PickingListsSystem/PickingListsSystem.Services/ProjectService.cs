﻿using AutoMapper;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Dto.Project;
using PickingListsSystem.Entities;
using PickingListsSystem.Services.Contracts;

namespace PickingListsSystem.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;
        //
        private readonly IWorkRepository _workRepository;

        public ProjectService(IMapper mapper, IProjectRepository projectRepository, IWorkRepository workRepository)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
            _workRepository = workRepository;
        }

        public async Task<int> AddProject(CreateProjectDto project)
        {
            var entitytoAdd = _mapper.Map<CreateProjectDto, Project>(project);
            await _projectRepository.AddProject(entitytoAdd);
            return entitytoAdd.Id;
        }

        public async Task DeleteProject(int id)
        {
            await _projectRepository.DeleteProject(id);
        }

        public async Task<ProjectDto> GetProjectID(int id)
        {
            var project = await _projectRepository.GetProjectID(id);
            return _mapper.Map<ProjectDto>(project);
        }

        public async Task<List<ProjectDto>> GetProject()
        {
            var project = await _projectRepository.GetProject();
            return _mapper.Map<List<ProjectDto>>(project);
        }

        public async Task<int> UpdateProject(ProjectDto project)
        {
            var entitytoUpdate = _mapper.Map<CreateProjectDto, Project>(project);
            await _projectRepository.UpdateProject(entitytoUpdate);
            return entitytoUpdate.Id;
        }

        public async Task AddWorkToProject(int projectId, List<int> workIds)
        {
            var project = await _projectRepository.GetProjectID(projectId);

            if (project != null)
            {
                foreach (var workId in workIds)
                {
                    var work = await _workRepository.GetWorkID(workId);
                    if (work != null)
                    {
                        project.Work.Add(work);
                    }
                }
                await _projectRepository.UpdateProject(project);
            }
        }
    }
}