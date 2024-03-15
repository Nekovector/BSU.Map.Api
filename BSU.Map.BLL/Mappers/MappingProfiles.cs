using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BSU.Map.BLL.Dtos;

namespace BSU.Map.BLL.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CoordinatesProfiles();
            BuildingAddressProfiles();
            BuildingTypeProfiles();
            PhotoProfiles();
            BuildingProfiles();
            CategoriesProfiles();
            StructuralObjectIconProfiles();
            StructuralObjectProfiles();
            MemoryPlaceProfiles();
            MemoryPhotoProfiles();
            ScientistProfiles();
            AddMaterialProfiles();
        }

        private void CoordinatesProfiles()
        {
            CreateMap<DAL.Models.Coordinate, CoordinatesDto>();
        }

        private void BuildingAddressProfiles()
        {
            CreateMap<DAL.Models.BuildingAddress, BuildingAddressDto>();
        }

        private void BuildingTypeProfiles()
        {
            CreateMap<DAL.Models.BuildingType, BuildingTypeDto>();
        }

        private void PhotoProfiles()
        {
            CreateMap<DAL.Models.Photo, PhotoDto>();
        }

        private void BuildingProfiles()
        {
            CreateMap<DAL.Models.Building, HistoricalBuildingDto>();
            CreateMap<DAL.Models.Building, ModernBuildingDto>();
        }

        private void CategoriesProfiles()
        {
            CreateMap<DAL.Models.Category, StructuralObjectCategoryDto>();
        }

        private void StructuralObjectIconProfiles()
        {
            CreateMap<DAL.Models.StructuralObjectsIcon, StructuralObjectIconDto>();
        }

        private void StructuralObjectProfiles()
        {
            CreateMap<DAL.Models.StructuralObject, StructuralObjectDto>()
                .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.StructuralObjectsIcon));
        }
        private void MemoryPlaceProfiles()
        {
            CreateMap<DAL.Models.MemoryPlace, MemoryPlaceDto>();
        }

        private void MemoryPhotoProfiles()
        {
            CreateMap<DAL.Models.MemoryPhoto, MemoryPhotoDto>();
        }

        private void ScientistProfiles()
        {
            CreateMap<DAL.Models.Scientist, ScientistDto>();
        }

        private void AddMaterialProfiles()
        {
            CreateMap<DAL.Models.AddMaterial, AddMaterialDto>();
        }
    }
}
