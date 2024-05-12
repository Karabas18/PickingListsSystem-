﻿using PickingListsSystem.Dto.Materials;
using PickingListsSystem.Services.Contracts;
using System.Net.Http.Json;

namespace PickingListsSystem.Front.Services
{
    public class MaterialService : IMaterialService
    {
        protected readonly HttpClient _httpClient;

        public MaterialService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<int> AddMaterial(CreateMaterialDto material)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMaterial(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MaterialDto>> GetMaterials()
        {
            var response = await _httpClient.GetFromJsonAsync<List<MaterialDto>>($"Material");
            return response ?? throw new HttpRequestException("Couldn't get vessels");
        }

        public async Task<MaterialDto> GetMaterialID(int id)
        {
            var response = await _httpClient.GetAsync($"Material/getbyid?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var materialDto = await response.Content.ReadFromJsonAsync<MaterialDto>();
                return materialDto ?? throw new HttpRequestException($"Couldn't get material with ID {id}");
            }
            else
            {
                throw new HttpRequestException($"Failed to get material with ID {id}. Status code: {response.StatusCode}");
            }
        }

        public Task<int> UpdateMaterial(MaterialDto material)
        {
            throw new NotImplementedException();
        }
    }
}
