using AutoMapper;
using BSU.Map.BLL.Dtos;
using BSU.Map.DAL.Models;

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
            MemoryDocProfiles();
            ScientistProfiles();
            ScientistPhotoProfiles();
            ScientistDocProfiles();
        }
        private void CoordinatesProfiles()
        {
            CreateMap<Coordinates, CoordinatesDto>();
        }

        private void BuildingAddressProfiles()
        {
            CreateMap<BuildingAddress, BuildingAddressDto>();
        }

        private void BuildingTypeProfiles()
        {
            CreateMap<BuildingType, BuildingTypeDto>();
        }

        private void PhotoProfiles()
        {
            CreateMap<Photo, PhotoDto>();
        }

        private void BuildingProfiles()
        {
            CreateMap<Building, HistoricalBuildingDto>();
            CreateMap<Building, ModernBuildingDto>();
        }

        private void CategoriesProfiles()
        {
            CreateMap<Category, StructuralObjectCategoryDto>();
        }

        private void StructuralObjectIconProfiles()
        {
            CreateMap<StructuralObjectsIcon, StructuralObjectIconDto>();
        }

        private void StructuralObjectProfiles()
        {
            CreateMap<StructuralObject, StructuralObjectDto>()
                .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.StructuralObjectsIcon));
        }
        private void MemoryPlaceProfiles()
        {
            CreateMap<MemoryPlace, MemoryPlaceDto>();
        }

        private void MemoryPhotoProfiles()
        {
            CreateMap<MemoryPhoto, MemoryPhotoDto>();
        }

        private void MemoryDocProfiles()
        {
            CreateMap<MemoryDoc, MemoryDocDto>();
        }

        private void ScientistProfiles()
        {
            CreateMap<Scientist, ScientistDto>();
            CreateMap<ScientistModelDto, Scientist>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.MemoryPlaces, opt => opt.Ignore())
                .ForMember(dest => dest.ScientistDocs, opt => opt.Ignore())
                .ForMember(dest => dest.ScientistPhotos, opt => opt.Ignore());
        }

        private void ScientistPhotoProfiles()
        {
            CreateMap<ScientistPhoto, ScientistPhotoDto>();
        }
        private void ScientistDocProfiles()
        {
            CreateMap<ScientistDoc, ScientistDocDto>();
        }
    }
}
