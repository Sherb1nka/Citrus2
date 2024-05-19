using CitrusWeb.DataAccess.DomainObjects;

namespace CitrusWeb.Shared.DTOs.Mappings
{
    public static class VideoMapper
    {
        public static VideoDTO ToDto(this VideoDO obj)
        {
            return new()
            {
                Id = obj.Id,
                Presentations = obj.Presentations.Select(p => p.ToDto()).ToList(),
            };
        }

        public static VideoDO ToObj(this VideoDTO dto)
        {
            return new()
            {
                Presentations = dto.Presentations.Select(p => p.ToObj()).ToList(),
            };
        }
    }
}
